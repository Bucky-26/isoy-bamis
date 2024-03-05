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
    public partial class frm_login : Form
    {
        SqlConnection con;
        SqlCommand com;
        public frm_login()
        {
            con = new SqlConnection(crud.connection);
            InitializeComponent();
        }
        public void Login(string username, string password)
        {
           
                con.Open();
                com = new SqlCommand("SELECT COUNT(1) FROM _USERS WHERE _USERNAME = @username AND _PASSWORD = @password", con);
                com.Parameters.AddWithValue("@username", username);
                com.Parameters.AddWithValue("@password", password);

                int count = (int)com.ExecuteScalar();

                if (count > 0)
                {
                    // Authentication succeeded
                    MessageBox.Show("Login successful");

                this.Hide();

                // Show the main form
                Form1 new_form = new Form1();
                new_form.FormClosed += (s, args) => this.Close(); // Close the application when the main form is closed
                new_form.Show();
            }
            else
                {
                    // Authentication failed
                    MessageBox.Show("Invalid username or password");
                }
            con.Close();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txt_pass.Text == "" || txt_user.Text == "")
            {
                MessageBox.Show("Please Provide 'username' and 'password'");
            }
            else
            {
                   Login(txt_user.Text,txt_pass.Text);
                    }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
