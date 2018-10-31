using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop20181019.Web.Member.ashx
{
    /// <summary>
    /// ValidateReg 的摘要说明
    /// </summary>
    public class ValidateReg : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {
        BLL.Users userBll = new BLL.Users();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"];
            if (action=="email")
            {
                CheckEmail(context);
            }
            else if (action == "code")
            {
                string code = context.Request["validateCode"];
                if (Common.ValidateCodeHelper.CheckValidateCode(code))
                {
                    context.Response.Write("验证码正确");
                }
                else
                {
                    context.Response.Write("验证码错误");
                }
            }
            else if (action=="userName")
            {
                CheckUserName(context);

            }
            else
            {
                context.Response.Write("参数错误");
            }
        }

        private void CheckUserName(HttpContext context)
        {
            string userNam = context.Request["uName"];
            if (userBll.ValidateUserName(userNam))
            {
                context.Response.Write("用户名已经被占用");
                
            }
            else
            {
                context.Response.Write("用户名可以使用");
            }
        }


        private void CheckEmail(HttpContext context)
        {
           string userEmail= context.Request["userEmail"];
           if (userBll.ValidateEmail(userEmail))
           {
               context.Response.Write("邮箱已经注册");
           }
           else
           {
               context.Response.Write("邮箱可以注册");
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