<%@ Page Title="" Language="C#" MasterPageFile="~/Views/UserInfoPage.master" AutoEventWireup="true" CodeFile="MyDraft.aspx.cs" Inherits="User_MyDraft" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <asp:Repeater ID="Repeater_Draft" runat="server" OnItemCommand="Repeater_Draft_ItemCommand" OnItemDataBound="Repeater_Draft_ItemDataBound" >
        <HeaderTemplate>
            <table style="width: 90%;  margin: 10px auto; border-spacing: 0;">
                <thead>
                    <tr style="height: 40px; background: #dfdfdf; color: #042532;">
                        <th style="width:40%; text-align: left; padding-left: 15px;">标题</th>
                        <th>类型</th>
                        <th>标签</th>
                        <th>上次修改时间</th>
                        <th>操作</th>
                    </tr>
                </thead>           
        </HeaderTemplate>

        <ItemTemplate>
            <asp:Panel ID="plItem" runat="server">
                
                    <tr style="height: 40px; text-align: center; color: #696868;">
                        <td style="padding-left: 15px;text-align: left;border-bottom: 1px solid #c5c5c5;">
                            <asp:Label ID="lTitle" runat="server" Text='<%#Eval("Title") %>' ForeColor="#0066ff"></asp:Label>
                        </td>
                        <td style="border-bottom: 1px solid #c5c5c5; "><%#Eval("Type") %></td>
                        <td style="border-bottom: 1px solid #c5c5c5; "><%#Eval("Tag") %></td>
                        <td style="border-bottom: 1px solid #c5c5c5; "><%#Eval("create_time") %></td>
                        <td style="border-bottom: 1px solid #c5c5c5; ">
                            <asp:LinkButton ID="lbtEdit" runat="server" Font-Underline="false" ForeColor="#009933"
                                CommandName="Edit" CommandArgument='<%#Eval("ID") %>'>编辑</asp:LinkButton>
                            <asp:LinkButton ID="lbtDelete" runat="server" Font-Underline="false" ForeColor="#ff0000"
                                CommandName="Delete" CommandArgument='<%#Eval("ID") %>'>删除</asp:LinkButton>
                        </td>
                    </tr>              
            </asp:Panel>
        </ItemTemplate>

        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>

