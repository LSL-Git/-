<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" ValidateRequest="false"
    CodeFile="CheckArticle.aspx.cs" Inherits="Admin_CheckArticle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 90%;  margin: 0 auto;">
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" DataSourceID="AccessDataSource1" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="UserID" HeaderText="用户ID" SortExpression="UserID" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                <asp:BoundField DataField="Tag" HeaderText="Tag" SortExpression="Tag" />
                <asp:BoundField DataField="Pub_Time" HeaderText="Pub_Time" SortExpression="Pub_Time" />
                <asp:BoundField DataField="Jurisdiction" HeaderText="Jurisdiction" SortExpression="Jurisdiction" />
                <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/BBSdb.accdb" DeleteCommand="DELETE FROM [Article] WHERE [ID] = ?" InsertCommand="INSERT INTO [Article] ([UserID], [Title], [Type], [Tag], [Pub_Time], [Jurisdiction], [State], [ID]) VALUES (?, ?, ?, ?, ?, ?, ?, ?)" SelectCommand="SELECT [UserID], [Title], [Type], [Tag], [Pub_Time], [Jurisdiction], [State], [ID] FROM [Article] WHERE [Jurisdiction] = '待审核'" UpdateCommand="UPDATE [Article] SET [UserID] = ?, [Title] = ?, [Type] = ?, [Tag] = ?, [Pub_Time] = ?, [Jurisdiction] = ?, [State] = ? WHERE [ID] = ?">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="UserID" Type="Int32" />
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="Type" Type="String" />
            <asp:Parameter Name="Tag" Type="String" />
            <asp:Parameter Name="Pub_Time" Type="DateTime" />
            <asp:Parameter Name="Jurisdiction" Type="String" />
            <asp:Parameter Name="State" Type="String" />
            <asp:Parameter Name="ID" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="UserID" Type="Int32" />
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="Type" Type="String" />
            <asp:Parameter Name="Tag" Type="String" />
            <asp:Parameter Name="Pub_Time" Type="DateTime" />
            <asp:Parameter Name="Jurisdiction" Type="String" />
            <asp:Parameter Name="State" Type="String" />
            <asp:Parameter Name="ID" Type="Int32" />
        </UpdateParameters>
    </asp:AccessDataSource>

    

    </div>
</asp:Content>

