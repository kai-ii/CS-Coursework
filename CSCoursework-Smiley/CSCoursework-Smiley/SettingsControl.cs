﻿using System;
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
        // Initialize variables
        Color highlightColour;
        Color backgroundColour;
        public Dashboard parentForm { get; set; }
        public string userUsername { get; set; }
        public string userPassword { get; set; }
        public SettingsControl()
        {
            InitializeComponent();
        }
        private void SettingsControl_Load(object sender, EventArgs e)
        {
            //UpdateUsernamePasswordTextboxes();
        }
        public void UpdateUsernamePasswordTextboxes()
        {
            txtUsername.Text = userUsername;
            txtPassword.Text = userPassword;
        }
        public void setBackgroundHighlightColours(Color receivedBackgroundColour, Color receivedHighlightColour)
        {
            backgroundColour = receivedBackgroundColour;
            highlightColour = receivedHighlightColour;
            SetButtonColour();
        }

        private void SetButtonColour()
        {
            btnBackgroundColour.BackColor = backgroundColour;
            btnHighlightColour.BackColor = highlightColour;
        }

        private void btnEditBackgroundColour_Click(object sender, EventArgs e)
        {
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
            if (txtBackgroundColour.Text == "Background") { return; }
            try
            {
                string backgroundColourRGBString = txtBackgroundColour.Text;
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
                MessageBox.Show("Colour must be in the format: 'int,int,int' where int<=255");
            }
        }
        private void txtHighlightColour_TextChanged(object sender, EventArgs e)
        {
            if (txtHighlightColour.Text == "Highlight") { return; }
            try
            {
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
                MessageBox.Show("Colour must be in the format: 'int,int,int' where int<=255");
            }
        }
        private void btnResetColourToDefault_Click(object sender, EventArgs e)
        {
            txtBackgroundColour.Text = "245, 208, 226";
            txtHighlightColour.Text = "221, 165, 182";
            if (txtBackgroundColour.ReadOnly) { txtBackgroundColour.Text = "Background"; }
            if (txtHighlightColour.ReadOnly) { txtHighlightColour.Text = "Highlight"; }
        }

        private void btnSaveNewColour_Click(object sender, EventArgs e)
        {
            parentForm.UpdateUserColours(backgroundColour, highlightColour);
        }

        private void chkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
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
            parentForm.UpdateUserPassword(txtPassword.Text);
        }
    }
}
