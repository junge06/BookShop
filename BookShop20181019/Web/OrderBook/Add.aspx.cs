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
namespace BookShop20181019.Web.OrderBook
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtOrderID.Text.Trim().Length==0)
			{
				strErr+="OrderID不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtBookID.Text))
			{
				strErr+="BookID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtQuantity.Text))
			{
				strErr+="Quantity格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtUnitPrice.Text))
			{
				strErr+="UnitPrice格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string OrderID=this.txtOrderID.Text;
			int BookID=int.Parse(this.txtBookID.Text);
			int Quantity=int.Parse(this.txtQuantity.Text);
			decimal UnitPrice=decimal.Parse(this.txtUnitPrice.Text);

			BookShop20181019.Model.OrderBook model=new BookShop20181019.Model.OrderBook();
			model.OrderID=OrderID;
			model.BookID=BookID;
			model.Quantity=Quantity;
			model.UnitPrice=UnitPrice;

			BookShop20181019.BLL.OrderBook bll=new BookShop20181019.BLL.OrderBook();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
