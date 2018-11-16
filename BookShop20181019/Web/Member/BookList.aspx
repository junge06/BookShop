<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true"
    CodeBehind="BookList.aspx.cs" Inherits="BookShop20181019.Web.Member.BookList" EnableViewState="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <link href="../Css/pageBarStyle.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Repeater ID="BookListRepeater" runat="server">
        <ItemTemplate>
            <table>
                <tbody>
                    <tr>
                        <td rowspan="2"><a
                            href="<%#Eval("Id","/BookDetail_{0}.aspx?") %>">
                            <img
                                id="ctl00_cphContent_dl_Books_ctl01_imgBook"
                                style="CURSOR: hand" height="121"
                                alt="<%#Eval("Title") %>" hspace="4"
                                src="<%#Eval("ISBN","/Images/BookCovers/{0}.jpg") %>" width="95"></a>
                        </td>
                        <td style="FONT-SIZE: small; COLOR: red" width="650"><a
                            class="booktitle" id="link_prd_name"
                            href="<%#GetString(Eval("PublishDate"))%><%#Eval("Id")%>.html" target="_blank"
                            name="link_prd_name"><%#Eval("Title") %></a>
                        </td>
                    </tr>
                    <tr>
                        <td align="left"><span
                            style="FONT-SIZE: 12px; LINE-HEIGHT: 20px"><%#Eval("Author") %></span><br>
                            <br>
                            <span
                                style="FONT-SIZE: 12px; LINE-HEIGHT: 20px"><%#this.CutString(Eval("ContentDescription").ToString(),150)%></span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2"><span
                            style="FONT-WEIGHT: bold; FONT-SIZE: 13px; LINE-HEIGHT: 20px">&yen; 
                        <%#Eval("UnitPrice","{0:0.00}") %></span> </td>
                    </tr>
                </tbody>
            </table>
        </ItemTemplate>
        <SeparatorTemplate>
            <hr />
        </SeparatorTemplate>
    </asp:Repeater>
    <div class="page_nav">
        <%=Common.PageBarHelper.GetPagaBar(PageIndex,PageCount) %>
    </div>

</asp:Content>
