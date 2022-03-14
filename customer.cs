using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace rafay_shop_project
{
    public partial class customer : Form
    {
        SqlConnection connection;
        SqlCommand command;
        DataTable table = new DataTable();
        string db_connection = @"Data Source=RANA-ABOBAKAR\SQLEXPRESS;Initial Catalog=rafays;Integrated Security=true";
        bool edit_c = false;
        public customer()
        {
            InitializeComponent();
            this.connection = new SqlConnection(db_connection);
            table.Columns.Add("Sr No");
            table.Columns.Add("Name");
            table.Columns.Add("Address");
            table.Columns.Add("Contect No");
            table.Columns.Add("Email");
            table.Columns.Add("Panding");
            
            dataGridView1.DataSource = table;
            read_customer();
        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void Label_Click(object sender, EventArgs e)
        {
            sales sales1 = new sales();
            sales1.Show();
            this.Hide();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            sales sales1 = new sales();
            sales1.Show();
            this.Hide();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            items items1 = new items();
            items1.Show();
            this.Hide();
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            items items1 = new items();
            items1.Show();
            this.Hide();
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            suppley suppley1 = new suppley();
            suppley1.Show();
            this.Hide();
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            suppley suppley1 = new suppley();
            suppley1.Show();
            this.Hide();
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            expenses expenses1 = new expenses();
            expenses1.Show();
            this.Hide();
        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            expenses expenses1 = new expenses();
            expenses1.Show();
            this.Hide();
        }

        private void Customer_Load(object sender, EventArgs e)
        {

        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (edit_c == false)
            {

            write_customer();
            }
            else
            {
                update_customer();
            }
        }
        private void write_customer()
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox5.Text))
            {
                try
                {
                   
                    int panding = Convert.ToInt32(textBox5.Text);
                    string type = "customer";
                    string sql = $"Insert into user_tb(cname,caddress,contect_no,pending,email,ctype)"
                        + $"values('{textBox1.Text}','{textBox3.Text}','{textBox2.Text}',{panding},'{textBox4.Text}','{type}')";
                    connection.Open();
                    command = new SqlCommand(sql, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.InsertCommand = command;
                    MessageBox.Show(adapter.InsertCommand.ExecuteNonQuery().ToString() + " New Record Added");
                
                    connection.Close();
                    textBox1.Text = textBox3.Text = textBox2.Text = textBox4.Text = textBox5.Text = "";

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else
            {
                MessageBox.Show("Something Missing!");
            }
        }
        private void read_customer()
        {

            try
            {
                SqlDataReader dataReader;
                command = new SqlCommand("Select * from user_tb where ctype='customer'", this.connection);
                this.connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    DataRow row = this.table.NewRow();
                    row["Sr No"] = dataReader.GetValue(0);
                    row["Name"] = dataReader.GetValue(1);
                    row["Address"] = dataReader.GetValue(2);
                    row["Contect No"] = dataReader.GetValue(3);
                    row["Email"] = dataReader.GetValue(5);
                    row["Panding"] = dataReader.GetValue(4);
                 
                    this.table.Rows.Add(row);
                }
                dataGridView1.Refresh();
                this.connection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
           
            edit_c = true;
            try
            {
                int id = Convert.ToInt32(textBox6.Text);
                SqlDataReader dataReader;
                command = new SqlCommand($"Select * from user_tb where id={id} and ctype='customer'", this.connection);
                this.connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {  
                    textBox1.Text = (string)dataReader.GetValue(1);
                    textBox3.Text = (string)dataReader.GetValue(2);
                    textBox2.Text = (string)dataReader.GetValue(3);
                    textBox4.Text = (string)dataReader.GetValue(5);
                    int pnd = (int)dataReader.GetValue(4);
                    textBox5.Text = Convert.ToString(pnd);

                }
               
                this.connection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            {
                if (edit_c == false)
                {
                    write_customer();
                    table.Rows.Clear();
                    read_customer();
                }
                else
                {
                    update_customer();
                    edit_c = false;
                    textBox1.Text = textBox3.Text = textBox2.Text = textBox4.Text = textBox5.Text = "";
                }
            }
        }
        private void update_customer()
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox5.Text))
            {
                try
                {
                    int id = Convert.ToInt32(textBox6.Text);
                    int panding = Convert.ToInt32(textBox5.Text);
                    string type = "customer";
                    string sql = $"update user_tb "
                        + $"set cname='{textBox1.Text}',caddress='{textBox3.Text}',contect_no='{textBox2.Text}',pending={panding},email='{textBox4.Text}',ctype='{type}' where id={id} and ctype='customer'";
                    connection.Open();
                    command = new SqlCommand(sql, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.InsertCommand = command;
                    MessageBox.Show(adapter.InsertCommand.ExecuteNonQuery().ToString() + "  Record update");
                    connection.Close();
                    dataGridView1.Refresh();
                    table.Rows.Clear();
                    read_customer();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else
            {
                MessageBox.Show("Something Missing!");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox7.Text))
            {

            search_customer();
            }
            else
            {
                table.Rows.Clear();
                read_customer();
            }
        }
        private void search_customer()
        {

            try
            {
                table.Rows.Clear();
                int id = Convert.ToInt32(textBox7.Text);
                SqlDataReader dataReader;
                command = new SqlCommand($"Select * from user_tb where id ={id} and ctype ='customer'", this.connection);
                this.connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    DataRow row = this.table.NewRow();
                    row["Sr No"] = dataReader.GetValue(0);
                    row["Name"] = dataReader.GetValue(1);
                    row["Address"] = dataReader.GetValue(2);
                    row["Contect No"] = dataReader.GetValue(3);
                    row["Email"] = dataReader.GetValue(5);
                    row["Panding"] = dataReader.GetValue(4);

                    this.table.Rows.Add(row);
                }
                dataGridView1.Refresh();
                this.connection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

    }
}



