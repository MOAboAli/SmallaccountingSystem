<%@ Page Title="" Language="C#" MasterPageFile="~/BIMasterPage.Master" AutoEventWireup="true" CodeBehind="PageAccess.aspx.cs" Inherits="BsolutionWebApp.Pages.AdminPages.PageAccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="nav-justified">
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="Label5" runat="server" Text="UserName"></asp:Label>
            </td>
            <td style="text-align: left">
                       
                         <asp:DropDownList ID="DropDownList1" runat="server"  class="form-control" DataValueField="ID" DataTextField="Name" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                         </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="Label6" runat="server" Text="Page"></asp:Label>
            </td>
            <td style="text-align: left">
                       
                         <asp:DropDownList ID="DropDownList2" runat="server"  class="form-control" DataValueField="ID" DataTextField="Name"></asp:DropDownList>
                         </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="text-align: left">                            
                         
                            <asp:Button ID="Successbtn" runat="server" Text="ADD" class="btn btn-success" OnClick="Successbtn_Click" ValidationGroup="Go" />

                            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">


               



                <asp:GridView ID="GridView1" runat="server" class="table table-striped" Width="1181px">
                    <Columns>
                       
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="ButtonEdit" runat="server" CausesValidation="false" Text="Delete" OnClick="EditGrid_Click"  CommandName='<%#Eval("ID") %>' ValidationGroup="Go" />
                            </ItemTemplate>
                            <ControlStyle CssClass="btn btn-warning" />
                        </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>



                </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
