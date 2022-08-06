using App.Controller;
using App.Forms.Programmer;
using App.Utils.DTOs;
using System;
using System.Drawing;
using System.Windows.Forms;
using static App.Utils.Enums.Enums;

namespace App.Programmer
{
    partial class AddReview : Form
    {
        private LoggedEmployeeDTO loggedEmp;
        private LoginController loginCntrl;
        private ReviewsController reviewCntrl;
        public AddReview(LoggedEmployeeDTO emp, LoginController login_controller, ReviewsController review_controller)
        {
            InitializeComponent();
            loggedEmp = emp;
            loginCntrl = login_controller;
            reviewCntrl = review_controller;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            ProgrammerMain programmerMain = new ProgrammerMain(loggedEmp, loginCntrl);
            this.Hide();
            programmerMain.Show();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxDescription.Text.Length <= 0 || textBoxDescription.Text.Length > 500)
            {
                MessageBox.Show("Review description must be of 1-500 length!", "ERROR");
            }
            else
            {
                int codeId = (int)comboBoxCodeId.SelectedItem;
                string username = loggedEmp.username;
                string description = textBoxDescription.Text;
                CodeQuality quality = (CodeQuality)comboBoxFeedback.SelectedItem;
                reviewCntrl.AddReview(codeId, username, description, quality);
                textBoxDescription.Text = "";
                comboBoxCodeId.SelectedItem = comboBoxCodeId.Items[0];
                comboBoxFeedback.SelectedItem = comboBoxFeedback.Items[0];
            }
        }

        private void FetchCodeIds()
        {
            comboBoxCodeId.Items.Clear();
            foreach (int codeID in reviewCntrl.GetCodeIds())
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

        private void AddReview_Load(object sender, EventArgs e)
        {
            this.Size = new Size(470, 800);
            FetchCodeIds();
            buttonBack.BackColor = ColorTranslator.FromHtml("#d09cd9");
            textBoxDescription.BackColor = ColorTranslator.FromHtml("#d09cd9");
            comboBoxCodeId.BackColor = ColorTranslator.FromHtml("#d09cd9");
            comboBoxFeedback.BackColor = ColorTranslator.FromHtml("#d09cd9");
            buttonAdd.BackColor = ColorTranslator.FromHtml("#d09cd9");
            comboBoxFeedback.Items.Add(CodeQuality.Poor);
            comboBoxFeedback.Items.Add(CodeQuality.Weak);
            comboBoxFeedback.Items.Add(CodeQuality.Mediocre);
            comboBoxFeedback.Items.Add(CodeQuality.Good);
            comboBoxFeedback.Items.Add(CodeQuality.VeryGood);
            comboBoxFeedback.Items.Add(CodeQuality.Excellent);
            comboBoxFeedback.SelectedItem = CodeQuality.Poor;
            textBoxDescription.Font = new Font("Sans", 14);
        }
    }
}
