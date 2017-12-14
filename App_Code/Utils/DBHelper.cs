using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/// <summary>
/// DBHelper 数据库操作类
/// </summary>
public class DBHelper
{
    private OleDbConnection _conn;
    // 获取链接数据库字符串
    string connStr = ConfigurationManager.ConnectionStrings["ConnDbStr"].ConnectionString;

    public OleDbConnection GetConn
    {
        get
        {
            return _conn;
        }
    }
    // 创建链接对象
    public DBHelper()
    {
        _conn = new OleDbConnection(connStr);
    }
    // 打开数据库链接
    public void Connect()
    {
        try
        {
            if (_conn.State != ConnectionState.Open)
            {
                _conn.Open();
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
    }
    // 关闭数据库连接
    public void Disconnect()
    {
        if (_conn.State != ConnectionState.Closed)
        {
            _conn.Close();
        }
    }
    // 根据当前时间产生一个序列号
    public long GetNumberByTime()
    {
        DateTime dateTime = new DateTime();
        string number = dateTime.ToString("yyyyMMddHHmmss") + dateTime.Millisecond.ToString("D3");
        return long.Parse(number);
    }
}