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
    public partial class TimesheetHolidayDataControl : UserControl
    {
        // Initialise local class variables.
        private bool userUpdate = true;
        private int comboBoxIndex = 0;
        TimesheetControl parentForm;
        List<Tuple<int, List<bool>>> employeeCombobox;
        public TimesheetHolidayDataControl()
        {
            // Standard form initialize component call.
            InitializeComponent();
        }
        public void SetEmployeeComboBox(List<Tuple<int, List<bool>>> EmployeeCombobox)
        {
            // Set the local employeeCombobox variable to the passed in value.
            employeeCombobox = EmployeeCombobox;
        }
        public void SetParentForm(TimesheetControl ParentForm)
        {
            // Assign this forms parent form to be a parent form of the template TimesheetControl which is passed in from the Timesheet Control.
            parentForm = ParentForm;
        }
        private void TimesheetHolidayDataControl_Load(object sender, EventArgs e)
        {
            // Preprocessing for the form to do before data gets passed in, including initializing the holiday datagrid (where the days are selected) and setting up the forms event handlers.
            InitializeHolidayDataGridView();
            SetUpEventHandlers();
        }
        private void SetUpEventHandlers()
        {
            // Set up the holiday data grid cell value changed event.
            this.holidayDataGridView.CellValueChanged += new DataGridViewCellEventHandler(this.holidayDataGridView_CellValueChanged);
        }
        private void holidayDataGridView_CellValueChanged (object sender, DataGridViewCellEventArgs e)
        {
            // userUpdate dictates whether or not the update was caused by a user or automatically. This stops an infinite looping bug.
            if (userUpdate)
            {
                // Update the timesheet datagrid view with holidays corresponding to the selected cell.
                if (Convert.ToBoolean(holidayDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                {
                    parentForm.UpdateHolidayData(comboBoxSelectEmployee.SelectedIndex, e.ColumnIndex + 1, true);
                }
                else
                {
                    parentForm.UpdateHolidayData(comboBoxSelectEmployee.SelectedIndex, e.ColumnIndex + 1, false);
                }
            }
        }
        private void InitializeHolidayDataGridView()
        {
            // Add the initial row to the holiday data grid.
            holidayDataGridView.Rows.Add();
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
            holidayDataGridView.Rows.Clear();
            holidayDataGridView.Rows.Add();
        }
        private void comboBoxSelectEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If the selected employee has changed clear the datagrid and then update it with the users absence values for the current timesheet.
            ClearDataGrid();
            UpdateDatagrid();
            comboBoxIndex = comboBoxSelectEmployee.SelectedIndex;
        }
        public void UpdateDatagrid()
        {
            // This is an automatic update so set userUpdate to be false, this way when the cell changed event fires, logic applied to a human change isn't applied during this update.
            userUpdate = false;
            for (int holiday = 0; holiday < employeeCombobox[comboBoxSelectEmployee.SelectedIndex].Item2.Count; holiday++)
            {
                if (employeeCombobox[comboBoxSelectEmployee.SelectedIndex].Item2[holiday])
                {
                    holidayDataGridView.Rows[0].Cells[holiday].Value = true;
                }
            }
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
