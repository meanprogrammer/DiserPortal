<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="DiserPortal._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.: Diser Portal :.</title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <%--<script type="text/javascript">
        Date.prototype.getWeek = function (start) {
            start = start || 0;
            var today = new Date(this.setHours(0, 0, 0, 0));
            var day = today.getDay() - start;
            var date = today.getDate() - day;

            var startday = new Date(today.setDate(date + 1));
            var endday = new Date(today.setDate(date + 7));
            return [startday, endday];
        }
        Date.prototype.getMonthStartandEndDate = function () {
            var today = new Date(this.setHours(0, 0, 0, 0));
            var startday = new Date(today.setDate(1));
            var endday = new Date(today.setMonth(today.getMonth() + 1));
            endday.setDate(endday.getDate() - 1)
            return [startday, endday];
        }
        Date.prototype.getYearStartandEndDate = function () {
            var year = this.getFullYear();
            var startday = new Date(year, 0, 1, 0, 0, 0, 0);
            var endday = new Date(startday.setFullYear(year + 1));
            endday.setDate(endday.getDate() - 1)
            return [startday, endday];
        }
        var date = new Date();
        var A = date.getWeek();
        var b = date.getMonthStartandEndDate();
        var y = date.getYearStartandEndDate();
        alert(A[0].toLocaleDateString() + ' to ' + A[1].toLocaleDateString());
        alert(b[0].toLocaleDateString() + ' to ' + b[1].toLocaleDateString());
        alert(y[0].toLocaleDateString() + ' to ' + y[1].toLocaleDateString());
    </script>--%>
</head>
<body>

<form id="form1" runat="server" defaultbutton="btnLogin" defaultfocus="txtUname">
<asp:ScriptManager ID="ScriptManager2" runat="server"/>

<asp:UpdatePanel id="updClient" runat="server" >
<contenttemplate>

    <div class="page">
        <div class="header">
        </div>
        <div class="main">
            <h2>
                &nbsp;Log In
            </h2>
            <p>
                Please enter your username and password.
                <%--<asp:HyperLink ID="RegisterHyperLink" runat="server" EnableViewState="false">Register</asp:HyperLink> if you don't have an account.--%>
            </p>
            <%--<asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false">--%>                <%--<LayoutTemplate>--%>
                <div>
                    <span class="failureNotification">
                        <asp:Label runat="server" ID="lbleMsg1" Text="" cssclass="failureNotification"></asp:Label>
                        <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                    </span>
                
                    <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="vgLogin"/>
                         </div>
                    <div class="accountInfo">
                        <fieldset class="login">
                            <legend>Account Information</legend>
                            <p>
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtUname">Username:</asp:Label>
                                <asp:TextBox ID="txtUname" runat="server" CssClass="textEntry" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtUname" 
                                     CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." 
                                     ValidationGroup="vgLogin"><img id='Img2' style='cursor:help' 
                src='images/icons/rfvIcon.png'/></asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="txtPwd">Password:</asp:Label>
                                <asp:TextBox ID="txtPwd" runat="server" CssClass="passwordEntry" 
                                    TextMode="Password" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPwd" 
                                     CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                                     ValidationGroup="vgLogin"><img id='Img1' style='cursor:help' 
                src='images/icons/rfvIcon.png'/></asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:LinkButton runat="server" ID="lkbForgot" text="Forgot Password?" CssClass="inline"></asp:LinkButton>&nbsp;&nbsp;
                                <br />
                                
                                <%--<asp:CheckBox ID="RememberMe" runat="server"/>
                                <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Keep me logged in</asp:Label>--%>
                            </p>
                            
                            <%--<p>
                                <asp:CheckBox ID="RememberMe" runat="server"/>
                                <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Keep me logged in</asp:Label>
                            </p>--%>
                        </fieldset>
                        <p class="submitButton">
                            <asp:Button ID="btnLogin0" runat="server" Text="Populate Week" Visible="False"/>
                            <asp:Button ID="btnLogin" runat="server" onclick="btnLogin_Click" Text="Log In" 
                                ValidationGroup="vgLogin" />
                        </p>
                    </div>
            <%--</LayoutTemplate>--%>            <%--</asp:Login>--%>
        </div>
    </div>
    
</contenttemplate>
</asp:UpdatePanel>
</form>
  
</body>
</html>
