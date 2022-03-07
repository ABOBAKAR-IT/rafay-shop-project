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
    public partial class items : Form
    {
        SqlConnection connection;
        SqlCommand command;
        DataTable table = new DataTable();
        string db_connection = @"Data Source=RANA-ABOBAKAR\SQLEXPRESS;Initial Catalog=rafays;Integrated Security=true";
        bool edit_c = false;
        public items()
        {
            InitializeComponent();
            this.connection = new SqlConnection(db_connection);
            table.Columns.Add("Sr No");
            table.Columns.Add("Item Name");
            table.Columns.Add("Category");
            table.Columns.Add("Quantity");
            table.Columns.Add("S Price");
            table.Columns.Add("P Price");

            dataGridView1.DataSource = table;
            read_suppleyer();
          
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            customer customer1 = new customer();
            customer1.Show();
            this.Hide();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            customer customer1 = new customer();
            customer1.Show();
            this.Hide();
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

        private void Items_Load(object sender, EventArgs e)
        {

        }
        private void write_suppler()
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) && !string.IsNullOrWhiteSpace(comboBox1.Text) && !string.IsNullOrWhiteSpace(textBox5.Text))
            {
                try
                {

                    int panding = Convert.ToInt32(textBox5.Text);
                   
                    string sql = $"Insert into items(item_name,category,quantity,s_price,p_price)"
                        + $"values('{textBox1.Text}','{comboBox1.Text}',{Convert.ToInt32(textBox2.Text)},{Convert.ToInt32(textBox3.Text)},{Convert.ToInt32(textBox5.Text)})";
                    connection.Open();
                    command = new SqlCommand(sql, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.InsertCommand = command;
                    MessageBox.Show(adapter.InsertCommand.ExecuteNonQuery().ToString() + " New Record Added");

                    connection.Close();
                    textBox1.Text = textBox3.Text = textBox2.Text = textBox5.Text = "";

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
        private void read_suppleyer()
        {

            try
            {
                SqlDataReader dataReader;
                command = new SqlCommand("Select * from items", this.connection);
                this.connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                   
                    DataRow row = this.table.NewRow();
                    row["Sr No"] = dataReader.GetValue(0);
                    row["Item Name"] = dataReader.GetValue(1);
                    row["Category"] = dataReader.GetValue(2);
                    row["Quantity"] = dataReader.GetValue(3);
                    row["S Price"] = dataReader.GetValue(5);
                    row["P Price"] = dataReader.GetValue(4);

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
        private void update_suppleyer()
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) && !string.IsNullOrWhiteSpace(comboBox1.Text) && !string.IsNullOrWhiteSpace(textBox5.Text))
            {
                try
                {
                    int id = Convert.ToInt32(textBox6.Text);
                    
                  
                    string sql = $"update items "
                        + $"set item_name='{textBox1.Text}',category='{comboBox1.Text}',quantity='{textBox2.Text}',s_price='{textBox3.Text}',p_price='{textBox5.Text}' where id={id}";
                    connection.Open();
                    command = new SqlCommand(sql, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.InsertCommand = command;
                    MessageBox.Show(adapter.InsertCommand.ExecuteNonQuery().ToString() + "  Record update");
                    connection.Close();
                    dataGridView1.Refresh();
                    table.Rows.Clear();
                    read_suppleyer();
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
        private void search_suppleyer()
        {

            try
            {
                table.Rows.Clear();
                int id = Convert.ToInt32(textBox7.Text);
                SqlDataReader dataReader;
                command = new SqlCommand($"Select * from items where id ={id}", this.connection);
                this.connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    DataRow row = this.table.NewRow();
                    row["Sr No"] = dataReader.GetValue(0);
                    row["Item Name"] = dataReader.GetValue(1);
                    row["Category"] = dataReader.GetValue(2);
                    row["Quantity"] = dataReader.GetValue(3);
                    row["S Price"] = dataReader.GetValue(5);
                    row["P Price"] = dataReader.GetValue(4);

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
                command = new SqlCommand($"Select * from items where id={id}", this.connection);
                this.connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    textBox1.Text = (string)dataReader.GetValue(1);
                    comboBox1.Text = (string)dataReader.GetValue(2);

                    int v1 = (int)dataReader.GetValue(3);
                    int v2 = (int)dataReader.GetValue(4);
                    int v3 = (int)dataReader.GetValue(5);
                    textBox2.Text = Convert.ToString(v1);
                    textBox3.Text = Convert.ToString(v2);
                    textBox5.Text = Convert.ToString(v3);
                }

                this.connection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (edit_c == false)
            {
                write_suppler();
                table.Rows.Clear();
                read_suppleyer();
            }
            else
            {
                update_suppleyer();
                edit_c = false;
                textBox1.Text = textBox3.Text = textBox2.Text =  textBox5.Text = "";
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox7.Text))
            {

                search_suppleyer();
            }
            else
            {
                table.Rows.Clear();
                read_suppleyer();
            }
        }
    }
}
