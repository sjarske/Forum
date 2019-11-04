using DAL;
using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class UserLogic
    {
        private readonly IUserContext _context;

        public UserLogic()
        {
            _context = new UserSQLContext();
        }

        public void Register(User user)
        {
            _context.Register(user);
        }

        public bool Login(User user)
        {
            return _context.Login(user);
        }

        public User GetUser(User user)
        {
            return _context.GetUser(user);
        }

        public IEnumerable<string> GetUserRoles(User user)
        {
            return _context.GetUserRoles(user);
        }

    }
}
