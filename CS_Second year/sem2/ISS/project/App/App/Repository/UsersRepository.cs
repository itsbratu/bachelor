using App.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using App.Utils;
using System;

namespace App.Repository
{
    class UsersRepository : IRepository<User, string>
    {
        public void Add(User elem)
        {
            using (IDbConnection connection = new SqlConnection(AppConnection.ConnectionString))
            {
                var sqlInsertUserCommand = "INSERT INTO Employee (Username,Password,FirstName,LastName,Type) VALUES (@username,@password,@firstname,@lastname,@type)";
                connection.Open();
                connection.Execute(sqlInsertUserCommand, new { username = elem.username, password = elem.password, firstname = elem.firstname, lastname = elem.lastname, type = elem.type });
            }
        }
        public void Update(User elem)
        {
            var sqlUpdateUserCommand = "UPDATE Employee SET Password = @password, FirstName = @firstname , LastName = @lastname , Type = @type WHERE Username = @username";
            using (IDbConnection connection = new SqlConnection(AppConnection.ConnectionString))
            {
                connection.Execute(sqlUpdateUserCommand,new { password = elem.password, firstname = elem.firstname, lastname = elem.lastname, type = elem.type, username = elem.username});
            }
        }
        public void Delete(string username)
        {
            var sqlDeleteUserCommand = "DELETE FROM Employee WHERE Username = @username";
            using (IDbConnection connection = new SqlConnection(AppConnection.ConnectionString))
            {
                connection.Execute(sqlDeleteUserCommand, new { username = username });
            }
        }

        public User FindByID(string id)
        {
            var sqlSelectUserCommand = "SELECT Username, Password, FirstName, LastName, Type FROM Employee WHERE Username = @username";
            using (IDbConnection connection = new SqlConnection(AppConnection.ConnectionString))
            {
                IEnumerable<User> emps = connection.Query<User>(sqlSelectUserCommand, new { username = id });
                foreach (User emp in emps)
                {
                    return emp;
                }
                return null;
            }
        }
        public IList<User> GetAll()
        {
            var sqlSelectUsersCommand = "SELECT Username, Password, FirstName, LastName, Type FROM Employee";
            using (IDbConnection connection = new SqlConnection(AppConnection.ConnectionString))
            {
                return (IList<User>)connection.Query<User>(sqlSelectUsersCommand);
            }
        }
    }
}
