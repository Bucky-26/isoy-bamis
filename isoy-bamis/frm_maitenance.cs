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
        public void update()
        {
            try
            {

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, declares._title + "[error]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
            try
            {
                string clm_name = dataGridView1.Columns[e.ColumnIndex].Name;
                if (clm_name == "edit")
                   {
                    frm_add_info _form = new frm_add_info(this);
                    _form.btn_save.Enabled = false;
                    _form._ID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    _form.txt_name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    _form.txt_cm.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    _form.txt_pos.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    _form.dp_ts.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                    _form.dt_te.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                    _form.txt_tstats.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    _form.btn_update.Enabled = true;
                    _form.ShowDialog();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, declares._title + "[error]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
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
