<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="BookShop20181019.Web.Books.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		Id
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Title
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTitle" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Author
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAuthor" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PublisherId
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPublisherId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PublishDate
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPublishDate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ISBN
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblISBN" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		WordsCount
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblWordsCount" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		UnitPrice
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUnitPrice" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ContentDescription
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblContentDescription" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		AurhorDescription
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAurhorDescription" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		EditorComment
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblEditorComment" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TOC
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTOC" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CategoryId
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCategoryId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Clicks
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblClicks" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




