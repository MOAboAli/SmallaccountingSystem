<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintInvoice.aspx.cs" Inherits="BsolutionWebApp.Pages.InvoiceCollecting.PrintInvoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 50%;
        }
        .auto-style2 {
            height: 23px;
            text-align: right;
        }


        .td1 {
    background-clip: padding-box; /* this has been added */
    border-radius: 12px;
    background-color: #fc4c02;
    color: white;
     border-collapse: collapse;
     -webkit-print-color-adjust: exact; 
    /*border: 5px solid white;*/
        }​
         
             .tr2 {
            
    background-clip: padding-box; 
    border-radius: 12px;
    background-color: #fc4c02;
    color: white;
    border: 5px solid white;
    -webkit-print-color-adjust: exact; 
        }​





        .auto-style3 {
            font-weight: bold;
        }
        .auto-style4 {
            width: 100%;
        }


        .auto-style5 {
            font-weight: bold;
        }

       @media screen {
              div.divFooter {
                display: none;
              }
              div.divheader {
               display: none;
              }
            }
        @media print {
              div.divFooter {
                  
                position: fixed;
                bottom: 0;
                display: table-footer-group;
              }
              div.divheader {
                  
                position: fixed;
                top: 0;
                display: table-header-group;
              }
              
                .auto-style1 {
                  display: table-row-group;
                }

                
            }

        


    </style>
</head>
<body>
    <form id="form1" runat="server">
    
        <div class="divheader">
            <asp:Image ID="Image3" runat="server" Height="200px" ImageUrl="~/images/Invoice/1.png" Width="818px"  />
  
            
            </div>
    
        <table class="auto-style1">
            <tr>
                <td colspan="11">
                  <asp:Image ID="Image1" runat="server" Height="200px" ImageUrl="~/images/Invoice/1 - Copy.png" Width="818px"  />
  
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td colspan="2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="Label2" runat="server" style="font-weight: 700" Text="Invoice To:"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td style="text-align: right">&nbsp;</td>
                <td style="text-align: right">
                    <asp:Label ID="Label6" runat="server" Text="Invoice #:"></asp:Label>
                </td>
                <td style="text-align: center;" class="td1" colspan="2">
                    <asp:Label ID="Labelinvoiceno" runat="server" ></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="4" rowspan="2">
                    <asp:Label ID="LabelName" runat="server" style="font-weight: 700"></asp:Label>
                </td>
                <td style="text-align: right">
                    <asp:Label ID="Label7" runat="server" Text="Invoice Date:"></asp:Label>
                </td>
                <td style="text-align: center" class="td1" colspan="2">
                    <asp:Label ID="LabelInvoiceDate" runat="server"></asp:Label>
                </td>
                <td colspan="2" rowspan="2" style="text-align: right">
                    <asp:Label ID="Label1" runat="server" style="font-weight: 700; font-size: xx-large" Text="INVOICE"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td style="text-align: right">
                    <asp:Label ID="Label8" runat="server" Text="Account #:"></asp:Label>
                </td>
                <td style="text-align: center" class="td1" colspan="2">
                    <asp:Label ID="Labelaccountno" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td colspan="4">
                    <asp:Label ID="Labelmobile" runat="server"></asp:Label>
                </td>
                <td style="text-align: right">
                    <asp:Label ID="Label9" runat="server" Text="Total Due:"></asp:Label>
                </td>
                <td style="text-align: center" class="td1" colspan="2">
                    <asp:Label ID="Labeltotaldue" runat="server"></asp:Label>
                </td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="4">
                    <asp:Label ID="Labeladdress" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td colspan="2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td colspan="2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr >
                <td>&nbsp;</td>
                <%--<td colspan="8" class="td1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label10" runat="server" CssClass="auto-style3" Text="Item Description"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label11" runat="server" CssClass="auto-style3" Text="Unit Price"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label12" runat="server" CssClass="auto-style3" Text="Quantity"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label13" runat="server" CssClass="auto-style3" Text="Total"></asp:Label>
                </td>--%>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="9">
                   
                               
                    <asp:Repeater ID="Repeater1" runat="server">

                        <HeaderTemplate>
                            <table class="auto-style4">
                                <tr class="td1">
                                    <td colspan="2">Item Description</td>
                                    
                                    <td >Unit Price</td>
                                    <td >Quantity</td>
                                    
                                    <td >Total</td>
                                </tr>

                            </HeaderTemplate>
                      
                         <ItemTemplate>
                     

                               <tr>
                                    <td colspan="2" >
                                        <asp:Label ID="Labelitem" runat="server" Text='<%# Eval("ItemDescription") %>'></asp:Label></td>
                                    
                                    <td ><asp:Label ID="Labelunitprice" runat="server" Text='<%# Eval("UnitPrice") %>'></asp:Label></td>
                                    <td ><asp:Label ID="Labelquantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label></td>
                                    
                                    <td ><asp:Label ID="Labeltotal" runat="server" Text='<%# Eval("Total") %>'></asp:Label></td>
                                </tr>
                           
                              </ItemTemplate>
                  
              
                          <FooterTemplate>
                              </table>
                          </FooterTemplate>
                            
                      </asp:Repeater> 
                      
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td colspan="2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td style="text-align: right">&nbsp;</td>
                <td style="text-align: left">
                    <asp:Label ID="Label10" runat="server" CssClass="auto-style5" Text="Sub Total:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Labelsubtotal" runat="server" CssClass="auto-style5"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td style="text-align: right">&nbsp;</td>
                <td style="text-align: left">
                    <asp:Label ID="Label14" runat="server" CssClass="auto-style5" Text="Discount"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Labeldiscount" runat="server" CssClass="auto-style5"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td style="text-align: right">&nbsp;</td>
                <td style="text-align: left">
                    <asp:Label ID="Label12" runat="server" CssClass="auto-style5" Text="Tax"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Labeltax" runat="server" CssClass="auto-style5"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td style="text-align: right">&nbsp;</td>
                <td style="text-align: left">
                    <asp:Label ID="Label16" runat="server" CssClass="auto-style5" Text="Total Due"></asp:Label>
                </td>
                <td style="text-align: center" class="td1">
                    <asp:Label ID="Labeltotaldue2" runat="server" CssClass="auto-style5"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td colspan="2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="5">
                    <asp:Label ID="Label18" runat="server" Text="Thank your for your business!"></asp:Label>
                </td>
                <td colspan="3" style="text-align: right">
                    <asp:Label ID="Label17" runat="server" Text="Account Manager"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td colspan="2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td colspan="2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="11">&nbsp;</td>
            </tr>
            </table>
    
        <div class="divFooter">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Invoice/2.png" Width="818px" />

            
            &nbsp;</div>
    
    </form>
</body>
</html>
