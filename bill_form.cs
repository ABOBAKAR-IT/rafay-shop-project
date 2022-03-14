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
using Microsoft.Reporting.WinForms;

namespace rafay_shop_project
{
    public partial class bill_form : Form
    {
        int id;
        SqlConnection connection;
        SqlCommand command;
        string db_connection = @"Data Source=RANA-ABOBAKAR\SQLEXPRESS;Initial Catalog=rafays;Integrated Security=true";
        public bill_form(int id)
        {
            InitializeComponent();
            this.id = id;
            this.connection = new SqlConnection(db_connection);
            show_report();
        }

        private void Bill_form_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void show_report()
        {
          
            string sql = $"select bills.id,user_tb.cname as name,bills.date,bills.panding as old_pending,item_bill.item_name,item_bill.quantity as item_quantity," +
                $"item_bill.price as item_price,item_bill.quantity*item_bill.price as total_item_price,user_tb.pending as new_pending,bills.p_amount,bills.n_amount,bills.g_total" +
                $"  from bills join user_tb on bills.customer_id=user_tb.id  join item_bill on bills.id=item_bill.bill_id where bill_id={id}";



            SqlDataAdapter dataReader =new SqlDataAdapter(sql,connection);
            DataSet1 ds = new DataSet1();
            dataReader.Fill(ds, "DataTable1");
            //  this.connection.Open();
            ReportDataSource dataSource = new ReportDataSource("DataSet1", ds.Tables[0]);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(dataSource);
            this.reportViewer1.RefreshReport();
          

         



           // connection.Close();
        }
    }
}
