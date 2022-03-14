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
            this.chart1.Series["Sales"].Points.AddXY("sales", 50);
            this.chart1.Series["Sales"].Points.AddXY("sales", 500);

            DateTime d;
            try
            {
                SqlDataReader dataReader;
                command = new SqlCommand("select * from bills", this.connection);
                this.connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                  
                  d=(DateTime)  dataReader.GetValue(3);
                    this.chart1.Series["Sales"].Points.AddXY("sale", dataReader.GetValue(6));


                }
               
                this.connection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
           
        }
    }
}
