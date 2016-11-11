<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEditProduct.aspx.cs" Inherits="SalesTransaction.Pages.AddEditProduct" MasterPageFile="~/SiteMaster.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
   
            <div class="row">
                <div class="col-lg-12">
                   
                </div>
                <!-- /.col-lg-12 -->
            </div>
     <div class="row">
                <div class="col-lg-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Add Edit Products
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-12">
                                    
                                        <div class="form-group">
                                            <label>Name</label>
                                           <asp:TextBox runat="server" ID="txtProductName" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    <div class="form-group">
                                            <label>Category</label>
                                         <asp:TextBox runat="server" ID="txtCategory" CssClass="form-control"></asp:TextBox>
                                        <%--<asp:DropDownList runat="server" ID="ddlCategory" CssClass="form-control">
                                            <asp:ListItem Text="Electronics" Value="0"></asp:ListItem>
                                             <asp:ListItem Text="CLothes" Value="1"></asp:ListItem>
                                             <asp:ListItem Text="COsmetics" Value="2"></asp:ListItem>
                                            </asp:DropDownList>--%>
                                          
                                        </div>
                                    <div class="form-group">
                                            <label>Rate</label>
                                           <asp:TextBox runat="server" ID="txtProductRate" CssClass="form-control"></asp:TextBox>
                                        </div>
                                     <div class="form-group">
                                           <asp:CheckBox runat="server" ID="chkStatus" Text="Is Active" CssClass="form-control"/>
                                        </div>
                                        <asp:Button runat="server" ID="btnAdd" Text="Add" CssClass="btn btn-primary" OnClick="btnAdd_OnClick"/>
                                        
                                </div>
                               
                            </div>
                            <!-- /.row (nested) -->
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
            </div>
         <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Products List
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="dataTable_wrapper">
                                <asp:ListView ID="lvProducts" runat="server">
                        <LayoutTemplate>
                                <table class="table table-striped table-bordered table-hover" id="dataTables-example">
                                    <thead>
                                        <tr>
                                            <th><asp:Label ID="lblId" Text="ID"  runat="server"></asp:Label></th>
                                            <th><asp:Label ID="lblName" Text="NAme"  runat="server"></asp:Label></th>
                                            <th><asp:Label ID="lblCategory" Text="Category"  runat="server"></asp:Label></th>
                                            <th><asp:Label ID="lblRate" Text="Rate"  runat="server"></asp:Label></th>
                                            <th><asp:Label ID="lblStatus" Text="Status"  runat="server"></asp:Label></th>
                                            <th>
                                            <asp:Label ID="lblAction" runat="server" Text="Action"></asp:Label>
                                        </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                           <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                                    <ItemTemplate>
                            <tr>
                                <td>
                                    <%# Eval("product_id").ToString()%>
                                </td>
                                <td>
                                    <%# Eval("product_name") %>
                                </td>
                                <td>
                                    <%# Eval("product_category") %>
                                </td>
                                <td>
                                    <%# Eval("product_rate") %>
                                </td>
                                 <td>
                                    <%# Eval("is_active") %>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lbEdit" CssClass="green btn btn-small" runat="server" CommandName="edit" CommandArgument='<%#Eval("product_id") %>' ToolTip="Edit" OnCommand="lbEdit_OnCommand"><i class="gicon-edit"></i>Edit</asp:LinkButton>
                               
                                    <asp:LinkButton ID="lbtnView" CssClass="green btn btn-small" runat="server" CommandName="view" CommandArgument='<%#Eval("product_id") %>' ToolTip="View" ><i class="gicon-eye-open">View</i></asp:LinkButton>
                                
                                    <asp:LinkButton ID="lbtnRemove" CssClass="green btn btn-small" runat="server" CommandName="remove" CommandArgument='<%#Eval("product_id") %>' ToolTip="Remove"><i class="gicon-remove">Remove</i></asp:LinkButton>
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
             </div>
        </div>
     <script src="../Scripts/jquery.min.js"></script>
     <script src="../Scripts/bootstrap.min.js"></script>
        
    <script src="../Scripts/metisMenu.min.js"></script>
        <!-- Metis Menu Plugin JavaScript -->
    <script src="../Scripts/jquery.dataTables.min.js"></script>
    <script src="../Scripts/sb-admin-2.js"></script>
    <script src="../Scripts/dataTables.bootstrap.min.js"></script>
       <script>
    $(document).ready(function() {
        $('#dataTables-example').DataTable({
                responsive: true
        });
    });
    </script>
</asp:Content>
