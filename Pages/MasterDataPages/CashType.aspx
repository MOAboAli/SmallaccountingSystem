﻿<%@ Page Title="" Language="C#" MasterPageFile="~/BIMasterPage.Master" AutoEventWireup="true" CodeBehind="CashType.aspx.cs" Inherits="BsolutionWebApp.Pages.MasterDataPages.CashType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .element {
                 @include float-left;
                }
    </style>
    <div class="container">
    <div class="row">
                <div class="col-sm-4">
                    <h3> Cash Type Page</h3>
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
                                 <label for="ex1">Cash Type Name

                                 </label>
                           </div>
                        <div class="col-xs-4">
                            
                         
                         <asp:TextBox ID="TextBoxCashtype" runat="server" class="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxCashtype" ErrorMessage="RequiredFieldValidator" Font-Bold="True" Font-Italic="False" style="color: #FF0000" ValidationGroup="Go">Required</asp:RequiredFieldValidator>
                       
                            </div>
                       </div>
                    <div class="row">

                        <div class="col-xs-4">
                       
                           </div>
                        <div class="col-xs-3">
                                 <label for="ex1">Notes
                                 </label>
                           </div>
                        <div class="col-xs-4">
                            
                         <asp:TextBox ID="TextBoxNote" runat="server" class="form-control" TextMode="MultiLine" Height="100"></asp:TextBox>                       
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
                            
                         
                            <asp:Button ID="Successbtn" runat="server" Text="ADD" class="btn btn-success" OnClick="Successbtn_Click" ValidationGroup="Go" />

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
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="ButtonDelete" runat="server" CausesValidation="false" Text="Delete" OnClick="DeleteGrid_Click"  CommandName='<%#Eval("ID") %>'/>
                            </ItemTemplate>
                            <ControlStyle CssClass="btn btn-danger" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>



            </div>


           



        </div>
     </div>
</asp:Content>