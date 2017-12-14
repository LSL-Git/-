<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="User_Login" %>

<%@ Register Src="~/Views/Login.ascx" TagPrefix="uc1" TagName="Login" %>
<%@ Register Src="~/Views/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:Login runat="server" ID="Login" />            
        </div>

        <div style="bottom: 0;position: absolute;width: 100%;">
            <uc1:Footer runat="server" ID="Footer" />
        </div>
    </form>
</body>
</html>
