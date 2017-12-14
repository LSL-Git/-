using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_MyEditor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // 获取数据库连接对象
            DBHelper mdb = new DBHelper();
            mdb.Connect();//链接数据库
            DataSet data = new DataSet();
            // 从数据库读取文章的所有类型
            OleDbDataAdapter article_type = ArticleTypeDate.GetAllArticleType(mdb.GetConn);
            article_type.Fill(data, "TypeTable");
            mdb.Disconnect();// 断开数据库连接

            // 将数据绑定到控件上
            ArticleTypeList.DataSource = data.Tables["TypeTable"].DefaultView;
            ArticleTypeList.DataTextField = "type";
            ArticleTypeList.DataValueField = "type";
            ArticleTypeList.DataBind();
            // 设置第一项为空项
            ArticleTypeList.Items.Insert(0, new ListItem("", ""));
            data.Dispose(); // 释放data中的资源
            article_type.Dispose(); // 释放article_type中的资源
        }
    }

    protected void butPublish_Click(object sender, EventArgs e)
    {
        string c = content.Text.ToString();
    }
}