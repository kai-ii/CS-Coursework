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
    public partial class StaffControlNotes : UserControl
    {
        string generalNotes = "temp";
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
                UpdateMonthCalendar();            }
        }

        private void UpdateMonthCalendar()
        {
            monthCalendar1.RemoveAllBoldedDates();
            foreach (Tuple<DateTime, string> absencePair in absenceTupleList)
            {
                monthCalendar1.AddBoldedDate(absencePair.Item1);
            }
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
                }
            }
        }
    }
}
