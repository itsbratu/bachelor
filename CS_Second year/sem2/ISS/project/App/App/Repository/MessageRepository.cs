using App.Model;
using App.Utils;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace App.Repository
{
    class MessageRepository : IRepository<Message, int>
    {
        public void Add(Message elem)
        {
            using (IDbConnection connection = new SqlConnection(AppConnection.ConnectionString))
            {
                var sqlInsertMessageCommand = "INSERT INTO Message (Message_Content,Message_Date,Sender_username,Receiver_username,Id_bug) VALUES (@message_content,@message_date,@sender_username,@receiver_username,@id_bug)";
                connection.Open();
                connection.Execute(sqlInsertMessageCommand, new { message_content = elem.content, message_date = elem.sendDate, sender_username = elem.sender.username, receiver_username = elem.receiver.username, id_bug = elem.bug.id });
            }
        }

        public IList<Message> GetAll()
        {
            IList<Message> messages = new List<Message>();
            using (IDbConnection connection = new SqlConnection(AppConnection.ConnectionString))
            {
                connection.Open();
                using (var comm = connection.CreateCommand())
                {
                    comm.CommandText = "select * from Message";
                    using (var dataR = comm.ExecuteReader())
                    {
                        UsersRepository usersRepo = new UsersRepository();
                        BugRepository bugsRepo = new BugRepository();
                        while (dataR.Read())
                        {
                            int idMsg = dataR.GetInt32(0);
                            string content = dataR.GetString(1);
                            DateTime date = dataR.GetDateTime(2);
                            User sender = usersRepo.FindByID(dataR.GetString(3));
                            User receiver = usersRepo.FindByID(dataR.GetString(4));
                            int bugId = dataR.GetInt32(5);
                            Bug bugMsg = new Bug(0, "", Utils.Enums.Enums.SeverityStatus.Moderate, new User(), new Code());
                            foreach(Bug b in bugsRepo.GetAll())
                            {
                                if(b.id == bugId)
                                {
                                    bugMsg.id = b.id;
                                    bugMsg.description = b.description;
                                    bugMsg.severity = b.severity;
                                    bugMsg.tester = b.tester;
                                    bugMsg.code = b.code;
                                    break;
                                }
                            }
                            Message msg = new Message(idMsg, content, date, sender, receiver, bugMsg);
                            messages.Add(msg);
                        }
                    }
                }
            }
            return messages;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Message elem)
        {
            throw new NotImplementedException();
        }

        public Message FindByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
