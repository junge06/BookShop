<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BookShop20181019.Web.Member.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <script type="text/javascript">
        window.onload = function () {
            var validateCode = document.getElementById("validateCodeA");
            validateCode.onclick = function () {
                document.getElementById("ValidateCodeImg").src = "validateImageCode.ashx?d=" + new Date().getMilliseconds();
            }
        }
        $(function () {
            //var userName = $("#userName").val();
            //var userPwd = $("#userPwd").val();
            //var userRealName = $("#userRealName").val();
            //var confirmPwd = $("#confirmPwd").val();
            //var email = $("email").val();
            //var address = $("#address").val();
            //var phone = $("#phone").val();
            //var validateCode = $("validateCode").val();
            $("#spanUserName").css("display","none");
            $("#userName").blur(function () {
                var userName = $("#userName").val();
                if (userName != "") {
                    $.post("Register.aspx", { "userName": userName }, function (data) {


                    });

                } else {
                    $("#spanUserName").css("display", "block");
                    $("#spanUserName").text("用户名不能为空");
                }
            });




        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div style="font-size:small">
  <table width="80%" height="22" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td style="width: 10px"><img src="../Images/az-tan-top-left-round-corner.gif" width="10" height="28" /></td>
    <td bgcolor="#DDDDCC"><span class="STYLE1">注册新用户</span></td>
    <td width="10"><img src="../Images/az-tan-top-right-round-corner.gif" width="10" height="28" /></td>
  </tr>
</table>


<table width="80%" height="22" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td width="2" bgcolor="#DDDDCC">&nbsp;</td>
    <td><div align="center">
      <table height="61" cellpadding="0" cellspacing="0" style="height: 332px">
        <tr>
          <td height="33" colspan="6"><p class="STYLE2" style="text-align: center">注册新帐户方便又容易</p></td>
        </tr>
        <tr>
          <td width="24%" align="center" valign="top" style="height: 26px">用户名</td>
          <td valign="top" width="37%" align="left" style="height: 26px">
             <input type="text" name="txtName" id="userName"/><span id="spanUserName"></span></td>          
        </tr>
        <tr>
          <td width="24%" height="26" align="center" valign="top">真实姓名：</td>
          <td valign="top" width="37%" align="left">
              <input type="text" name="txtRealName" id="userRealName"/></td>          
        </tr>
        <tr>
          <td width="24%" height="26" align="center" valign="top">密码：</td>
          <td valign="top" width="37%" align="left">
               <input type="password" name="txtPwd" id="userPwd"/></td>          
        </tr>
        <tr>
          <td width="24%" height="26" align="center" valign="top">确认密码：</td>
          <td valign="top" width="37%" align="left">
               <input type="password" name="txtConfirmPwd" id="confirmPwd"/></td>          
        </tr>
         <tr>
          <td width="24%" height="26" align="center" valign="top">Email：</td>
          <td valign="top" width="37%" align="left">
               <input type="text" name="txtEmail" id="Email" /><span id="msg" style="font-size:14px;color:red"></span></td>          
        </tr>
        <tr>
          <td width="24%" height="26" align="center" valign="top">地址：</td>
          <td valign="top" width="37%" align="left">
              <input type="text" name="txtAddress" id="Address"/></td>          
        </tr>
        <tr>
          <td width="24%" height="26" align="center" valign="top">手机：</td>
          <td valign="top" width="37%" align="left">
              <input type="text" name="txtPhone" id="phone"/></td>          
        </tr>
        <tr>
          <td width="24%" align="center" valign="top" class="auto-style1">
              验证码：</td>
          <td valign="top" width="37%" align="left" class="auto-style1">
               <input type="text" name="txtCode" id="validateCode" /><img src="ValidateImageCode.ashx" id="ValidateCodeImg" /><a href="javascript:void(0)" id="validateCodeA">看不清换一张</a></td>          
        </tr>
        <tr>
          <td colspan="2" align="center"><input type="button" value="注册" class="regnow" id="btnRegister"/></td>           
        </tr>
        <tr>
          <td colspan="2" align="center">&nbsp;</td>           
        </tr>
      </table>
      <div class="STYLE5">---------------------------------------------------------</div>
    </div>	
    </td>
    <td width="2" bgcolor="#DDDDCC">&nbsp;</td>
  </tr>
</table>

<table width="80%" height="3" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td height="3" bgcolor="#DDDDCC"><img src="../Images/touming.gif" width="27" height="9" /></td>
  </tr>
</table>
</div>
</asp:Content>
