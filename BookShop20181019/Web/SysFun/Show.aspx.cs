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
namespace BookShop20181019.Web.SysFun
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
					int NodeId=(Convert.ToInt32(strid));
					ShowInfo(NodeId);
				}
			}
		}
		
	private void ShowInfo(int NodeId)
	{
		BookShop20181019.BLL.SysFun bll=new BookShop20181019.BLL.SysFun();
		BookShop20181019.Model.SysFun model=bll.GetModel(NodeId);
		this.lblNodeId.Text=model.NodeId.ToString();
		this.lblDisplayName.Text=model.DisplayName;
		this.lblNodeURL.Text=model.NodeURL;
		this.lblDisplayOrder.Text=model.DisplayOrder.ToString();
		this.lblParentNodeId.Text=model.ParentNodeId.ToString();

	}


    }
}
