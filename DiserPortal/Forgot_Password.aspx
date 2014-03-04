<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Forgot_Password.aspx.vb" Inherits="DiserPortal.Forgot_Password" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>

<form runat="server">



<contenttemplate>
   
    <div class="page">
        <div class="header">
        </div>
        <div class="main">
            <h2>
                Forgot Password</h2>
            <p>
                Please enter your registered email address to reset your password.
            </p>
                <div>
                    <span class="failureNotification">
                        <asp:Label runat="server" ID="lbleMsg" Text="" cssclass="failureNotification"></asp:Label>
                    </span>
                         </div>
                    <div class="accountInfo">
                        <fieldset class="login">
							<legend>Password Reset</legend>
                            <p>
								Email&nbsp;<asp:RequiredFieldValidator ID="p_email_validator" ControlToValidate="liame" Font-Bold="true" ForeColor="Red" Text="*" runat="server" Display="Dynamic" /><asp:RegularExpressionValidator id="p_email_reg" runat="server" ControlToValidate="liame" Font-Bold="true" ForeColor="Red" Text="must be valid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  Display="Dynamic" />
                                <br/>
                                <asp:TextBox ID="liame" runat="server" CssClass="textEntry"></asp:TextBox>
                            </p>
                        </fieldset>
						<asp:Button runat="server" ID="send_email" Text="Send" class="submitButton" />
                    </div>
        </div>
    </div>

</contenttemplate>

</form>
</body>
</html>
