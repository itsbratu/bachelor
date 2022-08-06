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

namespace App.Admin
{
    partial class DeleteUser : Form
    {
        private LoggedEmployeeDTO loggedEmp;
        private LoginController loginCntrl;
        private UsersController usersCntrl;
        public DeleteUser(LoggedEmployeeDTO emp, LoginController login_controller, UsersController users_controller)
        {
            loggedEmp = emp;
            loginCntrl = login_controller;
            usersCntrl = users_controller;
            InitializeComponent();
        }

        private void FetchUsernames()
        {
            comboBoxUsername.Items.Clear();
            foreach(string username in usersCntrl.GetUsernames().Where(e => e != loggedEmp.username))
            {
                comboBoxUsername.Items.Add(username);
            }
            if (comboBoxUsername.Items.Count != 0)
            {
                comboBoxUsername.SelectedItem = comboBoxUsername.Items[0];
            }
            else
            {
                buttonDelete.Enabled = false;
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            AdminMain adminMain = new AdminMain(loggedEmp, loginCntrl);
            this.Hide();
            adminMain.Show();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string username = (string)comboBoxUsername.SelectedItem;
            usersCntrl.DeleteEmployee(username);
            FetchUsernames();
        }

        private void DeleteUser_Load(object sender, EventArgs e)
        {
            buttonBack.BackColor = ColorTranslator.FromHtml("#d09cd9");
            comboBoxUsername.BackColor = ColorTranslator.FromHtml("#d09cd9");
            comboBoxUsername.Font = new Font("Sans", 12);
            buttonDelete.BackColor = ColorTranslator.FromHtml("#d09cd9");
            FetchUsernames();
        }
    }
}
