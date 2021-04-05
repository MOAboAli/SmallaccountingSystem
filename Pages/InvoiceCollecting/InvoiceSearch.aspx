<%@ Page Title="" Language="C#" MasterPageFile="~/BIMasterPage.Master" AutoEventWireup="true" CodeBehind="InvoiceSearch.aspx.cs" Inherits="BsolutionWebApp.Pages.InvoiceCollecting.InvoiceSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <style>
        .element {
                 @include float-left;
                }
          .auto-style1 {
              width: 130px;
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
                <td colspan="7" style="text-align: left">
                    <asp:Label ID="Label3" runat="server" style="font-size: x-large" Text="Invoice Search "></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="2">
                    <asp:Label ID="Labelstatus" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right" class="auto-style1">
                    <asp:Label ID="Label4" runat="server" Text="Invoice Type"></asp:Label>
                </td>
                <td style="text-align: left">
                        <asp:DropDownList ID="DropDownListinvoicetype" runat="server" CssClass="form-control" AutoPostBack="True" DataTextField="name" DataValueField="ID" OnSelectedIndexChanged="DropDownListinvoicetype_SelectedIndexChanged" Width="200px"></asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                <td style="text-align: left">
                    <asp:Button ID="Successbtn1" runat="server" class="btn btn-success" OnClick="Successbtnadd_Click" Text="ADD" ValidationGroup="ADD" />
                        </td>
                <td style="text-align: right">
                    <asp:Label ID="Label8" runat="server" Text="Item"></asp:Label>
                </td>
                <td style="text-align: left">
                        <asp:DropDownList ID="DropDownListItem" runat="server" class="form-control" DataTextField="name" DataValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="DropDownListItem_SelectedIndexChanged" Width="200px"></asp:DropDownList>
                        </td>
                <td style="text-align: right">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right" class="auto-style1">
                    &nbsp;</td>
                <td style="text-align: left" colspan="2">
                        &nbsp;</td>
                <td style="text-align: right">
                    &nbsp;</td>
                <td style="text-align: left">
                        &nbsp;</td>
                <td style="text-align: right">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right" class="auto-style1">
                    <asp:Label ID="Label5" runat="server" Text="Date"></asp:Label>
                </td>
                <td style="text-align: left" colspan="2">
                    <asp:TextBox ID="datepicker" runat="server" class="form-control" ClientIDMode="Static" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="ADD" ControlToValidate="datepicker" style="color: #FF0000">Required</asp:RequiredFieldValidator>
                </td>
                <td style="text-align: right">&nbsp;</td>
                <td style="text-align: left">&nbsp;</td>
                <td style="text-align: right">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right" class="auto-style1">
                    <asp:Label ID="Label7" runat="server" Text="Contact"></asp:Label>
                </td>
                <td style="text-align: left" colspan="2">
                        <asp:DropDownList ID="DropDownListcontac" runat="server" class="form-control" DataTextField="name" DataValueField="ID" Width="200px">
                            <asp:ListItem Value="0">Choose</asp:ListItem>
                    </asp:DropDownList>
                        <a href="#" class="btn-link" class="btn-link" data-toggle="modal" data-target="#myModal2"><span class="glyphicon glyphicon-inbox"></span></a>
                        </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right" class="auto-style1">
                    &nbsp;</td>
                <td style="text-align: left" colspan="2">
                        &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td style="text-align: left" colspan="2">
                    <asp:Button ID="Successbtn0" runat="server" class="btn btn-success" OnClick="Successbtn_Click" Text="search" ValidationGroup="Go" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="6" style="text-align: left">
                    <asp:GridView ID="GridView1" runat="server" class="table table-striped" Width="1092px">
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="ButtonEdit0" runat="server" CausesValidation="false" CommandName='<%#Eval("ID") %>' OnClick="EditGrid_Click" Text="Edit" />
                                </ItemTemplate>
                                <ControlStyle CssClass="btn btn-warning" />
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="Collect0" runat="server" CausesValidation="false" CommandName='<%#Eval("ID") %>' OnClick="Collecting_Click" Text="Debit/Credit" />
                                </ItemTemplate>
                                <ControlStyle CssClass="btn btn-warning" />
                            </asp:TemplateField>
                             <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="Print" runat="server" CausesValidation="false" CommandName='<%#Eval("ID") %>' OnClick="Print_Click" Text="Print" />
                                </ItemTemplate>
                                <ControlStyle CssClass="btn btn-warning" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="7">
                   
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

</asp:Content>
