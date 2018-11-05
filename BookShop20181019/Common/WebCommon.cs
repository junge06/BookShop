using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Security.Cryptography;


namespace Common
{
   public class WebCommon
    {
       public static void RedirectPage()
       {
           HttpContext.Current.Response.Redirect("/Member/Login.aspx?returnUrl="+HttpContext.Current.Request.Url.ToString());
       }


       /// <summary>
       /// 对字符串进行md5加密
       /// </summary>
       /// <param name="str"></param>
       /// <returns></returns>
       public static string GetMD5(string str)
       {
           MD5 md5 = MD5.Create();
           byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);
           byte[] md5Buffer= md5.ComputeHash(buffer);
           StringBuilder sb = new StringBuilder();
           foreach (byte b in md5Buffer)
           {
               sb.Append(b.ToString("x2"));
           }
           return sb.ToString();
       }
    }

   
}
