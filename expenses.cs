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
    public partial class expenses : Form
    {
        SqlConnection connection;
        SqlCommand command;
        DataTable table = new DataTable();
        string db_connection = @"Data Source=RANA-ABOBAKAR\SQLEXPRESS;Initial Catalog=rafays;Integrated Security=true";
        bool edit_c = false;
        public expenses()
        {
            InitializeComponent();
            this.connection = new SqlConnection(db_connection);
            table.Columns.Add("Sr No");
            table.Columns.Add("Title");
            table.Columns.Add("Amount");
            table.Columns.Add("Detail");
           

            dataGridView1.DataSource = table;
            read_expenses();
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

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            customer customer1 = new customer();
            customer1.Show();
            this.Hide();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            customer customer1 = new customer();
            customer1.Show();
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

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void write_expenses()
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                try
                {
                    string sql = $"Insert into expenses(title,amount,detail)"
                        + $"values('{textBox1.Text}',{Convert.ToInt16(textBox2.Text)},'{richTextBox1.Text}')";
                    connection.Open();
                    command = new SqlCommand(sql, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.InsertCommand = command;
                    MessageBox.Show(adapter.InsertCommand.ExecuteNonQuery().ToString() + " New Record Added");

                    connection.Close();
                    textBox1.Text = textBox2.Text = richTextBox1.Text  = "";

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
        private void read_expenses()
        {
            try
            {
                SqlDataReader dataReader;
                command = new SqlCommand("Select * from expenses", this.connection);
                this.connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    DataRow row = this.table.NewRow();
                    row["Sr No"] = dataReader.GetValue(0);
                    row["Title"] = dataReader.GetValue(1);
                    row["Amount"] = dataReader.GetValue(2);
                    row["Detail"] = dataReader.GetValue(3);                  
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
        private void update_expenses()
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                try
                {
                    int id = Convert.ToInt32(textBox6.Text.Trim());
                    int amt = Convert.ToInt32(textBox2.Text.Trim());
                    string sql = $"update expenses "
                        + $"set title='{textBox1.Text}',amount={amt},detail='{textBox1.Text}'  where id={id}";
                    connection.Open();
                    command = new SqlCommand(sql, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.InsertCommand = command;
                    MessageBox.Show(adapter.InsertCommand.ExecuteNonQuery().ToString() + "  Record update");
                    connection.Close();
                    dataGridView1.Refresh();
                    table.Rows.Clear();
                    read_expenses();
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
        private void search_expenses()
        {

            try
            {
                table.Rows.Clear();
                int id = Convert.ToInt32(textBox7.Text);
                SqlDataReader dataReader;
                command = new SqlCommand($"Select * from expenses where id ={id}", this.connection);
                this.connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    DataRow row = this.table.NewRow();
                    row["Sr No"] = dataReader.GetValue(0);
                    row["Title"] = dataReader.GetValue(1);
                    row["Amount"] = dataReader.GetValue(2);
                    row["Detail"] = dataReader.GetValue(3);

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
                command = new SqlCommand($"Select * from expenses where id={id}", this.connection);
                this.connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    textBox1.Text = (string)dataReader.GetValue(1);
                    int amt = (int)dataReader.GetValue(2);
                    textBox2.Text = Convert.ToString(amt);
                    richTextBox1.Text = (string)dataReader.GetValue(3);
                  
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
                write_expenses();
                table.Rows.Clear();
                read_expenses();
            }
            else
            {
                update_expenses();
                edit_c = false;
                textBox1.Text =  textBox2.Text = richTextBox1.Text = "";
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox7.Text))
            {

                search_expenses();
            }
            else
            {
                table.Rows.Clear();
                read_expenses();
            }
        }
    }
}
