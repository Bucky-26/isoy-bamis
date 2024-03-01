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
namespace isoy_bamis
{
    public partial class frm_maintenance : Form
    {

        SqlConnection con;
        SqlCommand com;
        SqlDataReader dataread;

        public frm_maintenance()
        {
            InitializeComponent();
            con = new SqlConnection(crud.connection);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void load_data()
        {
            try
            {
                dataGridView1.Rows.Clear();
                con.Open();
                com = new SqlCommand("select * from TBL_OFFICIALS",con);
                dataread = com.ExecuteReader();

                while (dataread.Read())
                {
                    dataGridView1.Rows.Add(dataread[0].ToString(), dataread[1].ToString(), dataread[2].ToString(), dataread[3].ToString(), DateTime.Parse(dataread[4].ToString()).ToShortDateString(), DateTime.Parse(dataread[5].ToString()).ToShortDateString(), dataread[6].ToString());
                }
                dataGridView1.ClearSelection();
                dataread.Close();
                con.Close();
            }catch(Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message, declares._title + "[error]", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            frm_add_info frm_add_new = new frm_add_info(this);
            frm_add_new.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
