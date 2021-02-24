using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSCoursework_Smiley.Properties
{
    public partial class SettingsControl : UserControl
    {
        // Initialise local class variables.
        Color highlightColour;
        Color backgroundColour;
        Dashboard parentForm;
        string userUsername;
        string userPassword;

        public void SetParentForm(Dashboard ParentForm)
        {
            // Assign this forms parent form to be a parent form of the template Dashboard (background) which is passed in from the Dashboard background form.
            parentForm = ParentForm;
        }
        public void SetUserUsername(string UserUsername)
        {
            // Sets the username to be displayed.
            userUsername = UserUsername;
        }
        public void SetUserPassword(string UserPassword)
        {
            // Sets the unencrypted password to be displayed to the user when they wish to change their password.
            userPassword = UserPassword;
        }
        public SettingsControl()
        {
            // Standard form initialize component call.
            InitializeComponent();
        }
        private void SettingsControl_Load(object sender, EventArgs e)
        {
            // This does nothing when loaded since it waits for the username and password to be passed in, then for the UpdateUsernamePasswordTextboxes public function to be called by the background form to initialize this form. Everything else is event based.
        }
        public void UpdateUsernamePasswordTextboxes()
        {
            // Initialize the username and password textboxes.
            txtUsername.Text = userUsername;
            txtPassword.Text = userPassword;
        }
        public void setBackgroundHighlightColours(Color receivedBackgroundColour, Color receivedHighlightColour)
        {
            // Set the forms background and highlight colours and then display these on the small representative buttons.
            backgroundColour = receivedBackgroundColour;
            highlightColour = receivedHighlightColour;
            SetButtonColour();
        }

        private void SetButtonColour()
        {
            // Set the buttons to the forms background and highlight colours, given to by the background dashboard form.
            btnBackgroundColour.BackColor = backgroundColour;
            btnHighlightColour.BackColor = highlightColour;
        }

        private void btnEditBackgroundColour_Click(object sender, EventArgs e)
        {
            // If the edit background colour button is clicked, show the colour to be edited if the edit button isn't already active, otherwise hide the colours and make it uneditable.
            if (txtBackgroundColour.ReadOnly)
            {
                txtBackgroundColour.ReadOnly = false;
                txtBackgroundColour.Text = $"{backgroundColour.R}, {backgroundColour.G}, {backgroundColour.B}";
            }
            else
            {
                txtBackgroundColour.ReadOnly = true;
                txtBackgroundColour.Text = "Background";
            }
        }

        private void btnEditHighlightColour_Click(object sender, EventArgs e)
        {
            // If the edit highlight colour button is clicked, show the colour to be edited if the edit button isn't already active, otherwise hide the colours and make it uneditable.
            if (txtHighlightColour.ReadOnly)
            {
                txtHighlightColour.ReadOnly = false;
                txtHighlightColour.Text = $"{highlightColour.R}, {highlightColour.G}, {highlightColour.B}";
            }
            else
            {
                txtHighlightColour.ReadOnly = true;
                txtHighlightColour.Text = "Highlight";
            }
        }
        private void txtBackgroundColour_TextChanged(object sender, EventArgs e)
        {
            // When the background colour text is changed, try to parse the input to a colour and display this new colour on the background colour button.
            if (txtBackgroundColour.Text == "Background") { return; }
            try
            {
                // Get the input, split it by csv, set any blank inputs to 0, parse the string to an integer, set the background colour to a color from rgb of the inputs, set the button colour to this new colour ready to be saved.
                string backgroundColourRGBString = txtBackgroundColour.Text; // return if the default background text is written, this is because it is clearly not a colour and is just used for user intuition.
                string[] backgroundColourRGBStringArray = backgroundColourRGBString.Split(',');
                for (int colour = 0; colour < backgroundColourRGBStringArray.Length; colour++)
                {
                    if (backgroundColourRGBStringArray[colour].Trim() == "")
                    {
                        backgroundColourRGBStringArray[colour] = "0";
                    }
                }
                int[] backgroundColourRGBIntArray = backgroundColourRGBStringArray.Select(item => int.Parse(item)).ToArray();
                backgroundColour = Color.FromArgb(backgroundColourRGBIntArray[0], backgroundColourRGBIntArray[1], backgroundColourRGBIntArray[2]);
                btnBackgroundColour.BackColor = backgroundColour;
            }
            catch
            {
                //----------Exception handling----------
                // If there is a problem in the try section, this will be due to the int.Parse function not being able to parse an item, this means that there is a character somewhere. Tell the user the correct format.
                MessageBox.Show("Colour must be in the format: 'int,int,int' where int<=255");
            }
        }
        private void txtHighlightColour_TextChanged(object sender, EventArgs e)
        {
            // When the highlight colour text is changed, try to parse the input to a colour and display this new colour on the highlight colour button.
            if (txtHighlightColour.Text == "Highlight") { return; } // return if the default highlight text is written, this is because it is clearly not a colour and is just used for user intuition.
            try
            {
                // Get the input, split it by csv, set any blank inputs to 0, parse the string to an integer, set the highlight colour to a color from rgb of the inputs, set the button colour to this new colour ready to be saved.
                string highlightColourRGBString = txtHighlightColour.Text;
                string[] highlightColourRGBStringArray = highlightColourRGBString.Split(',');
                for (int colour = 0; colour < highlightColourRGBStringArray.Length; colour++)
                {
                    if (highlightColourRGBStringArray[colour].Trim() == "")
                    {
                        highlightColourRGBStringArray[colour] = "0";
                    }
                }
                int[] highlightColourRGBIntArray = highlightColourRGBStringArray.Select(item => int.Parse(item)).ToArray();
                highlightColour = Color.FromArgb(highlightColourRGBIntArray[0], highlightColourRGBIntArray[1], highlightColourRGBIntArray[2]);
                btnHighlightColour.BackColor = highlightColour;
            }
            catch
            {
                //----------Exception handling----------
                // If there is a problem in the try section, this will be due to the int.Parse function not being able to parse an item, this means that there is a character somewhere. Tell the user the correct format.
                MessageBox.Show("Colour must be in the format: 'int,int,int' where int<=255");
            }
        }
        private void btnResetColourToDefault_Click(object sender, EventArgs e)
        {
            // Resets the colours to their default colours, as shown in the design document of the project. If the rgb colour shouldn't be displayed, e.g. when readonly of the textboxes is true, replace this new colour with background and highlight respectively as expected.
            txtBackgroundColour.Text = "245, 208, 226";
            txtHighlightColour.Text = "221, 165, 182";
            if (txtBackgroundColour.ReadOnly) { txtBackgroundColour.Text = "Background"; }
            if (txtHighlightColour.ReadOnly) { txtHighlightColour.Text = "Highlight"; }
        }

        private void btnSaveNewColour_Click(object sender, EventArgs e)
        {
            // Update the new background highlight rgb colours by calling the respective function in the dashboard background form.
            parentForm.UpdateUserColours(backgroundColour, highlightColour);
        }

        private void chkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // If the show password is enabled, show the user their unencrypted password and allow them to edit it, this is a precursive step to them being able to save a new password and flows very smoothly and intuitively when using.
            if (txtPassword.PasswordChar == '\0')
            {
                txtPassword.PasswordChar = '*';
                txtPassword.ReadOnly = true;
            }
            else
            {
                txtPassword.PasswordChar = '\0';
                txtPassword.ReadOnly = false;
            }
        }
        private void btnChangePassword_Click(object sender, EventArgs e)
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
            // Various validation checks.
            foreach (char letter in txtPassword.Text)
            {
                if (letter == ' ')
                {
                    // Password must contain no whitespace.
                    MessageBox.Show("Password Cannot contain any spaces.");
                    return;
                }
                if (Char.IsLetter(letter))
                {
                    // Ensures the password contains a letter.
                    passwordContainsLetter = true;
                    if (Char.IsUpper(letter))
                    {
                        // Ensures the password contains a captial letter.
                        passwordContainsCaptial = true;
                    }
                }
                else
                {
                    // Ensures the password contains a number.
                    passwordContainsInteger = true;
                }
            }

            // Character/Type checks
            if (!passwordContainsLetter)
            {
                //----------Exception handling----------
                // Tell the user of the invalidation their password caused to allow them to update it.
                MessageBox.Show("Password must contain a letter.");
                return;
            }
            if (!passwordContainsCaptial)
            {
                //----------Exception handling----------
                // Tell the user of the invalidation their password caused to allow them to update it.
                MessageBox.Show("Password must contain a captial letter.");
                return;
            }
            if (!passwordContainsInteger)
            {
                //----------Exception handling----------
                // Tell the user of the invalidation their password caused to allow them to update it.
                MessageBox.Show("Password must contain a number.");
                return;
            }

            // Update the users password by calling the respective public function stored in the dashboard background form.
            parentForm.UpdateUserPassword(txtPassword.Text);
        }
        private void checkBoxShowDateAndTime_CheckedChanged(object sender, EventArgs e)
        {
            // If the show date time settings is updated, display it or do not display it based on the state of the checkbox and update the database accordingly. This is done by simply calling the parent form (Dashboard background form) with the state of the checkbox rather than having say an if statement conditioned on the state of the checkbox, this makes the program slightly more efficient.
            parentForm.DisplayDateTimeLabel(checkBoxShowDateAndTime.Checked);
            parentForm.SaveSettingsShowDateTimeLabel(checkBoxShowDateAndTime.Checked);
        }
        public void UpdateShowDateTimeCheckbox(bool checkedBool)
        {
            // Updates the show date time checkbox based on the users existing settings, this is an initialization funciton.
            checkBoxShowDateAndTime.Checked = checkedBool;
        }
    }
}
