using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_MainPage : System.Web.UI.Page
{
    /// <summary>
    /// 加载文章列表
    /// </summary>
    /// <param name="type"></param>
    private void LoadArticle(string type)
    {
        DBHelper mdb = new DBHelper();
        mdb.Connect();
        Repeater_Article.DataSource = MainPageHelper.GetAllArticle(type, mdb.GetConn);
        Repeater_Article.DataBind();
        mdb.Disconnect();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
            LoadArticle("全部");
         }      
    }
    
    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        //string str = e.Item.Value;
        LoadArticle(e.Item.Value);
    }
}