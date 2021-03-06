﻿using System;
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
    public partial class LoginFormCreateAccount : UserControl
    {
        // Initialise local class variables.
        LoginForm parentForm;
        string[] possibleStaffNames;
        string username;
        string password;
        string securityQuestion1;
        string securityQuestion2;
        string securityQuestion3;
        string securityAnswer1;
        string securityAnswer2;
        string securityAnswer3;
        public LoginFormCreateAccount()
        {
            // Standard form initialize component call.
            InitializeComponent();
        }

        public void SetParentForm(LoginForm ParentForm)
        {
            // Assign this forms parent form to be a parent form of the template LoginForm which is passed in from the login form.
            parentForm = ParentForm;
        }
        private void LoginFormCreateAccount_Load(object sender, EventArgs e)
        {
            // Set the account security group box to the correct location, this isn't stacked because it caused a problem where winforms thought some other elements were inside the groupbox when they weren't meant to be.
            grpBoxAccountSecurity.Location = new Point(4, 4);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // If the user decides to cancel creating their account, then reset the form.
            ResetForm();
        }
        private void ResetForm()
        {
            // All textboxes are cleared and labels are reset, all elements visibility reverts back to the original state. The loginform cancel account creation method is also called, this deals with the macro visibility of the entire form.
            parentForm.CancelAccountCreation();
            txtStaffName.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            lblUsername.Text = "Username (auto-generated)";
            grpBoxAccountSecurity.Visible = false;
            grpBoxAccountCreation.Visible = true;
            btnSubmit.Visible = false;
            btnNext.Visible = true;
        }
        public void UpdateTextboxAutocomplete(string[] suggestionArray)
        {
            // When passed in staff autocomplete data, set the staff name text box autocomplete data to this array.
            possibleStaffNames = suggestionArray;
            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
            autoCompleteStringCollection.AddRange(suggestionArray);
            txtStaffName.AutoCompleteCustomSource = autoCompleteStringCollection;
            txtStaffName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtStaffName.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void txtStaffName_TextChanged(object sender, EventArgs e)
        {
            // Checks if the staff name typed in coincides with an actual staff member.
            if (possibleStaffNames.Contains<string>(txtStaffName.Text))
            {
                username = $"{txtStaffName.Text.ToLower().Split(' ')[0][0]}{txtStaffName.Text.ToLower().Split(' ')[1]}";
                lblUsername.Text = $"Username ({username})";
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // When next is clicked if a valid staff name has not been provided do nothing.
            if (lblUsername.Text == "Username (auto-generated)")
            {
                MessageBox.Show("You must provde your name in order for a username to be autogenerated.");
                return;
            }
            // Password length check.
            if (txtPassword.Text.Length < 8)
            {
                MessageBox.Show("Your password must contain at least 8 characters.");
                return;
            }
            bool passwordContainsLetter = false;
            bool passwordContainsCaptial = false;
            bool passwordContainsInteger = false;

            // Password whitespace check.
            foreach (char letter in txtPassword.Text)
            {
                if (letter == ' ')
                {
                    MessageBox.Show("Password Cannot contain any spaces.");
                    return;
                }
                if (Char.IsLetter(letter))
                {
                    // Leter check.
                    passwordContainsLetter = true;
                    if (Char.IsUpper(letter))
                    {
                        // Capital check.
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

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match. Try entering them again.");
                return;
            }

            // Initialize the next stage of the form.
            password = txtPassword.Text;
            grpBoxAccountCreation.Visible = false;
            btnNext.Visible = false;
            grpBoxAccountSecurity.Visible = true;
            btnSubmit.Visible = true;
            //MD5 encryption to store the password.
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validation to ensure the same question hasn't been picked multiple times.
            if (comboBoxSecurityQuestion1.SelectedItem == comboBoxSecurityQuestion2.SelectedItem || comboBoxSecurityQuestion1.SelectedItem == comboBoxSecurityQuestion3.SelectedItem || comboBoxSecurityQuestion2.SelectedItem == comboBoxSecurityQuestion3.SelectedItem)
            {
                MessageBox.Show("You cannot use the same security question more than once.");
                return;
            }
            // Presence check.
            if (txtSecurityAnswer1.Text.Trim() == "")
            {
                MessageBox.Show("You must provide answers to all security questions. Check answer 1.");
                return;
            }
            // Presence check.
            if (txtSecurityAnswer2.Text.Trim() == "")
            {
                MessageBox.Show("You must provide answers to all security questions. Check answer 2.");
                return;
            }
            // Presence check.
            if (txtSecurityAnswer3.Text.Trim() == "")
            {
                MessageBox.Show("You must provide answers to all security questions. Check answer 3.");
                return;
            }

            // If all validation is passed then save the account using the login forms save account function, passing security questions and answers as well as username and chosen password.
            securityQuestion1 = comboBoxSecurityQuestion1.SelectedItem.ToString();
            securityQuestion2 = comboBoxSecurityQuestion2.SelectedItem.ToString();
            securityQuestion3 = comboBoxSecurityQuestion3.SelectedItem.ToString();
            securityAnswer1 = txtSecurityAnswer1.Text;
            securityAnswer2 = txtSecurityAnswer2.Text;
            securityAnswer3 = txtSecurityAnswer3.Text;
            parentForm.SaveAccount(username, password, securityQuestion1, securityAnswer1, securityQuestion2, securityAnswer2, securityQuestion3, securityAnswer3);
            ResetForm();
            MessageBox.Show("Account Successfully Created.");
        }
    }
}
