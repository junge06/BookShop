using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop20181019.Web.Member.ashx
{
    /// <summary>
    /// BookComment 的摘要说明
    /// </summary>
    public class BookComment : IHttpHandler
    {
        BLL.BookComment commentBll = new BLL.BookComment();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"];
            if (action=="add")
            {
                AddComment(context);
            }
            else if (action=="load")
            {
                LoadComment(context);
            }
            else
            {

            }
        }


        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="context"></param>
        private void AddComment(HttpContext context) 
        {
            BLL.Articel_Words bll = new BLL.Articel_Words();
            string msg = context.Request["msg"];
            if (bll.CheckForbid(msg))
            {
                context.Response.Write("no:评论中含有禁用词");
            }
            else if(bll.CheckModWord(msg))
            {
                context.Response.Write("no:评论中含有审查词");
              
            }
            else
            {
                Model.BookComment comment = new Model.BookComment();
                comment.BookId = Convert.ToInt32(context.Request["bookId"]);
                comment.CreateDateTime = DateTime.Now;
                comment.Msg = bll.CheckReplace(msg);  //替换词

                if (commentBll.Add(comment) > 0)
                {
                    context.Response.Write("ok:评论成功");
                }
                else
                {
                    context.Response.Write("no:评论失败");
                }

            }
        }
        //加载评论
        private void  LoadComment(HttpContext context) 
        {
            int bookId = Convert.ToInt32(context.Request["bookId"]);
            List<Model.BookComment> list = commentBll.GetModelList("BookId=" + bookId);

            List<Model.ViewModel> newlist = new List<Model.ViewModel>();
            foreach (Model.BookComment item in list)
            {
                Model.ViewModel viewModel = new Model.ViewModel();
                viewModel.Msg = Common.WebCommon.UbbToHtml(item.Msg);
                TimeSpan ts = DateTime.Now - item.CreateDateTime;
                viewModel.CreateDateTime = Common.WebCommon.GetTimeSpan(ts);//获取评论的时间
                newlist.Add(viewModel);
            }

            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            context.Response.Write(js.Serialize(newlist));
            
        }







        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}