using ApakQuestion1SimpleServerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApakQuestion1SimpleServerApplication.DataAccess
{
    public interface IUserDao
    {
        User Get(int id);
        User Insert(User user);
        void Delete(int id);
    }
}
