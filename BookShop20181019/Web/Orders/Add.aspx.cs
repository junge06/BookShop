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
namespace BookShop20181019.Web.Orders
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtOrderId.Text.Trim().Length==0)
			{
				strErr+="OrderId不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtOrderDate.Text))
			{
				strErr+="OrderDate格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtUserId.Text))
			{
				strErr+="UserId格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtTotalPrice.Text))
			{
				strErr+="TotalPrice格式错误！\\n";	
			}
			if(this.txtPostAddress.Text.Trim().Length==0)
			{
				strErr+="PostAddress不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtstate.Text))
			{
				strErr+="state格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string OrderId=this.txtOrderId.Text;
			DateTime OrderDate=DateTime.Parse(this.txtOrderDate.Text);
			int UserId=int.Parse(this.txtUserId.Text);
			decimal TotalPrice=decimal.Parse(this.txtTotalPrice.Text);
			string PostAddress=this.txtPostAddress.Text;
			int state=int.Parse(this.txtstate.Text);

			BookShop20181019.Model.Orders model=new BookShop20181019.Model.Orders();
			model.OrderId=OrderId;
			model.OrderDate=OrderDate;
			model.UserId=UserId;
			model.TotalPrice=TotalPrice;
			model.PostAddress=PostAddress;
			model.state=state;

			BookShop20181019.BLL.Orders bll=new BookShop20181019.BLL.Orders();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
