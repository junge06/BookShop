using BookShop20181019.Web.Member.Enum;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop20181019.Web.Member
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string code = Request.Form["txtCode"];
                if (Common.ValidateCodeHelper.CheckValidateCode(code))//完成验证码的校验
                {
                    //添加用户信息
                    AddUer();

                }
            }
        }

        #region 添加用户
        private void AddUer()
        {
            Model.Users user = new Model.Users();
            user.LoginId = Request[""];
            user.Name = Request[""];
            user.LoginPwd = Request[""];
            user.Address = Request[""];
            user.Mail = Request[""];
            user.Phone = Request[""];
            user.UserStateId=Convert.ToInt32(UserStateEnum.NormalState);
            BLL.Users userBll = new BLL.Users();
            string msg = string.Empty;
            if (userBll.Add(user, out msg) > 0) 
            {
                Session["userInfo"] = user;
                Response.Redirect("/Default.aspx");

            }
            else
            {
                Response.Redirect("/ShowMsg.aspx?msg="+msg+"&txt=首页"+"&url=/Default.aspx");
            }
        } 
        #endregion
    }
}