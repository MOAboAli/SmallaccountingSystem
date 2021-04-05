<%@ Page Title="" Language="C#" MasterPageFile="~/BIMasterPage.Master" AutoEventWireup="true" CodeBehind="AddExpenses.aspx.cs" Inherits="BsolutionWebApp.Pages.ExpensesPages.AddExpenses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        /*.element {
                 @include float-left;
                }*/
        .auto-style3 {
        }
        .auto-style4 {
            width: 164px;
            text-align: right;
        }
        .auto-style6 {
        }
        .auto-style7 {
            width: 87px;
        }
        </style>
    <script src="../../Scripts/jquery-ui.js"></script>
    
    <script>
 
    

  $(document).ready(function () {
      $("#TextBoxdate").datepicker({
         // dateFormat: 'dd-mm-yy'
      });

    //$('#TextBoxInvoiceno').attr("disabled", "disabled");
    
      
      $("#TextBoxunitcost").change(function () {
          
          var text1 = $("#TextBoxquantity").val();
          
          var text2=$("#TextBoxunitcost").val();
          var text = text1 * text2;
          $("#TextBoxtotal").val(text);
      });

      

      $("#TextBoxquantity").change(function () {

          var text1 = $("#TextBoxquantity").val();

          var text2 = $("#TextBoxunitcost").val();
          var text = text1 * text2;
          $("#TextBoxtotal").val(text);
      });

  });
  </script>


    <div class="container">



        <table class="nav-justified">
            <tr>
                <td colspan="6">
                    <asp:Label ID="Label3" runat="server" style="color: #FD9D74; font-size: large" Text="Expenses"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style6" colspan="5">
                    <asp:Label ID="Labelstatus" runat="server" style="color: #FF0000"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <label for="ex1" style="text-align:right;">
                    Expense Type</label></td>
                <td class="auto-style6">
                    <asp:DropDownList ID="DropDownListExpenseType" runat="server" class="form-control" DataTextField="name" DataValueField="ID" Width="200px">
                    </asp:DropDownList>
                        <a href="#" class="btn-link" class="btn-link" data-toggle="modal" data-target="#myModal2"><span class="glyphicon glyphicon-inbox"></span></a>
                </td>
                <td style="text-align: right">
                    <label for="ex1" style="text-align:right;">
                    Expenses No.</label></td>
                <td>
                    <asp:TextBox ID="TextBoxExpensesNo" runat="server" CssClass="form-control" Enabled="False" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxExpensesNo" ErrorMessage="RequiredFieldValidator" style="color: #FD9D74" ValidationGroup="go">Required</asp:RequiredFieldValidator>
                </td>
                <td style="text-align: right">
                    <label for="ex1" style="text-align:right;">
                    Date</label></td>
                <td>
                    <asp:TextBox ID="TextBoxdate" runat="server" class="form-control" ClientIDMode="Static" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxdate" ErrorMessage="RequiredFieldValidator" style="color: #FD9D74" ValidationGroup="go">Required</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <label for="ex1">
                    Unit Cost</label></td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxunitcost" runat="server" class="form-control" ClientIDMode="Static" Width="200px">0</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxunitcost" ErrorMessage="RequiredFieldValidator" style="color: #FD9D74" ValidationGroup="go">Required</asp:RequiredFieldValidator>
                </td>
                <td style="text-align: right">
                    <label for="ex1" style="text-align:right;">
                    Quanitity</label></td>
                <td>
                    <asp:TextBox ID="TextBoxquantity" runat="server" class="form-control" ClientIDMode="Static" Width="200px">1</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxquantity" ErrorMessage="RequiredFieldValidator" style="color: #FD9D74" ValidationGroup="go">Required</asp:RequiredFieldValidator>
                </td>
                <td style="text-align: right">
                    <label for="ex1" style="text-align:right;">
                    Total
                    </label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxtotal" runat="server" ClientIDMode="Static" CssClass="form-control" Enabled="False" Width="200px">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <label for="ex1" style="text-align:right;">
                    From</label></td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxfrom" runat="server" class="form-control" Width="200px"></asp:TextBox>
                </td>
                <td style="text-align: right">
                    <label for="ex1" style="text-align:right;">
                    Bank/Cash
                    </label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListbankcash" runat="server" AutoPostBack="True" class="form-control" DataTextField="name" DataValueField="ID" OnSelectedIndexChanged="DropDownListbankcash_SelectedIndexChanged" Width="200px">
                        <asp:ListItem Value="0">Bank</asp:ListItem>
                        <asp:ListItem Value="1">Cash</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="text-align: right">
                    <asp:Label ID="Labelbankcash" runat="server" style="color: #FD9D74"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListbankcashtype" runat="server" class="form-control" DataTextField="name" DataValueField="ID" Width="200px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <label for="ex1" style="text-align:right;">
                    Note</label></td>
                <td class="auto-style6">
                         <asp:TextBox ID="TextBoxNote" runat="server" class="form-control" TextMode="MultiLine" Height="100" Width="200px"></asp:TextBox>

                        </td>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="Successbtn" runat="server" class="btn btn-success" OnClick="Successbtn_Click" Text="ADD" ValidationGroup="go" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3" colspan="6">
                    <asp:GridView ID="GridView1" runat="server" class="table table-striped" Width="1256px">
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
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
            </tr>
            <tr>
                <td colspan="6">
                 
                  
                 
                </td>
            </tr>
        </table>



        </div>

    <div id="myModal2" class="modal fade in" role="dialog" >
        <div class="modal-dialog" style="padding: 30px;">
            <!-- Modal Content -->
            <div class="modal-content" style="width:150%">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &times</button>
                    <h4 class="modal-title" style="color:black">
                        Add Contact</h4>
                </div>
                <div class="modal-body">


                    <table class="nav-justified">
                        <tr>
                            <td> <asp:Label ID="Label2" runat="server" Text="Expenses Type" style="color:black"></asp:Label></td>
                            <td><asp:TextBox ID="TextBoxContactName" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxContactName" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="pop1">Required</asp:RequiredFieldValidator>
                       
                            </td>
                           
                        </tr>
                       
                       
                    
                    </table>



                    <div role="form">
                        
                        <hr class="divider">
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-6">
                                </div>
                                <div class="col-sm-6">
                                    <span class="pull-right">
                                        <asp:Button ID="btnSumbitcontact" CssClass="btn btn-success" runat="server" Text="Submit" ValidationGroup="pop1" OnClick="btnSumbitcontact_Click"/></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
   
</asp:Content>
