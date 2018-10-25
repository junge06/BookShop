using System;
using System.Collections.Generic;
using System.Web;
using Common;

namespace BookShop20181019.Web.Member
{
    /// <summary>
    /// ValidateImageCode 的摘要说明
    /// </summary>
    public class ValidateImageCode : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            ValidateCode validateCode = new ValidateCode();
            string code = validateCode.CreateValidateCode(4);
            context.Session["validateCode"] = code;
            validateCode.CreateValidateGraphic(code,context);
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