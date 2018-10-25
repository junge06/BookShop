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
namespace BookShop20181019.Web.Orders
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					string OrderId= strid;
					ShowInfo(OrderId);
				}
			}
		}
		
	private void ShowInfo(string OrderId)
	{
		BookShop20181019.BLL.Orders bll=new BookShop20181019.BLL.Orders();
		BookShop20181019.Model.Orders model=bll.GetModel(OrderId);
		this.lblOrderId.Text=model.OrderId;
		this.lblOrderDate.Text=model.OrderDate.ToString();
		this.lblUserId.Text=model.UserId.ToString();
		this.lblTotalPrice.Text=model.TotalPrice.ToString();
		this.lblPostAddress.Text=model.PostAddress;
		this.lblstate.Text=model.state.ToString();

	}


    }
}
