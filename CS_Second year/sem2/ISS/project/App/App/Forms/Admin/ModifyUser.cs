using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Controller;
using App.Model;
using App.Utils.DTOs;
using static App.Utils.Enums.Enums;

namespace App.Admin
{
    partial class ModifyUser : Form
    {
        private LoggedEmployeeDTO loggedEmp;
        private LoginController loginCntrl;
        private UsersController usersCntrl;
        private string selectedUsername;
        public ModifyUser(LoggedEmployeeDTO emp, LoginController login_controller, UsersController users_controller)
        {
            loggedEmp = emp;
            loginCntrl = login_controller;
            usersCntrl = users_controller;
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            AdminMain adminMain = new AdminMain(loggedEmp, loginCntrl);
            this.Hide();
            adminMain.Show();
        }

        private void ModifyUser_Load(object sender, EventArgs e)
        {
            this.InitializeForm();
        }

        private void viewEntities_SelectionChanged(object sender, EventArgs e)
        {
            if (viewEntities.SelectedCells.Count > 0)
            {
                int selectedrowindex = viewEntities.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = viewEntities.Rows[selectedrowindex];
                selectedUsername = selectedRow.Cells["username"].Value.ToString();
                string passValue = selectedRow.Cells["password"].Value.ToString();
                string firstnameValue = selectedRow.Cells["firstname"].Value.ToString();
                string lastnameValue = selectedRow.Cells["lastname"].Value.ToString();
                string typeValue = selectedRow.Cells["type"].Value.ToString();
                textBoxPassword.Text = passValue;
                textBoxConfirmPassword.Text = passValue;
                textBoxFirstName.Text = firstnameValue;
                textBoxLastName.Text = lastnameValue;
                comboBoxType.Items.Clear();
                comboBoxType.Items.Add(EmployeeType.Programmer);
                comboBoxType.Items.Add(EmployeeType.Tester);
                comboBoxType.Items.Add(EmployeeType.Admin);
                comboBoxType.Font = new Font("Sans", 12);
                switch (typeValue)
                {
                    case "Programmer":
                        comboBoxType.SelectedItem = EmployeeType.Programmer;
                        break;
                    case "Tester":
                        comboBoxType.SelectedItem = EmployeeType.Tester;
                        break;
                    default:
                        comboBoxType.SelectedItem = EmployeeType.Admin;
                        break;
                }
            }
        }
        private void InitializeForm()
        {
            this.Size = new Size(1300, 500);
            viewEntities.DataSource = usersCntrl.GetEmployees().Where(e => e.username != loggedEmp.username).ToList();
            viewEntities.DefaultCellStyle.Alignment = (DataGridViewContentAlignment)HorizontalAlignment.Left;
            viewEntities.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#d09cd9");
            viewEntities.EnableHeadersVisualStyles = false;
            viewEntities.Columns["username"].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#c069cf");
            viewEntities.Columns["password"].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#c069cf");
            viewEntities.Columns["firstname"].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#c069cf");
            viewEntities.Columns["lastname"].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#c069cf");
            viewEntities.Columns["type"].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#c069cf");
            viewEntities.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
            viewEntities.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
            viewEntities.AdvancedCellBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            viewEntities.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            viewEntities.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            viewEntities.Columns[0].DefaultCellStyle.Font = new Font("Sans", 10);
            viewEntities.Columns[1].DefaultCellStyle.Font = new Font("Sans", 10);
            viewEntities.Columns[2].DefaultCellStyle.Font = new Font("Sans", 10);
            viewEntities.Columns[3].DefaultCellStyle.Font = new Font("Sans", 10);
            viewEntities.Columns[4].DefaultCellStyle.Font = new Font("Sans", 10);
            viewEntities.BorderStyle = BorderStyle.None;
            viewEntities.Columns[0].Width = 125;
            viewEntities.Columns[1].Width = 125;
            viewEntities.Columns[2].Width = 105;
            viewEntities.Columns[3].Width = 105;
            viewEntities.Columns[4].Width = 105;
            viewEntities.RowHeadersVisible = false;
            buttonBack.BackColor = ColorTranslator.FromHtml("#d09cd9");
            buttonModify.BackColor = ColorTranslator.FromHtml("#d09cd9");
            textBoxPassword.BackColor = ColorTranslator.FromHtml("#d09cd9");
            textBoxConfirmPassword.BackColor = ColorTranslator.FromHtml("#d09cd9");
            textBoxFirstName.BackColor = ColorTranslator.FromHtml("#d09cd9");
            textBoxLastName.BackColor = ColorTranslator.FromHtml("#d09cd9");
            comboBoxType.BackColor = ColorTranslator.FromHtml("#d09cd9");
            viewEntities.Columns[0].HeaderCell.Style.Font = new Font("Sans", 10, FontStyle.Bold);
            viewEntities.Columns[0].HeaderText = "Username";
            viewEntities.Columns[1].HeaderCell.Style.Font = new Font("Sans", 10, FontStyle.Bold);
            viewEntities.Columns[1].HeaderText = "Password";
            viewEntities.Columns[2].HeaderCell.Style.Font = new Font("Sans", 10, FontStyle.Bold);
            viewEntities.Columns[2].HeaderText = "First name";
            viewEntities.Columns[3].HeaderCell.Style.Font = new Font("Sans", 10, FontStyle.Bold);
            viewEntities.Columns[3].HeaderText = "Last name";
            viewEntities.Columns[4].HeaderCell.Style.Font = new Font("Sans", 10, FontStyle.Bold);
            viewEntities.Columns[4].HeaderText = "Type";
        }

        private void eyePassBtn_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !textBoxPassword.UseSystemPasswordChar;
            textBoxConfirmPassword.UseSystemPasswordChar = !textBoxConfirmPassword.UseSystemPasswordChar;
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            try
            {
                string password = textBoxPassword.Text;
                string confirmPassword = textBoxConfirmPassword.Text;
                string firstName = textBoxFirstName.Text;
                string lastName = textBoxLastName.Text;
                EmployeeType type = (EmployeeType)comboBoxType.SelectedItem;
                usersCntrl.UpdateEmployee(selectedUsername, password, confirmPassword, firstName, lastName, type);
                viewEntities.DataSource = usersCntrl.GetEmployees().Where(e => e.username != loggedEmp.username).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
