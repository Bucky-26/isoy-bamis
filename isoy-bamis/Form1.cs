﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace isoy_bamis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.Bounds.Height - 40;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Left = 0;
            this.Top = 0;
        }

        private void pnl_nav_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_docs new_docs = new frm_docs();
            new_docs.TopLevel = false;
            pnl_body.Controls.Add(new_docs);
            new_docs.BringToFront();
            new_docs.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}