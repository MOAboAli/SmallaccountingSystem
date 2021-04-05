<%@ Page Title="" Language="C#" MasterPageFile="~/BIMasterPage.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="BsolutionWebApp.Pages.ContactPages.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .element {
                 @include float-left;
                }
    </style>

      <div class="container">
    <table class="nav-justified">
        <tr>
            <td colspan="4">  <h2> <label for="ex1">Contact Page </label></h2></td>
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
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td> 
                <div class="col-xs-4">
                         <label for="ex1" style="text-align:right;">
                    Contact Name</label>
                        </div>
                    <div class="col-xs-8">
                        <asp:TextBox ID="TextBoxContactName" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxContactName" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="Go">Required</asp:RequiredFieldValidator>
                        </div>

            </td>
            <td> <div class="col-xs-4">
                         <label for="ex1">
                    mobile
                    </label>
                         </div>
                     <div class="col-xs-8">
                        <asp:TextBox ID="TextBoxmobile" runat="server" class="form-control" onkeypress="keypress()"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxmobile" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="Go">Required</asp:RequiredFieldValidator>
                         </div></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td> 
                <div class="col-xs-4">
                         <label for="ex1" style="text-align:right;">
                    Phone </label>
                        </div>
                    <div class="col-xs-8">
                        <asp:TextBox ID="TextBoxphone" runat="server" class="form-control"></asp:TextBox>
                        </div>

            </td>
            <td> <div class="col-xs-4">
                         <label for="ex1">
                    Location
                    </label>
                         </div>
                     <div class="col-xs-8">
                        <asp:TextBox ID="TextBoxlocation" runat="server" class="form-control" onkeypress="keypress()"></asp:TextBox>
                        
                         </div></td>
            <td><br /></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td> 
                <div class="col-xs-4">
                         <label for="ex1" style="text-align:right;">
                    Website </label>
                        </div>
                    <div class="col-xs-8">
                        <asp:TextBox ID="TextBoxwebsite" runat="server" class="form-control"></asp:TextBox>
                        </div>

            </td>
            <td> <div class="col-xs-4">
                         <label for="ex1">
                    Contact Type
                    </label>
                         </div>
                     <div class="col-xs-8">
                       
                         <asp:DropDownList ID="DropDownList1" runat="server"  class="form-control" DataValueField="Contat_T_Id" DataTextField="Contat_T_Name"></asp:DropDownList>
                         </div></td>
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
            <td> 
                <div class="col-xs-4">
                         <label for="ex1" style="text-align:right;">
                    PersonInChargeName </label>
                        </div>
                    <div class="col-xs-8">
                        <asp:TextBox ID="TextBoxpicname" runat="server" class="form-control"></asp:TextBox>
                        </div>

            </td>
            <td> <div class="col-xs-4">
                         <label for="ex1">
                    PersonInChargephone
                    </label>
                         </div>
                     <div class="col-xs-8">
                        <asp:TextBox ID="TextBoxpicphone" runat="server" class="form-control" onkeypress="keypress()"></asp:TextBox>
                        
                         </div></td>
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
             <td> 
                <div class="col-xs-4">
                         <label for="ex1" style="text-align:right;">
                    Note </label>
                        </div>
                    <div class="col-xs-8">
                        <asp:TextBox ID="TextBoxNote" runat="server" class="form-control" TextMode="MultiLine" Height="150px"></asp:TextBox>
                        </div>

            </td>
            <td>                            
                         
                            &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>                            
                         
                            <asp:Button ID="Successbtn" runat="server" Text="ADD" class="btn btn-success" OnClick="Successbtn_Click" ValidationGroup="Go" />

                            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">


               



                <asp:GridView ID="GridView1" runat="server" class="table table-striped">
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
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="ButtonDelete" runat="server" CausesValidation="false" Text="Delete" OnClick="DeleteGrid_Click"  CommandName='<%#Eval("ID") %>'/>
                            </ItemTemplate>
                            <ControlStyle CssClass="btn btn-danger" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>



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
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
          </div>
</asp:Content>
