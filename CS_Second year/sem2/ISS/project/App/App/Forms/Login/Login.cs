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
using App.Forms.Programmer;
using App.Programmer;
using App.Tester;
using App.Utils.DTOs;
using static App.Utils.Enums.Enums;

namespace App
{
    partial class Login : Form
    {
        private LoginController loginCntrl;
        public Login(LoginController cntrl)
        {
            this.loginCntrl = cntrl;
            InitializeComponent();
        } 

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            if (username == "" || password == "")
            {
                MessageBox.Show("Username and password fields must not be empty!", "Invalid user input!");
                textBoxUsername.Text = "";
                textBoxPassword.Text = "";
            }
            else
            {
                try
                {
                    LoggedEmployeeDTO loggedEmp = loginCntrl.LoginEmployee(username, password);
                    switch (loggedEmp.type)
                    {
                        case EmployeeType.Admin:
                            AdminMain adminWindow = new AdminMain(loggedEmp, loginCntrl);
                            this.Hide();
                            adminWindow.Show();
                            break;
                        case EmployeeType.Programmer:
                            ProgrammerMain programmerWindow = new ProgrammerMain(loggedEmp, loginCntrl);
                            this.Hide();
                            programmerWindow.Show();
                            break;
                        case EmployeeType.Tester:
                            TesterMain testerWindow = new TesterMain(loggedEmp, loginCntrl);
                            this.Hide();
                            testerWindow.Show();
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message, "Invalid credentials!");
                    textBoxUsername.Text = "";
                    textBoxPassword.Text = "";
                }
            }
        }

        private void Login_Load_1(object sender, EventArgs e)
        {
            textBoxUsername.BackColor = ColorTranslator.FromHtml("#d09cd9");
            textBoxPassword.BackColor = ColorTranslator.FromHtml("#d09cd9");
            buttonLogin.BackColor = ColorTranslator.FromHtml("#d09cd9");
        }
    }
}
