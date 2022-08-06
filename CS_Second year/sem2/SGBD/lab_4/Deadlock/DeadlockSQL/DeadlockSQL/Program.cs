using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab4_sgbd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server = IONUWORKSPACE\SQLEXPRESS; Initial Catalog = CarSharing; Integrated Security = true;";

            Thread thread1 = new Thread(() => Func1(connectionString));
            Thread thread2 = new Thread(() => Func2(connectionString));

            thread1.Start();
            thread2.Start();
        }


        public static void Func1(string connection)
        {
            int count = 0;
            int maxRetries = 5;
            while (count < maxRetries)
            {
                try
                {
                    Console.WriteLine("In trans 1: ");
                    using (var conn = new SqlConnection(connection))
                         
                    using (var command = new SqlCommand("trans1_deadlock_initial", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                    break;
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Number);
                    if (e.Number == 1205)  // SQL Server error code for deadlock
                    {
                        count++;
                        Console.WriteLine("Deadlock 1");
                    }
                    else
                    {
                        Console.WriteLine("Not a deadlock");
                        throw;  // Not a deadlock so throw the exception
                    }
                }
            }
        }
        public static void Func2(string connection)
        {
            int count = 0;
            int maxCount = 5;
            while (count < maxCount)
            {
                try
                {
                    Console.WriteLine("In trans 2: ");
                    using (var conn = new SqlConnection(connection))

                    using (var command = new SqlCommand("trans2_deadlock_initial", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                    break;

                }
                catch (SqlException e)
                {

                    if (e.Number == 1205)  // SQL Server error code for deadlock
                    {
                        count++;
                        Console.WriteLine("Deadlock 2");
                    }
                    else
                    {
                        Console.WriteLine("Not a deadlock");
                        throw;  // Not a deadlock so throw the exception
                    }
                }
            }

        }
    }
}


