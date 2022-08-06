using App.Controller;
using App.Forms.Programmer;
using App.Model;
using App.Utils.DTOs;
using System.Drawing;
using System.Windows.Forms;

namespace App.Programmer
{
    partial class FixBug : Form
    {
        private LoggedEmployeeDTO loggedEmp;
        private LoginController loginCntrl;
        private BugsController bugCntrl;
        public FixBug(LoggedEmployeeDTO emp, LoginController controllerLogin, BugsController controllerBug)
        {
            InitializeComponent();
            loggedEmp = emp;
            loginCntrl = controllerLogin;
            bugCntrl = controllerBug;
        }

        private void backButton_Click(object sender, System.EventArgs e)
        {
            ProgrammerMain programmerMain = new ProgrammerMain(loggedEmp, loginCntrl);
            this.Hide();
            programmerMain.Show();
        }

        private void FetchBugIds()
        {
            comboBoxIds.Items.Clear();
            foreach (Bug b in bugCntrl.GetBugs(loggedEmp.username, true))
            {
                comboBoxIds.Items.Add(b.id);
            }
            if (comboBoxIds.Items.Count != 0)
            {
                comboBoxIds.SelectedItem = comboBoxIds.Items[0];
            }
            else
            {
                buttonFix.Enabled = false;
            }
        }

        private void FixBug_Load(object sender, System.EventArgs e)
        {
            comboBoxIds.BackColor = ColorTranslator.FromHtml("#d09cd9");
            buttonFix.BackColor = ColorTranslator.FromHtml("#d09cd9");
            backButton.BackColor = ColorTranslator.FromHtml("#d09cd9");
            FetchBugIds();
        }

        private void buttonFix_Click(object sender, System.EventArgs e)
        {
            int bugId = (int)comboBoxIds.SelectedItem;
            bugCntrl.DeleteBug(bugId);
            FetchBugIds();
        }
    }
}
