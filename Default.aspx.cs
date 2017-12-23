using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class _Default : System.Web.UI.Page
{
    private const string GET_FLOOR_NUM = " SELECT COUNT(*) FROM [ArticleComment] WHERE [ArticleID] = {0} ";

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

        ////UserArticleInfo info = new UserArticleInfo();
        //Article article = ArticleHelper.GetTheNewArticleByUserId(8);
        //Label1.Text = article.ID + "";

        

        DBHelper mdb = new DBHelper();
        mdb.Connect();
        string sql2 = String.Format(GET_FLOOR_NUM, 54);
        OleDbCommand cmd2 = new OleDbCommand(sql2, mdb.GetConn);
        int newFloor = (int)cmd2.ExecuteScalar() + 1;
        mdb.Disconnect();

        Label1.Text = newFloor + "";
        //GridView1.DataSource = table;
        //GridView1.DataBind();

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

    protected void Button3_Click(object sender, EventArgs e)
    {
        string c = content.Text.ToString();
    }
}