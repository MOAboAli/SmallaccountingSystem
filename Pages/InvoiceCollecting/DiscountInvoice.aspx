<%@ Page Title="" Language="C#" MasterPageFile="~/BIMasterPage.Master" AutoEventWireup="true" CodeBehind="DiscountInvoice.aspx.cs" Inherits="BsolutionWebApp.Pages.InvoiceCollecting.DiscountInvoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    

    
      <style>
        .element {
                 @include float-left;
                }
          .auto-style1 {
              height: 20px;
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
                    
                   <h2> <label for="ex1">Discount Invoice</label></h2>
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
                </td>
                <td colspan="2">
                            
                         
                            <asp:Button ID="SuccessbtnInvoice" runat="server" Text="Return Invoice" class="btn btn-success" OnClick="SuccessbtnInvoice_Click" />

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
                <td colspan="2">
                   
                    <div class="col-xs-4">
                         <label for="ex1" style="text-align:right;">
                         Discount Percentage
                         </label>
                        </div>
                    <div class="col-xs-8">
                         <asp:TextBox ID="TextBoxdpercentage" runat="server" class="form-control" ClientIDMode="Static" Text="0"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxdpercentage" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="Go">Required</asp:RequiredFieldValidator>
                       
                        </div>

                </td>
                <td colspan="2">

                     <div class="col-xs-4">
                         <label for="ex1">
                         Discount Amount
                    </label>
                         </div>
                     <div class="col-xs-8">
                          <asp:TextBox ID="TextBoxdamount" runat="server" class="form-control" ClientIDMode="Static" Text="0"></asp:TextBox>
                       
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
                        <label for="ex1">Date</label>
                        </div>
                    <div class="col-xs-8">
                         <asp:TextBox ID="datepicker" runat="server" class="form-control" ClientIDMode="Static"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="datepicker" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="Go">Required</asp:RequiredFieldValidator>
                        <%--<input type="text" id="datepicker" class="form-control"/>--%>
                        </div>

                        
                       
                </td>
                <td colspan="2">
                   

                   




                    <div class="col-xs-4">
                        <label for="ex1">
                        Note
                        </label>
                    </div>
                    <div class="col-xs-8">
                        <asp:CheckBox ID="CheckBoxcollecting" runat="server" Text="Collecting" />
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
                <td>
                            
                         
                            &nbsp;</td>
                <td>
                            
                         
                            &nbsp;</td>
                <td>
                            
                         
                            &nbsp;</td>
                <td>
                            
                         
                            &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="2">
                    <div class="col-xs-4">
                        <label for="ex1">
                        Note
                        </label>
                    </div>
                    <div class="col-xs-8">
                        <asp:TextBox ID="TextBoxNote0" runat="server" class="form-control" Height="47px" TextMode="MultiLine" Width="196px"></asp:TextBox>
                    </div>
                </td>
                <td colspan="2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="2">&nbsp;</td>
                <td colspan="2">
                            
                         
                            <asp:Button ID="Successbtnsave" runat="server" Text="Save" class="btn btn-success" OnClick="Successbtn_Click" ValidationGroup="Go" />

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
                <td colspan="2">&nbsp;</td>
                <td colspan="2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1"></td>
                <td colspan="4" class="auto-style1">


               



                <asp:GridView ID="GridView1" runat="server" class="table table-striped">
                    <Columns>
                        
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="ButtonDelete" runat="server" CausesValidation="false" Text="Delete" OnClick="DeleteGrid_Click"  CommandName='<%#Eval("ID") %>'/>
                            </ItemTemplate>
                            <ControlStyle CssClass="btn btn-danger" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>



                </td>
                <td class="auto-style1"></td>
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
