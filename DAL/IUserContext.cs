using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUserContext
    {
        void Register(User user);
        bool Login(User user);
        List<string> GetUserRoles(User user);
        User GetUser(User user);
    }
}
