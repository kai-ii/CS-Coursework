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
    public partial class AdminControlManageEmployees : UserControl
    {
        // Initialise local class variables.
        OleDbConnection con = new OleDbConnection();
        Dictionary<string, string> staffNameDictionary;
        int primaryKeySelected; // this refers to the staffID in most cases
        int userID;
        public void SetCon(OleDbConnection Con)
        {
            // Assign the local connection string value to the already generated one, saving on processing since otherwise the database location would have to be grabbed multiple times.
            con = Con;
            // Initialize the form once the connection string has been assigned.
            InitializeForm();
        }
        private void InitializeForm()
        {
            /*This function is used to initialize various sections of the form e.g. visibility or default values for more info on a specific function there is one provided within the function declaration*/
            InitializeSearchTextbox();
            InitializeStaffMembers();
            lstBoxEmployees.Visible = false;
            lstBoxDummy.Visible = true;
            comboBoxSort.SelectedIndex = 0;
            CopyBaseListBoxToDummyBox();
            SortDummyBox();
            lstBoxDummy.SelectedIndex = 0;
            InitializeParentChildRelationships();
        }
        public AdminControlManageEmployees()
        {
            // Standard form initialize component call.
            InitializeComponent();
        }
        public void SavePermissions(bool[] permissionArray)
        {
            // Open database connection.
            con.Open();

            // Initialize database variables.
            DataSet PermissionDS;
            DataTable PermissionTable;
            OleDbDataAdapter da;
            string sql;

            // Get permission_id for permissionArray given and initialize the permission dataset and datatable.
            sql = $"SELECT permission_id FROM tblPermissions WHERE dashboard_access={permissionArray[0]} AND staff_personal_access={permissionArray[1]} AND staff_all_access={permissionArray[2]} AND rota_access={permissionArray[3]} AND timesheet_access={permissionArray[4]} AND payslip_access={permissionArray[5]} AND export_access={permissionArray[6]} AND admin_access=false";
            da = new OleDbDataAdapter(sql, con);
            PermissionDS = new DataSet();
            da.Fill(PermissionDS, "PermissionInfo");
            PermissionTable = PermissionDS.Tables["PermissionInfo"];

            // CLose database connection.
            con.Close();

            // Check if there is already an entry for this permissionArray combo.
            if (PermissionTable.Rows.Count > 0)
            {
                /*If the permission array already exists when just update the user to that permission_id.*/
                var updateCommand = new OleDbCommand();
                sql = $"UPDATE [tblUsers] SET [permission_id]={PermissionTable.Rows[0].Field<int>("permission_id")} WHERE [user_id]={userID};";
                updateCommand.CommandText = sql;
                updateCommand.Connection = con;
                con.Open();
                updateCommand.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                /*If the permission array has not been created then create it*/
                // Open database connection.
                con.Open(); 

                // Initialize permission dataset and datatable.
                sql = $"SELECT * FROM tblPermissions";
                da = new OleDbDataAdapter(sql, con);
                PermissionDS = new DataSet();
                da.Fill(PermissionDS, "PermissionInfo");
                PermissionTable = PermissionDS.Tables["PermissionInfo"];

                // Close database connection.
                con.Close();

                // Create a new permission row and add the corresponding values.
                DataRow newPermissionRow = PermissionTable.NewRow();
                int permissionID = PermissionTable.Rows[PermissionTable.Rows.Count - 1].Field<int>("permission_id") + 1;
                newPermissionRow[0] = permissionID;
                for (int column = 1; column <= 7; column++)
                {
                    newPermissionRow[column] = permissionArray[column - 1];
                }
                newPermissionRow[8] = false; // Admin access is always false, this is only set true for the administrator for security reasons.
                PermissionTable.Rows.Add(newPermissionRow);

                // Generate a command builder and update the permission database.
                _ = new OleDbCommandBuilder(da);
                da.Update(PermissionDS, "PermissionInfo");

                // Now add the created permission to the user.
                var updateCommand = new OleDbCommand();
                sql = $"UPDATE [tblUsers] SET [permission_id]={permissionID} WHERE [user_id]={userID};";
                updateCommand.CommandText = sql;
                updateCommand.Connection = con;
                con.Open();
                updateCommand.ExecuteNonQuery();
                con.Close();
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            // If the user clicks the back button then hide this form.
            this.Visible = false;
        }

        private void AdminControlManageEmployees_Load(object sender, EventArgs e)
        {
            // Nothing is done when the form is loaded since we must wait for the connection string to be passed to access the database.
        }
        private void InitializeParentChildRelationships()
        {
            // Set the manage employees detail parent form to this form to allow it to call this forms public functions
            adminControlManageEmployeesDetails1.SetParentForm(this);
        }
        private void InitializeStaffMembers()
        {
            //Initialize Staff List.
            staffNameDictionary = new Dictionary<string, string>();

            //Open database connection.
            con.Open();

            // Initialize database variables.
            DataSet StaffInfoDS;
            OleDbDataAdapter da;
            string sql;

            // Initialize staff info dataset with all staff members.
            sql = $"SELECT * FROM tblStaff";
            da = new OleDbDataAdapter(sql, con);
            StaffInfoDS = new DataSet();
            da.Fill(StaffInfoDS, "StaffInfo");

            // For each employee add the names to the full employee list box.
            for (int employee = 0; employee < StaffInfoDS.Tables["StaffInfo"].Rows.Count; employee++)
            {
                string staff_firstname = StaffInfoDS.Tables["StaffInfo"].Rows[employee].Field<string>("staff_firstname");
                string staff_surname = StaffInfoDS.Tables["StaffInfo"].Rows[employee].Field<string>("staff_surname");
                lstBoxEmployees.Items.Add($"{staff_firstname.ToLower()[0]}{staff_surname}");
                staffNameDictionary.Add($"{staff_surname.Trim()}{staff_firstname.Trim()}", $"{staff_firstname.ToLower()[0]}{staff_surname}");
            }

            // Close database connection.
            con.Close();

            // Initialize Details View.
            lstBoxEmployees.SelectedIndex = 0;
        }
        private void InitializeSearchTextbox()
        {
            // Set up the events for entering and leaving the search textbox to give it the "search" tag when not entering it for user intuition.
            txtSearch.ForeColor = SystemColors.GrayText;
            txtSearch.Text = "search";
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
        }
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            // When the user enters the search textbox and the text is currently search set it to nothing to allow the user to search.
            if (txtSearch.Text == "search")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = SystemColors.WindowText;
            }
        }
        private void txtSearch_Leave(object sender, EventArgs e)
        {
            // When the user leaves the textbox empty, return the text to being search.
            if (txtSearch.Text.Length == 0)
            {
                txtSearch.Text = "search";
                txtSearch.ForeColor = SystemColors.GrayText;
                CopyBaseListBoxToDummyBox();
                SortDummyBox();
            }
        }
        private void CopyBaseListBoxToDummyBox()
        {
            // Reset the dummy box with all the staff members.
            lstBoxDummy.Items.Clear();
            foreach (string employee in lstBoxEmployees.Items)
            {
                lstBoxDummy.Items.Add(employee);
            }
        }
        private void SortDummyBox()
        {
            /*Quicksorts all of the items in the dummy list box using a standard quicksort algorithm with the pivot point at the end of the list*/
            if (staffNameDictionary == null) { Console.WriteLine("SortDummyBox somehow got accidentally called."); return; }
            // Assign quicksort array its values
            string[] quicksortArray = lstBoxDummy.Items.OfType<string>().ToArray();

            // Debug console writelines.
            Console.Write("Unsorted Array: ");
            foreach (string item in quicksortArray)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();

            // Perform the quicksort on the quicksortarray.
            Quicksort(quicksortArray, 0, quicksortArray.Length - 1);
            Console.Write("Sorted Array: ");
            foreach (string item in quicksortArray)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();

            // Clear the items in the dummy list box.
            lstBoxDummy.Items.Clear();
            // Foreach sorted item in the quicksort array add it to the dummy list box.
            Array.ForEach<string>(quicksortArray, staffMember => lstBoxDummy.Items.Add(staffMember));

            void Quicksort(string[] arr, int start, int end)
            {
                // Get the pivot point and set it to i, quicksort the values between the start and pivot and the pivot and the end.
                int i;
                if (start < end)
                {
                    i = Partition(arr, start, end);

                    Quicksort(arr, start, i - 1);
                    Quicksort(arr, i + 1, end);
                }
            }
            int Partition(string[] arr, int start, int end)
            {
                // Initialize variables.
                string[] a = arr;
                string pivot = a[end];
                int i = start - 1;
                string tempLow;
                string tempHigh;

                for (int j = start; j < end; j++)
                {
                    // if sorting from A-Z.
                    if (comboBoxSort.SelectedIndex == 0)
                    {
                        // if this item is less than the pivot, swap its place with the temp low value this ensures that at the end the items less than the pivot are on the left.
                        if (String.Compare(a[j], pivot) < 0)
                        {
                            Console.WriteLine($"{a[j]} < {pivot}");
                            i++;
                            tempLow = a[i];
                            tempHigh = a[j];
                            a[j] = tempLow;
                            a[i] = tempHigh;
                        }
                    }
                    // else if sorting from Z-A
                    else if (comboBoxSort.SelectedIndex == 1)
                    {
                        // if this item is greater than the pivot, swap its place with the temp high value this ensures that at the end the items greater than the pivot are on the left.
                        if (String.Compare(a[j], pivot) > 0)
                        {
                            Console.WriteLine($"{a[j]} > {pivot}");
                            i++;
                            tempLow = a[i];
                            tempHigh = a[j];
                            a[j] = tempLow;
                            a[i] = tempHigh;
                        }
                    }
                }

                tempLow = a[i + 1];
                tempHigh = a[end];
                a[i + 1] = tempHigh;
                a[end] = tempLow;

                // Debug console writes.
                Console.Write($"Pivot = {pivot}. Current Array: ");
                foreach (string item in a)
                {
                    Console.Write($"{item}, ");
                }
                Console.WriteLine();

                // return the pivot point.
                return i + 1;
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            /*Search the list box dummy items for the search text, if there is no search text then just sort the items*/
            if (staffNameDictionary == null) { Console.WriteLine("txtSearch accidentally called."); return; }
            if (txtSearch.Text.Length == 0)
            {
                CopyBaseListBoxToDummyBox();
            }
            else
            {
                // Binary search the sorted list.
                CopyBaseListBoxToDummyBox();
                SortDummyBox();
                string[] sortedArray = lstBoxDummy.Items.OfType<string>().ToArray();
                lstBoxDummy.Items.Clear();
                string searchItem = txtSearch.Text;
                int min = 0;
                int max = sortedArray.Length - 1;

                while (min <= max)
                {
                    // Calculate the midpoint.
                    int midpoint = (min + max) / 2;
                    if (sortedArray[midpoint].ToLower().Contains(searchItem.ToLower()))
                    {
                        // If the item is found then add it to the dummy list box and break out of the loop to prevent an infinite loop.
                        lstBoxDummy.Items.Add(sortedArray[midpoint]);
                        break;
                    }
                    else if (String.Compare(searchItem, sortedArray[midpoint]) > 0)
                    {
                        // If the item is greater then "remove" the bottom values of the array by changing the min index.
                        min = midpoint + 1;
                    }
                    else if (String.Compare(searchItem, sortedArray[midpoint]) < 0)
                    {
                        // If the item is greater then "remove" the top values of the array by changing the max index.
                        max = midpoint - 1;
                    }
                }
            }
            // Sort the dummy box to ensure that if there is no search value the textbox is still sorted.
            SortDummyBox();
        }

        private void comboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If the sorting is changed from A-Z to Z-A or vice versa, then re-sort the dummy list box. This is handled within the SortDummyBox function.
            SortDummyBox();
        }
        private void lstBoxDummy_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Presence check
            if (lstBoxDummy.SelectedItem != null)
            {
                // If there is an employee selected then search the full employee list box and set the lstBoxEmployee textbox to this index, this triggers the new staff member to be displayed.
                for (int employee = 0; employee < lstBoxEmployees.Items.Count; employee++)
                {
                    if (lstBoxDummy.SelectedItem.ToString() == lstBoxEmployees.Items[employee].ToString())
                    {
                        lstBoxEmployees.SelectedIndex = employee;
                        lstBoxEmployeeUpdate();
                    }
                }
            }
        }
        private void lstBoxEmployeeUpdate()
        {
            // If the main list box is updated with respect to the dummy box changing then change the primary key to this listbox's index+1, coinciding with the staff members added to it (in this listbox they are sorted by staffID)
            int index = lstBoxEmployees.SelectedIndex + 1;

            // If the current staff member being displayed is different to the changed one then get the account and permission details for that staff member, the manage employees details form is updated within those functions.
            if (primaryKeySelected != index)
            {
                primaryKeySelected = index;
                string[] name = GetAccountDetails(primaryKeySelected);
                GetPermissionDetails(name);
            }
        }
        private string[] GetAccountDetails(int primaryKey)
        {
            // Open database connection.
            con.Open();

            // Initialize database variables.
            DataSet StaffInfoDS;
            DataSet JobPositionInfoDS;
            OleDbDataAdapter da;
            string sql;

            // Get staff members.
            sql = $"SELECT jobposition_id, staff_firstname, staff_surname FROM tblStaff WHERE staff_id={primaryKey}";
            da = new OleDbDataAdapter(sql, con);
            StaffInfoDS = new DataSet();
            da.Fill(StaffInfoDS, "StaffInfo");

            DataTable StaffInfoTable = StaffInfoDS.Tables["StaffInfo"];

            // Get job position.
            sql = $"SELECT jobposition_name FROM tblJobPositions WHERE jobposition_id={StaffInfoTable.Rows[0].Field<int>("jobposition_id")}";
            da = new OleDbDataAdapter(sql, con);
            JobPositionInfoDS = new DataSet();
            da.Fill(JobPositionInfoDS, "JobPositionInfo");

            DataTable JobPositionInfoTable = JobPositionInfoDS.Tables["JobPositionInfo"];

            // Close database connection.
            con.Close();

            string[] accountInfo = new string[3]; //[forename, surname, jobposition]
            accountInfo[0] = StaffInfoTable.Rows[0].Field<string>("staff_firstname");
            accountInfo[1] = StaffInfoTable.Rows[0].Field<string>("staff_surname");
            accountInfo[2] = JobPositionInfoTable.Rows[0].Field<string>("jobposition_name");

            // Update the account details in the manage employees details form using these account details.
            adminControlManageEmployeesDetails1.UpdateAccountDetails(accountInfo);
            string[] name = { accountInfo[0], accountInfo[1] };
            // return the staff firstname and surname to use later in order to search for the corresponding username in tblUsers to find the permissions.
            return name;
        }
        private void GetPermissionDetails(string[] name)
        {
            // Open database connection.
            con.Open();

            // Initialize variables.
            DataSet UserInfoDS;
            DataSet PermissionInfoDS;
            OleDbDataAdapter da;
            string sql;
            bool[] accountPermissions = new bool[7];

            // Get permissionID and userID for the username dictated by the staff members name, this is why it is automatically generated and is also why multiple employees of the same name cannot be added to the database.
            sql = $"SELECT user_id, permission_id FROM tblUsers WHERE username='{name[0].ToLower()[0]}{name[1].ToLower()}'";
            da = new OleDbDataAdapter(sql, con);
            UserInfoDS = new DataSet();
            da.Fill(UserInfoDS, "UserInfo");

            DataTable UserInfoTable = UserInfoDS.Tables["UserInfo"];

            if (UserInfoTable.Rows.Count == 0)
            {
                // If tehre are no rows for this search query then the username does not exist then the account has not been created
                accountPermissions[0] = false;
                accountPermissions[1] = false;
                accountPermissions[2] = false;
                accountPermissions[3] = false;
                accountPermissions[4] = false;
                accountPermissions[5] = false;
                accountPermissions[6] = false;
                // Update the permission details of this employee with no account permissions since the account does not exists.
                adminControlManageEmployeesDetails1.UpdatePermissionDetails(accountPermissions);
                // Update the employee details form to show a message saying that the employee has not created an account yet.
                adminControlManageEmployeesDetails1.UpdatePermissionsAccountNotCreated();
                con.Close();
                return;
            }

            // Set userID used later on to update permissions.
            userID = UserInfoTable.Rows[0].Field<int>("user_id");

            // Get permissions
            sql = $"SELECT * FROM tblPermissions WHERE permission_id={UserInfoTable.Rows[0].Field<int>("permission_id")}";
            da = new OleDbDataAdapter(sql, con);
            PermissionInfoDS = new DataSet();
            da.Fill(PermissionInfoDS, "PermissionInfo");

            DataTable PermissionInfoTable = PermissionInfoDS.Tables["PermissionInfo"];

            // Close database connection
            con.Close();

            //[dashboard, staffpersonal, staffall, rota, timesheet, payslip, export]
            accountPermissions[0] = PermissionInfoTable.Rows[0].Field<bool>("dashboard_access");
            accountPermissions[1] = PermissionInfoTable.Rows[0].Field<bool>("staff_personal_access");
            accountPermissions[2] = PermissionInfoTable.Rows[0].Field<bool>("staff_all_access");
            accountPermissions[3] = PermissionInfoTable.Rows[0].Field<bool>("rota_access");
            accountPermissions[4] = PermissionInfoTable.Rows[0].Field<bool>("timesheet_access");
            accountPermissions[5] = PermissionInfoTable.Rows[0].Field<bool>("payslip_access");
            accountPermissions[6] = PermissionInfoTable.Rows[0].Field<bool>("export_access");

            // Update the permission details of this employee with the account permissions retrieved.
            adminControlManageEmployeesDetails1.UpdatePermissionDetails(accountPermissions);
        }
    }
}
