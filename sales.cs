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
            Report_Form rf = new Report_Form();
            rf.Show();
            this.Hide();

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
        int g_total = 0, n_amount = 0;
        private void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) && !string.IsNullOrWhiteSpace(comboBox2.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
            {
                int amt = Convert.ToInt32(textBox4.Text);
                 g_total = Convert.ToInt32(textBox3.Text);
                 n_amount = Convert.ToInt32(textBox2.Text);


                int count = 0;
                try
                {
                     DateTime dte = DateTime.Now;
                      string daate = dte.ToString("yyyy-MM-dd");
                  


                    string sql = $"Insert into bills(customer_id,date,panding,p_amount,g_total,n_amount)"
                         + $"values({cstmr_id},'{daate}',{pnd_m},{amt},{g_total},{n_amount})";

                    connection.Open();
                    command = new SqlCommand(sql, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    connection.Close();

                    SqlDataReader dataReader;
                    command = new SqlCommand("Select count(*) from bills", this.connection);
                    this.connection.Open();
                    dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        count = (int)dataReader.GetValue(0);
                    }
                    dataGridView1.Refresh();
                    this.connection.Close();

                    this.connection.Open();
                    foreach (DataRow row in table.Rows)
                    {
                        int q = Convert.ToInt32(row["Quantity"]);
                        int p = Convert.ToInt32(row["Price"]);
                        string n = Convert.ToString(row["Item Name"]);

                        //  MessageBox.Show(q.ToString());

                        sql = $"Insert into item_bill (item_name,quantity,price,bill_id)"
                           + $"values ('{n}',{q},{p},{count})";
                        command = new SqlCommand(sql, connection);
                        SqlDataAdapter adapter2 = new SqlDataAdapter();
                        adapter2.InsertCommand = command;
                        adapter2.InsertCommand.ExecuteNonQuery();

                        //update item quantity

                        sql = $"update items "
                           + $"set quantity=quantity-{q} where item_name='{n}'";
                        command = new SqlCommand(sql, connection);
                        SqlDataAdapter adapter1 = new SqlDataAdapter();
                        adapter1.InsertCommand = command;
                        adapter1.InsertCommand.ExecuteNonQuery();

                    }
                    //  cstmr_id
                    int toam = Convert.ToInt16(textBox3.Text);
                    int pp = toam - amt;
                    sql = $"update user_tb "
                     + $"set pending={pp} where id={cstmr_id}";
                    command = new SqlCommand(sql, connection);
                    SqlDataAdapter adapter3 = new SqlDataAdapter();
                    adapter3.InsertCommand = command;
                    adapter3.InsertCommand.ExecuteNonQuery();

                    this.connection.Close();
                    MessageBox.Show("Bill save in database");

                    bill_form billshow = new bill_form(count);
                    billshow.Show();

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else
            {
                MessageBox.Show("Something missing...");
            }
        }

        private void combobox_Category()
        {

        }

        private void ComboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            combobox_get_items();
        }
       
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
        int sumt = 0;
        int grand_t = 0;
        int pnd_m = 0;
        int reming_quantity = 0;
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
                        reming_quantity = q - increment;
                        add++;
                        row["Item Name"] = id;
                        row["Sr No"] = add;
                        row["Quantity"] = increment;
                        row["Price"] = dataReader.GetValue(5);
                        int total = increment * Convert.ToInt32(dataReader.GetValue(5));
                        sumt = sumt + total;
                        row["Total Price"] = total;
                        this.table.Rows.Add(row);
                        textBox2.Text = Convert.ToString(sumt);
                        textBox3.Text = Convert.ToString(sumt+pnd_m);
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


        int cstmr_id = 0;
        private void ComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

            string nam = comboBox1.GetItemText(comboBox1.SelectedItem);
          //  MessageBox.Show(nam);

            string[] names = nam.Split(',');
            int id = Convert.ToInt32(names[1]);
          //  MessageBox.Show(names[1]);
            try
            {

              
                SqlDataReader dataReader;
                command = new SqlCommand($"Select * from user_tb where id={id}", this.connection);
                this.connection.Open();
                dataReader = command.ExecuteReader();
                //   //   MessageBox.Show(id);
                while (dataReader.Read())
                {
                    cstmr_id = (int)dataReader.GetValue(0);
                    int pnding = (int)dataReader.GetValue(4);
                    textBox1.Text = Convert.ToString(pnding);
                    pnd_m = pnding;
                }
                dataGridView1.Refresh();
                this.connection.Close();
                textBox3.Text = Convert.ToString(sumt + pnd_m);
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            increment = Convert.ToInt32(label19.Text);
            increment++;
            label19.Text = Convert.ToString(increment);
        }

        private void Panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            table.Rows.Clear();
            g_total = 0;
            n_amount = 0;
            textBox2.Text = "";
            textBox3.Text = "";
            sumt = 0;
        }

        private void combobox_get_items()
        {
            try
            {

                string id = comboBox3.GetItemText(comboBox3.SelectedItem);
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
                    string name = (string)dataReader.GetValue(1)+","+ Convert.ToString((int)dataReader.GetValue(0));
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
