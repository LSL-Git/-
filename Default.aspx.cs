using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private string EnCondingMD5(string str)
    {
        byte[] b = Encoding.Default.GetBytes(str);
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] o = md5.ComputeHash(b);
        return BitConverter.ToString(o).Replace("-", "");
    }
    

    protected void Button1_Click(object sender, EventArgs e)
    {
        string psw = EnCondingMD5(TextBox1.Text.Trim());

        Label1.Text = psw;

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (EnCondingMD5(TextBox2.Text.Trim()) == Label1.Text.Trim())
        {
            Label2.Text = "比对成功";
        }
        else
        {
            Label2.Text = "比对失败";
        }
    }
}