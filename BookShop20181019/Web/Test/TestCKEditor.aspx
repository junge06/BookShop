<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestCKEditor.aspx.cs" Inherits="BookShop20181019.Web.Test.TestCKEditor" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../ckeditor/ckeditor.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <textarea cols="100" id="editor1" name="editor1"></textarea>
        <script type="text/javascript">
            var editor = CKEDITOR.replace('editor1');
        </script>
        <input type="submit"  value="提交" />
    
    </div>
    </form>
</body>
</html>
