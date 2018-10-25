using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop20181019.BLL
{
    partial class  Users
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BookShop20181019.Model.Users model,out string msg)
        {
            int isSuccess = -1;
            if (ValidateUserName(model.LoginId))
            {
                msg = "此用户名已经注册";
            }
            else
            {
                isSuccess = dal.Add(model);
                msg = "注册成功";
            }
            return isSuccess;
            
        }

        public bool ValidateUserName(string userName) 
        {
            return dal.GetModel(userName) != null ? true : false;
        }

    }
}
