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

        public bool ValidateEmail(string email) 
        {
            return dal.CheckUserEmail(email) > 0 ? true : false;
        }

        /// <summary>
        /// 根据用户名找用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Model.Users GetUserByName(string userName) 
        {
            return dal.GetModel(userName);
        }

        /// <summary>
        /// 完成用户登录信息的校验
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPwd"></param>
        /// <param name="msg"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool CheckUserInfo(string userName,string userPwd,out string msg,out Model.Users user)
        {
            user = dal.GetModel(userName);
            if (user!=null)
            {
                if (user.LoginPwd==userPwd)
                {
                    msg = "登录成功";
                    return true;
                }
                else
                {
                    msg = "用户名或者密码错误";
                    return false;
                }

            }
            else
            {
                msg = "此用户不存在";
                return false;
            }
        }

    }
}
