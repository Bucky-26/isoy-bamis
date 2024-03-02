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
    public partial class frm_add_info : Form
    {
        SqlConnection con;
        SqlCommand command;
        private string _id;
        private frm_maintenance maintenanceForm;
        public string _ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public frm_add_info(frm_maintenance maintenanceForm)
        {
            InitializeComponent();
            con = new SqlConnection(crud.connection);
            //  con.ConnectionString = crud.connection;
            //  con.Open();
            this.maintenanceForm = maintenanceForm;

        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                //command = new SqlCommand(sqlquery,conection);
                command = new SqlCommand("INSERT INTO TBL_OFFICIALS (NAME,CHAIRMANSHIP,POSITION,TERM_START,TERM_END,STATUS) VALUES(@NAME,@CHAIRMANSHIP,@POSITION,@TERM_START,@TERM_END,@STATUS)", con);
                command.Parameters.AddWithValue("@NAME",txt_name.Text);
                command.Parameters.AddWithValue("@CHAIRMANSHIP",txt_cm.Text);
                command.Parameters.AddWithValue("@POSITION",txt_pos.Text);
                command.Parameters.AddWithValue("@TERM_START",dp_ts.Value);
                command.Parameters.AddWithValue("@TERM_END",dt_te.Value);
                command.Parameters.AddWithValue("@STATUS",txt_tstats.Text);
                command.ExecuteNonQuery();


                con.Close();
                clear();
                maintenanceForm.load_data();
 
                MessageBox.Show("Data has been added successfully", declares._title + "[System]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }catch(Exception ex)
            {

                con.Close();

                MessageBox.Show(ex.Message, declares._title + "[error]",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        public void clear()
        {
            txt_name.Text = "";
               txt_cm.Text = "";
            txt_pos.Text = "";
           btn_save.Enabled = true;

            dp_ts.Value = DateTime.Today;
            dt_te.Value = DateTime.Today;
            txt_tstats.Text = Text = "";
            btn_update.Enabled = false;
        }

        private void frm_add_info_Load(object sender, EventArgs e)
        {

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                command = new SqlCommand("UPDATE TBL_OFFICIALS SET NAME=@NAME,CHAIRMANSHIP=@CHAIRMANSHIP,POSITION=@POSITION,TERM_START=@TERM_START,TERM_END=@TERM_END,STATUS=@STATUS WHERE ID = @ID",con);
                command.Parameters.AddWithValue("@NAME", txt_name.Text);
                command.Parameters.AddWithValue("@CHAIRMANSHIP", txt_cm.Text);
                command.Parameters.AddWithValue("@POSITION", txt_pos.Text);
                command.Parameters.AddWithValue("@TERM_START", dp_ts.Value);
                command.Parameters.AddWithValue("@TERM_END", dt_te.Value);
                command.Parameters.AddWithValue("@STATUS", txt_tstats.Text);
                command.Parameters.AddWithValue("@ID", _ID);
                command.ExecuteNonQuery();
                maintenanceForm.load_data();

                con.Close();

                MessageBox.Show("Data has been Updated successfully", declares._title + "[System]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
                this.Dispose();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, declares._title + "[error]", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}
