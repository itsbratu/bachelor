using System;
using System.Drawing;
using System.Windows.Forms;
using App.Controller;
using App.Model;
using App.Utils.DTOs;
using static App.Utils.Enums.Enums;

namespace App.Admin
{
    partial class AddUser : Form
    {
        private LoggedEmployeeDTO loggedEmp;
        private LoginController loginCntrl;
        private UsersController usersCntrl;
        public AddUser(LoggedEmployeeDTO emp, LoginController login_controller, UsersController users_controller)
        {
            loggedEmp = emp;
            loginCntrl = login_controller;
            usersCntrl = users_controller;
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            buttonAddUser.BackColor = ColorTranslator.FromHtml("#d09cd9");
            buttonBack.BackColor = ColorTranslator.FromHtml("#d09cd9");
            eyePassBtn.BackColor = ColorTranslator.FromHtml("#d09cd9");
            comboBoxType.Items.Add(EmployeeType.Programmer);
            comboBoxType.Items.Add(EmployeeType.Tester);
            comboBoxType.Items.Add(EmployeeType.Admin);
            comboBoxType.SelectedItem = EmployeeType.Programmer;
            comboBoxType.Font = new Font("Sans", 12);
            textBoxUsername.BackColor = ColorTranslator.FromHtml("#d09cd9");
            textBoxPassword.BackColor = ColorTranslator.FromHtml("#d09cd9");
            textBoxConfirmPassword.BackColor = ColorTranslator.FromHtml("#d09cd9");
            textBoxFirstname.BackColor = ColorTranslator.FromHtml("#d09cd9");
            textBoxLastname.BackColor = ColorTranslator.FromHtml("#d09cd9");
            comboBoxType.BackColor = ColorTranslator.FromHtml("#d09cd9");
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            AdminMain adminMain = new AdminMain(loggedEmp, loginCntrl);
            this.Hide();
            adminMain.Show();
        }
    
        private void clearInputs()
        {
            textBoxUsername.Text = "";
            textBoxPassword.Text = "";
            textBoxConfirmPassword.Text = "";
            textBoxFirstname.Text = "";
            textBoxLastname.Text = "";
            comboBoxType.SelectedItem = EmployeeType.Programmer;
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBoxUsername.Text;
                string password = textBoxPassword.Text;
                string confirmPassword = textBoxConfirmPassword.Text;
                string firstName = textBoxFirstname.Text;
                string lastName = textBoxLastname.Text;
                EmployeeType type = (EmployeeType)comboBoxType.SelectedItem;
                usersCntrl.SaveEmployee(username, password, confirmPassword, firstName, lastName, type);
                clearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void eyePassBtn_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !textBoxPassword.UseSystemPasswordChar;
            textBoxConfirmPassword.UseSystemPasswordChar = !textBoxConfirmPassword.UseSystemPasswordChar;
        }
    }
}
