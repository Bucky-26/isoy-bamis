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
using System.IO;
namespace isoy_bamis
{
    public partial class frm_residents : Form
    {
        SqlConnection con;
        SqlDataReader record_reader;
        SqlCommand com;
        public frm_residents()
        {
            con = new SqlConnection(crud.connection);
            InitializeComponent();
        }
        public void edit_rec(int e)
        {
            frm_res_details new_res = new frm_res_details(this);

            try
            {
                con.Open();

                com = new SqlCommand("SELECT * FROM _RESIDENTS WHERE _ID = @id", con);
                com.Parameters.AddWithValue("@id", dataGridView1.Rows[e].Cells[0].Value.ToString());
                record_reader = com.ExecuteReader();

                if (record_reader.Read())
                {
                    byte[] imageData = (byte[])record_reader["_image"]; // Fetch the image data
                    MemoryStream ms = new MemoryStream(imageData);
                    Bitmap bitmap = new Bitmap(ms);

                    new_res._ID = record_reader["_ID"].ToString();
                    new_res.txt_nid.Text = record_reader[1].ToString();
                    new_res.txt_lname.Text = record_reader["_LAST_NAME"].ToString();
                    new_res.txt_fname.Text = record_reader["_FIRST_NAME"].ToString();
                    new_res.txt_mname.Text = record_reader["_MIDDLE_NAME"].ToString();
                    new_res.txt_nname.Text = record_reader["_NICKNAME"].ToString();
                    new_res.dp_birth.Value = DateTime.Parse(record_reader["_DATE_OF_BIRTH"].ToString());
                    new_res.txt_baddress.Text = record_reader["_BIRTH_PLACE"].ToString();
                    new_res.txt_age.Text = record_reader["_AGE"].ToString();
                    new_res.cmbx_cs.Text = record_reader["_CIVIL_STATUS"].ToString();
                    new_res.cmbx_gender.Text = record_reader["_GENDER"].ToString();
                    new_res.txt_religion.Text = record_reader["_RELIGION"].ToString();
                    new_res.txt_email.Text = record_reader["_EMAIL"].ToString();
                    new_res.txt_contact.Text = record_reader["_CONTACT_NO"].ToString();
                    new_res.cmbx_vs.Text = record_reader["_VOTER_STATS"].ToString();
                    new_res.txt_precint.Text = record_reader["_PRECINT_NO"].ToString();
                    new_res.cmbx_purok.Text = record_reader["_PUROK"].ToString();
                    new_res.txt_occ.Text = record_reader["_OCCU"].ToString();
                    new_res.txt_cat.Text = record_reader["_CAT"].ToString();
                    new_res.txt_address.Text = record_reader["_ADDRESS"].ToString();
                    new_res.txt_house.Text = record_reader["_H_NO"].ToString();
                    new_res.txt_stats.Text = record_reader["_STATUS"].ToString();
                    new_res.pictureBox1.Image = bitmap;

                    new_res.ShowDialog();
                 
                }
                con.Close();
                record_reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, declares._title + "[ERROR]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_res_details new_form = new frm_res_details(this);
           
            new_form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string col_name = dataGridView1.Columns[e.ColumnIndex].Name;
            try
            {
                switch (col_name)
                {
                    case "edit":
                        edit_rec(e.RowIndex);
                        break;
                    case "delete":


                        break;
                }
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, declares._title + "[ERROR]", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                con.Close();
            }
        }
        public void Load_data()
        {
            con.Open();
            dataGridView1.Rows.Clear();
            com = new SqlCommand("SELECT * FROM _RESIDENTS",con);
            record_reader = com.ExecuteReader();
            while (record_reader.Read())
            {
                dataGridView1.Rows.Add(record_reader[0].ToString(), record_reader[1].ToString(), record_reader[2].ToString(), record_reader[3].ToString(), record_reader[4].ToString(), record_reader[5].ToString(), record_reader["_ADDRESS"].ToString(), record_reader["_H_NO"].ToString(), DateTime.Parse(record_reader["_DATE_OF_BIRTH"].ToString()).ToShortDateString(), record_reader["_CAT"].ToString(), record_reader["_GENDER"].ToString(), record_reader["_CIVIL_STATUS"].ToString()); ;
            }
            record_reader.Close();
            con.Close();


        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
         
        }
        public string resTotal()
        {
            try
            {
                con.Open();
                com = new SqlCommand("Select Count(*) From _RESIDENTS", con);
                string total = com.ExecuteScalar().ToString();
                return total;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, declares._title + "[error]", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return "0";
            }
            finally
            {
                con.Close(); // Ensure the connection is closed in all cases
            }
        }

    }
}
