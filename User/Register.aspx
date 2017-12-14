<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="User_Register" %>

<%@ Register Src="~/Views/Register.ascx" TagPrefix="uc1" TagName="Register" %>
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
            <uc1:Register runat="server" ID="Register" />
        </div>

        <div style="bottom: 0;position: absolute;width: 100%;">
            <uc1:Footer runat="server" ID="Footer1" />
        </div>
    </form>
</body>
</html>
