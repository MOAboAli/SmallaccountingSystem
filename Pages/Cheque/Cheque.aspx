<%@ Page Title="" Language="C#" MasterPageFile="~/BIMasterPage.Master" AutoEventWireup="true" CodeBehind="Cheque.aspx.cs" Inherits="BsolutionWebApp.Pages.Cheque" %>
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

    

      


  });
  </script>
    <div class="container">
  
        <table class="nav-justified">
            <tr>
                <td colspan="4">
                    
                   <h2> <label for="ex1">Cheque Page </label></h2>
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
                    Cheque No</label>
                        </div>
                    <div class="col-xs-8">
                        <asp:TextBox ID="TextChequeNo" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextChequeNo" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="Go">Required</asp:RequiredFieldValidator>
                        </div>

                </td>
                <td>

                     <div class="col-xs-4">
                         <label for="ex1">
                    Person In Charge
                    </label>
                         </div>
                     <div class="col-xs-8">
                        <asp:TextBox ID="TextPersonInCharge" runat="server" class="form-control" onkeypress="keypress()"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextPersonInCharge" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="Go">Required</asp:RequiredFieldValidator>
                         </div>
                          
                </td>
                <td></td>
                
            </tr>
            
            <tr>
                <td>&nbsp;</td>
                <td>
                   
                    &nbsp;</td>
                <td>

                     &nbsp;</td>
                <td>&nbsp;</td>
                
            </tr>
            
            <tr>
                <td>&nbsp;</td>
                <td>
                    

                    <div class="col-xs-4">
                        <label for="ex1">Date Of Cheque </label>
                        </div>
                    <div class="col-xs-8">
                         <asp:TextBox ID="datepicker" runat="server" class="form-control" ClientIDMode="Static"></asp:TextBox>
                        <%--<input type="text" id="datepicker" class="form-control"/>--%>
                        </div>

                </td>
                <td>
                      <div class="col-xs-4">
                       <label for="ex1">
                    Bank Name
                       </label>
                        </div>
                     <div class="col-xs-8">
                         <asp:DropDownList ID="ddBankName" runat="server"  AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Bank_Name" DataValueField="BankName_Id"></asp:DropDownList>
                         
                         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CMSConnectionString7 %>" SelectCommand="SELECT [BankName_Id], [Bank_Name] FROM [Bank_Name]"></asp:SqlDataSource>
                         
                        </div>
                </td>
                <td>&nbsp;</td>
            </tr>
            
            <tr>
                <td>&nbsp;</td>
                <td>
                     <div class="col-xs-4">
                       <label for="ex1">
                         Note
                             </label>
                        </div>
                     <div class="col-xs-8">
                         <asp:TextBox ID="TextBoxNote" runat="server" class="form-control" TextMode="MultiLine" Height="100"></asp:TextBox>

                        </div>



                    &nbsp;</td>
                <td>
                   

                     &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>

                </td>
                                <td>
                    
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                  


                    &nbsp;</td>
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
                <td>&nbsp;</td>
                <td>
                            
                         
                            <asp:Button ID="Successbtn" runat="server" Text="ADD" class="btn btn-success" OnClick="Successbtn_Click" ValidationGroup="Go" />

                            </td>
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
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="2">


               



                <asp:GridView ID="GridView1" runat="server" class="table table-striped">
                    <Columns>
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
