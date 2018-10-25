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
namespace BookShop20181019.Web.Books
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
		BookShop20181019.BLL.Books bll=new BookShop20181019.BLL.Books();
		BookShop20181019.Model.Books model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.lblTitle.Text=model.Title;
		this.lblAuthor.Text=model.Author;
		this.lblPublisherId.Text=model.PublisherId.ToString();
		this.lblPublishDate.Text=model.PublishDate.ToString();
		this.lblISBN.Text=model.ISBN;
		this.lblWordsCount.Text=model.WordsCount.ToString();
		this.lblUnitPrice.Text=model.UnitPrice.ToString();
		this.lblContentDescription.Text=model.ContentDescription;
		this.lblAurhorDescription.Text=model.AurhorDescription;
		this.lblEditorComment.Text=model.EditorComment;
		this.lblTOC.Text=model.TOC;
		this.lblCategoryId.Text=model.CategoryId.ToString();
		this.lblClicks.Text=model.Clicks.ToString();

	}


    }
}
