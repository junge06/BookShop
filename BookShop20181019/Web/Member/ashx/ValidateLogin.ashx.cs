using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop20181019.Web.Member.ashx
{
    /// <summary>
    /// ValidateLogin 的摘要说明
    /// </summary>
    public class ValidateLogin : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string userName = context.Request["userName"];

            BLL.Users userBll = new BLL.Users();
            if (userBll.ValidateUserName(userName))
            {
                context.Response.Write("ok");

            }
            else
            {
                context.Response.Write("用户名不存在");
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