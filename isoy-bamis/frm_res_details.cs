﻿using System;
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
    public partial class frm_res_details : Form
    {
        SqlConnection _con;
        SqlCommand _com;
        SqlDataReader _readData;
        frm_residents new_form;
      private  string _id;

       public string _ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public frm_res_details(frm_residents new_form)
        {
            _con = new SqlConnection(crud.connection);
            InitializeComponent();
            load_purok();
            this.new_form = new_form;
        }
        private void ClearControls()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Text = string.Empty;
                }
                else if (ctrl is ComboBox)
                {
                    ((ComboBox)ctrl).SelectedIndex = -1;
                }
                // Add other control types as needed (e.g., DateTimePicker)

                // Clear specific controls
                if (ctrl.Name == "dp_birth") // Assuming "dp_birth" is the name of your DateTimePicker control
                {
                    ((DateTimePicker)ctrl).Value = DateTime.Now;
                }
                pictureBox1.Image = null;
            }
        }

        public void add_resident()
        {
            MemoryStream save_img = new MemoryStream();
            pictureBox1.Image.Save(save_img, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] arrImage = save_img.GetBuffer();
            _con.Open();
            _com = new SqlCommand("INSERT INTO _RESIDENTS (_NATIONAL_ID, _LAST_NAME, _FIRST_NAME, _MIDDLE_NAME, _NICKNAME, _DATE_OF_BIRTH, _BIRTH_PLACE, _AGE, _CIVIL_STATUS, _GENDER, _RELIGION, _EMAIL, _CONTACT_NO, _VOTER_STATS, _PRECINT_NO, _PUROK, _OCCU, _ADDRESS, _CAT, _H_NO, _STATUS,_image) VALUES (@NationalId, @LastName, @FirstName, @MiddleName, @Nickname, @DateOfBirth, @BirthPlace, @Age, @CivilStatus, @Gender, @Religion, @Email, @ContactNo, @VoterStats, @PrecintNo, @Purok, @Occupation, @Address, @Category, @HouseNo, @Status,@img)", _con);
            _com.Parameters.AddWithValue("@NationalId", txt_nid.Text );
            _com.Parameters.AddWithValue("@LastName", txt_lname.Text);
            _com.Parameters.AddWithValue("@FirstName",txt_fname.Text);
            _com.Parameters.AddWithValue("@MiddleName", txt_mname.Text);
            _com.Parameters.AddWithValue("@Nickname",txt_nname.Text);
            _com.Parameters.AddWithValue("@DateOfBirth", dp_birth.Value);
            _com.Parameters.AddWithValue("@BirthPlace",txt_baddress.Text);
            _com.Parameters.AddWithValue("@Age", txt_age.Text);
            _com.Parameters.AddWithValue("@CivilStatus", cmbx_cs.Text);
            _com.Parameters.AddWithValue("@Gender", cmbx_gender.Text);
            _com.Parameters.AddWithValue("@Religion", txt_religion.Text);
            _com.Parameters.AddWithValue("@Email", txt_email.Text);
            _com.Parameters.AddWithValue("@ContactNo", txt_contact.Text);
            _com.Parameters.AddWithValue("@VoterStats", cmbx_vs.Text);
            _com.Parameters.AddWithValue("@PrecintNo", txt_precint.Text);
            _com.Parameters.AddWithValue("@Purok", cmbx_purok.Text);
            _com.Parameters.AddWithValue("@Occupation",txt_occ.Text);
            _com.Parameters.AddWithValue("@Address",txt_address.Text);
            _com.Parameters.AddWithValue("@Category", txt_cat.Text);
            _com.Parameters.AddWithValue("@HouseNo", txt_house.Text);
            _com.Parameters.AddWithValue("@Status", txt_stats.Text);
            _com.Parameters.AddWithValue("@img", arrImage);

            _com.ExecuteNonQuery();
             
            _con.Close();
            MessageBox.Show("Resident Info has been save successfully", declares._title + "[SYSTEM]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            new_form.Load_data();
            new_form.lblTotal.Text = $"({new_form.resTotal()})";
        }

        /// <summary>
        /// ////////////
        /// 
        /// 
        public void res_Update()
        {
            // Validate all fields
            if (string.IsNullOrWhiteSpace(txt_nid.Text) ||
                string.IsNullOrWhiteSpace(txt_lname.Text) ||
                string.IsNullOrWhiteSpace(txt_fname.Text) ||
                string.IsNullOrWhiteSpace(txt_mname.Text) ||
                string.IsNullOrWhiteSpace(txt_nname.Text) ||
                string.IsNullOrWhiteSpace(txt_baddress.Text) ||
                string.IsNullOrWhiteSpace(txt_age.Text) ||
                string.IsNullOrWhiteSpace(cmbx_cs.Text) ||
                string.IsNullOrWhiteSpace(cmbx_gender.Text) ||
                string.IsNullOrWhiteSpace(txt_religion.Text) ||
                string.IsNullOrWhiteSpace(txt_email.Text) ||
                string.IsNullOrWhiteSpace(txt_contact.Text) ||
                string.IsNullOrWhiteSpace(cmbx_vs.Text) ||
                string.IsNullOrWhiteSpace(txt_precint.Text) ||
                string.IsNullOrWhiteSpace(cmbx_purok.Text) ||
                string.IsNullOrWhiteSpace(txt_occ.Text) ||
                string.IsNullOrWhiteSpace(txt_address.Text) ||
                string.IsNullOrWhiteSpace(txt_cat.Text) ||
                string.IsNullOrWhiteSpace(txt_house.Text) ||
                string.IsNullOrWhiteSpace(txt_stats.Text) ||
                pictureBox1.Image == null)
            {
                MessageBox.Show("Please fill in all fields.", declares._title + "[SYSTEM]", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MemoryStream save_img = new MemoryStream();
            pictureBox1.Image.Save(save_img, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] arrImage = save_img.GetBuffer();
            _con.Open();
            _com = new SqlCommand(@"UPDATE _RESIDENTS 
                            SET 
                                _NATIONAL_ID = @NationalId, 
                                _LAST_NAME = @LastName, 
                                _FIRST_NAME = @FirstName, 
                                _MIDDLE_NAME = @MiddleName, 
                                _NICKNAME = @Nickname, 
                                _DATE_OF_BIRTH = @DateOfBirth, 
                                _BIRTH_PLACE = @BirthPlace, 
                                _AGE = @Age, 
                                _CIVIL_STATUS = @CivilStatus, 
                                _GENDER = @Gender, 
                                _RELIGION = @Religion, 
                                _EMAIL = @Email, 
                                _CONTACT_NO = @ContactNo, 
                                _VOTER_STATS = @VoterStats, 
                                _PRECINT_NO = @PrecintNo, 
                                _PUROK = @Purok, 
                                _OCCU = @Occupation, 
                                _ADDRESS = @Address, 
                                _CAT = @Category, 
                                _H_NO = @HouseNo, 
                                _STATUS = @Status, 
                                _image = @img
                            WHERE  _ID= @id", _con);
            _com.Parameters.AddWithValue("@NationalId", txt_nid.Text);
            _com.Parameters.AddWithValue("@LastName", txt_lname.Text);
            _com.Parameters.AddWithValue("@FirstName", txt_fname.Text);
            _com.Parameters.AddWithValue("@MiddleName", txt_mname.Text);
            _com.Parameters.AddWithValue("@Nickname", txt_nname.Text);
            _com.Parameters.AddWithValue("@DateOfBirth", dp_birth.Value);
            _com.Parameters.AddWithValue("@BirthPlace", txt_baddress.Text);
            _com.Parameters.AddWithValue("@Age", txt_age.Text);
            _com.Parameters.AddWithValue("@CivilStatus", cmbx_cs.Text);
            _com.Parameters.AddWithValue("@Gender", cmbx_gender.Text);
            _com.Parameters.AddWithValue("@Religion", txt_religion.Text);
            _com.Parameters.AddWithValue("@Email", txt_email.Text);
            _com.Parameters.AddWithValue("@ContactNo", txt_contact.Text);
            _com.Parameters.AddWithValue("@VoterStats", cmbx_vs.Text);
            _com.Parameters.AddWithValue("@PrecintNo", txt_precint.Text);
            _com.Parameters.AddWithValue("@Purok", cmbx_purok.Text);
            _com.Parameters.AddWithValue("@Occupation", txt_occ.Text);
            _com.Parameters.AddWithValue("@Address", txt_address.Text);
            _com.Parameters.AddWithValue("@Category", txt_cat.Text);
            _com.Parameters.AddWithValue("@HouseNo", txt_house.Text);
            _com.Parameters.AddWithValue("@Status", txt_stats.Text);
            _com.Parameters.AddWithValue("@img", arrImage);
            _com.Parameters.AddWithValue("@id", _id);

            _com.ExecuteNonQuery();
            _con.Close();

            MessageBox.Show("Resident Info has been saved successfully", declares._title + "[SYSTEM]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            new_form.Load_data();
        }

        /// 
        /// </summary>
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

        private void button1_Click(object sender, EventArgs e)
        {
            add_resident();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            res_Update();
        }

        private void dp_birth_ValueChanged(object sender, EventArgs e)
        {
            DateTime t = DateTime.Today;
            int age = t.Year - dp_birth.Value.Year;
            txt_age.Text = age.ToString();
        }
    }
}
