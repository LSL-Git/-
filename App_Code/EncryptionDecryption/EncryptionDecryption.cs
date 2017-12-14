using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// EncryptionDecryption 编码解码器
/// </summary>
public class EncryptionDecryption:IBindsh.EnDe
{
    /// <summary>
    /// 解码器
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public string Decode(string str)
    {
        string htext = "";

        for (int i = 0; i < str.Length; i++)
        {
            htext = htext + (char)(str[i] + 10 - 1 * 2);
        }
        return htext;
    }

    /// <summary>
    /// 编码器
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public string Encode(string str)
    {
        string dtext = "";

        for (int i = 0; i < str.Length; i++)
        {
            dtext = dtext + (char)(str[i] - 10 + 1 * 2);
        }
        return dtext;
    }
}