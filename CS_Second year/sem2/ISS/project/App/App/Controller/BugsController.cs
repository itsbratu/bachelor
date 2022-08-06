using App.Model;
using App.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using static App.Utils.Enums.Enums;

namespace App.Controller
{
    class BugsController
    {
        BugRepository bugRepository;
        CodeRepository codeRepository;
        UsersRepository usersRepository;
        public BugsController()
        {
            bugRepository = new BugRepository();
            codeRepository = new CodeRepository();
            usersRepository = new UsersRepository();
        }

        public IList<int> GetCodeIds()
        {
            IList<int> CodeIDs = new List<int>();
            foreach(Code c in codeRepository.GetAll())
            {
                CodeIDs.Add(c.id);
            }
            return CodeIDs;
        }
        public IList<Bug> GetBugs(string LoggedUsername, bool CurrentUser)
        {
            return bugRepository.GetAll().Where(e => CurrentUser ? e.code.user.username == LoggedUsername : e.code.user.username != LoggedUsername).ToList();
        }

        public void AddBug(int id_code, string username_tester, string description, SeverityStatus status)
        {
            User tester = usersRepository.FindByID(username_tester);
            foreach(Code c in codeRepository.GetAll())
            {
                if(c.id == id_code)
                {
                    Code bugCode = new Code(c.id, c.description, c.functionality, c.addeddate, c.user);
                    Bug bug = new Bug(0, description, status, tester, bugCode);
                    bugRepository.Add(bug);
                    break;
                }
            }

        }

        public void DeleteBug(int id_bug)
        {
            bugRepository.Delete(id_bug);
        }
    }
}
