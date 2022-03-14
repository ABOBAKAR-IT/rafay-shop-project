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
    public partial class Report_Form : Form
    {
        SqlConnection connection;
        SqlCommand command;
      
        string db_connection = @"Data Source=RANA-ABOBAKAR\SQLEXPRESS;Initial Catalog=rafays;Integrated Security=true";

        public Report_Form()
        {
            InitializeComponent();
            this.connection = new SqlConnection(db_connection);
        }

        private void Report_Form_Load(object sender, EventArgs e)
        {
            chart1show();

        }
        private void chart1show()
        {
           // this.chart1.Series["Sales"].Points.AddXY("sales", 50);
           // this.chart1.Series["Sales"].Points.AddXY("sales", 500);

            DateTime d;
            try
            {
                SqlDataReader dataReader;
                command = new SqlCommand("select * from bills", this.connection);
                this.connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                  
                  d=(DateTime)  dataReader.GetValue(2);
                    int dd =Convert.ToInt16( d.ToString("dd"));
                      this.chart1.Series["Sales"].Points.AddXY(dd, dataReader.GetValue(6));
                  //  MessageBox.Show(dd.ToString());

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

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            sales sales1 = new sales();
            sales1.Show();
            this.Hide();
        }

        private void Label_Click(object sender, EventArgs e)
        {
            sales sales1 = new sales();
            sales1.Show();
            this.Hide();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            customer customer1 = new customer();
            customer1.Show();
            this.Hide();
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            suppley suppley1 = new suppley();
            suppley1.Show();
            this.Hide();
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            suppley suppley1 = new suppley();
            suppley1.Show();
            this.Hide();
        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            expenses expenses1 = new expenses();
            expenses1.Show();
            this.Hide();
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            expenses expenses1 = new expenses();
            expenses1.Show();
            this.Hide();
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            items items1 = new items();
            items1.Show();
            this.Hide();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            items items1 = new items();
            items1.Show();
            this.Hide();
        }
    }
}
