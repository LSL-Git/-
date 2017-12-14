using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void butChange_Click(object sender, EventArgs e)
    {
        string originPsw = txtOriginPsw.Text;
        string newPsw = txtNewPsw.Text;
        string newRpsw = txtNewRPsw.Text;

        if (originPsw.Equals("") || newPsw.Equals("") || newRpsw.Equals(""))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请填写完整！')", true);
        }
        else
        {
            if (newPsw.Equals(newRpsw))
            {
                if (UserHelper.Login(HttpUtility.UrlDecode(Request.Cookies["USERINFO"]["NAME"]), MD5Encryption.EnCondingMD5(originPsw)) != null)
                {
                    if (UserHelper.UpdateUserPsw(MD5Encryption.EnCondingMD5(newPsw), HttpUtility.UrlDecode(Request.Cookies["USERINFO"]["NAME"])))
                    {
                        Response.Cookies["USERINFO"]["NAME"] = Request.Cookies["USERINFO"]["NAME"];
                        Response.Cookies["USERINFO"]["PSW"] = null;
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('密码修改成功，重新登陆！'" +
                            ");window.location.href='Login.aspx'", true);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('密码修改失败！')", true);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('原密码有误！')", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('输入新密码与确认密码不同！')", true);
            }
        }
    }
}