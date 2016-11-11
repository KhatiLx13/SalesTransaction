<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAllTransaction.aspx.cs" Inherits="SalesTransaction.Pages.ViewAllTransaction" MasterPageFile="~/SiteMaster.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">


    <!-- /.row -->
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    View All Transaction
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div class="dataTable_wrapper">
                        <asp:ListView runat="server" ID="lvViewAll">
                            <LayoutTemplate>
                                <table class="table table-striped table-bordered table-hover" id="dataTables-example">
                                    <thead>
                                        <tr>
                                             <th>
                                                <asp:Label ID="lblInvoice" Text="InvoiceNo" runat="server"></asp:Label></th>
                                            <th>
                                                <asp:Label ID="lblName" Text="Customer Name" runat="server"></asp:Label></th>
                                            <th>
                                                <asp:Label ID="lblCategory" Text="Product" runat="server"></asp:Label></th>
                                            <th>
                                                <asp:Label ID="Label1" Text="Rate" runat="server"></asp:Label></th>
                                            
                                            <th>
                                                <asp:Label ID="lblRate" Text="Quantiry" runat="server"></asp:Label>
                                            </th>
                                            <th>
                                                <asp:Label ID="lblStatus" Text="Amount" runat="server"></asp:Label></th>
                                           
                                            <th>
                                                <asp:Label ID="lblAction" runat="server" Text="Action"></asp:Label>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                             <ItemTemplate>
                            <tr>
                                 <td>
                                    <%# Eval("invoice_no") %>
                                </td>
                                <td>
                                    <%# Eval("name") %>
                                </td>
                                <td>
                                    <%# Eval("product_name") %>
                                </td>
                                 <td>
                                    <%# Eval("product_rate") %>
                                </td>
                                 <td>
                                    <%# Eval("quantity") %>
                                </td>
                                <td>
                                    <%# Eval("amount") %>
                                </td>
                                
                                <td>
                                    <asp:LinkButton ID="lbEdit" CssClass="green btn btn-small" runat="server" CommandName="edit" CommandArgument='<%#Eval("invoice_id") %>'  OnCommand="lbEdit_OnCommand" ToolTip="Edit"><i class="gicon-edit"></i>Edit</asp:LinkButton>
                               
                                    <asp:LinkButton ID="lbtnView" CssClass="green btn btn-small" runat="server" CommandName="view" CommandArgument='<%#Eval("txn_id") %>' ToolTip="View" ><i class="gicon-eye-open">View</i></asp:LinkButton>
                                
                                    <asp:LinkButton ID="lbtnRemove" CssClass="green btn btn-small" runat="server" CommandName="remove" CommandArgument='<%#Eval("txn_id") %>' ToolTip="Remove"><i class="gicon-remove">Remove</i></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                        </asp:ListView>
                    </div>
                    <!-- /.table-responsive -->

                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->
    </div>

    <script src="../Scripts/jquery.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>

    <script src="../Scripts/metisMenu.min.js"></script>
    <!-- Metis Menu Plugin JavaScript -->
    <script src="../Scripts/jquery.dataTables.min.js"></script>
    <script src="../Scripts/sb-admin-2.js"></script>
    <script src="../Scripts/dataTables.bootstrap.min.js"></script>
    <script>
        $(document).ready(function () {
            $('#dataTables-example').DataTable({
                responsive: true
            });
        });
    </script>
</asp:Content>
