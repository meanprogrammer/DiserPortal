<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="NewUser.aspx.vb" Inherits="DiserPortal.NewUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>

<form id="form1" runat="server" defaultbutton="btnUpdate" defaultfocus="txtNPwd">
<asp:ScriptManager ID="ScriptManager2" runat="server"/>

<asp:UpdatePanel id="updClient" runat="server" >
<contenttemplate>
    
    <div class="page">
        <div class="header">
        </div>
        <div class="main">
            <h2>
                New User Info update</h2>
            <p>
                Please change your password and update your security information.</p>
            <%--<asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false">--%><%--<LayoutTemplate>--%>
                <div>
                    <span class="failureNotification">
                        <asp:Label runat="server" ID="lbleMsg" Text="" cssclass="failureNotification"></asp:Label>
                        <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                    </span>
                
                    <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="vgLogin"/>
                         </div>
                    <div class="accountInfo">
                        <fieldset class="login">
                            <legend>Account Information</legend>
                            <p>
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtNPwd">New 
                                Password:</asp:Label>
                                <asp:TextBox ID="txtNPwd" runat="server" CssClass="textEntry" 
                                    TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtNPwd" 
                                     CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="User Name is required." 
                                     ValidationGroup="vgLogin"><img id='Img2' style='cursor:help' 
                                       src='images/icons/rfvIcon.png'/></asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="txtCPwd">Confirm 
                                Password:</asp:Label>
                                <asp:TextBox ID="txtCPwd" runat="server" CssClass="passwordEntry" 
                                    TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtCPwd" 
                                     CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                                     ValidationGroup="vgLogin"><img id='Img1' style='cursor:help' 
                                        src='images/icons/rfvIcon.png'/></asp:RequiredFieldValidator>
                            </p>
                            <p>
                                &nbsp;<br />
                            <p>
                                <asp:Label ID="lblSQ" runat="server" AssociatedControlID="ddlSQ">Security Question:</asp:Label>
                                <asp:DropDownList ID="ddlSQ" runat="server" Width="320px"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvSQ" runat="server" ControlToValidate="ddlSQ" 
                                     CssClass="failureNotification" ErrorMessage="Security Question is required." 
                                     ToolTip="Security Question is required." 
                                     ValidationGroup="vgLogin"><img id='Img3' style='cursor:help' 
                                       src='images/icons/rfvIcon.png'/></asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="lblAns" runat="server" AssociatedControlID="txtAns">Answer:</asp:Label>
                                <asp:TextBox ID="txtAns" runat="server" CssClass="passwordEntry" 
                                    TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvAns" runat="server" ControlToValidate="txtAns" 
                                     CssClass="failureNotification" ErrorMessage="Answer is required." ToolTip="Answer is required." 
                                     ValidationGroup="vgLogin"><img id='Img4' style='cursor:help' 
                                        src='images/icons/rfvIcon.png'/></asp:RequiredFieldValidator>
                            </p>    
                                <%--<asp:CheckBox ID="RememberMe" runat="server"/>
                                <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Keep me logged in</asp:Label>--%>
                                <p>
                                </p>
                                <%--<p>
                                <asp:CheckBox ID="RememberMe" runat="server"/>
                                <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Keep me logged in</asp:Label>
                            </p>--%>
                            </p>
                            
                        </fieldset>
                        <p class="submitButton">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                                ValidationGroup="vgLogin"/>
                            <%--<asp:Button ID="btnLogin" runat="server" Text="Log In" 
                                ValidationGroup="LoginUserValidationGroup" onclick="btnLogin_Click"/>--%>
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel"/>
                        </p>
                    </div>
            <%--</LayoutTemplate>--%><%--</asp:Login>--%>
        </div>
    </div>

</contenttemplate>
</asp:UpdatePanel>
</form>

</body>
</html>
