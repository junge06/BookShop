﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using BookShop20181019.Model;
using System.Web;
using System.IO;
namespace BookShop20181019.BLL
{
	/// <summary>
	/// Books
	/// </summary>
	public partial class Books
	{
		private readonly BookShop20181019.DAL.Books dal=new BookShop20181019.DAL.Books();
		public Books()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ISBN,int Id)
		{
			return dal.Exists(ISBN,Id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(BookShop20181019.Model.Books model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BookShop20181019.Model.Books model)
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
		public bool Delete(string ISBN,int Id)
		{
			
			return dal.Delete(ISBN,Id);
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
		public BookShop20181019.Model.Books GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public BookShop20181019.Model.Books GetModelByCache(int Id)
		{
			
			string CacheKey = "BooksModel-" + Id;
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
			return (BookShop20181019.Model.Books)objModel;
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
		public List<BookShop20181019.Model.Books> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BookShop20181019.Model.Books> DataTableToList(DataTable dt)
		{
			List<BookShop20181019.Model.Books> modelList = new List<BookShop20181019.Model.Books>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BookShop20181019.Model.Books model;
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 获取总页数
		/// </summary>
		public int GetRecordCount(int pageSize)
		{
            int recordCount = dal.GetRecordCount();
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount/pageSize));
            return pageCount;
		}
		/// <summary>
		/// 获取指定范围的分页数据
		/// </summary>
        /// 
        public List<Model.Books> GetPageList(int pageIndex, int pageSize) 
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            DataSet ds = dal.GetPageList(start,end);
            return DataTableToList(ds.Tables[0]);
        }


        public void CreateHtmlPage(int id)
        {
           Model.Books book = dal.GetModel(id);
            //获取模板文件
           string template = HttpContext.Current.Request.MapPath("/Template/BookTemplate.html");
           string fileContent = File.ReadAllText(template);
           fileContent = fileContent.Replace("$title", book.Title).Replace
               ("$author", book.Author).Replace
               ("$unitprice", book.UnitPrice.ToString("0.00")).Replace
               ("$isbn", book.ISBN).Replace("$content", book.ContentDescription).Replace("$bookId",book.Id.ToString());
           string dir = "/HtmlPage/" + book.PublishDate.Year + "/" + book.PublishDate.Month + "/" + book.PublishDate.Day + "/";
           Directory.CreateDirectory(Path.GetDirectoryName(HttpContext.Current.Request.MapPath(dir)));
            string fullDir = dir + book.Id + ".html";
           File.WriteAllText(HttpContext.Current.Request.MapPath(fullDir),fileContent,System.Text.Encoding.UTF8);
        
        }



		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

