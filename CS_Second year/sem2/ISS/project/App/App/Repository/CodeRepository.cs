using App.Model;
using App.Utils;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace App.Repository
{
    class CodeRepository : IRepository<Code, int>
    {
        public IList<Code> GetAll()
        {
            using (IDbConnection connection = new SqlConnection(AppConnection.ConnectionString))
            {
                connection.Open();
                var querry = @"SELECT * FROM Code C LEFT JOIN Employee E ON C.Username_programmer = E.Username";
                IList<Code> Code = (IList<Code>)connection.Query<Code, User, Code>(querry, (c, u) =>
                {
                    c.user = u;
                    return c;
                }, splitOn: "Id, Username");
                return Code;
            }
        }
        public void Add(Code elem)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Code FindByID(int id)
        {
            using (IDbConnection connection = new SqlConnection(AppConnection.ConnectionString))
            {
                connection.Open();
                UsersRepository usersRepo = new UsersRepository();
                using (var comm = connection.CreateCommand())
                {
                    comm.CommandText = "SELECT * FROM Code WHERE Id=@id";
                    IDbDataParameter paramId = comm.CreateParameter();
                    paramId.ParameterName = "@id";
                    paramId.Value = id;
                    comm.Parameters.Add(paramId);
                    using (var dataR = comm.ExecuteReader())
                    {
                        if (dataR.Read())
                        {
                            int idCode = dataR.GetInt32(0);
                            string description = dataR.GetString(1);
                            string functionality = dataR.GetString(2);
                            DateTime dateCode = dataR.GetDateTime(3);
                            string usernameProgrammer = dataR.GetString(4);
                            Code foundCode = new Code(idCode, description, Utils.Enums.Enums.Functionality.Login, dateCode, usersRepo.FindByID(usernameProgrammer));
                            return foundCode;
                        }
                    }
                }
                return null;
            }
        }
        public void Update(Code elem)
        {
            throw new System.NotImplementedException();
        }
    }
}
