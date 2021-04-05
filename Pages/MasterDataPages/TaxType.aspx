<%@ Page Title="" Language="C#" MasterPageFile="~/BIMasterPage.Master" AutoEventWireup="true" CodeBehind="TaxType.aspx.cs" Inherits="BsolutionWebApp.Pages.MasterDataPages.TaxType" %>
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
            <td colspan="4">  <h2> <label for="ex1">Tax Type Page </label></h2></td>
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
                    Tax Type Name</label>
                        </div>
                <div class="col-xs-8">
                        <asp:TextBox ID="TextBoxTaxType" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxTaxType" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="Go">Required</asp:RequiredFieldValidator>
                        </div>

            </td>
            <td> </td>
            <td>&nbsp;</td>
        </tr>
       <tr>

           <td>&nbsp;</td>
           <td>
               <div class="col-xs-4">
                         <label for="ex1">Percentage</label>
                         </div>
                 <div class="col-xs-8">
                     <asp:TextBox ID="TextBoxPercentage" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPercentage" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="Go">Required</asp:RequiredFieldValidator>
                                 </div></td>
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
