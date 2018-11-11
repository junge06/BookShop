using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop20181019.Web
{
    public partial class BookDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id=Convert.ToInt32(Context.Request["id"]);
            Context.Response.Write(id);

        }
    }
}