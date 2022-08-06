using App.Repository;
using App.Model;
using System.Collections.Generic;
using App.Utils.DTOs;
using App.Utils.Validators;
using System;
using static App.Utils.Enums.Enums;

namespace App.Controller
{
    class UsersController
    {
        UsersRepository employeeRepository;
        public UsersController()
        {
            employeeRepository = new UsersRepository();
        }
        public void SaveEmployee(string username, string pass, string confirmPass, string firstname , string lastname, EmployeeType type)
        {
            User inputUser = new User(username, pass, firstname, lastname, type);
            UserDTO addUser = new UserDTO(inputUser, confirmPass);
            UserValidator validator = new UserValidator(addUser.user, addUser.confirmpass);
            string ErrorMsg = validator.ValidateUser();
            if(ErrorMsg.Length > 0)
            {
                throw new Exception(ErrorMsg);
            }
            else
            {
                User ExistingUser = employeeRepository.FindByID(addUser.user.username);
                if (ExistingUser == null)
                {
                    employeeRepository.Add(addUser.user);
                }
                else
                {
                    throw new Exception("User already exists!");
                }

            }
        }
        public void UpdateEmployee(string username, string pass, string confirmPass, string firstname, string lastname, EmployeeType type)
        {
            User inputUser = new User(username, pass, firstname, lastname, type);
            UserDTO updatedUser = new UserDTO(inputUser, confirmPass);
            UserValidator validator = new UserValidator(updatedUser.user, updatedUser.confirmpass);
            string ErrorMsg = validator.ValidateUser();
            if (ErrorMsg.Length > 0)
            {
                throw new Exception(ErrorMsg);
            }
            else
            {
                employeeRepository.Update(updatedUser.user);
            }
        }

        public IList<string> GetUsernames()
        {
            IList<string> usernames = new List<string>();
            foreach(User u in GetEmployees())
            {
                usernames.Add(u.username);
            }
            return usernames;
        }

        public void DeleteEmployee(string usernameEmployee)
        {
            employeeRepository.Delete(usernameEmployee);
        }

        public IList<User> GetEmployees()
        {
            return employeeRepository.GetAll();
        }
    }
}
