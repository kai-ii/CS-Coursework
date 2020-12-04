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
        // Variables
        OleDbConnection con = new OleDbConnection();
        string generalNotes = "temp";

        public StaffControl parentForm { get; set; }

        public void RefreshMonthCalendar()
        {
            monthCalendar1.SelectionStart = DateTime.Today;
            monthCalendar1.SelectionEnd = DateTime.Today;
        }
        public string GeneralNotes 
        {
            get { return generalNotes; }
            set
            {
                rTxtGeneralNotes.Text = value;
            }
        }

        List<Tuple<DateTime, string>> absenceTupleList;
        public List<Tuple<DateTime, string>> AbsenceTupleList
        {
            get { return absenceTupleList; }
            set
            {
                absenceTupleList = value;
                UpdateMonthCalendar();
            }
        }

        private void UpdateMonthCalendar()
        {
            monthCalendar1.RemoveAllBoldedDates();
            foreach (Tuple<DateTime, string> absencePair in absenceTupleList)
            {
                monthCalendar1.AddBoldedDate(absencePair.Item1);
            }
            monthCalendar1.UpdateBoldedDates();
        }
        public StaffControlNotes()
        {
            InitializeComponent();
        }

        private void StaffControlNotes_Load(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime currentlySelecetedDate = monthCalendar1.SelectionStart;

            foreach (Tuple<DateTime, string>absencePair in absenceTupleList)
            {
                if (absencePair.Item1 == currentlySelecetedDate)
                {
                    rTxtAbsentNotes.Text = absencePair.Item2;
                    break;
                }
                else
                {
                    rTxtAbsentNotes.Text = "";
                }
            }
        }

        private void btnSaveGeneralNotes_Click(object sender, EventArgs e)
        {
            // Use parentForm reference given by StaffControl each time this form is brought to front
            parentForm.UpdateGeneralNotes(rTxtGeneralNotes.Text);
        }

    }
}

