using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApakQuestion1SimpleServerApplication.Models
{
    public class UserRequestInfo
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public string DeviceName { get; set; }
        public string IpAddress { get; set; }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3}", Date, Time, DeviceName, IpAddress);
        }
    }
}
