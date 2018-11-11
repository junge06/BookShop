using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

        /// <summary>
        /// 找回用户的密码
        /// </summary>
        /// <param name="userInfo"></param>
        public void FindUserPWD(Model.Users userInfo)
        {
            Settings settingsDal = new Settings();
            //系统产生一个新密码，然后更新数据库，再将新的密码发送到用户的邮箱中。
            string newPwd = Guid.NewGuid().ToString().Substring(0,8);
            userInfo.LoginPwd = newPwd;//一定要将系统产生的新密码加密以后更新到数据库中，但是发送到用户邮箱的密码一定是明文。
            dal.Update(userInfo);

            MailMessage mailMsg = new MailMessage();//要引入System.Net.Mail这个命名空间

            mailMsg.From = new MailAddress(settingsDal.GetValue("系统邮件地址"), settingsDal.GetValue("系统邮件用户名"));//源邮箱地址
            mailMsg.To.Add(new MailAddress(userInfo.Mail));//目的邮箱地址，可以有多个收件人
            mailMsg.Subject = "hello everybody";//邮箱的标题

            StringBuilder sb = new StringBuilder();
            sb.Append("用户名是："+userInfo.LoginId);
            sb.Append("新的密码是："+newPwd);
            mailMsg.Body = sb.ToString();//发送邮件的内容
            SmtpClient client = new SmtpClient(settingsDal.GetValue("系统邮件SMTP"));//smtp.163.com,smtp.qq.com
            client.Credentials = new NetworkCredential(settingsDal.GetValue("系统邮件用户名"), settingsDal.GetValue("系统邮件密码"));
            client.Send(mailMsg);//发送大量邮件时会发送阻塞，所以可以将要发送的邮件先发送到队列中、

        }




    }
}
