using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace BookShop20181019.Web.Users
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtLoginId.Text.Trim().Length==0)
			{
				strErr+="LoginId不能为空！\\n";	
			}
			if(this.txtLoginPwd.Text.Trim().Length==0)
			{
				strErr+="LoginPwd不能为空！\\n";	
			}
			if(this.txtName.Text.Trim().Length==0)
			{
				strErr+="Name不能为空！\\n";	
			}
			if(this.txtAddress.Text.Trim().Length==0)
			{
				strErr+="Address不能为空！\\n";	
			}
			if(this.txtPhone.Text.Trim().Length==0)
			{
				strErr+="Phone不能为空！\\n";	
			}
			if(this.txtMail.Text.Trim().Length==0)
			{
				strErr+="Mail不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtUserStateId.Text))
			{
				strErr+="UserStateId格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string LoginId=this.txtLoginId.Text;
			string LoginPwd=this.txtLoginPwd.Text;
			string Name=this.txtName.Text;
			string Address=this.txtAddress.Text;
			string Phone=this.txtPhone.Text;
			string Mail=this.txtMail.Text;
			int UserStateId=int.Parse(this.txtUserStateId.Text);

			BookShop20181019.Model.Users model=new BookShop20181019.Model.Users();
			model.LoginId=LoginId;
			model.LoginPwd=LoginPwd;
			model.Name=Name;
			model.Address=Address;
			model.Phone=Phone;
			model.Mail=Mail;
			model.UserStateId=UserStateId;

			BookShop20181019.BLL.Users bll=new BookShop20181019.BLL.Users();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
