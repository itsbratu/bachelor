using App.Controller;
using App.Forms.Message;
using App.Programmer;
using App.Utils.DTOs;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace App.Forms.Programmer
{
    partial class ProgrammerMain : Form
    {
        private LoggedEmployeeDTO loggedEmp;
        private LoginController loginCntrl;
        private BugsController bugCntrl;
        private MessagesController msgCntrl;
        private ReviewsController reviewCntrl;
        public ProgrammerMain(LoggedEmployeeDTO emp, LoginController cntrl)
        {
            InitializeComponent();
            loggedEmp = emp;
            loginCntrl = cntrl;
            bugCntrl = new BugsController();
            msgCntrl = new MessagesController();
            reviewCntrl = new ReviewsController();
        }

        private void ProgrammerMain_Load(object sender, EventArgs e)
        {
            buttonViewBugs.BackColor = ColorTranslator.FromHtml("#d09cd9");
            buttonFixBug.BackColor = ColorTranslator.FromHtml("#d09cd9");
            buttonLogout.BackColor = ColorTranslator.FromHtml("#d09cd9");
            buttonViewBugs.BackColor = ColorTranslator.FromHtml("#d09cd9");
            buttonChat.BackColor = ColorTranslator.FromHtml("#d09cd9");
            buttonViewReviews.BackColor = ColorTranslator.FromHtml("#d09cd9");
            buttonAddReview.BackColor = ColorTranslator.FromHtml("#d09cd9");
            label_jobTitle.Text = loggedEmp.type.ToString();
            label_userName.Text = loggedEmp.username;
            this.Size = new Size(350, 1200);
        }

        private void buttonViewBugs_Click(object sender, EventArgs e)
        {
            BugList bugListWindow = new BugList(loggedEmp, loginCntrl, bugCntrl);
            this.Hide();
            bugListWindow.Show();
        }

        private void buttonFixBug_Click(object sender, EventArgs e)
        {
            FixBug fixBugWindow = new FixBug(loggedEmp, loginCntrl, bugCntrl);
            this.Hide();
            fixBugWindow.Show();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Login loginWindow = new Login(loginCntrl);
            this.Hide();
            loginWindow.Show();
        }

        private void buttonViewReviews_Click(object sender, EventArgs e)
        {
            ViewReviews reviewsListWindow = new ViewReviews(loggedEmp, loginCntrl, reviewCntrl);
            this.Hide();
            reviewsListWindow.Show();
        }

        private void buttonAddReview_Click(object sender, EventArgs e)
        {
            AddReview addReviewWindow = new AddReview(loggedEmp, loginCntrl, reviewCntrl);
            this.Hide();
            addReviewWindow.Show();
        }

        private void buttonChat_Click(object sender, EventArgs e)
        {
            Chat chatWindow = new Chat(loggedEmp, loginCntrl, msgCntrl, "programmer");
            this.Hide();
            chatWindow.Show();
        }
    }
}
