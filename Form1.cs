using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace WinFormsAssignment
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        private Color favColor;
        private void btnColorPicker_Click(object sender, EventArgs e)
        {
            if(clr_Dilg.ShowDialog() == DialogResult.OK)
            {
                favColor = clr_Dilg.Color;
                btnColorPicker.BackColor = favColor;
                btnColorPicker.Text = string.Empty;
            }
        }

        private void txt_Email_Validating(object sender, CancelEventArgs e)
        {
            const string pattern = "^[A-Za-z0-9]{3,20}"+@"@[A-Za-z]{4,10}\."+"[A-Za-z]{3,5}";
            if (string.IsNullOrEmpty(txt_Email.Text) )
            {
                lbl_Email_Check.Text = "You have to enter your Email";
                lbl_Email_Check.ForeColor = Color.Red;
            }
            else if(!Regex.IsMatch(txt_Email.Text,pattern))
            {
                lbl_Email_Check.Text = "Please Enter a Valid Email";
                lbl_Email_Check.ForeColor = Color.Red;
                txt_Email.Text=string.Empty;
            }
            else
            {
                lbl_Email_Check.Text = "Valid Email";
                lbl_Email_Check.ForeColor = Color.Green;
            }
        }

        private void txt_Password_TextChanged(object sender, EventArgs e)
        {
            txt_Password.UseSystemPasswordChar = true;
        }

        private void showPasswordToggle_CheckedChanged(object sender, EventArgs e)
        {
            txt_Password.UseSystemPasswordChar = !showPasswordToggle.Checked;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txt_Name.Text;
            string email = txt_Email.Text;
            string password = txt_Password.Text;
            string gender = rb_male.Checked?"Male" :rb_female.Checked?"Female": "Prefer not to answer";
            string favColor = clr_Dilg.Color.Name;
            string birthdate = dtp_Birthdate.Value.ToShortDateString();
            string country= cmb_Country.Text;

            if(string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                lbl_Result.ForeColor = Color.Red;
                lbl_Result.Text = "Please Enter All Required fields..!!";
            }
            else
            {
                lbl_Result.ForeColor = Color.Green;
                lbl_Result.Text = $"{name}, {email}, {gender}, Favorite Color:{favColor}, Birthdate:{birthdate}, Country:{country}";
                lbl_Email_Check.Text = string.Empty;
                btnColorPicker.BackColor = SystemColors.Control;
                btnColorPicker.Text = "Choose a Color";

                foreach (Control control in this.Controls)
                {
                    if (control is TextBox txt_bx)
                    {
                        txt_bx.Clear();
                    }

                    else if (control is GroupBox grp_bx)
                    {
                        foreach(Control inner_control in grp_bx.Controls)
                        {
                            if(inner_control is RadioButton rb)
                            {
                                rb.Checked = false;
                            }
                        }
                    }

                    else if (control is DateTimePicker dtp)
                    {
                        dtp.Value = DateTime.Today;
                    }

                    else if (control is ComboBox cmb_bx)
                    {
                        cmb_bx.SelectedIndex = -1;
                    }
                }
            }
        }

        private void txt_Name_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Name.Text))
            {
                lbl_Name_Check.Text = "Riquired Feilds";
                lbl_Name_Check.ForeColor = Color.Red;
            }
        }

        private void txt_Password_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Password.Text))
            {
                lbl_Password_Check.Text = "Riquired Feilds";
                lbl_Password_Check.ForeColor = Color.Red;
            }
        }
    }
}
