using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.DAL;
using System.Data;
using BookShop.Model;


namespace BookShop.BLL
{
    public class userManage
    {
        userService userservice = new userService();

        public string login(string userName, string password)
        {
            return userservice.Login(userName, password);
        }

        public string backlogin(string userName, string password)
        {
            return userservice.BackLogin(userName, password);
        }

        public string registe(string userName, string password, string sex, string birth,
          string mail, string realName, string address, string telephone)
        {
            return userservice.registe(userName, password, sex, birth, mail, realName, address, telephone);
        }

        public DataTable ShowUserInfo(string userId)
        {
            DataTable dt = userservice.ShowUserInfo(userId);
            return dt;
        }

        public DataTable ShowUser(string userName)
        {
            DataTable dt = userservice.ShowUser(userName);
            return dt;
        }

        public string adduser(user usermodel)
        {
            return userservice.adduser(usermodel);
        }

        public string updateuser(user usermodel)
        {
            return userservice.updateuser(usermodel);
        }

        public bool deleteuser(int userid)
        {
            return userservice.deleteuser(userid);
        }

        public string search(string userid, string username)
        {
            return userservice.search(userid, username);
        }

        public string getalluser()
        {
            return userservice.getalluser();
        }

    }
}
