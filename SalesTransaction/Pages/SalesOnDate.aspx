<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesOnDate.aspx.cs" Inherits="SalesTransaction.Pages.SalesOnDate" MasterPageFile="~/SiteMaster.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">


    <!-- /.row -->
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Transaction By Date
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div class="dataTable_wrapper">
                        <asp:ListView runat="server" ID="lvTotalByDate">
                            <LayoutTemplate>
                                <table class="table table-striped table-bordered table-hover" id="dataTables-example">
                                    <thead>
                                        <tr>
                                             <th>
                                                <asp:Label ID="lblInvoice" Text="Date" runat="server"></asp:Label></th>
                                            <th>
                                                <asp:Label ID="lblName" Text="Total Transaction" runat="server"></asp:Label></th>
                                            
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
                                    <%# Eval("date") %>
                                </td>
                                <td>
                                    <%# Eval("Total") %>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lbEdit" CssClass="green btn btn-small" runat="server" CommandName="edit"  ToolTip="Edit"><i class="gicon-edit"></i>Show Detail</asp:LinkButton>
                               
                                    <asp:LinkButton ID="lbtnView" CssClass="green btn btn-small" runat="server" CommandName="view"  ToolTip="View" ><i class="gicon-eye-open">View</i></asp:LinkButton>
                                
                                    <asp:LinkButton ID="lbtnRemove" CssClass="green btn btn-small" runat="server" CommandName="remove"  ToolTip="Remove"><i class="gicon-remove">Remove</i></asp:LinkButton>
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

