<%@ Page Title="" Language="C#" MasterPageFile="~/BIMasterPage.Master" AutoEventWireup="true" CodeBehind="Scripts.aspx.cs" Inherits="BsolutionWebApp.Pages.Report.general.Scripts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>

        button, input, optgroup, select, textarea 
        {
         color: black; 
        }

        .intro-header
        {
            color: black;
        }
    </style>
    <table class="nav-justified">
        <tr>
            <td colspan="6">
                <asp:Label ID="Label3" runat="server" style="font-size: large; color: #000000" Text="Report Scripts"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td colspan="3">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td colspan="3">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td colspan="3">
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="Label6" runat="server" style="color: #000000" Text="Name"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownListname" runat="server" AutoPostBack="True" DataTextField="name" DataValueField="id" Height="16px" OnSelectedIndexChanged="DropDownListname_SelectedIndexChanged" Width="362px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" style="color: #000000" Text="Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxName" runat="server" Width="356px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td colspan="3">
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td colspan="3">
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="Label5" runat="server" style="color: #000000" Text="Query"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="TextBoxquery" runat="server" Height="238px" TextMode="MultiLine" Width="1031px"></asp:TextBox>
                <asp:Button ID="Buttonshow" runat="server" OnClick="Buttonshow_Click" Text="Test" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td colspan="3">
                <asp:Button ID="Buttonadd" runat="server" OnClick="Buttonadd_Click" Text="Add" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Buttonedit" runat="server" OnClick="Buttonedit_Click" Text="Edit" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td colspan="3">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="5">
                <asp:GridView ID="GridView1" runat="server" Width="1254px">
                </asp:GridView>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td colspan="3">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td colspan="3">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
