using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/// <summary>
/// UserData 的摘要说明
/// </summary>
public class UserData
{
    private const string CHECK_USERNAME = " SELECT * FROM [User] WHERE [userName] = '{0}' ";
    private const string USER_REGISTER = " INSERT INTO [User]([userName], [userPsw], [userTel], [admin]) VALUES ('{0}','{1}','{2}','{3}')";
    private const string USER_LOGIN = "SELECT * FROM [User] WHERE [userName] = '{0}' AND [userPsw] = '{1}'";
    private const string GET_USERINFO_BY_USERNAME = " SELECT * FROM [User] WHERE [userName] = '{0}'";
    private const string UPDATE_USERINFO = "UPDATE [User] SET userName = '{0}', userTel = '{1}', userEmail = '{2}'"
        + ", sex = '{3}', education = '{4}', birth = '{5}', sketch = '{6}', img = '{7}' WHERE userName = '{8}'";
    private const string CHANGE_PASSWORD_BY_USERNAME = " UPDATE [User] SET [userPsw] = '{0}' WHERE [userName] = '{1}' ";

    /// <summary>
    /// 修改用户密码
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="userPsw"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static bool UpdateUserPasswordByUserName(string userName, string userPsw, OleDbConnection conn)
    {
        string sql = String.Format(CHANGE_PASSWORD_BY_USERNAME, userPsw, userName);
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.ExecuteNonQuery();
        return true;
    }

    /// <summary>
    /// 更新用户信息
    /// </summary>
    /// <param name="name"></param>
    /// <param name="tel"></param>
    /// <param name="email"></param>
    /// <param name="sex"></param>
    /// <param name="edu"></param>
    /// <param name="birth"></param>
    /// <param name="imgUrl"></param>
    /// <param name="ske"></param>
    /// <param name="orname"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static bool UpdateUserInfoByUserName(string name, string tel, string email, string sex, string edu,
        string birth, string imgUrl, string ske, string orname, OleDbConnection conn)
    {
        string sql = String.Format(UPDATE_USERINFO, name, tel, email, sex, edu, birth, ske, imgUrl,orname);
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.ExecuteNonQuery();
        return true;        
    }

    /// <summary>
    /// 根据用户名获取用户信息
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static User GetUserInfoByUserName(string userName, OleDbConnection conn)
    {
        string sql = String.Format(GET_USERINFO_BY_USERNAME, userName);
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        OleDbDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            User userInfo = new User();
            userInfo.userName = reader["userName"] + "";
            userInfo.userPsw = reader["userPsw"] + "";
            userInfo.userTel = reader["userTel"] + "";
            userInfo.userEmail = reader["userEmail"] + "";
            userInfo.userEdu = reader["education"] + "";
            userInfo.userSex = reader["sex"] + "";
            userInfo.userBirth = reader["birth"] + "";
            userInfo.userSke = reader["sketch"] + "";
            userInfo.Admin = reader["admin"] + "";
            userInfo.Img = reader["img"] + "";
            userInfo.Exp = (int)reader["userExp"];
            return userInfo;
        }
        else
        {
            return null;
        }
    }

    // 使用阅读器向数据表格填充数据
    public static DataTable FillUserInfo(OleDbConnection conn)
    {
        string sql = "SELECT [ID]," +
            "[userName] AS [用户名]," +
            "[userPsw] AS [密码]," +
            "[userTel] AS [联系方式]," +
            "[userEmail] AS [邮箱]," +
            "[education] AS [学历]," +
            "[sex] AS [性别]," +
            "[birth] AS [生日]," +
            "[sketch] AS [简介]," +
            "[admin] AS [身份]," +
            "[img] AS [图片名称]" +
            "FROM [User]";
        OleDbCommand cmd = new OleDbCommand(sql,conn);
        OleDbDataReader reader = cmd.ExecuteReader();
        DataTable userTable = new DataTable();
        userTable.Load(reader);
        reader.Close();
        return userTable;
    }

    /// <summary>
    /// 注册新用户
    /// </summary>
    /// <param name="username"></param>
    /// <param name="userpsw"></param>
    /// <param name="usertel"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static bool UserRegister(string username, string userpsw, string usertel, OleDbConnection conn)
    {
        bool result = false;
        string sql_Check = String.Format(CHECK_USERNAME, username);
        OleDbCommand cmd = new OleDbCommand(sql_Check, conn);
        OleDbDataReader reader = cmd.ExecuteReader();
        if (!reader.Read())
        {
            string sql_Register = String.Format(USER_REGISTER, username, userpsw, usertel, "user");
            OleDbCommand cmd2 = new OleDbCommand(sql_Register, conn);
            cmd2.ExecuteNonQuery();
            result = true;
        }
        return result;
    }

    /// <summary>
    /// 用户登录
    /// </summary>
    /// <param name="username"></param>
    /// <param name="userpsw"></param>
    /// <param name="conn"></param>
    /// <returns></returns> 
    public static User UserLogin(string username, string userpsw, OleDbConnection conn)
    {
        string sql = String.Format(USER_LOGIN, username, userpsw);
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        OleDbDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            User user = new User();
            user.userName = username;
            user.userPsw = userpsw;
            return user;
        }
        else
        {
            return null;
        }
    }
}