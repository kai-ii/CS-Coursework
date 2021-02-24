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
        // Initialise local class variables.
        Day currentDay;
        private bool userUpdate = true;
        private int comboBoxIndex = 0;
        TimesheetControl parentForm;
        List<Tuple<int, List<bool>>> employeeCombobox;
        public TimesheetAbsenceDataControl()
        {
            // Standard form initialize component call.
            InitializeComponent();
        }
        public void SetParentForm(TimesheetControl ParentForm)
        {
            // Assign this forms parent form to be a parent form of the template TimesheetControl which is passed in from the Timesheet Control.
            parentForm = ParentForm;
        }
        public void SetEmployeeCombobox(List<Tuple<int, List<bool>>> EmployeeCombobox)
        {
            // Set the local employeeCombobox variable to the passed in value.
            employeeCombobox = EmployeeCombobox;
        }

        private void TimesheetAbsenceDataControl_Load(object sender, EventArgs e)
        {
            // Preprocessing for the form to do before data gets passed in, including initializing the absence datagrid (where the days are selected) and setting up the forms event handlers.
            InitializeAbsenceDataGrid();
            SetUpEventHandlers();
            ResetCurrentDayToMonday();
            UpdateCurrentDayLabel();
        }
        public void ResetCurrentDayToMonday()
        {
            // Set the current day variable to monday.
            currentDay = Day.Monday;
        }
        private void SetUpEventHandlers()
        {
            // Set up the absence data grid cell value changed event.
            this.absenceDataGridView.CellValueChanged += new DataGridViewCellEventHandler(this.absenceDataGridView_CellValueChanged);
        }

        private void absenceDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // userUpdate dictates whether or not the update was caused by a user or automatically. This stops an infinite looping bug.
            if (userUpdate)
            {
                // Update the timesheet datagrid view with absences corresponding to the selected cell.
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
            // Initialize the forms combobox that stores staff members names with the given list.
            comboBoxSelectEmployee.Items.Clear();
            foreach (string employee in EmployeeList)
            {
                comboBoxSelectEmployee.Items.Add(employee);
            }

            comboBoxSelectEmployee.SelectedIndex = comboBoxIndex;
        }
        public void ClearDataGrid()
        {
            // Clear the datagrid and add a fresh row.
            absenceDataGridView.Rows.Clear();
            absenceDataGridView.Rows.Add();
        }
        private void InitializeAbsenceDataGrid()
        {
            // Add the initial row to the absence data grid.
            absenceDataGridView.Rows.Add();
        }

        private void comboBoxSelectEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If the selected employee has changed clear the datagrid and then update it with the users absence values for the current timesheet.
            ClearDataGrid();
            UpdateDatagrid();
            comboBoxIndex = comboBoxSelectEmployee.SelectedIndex;
        }

        private void btnPreviousDay_Click(object sender, EventArgs e)
        {
            // Rewind the current day by 1 day, cycling friday->thursday->wednesday->tuesday->monday->friday as weekends are not worked or rotad at the smiley happy people nursery.
            if (currentDay == Day.Monday)
            {
                currentDay = Day.Friday;
            }
            else
            {
                currentDay -= 1;
            }
            // Update the day label to reflect the day variables change.
            UpdateCurrentDayLabel();
        }

        private void btnNextDay_Click(object sender, EventArgs e)
        {
            // Increment the current day by 1 day, cycling moday->tuesday->wednesday->thursday->friday->monday as weekends are not worked or rotad at the smiley happy people nursery.
            if (currentDay == Day.Friday)
            {
                currentDay = Day.Monday;
            }
            else
            {
                currentDay += 1;
            }
            // Update the day label to reflect the day variables change.
            UpdateCurrentDayLabel();
        }

        public void UpdateCurrentDayLabel()
        {
            // Update the current day label to the value of the current day. (Displaying the first 3 chars as standard.)
            lblCurrentDay.Text = $"Current Day - {currentDay.ToString().Substring(0,3)}";
        }

        private void btnSaveAbsenceNotes_Click(object sender, EventArgs e)
        {
            // Presence Check
            if (rTxtAbsenceNotes.Text == "")
            {
                //----------Exception handling----------
                // Notify the user that their absence note was blank and so cannot be saved, this is because it doesn't make sense to save a note of absence if there is no description.
                MessageBox.Show("Cannot save absence note. Note must not be blank.");
                return;
            }
            // Save the absence data to database using the timesheets public UpdateAbsenceDatabaseInformation function.
            parentForm.UpdateAbsenceDatabaseInformation(currentDay, rTxtAbsenceNotes.Text, comboBoxSelectEmployee.SelectedIndex);
        }
        public void UpdateDatagrid()
        {
            // This is an automatic update so set userUpdate to be false, this way when the cell changed event fires, logic applied to a human change isn't applied during this update.
            userUpdate = false;
            for (int absence = 0; absence < employeeCombobox[comboBoxSelectEmployee.SelectedIndex].Item2.Count; absence++)
            {
                // Update the absence data grid with the absence details from this weeks timesheet.
                if (employeeCombobox[comboBoxSelectEmployee.SelectedIndex].Item2[absence])
                {
                    absenceDataGridView.Rows[0].Cells[absence].Value = true;
                }
            }
            // Set the automatic update to be finished, it is back to the users control.
            userUpdate = true;
        }
        private void comboBoxSelectEmployee_Enter(object sender, EventArgs e)
        {
            // Set the comboBoxIndex to the currently selected employee when entering the combobox so there is no null combobox selected value when the function SetComboBoxMembers is called.
            comboBoxIndex = comboBoxSelectEmployee.SelectedIndex;
        }
        private void comboBoxSelectEmployee_Leave(object sender, EventArgs e)
        {
            // Set the comboBoxIndex to the currently selected employee when leaving the combobox so there is no null combobox selected value when the function SetComboBoxMembers is called.
            comboBoxIndex = comboBoxSelectEmployee.SelectedIndex;
        }
    }
}
