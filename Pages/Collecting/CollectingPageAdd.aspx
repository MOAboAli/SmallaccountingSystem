<%@ Page Title="" Language="C#" MasterPageFile="~/BIMasterPage.Master" AutoEventWireup="true" CodeBehind="CollectingPageAdd.aspx.cs" Inherits="BsolutionWebApp.Pages.Collecting.CollectingPageAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <style>
            /*.element {
                 @include float-left;
                }*/
            .auto-style2 {
            }
            .auto-style3 {
                width: 170px;
            }
    </style>
    
    <script src="../../Scripts/jquery-ui.js"></script>
    <script>
 
    

        $(document).ready(function () {
           
      $("#TextBoxdate").datepicker({
         // dateFormat: 'dd-mm-yy'
      });

      //$('#TextBoxleft').attr("disabled", "disabled");
      $('#TextBoxleft').keydown(function (e) {
          e.preventDefault();
          return false;
      });

      $('#TextBoxtotalinvoice').keydown(function (e) {
          e.preventDefault();
          return false;
      });

      $('#TextBoxCollectingNo').keydown(function (e) {
          e.preventDefault();
          return false;
      });

      //$('#TextBoxtotalinvoice').attr("disabled", "disabled");
      
      //$('#TextBoxCollectingNo').attr("disabled", "disabled");


      $("#TextBoxamount").change(function () {
          var left = $('#TextBoxleft').val();
          var amount = $('#TextBoxamount').val();

          if(left-amount < 0)
          {
              alert("Enter Value Larger than what's Left in invoice");
              $('#TextBoxamount').val(left);
          }
      });
        });

        

        
  </script>

    <div class="container">

        <table class="nav-justified">
            <tr>
                <td colspan="6">
                    <asp:Label ID="Label3" runat="server" style="color: #FD9D74; font-size: large" Text="Debit/Credit"></asp:Label>
                    <asp:Label ID="Labelinvoiceid" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="Labelcollectingid" runat="server" Text="0" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style2" colspan="5">
                    <asp:Label ID="Labelstatus" runat="server" style="color: #FF0000"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <label for="ex1" style="text-align:right;">
                    Invoice type</label></td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DropDownListInvoicetype" runat="server" CssClass="form-control" DataTextField="name" DataValueField="ID" Enabled="False" Width="200px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right">
                    <label for="ex1">
                    Invoice
                    </label>
                </td>
                <td class="auto-style3">
                    <asp:DropDownList ID="DropDownListInvoice" runat="server" CssClass="form-control" DataTextField="name" DataValueField="ID" Enabled="False" Width="200px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right">
                    <label for="ex1">
                    &nbsp;No.</label></td>
                <td>
                    <asp:TextBox ID="TextBoxCollectingNo" runat="server" ClientIDMode="Static" CssClass="form-control" Enabled="False" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxCollectingNo" ErrorMessage="RequiredFieldValidator" style="color: #FD9D74" ValidationGroup="gO">Required</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <label for="ex1" style="text-align:right;">
                    Collector Name.</label></td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxcollectingname" runat="server" class="form-control" Width="200px"></asp:TextBox>
                </td>
                <td style="text-align: right">
                    <label for="ex1" style="text-align:right;">
                    Date</label></td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBoxdate" runat="server" class="form-control" ClientIDMode="Static" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxdate" ErrorMessage="RequiredFieldValidator" style="color: #FD9D74" ValidationGroup="gO">Required</asp:RequiredFieldValidator>
                </td>
                <td style="text-align: right">
                    <label for="ex1">
                    Total Invoice</label></td>
                <td>
                    <asp:TextBox ID="TextBoxtotalinvoice" runat="server" ClientIDMode="Static" CssClass="form-control" Enabled="False" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <label for="ex1" style="text-align:right;">
                    Amount</label></td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxamount" runat="server" class="form-control" ClientIDMode="Static" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxamount" ErrorMessage="RequiredFieldValidator" style="color: #FD9D74" ValidationGroup="gO">Required</asp:RequiredFieldValidator>
                </td>
                <td style="text-align: right">
                    <label for="ex1" style="text-align:right;">
                    Left in Invoice</label></td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBoxleft" runat="server" ClientIDMode="Static" CssClass="form-control" Enabled="False" OnTextChanged="TextBoxleft_TextChanged" Width="200px"></asp:TextBox>
                </td>
                <td style="text-align: right">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td style="text-align: right">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td style="text-align: right">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right">&nbsp;</td>
                <td class="auto-style2">
                    <asp:RadioButton ID="RadioButtonBankOrCash" runat="server" Checked="True" GroupName="rad" Text="BankORCash" />
                </td>
                <td style="text-align: right">&nbsp;</td>
                <td class="auto-style3">
                    <asp:RadioButton ID="RadioButtonCheque" runat="server" GroupName="rad" Text="Cheque" />
                </td>
                <td style="text-align: right">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <label for="ex1" style="text-align:right;">
                    Type
                    </label>
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="200px">
                        <asp:ListItem Value="0">Bank</asp:ListItem>
                        <asp:ListItem Value="1">Cash</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="text-align: right">
                    <label id="labelcheque0" runat="server" for="ex1" style="text-align:right;">
                    Bank Name</label></td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBoxchequebankname" runat="server" class="form-control" Width="200px"></asp:TextBox>
                </td>
                <td style="text-align: right">
                    <label for="ex1">
                    Note
                    </label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxNote" runat="server" class="form-control" Height="46px" TextMode="MultiLine" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="Labelbankcash" runat="server" style="color: #FD9D74"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DropDownListbankcashtype" runat="server" class="form-control" DataTextField="name" DataValueField="ID" Width="200px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right">
                    <label id="labelcheque" runat="server" for="ex1" style="text-align:right;">
                    Cheque No</label></td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBoxchequeno" runat="server" class="form-control" Width="200px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="Successbtn" runat="server" class="btn btn-success" OnClick="Successbtn_Click" Text="ADD" ValidationGroup="gO" />
                </td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:GridView ID="GridView1" runat="server" class="table table-striped" Width="1081px">
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="ButtonEdit" runat="server" CausesValidation="false" CommandName='<%#Eval("ID") %>' OnClick="EditGrid_Click" Text="Edit" ValidationGroup="Go" />
                                </ItemTemplate>
                                <ControlStyle CssClass="btn btn-warning" />
                            </asp:TemplateField>
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
   


    

</asp:Content>
