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

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_res_details new_form = new frm_res_details();
           
            new_form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void Load_data()
        {
            con.Open();
            com = new SqlCommand("SELECT * FROM _RESIDENTS",con);
            record_reader = com.ExecuteReader();
            while (record_reader.Read())
            {
                dataGridView1.Rows.Add(record_reader[0].ToString(), record_reader[1].ToString(), record_reader[2].ToString(), record_reader[3].ToString(), record_reader[4].ToString(), record_reader[18].ToString(), record_reader[20].ToString(), DateTime.Parse(record_reader[6].ToString()).ToShortDateString(), record_reader[19].ToString(), record_reader[10].ToString(), record_reader[9].ToString());
            }
            record_reader.Close();
            con.Close();


        }
    }
}
