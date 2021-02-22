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
        // Initialise local class variables.
        LoginForm parentForm;
        string[] userData;
        string currentUser;
        public LoginFormRecoverAccount()
        {
            // Standard form initialize component call.
            InitializeComponent();
        }
        public void SetParentForm(LoginForm ParentForm)
        {
            // Assign this forms parent form to be a parent form of the template LoginForm which is passed in from the login form.
            parentForm = ParentForm;
        }
        private void LoginFormRecoverAccount_Load(object sender, EventArgs e)
        {
            // Nothing is done when this form is loaded since it requires user input before any processing is carried out.
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // If the user decides to cancel creating their account, then reset the form.
            ResetForm();
        }
        private void ResetForm()
        {
            // All textboxes are cleared and labels are reset, all elements visibility reverts back to the original state. The loginform cancel account creation method is also called, this deals with the macro visibility of the entire form.
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
            // When passed userdata from the login form, add it to a local variable for use elsewhere in this form.
            userData = UserData;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            // each time the username field is changed, check to see if it is a valid username, if it is valid then change the textbox colour to green to notify to the user that their username is valid. Otherwise keep the colour as black and do nothing else.
            for (int username = 0; username < userData.Length; username++)
            {
                if (userData[username].Split(',')[0] == txtUsername.Text)
                {
                    // When the username is valid, change the current user data used in the rest of the form to the array stored at the index the username was validated.
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
            // When the first next button is clicked check if the username colour is green, if it is then that means it's valid, if not then it is not valid and return out of the function.
            if (txtUsername.ForeColor != Color.Green) { MessageBox.Show("Enter a valid username."); return; }
            // If the function hasn't returned then the name is valid, change visibility of the appropriate elements, assign values for the username given and move on to the next section of the form.
            lblUsername.Visible = false;
            string[] currentUserArray = currentUser.Split(','); //[username, q1, a1, q2, a2, q3, a3]
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
            // If the security questions answered match up with the given answers then move on to the last section of the form where the user can change their password, if not then tell the user that at least one of their answers were incorrect in order not to tell a user trying to brute force which answers they have correct, this will mean a potential attack will take much longer to brute force these security questions, increasing the likelihood that they give up, making the application more secure.
            string[] currentUserArray = currentUser.Split(','); //[username, q1, a1, q2, a2, q3, a3]
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
            // Password length check.
            if (txtPassword.Text.Length < 8)
            {
                MessageBox.Show("Your password must contain at least 8 characters.");
                return;
            }
            bool passwordContainsLetter = false;
            bool passwordContainsCaptial = false;
            bool passwordContainsInteger = false;
            // White space check.
            foreach (char letter in txtPassword.Text)
            {
                if (letter == ' ')
                {
                    MessageBox.Show("Password Cannot contain any spaces.");
                    return;
                }
                if (Char.IsLetter(letter))
                {
                    // Letter check.
                    passwordContainsLetter = true;
                    if (Char.IsUpper(letter))
                    {
                        // Captial check.
                        passwordContainsCaptial = true;
                    }
                }
                else
                {
                    // Integer check.
                    passwordContainsInteger = true;
                }
            }

            // Character/Type checks.
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

            // Double-entry validation check.
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match. Try entering them again.");
                return;
            }

            // Check if the password being entered is the current password, if it is then inform the user that they are entering their current password and that it will not be changed, this increases efficiency since the database will not have to be accessed as many times, which is important because accessing the hard disk takes a lot of time due to the hard disk being slower than RAM for example, where variables are stored.
            if (CreateMD5(txtPassword.Text) == currentUser.Split(',')[8])
            {
                MessageBox.Show("New password must be different to the current password.");
                return;
            }

            // If all validation is passed then save the new password and reset the form for use by another user later on.
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
