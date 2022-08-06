using App.Model;
using App.Utils;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace App.Repository
{
    class ReviewRepository : IRepository<Review, int>
    {
        public void Add(Review elem)
        {
            using (IDbConnection connection = new SqlConnection(AppConnection.ConnectionString))
            {
                var sqlInsertReviewCommand = "INSERT INTO Review (Description,Quality,Username_programmer,Id_code) VALUES (@description,@quality,@username_programmer,@id_code)";
                connection.Execute(sqlInsertReviewCommand, new { description = elem.description, quality = elem.quality, username_programmer = elem.programmer.username, id_code = elem.code.id });
            }
        }
        public IList<Review> GetAll()
        {
            using (IDbConnection connection = new SqlConnection(AppConnection.ConnectionString))
            {
                connection.Open();
                var querry = @"SELECT * FROM Review R 
                               LEFT JOIN Employee E_Reviewer ON R.Username_programmer = E_Reviewer.Username 
                               LEFT JOIN Code C ON R.Id_code = C.Id
                               LEFT JOIN Employee E_Coder ON C.Username_programmer = E_coder.Username";
                IList<Review> reviews = (IList<Review>)connection.Query<Review, User, Code, User, Review>(querry, (r, rev, code, u) =>
                {
                    r.programmer = rev;
                    r.code = code;
                    r.code.user = u;
                    return r;
                }, splitOn: "Id, Username, Id, Username");
                return reviews;
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Review elem)
        {
            throw new NotImplementedException();
        }

        public Review FindByID(int id)
        {
            throw new NotImplementedException();
        }

    }
}
