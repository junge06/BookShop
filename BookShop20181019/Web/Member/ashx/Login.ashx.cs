using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop20181019.Web.Member.ashx
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class Login : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string userName = context.Request["userName"];
            string userPwd = context.Request["userPwd"];
            if (userName!=null)
            {
                BLL.Users userBll = new BLL.Users();
                if (userBll.ValidateUserName(userName)) 
                {
                    Model.Users user = userBll.GetUserByName(userName);
                    if (user.LoginPwd==userPwd)
                    {
                        context.Response.Write("登陆成功！");
                        context.Response.Redirect("CutPhoto.aspx");
                    }
                    else
                    {
                        context.Response.Write("用户名或密码错误！！");
                    }
                    
                }
                else
                {
                    context.Response.Write("用户名不存在");
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}