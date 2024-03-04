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
    public partial class frm_res_details : Form
    {
        SqlConnection _con;
        SqlCommand _com;
        SqlDataReader _readData;
        public frm_res_details()
        {
            _con = new SqlConnection(crud.connection);
            InitializeComponent();
            load_purok();
        }
        public void load_purok()
        {
            try
            {   
                _con.Open();
                cmbx_purok.Items.Clear();
                _com = new SqlCommand("SELECT * FROM tbl_purok",_con);
                _readData = _com.ExecuteReader();
                while (_readData.Read())
                {
                    cmbx_purok.Items.Add(_readData[1].ToString());
                }
                _con.Close();
                _readData.Close();
            }
            catch (Exception ex)
            {
                _con.Close();
                MessageBox.Show(ex.Message, declares._title + "[ERROR]", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void frm_res_details_Load(object sender, EventArgs e)
        {
           
        }

        private void label23_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files (*.png)|*.png|(*.jpg)|*.jpg";
            openFileDialog1.ShowDialog();
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
