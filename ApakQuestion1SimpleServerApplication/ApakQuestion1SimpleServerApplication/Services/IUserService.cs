using ApakQuestion1SimpleServerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApakQuestion1SimpleServerApplication.Services
{
    public interface IUserService
    {
        User GetUser(int id);
        User SaveUser(User user);
        void DeleteUser(int id);
    }
}
