<%@ Page Title="" Language="C#" MasterPageFile="~/Views/UserPage.master" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
<br />
            <asp:Button ID="Button1" runat="server" Text="局部更新" OnClick="Button1_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
</asp:Content>

