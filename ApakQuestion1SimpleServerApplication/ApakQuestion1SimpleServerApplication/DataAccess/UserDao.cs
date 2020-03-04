using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ApakQuestion1SimpleServerApplication.Models;
using ApakQuestion1SimpleServerApplication.Utils;

namespace ApakQuestion1SimpleServerApplication.DataAccess
{
    public class UserDao : IUserDao
    {
        private const string USER_PERSISTENCE_FILEPATH = "users.csv";

        public User Get(int id)
        {
            if(id <= 0)
            {
                return null;
            }

            string[] usersCsv = CsvUtil.readAllLinesFromFile(USER_PERSISTENCE_FILEPATH);
            
            foreach(var userCsv in usersCsv)
            {
                User user = mapCsvStringToUser(userCsv);
                
                if(user != null && user.Id == id)
                {
                    return user;
                }
            }

            return null;
        }

        public User Insert(User user)
        {
            string[] usersCsv = CsvUtil.readAllLinesFromFile(USER_PERSISTENCE_FILEPATH);

            if(usersCsv.Length > 0)
            {
                // Grab last id and set +1
                user.Id = int.Parse(usersCsv[usersCsv.Length - 1].Split(",")[0]) + 1;
            }
            else
            {
                user.Id = 1;
            }

            CsvUtil.appendObjectToFile(USER_PERSISTENCE_FILEPATH, user);
            
            return user;
        }

        public void Delete(int id)
        {
            CsvUtil.deleteRowFromFile(USER_PERSISTENCE_FILEPATH, id);
        }
        
        private User mapCsvStringToUser(string userCsv)
        {
            Match match = new Regex(@"(?:\[(.+)?\],|(.+?)[,]|(.+)?$)").Match(userCsv);

            List<string> fields = new List<string>();

            while(match.Success)
            {
                for(int i = 1; i <= 3; i++)
                {
                    if (match.Groups[i].Captures.Count == 1)
                    {
                        fields.Add(match.Groups[i].Captures[0].Value);
                    }
                }
                
                match = match.NextMatch();
            }

            if(fields.Count != 8)
            {
                // CSV is incorrectly formatted. Cannot map to User.
                return null;
            }

            User user = new User();
            user.Id = int.Parse(fields[0]);
            user.Name = fields[1];
            user.Username = fields[2];
            user.Interests = String.IsNullOrEmpty(fields[3]) ? null : fields[3].Split(",").ToList();

            UserRequestInfo userRequestInfo = new UserRequestInfo();
            userRequestInfo.Date = fields[4];
            userRequestInfo.Time = fields[5];
            userRequestInfo.DeviceName = fields[6];
            userRequestInfo.IpAddress = fields[7];

            user.UserRequestInfo = userRequestInfo;
            
            return user; 
        }
    }
}
