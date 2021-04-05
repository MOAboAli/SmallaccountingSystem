<%@ Page Title="" Language="C#" MasterPageFile="~/BIMasterPage.Master" AutoEventWireup="true" CodeBehind="AddItems.aspx.cs" Inherits="BsolutionWebApp.Pages.MasterDataPages.AddItems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    

      <style>
        .element {
                 @include float-left;
                }
    </style>
    <script src="../../Scripts/jquery-ui.js"></script>
    
    <script>
 
    

  $(document).ready(function () {
      $("#datepicker").datepicker({
         // dateFormat: 'dd-mm-yy'
      });

    //$('#TextBoxInvoiceno').attr("disabled", "disabled");
    
      


  });
  </script>
    <div class="container">
  
        <table class="nav-justified">
            <tr>
                <td colspan="6">
                    
                   <h2> <label for="ex1">Add Item Page </label></h2>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="2">&nbsp;</td>
                <td colspan="2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="2">
                    <asp:Label ID="Labelid" runat="server" Visible="False">0</asp:Label>
                    <asp:Label ID="Labelstatus" runat="server" Font-Bold="True" ForeColor="#FD9D74"></asp:Label>
                </td>
                <td colspan="2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="2">&nbsp;</td>
                <td colspan="2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="2">
                   
                    <div class="col-xs-4">
                         <label for="ex1" style="text-align:right;">
                         Item Type

                         </label>
                        </div>
                    <div class="col-xs-8">
                        <asp:DropDownList ID="DropDownListitem" runat="server" class="form-control" DataTextField="name" DataValueField="ID" Width="322px"></asp:DropDownList>
                        </div>

                </td>
                <td colspan="2">

                     <div class="col-xs-4">
                         <label for="ex1">
                         Name
                    </label>
                         </div>
                     <div class="col-xs-8">
                          <asp:TextBox ID="TextBoxName" runat="server" class="form-control" ClientIDMode="Static"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxName" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="Go">Required</asp:RequiredFieldValidator>
                       
                        </div>
                          
                </td>
                <td></td>
                
            </tr>
            
            <tr>
                <td>&nbsp;</td>
                <td colspan="2">
                   
                    &nbsp;</td>
                <td colspan="2">

                     &nbsp;</td>
                <td>&nbsp;</td>
                
            </tr>
            
            <tr>
                <td>&nbsp;</td>
                <td colspan="2">
                    

                    <div class="col-xs-4">
                        <label for="ex1">Price</label>
                        </div>
                    <div class="col-xs-8">
                         <asp:TextBox ID="textboxprice" runat="server" class="form-control" ClientIDMode="Static"></asp:TextBox>
                        <%--<input type="text" id="datepicker" class="form-control"/>--%>
                        </div>

                </td>
                <td colspan="2">
                   

                    <div class="col-xs-4">
                        <label for="ex1">
                        Has Stock
                    </label>
                        </div>
                     <div class="col-xs-8">
                         <asp:CheckBox ID="CheckBoxhasstock" runat="server" />
                        </div>




                </td>
                <td>&nbsp;</td>
            </tr>
            
            <tr>
                <td>&nbsp;</td>
                <td colspan="2">
                    

                    &nbsp;</td>
                <td colspan="2">
                   

                     &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            
            <tr>
                <td>&nbsp;</td>
                <td colspan="2">
                    
                    <div class="col-xs-4">
                         <label for="ex1" style="text-align:right;">
                         Cost 

                         </label>
                        </div>
                    <div class="col-xs-8">
                          <asp:TextBox ID="TextBoxcost" runat="server" class="form-control" ClientIDMode="Static"></asp:TextBox>
                        </div>
                    
                
                </td>
                 <td colspan="2">

                     <div class="col-xs-4">
                         <label for="ex1">
                         Qauntity
                    </label>
                         </div>
                     <div class="col-xs-8">
                          <asp:TextBox ID="TextBoxquantity" runat="server" class="form-control" ClientIDMode="Static"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxquantity" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="Go">Required</asp:RequiredFieldValidator>
                       
                        </div>
                          
                </td>
                <td>&nbsp;</td>
            </tr>
            
            <tr>
                <td>&nbsp;</td>
                <td colspan="2">
                    

                    &nbsp;</td>
                <td colspan="2">
                   

                     &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="2">
                  


                    <div class="col-xs-4">
                        <label for="ex1">
                        Detials
                    </label>
                        </div>
                    <div class="col-xs-8">
                         <asp:TextBox ID="TextBoxDetials" runat="server" class="form-control" Height="99px" TextMode="MultiLine" Width="386px"></asp:TextBox>
                        </div>



                </td>
              
                <td>&nbsp;</td>
            </tr>
           
            <tr>
                <td>&nbsp;</td>
                <td colspan="2">&nbsp;</td>
                <td colspan="2">
                         <asp:Button ID="Successbtn" runat="server" Text="ADD" class="btn btn-success" OnClick="Successbtn_Click" ValidationGroup="Go" />
                     </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="2">&nbsp;</td>
                <td colspan="2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="4">


               



                 <asp:GridView ID="GridView1" runat="server" class="table table-striped">
                     <Columns>
                         <asp:TemplateField ShowHeader="False">
                             <ItemTemplate>
                                 <asp:Button ID="ButtonEdit" runat="server" CausesValidation="false" Text="Edit" OnClick="EditGrid_Click"  CommandName='<%#Eval("ID") %>' />
                             </ItemTemplate>
                             <ControlStyle CssClass="btn btn-warning" />
                         </asp:TemplateField>
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
                <td colspan="2">&nbsp;</td>
                <td colspan="2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
  
     </div>


</asp:Content>
