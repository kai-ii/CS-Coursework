using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSCoursework_Smiley
{
    public partial class LoginFormRecoverAccount : UserControl
    {
        LoginForm parentForm;
        string[] userData;
        string currentUser;
        public LoginFormRecoverAccount()
        {
            InitializeComponent();
        }
        public void SetParentForm(LoginForm ParentForm)
        {
            parentForm = ParentForm;
        }
        private void LoginFormRecoverAccount_Load(object sender, EventArgs e)
        {

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
        private void ResetForm()
        {
            parentForm.CancelAccountRecovery();
            txtUsername.Clear();
            txtUsername.Visible = true;
            btnNext1.Visible = true;
            btnNext2.Visible = false;
            txtSecurityQuestion1.Visible = false;
            txtSecurityQuestion2.Visible = false;
            txtSecurityQuestion3.Visible = false;
            txtSecurityAnswer1.Visible = false;
            txtSecurityAnswer1.Clear();
            txtSecurityAnswer2.Visible = false;
            txtSecurityAnswer2.Clear();
            txtSecurityAnswer3.Visible = false;
            txtSecurityAnswer3.Clear();
            lblFullUsername.Visible = false;
            lblUsername.Visible = true;
            grpBoxChooseNewPassword.Visible = false;
            btnSubmit.Visible = false;
            txtPassword.Clear();
            txtConfirmPassword.Clear();
        }
        public void UpdateUserData(string[] UserData)
        {
            userData = UserData;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            for (int username = 0; username < userData.Length; username++)
            {
                if (userData[username].Split(',')[0] == txtUsername.Text)
                {
                    txtUsername.ForeColor = Color.Green;
                    currentUser = userData[username];
                    break;
                }
                else
                {
                    txtUsername.ForeColor = Color.Black;
                }
            }
        }

        private void btnNext1_Click(object sender, EventArgs e)
        {
            if (txtUsername.ForeColor != Color.Green) { MessageBox.Show("Enter a valid username."); return; }
            lblUsername.Visible = false;
            string[] currentUserArray = currentUser.Split(','); //username, q1, a1, q2, a2, q3, a3
            txtSecurityQuestion1.Text = currentUserArray[1];
            txtSecurityQuestion2.Text = currentUserArray[3];
            txtSecurityQuestion3.Text = currentUserArray[5];
            btnNext1.Visible = false;
            txtUsername.Visible = false;
            btnNext2.Visible = true;
            txtSecurityQuestion1.Visible = true;
            txtSecurityQuestion2.Visible = true;
            txtSecurityQuestion3.Visible = true;
            txtSecurityAnswer1.Visible = true;
            txtSecurityAnswer2.Visible = true;
            txtSecurityAnswer3.Visible = true;
            lblFullUsername.Text = $"Username ({currentUserArray[0]})";
            lblFullUsername.Visible = true;
        }

        private void btnNext2_Click(object sender, EventArgs e)
        {
            string[] currentUserArray = currentUser.Split(','); //username, q1, a1, q2, a2, q3, a3
            if (txtSecurityAnswer1.Text.ToLower() == currentUserArray[2].ToLower() && txtSecurityAnswer2.Text.ToLower() == currentUserArray[4].ToLower() && txtSecurityAnswer3.Text.ToLower() == currentUserArray[6].ToLower())
            {
                txtSecurityQuestion1.Visible = false;
                txtSecurityQuestion2.Visible = false;
                txtSecurityQuestion3.Visible = false;
                txtSecurityAnswer1.Visible = false;
                txtSecurityAnswer2.Visible = false;
                txtSecurityAnswer3.Visible = false;
                grpBoxChooseNewPassword.Visible = true;
                btnNext2.Visible = false;
                btnSubmit.Visible = true;
            }
            else
            {
                MessageBox.Show("At least one of your answers are incorrect.");
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Password length check
            if (txtPassword.Text.Length < 8)
            {
                MessageBox.Show("Your password must contain at least 8 characters.");
                return;
            }
            bool passwordContainsLetter = false;
            bool passwordContainsCaptial = false;
            bool passwordContainsInteger = false;
            foreach (char letter in txtPassword.Text)
            {
                if (letter == ' ')
                {
                    MessageBox.Show("Password Cannot contain any spaces.");
                    return;
                }
                if (Char.IsLetter(letter))
                {
                    passwordContainsLetter = true;
                    if (Char.IsUpper(letter))
                    {
                        passwordContainsCaptial = true;
                    }
                }
                else
                {
                    passwordContainsInteger = true;
                }
            }

            // Character/Type checks
            if (!passwordContainsLetter)
            {
                MessageBox.Show("Password must contain a letter.");
                return;
            }
            if (!passwordContainsCaptial)
            {
                MessageBox.Show("Password must contain a captial letter.");
                return;
            }
            if (!passwordContainsInteger)
            {
                MessageBox.Show("Password must contain a number.");
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match. Try entering them again.");
                return;
            }

            if (CreateMD5(txtPassword.Text) == currentUser.Split(',')[8])
            {
                MessageBox.Show("New password must be different to the current password.");
                return;
            }

            string userID = currentUser.Split(',')[7];
            string password = txtPassword.Text;
            parentForm.UpdatePassword(userID, password);
            ResetForm();
        }

        // Taken from https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.md5?redirectedfrom=MSDN&view=net-5.0
        private string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
