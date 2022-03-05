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
    public partial class login : Form
    {
        SqlConnection connection;
        SqlCommand command;

        string db_connection = @"Data Source=RANA-ABOBAKAR\SQLEXPRESS;Initial Catalog=rafays;Integrated Security=true";
        public login()
        {
            InitializeComponent();
            this.connection = new SqlConnection(db_connection);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Forget password");
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            bool checklog = checklogin();
            if (checklog)
            {
                sales sales1 = new sales();
                sales1.Show();
                this.Hide();
            }
            else
            {

            }
        }
        public bool checklogin()
        {
          
            try
            {
                string uname = textBox1.Text.Trim();
                string upassword = textBox2.Text;
              
  
                command = new SqlCommand($"Select count(*) from admin where  name='{uname}' and password='{upassword}'", this.connection);
                this.connection.Open();
                int dd =(int) command.ExecuteScalar();
               
                    if (dd==1)
                    {
                        return true;
                    }
                    else
                    {
                        this.connection.Close();
                    label3.Text = "User Name or Password is Wrong";
                      //  MessageBox.Show(uname.ToString());
                        return false;
                    }
                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                this.connection.Close();
                return false;

            }
        }
    }
}
