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
namespace BookShop20181019.Web.Books
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtTitle.Text.Trim().Length==0)
			{
				strErr+="Title不能为空！\\n";	
			}
			if(this.txtAuthor.Text.Trim().Length==0)
			{
				strErr+="Author不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtPublisherId.Text))
			{
				strErr+="PublisherId格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtPublishDate.Text))
			{
				strErr+="PublishDate格式错误！\\n";	
			}
			if(this.txtISBN.Text.Trim().Length==0)
			{
				strErr+="ISBN不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtWordsCount.Text))
			{
				strErr+="WordsCount格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtUnitPrice.Text))
			{
				strErr+="UnitPrice格式错误！\\n";	
			}
			if(this.txtContentDescription.Text.Trim().Length==0)
			{
				strErr+="ContentDescription不能为空！\\n";	
			}
			if(this.txtAurhorDescription.Text.Trim().Length==0)
			{
				strErr+="AurhorDescription不能为空！\\n";	
			}
			if(this.txtEditorComment.Text.Trim().Length==0)
			{
				strErr+="EditorComment不能为空！\\n";	
			}
			if(this.txtTOC.Text.Trim().Length==0)
			{
				strErr+="TOC不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtCategoryId.Text))
			{
				strErr+="CategoryId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtClicks.Text))
			{
				strErr+="Clicks格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string Title=this.txtTitle.Text;
			string Author=this.txtAuthor.Text;
			int PublisherId=int.Parse(this.txtPublisherId.Text);
			DateTime PublishDate=DateTime.Parse(this.txtPublishDate.Text);
			string ISBN=this.txtISBN.Text;
			int WordsCount=int.Parse(this.txtWordsCount.Text);
			decimal UnitPrice=decimal.Parse(this.txtUnitPrice.Text);
			string ContentDescription=this.txtContentDescription.Text;
			string AurhorDescription=this.txtAurhorDescription.Text;
			string EditorComment=this.txtEditorComment.Text;
			string TOC=this.txtTOC.Text;
			int CategoryId=int.Parse(this.txtCategoryId.Text);
			int Clicks=int.Parse(this.txtClicks.Text);

			BookShop20181019.Model.Books model=new BookShop20181019.Model.Books();
			model.Title=Title;
			model.Author=Author;
			model.PublisherId=PublisherId;
			model.PublishDate=PublishDate;
			model.ISBN=ISBN;
			model.WordsCount=WordsCount;
			model.UnitPrice=UnitPrice;
			model.ContentDescription=ContentDescription;
			model.AurhorDescription=AurhorDescription;
			model.EditorComment=EditorComment;
			model.TOC=TOC;
			model.CategoryId=CategoryId;
			model.Clicks=Clicks;

			BookShop20181019.BLL.Books bll=new BookShop20181019.BLL.Books();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
