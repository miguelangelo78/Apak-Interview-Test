using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApakQuestion1SimpleServerApplication.DataAccess;
using ApakQuestion1SimpleServerApplication.Models;
using ApakQuestion1SimpleServerApplication.Utils;

namespace ApakQuestion1SimpleServerApplication.Services
{
    public class UserService : IUserService
    {
        private readonly IUserDao UserDao;

        public UserService(IUserDao UserDao)
        {
            this.UserDao = UserDao;
        }

        public User GetUser(int id)
        {
            return UserDao.Get(id);
        }

        public User SaveUser(User user)
        {
            return UserDao.Insert(user);
        }

        public void DeleteUser(int id)
        {
            UserDao.Delete(id);
        }
    }
}
