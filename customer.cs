﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rafay_shop_project
{
    public partial class customer : Form
    {
        public customer()
        {
            InitializeComponent();
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
    }
}
