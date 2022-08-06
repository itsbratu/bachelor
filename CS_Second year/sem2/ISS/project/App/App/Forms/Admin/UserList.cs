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


namespace App
{
    partial class UserList : Form
    {
        private LoggedEmployeeDTO loggedEmp;
        private LoginController loginCntrl;
        private UsersController usersCntrl;
        public UserList(LoggedEmployeeDTO emp, LoginController login_controller, UsersController users_controller)
        {
            loggedEmp = emp;
            loginCntrl = login_controller;
            usersCntrl = users_controller;
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            AdminMain adminMain = new AdminMain(loggedEmp, loginCntrl);
            this.Hide();
            adminMain.Show();
        }

        private void UserList_Load(object sender, EventArgs e)
        {
            viewEntities.DataSource = usersCntrl.GetEmployees();
            viewEntities.DefaultCellStyle.Alignment = (DataGridViewContentAlignment)HorizontalAlignment.Left;
            viewEntities.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#d09cd9");
            viewEntities.EnableHeadersVisualStyles = false;
            viewEntities.Columns["username"].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#c069cf");
            viewEntities.Columns["password"].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#c069cf");
            viewEntities.Columns["firstname"].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#c069cf");
            viewEntities.Columns["lastname"].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#c069cf");
            viewEntities.Columns["type"].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#c069cf");
            viewEntities.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
            viewEntities.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
            viewEntities.AdvancedCellBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            viewEntities.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            viewEntities.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            viewEntities.BorderStyle = BorderStyle.None;
            backButton.BackColor = ColorTranslator.FromHtml("#d09cd9");

            viewEntities.Columns[0].DefaultCellStyle.Font = new Font("Sans", 13);
            viewEntities.Columns[1].DefaultCellStyle.Font = new Font("Sans", 13);
            viewEntities.Columns[2].DefaultCellStyle.Font = new Font("Sans", 13);
            viewEntities.Columns[3].DefaultCellStyle.Font = new Font("Sans", 13);
            viewEntities.Columns[4].DefaultCellStyle.Font = new Font("Sans", 13);
            viewEntities.Columns[0].HeaderCell.Style.Font = new Font("Sans", 15, FontStyle.Bold);
            viewEntities.Columns[0].HeaderText = "Username";
            viewEntities.Columns[1].HeaderCell.Style.Font = new Font("Sans", 15, FontStyle.Bold);
            viewEntities.Columns[1].HeaderText = "Password";
            viewEntities.Columns[2].HeaderCell.Style.Font = new Font("Sans", 15, FontStyle.Bold);
            viewEntities.Columns[2].HeaderText = "First name";
            viewEntities.Columns[3].HeaderCell.Style.Font = new Font("Sans", 15, FontStyle.Bold);
            viewEntities.Columns[3].HeaderText = "Last name";
            viewEntities.Columns[4].HeaderCell.Style.Font = new Font("Sans", 15, FontStyle.Bold);
            viewEntities.Columns[4].HeaderText = "Type";

            viewEntities.Columns[0].Width = 160;
            viewEntities.Columns[1].Width = 160;
            viewEntities.Columns[2].Width = 160;
            viewEntities.Columns[3].Width = 160;
            viewEntities.Columns[4].Width = 160;

        }
    }
}
