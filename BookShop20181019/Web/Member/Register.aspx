<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BookShop20181019.Web.Member.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <style>

    .regnow {
	width:300px;
	margin-left:30px;
	height:40px;
	background:#db2f2f;
	border:none;
	color: #FFF;
	font-size: 15px;
	font-weight: 700;
    cursor:pointer; 
}
    </style>
    <script type="text/javascript">
        window.onload = function () {
            var validateCode = document.getElementById("validateCodeA");
            validateCode.onclick = function () {
                document.getElementById("ValidateCodeImg").src = "validateImageCode.ashx?d=" + new Date().getMilliseconds();
            }
        }
        $(function () {
            $("#userName").blur(function () {
                validateUserName();
            });

            $("#userPwd").blur(function () {
                validateUserPwd();
            });
            $("#confirmPwd").blur(function () {
                validateConfirmPwd();
            });

            $("#email").blur(function () {
                validateEmail();
            });

            $("#validateCode").blur(function() {
                validateImageCode();
            });

            $("#btnRegister").click(function () {
                validateUserName();
                validateUserPwd();
                validateConfirmPwd();
                validateEmail();
                validateImageCode();

                var pai = $("#aspnetForm").serialize();
                $.post("ashx/Register.ashx", {"pai":pai}, function(data) {

                });


            });

        });


        //验证用户名
        function validateUserName() {
            var userName = $("#userName").val();
            if (userName != "") {
                var reg = /^[a-zA-Z0-9_-]{4,16}$/;
                if (reg.test(userName)) {
                    $("#spanUserName").css("display", "none");
                    $.post("ashx/ValidateReg.ashx", { "action": "userName", "uName": userName }, function (data) {
                        $("#spanUserName").css("display", "block");
                        $("#spanUserName").text(data);
                    });
                } else {
                    $("#spanUserName").text("用户名格式不正确");
                }
            } else {
                $("#spanUserName").text("用户名不可为空");
            }
        }


        //校验密码
        function validateUserPwd() {
            var userPwd = $("#userPwd").val();

            if (userPwd != "") {
                $("#spanPwd").css("display", "none");

            } else {
                $("#spanPwd").text("密码不可为空");
            }
        }
        //校验确认密码
        function validateConfirmPwd() {
            var userPwd = $("#userPwd").val();
            var confirmPwd = $("#confirmPwd").val();
            if (confirmPwd != "" && confirmPwd == userPwd) {
                $("#spanConPwd").css("display", "none");

            } else {
                $("#spanConPwd").text("确认密码与密码不一致");
            }
        }

        //验证邮箱
        function validateEmail() {
            var email = $("#email").val();
            if (email != "") {
                var reg = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
                if (reg.test(email)) {
                    $("#msg").css("display", "none");
                    $.post("ashx/ValidateReg.ashx", { "action": "email", "userEmail": email }, function (data) {
                        $("#msg").css("display", "block");
                        $("#msg").text(data);
                    });
                } else {
                    $("#msg").text("邮箱格式错误");
                }

            } else {
                $("#msg").text("邮箱不能为空");
            }

        }

        //校验验证码
        function validateImageCode() {
            var validateCode = $("#validateCode").val();
            if (validateCode != "") {
                var reg = /^[0-9]*$/;
                if (reg.test(validateCode)) {
                    $("#codeMsg").css("display", "none");
                    $.post("ashx/ValidateReg.ashx", { "action": "code", "validateCode": validateCode }, function (data) {
                        $("#codeMsg").css("display", "block")
                        $("#codeMsg").text(data);
                    });

                } else {
                    $("#codeMsg").text("验证码格式错误");
                }

            } else {
                $("#codeMsg").text("验证码不能为空");
            }

        }

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
             <input type="text" name="txtName" id="userName"/><span id="spanUserName" style="font-size:14px;color:red"></span></td>          
        </tr>
        <tr>
          <td width="24%" height="26" align="center" valign="top">真实姓名：</td>
          <td valign="top" width="37%" align="left">
              <input type="text" name="txtRealName"/></td>          
        </tr>
        <tr>
          <td width="24%" height="26" align="center" valign="top">密码：</td>
          <td valign="top" width="37%" align="left">
               <input type="password" name="txtPwd" id="userPwd"/><span id="spanPwd" style="font-size:14px;color:red"></span></td>          
        </tr>
        <tr>
          <td width="24%" height="26" align="center" valign="top">确认密码：</td>
          <td valign="top" width="37%" align="left">
               <input type="password" name="txtConfirmPwd" id="confirmPwd"/><span id="spanConPwd" style="font-size:14px;color:red"></span></td>          
        </tr>
         <tr>
          <td width="24%" height="26" align="center" valign="top">Email：</td>
          <td valign="top" width="37%" align="left">
               <input type="text" name="txtEmail" id="email" /><span id="msg" style="font-size:14px;color:red"></span></td>          
        </tr>
        <tr>
          <td width="24%" height="26" align="center" valign="top">地址：</td>
          <td valign="top" width="37%" align="left">
              <input type="text" name="txtAddress"/></td>          
        </tr>
        <tr>
          <td width="24%" height="26" align="center" valign="top">手机：</td>
          <td valign="top" width="37%" align="left">
              <input type="text" name="txtPhone"/></td>          
        </tr>
        <tr>
          <td width="24%" align="center" valign="top" class="auto-style1">
              验证码：</td>
          <td valign="top" width="37%" align="left" class="auto-style1">
               <input type="text" name="txtCode" id="validateCode" /><span id="codeMsg" style="font-size:14px;color:red"></span>
              <img src="ValidateImageCode.ashx" id="ValidateCodeImg"/>
              <a href="javascript:void(0)" id="validateCodeA">看不清换一张</a></td>         
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
