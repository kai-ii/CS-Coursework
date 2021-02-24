using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.OleDb;

namespace CSCoursework_Smiley
{
    public partial class StaffControlNotes : UserControl
    {
        // Initialise local class variables.
        StaffControl parentForm;
        List<Tuple<DateTime, string>> absenceTupleList;
        public void SetParentForm(StaffControl ParentForm)
        {
            // Assign this forms parent form to be a parent form of the template AdminControl which is passed in from the Admin Control.
            parentForm = ParentForm;
        }
        public void RefreshMonthCalendar()
        {
            // Refreshes the selected date of the month calendar to todays date.
            monthCalendar1.SelectionStart = DateTime.Today;
            monthCalendar1.SelectionEnd = DateTime.Today;
        }
        public void SetGeneralNotes(string generalNotes)
        {
            // Updates the general notes displayed in the rich general notes textbox to the given notes.
            rTxtGeneralNotes.Text = generalNotes;
        }
        public void SetAbsenceTupleList(List<Tuple<DateTime, string>> AbsenceTupleList)
        {
            // Set the forms absence tuple list variable and update the month calendar with these values. (Sets the bolded dates and corresponding values.)
            if (AbsenceTupleList != null)
            {
                absenceTupleList = AbsenceTupleList;
                UpdateMonthCalendar();
            }
        }
        private void UpdateMonthCalendar()
        {
            // Remove all the bolded dates and then add the dates in the new absence tuple list.
            monthCalendar1.RemoveAllBoldedDates();
            foreach (Tuple<DateTime, string> absencePair in absenceTupleList)
            {
                monthCalendar1.AddBoldedDate(absencePair.Item1);
            }
            monthCalendar1.UpdateBoldedDates();
        }
        public StaffControlNotes()
        {
            // Standard form initialize component call.
            InitializeComponent();
        }
        private void StaffControlNotes_Load(object sender, EventArgs e)
        {
            // Nothing is done when the form is loaded since we must wait for events driven by the user or data passed in before any processing can occur.
        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            // Set the currently selected date on the calendar, check for this date in the absence tuple list and if a date matches, display the corresponding absence note for said date. If no date is found then set the note to be blank.
            DateTime currentlySelectedDate = monthCalendar1.SelectionStart;

            foreach (Tuple<DateTime, string>absencePair in absenceTupleList)
            {
                if (absencePair.Item1 == currentlySelectedDate)
                {
                    rTxtAbsentNotes.Text = absencePair.Item2;
                    break;
                }
            }
            rTxtAbsentNotes.Text = "";
        }
        private void btnSaveGeneralNotes_Click(object sender, EventArgs e)
        {
            // Use parentForm reference given by StaffControl each time this form is brought to front
            parentForm.UpdateGeneralNotes(rTxtGeneralNotes.Text);
        }
    }
}

