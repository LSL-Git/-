using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/// <summary>
/// UserHelper 的摘要说明
/// </summary>
public class UserHelper
{
    private static DBHelper mdb = new DBHelper();
    private static Object mLockObj = new Object();

    /// <summary>
    /// 登录业务
    /// </summary>
    /// <param name="name"></param>
    /// <param name="psw"></param>
    /// <returns></returns>
    public static User Login(string name, string psw)
    {
        User userData = null;
        lock (mLockObj)
        {
            mdb.Connect();
            userData = UserData.UserLogin(name, psw, mdb.GetConn);
            mdb.Disconnect();
        }        
        return userData;
    }
    /// <summary>
    /// 注册业务
    /// </summary>
    /// <param name="nname"></param>
    /// <param name="npsw"></param>
    /// <param name="ntel"></param>
    /// <returns></returns>
    public static bool Register(string nname, string npsw, string ntel)
    {
        bool result = false;
        lock (mLockObj)
        {
            mdb.Connect();
            result = UserData.UserRegister(nname, npsw, ntel, mdb.GetConn);
            mdb.Disconnect();
        }
        return result;
    }

    /// <summary>
    /// 执行查询用户信息业务
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    public static User GetUserInfoByUserName(string username)
    {
        User userInfo = null;
        lock (mLockObj)
        {
            mdb.Connect();
            userInfo = UserData.GetUserInfoByUserName(username, mdb.GetConn);
            mdb.Disconnect();
        }
        return userInfo;
    }
    
    /// <summary>
    /// 检查是否存在相同用户名 返回true表示没有相同用户名
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    public static bool ExistsUserName(string username)
    {
        bool exists = false;
        lock (mLockObj)
        {
            mdb.Connect();
            exists = UserData.GetUserInfoByUserName(username, mdb.GetConn) == null;
            mdb.Disconnect();
        }
        return exists;
    }

    /// <summary>
    /// 执行更新业务
    /// </summary>
    /// <param name="userInfo"></param>
    /// <param name="userName"></param>
    /// <returns></returns>
    public static bool UpdateUserInfo(User userInfo,string userName)
    {
        bool result = false;
        lock (mLockObj)
        {
            mdb.Connect();
            result = UserData.UpdateUserInfoByUserName(userInfo.userName, userInfo.userTel,userInfo.userEmail,
                userInfo.userSex, userInfo.userEdu, userInfo.userBirth, userInfo.Img, userInfo.userSke, 
                userName, mdb.GetConn);
            mdb.Disconnect();
        }
        return result;
    }
    /// <summary>
    /// 执行修改密码业务
    /// </summary>
    /// <param name="psw"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static bool UpdateUserPsw(string psw, string name)
    {
        bool result = false;
        lock (mLockObj)
        {
            mdb.Connect();
            result = UserData.UpdateUserPasswordByUserName(name, psw, mdb.GetConn);
            mdb.Disconnect();
        }
        return result;
    }
}