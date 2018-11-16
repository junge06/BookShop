using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop20181019.Web.AdminManager
{
    public partial class CreateStaticPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.Books bookBll = new BLL.Books();
            List<Model.Books> list = bookBll.GetModelList("");
            foreach (Model.Books book in list)
            {
                bookBll.CreateHtmlPage(book.Id);
            }
        }
    }
}