<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SalesTransaction.Pages.Home" MasterPageFile="~/SiteMaster.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Sales Transaction Form</h3>
            </div>
            <div class="panel-body ">
                <div class="col-md-6">
                    <fieldset>
                        <div class="form-group">
                            <asp:HiddenField runat="server" ID="hidTxnID"/>
                            <label>Cumstomer</label>
                            <asp:DropDownList runat="server" ID="ddlCustomer" CssClass="form-control" DataSourceID="SqlDataSource2" DataTextField="name" DataValueField="customer_id" />
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Conn %>" SelectCommand="SELECT * FROM [tbl_customer]"></asp:SqlDataSource>
                            <div>New Customer?
                                    <button type="button" class="btn-info btn-sm" data-toggle="modal" data-target="#newCustomerModal">Add New</button>
                                </div>
                            <label>
                                Choose Product
                            </label>
                            <asp:DropDownList runat="server" ID="ddlProduct" DataSourceID="SqlDataSource1" DataTextField="product_name" DataValueField="product_id" CssClass="form-control" OnSelectedIndexChanged="ddlProduct_OnSelectedIndexChanged" AutoPostBack="True" />
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Conn %>" SelectCommand="SELECT * FROM [tbl_product] WHERE ([is_active] = @is_active)">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="True" Name="is_active" Type="Boolean" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <div>
                                 Product Rate is:<asp:Label runat="server" ID="lblRate"></asp:Label>

                             </div>
                                <label>Quantity:</label>
                           
                           
                            <asp:DropDownList runat="server" ID="ddlQuantity" CssClass="form-control" OnSelectedIndexChanged="ddlQuantity_OnSelectedIndexChanged" AutoPostBack="True">
                                 <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label runat="server" id="lblInvoiceNo"  Text="Invoice No:"></asp:Label>
                            <asp:TextBox runat="server" ID="txtInvoiceNo" CssClass="form-control"></asp:TextBox>
                            <label>Current Amount</label>
                            <asp:TextBox runat="server" ID="txtAmount" CssClass="form-control"></asp:TextBox>
                            

                        </div>
                        <asp:Button runat="server" ID="btnSave" CssClass="btn btn-lg btn-success btn-block" Text="SAVE" OnClick="btnSave_OnClick" />

                    </fieldset>
                </div>




            </div>
        </div>
    </div>
    <div class="modal fade" id="newCustomerModal" tabindex="-1" role="dialog" aria-labelledby="newCustomerModalLabel">
        <div class="modal-dialog span9" role="document">
            <div class="modal-content span9 box paint color_11">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="signupModallabel">Please Add Customer</h4>
                </div>
                <div class="modal-body ">
                    <div class="form-group">
                        <div>
                            <label>Cumstomer Name</label>
                            <asp:TextBox runat="server" ID="txtCustomerName"></asp:TextBox>
                        </div>
                        <div>
                              <label>Contact No:</label>
                             <asp:TextBox runat="server" ID="txtContact" ></asp:TextBox>
                        </div>


                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            <asp:Button ID="btnAddCustomer" runat="server" class="btn btn-primary" Text="Add" OnClick="btnAddCustomer_OnClick"/>

                        </div>


                    </div>
                </div>
            </div>
        </div>
    </div>




    <script src="../Scripts/jquery.min.js"></script>
    <!-- Bootstrap Core JavaScript -->
    <script src="../Scripts/bootstrap.min.js"></script>

    <script src="../Scripts/metisMenu.min.js"></script>
    <!-- Metis Menu Plugin JavaScript -->

    <script src="../Scripts/sb-admin-2.js"></script>
</asp:Content>
