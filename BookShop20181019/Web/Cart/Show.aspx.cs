﻿using System;
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
namespace BookShop20181019.Web.Cart
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
					int Id=(Convert.ToInt32(strid));
					ShowInfo(Id);
				}
			}
		}
		
	private void ShowInfo(int Id)
	{
		BookShop20181019.BLL.Cart bll=new BookShop20181019.BLL.Cart();
		BookShop20181019.Model.Cart model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.lblUserId.Text=model.UserId.ToString();
		this.lblBookId.Text=model.BookId.ToString();
		this.lblCount.Text=model.Count.ToString();

	}


    }
}
