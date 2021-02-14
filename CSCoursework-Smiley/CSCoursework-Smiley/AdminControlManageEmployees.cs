﻿using System;
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
        // Initialize Variables
        OleDbConnection con = new OleDbConnection();
        Dictionary<string, string> staffNameDictionary;
        int primaryKeySelected;

        public int userID { get; set; }
        public AdminControlManageEmployees()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void AdminControlManageEmployees_Load(object sender, EventArgs e)
        {
            InitializeDatabaseConnection();
            InitializeSearchTextbox();
            InitializeStaffMembers();
            lstBoxEmployees.Visible = false;
            lstBoxDummy.Visible = true;
            comboBoxSort.SelectedIndex = 0;
            CopyBaseListBoxToDummyBox();
            SortDummyBox();
            lstBoxDummy.SelectedIndex = 0;
            //GetAccountDetails(primaryKeySelected);
            //GetPermissionDetails(primaryKeySelected);
        }
        private void InitializeStaffMembers()
        {
            //Initialize Staff List
            staffNameDictionary = new Dictionary<string, string>();

            //Open database connection
            con.Open();

            //Initialize variables
            DataSet StaffInfoDS;
            OleDbDataAdapter da;
            string sql;

            //Get staff members
            sql = $"SELECT * FROM tblStaff";
            da = new OleDbDataAdapter(sql, con);
            StaffInfoDS = new DataSet();
            da.Fill(StaffInfoDS, "StaffInfo");

            for (int employee = 0; employee < StaffInfoDS.Tables["StaffInfo"].Rows.Count; employee++)
            {
                string staff_firstname = StaffInfoDS.Tables["StaffInfo"].Rows[employee].Field<string>("staff_firstname");
                string staff_surname = StaffInfoDS.Tables["StaffInfo"].Rows[employee].Field<string>("staff_surname");
                lstBoxEmployees.Items.Add($"{staff_firstname.ToLower()[0]}{staff_surname}");
                staffNameDictionary.Add($"{staff_surname.Trim()}{staff_firstname.Trim()}", $"{staff_firstname.ToLower()[0]}{staff_surname}");
            }

            //Close database connection
            con.Close();

            //Initialize Details View
            lstBoxEmployees.SelectedIndex = 0;


            //UpdateRowStaffDetails(1);
        }
        private void InitializeSearchTextbox()
        {
            txtSearch.ForeColor = SystemColors.GrayText;
            txtSearch.Text = "search";
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
        }
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "search")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = SystemColors.WindowText;
            }
        }
        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
            {
                txtSearch.Text = "search";
                txtSearch.ForeColor = SystemColors.GrayText;
                //lstBoxDummy.Visible = false;
                CopyBaseListBoxToDummyBox();
                SortDummyBox();
            }
        }
        private void CopyBaseListBoxToDummyBox()
        {
            lstBoxDummy.Items.Clear();
            foreach (string employee in lstBoxEmployees.Items)
            {
                lstBoxDummy.Items.Add(employee);
            }
        }
        private void SortDummyBox()
        {
            if (staffNameDictionary == null) { Console.WriteLine("SortDummyBox somehow got accidentally called."); return; }
            string[] quicksortArray = lstBoxDummy.Items.OfType<string>().ToArray();

            Console.Write("Unsorted Array: ");
            foreach (string item in quicksortArray)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();

            Quicksort(quicksortArray, 0, quicksortArray.Length - 1);
            Console.Write("Sorted Array: ");
            foreach (string item in quicksortArray)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();

            lstBoxDummy.Items.Clear();
            Array.ForEach<string>(quicksortArray, staffMember => lstBoxDummy.Items.Add(staffMember));

            void Quicksort(string[] arr, int start, int end)
            {
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
                string[] a = arr;
                string pivot = a[end];
                int i = start - 1;
                string tempLow;
                string tempHigh;

                for (int j = start; j < end; j++)
                {
                    if (comboBoxSort.SelectedIndex == 0)
                    {
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
                    else if (comboBoxSort.SelectedIndex == 1)
                    {
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

                Console.Write($"Pivot = {pivot}. Current Array: ");
                foreach (string item in a)
                {
                    Console.Write($"{item}, ");
                }
                Console.WriteLine();

                return i + 1;
            }
        }
        private void InitializeDatabaseConnection()
        {
            //Initialize variables
            string dbProvider;
            string DatabasePath;
            string CurrentProjectPath;
            string FullDatabasePath;
            string dbSource;

            try
            {
                //Establish Connection with Database
                dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;";
                DatabasePath = "/TestDatabase.accdb";
                CurrentProjectPath = System.AppDomain.CurrentDomain.BaseDirectory;
                FullDatabasePath = CurrentProjectPath + DatabasePath;
                dbSource = "Data Source =" + FullDatabasePath;
                con.ConnectionString = dbProvider + dbSource;
                con.Open();
                Console.WriteLine("Connection established");
                con.Close();
            }
            catch
            {
                MessageBox.Show("Error establishing database connection AdminControlManageEmployees.");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (staffNameDictionary == null) { Console.WriteLine("txtSearch accidentally called."); return; }
            if (txtSearch.Text.Length == 0)
            {
                //lstBoxDummy.Visible = false;
                CopyBaseListBoxToDummyBox();
            }
            else
            {
                string searchString = txtSearch.Text;
                lstBoxDummy.Items.Clear();
                foreach (string employee in staffNameDictionary.Values)
                {
                    //MessageBox.Show($"employee = {employee}, searchString = {searchString}");
                    //lstBoxDummy.Visible = true;
                    if (employee.ToLower().Contains(searchString))
                    {
                        if (!lstBoxDummy.Items.Contains(employee))
                        {
                            lstBoxDummy.Items.Add(employee);
                        }
                    }
                }
            }
            SortDummyBox();
        }

        private void comboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            SortDummyBox();
        }
        private void lstBoxDummy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Presence check
            if (lstBoxDummy.SelectedItem != null)
            {
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
            int index = lstBoxEmployees.SelectedIndex + 1;

            if (primaryKeySelected != index)
            {
                primaryKeySelected = index;
                string[] name = GetAccountDetails(primaryKeySelected);
                GetPermissionDetails(name);
            }
        }
        private string[] GetAccountDetails(int primaryKey)
        {
            // Open database connection
            con.Open();

            // Initialize variables
            DataSet StaffInfoDS;
            DataSet JobPositionInfoDS;
            OleDbDataAdapter da;
            string sql;

            // Get staff members
            sql = $"SELECT jobposition_id, staff_firstname, staff_surname FROM tblStaff WHERE staff_id={primaryKey}";
            da = new OleDbDataAdapter(sql, con);
            StaffInfoDS = new DataSet();
            da.Fill(StaffInfoDS, "StaffInfo");

            DataTable StaffInfoTable = StaffInfoDS.Tables["StaffInfo"];

            // Get job position
            sql = $"SELECT jobposition_name FROM tblJobPositions WHERE jobposition_id={StaffInfoTable.Rows[0].Field<int>("jobposition_id")}";
            da = new OleDbDataAdapter(sql, con);
            JobPositionInfoDS = new DataSet();
            da.Fill(JobPositionInfoDS, "JobPositionInfo");

            DataTable JobPositionInfoTable = JobPositionInfoDS.Tables["JobPositionInfo"];

            // Close database connection
            con.Close();

            string[] accountInfo = new string[3]; //forename, surname, jobposition
            accountInfo[0] = StaffInfoTable.Rows[0].Field<string>("staff_firstname");
            accountInfo[1] = StaffInfoTable.Rows[0].Field<string>("staff_surname");
            accountInfo[2] = JobPositionInfoTable.Rows[0].Field<string>("jobposition_name");

            adminControlManageEmployeesDetails1.UpdateAccountDetails(accountInfo);
            string[] name = { accountInfo[0], accountInfo[1] };
            return name;
        }
        private void GetPermissionDetails(string[] name)
        {
            // Open database connection
            con.Open();

            // Initialize variables
            DataSet UserInfoDS;
            DataSet PermissionInfoDS;
            OleDbDataAdapter da;
            string sql;
            bool[] accountPermissions = new bool[7];

            // Get permissionID
            sql = $"SELECT permission_id FROM tblUsers WHERE username='{name[0].ToLower()[0]}{name[1].ToLower()}'";
            da = new OleDbDataAdapter(sql, con);
            UserInfoDS = new DataSet();
            da.Fill(UserInfoDS, "UserInfo");

            DataTable UserInfoTable = UserInfoDS.Tables["UserInfo"];
            if (UserInfoTable.Rows.Count == 0)
            {
                accountPermissions[0] = false;
                accountPermissions[1] = false;
                accountPermissions[2] = false;
                accountPermissions[3] = false;
                accountPermissions[4] = false;
                accountPermissions[5] = false;
                accountPermissions[6] = false;
                adminControlManageEmployeesDetails1.UpdatePermissionDetails(accountPermissions);
                adminControlManageEmployeesDetails1.UpdatePermissionsAccountNotCreated();
                con.Close();
                return;
            }

            // Get permissions
            sql = $"SELECT * FROM tblPermissions WHERE permission_id={UserInfoTable.Rows[0].Field<int>("permission_id")}";
            da = new OleDbDataAdapter(sql, con);
            PermissionInfoDS = new DataSet();
            da.Fill(PermissionInfoDS, "PermissionInfo");

            DataTable PermissionInfoTable = PermissionInfoDS.Tables["PermissionInfo"];

            // Close database connection
            con.Close();

            //dashboard, staffpersonal, staffall, rota, timesheet, payslip, export
            accountPermissions[0] = PermissionInfoTable.Rows[0].Field<bool>("dashboard_access");
            accountPermissions[1] = PermissionInfoTable.Rows[0].Field<bool>("staff_personal_access");
            accountPermissions[2] = PermissionInfoTable.Rows[0].Field<bool>("staff_all_access");
            accountPermissions[3] = PermissionInfoTable.Rows[0].Field<bool>("rota_access");
            accountPermissions[4] = PermissionInfoTable.Rows[0].Field<bool>("timesheet_access");
            accountPermissions[5] = PermissionInfoTable.Rows[0].Field<bool>("payslip_access");
            accountPermissions[6] = PermissionInfoTable.Rows[0].Field<bool>("export_access");

            adminControlManageEmployeesDetails1.UpdatePermissionDetails(accountPermissions);
        }
    }
}