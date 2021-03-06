﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace BookShop20181019.Web.SysFun
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtNodeId.Text))
			{
				strErr+="NodeId格式错误！\\n";	
			}
			if(this.txtDisplayName.Text.Trim().Length==0)
			{
				strErr+="DisplayName不能为空！\\n";	
			}
			if(this.txtNodeURL.Text.Trim().Length==0)
			{
				strErr+="NodeURL不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtDisplayOrder.Text))
			{
				strErr+="DisplayOrder格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtParentNodeId.Text))
			{
				strErr+="ParentNodeId格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int NodeId=int.Parse(this.txtNodeId.Text);
			string DisplayName=this.txtDisplayName.Text;
			string NodeURL=this.txtNodeURL.Text;
			int DisplayOrder=int.Parse(this.txtDisplayOrder.Text);
			int ParentNodeId=int.Parse(this.txtParentNodeId.Text);

			BookShop20181019.Model.SysFun model=new BookShop20181019.Model.SysFun();
			model.NodeId=NodeId;
			model.DisplayName=DisplayName;
			model.NodeURL=NodeURL;
			model.DisplayOrder=DisplayOrder;
			model.ParentNodeId=ParentNodeId;

			BookShop20181019.BLL.SysFun bll=new BookShop20181019.BLL.SysFun();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
