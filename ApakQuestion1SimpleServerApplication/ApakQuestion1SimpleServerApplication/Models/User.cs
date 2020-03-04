using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApakQuestion1SimpleServerApplication.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public List<String> Interests { get; set; }
        public UserRequestInfo UserRequestInfo { get; set; }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},[{3}],{4}", Id, Name, Username, string.Join(",", Interests), UserRequestInfo.ToString());
        }
    }
}
