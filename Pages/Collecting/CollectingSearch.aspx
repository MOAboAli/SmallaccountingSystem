<%@ Page Title="" Language="C#" MasterPageFile="~/BIMasterPage.Master" AutoEventWireup="true" CodeBehind="CollectingSearch.aspx.cs" Inherits="BsolutionWebApp.Pages.Collecting.CollectingSearch" %>
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
    <div class="row">
                <div class="col-sm-4">
                    <h3> Search Collecting Page</h3>
                    </div>
                <div class="col-sm-6">
                      
                    </div>

                <div class="col-sm-2">
                    </div>
        </div>

        <div class="row">
                <div class="col-sm-1">
                    
                    </div>
                <div class="col-sm-9">
                      
                    <div class="row">

                        <div class="col-xs-4">
                       
                           </div>
                        <div class="col-xs-3">
                                 <label for="ex1">Collecting No

                                 </label>
                           </div>
                        <div class="col-xs-4">
                            
                         
                         <asp:TextBox ID="TxtCollecting_No" runat="server" class="form-control"></asp:TextBox>
                            
                            </div>
                       </div>
                     <div class="row">
                         <br />
                    </div>
                    <div class="row">
                         <div class="col-xs-4">
                       
                           </div>
                        <div class="col-xs-3">
                                 <label for="ex1">Collecting Date

                                 </label>
                           </div>
                        <div class="col-xs-4">
                            
                         
                         <asp:TextBox ID="datepicker" runat="server" class="form-control" ClientIDMode="Static"></asp:TextBox>
                            
                            </div>
                    </div>
                    <div class="row">
                         <br />
                    </div>

                     <div class="row">

                        <div class="col-xs-4">
                       
                           </div>
                        <div class="col-xs-3">
                               
                           </div>
                        <div class="col-xs-4">
                            
                         
                            <asp:Button ID="Successbtn" runat="server" Text="search" class="btn btn-success" OnClick="Successbtn_Click" ValidationGroup="Go" />

                            </div>
                       </div>


                    </div>

                <div class="col-sm-2">

                    </div>
        </div>

         <div class="row">
             <br />
             </div>
        <div class="row">

            <div class="col-lg-1"></div>
            <div class="col-lg-9">
                <asp:GridView ID="GridView1" runat="server" class="table table-striped">
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="ButtonEdit" runat="server" CausesValidation="false" Text="Edit" OnClick="EditGrid_Click"  CommandName='<%#Eval("ID") %>' />
                            </ItemTemplate>
                            <ControlStyle CssClass="btn btn-warning" />
                        </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>
            </div>
        </div>
     </div>
</asp:Content>
