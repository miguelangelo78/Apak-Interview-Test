using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApakQuestion1SimpleServerApplication.Services
{
    public interface IUserLookup
    {
        string GetLocation(int id);
    }
}
