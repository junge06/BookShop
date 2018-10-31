using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common
{
    public class ValidateCodeHelper : System.Web.SessionState.IRequiresSessionState
    {
       /// <summary>
       /// 完成验证码校验
       /// </summary>
       /// <returns></returns>
       public static bool CheckValidateCode(string code)
       {
           bool isSuccess = false;
           if (HttpContext.Current.Session["validateCode"] != null)
           {
               string sysCode = HttpContext.Current.Session["validateCode"].ToString();
               if (sysCode.Equals(code, StringComparison.InvariantCultureIgnoreCase))
               {
                   isSuccess = true;
                   HttpContext.Current.Session["validateCode"] = null;
               }
               
           }
           return isSuccess;
       }

    }
}
