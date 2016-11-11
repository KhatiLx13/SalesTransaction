<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SalesTransaction.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Login</title>

      <link href="Styles/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="Styles/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="Styles/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="Styles/font-awesome.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-4 col-md-offset-4">
                    <div class="login-panel panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Please Sign In</h3>
                        </div>
                        <div class="panel-body">
                            
                                <fieldset>
                                    <div class="form-group">
                                        <asp:TextBox runat="server" ID="txtName" class="form-control" placeholder="Please enter User NAme" ></asp:TextBox>
                                        
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox runat="server" ID="txtPassword" class="form-control" placeholder="Please enterPassword" ></asp:TextBox>
                                    </div>
                                   
                                    <!-- Change this to a button or input when using this as a form -->
                                    <asp:Button runat="server" ID="btnLogin" class="btn btn-lg btn-success btn-block" Text="Login" OnClick="btnLogin_OnClick" />
                                   
                                </fieldset>
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- jQuery -->
       <script src="Scripts/jquery.min.js"></script>
        

        <!-- Bootstrap Core JavaScript -->
    <script src="Scripts/bootstrap.min.js"></script>
        
    <script src="Scripts/metisMenu.min.js"></script>
        <!-- Metis Menu Plugin JavaScript -->
        
    <script src="Scripts/sb-admin-2.js"></script>
        <!-- Custom Theme JavaScript -->
    </form>
</body>
</html>
