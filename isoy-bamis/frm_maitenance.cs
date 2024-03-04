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

        public void update(int eColumnIndex, int eRowIndex)
        {
            
            try
            {
                string clm_name = dataGridView1.Columns[eColumnIndex].Name;
                frm_add_info _form = new frm_add_info(this);
                _form.btn_save.Enabled = false;
                _form._ID = dataGridView1.Rows[eRowIndex].Cells[0].Value.ToString();
                _form.txt_name.Text = dataGridView1.Rows[eRowIndex].Cells[1].Value.ToString();
                _form.txt_cm.Text = dataGridView1.Rows[eRowIndex].Cells[2].Value.ToString();
                _form.txt_pos.Text = dataGridView1.Rows[eRowIndex].Cells[3].Value.ToString();
                _form.dp_ts.Value = DateTime.Parse(dataGridView1.Rows[eRowIndex].Cells[4].Value.ToString());
                _form.dt_te.Value = DateTime.Parse(dataGridView1.Rows[eRowIndex].Cells[5].Value.ToString());
                _form.txt_tstats.Text = dataGridView1.Rows[eRowIndex].Cells[6].Value.ToString();
                _form.btn_update.Enabled = true;
                _form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, declares._title + "[error]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            }
        public void delete_data(string id)
        {
            try
            {
                con.Open();
                // Replace "ID" with the appropriate primary key column name in your TBL_OFFICIALS table
                com = new SqlCommand("DELETE FROM TBL_OFFICIALS WHERE ID = @id", con);
                com.Parameters.AddWithValue("@id", id);
                com.ExecuteNonQuery();
                con.Close();
                load_data();
            }
            catch (Exception ex)
            {
                con.Close();
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
                if (e.RowIndex >= 0)
                {
                    string clm_name = dataGridView1.Columns[e.ColumnIndex].Name;
                    switch (clm_name)
                    {
                        case "edit":
                            update(e.ColumnIndex, e.RowIndex);
                            break;
                        case "delete":
                            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                delete_data(id);
                                MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm_add_purok new_form = new frm_add_purok(this);
            new_form.ShowDialog(); 
        }
        public void load_purok()
        {
            try
            {
                dataGridView2.Rows.Clear();
                con.Open();
                com = new SqlCommand("SELECT * FROM tbl_purok",con);
                dataread = com.ExecuteReader();
                while (dataread.Read())
                {
                    dataGridView2.Rows.Add(dataread[0].ToString(), dataread[1].ToString(), dataread[2].ToString(), dataread[3].ToString());

                }

                dataGridView2.ClearSelection();
                dataread.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, declares._title + "[error]", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        public void delete_purok(string id)
        {
            con.Open();
            com = new SqlCommand("Delete From tbl_purok Where _ID = @id", con);
            com.Parameters.AddWithValue("@id", id);
            com.ExecuteNonQuery();
            load_purok();
            con.Close();
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            string col_name = dataGridView2.Columns[e.ColumnIndex].Name;
                switch (col_name)
                {
                    case "_edit":
                        frm_add_purok _new_purok = new frm_add_purok(this);
                    _new_purok._ID = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();

                    _new_purok.txt_purok.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                        _new_purok.txt_pres.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                        _new_purok.cmbx_stats.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                    _new_purok.btn_update.Enabled = true;
                    _new_purok.btn_save.Enabled = false;
                  //  MessageBox.Show(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                        _new_purok.ShowDialog();
                        break;
                    case "_delete":

                    DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {

                        string id = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                        delete_purok(id);
                        MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                    }
                    break;

                }
            
        }
    }
}
