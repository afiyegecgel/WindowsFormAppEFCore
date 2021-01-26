using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormAppEFCore.Services
{
     class LoginServices
    {
        string defaultusername = "admin";
        string defaultpassword = "12345";
        
        public bool IsLoginSuccess(string username, string password)
        {
            if(username==defaultusername && password == defaultpassword)
            {
                return true;
            }
            return false;
        }
       
    }
}
