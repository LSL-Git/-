using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Text.RegularExpressions;

public partial class User_UserInfo : System.Web.UI.Page
{
    User userInfo = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        string userName = "";

        if (Request.Cookies["USERINFO"] != null)
        {
            userName = HttpUtility.UrlDecode(Request.Cookies["USERINFO"]["NAME"]);
        }
        // 从数据库获取用户信息
        userInfo = UserHelper.GetUserInfoByUserName(userName);

        if (!IsPostBack)
        {
            LoadUserInfo(userInfo);
        }
    }

    /// <summary>
    ///  加载用户信息
    /// </summary>
    /// <param name="userInfo"></param>
    public void LoadUserInfo(User userInfo)
    {
        if (userInfo != null)
        {
            txtUserName.Text = userInfo.userName;
            txtUserTel.Text = userInfo.userTel;
            txtUserEmail.Text = userInfo.userEmail;
            Sex.SelectedValue = userInfo.userSex;
            edu.SelectedValue = userInfo.userEdu;
            txtUserBirth.Text = userInfo.userBirth;
            if (userInfo.userBirth.Length >= 10)
            {
                txtUserBirth.Text = userInfo.userBirth.Substring(0, 10).Replace(" ","");
            }                
            txtUserSketch.Text = userInfo.userSke;
            userIcon.ImageUrl = userInfo.Img;
            UserExp.Text = userInfo.Exp + "";
            if (userInfo.Admin.Equals("admin"))
            {
                butAdmin.Visible = true;
            }
            else
            {
                butAdmin.Visible = false;
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(),
                "", "alert('没有该用户信息');window.location.href='MainPage.aspx'", true);
            //Response.Redirect("MainPage.aspx");
        }
    }

    /// <summary>
    /// 控制文本框是否可编辑
    /// </summary>
    /// <param name="en">true 可编辑，false不可编辑</param>
    /// <param name="boColor">边框颜色</param>
    /// <param name="baColor">背景颜色</param>
    private void CtlEnable(bool en, Color boColor, Color baColor)
    {

        butCancel.Visible = en;
        txtUserName.Enabled = en;
        txtUserName.BorderColor = boColor;
        txtUserName.BackColor = baColor;
        txtUserTel.Enabled = en;
        txtUserTel.BorderColor = boColor;
        txtUserTel.BackColor = baColor;
        txtUserEmail.Enabled = en;
        txtUserEmail.BorderColor = boColor;
        txtUserEmail.BackColor = baColor;
        txtUserBirth.Enabled = en;
        txtUserBirth.BorderColor = boColor;
        txtUserBirth.BackColor = baColor;
        txtUserSketch.Enabled = en;
        txtUserSketch.BorderColor = boColor;
        txtUserSketch.BackColor = baColor;
        Sex.Enabled = en;
        edu.Enabled = en;
        ImageButton1.Visible = en;
        if (!en)
        {
            calendar.Visible = en;
        }
    }

    /// <summary>
    /// 判断字符串是否符合日期格式
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public bool IsBirth(string msg)
    {
        return Regex.IsMatch(msg, @"^\d{4}(\-|\/|.)\d{1,2}\1\d{1,2}$");
    }
    
    /// <summary>
    /// 判断字符串是否符合邮箱格式
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public bool IsEmail(string msg)
    {
        return Regex.IsMatch(msg, @"\w[-\w.+]*@([A-Za-z0-9][-A-Za-z0-9]+\.)+[A-Za-z]{2,14}");
    }
    
    /// <summary>
    /// 判断字符串是否符合电话号码格式
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public bool IsTel(string msg)
    {
        return Regex.IsMatch(msg, @"^\d{11}$");
    }

    protected void butUpdate_Click(object sender, EventArgs e)
    {
        if (butUpdate.Text.Equals("确认"))
        {
            string userName = txtUserName.Text;

            User user = new User();
            user.userName = userName;
            user.userTel = txtUserTel.Text;
            user.userEmail = txtUserEmail.Text;
            user.userSex = Sex.SelectedValue;
            user.userEdu = edu.SelectedValue;
            user.userBirth = txtUserBirth.Text;
            user.userSke = txtUserSketch.Text;
            user.Img = userIcon.ImageUrl;// 头像路径

            bool update = true; // 是否符合更新条件

            if (userInfo.userName != userName) // 检查是否修改了用户名
            {
                update = UserHelper.ExistsUserName(userName);// 检查是否有相同用户名
            }

            if (update) 
            {
                if (IsBirth(txtUserBirth.Text))
                {
                    if (IsEmail(txtUserEmail.Text))
                    {
                        if (IsTel(txtUserTel.Text))
                        {
                            if (UserHelper.UpdateUserInfo(user, userInfo.userName))
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(),
                                    "", "alert('更新成功！');window.location.href='UserInfo.aspx'", true);

                                Response.Cookies["USERINFO"]["NAME"] = HttpUtility.UrlEncode(user.userName);
                                Response.Cookies["USERINFO"]["PSW"] = Request.Cookies["USERINFO"]["PSW"];

                                Color color = System.Drawing.ColorTranslator.FromHtml("#fff");
                                CtlEnable(false, color, color);
                                butUpdate.Text = "修改";
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(),
                              "", "alert('更新失败！');window.location.href='UserInfo.aspx'", true);
                            }
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(),
                                        "", "alert('手机号格式不符合!');", true);
                        }                        
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(),
                                        "", "alert('邮箱格式不符合!');", true);
                    }                    
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(),
                                        "", "alert('出生日期存在非法字符!');", true);
                }                
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(),
                "", "alert('已有该用户名，请更改!');", true);
            }
        }
        else
        {
            Color boColor = System.Drawing.ColorTranslator.FromHtml("#038bcb");
            Color baColor = System.Drawing.ColorTranslator.FromHtml("#F5F5F5");
            CtlEnable(true, boColor, baColor);
            butUpdate.Text = "确认";
        }
    }

    protected void butCancel_Click(object sender, EventArgs e)
    {
        Color color = System.Drawing.ColorTranslator.FromHtml("#fff");
        CtlEnable(false, color, color);
        butUpdate.Text = "修改";
        LoadUserInfo(userInfo);
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        txtUserBirth.Text = Calendar1.SelectedDate.ToShortDateString();
        // 隐藏日历
        calendar.Visible = false;
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        calendar.Visible = !calendar.Visible;
    }

    protected void butAdmin_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Admin/CheckArticle.aspx");
    }
}