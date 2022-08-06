using App.Model;
using App.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Controller
{
    class MessagesController
    {
        MessageRepository msgRepo;
        BugRepository bugsRepo;
        UsersRepository usersRepo;

        public MessagesController()
        {
            msgRepo = new MessageRepository();
            bugsRepo = new BugRepository();
            usersRepo = new UsersRepository();
        }

        public IList<int> GetBugsIds(string LoggedUsername, bool CurrentUser, string type)
        {
            IList<int> BugsIds = new List<int>();
            if(type == "programmer")
            {
                foreach (Bug b in bugsRepo.GetAll().Where(e => CurrentUser ? e.code.user.username == LoggedUsername : e.code.user.username != LoggedUsername).ToList())
                {
                    BugsIds.Add(b.id);
                }
                return BugsIds;
            }
            else
            {
                foreach (Bug b in bugsRepo.GetAll().Where(e => CurrentUser ? e.tester.username == LoggedUsername : e.tester.username != LoggedUsername).ToList())
                {
                    BugsIds.Add(b.id);
                }
                return BugsIds;
            }

        }

        public void SaveMessage(string content, DateTime date ,string usernameSender, string userNameReceiver, int idBug)
        {
            User sender = usersRepo.FindByID(usernameSender);
            User receiver = usersRepo.FindByID(userNameReceiver);
            Bug bug = bugsRepo.FindByID(idBug);
            Message msg = new Message(0, content, date, sender, receiver, bug);
            msgRepo.Add(msg);
        }
        public IList<Model.Message> GetMessages()
        {
            return msgRepo.GetAll();
        }

    }
}
