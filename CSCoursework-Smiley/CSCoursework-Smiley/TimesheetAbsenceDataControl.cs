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
        private bool userUpdate = true;
        private int comboBoxIndex = 0;
        public TimesheetAbsenceDataControl()
        {
            InitializeComponent();
        }

        TimesheetControl parentForm;

        public void SetParentForm(TimesheetControl ParentForm)
        {
            parentForm = ParentForm;
        }

        List<Tuple<int, List<bool>>> employeeCombobox;

        public void SetEmployeeCombobox(List<Tuple<int, List<bool>>> EmployeeCombobox)
        {
            employeeCombobox = EmployeeCombobox;
        }

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
            if (userUpdate)
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
            
        }
        public void SetComboBoxMembers(List<string> EmployeeList)
        {
            comboBoxSelectEmployee.Items.Clear();
            foreach (string employee in EmployeeList)
            {
                comboBoxSelectEmployee.Items.Add(employee);
            }

            comboBoxSelectEmployee.SelectedIndex = comboBoxIndex;
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
            UpdateDatagrid();
            comboBoxIndex = comboBoxSelectEmployee.SelectedIndex;
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
        public void UpdateDatagrid()
        {
            userUpdate = false;
            for (int absence = 0; absence < employeeCombobox[comboBoxSelectEmployee.SelectedIndex].Item2.Count; absence++)
            {
                if (employeeCombobox[comboBoxSelectEmployee.SelectedIndex].Item2[absence])
                {
                    absenceDataGridView.Rows[0].Cells[absence].Value = true;
                }
            }
            userUpdate = true;
        }
        private void comboBoxSelectEmployee_Enter(object sender, EventArgs e)
        {
            comboBoxIndex = comboBoxSelectEmployee.SelectedIndex;
        }
    }
}
