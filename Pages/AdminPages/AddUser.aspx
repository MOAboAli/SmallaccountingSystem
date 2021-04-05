<%@ Page Title="" Language="C#" MasterPageFile="~/BIMasterPage.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="BsolutionWebApp.Pages.AdminPages.AddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="nav-justified">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
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
                        <asp:TextBox ID="TextBoxusername" runat="server" class="form-control" Width="342px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxusername" ErrorMessage="RequiredFieldValidator" ValidationGroup="uu">Required</asp:RequiredFieldValidator>
                        </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="Label6" runat="server" Text="Password"></asp:Label>
            </td>
            <td style="text-align: left">
                        <asp:TextBox ID="TextBoxPaswword" runat="server" class="form-control" Width="319px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPaswword" ErrorMessage="RequiredFieldValidator" ValidationGroup="uu">Required</asp:RequiredFieldValidator>
                        </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="Label7" runat="server" Text="ISDisable"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:CheckBox ID="CheckBoxisdisable" runat="server" Text="Yes" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="Label8" runat="server" Text="ISAdmin"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:CheckBox ID="CheckBoxisadmin" runat="server" Text="Yes" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="text-align: left">                            
                         
                            <asp:Button ID="Successbtn" runat="server" Text="ADD" class="btn btn-success" OnClick="Successbtn_Click" ValidationGroup="uu" />

                            </td>
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
                                <asp:Button ID="Buttonselect" runat="server" CausesValidation="false" Text="Select" OnClick="SelectGrid_Click"  CommandName='<%#Eval("ID") %>'  />
                            </ItemTemplate>
                            <ControlStyle CssClass="btn btn-warning" />
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="ButtonEdit" runat="server" CausesValidation="false" Text="Edit" OnClick="EditGrid_Click"  CommandName='<%#Eval("ID") %>' ValidationGroup="Go" />
                            </ItemTemplate>
                            <ControlStyle CssClass="btn btn-warning" />
                        </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>



                </td>
        </tr>
    </table>
</asp:Content>
