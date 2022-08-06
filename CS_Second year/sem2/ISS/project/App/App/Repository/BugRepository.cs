using App.Model;
using App.Utils;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static App.Utils.Enums.Enums;

namespace App.Repository
{
    class BugRepository : IRepository<Bug, int>
    {
        public void Add(Bug elem)
        {
            using (IDbConnection connection = new SqlConnection(AppConnection.ConnectionString))
            {
                var sqlInsertBugCommand = "INSERT INTO Bug (Description,Severity,Username_tester,Id_code) VALUES (@description,@severity,@username_tester,@id_code)";
                connection.Execute(sqlInsertBugCommand, new { description = elem.description, severity = elem.severity, username_tester = elem.tester.username, id_code = elem.code.id });
            }
        }
        public void Delete(int idBug)
        {
            var sqlDeleteBugCommand = "DELETE FROM Bug WHERE Id = @id";
            using (IDbConnection connection = new SqlConnection(AppConnection.ConnectionString))
            {
                connection.Execute(sqlDeleteBugCommand, new { id = idBug });
            }
        }

        public IList<Bug> GetAll()
        {
            using (IDbConnection connection = new SqlConnection(AppConnection.ConnectionString))
            {
                connection.Open();
                var querry = @"SELECT * FROM Bug B
                    LEFT JOIN Employee E_Tester ON B.Username_tester = E_Tester.Username 
                    LEFT JOIN Code C ON B.Id_code = C.Id
                    LEFT JOIN Employee E_Programmer ON C.Username_programmer = E_Programmer.Username
                    ";
                IList<Bug> bugs = (IList<Bug>)connection.Query<Bug, User, Code, User, Bug>(querry, (b, t, c, p) =>
                {
                    b.tester = t;
                    b.code = c;
                    b.code.user = p;
                    return b;
                }, splitOn: "Id, Username, Id, Username");

                return bugs;
            }
        }
        public void Update(Bug elem)
        {
            throw new System.NotImplementedException();
        }

        public Bug FindByID(int id)
        {
            using (IDbConnection connection = new SqlConnection(AppConnection.ConnectionString))
            {
                connection.Open();
                UsersRepository usersRepo = new UsersRepository();
                CodeRepository codeRepo = new CodeRepository();
                using (var comm = connection.CreateCommand())
                {
                    comm.CommandText = "SELECT * FROM Bug WHERE Id=@id";
                    IDbDataParameter paramId = comm.CreateParameter();
                    paramId.ParameterName = "@id";
                    paramId.Value = id;
                    comm.Parameters.Add(paramId);
                    using (var dataR = comm.ExecuteReader())
                    {
                        if (dataR.Read())
                        {
                            int idBug = dataR.GetInt32(0);
                            string content = dataR.GetString(1);
                            string severity = dataR.GetString(2);
                            string usernameTester = dataR.GetString(3);
                            int idCode = dataR.GetInt32(4);
                            Bug foundBug = new Bug(idBug, content, SeverityStatus.Light, usersRepo.FindByID(usernameTester), codeRepo.FindByID(idCode));
                            return foundBug;
                        }
                    }
                }
                return null;
            }
        }
    }
}
