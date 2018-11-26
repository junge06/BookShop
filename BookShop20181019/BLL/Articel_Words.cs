using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookShop20181019.BLL
{
    /// <summary>
	/// Articel_Words
	/// </summary>
	public partial class Articel_Words
	{
		private readonly DAL.Articel_Words dal=new DAL.Articel_Words();
		public Articel_Words()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool  Add(Model.Articel_Words model)
		{
			return dal.Add(model)>0;
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.Articel_Words model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			return dal.Delete(Id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(Idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.Articel_Words GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Model.Articel_Words GetModelByCache(int Id)
		{
			
			string CacheKey = "Articel_WordsModel-" + Id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Model.Articel_Words)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.Articel_Words> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.Articel_Words> DataTableToList(DataTable dt)
		{
			List<Model.Articel_Words> modelList = new List<Model.Articel_Words>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.Articel_Words model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

        /// <summary>
        /// 判断用户的评论中是否有禁用词
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool CheckForbid(string msg) 
        {
            List<string> list = dal.GetForBidWord();//获取所有的禁用词
            string regex = string.Join("|",list.ToArray());// aa|bb|cc|
            return Regex.IsMatch(msg,regex);

        }

        /// <summary>
        /// 判断用户的评论中是否有审查词
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool CheckModWord(string msg)
        {
            List<string> list = dal.GetModWord();//获取所有的禁用词
            string regex = string.Join("|", list.ToArray());// aa|bb|cc|
            regex = regex.Replace(@"\",@"\\").Replace("{2}",@"{0,2}");
            return Regex.IsMatch(msg, regex);

        }

        public string CheckReplace(string msg)
        {
            List<Model.Articel_Words> list = dal.GetReplaceword();
            foreach (Model.Articel_Words model in list)
            {
                msg = msg.Replace(model.WordPattern,model.ReplaceWord);
            }
            return msg;
        }




		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}
