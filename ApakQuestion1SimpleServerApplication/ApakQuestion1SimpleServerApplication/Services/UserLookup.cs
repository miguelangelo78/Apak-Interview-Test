using ApakQuestion1SimpleServerApplication.Models;
using IpStack;
using IpStack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApakQuestion1SimpleServerApplication.Services
{
    public class UserLookup : IUserLookup
    {
        private const string IP_STACK_KEY = "4962242a1456b78f4bbfef1e8d34ed58";

        private readonly IUserService UserService;

        public UserLookup(IUserService UserService)
        {
            this.UserService = UserService;
        }

        public string GetLocation(int id)
        {
            User user = UserService.GetUser(id);

            if(user == null || user.UserRequestInfo == null || String.IsNullOrEmpty(user.UserRequestInfo.IpAddress))
            {
                return null;
            }

            IpAddressDetails addressDetails = new IpStackClient(IP_STACK_KEY).GetIpAddressDetails(user.UserRequestInfo.IpAddress);

            return String.Format("{0}, {1}, {2}", addressDetails.City, addressDetails.CountryName, addressDetails.ContinentName);
        }
    }
}
