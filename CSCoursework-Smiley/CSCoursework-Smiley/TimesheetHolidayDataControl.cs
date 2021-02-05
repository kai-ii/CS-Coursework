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
        // Initialize Variables
        private bool userUpdate = true;
        private int comboBoxIndex = 0;
        public TimesheetHolidayDataControl()
        {
            InitializeComponent();
        }

        public TimesheetControl parentForm { get; set; }
        public List<Tuple<int, List<bool>>> employeeCombobox { get; set; }

        private void TimesheetHolidayDataControl_Load(object sender, EventArgs e)
        {
            InitializeHolidayDataGridView();
            SetUpEventHandlers();
        }

        private void SetUpEventHandlers()
        {
            this.holidayDataGridView.CellValueChanged += new DataGridViewCellEventHandler(this.holidayDataGridView_CellValueChanged);
        }

        private void holidayDataGridView_CellValueChanged (object sender, DataGridViewCellEventArgs e)
        {
            if (userUpdate)
            {
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
            holidayDataGridView.Rows.Add();
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
            holidayDataGridView.Rows.Clear();
            holidayDataGridView.Rows.Add();
        }

        private void comboBoxSelectEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBoxSelectEmployee.SelectedIndex.ToString());
            ClearDataGrid();
            UpdateDatagrid();
            comboBoxIndex = comboBoxSelectEmployee.SelectedIndex;
        }

        private void comboBoxSelectEmployee_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ClearDataGrid();
            UpdateDatagrid();
        }

        public void UpdateDatagrid()
        {
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
            comboBoxIndex = comboBoxSelectEmployee.SelectedIndex;
        }

        private void comboBoxSelectEmployee_Leave(object sender, EventArgs e)
        {
            comboBoxIndex = comboBoxSelectEmployee.SelectedIndex;
        }
    }
}
