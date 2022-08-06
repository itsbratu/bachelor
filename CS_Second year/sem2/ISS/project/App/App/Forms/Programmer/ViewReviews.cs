using App.Controller;
using App.Forms.Programmer;
using App.Model;
using App.Utils.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace App.Programmer
{
    partial class ViewReviews : Form
    {
        private LoggedEmployeeDTO loggedEmp;
        private LoginController loginCntrl;
        private ReviewsController reviewCntrl;
        private IList<Review> currentReviews;
        public ViewReviews(LoggedEmployeeDTO emp, LoginController login_controller, ReviewsController review_controller)
        {
            InitializeComponent();
            loggedEmp = emp;
            loginCntrl = login_controller;
            reviewCntrl = review_controller;
        }

        private void PopulateGridView()
        {
            IList<ReviewViewDTO> viewReviews = new List<ReviewViewDTO>();
            foreach (Review r in currentReviews)
            {
                viewReviews.Add(new ReviewViewDTO(r.id, r.code.id, r.programmer.username, r.quality));
            }
            viewEntities.DataSource = viewReviews;
        }

        private void StyleGridView()
        {
            viewEntities.DefaultCellStyle.Alignment = (DataGridViewContentAlignment)HorizontalAlignment.Left;
            viewEntities.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#d09cd9");
            viewEntities.EnableHeadersVisualStyles = false;
            viewEntities.RowHeadersVisible = false;
            viewEntities.Columns["id_review"].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#c069cf");
            viewEntities.Columns["id_code"].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#c069cf");
            viewEntities.Columns["username_reviewer"].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#c069cf");
            viewEntities.Columns["quality"].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#c069cf");
            viewEntities.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
            viewEntities.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
            viewEntities.AdvancedCellBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            viewEntities.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            viewEntities.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            viewEntities.BorderStyle = BorderStyle.None;

            viewEntities.Columns[0].DefaultCellStyle.Font = new Font("Sans", 8);
            viewEntities.Columns[1].DefaultCellStyle.Font = new Font("Sans", 8);
            viewEntities.Columns[2].DefaultCellStyle.Font = new Font("Sans", 8);
            viewEntities.Columns[3].DefaultCellStyle.Font = new Font("Sans", 8);
            viewEntities.Columns[0].HeaderCell.Style.Font = new Font("Sans", 10, FontStyle.Bold);
            viewEntities.Columns[0].HeaderText = "Id Review";
            viewEntities.Columns[1].HeaderCell.Style.Font = new Font("Sans", 10, FontStyle.Bold);
            viewEntities.Columns[1].HeaderText = "Id Code";
            viewEntities.Columns[2].HeaderCell.Style.Font = new Font("Sans", 10, FontStyle.Bold);
            viewEntities.Columns[2].HeaderText = "Username Reviewer";
            viewEntities.Columns[3].HeaderCell.Style.Font = new Font("Sans", 10, FontStyle.Bold);
            viewEntities.Columns[3].HeaderText = "Quality";

            viewEntities.Columns[0].Width = 90;
            viewEntities.Columns[1].Width = 90;
            viewEntities.Columns[2].Width = 110;
            viewEntities.Columns[3].Width = 90;
            textBoxContent.Font = new Font("Sans", 16);
            textBoxContent.BackColor = ColorTranslator.FromHtml("#d09cd9");
        }

        private void backButton_Click(object sender, System.EventArgs e)
        {
            ProgrammerMain programmerMain = new ProgrammerMain(loggedEmp, loginCntrl);
            this.Hide();
            programmerMain.Show();
        }

        private void ViewReviews_Load(object sender, System.EventArgs e)
        {
            backButton.BackColor = ColorTranslator.FromHtml("#d09cd9");
            textBoxContent.BackColor = ColorTranslator.FromHtml("#d09cd9");
            currentReviews = reviewCntrl.GetReviews(loggedEmp.username);
            PopulateGridView();
            StyleGridView();
        }

        private string FormatReviewInfo(int id_review)
        {
            string ReviewInfo = "";
            foreach (Review r in currentReviews)
            {
                if (r.id == id_review)
                {
                    ReviewInfo += "Review description : " + Environment.NewLine + r.description + Environment.NewLine;
                    ReviewInfo += Environment.NewLine + "Quality of the code : " + Environment.NewLine + r.quality;
                    ReviewInfo += Environment.NewLine + "Code for the bug : " + Environment.NewLine + r.code.ToString();
                }
            }
            return ReviewInfo;
        }

        private void viewEntities_SelectionChanged(object sender, System.EventArgs e)
        {
            if (viewEntities.SelectedCells.Count > 0)
            {
                int selectedrowindex = viewEntities.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = viewEntities.Rows[selectedrowindex];
                int selectedReviewId = (int)selectedRow.Cells["id_review"].Value;
                textBoxContent.Text = FormatReviewInfo(selectedReviewId);
            }
        }
    }
}
