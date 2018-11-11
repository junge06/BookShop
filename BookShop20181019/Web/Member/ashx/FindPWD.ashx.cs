using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop20181019.Web.Member.ashx
{
    /// <summary>
    /// FindPWD 的摘要说明
    /// </summary>
    public class FindPWD : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string name = context.Request["name"];
            string email=context.Request["email"];
            BLL.Users userBll = new BLL.Users();
            Model.Users userInfo=userBll.GetUserByName(name);
            if (userInfo!=null)
            {
                if (userInfo.Mail==email)
                {

                }
                else
                {
                    context.Response.Write("邮箱错误");
                }
            }
            else
            {
                context.Response.Write("查无此人！！！");
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