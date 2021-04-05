<%@ Page Title="" Language="C#" MasterPageFile="~/BIMasterPage.Master" AutoEventWireup="true" CodeBehind="Collecting.aspx.cs" Inherits="BsolutionWebApp.Pages.MasterDataPages.Collecting" %>
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
                    
                   <h2> <label for="ex1">Debit/Credit Page </label></h2>
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
                <td colspan="2">
                    <asp:Label ID="Labelid" runat="server" Visible="False">0</asp:Label>
                    <asp:Label ID="Labelstatus" runat="server" Font-Bold="True" ForeColor="#FD9D74"></asp:Label>
                </td>
                <td colspan="2">&nbsp;</td>
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
                    Collecting Name</label>
                        </div>
                    <div class="col-xs-8">
                        <asp:TextBox ID="TextCollectingName" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextCollectingName" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="Go">Required</asp:RequiredFieldValidator>
                        </div>

                </td>
                <td>

                     <div class="col-xs-4">
                         <label for="ex1">
                    Collecting No
                    </label>
                         </div>
                     <div class="col-xs-8">
                        <asp:TextBox ID="TextCollectingNo" runat="server" class="form-control" onkeypress="keypress()"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextCollectingNo" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="Go">Required</asp:RequiredFieldValidator>
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
                        <label for="ex1">Date Of Open </label>
                        </div>
                    <div class="col-xs-8">
                         <asp:TextBox ID="datepicker" runat="server" class="form-control" ClientIDMode="Static"></asp:TextBox>
                        <%--<input type="text" id="datepicker" class="form-control"/>--%>
                        </div>

                </td>
                <td>
                   

                     <div class="col-xs-4">
                        <label for="ex1">
                    Invoice No
                    </label>
                        </div>
                     <div class="col-xs-8">
                         <asp:DropDownList ID="ddInvoice" runat="server" DataSourceID="SqlDataSource1" class="form-control" DataTextField="Invoice_No" DataValueField="Invoice_Id" ></asp:DropDownList>
                         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CMSConnectionString2 %>" SelectCommand="SELECT [Invoice_Id], [Invoice_No] FROM [Invoice]"></asp:SqlDataSource>
                        </div>




                </td>
                <td>&nbsp;</td>
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
                        <label for="ex1">
                            Cheque/Cash
                        </label>
                        </div>
                    <div class="col-xs-8">
                        <asp:DropDownList ID="ddChequeOrCash" runat="server" class="form-control"  DataTextField="name"  DataValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="DropDownListbankcash_SelectedIndexChanged" >
                             <asp:ListItem Value="0">Cheque</asp:ListItem>
                             <asp:ListItem Value="1">Cash</asp:ListItem>
                         </asp:DropDownList>
                        </div>



                </td>
                                <td>
                    


                     <div class="col-xs-4">
                       <label for="ex1">
                    Operation Type
                       </label>
                        </div>
                     <div class="col-xs-8">
                         <asp:DropDownList ID="ddOperationType" runat="server" DataSourceID="SqlDataSource4" class="form-control" DataTextField="Transaction_Type_Name" DataValueField="Transaction_Type_Id"></asp:DropDownList>
                         <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:CMSConnectionString5 %>" SelectCommand="SELECT [Transaction_Type_Id], [Transaction_Type_Name] FROM [Transaction_Type]"></asp:SqlDataSource>
                        </div>




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
                <td>
                   

                     <div class="col-xs-4">
                       <label for="ex1">
                    Contact</label>
                        </div>
                     <div class="col-xs-8">
                         <asp:DropDownList ID="ddContact" runat="server" DataSourceID="SqlDataSource3" DataTextField="Contact_Name"  class="form-control" DataValueField="Contact_Id"></asp:DropDownList>
                         <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:CMSConnectionString4 %>" SelectCommand="SELECT [Contact_Id], [Contact_Name] FROM [Contact]"></asp:SqlDataSource>
                        </div>



                </td>
                <td>

                     <div class="col-xs-4">
                         <label for="ex1">
                    Collecting Amount
                    </label>
                         </div>
                     <div class="col-xs-8">
                        <asp:TextBox ID="txtCollectingAmount" runat="server" class="form-control" onkeypress="keypress()"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCollectingAmount" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="Go">Required</asp:RequiredFieldValidator>
                         </div>
                          
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>

                     <div class="col-xs-4">
                         <label for="ex1">
                    Collecting What is Left
                    </label>
                         </div>
                     <div class="col-xs-8">
                        <asp:TextBox ID="txtCollecting_WhatsLeft" runat="server" class="form-control" onkeypress="keypress()"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCollecting_WhatsLeft" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="Go">Required</asp:RequiredFieldValidator>
                         </div>
                          
                </td>
                <td>

                <div class="col-xs-4">
                         <asp:Label ID="Labelbankcash" runat="server" style="color: #FD9D74"></asp:Label>
&nbsp;</div>
                    <div class="col-xs-8">
                         <asp:DropDownList ID="DropDownListbankcashtype" runat="server" class="form-control"  DataTextField="name" DataValueField="ID" ></asp:DropDownList>
                        </div>
            </td>
                
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


                </td>
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
