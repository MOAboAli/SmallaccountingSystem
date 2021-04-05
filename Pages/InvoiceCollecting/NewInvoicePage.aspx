<%@ Page Title="" Language="C#" MasterPageFile="~/BIMasterPage.Master" AutoEventWireup="true" CodeBehind="NewInvoicePage.aspx.cs" Inherits="BsolutionWebApp.Pages.InvoiceCollecting.NewInvoicePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

        <script src="../../Scripts/jquery-ui.js"></script>
    
    <script>
 
    

  $(document).ready(function () {
      $("#datepicker").datepicker({
         // dateFormat: 'dd-mm-yy'
      });
  });
          </script>

    <style type="text/css">
      
       
      
        .auto-style1 {
            width: 200px;
        }
        .auto-style2 {
            width: 200px;
        }
        .auto-style3 {
            width: 200px;
        }
        .auto-style4 {
            width: 200px;
        }
        .auto-style5 {
            width: 200px;
        }
      
       
      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="nav-justified">
        <tr>
            <td class="active" colspan="6">
                <asp:Label ID="Label3" runat="server" Text="Invoice Page" style="font-size: x-large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style3">
                <asp:Label ID="Label4" runat="server" Text="Invoice Type"></asp:Label>
            </td>
            <td style="text-align: left" class="auto-style1"  >
                        <asp:DropDownList ID="DropDownListinvoicetype" runat="server" class="form-control" AutoPostBack="True" DataTextField="name" DataValueField="ID" OnSelectedIndexChanged="DropDownListinvoicetype_SelectedIndexChanged"></asp:DropDownList>
                        </td>
            <td style="text-align: right" class="auto-style4">
                <asp:Label ID="Label6" runat="server" Text="Invoice No."></asp:Label>
            </td>
            <td class="auto-style2">
                          <asp:TextBox ID="TextBoxInvoiceno" runat="server" CssClass="form-control" ClientIDMode="Static"  Enabled="False"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxInvoiceno" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="Go">Required</asp:RequiredFieldValidator>
                       
                        </td>
            <td style="text-align: right" class="auto-style5">
                <asp:Label ID="Label7" runat="server" Text="Invoice Date"></asp:Label>
            </td>
            <td style="text-align: left" class="auto-style5">
                         <asp:TextBox ID="datepicker" runat="server" class="form-control" ClientIDMode="Static"></asp:TextBox>
                        </td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style3" >
                <asp:Label ID="Label5" runat="server" Text="Contact"></asp:Label>
            </td>
            <td class="auto-style1"  >
                        <asp:DropDownList ID="DropDownListcontac" runat="server" class="form-control" DataTextField="name" DataValueField="ID"></asp:DropDownList>
                        </td>
            <td style="text-align: right" class="auto-style4" >
                <asp:Label ID="Label8" runat="server" Text="Note"></asp:Label>
            </td>
            <td   colspan="2">
                         <asp:TextBox ID="TextBoxNote" runat="server" class="form-control" TextMode="MultiLine" Height="100"></asp:TextBox>

                        </td>
            <td  ></td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1"  >&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style3">
                <asp:Label ID="Label9" runat="server" Text="Total Price"></asp:Label>
            </td>
            <td   style="text-align: left" class="auto-style1">
                         <asp:TextBox ID="TextBoxtotalprice" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                        </td>
            <td style="text-align: right" class="auto-style4">
                <asp:Label ID="Label10" runat="server" Text="Total Cost"></asp:Label>
            </td>
            <td style="text-align: left" class="auto-style2">
                         <asp:TextBox ID="TextBoxcost" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                        </td>
            <td style="text-align: right" class="auto-style5">
                <asp:Label ID="Label11" runat="server" Text="AfterDiscount"></asp:Label>
            </td>
            <td style="text-align: left">
                         <asp:TextBox ID="TextBoxAfterDiscount" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                        </td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style3">
                &nbsp;</td>
            <td   style="text-align: left" class="auto-style1">
                         &nbsp;</td>
            <td style="text-align: right" class="auto-style4">
                &nbsp;</td>
            <td style="text-align: left" class="auto-style2">
                         &nbsp;</td>
            <td style="text-align: right" class="auto-style5">
                &nbsp;</td>
            <td style="text-align: left">
                         &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style3">
                <asp:Label ID="Label12" runat="server" Text="After Taxing"></asp:Label>
            </td>
            <td   style="text-align: left" class="auto-style1">
                         <asp:TextBox ID="TextBoxTax" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                        </td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1"  >&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1"  >&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1"  >&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1"  >&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1"  >&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1"  >&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1"  >&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1"  >&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1"  >&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1"  >&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1"  >&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1"  >&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1"  >&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1"  >&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1"  >&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1"  >&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1"  >&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1"  >&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1"  >&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1"  >&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1"  >&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1"  >&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1"  >&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1"  >&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
