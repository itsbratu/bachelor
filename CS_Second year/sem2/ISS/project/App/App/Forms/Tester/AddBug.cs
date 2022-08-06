using App.Controller;
using App.Model;
using App.Utils.DTOs;
using System;
using System.Drawing;
using System.Windows.Forms;
using static App.Utils.Enums.Enums;

namespace App.Tester
{
    partial class AddBug : Form
    {
        private LoggedEmployeeDTO loggedEmp;
        private LoginController loginCntrl;
        private BugsController bugCntrl;
        public AddBug(LoggedEmployeeDTO emp, LoginController controllerLogin, BugsController controllerBug)
        {
            loggedEmp = emp;
            loginCntrl = controllerLogin;
            bugCntrl = controllerBug;
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            TesterMain testerMain = new TesterMain(loggedEmp, loginCntrl);
            this.Hide();
            testerMain.Show();
        }

        private void FetchCodeIds()
        {
            comboBoxCodeId.Items.Clear();
            foreach (int codeID in bugCntrl.GetCodeIds())
            {
                comboBoxCodeId.Items.Add(codeID);
            }
            if (comboBoxCodeId.Items.Count != 0)
            {
                comboBoxCodeId.SelectedItem = comboBoxCodeId.Items[0];
            }
            else
            {
                buttonAdd.Enabled = false;
            }
        }

        private void AddBug_Load(object sender, EventArgs e)
        {
            this.Size = new Size(470, 800);
            FetchCodeIds();
            buttonBack.BackColor = ColorTranslator.FromHtml("#d09cd9");
            textBoxDescription.BackColor = ColorTranslator.FromHtml("#d09cd9");
            comboBoxCodeId.BackColor = ColorTranslator.FromHtml("#d09cd9");
            comboBoxSeverity.BackColor = ColorTranslator.FromHtml("#d09cd9");
            buttonAdd.BackColor = ColorTranslator.FromHtml("#d09cd9");
            comboBoxSeverity.Items.Add(SeverityStatus.Light);
            comboBoxSeverity.Items.Add(SeverityStatus.Moderate);
            comboBoxSeverity.Items.Add(SeverityStatus.Severe);
            comboBoxSeverity.Items.Add(SeverityStatus.Extreme);
            comboBoxSeverity.SelectedItem = SeverityStatus.Light;
            textBoxDescription.Font = new Font("Sans", 14);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if(textBoxDescription.Text.Length <= 0 || textBoxDescription.Text.Length > 500)
            {
                MessageBox.Show("Bug description must be of 1-500 length!", "ERROR");
            }
            else
            {
                int codeId = (int)comboBoxCodeId.SelectedItem;
                string username = loggedEmp.username;
                string description = textBoxDescription.Text;
                SeverityStatus status = (SeverityStatus)comboBoxSeverity.SelectedItem;
                bugCntrl.AddBug(codeId, username, description, status);
                textBoxDescription.Text = "";
                comboBoxCodeId.SelectedItem = comboBoxCodeId.Items[0];
                comboBoxSeverity.SelectedItem = comboBoxSeverity.Items[0];
            }
        }
    }
}
