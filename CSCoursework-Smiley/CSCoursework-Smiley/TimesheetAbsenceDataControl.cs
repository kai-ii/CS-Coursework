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
    public partial class TimesheetAbsenceDataControl : UserControl
    {
        Day currentDay;
        public TimesheetAbsenceDataControl()
        {
            InitializeComponent();
        }

        public TimesheetControl parentForm { get; set; }

        private void TimesheetAbsenceDataControl_Load(object sender, EventArgs e)
        {
            InitializeAbsenceDataGrid();
            SetUpEventHandlers();
            ResetCurrentDayToMonday();
            UpdateCurrentDayLabel();
        }
        public void ResetCurrentDayToMonday()
        {
            currentDay = Day.Monday;
        }
        private void SetUpEventHandlers()
        {
            this.absenceDataGridView.CellValueChanged += new DataGridViewCellEventHandler(this.absenceDataGridView_CellValueChanged);
        }

        private void absenceDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(absenceDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
            {
                parentForm.UpdateAbsenceDataGrid(comboBoxSelectEmployee.SelectedIndex, e.ColumnIndex + 1, true);
            }
            else
            {
                parentForm.UpdateAbsenceDataGrid(comboBoxSelectEmployee.SelectedIndex, e.ColumnIndex + 1, false);
            }
        }
        public void SetComboBoxMembers(List<string> EmployeeList)
        {
            foreach (string employee in EmployeeList)
            {
                comboBoxSelectEmployee.Items.Add(employee);
            }
            comboBoxSelectEmployee.SelectedIndex = 0;
        }
        public void ClearDataGrid()
        {
            absenceDataGridView.Rows.Clear();
            absenceDataGridView.Rows.Add();
        }
        private void InitializeAbsenceDataGrid()
        {
            absenceDataGridView.Rows.Add();
        }

        private void comboBoxSelectEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearDataGrid();
        }

        private void btnPreviousDay_Click(object sender, EventArgs e)
        {
            if (currentDay == Day.Monday)
            {
                currentDay = Day.Friday;
            }
            else
            {
                currentDay -= 1;
            }
            UpdateCurrentDayLabel();
        }

        private void btnNextDay_Click(object sender, EventArgs e)
        {
            if (currentDay == Day.Friday)
            {
                currentDay = Day.Monday;
            }
            else
            {
                currentDay += 1;
            }
            UpdateCurrentDayLabel();
        }

        public void UpdateCurrentDayLabel()
        {
            lblCurrentDay.Text = $"Current Day - {currentDay.ToString().Substring(0,3)}";
        }

        private void btnSaveAbsenceNotes_Click(object sender, EventArgs e)
        {
            //Presence Check
            if (rTxtAbsenceNotes.Text == "")
            {
                MessageBox.Show("Cannot save absence note. Note must not be blank.");
                return;
            }
            parentForm.UpdateAbsenceDatabaseInformation(currentDay, rTxtAbsenceNotes.Text, comboBoxSelectEmployee.SelectedIndex);
        }
    }
}
