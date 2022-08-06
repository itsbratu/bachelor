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
using App.Forms.Message;
using App.Utils.DTOs;

namespace App.Tester
{
    partial class TesterMain : Form
    {
        private LoggedEmployeeDTO loggedEmp;
        private LoginController loginCntrl;
        private BugsController bugCntrl;
        private MessagesController msgCntrl;
        public TesterMain(LoggedEmployeeDTO emp, LoginController cntrl)
        {
            loggedEmp = emp;
            loginCntrl = cntrl;
            InitializeComponent();
            bugCntrl = new BugsController();
            msgCntrl = new MessagesController();
        }

        private void TesterMain_Load(object sender, EventArgs e)
        {
            label_userName.Text = loggedEmp.username;
            label_jobTitle.Text = loggedEmp.type.ToString();
            buttonLogout.BackColor = ColorTranslator.FromHtml("#d09cd9");
            buttonAddBug.BackColor = ColorTranslator.FromHtml("#d09cd9");
            buttonChat.BackColor = ColorTranslator.FromHtml("#d09cd9");
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Login loginWindow = new Login(loginCntrl);
            this.Hide();
            loginWindow.Show();
        }

        private void buttonAddBug_Click(object sender, EventArgs e)
        {
            AddBug addBugWindow = new AddBug(loggedEmp, loginCntrl, bugCntrl);
            this.Hide();
            addBugWindow.Show();
        }

        private void buttonChat_Click(object sender, EventArgs e)
        {
            Chat chatWindow = new Chat(loggedEmp, loginCntrl, msgCntrl, "tester");
            this.Hide();
            chatWindow.Show();
        }
    }
}
