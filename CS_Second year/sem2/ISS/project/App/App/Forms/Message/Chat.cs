using App.Controller;
using App.Forms.Programmer;
using App.Model;
using App.Tester;
using App.Utils.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static App.Utils.Enums.Enums;

namespace App.Forms.Message
{
    partial class Chat : Form
    {
        private LoggedEmployeeDTO loggedEmp;
        private LoginController loginCntrl;
        private MessagesController msgCntrl;
        private IList<Model.Message> currentMsgs;
        private string userType;
        public Chat(LoggedEmployeeDTO emp, LoginController login_controller, MessagesController msg_controller, string type)
        {
            InitializeComponent();
            loggedEmp = emp;
            loginCntrl = login_controller;
            msgCntrl = msg_controller;
            userType = type;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (loggedEmp.type == EmployeeType.Programmer)
            {
                ProgrammerMain programmerMain = new ProgrammerMain(loggedEmp, loginCntrl);
                this.Hide();
                programmerMain.Show();
            }
            else
            {
                TesterMain testerMain = new TesterMain(loggedEmp, loginCntrl);
                this.Hide();
                testerMain.Show();
            }
        }
        private string padText(string text, int numberOfSpaces)
        {
            string newText = "";
            for (int i = 0; i < numberOfSpaces; i++)
            {
                newText += " ";
            }
            return newText + text;
        }

        private string getReceiverUsername(int idBugSelected)
        {
            List<Model.Message> messages = msgCntrl.GetMessages().Where(e => e.bug.id == idBugSelected).ToList();
            if(messages[0].sender.username == loggedEmp.username)
            {
                return messages[0].receiver.username;
            }
            else
            {
                return messages[0].sender.username;
            }
        }

        private void renderMessages(int idBugSelected)
        {
            List<Model.Message> messages = msgCntrl.GetMessages().Where(e => e.bug.id == idBugSelected).ToList();
            string paddedText = "NO MESSAGES FOUND!";
            int paddedValue = 20;
            if (messages.Count == 0)
            {
                textBoxContent.Font = new Font("Arial", 20);
                string emptyMessage = padText(paddedText, paddedValue);
                textBoxContent.AppendText(emptyMessage);
            }
            else
            {
                textBoxContent.Text = "";
                string userChatName = "";
                if (messages[0].sender.username == loggedEmp.username)
                {
                    userChatName = messages[0].receiver.firstname + " " + messages[0].receiver.lastname;
                }
                else
                {
                    userChatName = messages[0].sender.firstname + " " + messages[0].sender.lastname;
                }
                paddedText = userChatName;
                paddedValue = 48;
                textBoxContent.AppendText(padText(paddedText, paddedValue));
                textBoxContent.Font = new Font("Arial", 14);
                textBoxContent.AppendText(Environment.NewLine);
                foreach (Model.Message m in messages)
                {
                    if (m.sender.username == loggedEmp.username)
                    {
                        paddedText = " ";
                        paddedValue = 50;
                        string currentMessage = Environment.NewLine + padText(paddedText, paddedValue);
                        bool resetLine = false;
                        for (int i = 0; i < m.content.Length; i++)
                        {
                            char currentChar = m.content[i];
                            currentMessage += currentChar;
                            if (i != 0 && i % 30 == 0)
                            {
                                resetLine = true;
                            }
                            if(resetLine == true && Char.IsWhiteSpace(currentChar))
                            {
                                paddedText = " ";
                                paddedValue = 70;
                                currentMessage += padText(paddedText, paddedValue);
                                resetLine = false;
                            }
                        }
                        paddedText = "(" + m.sendDate.ToString("yyyy/dd/MM HH:mm") + ")";
                        paddedValue = 51;
                        currentMessage += Environment.NewLine + padText(paddedText, paddedValue) + Environment.NewLine;
                        textBoxContent.AppendText(currentMessage);
                    }
                    else
                    {
                        string currentMessage = Environment.NewLine + padText(" ", 3);
                        bool resetLine = false;
                        for (int i = 0; i < m.content.Length; i++)
                        {
                            char currentChar = m.content[i];
                            currentMessage += currentChar;
                            if (i != 0 && i % 20 == 0)
                            {
                                resetLine = true;
                            }
                            if (resetLine == true && Char.IsWhiteSpace(currentChar))
                            {
                                paddedText = Environment.NewLine + " ";
                                paddedValue = 5;
                                currentMessage += padText(paddedText, paddedValue);
                                resetLine = false;
                            }
                        }
                        paddedText = "(" + m.sendDate.ToString("yyyy/dd/MM HH:mm") + ")";
                        paddedValue = 3;
                        currentMessage += Environment.NewLine + padText(paddedText, paddedValue) + Environment.NewLine;
                        textBoxContent.AppendText(currentMessage);
                    }
                    
                }
            }
        }

        private void fetchBugsIds()
        {
            foreach (int bugId in msgCntrl.GetBugsIds(loggedEmp.username, true, userType))
            {
                comboBoxIdBug.Items.Add(bugId);
            }

            if (comboBoxIdBug.Items.Count != 0)
            {
                comboBoxIdBug.SelectedItem = comboBoxIdBug.Items[0];
                renderMessages((int)comboBoxIdBug.Items[0]);
            }
            else
            {
                sendButton.Enabled = false;
            }
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            backButton.BackColor = ColorTranslator.FromHtml("#d09cd9");
            comboBoxIdBug.BackColor = ColorTranslator.FromHtml("#d09cd9");
            textBoxContent.BackColor = ColorTranslator.FromHtml("#d09cd9");
            textBoxContent.ReadOnly = true;
            sendButton.BackColor = ColorTranslator.FromHtml("#d09cd9");
            textBoxMsg.BackColor = ColorTranslator.FromHtml("#d09cd9");
            fetchBugsIds();
            textBoxContent.ScrollBars = ScrollBars.Vertical;
            this.Size = new Size(759, 975);
        }
        private void comboBoxIdBug_SelectionChangeCommitted(object sender, EventArgs e)
        {
            textBoxContent.Text = "";
            int idBugSelected = (int)comboBoxIdBug.SelectedItem;
            renderMessages(idBugSelected);

        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if(textBoxMsg.TextLength == 0)
            {
                MessageBox.Show("Message cannot be empty!");
                textBoxMsg.Text = "";
            }
            else
            {
                string content = textBoxMsg.Text;
                int idBugSelected = (int)comboBoxIdBug.SelectedItem;
                DateTime sendDate = DateTime.Now;
                string senderUsername = loggedEmp.username;
                string receiverUsername = getReceiverUsername(idBugSelected);
                msgCntrl.SaveMessage(content, sendDate, senderUsername, receiverUsername, idBugSelected);
                textBoxMsg.Text = "";
                textBoxContent.ScrollToCaret();
                renderMessages(idBugSelected);
            }
        }
    }
}
