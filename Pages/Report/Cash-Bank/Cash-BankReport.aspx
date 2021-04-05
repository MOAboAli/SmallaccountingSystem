<%@ Page Title="" Language="C#" MasterPageFile="~/BIMasterPage.Master" AutoEventWireup="true" CodeBehind="Cash-BankReport.aspx.cs" Inherits="BsolutionWebApp.Pages.Report.Cash_Bank.Cash_BankReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 32px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="nav-justified">
        <tr>
            <td colspan="4" style="text-align: left">
                <asp:Label ID="Label3" runat="server" Text="Cash-Bank Report"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="text-align: right">
                <asp:Label ID="Label4" runat="server" Text="BankORCash"></asp:Label>
            </td>
            <td style="text-align: left">
                    <asp:DropDownList ID="DropDownListbankcash" runat="server" AutoPostBack="True" class="form-control" DataTextField="name" DataValueField="ID" OnSelectedIndexChanged="DropDownListbankcash_SelectedIndexChanged" Width="200px">
                        <asp:ListItem Value="0">Bank</asp:ListItem>
                        <asp:ListItem Value="1">Cash</asp:ListItem>
                    </asp:DropDownList>
                </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style1" style="text-align: right">
                <asp:Label ID="Labelbankcash" runat="server"></asp:Label>
            </td>
            <td class="auto-style1" style="text-align: left">
                    <asp:DropDownList ID="DropDownListbankcashtype" runat="server" class="form-control" DataTextField="name" DataValueField="ID" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="DropDownListbankcashtype_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td style="text-align: left">
                <asp:Label ID="Labelstatus" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="2" style="text-align: left">
                    <asp:GridView ID="GridView1" runat="server" class="table table-striped" Width="1256px">
                        <Columns>
                           <%-- <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="Buttonselect" runat="server" CausesValidation="false" CommandName='<%#Eval("ID") %>' OnClick="selectGrid_Click" Text="Select" />
                                </ItemTemplate>
                                <ControlStyle CssClass="btn btn-danger" />
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="ButtonEdit" runat="server" CausesValidation="false" CommandName='<%#Eval("ID") %>' OnClick="EditGrid_Click" Text="Edit" />
                                </ItemTemplate>
                                <ControlStyle CssClass="btn btn-warning" />
                            </asp:TemplateField>--%>
                         <%--<asp:TemplateField ShowHeader="False">
                             <ItemTemplate>
                                 <asp:Button ID="ButtonDelete" runat="server" CausesValidation="false" Text="Delete" OnClick="DeleteGrid_Click"  CommandName='<%#Eval("ID") %>'/>
                             </ItemTemplate>
                             <ControlStyle CssClass="btn btn-danger" />
                         </asp:TemplateField>--%>
                                    </Columns>
                    </asp:GridView>
                </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
