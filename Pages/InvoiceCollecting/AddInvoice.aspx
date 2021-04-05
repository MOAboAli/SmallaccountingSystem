<%@ Page Title="" Language="C#" MasterPageFile="~/BIMasterPage.Master" AutoEventWireup="true" enableEventValidation="false" CodeBehind="AddInvoice.aspx.cs" Inherits="BsolutionWebApp.Pages.InvoiceCollecting.AddInvoice" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



      <style>
        .element {
                 @include float-left;
                }
          .auto-style1 {
              height: 21px;
              text-align: right;
              width: 102px;
          }
          .auto-style2 {
              height: 22px;
              text-align: right;
          }
          .auto-style3 {
              text-align: left;
          }
          .auto-style4 {
              height: 21px;
              text-align: right;
              width: 161px;
          }
          .auto-style5 {
              height: 22px;
              text-align: right;
              width: 161px;
          }
          .auto-style6 {
              text-align: left;
          }
          .auto-style7 {
              height: 21px;
              text-align: right;
              width: 244px;
          }
          .auto-style8 {
              height: 22px;
              text-align: right;
              width: 244px;
          }
          .auto-style9 {
              width: 141px;
              text-align: left;
          }
          .auto-style14 {
              width: 102px;
              text-align: right;
          }
          .auto-style15 {
              width: 306px;
              text-align: left;
          }
          .auto-style16 {
              height: 21px;
              text-align: right;
              width: 306px;
          }
          .auto-style17 {
              text-align: left;
              }
          .auto-style20 {
              text-align: left;
              height: 22px;
          }
          </style>
    <script src="../../Scripts/jquery-ui.js"></script>
    
    <script>
 
    

  $(document).ready(function () {
      $("#datepicker").datepicker({
         // dateFormat: 'dd-mm-yy'
      });

      if ($('#DropDownListinvoicetype').val() == 2) {
          $('#textboxunticost').hide();
          $('#Label15').hide();
      }
      else {
          $('#textboxunticost').show();
          $('#Label15').show();
      }


  });
  </script>
    <div class="container">
  
        <table class="nav-justified">
            <tr>
                <td colspan="6" style="text-align: left">
                    <asp:Label ID="Label3" runat="server" style="font-size: x-large" Text="Invoice Page"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style6" colspan="3">
                    <asp:Label ID="Labelid" runat="server" Visible="False">0</asp:Label>
                    <asp:Label ID="Labelstatus" runat="server" Font-Bold="True" ForeColor="#FD9D74" Visible="False"></asp:Label>
                </td>
                <td class="auto-style14">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4" style="text-align: right">
                    <asp:Label ID="Label1" runat="server" Text="Invoice Type"></asp:Label></td>
                <td class="auto-style7">
                        <asp:DropDownList ID="DropDownListinvoicetype" runat="server" ClientIDMode="Static" CssClass="form-control" AutoPostBack="True" DataTextField="name" DataValueField="ID" OnSelectedIndexChanged="DropDownListinvoicetype_SelectedIndexChanged" Width="200px" Enabled="false"></asp:DropDownList>
                        </td>
                <td style="text-align: right">
                    <asp:Label ID="Label4" runat="server" Text="Invoice No."></asp:Label></td>
                <td class="auto-style16">
                          <asp:TextBox ID="TextBoxInvoiceno" runat="server" CssClass="form-control" ClientIDMode="Static"  Enabled="False" Width="93px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxInvoiceno" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="Done">Required</asp:RequiredFieldValidator>
                       
                        </td>
                <td class="auto-style1">
                    <asp:Label ID="Label5" runat="server" Text="Invoice Date"></asp:Label></td>
                <td style="text-align: left" >
                         <asp:TextBox ID="datepicker" runat="server" class="form-control" ClientIDMode="Static" Width="200px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp; </td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label6" runat="server" Text="Contact"></asp:Label></td>
                <td class="auto-style8">
                        <asp:DropDownList ID="DropDownListcontac" runat="server" class="form-control" DataTextField="name" DataValueField="ID" Width="200px"></asp:DropDownList>
                        <a href="#" class="btn-link" class="btn-link" data-toggle="modal" data-target="#myModal2"><span class="glyphicon glyphicon-inbox"></span></a>
                </td>
                <td style="text-align: right">
                    <asp:Label ID="Label7" runat="server" Text="Note"></asp:Label></td>
                <td  colspan="2" style="text-align: left">
                         <asp:TextBox ID="TextBoxNote" runat="server" class="form-control" TextMode="MultiLine" Height="100"></asp:TextBox>

                        </td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style3" colspan="6">
                    <hr />
                </td>
            </tr>
            <tr>
                <td class="auto-style3" colspan="6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3" colspan="6">
                    <asp:Label ID="Label12" runat="server" Text="Invoice Detials"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style9">&nbsp;&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="Label13" runat="server" Text="Item"></asp:Label>
                </td>
                <td class="auto-style8">
                        
                        <asp:DropDownList ID="DropDownListItem" runat="server" class="form-control" DataTextField="name" DataValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="DropDownListItem_SelectedIndexChanged" Width="200px"></asp:DropDownList>
                        <a class="btn-link" class="btn-link" data-target="#myModal3" data-toggle="modal" href="#"><span class="glyphicon glyphicon-inbox"></span></a>
                        </td>
                <td style="text-align: right" >
                    <asp:Label ID="Label14" runat="server" Text="Quantity"></asp:Label>
                </td>
                <td class="auto-style15">
                          <asp:TextBox ID="TextBoxquentity" runat="server" class="form-control" ClientIDMode="Static" OnTextChanged="TextBoxquentity_TextChanged" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxquentity" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="Detials">Required</asp:RequiredFieldValidator>
                       
                        </td>
                <td style="text-align: right">
                    <asp:Label ID="Label15" runat="server" Text="CostUnitPrice" ClientIDMode="Static"></asp:Label>
                </td>
                <td style="text-align: left">
                         <asp:TextBox ID="textboxunticost" runat="server" class="form-control" ClientIDMode="Static" Width="200px">0</asp:TextBox>
                        </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="Label16" runat="server" Text="SalesUnitPrice"></asp:Label>
                </td>
                <td class="auto-style6">
                        <asp:TextBox ID="TextBoxunitprice" runat="server" class="form-control" Width="200px">0</asp:TextBox>
                    </td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style15">
                            
                         
                            &nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td>
                            
                         
                            <asp:Button ID="Successbtnsave" runat="server" Text="Save" class="btn btn-success" OnClick="Successbtnitem_Click" ValidationGroup="Detials" />

                            </td>
            </tr>
            <tr>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style6" colspan="4">


               



                <asp:GridView ID="GridViewitem" runat="server" class="table table-striped" Height="100px" Width="800px">
                    <Columns>
                        
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="ButtonDelete1" runat="server" CausesValidation="false" Text="Delete" OnClick="DeleteGrid_Click"  CommandName='<%#Eval("ID") %>'/>
                            </ItemTemplate>
                            <ControlStyle CssClass="btn btn-danger" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>



                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style17" colspan="6">
                    <hr />
                </td>
            </tr>
            <tr>
                <td class="auto-style17" colspan="6">
                    <asp:Label ID="Label17" runat="server" Text="Discount"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right" >
                    <asp:Label ID="Label18" runat="server" Text="Discount%"></asp:Label>
                </td>
                <td class="auto-style6">
                         <asp:TextBox ID="TextBoxdpercentagedis" runat="server" class="form-control" ClientIDMode="Static" Text="0" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxdpercentagedis" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="Discount">Required</asp:RequiredFieldValidator>
                       
                        </td>
                <td style="text-align: right">
                    <asp:Label ID="Label19" runat="server" Text="Discount Amount"></asp:Label>
                </td>
                <td class="auto-style15">
                          <asp:TextBox ID="TextBoxdamountdis" runat="server" class="form-control" ClientIDMode="Static" Text="0" Width="200px"></asp:TextBox>
                       
                        </td>
                <td style="text-align: right">
                    <asp:Label ID="Label20" runat="server" Text="Note"></asp:Label>
                </td>
                <td style="text-align: left">
                        <asp:TextBox ID="TextBoxNote0" runat="server" class="form-control" Height="47px" TextMode="MultiLine" Width="196px"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td style="text-align: right" >
                    &nbsp;</td>
                <td class="auto-style6">
                        &nbsp;</td>
                <td class="auto-style9">
                            
                         
                            &nbsp;</td>
                <td class="auto-style15">
                            
                         
                            &nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td>
                            
                         
                            <asp:Button ID="Successbtnsave0" runat="server" Text="Save" class="btn btn-success" OnClick="SuccessbtnDiscount_Click" ValidationGroup="Discount" />

                            </td>
            </tr>
            <tr>
                <td style="text-align: right" >
                    &nbsp;</td>
                <td class="auto-style6">
                        &nbsp;</td>
                <td class="auto-style9">
                            
                         
                            &nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style6" colspan="4">


               



                <asp:GridView ID="GridViewDiscount" runat="server" class="table table-striped" Height="100px" Width="800px">
                    <Columns>
                        
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="ButtonDelete2" runat="server" CausesValidation="false" Text="Delete" OnClick="DeleteGrid2_Click"  CommandName='<%#Eval("ID") %>'/>
                            </ItemTemplate>
                            <ControlStyle CssClass="btn btn-danger" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>



                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style17" colspan="6">
                    <hr />
                </td>
            </tr>
            <tr>
                <td class="auto-style20" colspan="6">
                    <asp:Label ID="Label21" runat="server" Text="Tax"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="Label22" runat="server" Text="Tax Type"></asp:Label>
                </td>
                <td class="auto-style6">
                        <asp:DropDownList ID="DropDownListtax" runat="server" AutoPostBack="True" class="form-control" DataTextField="name" DataValueField="ID" OnSelectedIndexChanged="DropDownListtax2_SelectedIndexChanged" Width="200px">
                        </asp:DropDownList>
                    </td>
                <td style="text-align: right">
                    <asp:Label ID="Label23" runat="server" Text="TaxPercentage"></asp:Label>
                </td>
                <td class="auto-style15">
                         <asp:TextBox ID="TextBoxtaxpercentage0" runat="server" class="form-control" ClientIDMode="Static" Text="0" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxtaxpercentage0" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="Tax">Required</asp:RequiredFieldValidator>
                       
                        </td>
                <td class="auto-style14">
                    <asp:Label ID="Label24" runat="server" Text="TaxAmount"></asp:Label>
                </td>
                <td style="text-align: left">
                          <asp:TextBox ID="TextBoxdamounttax" runat="server" class="form-control" ClientIDMode="Static" Text="0" Width="200px"></asp:TextBox>
                        
                        </td>
            </tr>
            <tr>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style15">
                            
                         
                            &nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td>
                            
                         
                            <asp:Button ID="Successbtnsave1" runat="server" Text="Save" class="btn btn-success" OnClick="Successbtntax2_Click" ValidationGroup="Tax" />

                            </td>
            </tr>
            <tr>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style15">
                            
                         
                            &nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style6" colspan="4">


               



                <asp:GridView ID="GridViewtax" runat="server" class="table table-striped" Height="100px" Width="800px">
                    <Columns>
                        
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="ButtonDelete3" runat="server" CausesValidation="false" Text="Delete" OnClick="DeleteGrid3_Click"  CommandName='<%#Eval("ID") %>'/>
                            </ItemTemplate>
                            <ControlStyle CssClass="btn btn-danger" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>



                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style17" colspan="6">
                    <hr />
                </td>
            </tr>
            <tr>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style9">
                            
                         
                            &nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style17">&nbsp;</td>
                <td style="text-align: right">
                    <asp:Label ID="Label8" runat="server" Text="Total Price"></asp:Label></td>
                <td>
                            
                         
                         <asp:TextBox ID="TextBoxtotalprice" runat="server" CssClass="form-control" Enabled="False" Width="200px"></asp:TextBox>

                            </td>
                <td style="text-align: right">
                    <asp:Label ID="Label9" runat="server" Text="TotalCost"></asp:Label></td>
                <td>
                         <asp:TextBox ID="TextBoxcost" runat="server" CssClass="form-control" Enabled="False" Width="200px"></asp:TextBox>
                        </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style17">&nbsp;</td>
                <td style="text-align: right">
                    <asp:Label ID="Label10" runat="server" Text="AfterDiscount"></asp:Label></td>
                <td>
                            
                         
                         <asp:TextBox ID="TextBoxAfterDiscount" runat="server" CssClass="form-control" Enabled="False" Width="200px"></asp:TextBox>

                            </td>
                <td style="text-align: right">
                    <asp:Label ID="Label11" runat="server" Text="AfterTax&amp;Discount"></asp:Label></td>
                <td>
                         <asp:TextBox ID="TextBoxTax" runat="server" CssClass="form-control" Enabled="False" Width="200px"></asp:TextBox>
                        </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style9">
                            
                         
                            &nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style17" colspan="6">
                    <hr />
                </td>
            </tr>
            <tr>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style6">
                            
                         
                            <asp:Button ID="Successbtnsave3" runat="server" Text="Debit/Credit" class="btn btn-success" OnClick="Collecting_Click" ValidationGroup="Done" />

                            </td>
                <td class="auto-style9">
                            
                         
                            &nbsp;</td>
                <td class="auto-style15">
                            
                         
                            <asp:Button ID="Successbtnsave4" runat="server" Text="Print" class="btn btn-success" OnClick="SuccessbtPrintDone_Click" ValidationGroup="Done" />

                            </td>
                <td class="auto-style14">&nbsp;</td>
                <td>
                            
                         
                            <asp:Button ID="Successbtnsave2" runat="server" Text="Done" class="btn btn-success" OnClick="SuccessbtntaxDone_Click" ValidationGroup="Done" />

                            </td>
            </tr>
            <tr>
                <td colspan="6">
  
                    
                   
  
                    
                    &nbsp;</td>
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
                            <td> <asp:Label ID="Label2" runat="server" Text="ContactName" style="color:black"></asp:Label></td>
                            <td><asp:TextBox ID="TextBoxContactName" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxContactName" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="pop1">Required</asp:RequiredFieldValidator>
                       
                            </td>
                            <td><asp:Label ID="Label25" runat="server" Text="Mobile" style="color:black"></asp:Label>
                           </td>
                            <td ><asp:TextBox ID="TextBoxmobile" runat="server" CssClass="form-control" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxmobile" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="pop1">Required</asp:RequiredFieldValidator>
                      </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="Label26" runat="server" Text="Contact Type" style="color:black"></asp:Label>
                                                  
                          </td>
                            <td><asp:DropDownList ID="DropDownListcontacttype2" runat="server"  CssClass="form-control" DataValueField="Contat_T_Id" DataTextField="Contat_T_Name"></asp:DropDownList>
                         </td>
                            <td><asp:Label ID="Label27" runat="server" Text="Location" style="color:black"></asp:Label></td>
                            <td><asp:TextBox ID="TextBoxlocation" runat="server" class="form-control" ></asp:TextBox>
                        
                         </td>
                        </tr>
                       
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
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


     <div id="myModal3" class="modal fade in" role="dialog" >
        <div class="modal-dialog" style="padding: 30px;">
            <!-- Modal Content -->
            <div class="modal-content" style="width:150%">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &times</button>
                    <h4 class="modal-title" style="color:black">
                        Add item</h4>
                </div>
                <div class="modal-body">


                   <table class="nav-justified">
                        <tr>
                            <td style="text-align: right">
                                <asp:Label ID="Label32" runat="server" Text="ItemType"></asp:Label>
                            </td>
                            <td class="" style="text-align: left">
                        <asp:DropDownList ID="DropDownListitem0" runat="server" class="form-control" DataTextField="name" DataValueField="ID" Width="200px"></asp:DropDownList>
                            </td>
                            <td class="" style="text-align: right">
                                <asp:Label ID="Label33" runat="server" Text="ItemName"></asp:Label>
                            </td>
                            <td style="text-align: left">
                          <asp:TextBox ID="TextBoxName" runat="server" class="form-control" ClientIDMode="Static" Width="200px" Text="0"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBoxName" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="pop2">Required</asp:RequiredFieldValidator>
                       
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                <asp:Label ID="Label34" runat="server" Text="UnitPrice"></asp:Label>
                            </td>
                            <td class="" style="text-align: left">
                         <asp:TextBox ID="textboxprice" runat="server" class="form-control" ClientIDMode="Static" Width="200px" Text="0"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="textboxprice" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="pop2">Required</asp:RequiredFieldValidator>
                       
                            </td>
                            <td class="" style="text-align: right">
                                <asp:Label ID="Label35" runat="server" Text="UnitCost"></asp:Label>
                            </td>
                            <td style="text-align: left">
                          <asp:TextBox ID="TextBoxcost0" runat="server" class="form-control" ClientIDMode="Static" Width="200px"  Text="0"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBoxcost0" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="pop2">Required</asp:RequiredFieldValidator>
                       
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                <asp:Label ID="Label36" runat="server" Text="HasStock"></asp:Label>
                            </td>
                            <td class="" style="text-align: left">
                         <asp:CheckBox ID="CheckBoxhasstock" runat="server" />
                            </td>
                            <td class="" style="text-align: right">
                                <asp:Label ID="Label37" runat="server" Text="Qauntity"></asp:Label>
                            </td>
                            <td style="text-align: left">
                          <asp:TextBox ID="TextBoxquantity" runat="server" class="form-control" ClientIDMode="Static" Width="200px" Text="0"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBoxquantity" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="pop2">Required</asp:RequiredFieldValidator>
                       
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
                                        <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Text="Submit" ValidationGroup="pop2" OnClick="btnSumbititem_Click"/></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
