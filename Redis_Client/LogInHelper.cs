using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis_Client
{
    class LogInHelper
    {
        AppError appErr = new AppError();
        public int LogIn(string username, string password)
        {
            ClientUtil rUtil = new ClientUtil();
            if (rUtil.FindClient(username, password) == true) return rUtil.GetId(username);
            else
            {
                appErr.ShowErrorMsg("Invalid username or password");
                return -1;
            }
        }
        public int Register(string username, string password, string mail)
        {
            ClientUtil rUtil = new ClientUtil();
            //if (username.Length < 8)
            //{
            //    appErr.ShowErrorMsg("Name is too short");
            //}
            //else if (password.Length < 8)
            //{
            //    return "Password is too short";
            //}
            if (rUtil.IsUsernameExist(username) == true)
            {
                appErr.ShowErrorMsg("This name is already in use. Choose different name");
            }
            else if (rUtil.IsMailExist(mail) == true)
            {
                appErr.ShowErrorMsg("This mail is already in use");
            }
            else
            {
                rUtil.CreateClient(username, password, mail);
                return rUtil.GetId(username);
            }
            return -1;
        }
    }
}
