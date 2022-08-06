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
using App.Utils.DTOs;
using App.Admin;

namespace App
{
    partial class AdminMain : Form
    {
        private LoggedEmployeeDTO loggedEmp;
        private LoginController loginCntrl;
        private UsersController usersCntrl;
        public AdminMain(LoggedEmployeeDTO emp, LoginController cntrl)
        {
            loggedEmp = emp;
            loginCntrl = cntrl;
            InitializeComponent();
            usersCntrl = new UsersController();
        }

        private void AdminMain_Load(object sender, EventArgs e)
        {
            buttonLogout.BackColor = ColorTranslator.FromHtml("#d09cd9");
            buttonAddUser.BackColor = ColorTranslator.FromHtml("#d09cd9");
            buttonDeleteUser.BackColor = ColorTranslator.FromHtml("#d09cd9");
            buttonModifyUser.BackColor = ColorTranslator.FromHtml("#d09cd9");
            buttonViewUsers.BackColor = ColorTranslator.FromHtml("#d09cd9");
            label_userName.Text = loggedEmp.username;
            label_jobTitle.Text = loggedEmp.type.ToString();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Login loginWindow = new Login(loginCntrl);
            this.Hide();
            loginWindow.Show();
        }

        private void buttonViewUsers_Click(object sender, EventArgs e)
        {
            UserList usersWindow = new UserList(loggedEmp, loginCntrl, usersCntrl);
            this.Hide();
            usersWindow.Show();
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            AddUser addUserWindow = new AddUser(loggedEmp, loginCntrl, usersCntrl);
            this.Hide();
            addUserWindow.Show();
        }

        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            DeleteUser deleteUserWindow = new DeleteUser(loggedEmp, loginCntrl, usersCntrl);
            this.Hide();
            deleteUserWindow.Show();
        }

        private void buttonModifyUser_Click(object sender, EventArgs e)
        {
            ModifyUser modifyUserWindow = new ModifyUser(loggedEmp, loginCntrl, usersCntrl);
            this.Hide();
            modifyUserWindow.Show();
        }
    }
}
