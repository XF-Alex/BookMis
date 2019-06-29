using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMis
{
     public class UserInfo
    {
        public static Boolean IsCheckIn;            //登录状态
        public static string UID;                   //账号
        public static string LoginTime;             //登录时间
        public static Boolean IsUserAdmin;          //是否拥有用户管理权限
        public static Boolean IsReaderAdmin;        //是否拥有读者管理权限
        public static Boolean IsBookAdmin;          //是否拥有图书权限
        public static Boolean IsBorrowAdmin;        //是否拥有借阅权限

        public static bool judgeUser(string uid, string pwd)
        {
            string sql;
            sql = "SELECT count(*) FROM UserInfo WHERE UserID='" + uid + "' and UserPWD='" + pwd + "'";
            string cnt = AccessDB.GetFieldValue(sql);
            if (cnt == "1")
            {
                return true;
            }
            return false;

        }

        public static bool isExistUser(string uid)
        {
            string cnt = AccessDB.GetFieldValue("SELECT count(*) FROM UserInfo WHERE UserID = '" + uid + "'");
            if (cnt == "1")
            {
                return true;
            }
            return false;
        }

        public static string getPassword(string uid)
        {
            if (isExistUser(uid) == true)
            {
                return AccessDB.GetFieldValue("SELECT UserPWD FROM UserInfo WHERE UserID = '" + uid + "'");
            }
            return "";
        }

        public static Boolean getUserAdmin(string uid)
        {
            if (isExistUser(uid) == true)
            {
                string qx = AccessDB.GetFieldValue("SELECT UserAdmin FROM UserInfo WHERE UserID = '" + uid + "'");
                return Convert.ToBoolean(qx);
            }
            return false;
        }

        public static Boolean getReaderAdmin(string uid)
        {
            if (isExistUser(uid) == true)
            {
                string qx = AccessDB.GetFieldValue("SELECT ReaderAdmin FROM UserInfo WHERE UserID = '" + uid + "'");
                return Convert.ToBoolean(qx);
            }
            return false;
        }

        public static Boolean getBookAdmin(string uid)
        {
            if (isExistUser(uid) == true)
            {
                string qx = AccessDB.GetFieldValue("SELECT BookAdmin FROM UserInfo WHERE UserID = '" + uid + "'");
                return Convert.ToBoolean(qx);
            }
            return false;
        }

        public static Boolean getBorrowAdmin(string uid)
        {
            if (isExistUser(uid) == true)
            {
                string qx = AccessDB.GetFieldValue("SELECT BorrowAdmin FROM UserInfo WHERE UserID = '" + uid + "'");
                return Convert.ToBoolean(qx);
            }
            return false;
        }

        public static bool newUser(string uid, string pwd, string userAdmin, string readerAdmin, string bookAdmin, string borrowAdmin, string regTime)
        {
            if (isExistUser(uid) == false)
            {
                string sql;
                sql = "INSERT INTO UserInfo(UserID,UserPWD,UserAdmin,ReaderAdmin,BookAdmin,BorrowAdmin,RegisterTime)";
                sql += "Values('" + uid + "','" + pwd + "','" + userAdmin + "','" + readerAdmin + "','" + bookAdmin + "','" + borrowAdmin + "','" + regTime + "')";
                AccessDB.ExecSQL(sql);
                return true;
            }
            return false;
        }

        public static bool modifyUser(string uid, string pwd, string userAdmin, string readerAdmin, string bookAdmin, string borrowAdmin)
        {
            if (isExistUser(uid) == true)
            {
                string sql;
                sql = "UPDATE UserInfo SET UserPWD='" + pwd + "',UserAdmin='" + userAdmin + "',ReaderAdmin='" + readerAdmin;
                sql += "',BookAdmin='" + bookAdmin + "',BorrowAdmin='" + borrowAdmin + "' WHERE UserID='" + uid + "'";
                AccessDB.ExecSQL(sql);
                return true;
            }
            return false;
        }

        public static bool deleteUser(string uid)
        {
            if (isExistUser(uid) == true)
            {
                AccessDB.ExecSQL("DELETE FROM UserInfo WHERE UserID='" + uid + "'");
                return true;
            }
            return false;
        }
    }
}
