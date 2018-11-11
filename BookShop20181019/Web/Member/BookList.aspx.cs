using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop20181019.Web.Member
{
    public partial class BookList : System.Web.UI.Page
    {
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBookList();
            }
        }

        private void BindBookList()
        {
            int pageIndex;
            if (!int.TryParse(Request["pageIndex"],out pageIndex))
            {
                pageIndex = 1;
            }
            int pageSize = 10;
            BLL.Books bookBll = new BLL.Books();
            int pageCount = bookBll.GetRecordCount(pageSize);
            PageCount = pageCount;
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            PageIndex = PageIndex;
            this.BookListRepeater.DataSource = bookBll.GetPageList(pageIndex,pageSize);
            this.BookListRepeater.DataBind();


            //BLL.Books bookBll = new BLL.Books();
            //this.BookListRepeater.DataSource = bookBll.GetModelList("");
            //this.BookListRepeater.DataBind();
        }

        public string CutString(string str,int length)
        {
            return str.Length > length ? str.Substring(0, length) + "......" : str;
        }
    }
}