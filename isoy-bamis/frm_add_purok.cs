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
    public partial class frm_add_purok : Form
    {
        SqlConnection con;
        SqlCommand command;
        private string _id;
        private  frm_maintenance _new_maintenance;
        public string _ID {
            get { return _id; }
            set { _id = value; }
                       }
        public frm_add_purok(frm_maintenance _new_maintenance)
        {
            con = new SqlConnection(crud.connection);
            InitializeComponent();
            this._new_maintenance = _new_maintenance;
        }

        private void frm_add_purok_Load(object sender, EventArgs e)
        {
            MessageBox.Show(_ID);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                command = new SqlCommand("INSERT INTO tbl_purok (_PUROK,_PRESIDENT,_STATUS) VALUES(@purok,@pres,@stats)",con);
                command.Parameters.AddWithValue("@purok",txt_purok.Text);
                command.Parameters.AddWithValue("@pres",txt_pres.Text);
                command.Parameters.AddWithValue("@stats", cmbx_stats.Text);
                command.ExecuteNonQuery();
                
                MessageBox.Show("Data has been added successfully", declares._title + "[System]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _new_maintenance.load_purok();
                Clear();
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, declares._title + "[error]", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                con.Close();
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {



              
                con.Open();
                command = new SqlCommand("UPDATE tbl_purok SET _PUROK = @purok , _PRESIDENT = @pres,_STATUS = @stats WHERE _ID = @id",con);
                command.Parameters.AddWithValue("@purok", txt_purok.Text);
                command.Parameters.AddWithValue("@pres", txt_pres.Text);
                command.Parameters.AddWithValue("@stats", cmbx_stats.Text);
                command.Parameters.AddWithValue("@id", _ID);
                command.ExecuteNonQuery();
                _new_maintenance.load_purok();

                con.Close();
                    MessageBox.Show("The Record has been updated succesfully!", declares._title + "[SYSTEM]",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, declares._title + "[error]", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                con.Close();
            }
        }
        public void Clear()
        {
            txt_purok.Text = "";
            txt_pres.Text = "";
            cmbx_stats.Text = "";
            btn_save.Enabled = true;
            btn_update.Enabled = false;
        }
    }
}
