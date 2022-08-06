using System;

namespace App.Model
{
    class Message
    {
        private int ID;
        private string Content;
        private DateTime SendDate;
        private User Sender;
        private User Receiver;
        private Bug Bug;

        public int id
        {
            get { return ID; }
            set { ID = value; }
        }
        public string content
        {
            get { return Content; }
            set { Content = value; }
        }

        public DateTime sendDate
        {
            get { return SendDate; }
            set { SendDate = value; }
        }

        public User sender
        {
            get { return Sender; }
            set { Sender = value; }
        }

        public User receiver
        {
            get { return Receiver; }
            set { Receiver = value; }
        }

        public Bug bug
        {
            get { return Bug; }
            set { Bug = value; }
        }

        public Message(int id, string content, DateTime sendDate, User sender, User receiver, Bug bug)
        {
            ID = id;
            Content = content;
            SendDate = sendDate;
            Sender = sender;
            Receiver = receiver;
            Bug = bug;
        }
        public Message()
        {

        }
        public override string ToString()
        {
            return " ID = " + ID + "\n" +
                " Content = " + Content + "\n" +
                " SendDate = " + SendDate + "\n" +
                " Sender =  " + Sender.ToString() + "\n" +
                " Receiver = " + Receiver.ToString() + "\n" + 
                " Bug = " + Bug.ToString();
        }

    }
}
