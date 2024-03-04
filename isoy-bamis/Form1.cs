using System;
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
            frm_maintenance frm_off = new frm_maintenance();
            frm_off.TopLevel = false;
            pnl_body.Controls.Add(frm_off);
            frm_off.BringToFront();
            frm_off.load_data();
            frm_off.load_purok();
            frm_off.Show();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_residents_Click(object sender, EventArgs e)
        {
            frm_residents new_form = new frm_residents();
            
            new_form.TopLevel = false;
            pnl_body.Controls.Add(new_form);

            new_form.BringToFront();
            new_form.Show();
        }
    }
}
