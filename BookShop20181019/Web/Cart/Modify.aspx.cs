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
namespace BookShop20181019.Web.Cart
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int Id=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(Id);
				}
			}
		}
			
	private void ShowInfo(int Id)
	{
		BookShop20181019.BLL.Cart bll=new BookShop20181019.BLL.Cart();
		BookShop20181019.Model.Cart model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.txtUserId.Text=model.UserId.ToString();
		this.txtBookId.Text=model.BookId.ToString();
		this.txtCount.Text=model.Count.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtUserId.Text))
			{
				strErr+="UserId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtBookId.Text))
			{
				strErr+="BookId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtCount.Text))
			{
				strErr+="Count格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int Id=int.Parse(this.lblId.Text);
			int UserId=int.Parse(this.txtUserId.Text);
			int BookId=int.Parse(this.txtBookId.Text);
			int Count=int.Parse(this.txtCount.Text);


			BookShop20181019.Model.Cart model=new BookShop20181019.Model.Cart();
			model.Id=Id;
			model.UserId=UserId;
			model.BookId=BookId;
			model.Count=Count;

			BookShop20181019.BLL.Cart bll=new BookShop20181019.BLL.Cart();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
