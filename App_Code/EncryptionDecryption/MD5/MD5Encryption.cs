using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// MD5Encryption MD5 加密，不可逆
/// </summary>
public class MD5Encryption
{
    public static string EnCondingMD5(string str)
    {
        byte[] b = Encoding.Default.GetBytes(str);
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] o = md5.ComputeHash(b);
        return BitConverter.ToString(o).Replace("-", "");
    }
}