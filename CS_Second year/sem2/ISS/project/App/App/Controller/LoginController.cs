using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Repository;
using App.Model;
using App.Utils.DTOs;

namespace App.Controller
{
    class LoginController
    {
        UsersRepository employeeRepository;

        public LoginController()
        {
            employeeRepository = new UsersRepository();
        }

        public LoggedEmployeeDTO LoginEmployee(string empUsername, string password)
        {
            User emp = employeeRepository.FindByID(empUsername);
            if (emp == null || password != emp.password)
            {
                throw new Exception("Invalid username or password!");
            }
            else
            {
                return new LoggedEmployeeDTO(emp.username, emp.type);
            }
        }

    }
}
