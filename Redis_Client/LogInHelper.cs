using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis_Client
{
    class LogInHelper
    {
        public string LogIn(string username, string password)
        {
            RedisUtil rUtil = new RedisUtil();

            if (rUtil.FindClient(username, password) == false) return "Invalid name or password";
            else return "";
        }

        public string Register(string username, string password, string mail)
        {
            RedisUtil rUtil = new RedisUtil();
            //if (username.Length < 8)
            //{
            //    return "Name is too short";
            //}
            //else if (password.Length < 8)
            //{
            //    return "Password is too short";
            //}
            if (rUtil.IsUsernameExist(username) == true)
            {
                return "This name is already in use. Choose different name";
            }
            else if (rUtil.IsMailExist(mail) == true)
            {
                return "This mail is already in use";
            }
            else
            {
                rUtil.CreateClient(username, password, mail);
            }
            return "";
        }
    }
}
