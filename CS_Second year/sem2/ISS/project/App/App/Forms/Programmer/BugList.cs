using App.Controller;
using App.Model;
using App.Programmer;
using App.Utils.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace App.Forms.Programmer
{
    partial class BugList : Form
    {
        private LoggedEmployeeDTO loggedEmp;
        private LoginController loginCntrl;
        private BugsController bugCntrl;
        private IList<Bug> currentBugs;
        public BugList(LoggedEmployeeDTO emp, LoginController controllerLogin, BugsController controllerBug)
        {
            loggedEmp = emp;
            loginCntrl = controllerLogin;
            bugCntrl = controllerBug;
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            ProgrammerMain programmerMain = new ProgrammerMain(loggedEmp, loginCntrl);
            this.Hide();
            programmerMain.Show();
        }

        private void PopulateGridView()
        {
            IList<BugViewDTO> viewBugs = new List<BugViewDTO>();
            foreach(Bug b in currentBugs)
            {
                viewBugs.Add(new BugViewDTO(b.id, b.code.id, b.tester.username, b.severity));
            }
            viewEntities.DataSource = viewBugs;
        }

        private void StyleGridView()
        {
            viewEntities.DefaultCellStyle.Alignment = (DataGridViewContentAlignment)HorizontalAlignment.Left;
            viewEntities.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#d09cd9");
            viewEntities.EnableHeadersVisualStyles = false;
            viewEntities.RowHeadersVisible = false;
            viewEntities.Columns["id_bug"].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#c069cf");
            viewEntities.Columns["id_code"].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#c069cf");
            viewEntities.Columns["username_tester"].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#c069cf");
            viewEntities.Columns["severity"].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#c069cf");
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
            viewEntities.Columns[0].HeaderText = "Id Bug";
            viewEntities.Columns[1].HeaderCell.Style.Font = new Font("Sans", 10, FontStyle.Bold);
            viewEntities.Columns[1].HeaderText = "Id Code";
            viewEntities.Columns[2].HeaderCell.Style.Font = new Font("Sans", 10, FontStyle.Bold);
            viewEntities.Columns[2].HeaderText = "Username Tester";
            viewEntities.Columns[3].HeaderCell.Style.Font = new Font("Sans", 10, FontStyle.Bold);
            viewEntities.Columns[3].HeaderText = "Severity";

            viewEntities.Columns[0].Width = 90;
            viewEntities.Columns[1].Width = 90;
            viewEntities.Columns[2].Width = 110;
            viewEntities.Columns[3].Width = 90;
            textBoxBugInfo.Font = new Font("Sans", 16);
            textBoxBugInfo.BackColor = ColorTranslator.FromHtml("#d09cd9");
        }

        private void BugList_Load(object sender, EventArgs e)
        {
            buttonBack.BackColor = ColorTranslator.FromHtml("#d09cd9");
            currentBugs = bugCntrl.GetBugs(loggedEmp.username, true);
            PopulateGridView();
            StyleGridView();
        }

        private string FormatBugInfo(int id_bug)
        {
            string BugInfo = "";
            foreach(Bug b in currentBugs)
            {
                if(b.id == id_bug)
                {
                    BugInfo += "Bug description : " + Environment.NewLine + b.description + Environment.NewLine;
                    BugInfo += Environment.NewLine + "Code for the bug : " + Environment.NewLine + b.code.ToString();
                }
            }
            return BugInfo;
        }

        private void viewEntities_SelectionChanged(object sender, EventArgs e)
        {
            if (viewEntities.SelectedCells.Count > 0)
            {
                int selectedrowindex = viewEntities.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = viewEntities.Rows[selectedrowindex];
                int selectedBugID = (int)selectedRow.Cells["id_bug"].Value;
                textBoxBugInfo.Text = FormatBugInfo(selectedBugID);
            }
        }
    }
}
