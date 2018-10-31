using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maticsoft.DBUtility;namespace BookShop20181019.DAL
{
    partial class Users
    {
        //根据用户名查询一个用户
        public Model.Users GetModel(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,LoginId,LoginPwd,Name,Address,Phone,Mail,UserStateId from Users ");
            strSql.Append(" where LoginId=@LoginId");
            SqlParameter[] parameters = {
					new SqlParameter("@LoginId", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = userName;

            BookShop20181019.Model.Users model = new BookShop20181019.Model.Users();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        public int CheckUserEmail(string email) 
        {
            string sql = "select count(*) from users where Mail=@Mail";
            SqlParameter parameter = new SqlParameter("@Mail",SqlDbType.NVarChar,50);
            parameter.Value = email;
            return Convert.ToInt32(DbHelperSQL.GetSingle(sql,parameter));
        }
    }
}
