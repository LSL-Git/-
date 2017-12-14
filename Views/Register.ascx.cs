using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Register : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        newUser.Focus();
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        string newuser = newUser.Text.Trim();
        string newpsw = newPsw.Text.Trim();
        string newrpsw = newRpsw.Text.Trim();
        string newtel = newTel.Text.Trim();

        // 检测用户名是否有效
        System.Text.RegularExpressions.Regex regex_name = 
            new System.Text.RegularExpressions.Regex("[A-Za-z0-9\u4e00-\u9fa5]+");

        System.Text.RegularExpressions.Regex regex_psw =
            new System.Text.RegularExpressions.Regex("[A-Za-z0-9]+");

        System.Text.RegularExpressions.Regex regex_tel =
            new System.Text.RegularExpressions.Regex("0?(13|14|15|18)[0-9]{9}");

        registerMsg.Text = "";

        if (regex_name.IsMatch(newuser))
        {
            if (newpsw.Equals(newrpsw))
            {
                if (regex_psw.IsMatch(newpsw))
                {
                    if (regex_tel.IsMatch(newtel))
                    {
                        // 注册成功
                        // 保存用户信息，并对密码进行加密
                        if (UserHelper.Register(newuser, MD5Encryption.EnCondingMD5(newpsw), newtel))
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "",
                                "alert('注册成功！前往登录...');window.location.href='Login.aspx'", true);
                        }
                        else
                        {
                            registerMsg.Text = "用户名已存在！";
                        }
                    }
                    else
                    {
                        registerMsg.Text = "请输入正确手机号！";
                    }
                }
                else
                {
                    registerMsg.Text = "无效密码！(大小写母、数字)";
                }
            }
            else
            {
                registerMsg.Text = "输入两次密码不一样！";
            }
        }
        else
        {
            registerMsg.Text = "无效用户名！(中文、大小写母、数字、'-'或'_')";
        }
    }
}