using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using BookShop.Model;

namespace BookShop.DAL
{
    public class userService
    {
        SqlDBConnect db = new SqlDBConnect();

        /// <summary>
        /// 前台登陆
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>成功失败</returns>
        public string Login(string userName, string password)
        {
            bool isexist = false;
            string sql1 = "select * from [user] where userName='" + userName + "'" +
            " and password='" + password + "'";
            isexist = db.YNExistData(sql1);
            if (isexist){
                System.Web.HttpContext.Current.Session["userName"] = userName;
                return "1";
            }
                
            else
                return "0";
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="sex"></param>
        /// <param name="birth"></param>
        /// <param name="mail"></param>
        /// <param name="realName"></param>
        /// <param name="address"></param>
        /// <param name="telephone"></param>
        /// <returns></returns>
        public string registe(string userName, string password, string sex, string birth,
           string mail, string realName, string address, string telephone)
        {
            bool isexist = false;
            string sql_1 = "select userName from [user] where userName = '" + userName + "'";
            isexist = db.YNExistData(sql_1);
            if (isexist == false)
            {
                string sql1 = "select max(userID) as userid from [user]";
                DataTable dt = db.GetDataTable(sql1);
                int userid = int.Parse(dt.Rows[0][0].ToString());
                userid = userid + 1;

                string sql = "insert into [user](userID,userName, password, sex, birth, email,realName,address, telephone,type,balance)" +
                "values({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')";
                sql = string.Format(sql, userid, userName, password, sex, birth, mail, realName, address, telephone,"普通用户","0");
                db.ExecuteNonQuery(sql);
                return "1";
            }
            else
            {
                return "0";
            }
        }

        /// <summary>
        /// 后台登陆
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string BackLogin(string userName, string password)
        {
            bool isexist = false;
            string sql1 = "select * from [user] where userName='" + userName + "'" +
            " and password='" + password + "'"+" and type='管理员'";
            isexist = db.YNExistData(sql1);
            if (isexist)
            {
                System.Web.HttpContext.Current.Session["userName"] = userName;
                return "1";
            }

            else
                return "0";
        }

        /// <summary>
        /// 根据用户id获取用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        public DataTable ShowUserInfo(string userId)
        {
            string sql = "select * from [user] where userID= '" + userId + "'";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        /// <summary>
        /// 根据用户id获取用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        public DataTable ShowUser(string userName)
        {
            string sql = "select * from [user] where userName= '" + userName + "'";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="usermodel">用户实体</param>
        /// <returns>"1"表示新增成功 "0"表示新增失败</returns>
        public string adduser(user usermodel)
        {
            string sql_1 = "select * from [User] where userName = '" + usermodel.userName + "'";
            bool isExist = db.YNExistData(sql_1);
            if (isExist == false)
            {
                string sql1 = "select max(userID) as userid from [user]";
                DataTable dt = db.GetDataTable(sql1);
                int userid = int.Parse(dt.Rows[0][0].ToString());
                userid = userid + 1;

                string sql = "insert into [User](UserID,userName, realName, password, "+
               " sex, email, telephone ,type ,address ,birth ,balance,age) " +
                      "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')";
                sql = string.Format(sql, userid, usermodel.userName, usermodel.realName, 
                    usermodel.password, usermodel.sex, usermodel.email, usermodel.telephone,
                    "管理员", usermodel.address, usermodel.birth, "0", usermodel.age);
                db.ExecuteNonQuery(sql);
                return "1";
            }
            else
                return "0";
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="usermodel">用户实体</param>
        /// <returns>"1"表示修改成功 "0"表示修改失败</returns>
        public string updateuser(user usermodel)
        {
            string sql_1 = "select * from [User] where userName = '" + usermodel.userName + "'";
            bool isExist = db.YNExistData(sql_1);

            if (isExist)
            {
                string sql = "update [user] set realName = '{0}', password = '{1}', sex = '{2}', email = '{3}', telephone='{4}', age='{5}'" +
                         " where userName= '{6}'";
                sql = string.Format(sql, usermodel.realName, usermodel.password, usermodel.sex, usermodel.email,
                    usermodel.telephone,usermodel.age,usermodel.userName);
                db.ExecuteNonQuery(sql);
                return "1";
            }else 
                return "0";
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <returns>true or false</returns>
        public bool deleteuser(int userid)
        {
            try
            {
                string sql = "delete from [user] where userID = '{0}'";
                sql = string.Format(sql, userid);
                //执行插入
                db.ExecuteNonQuery(sql);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public string search(string userid, string username)
        {
            string sql = "select * from [user] where 1=1";
            if (username != null || username != "" || userid != null || userid != "")
            {
                sql += " and realName like '%" + username + "%' and userID like '%" + userid + "%'";
            }
            return sql;
        }
        /// <summary>
        /// 获取用户表所有数据
        /// </summary>
        /// <returns></returns>
        public string getalluser()
        {
            string sql = "select * from [User]";

            return sql;
        }
       
    }
}
