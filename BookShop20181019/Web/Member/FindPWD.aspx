<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="FindPWD.aspx.cs" Inherits="BookShop20181019.Web.Member.FindPWD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">

    <script type="text/javascript">
        $(function () {
            findPWD();
        });

        function findPWD() {
            var userName = $("#txtName").val();
            var userEmail = $("#txtEmail").val();
            if (userName!=""&&userEmail!="") {
                $.post("ashx/FindPWD.ashx",{"name":userName,"email":userEmail}, function (data) {

                });
            }

        }

    </script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table>
        <tr>
            <td>用户名</td>
            <td>
                <input type="text" name="txtUserName" id="txtName" value="" /></td>
        </tr>

         <tr>
            <td>邮箱</td>
            <td>
                <input type="text" name="txtEmail" id="txtEmail" value="" /></td>
        </tr>

        <tr>
            <td colspan="2">
                <input type="button" name="txtFindPWD" value="找回密码" id="btnFindPWD"/></td>
        </tr>
    </table>


</asp:Content>
