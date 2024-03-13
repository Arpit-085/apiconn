<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="phone.aspx.cs" Inherits="forgetpasswordportal.phone" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Portal</title>
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" media="all" />
    <link href="css/style.css" rel="stylesheet" type="text/css" media="all" />
    <link href="css/font-awesome.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/jstarbox.css" type="text/css" media="screen" charset="utf-8" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="cart">
            <div class="container">
                <div class="col-md-8 cart-items">
                    <div class="main-agileits" style="width: 100%; width: 100%;
    display: flex;
    align-items: center;
    justify-content: center;">
                        <div class="form-w3agile form1" style="width: 300px;
    background: yellow;
    padding: 32px;">
                            <h3 style="background-color:red;">Login To Admin</h3>
                            <div class="key">
                                <asp:TextBox ID="txtPhone" runat="server" placeholder="Enter Mobile Number"></asp:TextBox>
                                <div class="clearfix"></div>
                            </div>
                            <asp:Label ID="lblMessage" runat="server" ></asp:Label>
                            <asp:Button ID="btnSend" OnClick="btnSend_Click" runat="server" Text="Send OTP" /><br /><br />
                            <div class="key">
                                <asp:TextBox ID="txtOTP" runat="server" Visible="false" placeholder="Enter OTP"></asp:TextBox>
                                <div class="clearfix"></div>
                            </div>
                            <asp:Button ID="btnVerify" OnClick="btnVerify_Click" Visible="false" runat="server" Text="Login" /><br /><br />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
