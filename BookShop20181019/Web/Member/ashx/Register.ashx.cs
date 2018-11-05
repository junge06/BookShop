using BookShop20181019.Web.Member.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop20181019.Web.Member.ashx
{
    /// <summary>
    /// Register 的摘要说明
    /// </summary>
    public class Register : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";


            
                //string code = context.Request.Form["txtCode"];
            //string code = context.Request["code"];
            //    if (Common.ValidateCodeHelper.CheckValidateCode(code))//完成验证码的校验
            //    {
                    //添加用户信息
                    AddUer(context);

                //}
           

            
            
        }

        #region 添加用户
        private void AddUer(HttpContext context)
        {
            BLL.Users userBll = new BLL.Users();

            Model.Users user = new Model.Users();
            if (userBll.ValidateUserName(context.Request["userName"]))
            {
                context.Response.Write("用户名已经被注册");
                return;
            }
            user.LoginId = context.Request["userName"];
            user.Name = context.Request["realName"];
            user.LoginPwd = context.Request["userPwd"];
            user.Address = context.Request["address"];
            if (userBll.ValidateEmail(context.Request["email"]))
            {
                context.Response.Write("邮箱已经被注册");
                return;
            }

            user.Mail = context.Request["email"];
            user.Phone = context.Request["telephone"];
            user.UserStateId = Convert.ToInt32(UserStateEnum.NormalState);


            if (userBll.Add(user) > 0)
            {
                context.Response.Write("注册成功");
            }
            else
            {
                context.Response.Write("服务器忙请稍后重试");
            }

            //string msg = string.Empty;
            //if (userBll.Add(user, out msg) > 0)
            //{
            //    context.Session["userInfo"] = user;
            //    context.Response.Redirect("/Default.aspx");

            //}
            //else
            //{
            //    context.Response.Redirect("/ShowMsg.aspx?msg=" + msg + "&txt=首页" + "&url=/Default.aspx");
            //}
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}