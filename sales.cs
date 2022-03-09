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
    public partial class sales : Form
    {
        SqlConnection connection;
        SqlCommand command;
        DataTable table = new DataTable();
        string db_connection = @"Data Source=RANA-ABOBAKAR\SQLEXPRESS;Initial Catalog=rafays;Integrated Security=true";
        bool edit_c = false;
        public sales()
        {
            InitializeComponent();
            this.connection = new SqlConnection(db_connection);
            table.Columns.Add("Sr No");
            table.Columns.Add("Item Name");
            //  table.Columns.Add("Category");
            table.Columns.Add("Quantity");
            table.Columns.Add("Price");
            table.Columns.Add("Total Price");

            dataGridView1.DataSource = table;
            combobox_get_customers();

        }

        private void Sales_Load(object sender, EventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {



        }

        private void Label_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void Label3_Click(object sender, EventArgs e)
        {
            suppley suppley1 = new suppley();
            suppley1.Show();
            this.Hide();
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {
            expenses expenses1 = new expenses();
            expenses1.Show();
            this.Hide();
        }

        private void Label13_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            customer customer1 = new customer();
            customer1.Show();
            this.Hide();
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            items items1 = new items();
            items1.Show();
            this.Hide();
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            suppley suppley1 = new suppley();
            suppley1.Show();
            this.Hide();
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            expenses expenses1 = new expenses();
            expenses1.Show();
            this.Hide();
        }

        private void PictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }
        private void combobox_Category()
        {

        }

        private void ComboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            combobox_get_items();
        }
        string items_name, stock, s_price;
        int increment;

        private void Button3_Click(object sender, EventArgs e)
        {
            int ch = Convert.ToInt32(label19.Text);
            if (!(ch <= 1))
            {
                increment = Convert.ToInt32(label19.Text);
                increment--;
                label19.Text = Convert.ToString(increment);
            }
        }
        int add = 0;
        private void Button5_Click(object sender, EventArgs e)
        {
            try
            {

                //  table.Rows.Clear();
                string id = comboBox2.Text;
                // MessageBox.Show(id);
                SqlDataReader dataReader;
                command = new SqlCommand($"Select * from items where item_name='{id}' and category='{comboBox3.Text}'", this.connection);
                this.connection.Open();
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    DataRow row = this.table.NewRow();

                    int q = (int)dataReader.GetValue(3);


                    if (q >= increment)
                    {
                        add++;
                        row["Item Name"] = id;
                        row["Sr No"] = add;
                        row["Quantity"] = increment;
                        row["Price"] = dataReader.GetValue(5);
                        int total = increment * Convert.ToInt32(dataReader.GetValue(5));
                        row["Total Price"] = total;
                        this.table.Rows.Add(row);
                    }
                    else
                    {
                        MessageBox.Show("Out of Stock");
                    }


                }
                dataGridView1.Refresh();
                this.connection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }



        }

        private void ComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

          

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            increment = Convert.ToInt32(label19.Text);
            increment++;
            label19.Text = Convert.ToString(increment);
        }

        private void combobox_get_items()
        {
            try
            {

                string id = comboBox3.GetItemText(comboBox3.SelectedText);
                SqlDataReader dataReader;
                command = new SqlCommand($"Select * from items where category='{id}'", this.connection);
                this.connection.Open();
                dataReader = command.ExecuteReader();
                //   //   MessageBox.Show(id);
                while (dataReader.Read())
                {
                    string name = (string)dataReader.GetValue(1);
                    comboBox2.Items.Add(name);
                }
                dataGridView1.Refresh();
                this.connection.Close();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }



        }

        private void combobox_get_customers()
        {
            try
            {

              //  string id = comboBox3.GetItemText(comboBox3.SelectedText);
                SqlDataReader dataReader;
                command = new SqlCommand($"Select * from user_tb where ctype='customer'", this.connection);
                this.connection.Open();
                dataReader = command.ExecuteReader();
                //   //   MessageBox.Show(id);
                while (dataReader.Read())
                {
                    string name = (string)dataReader.GetValue(1);
                    comboBox1.Items.Add(name);
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
