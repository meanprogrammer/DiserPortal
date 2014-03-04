<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SecurityQuestion.aspx.vb" Inherits="DiserPortal.SecurityQuestion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server" defaultbutton="btnValidate" defaultfocus="txtAnswer">
<asp:ScriptManager ID="ScriptManager2" runat="server"/>

<asp:UpdatePanel id="updClient" runat="server" >
<contenttemplate>
    
    <div class="page">
        <div class="header">
        </div>
        <div class="main">
            <h2>
                Password retrieval</h2>
            <p>
                Kindly answer your security question.</p>
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
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtQuestion">Security 
                                Question:</asp:Label>
                                <asp:TextBox ID="txtQuestion" runat="server" CssClass="textEntry" 
                                    ReadOnly="True"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="txtAnswer">Answer:</asp:Label>
                                <asp:TextBox ID="txtAnswer" runat="server" CssClass="passwordEntry" 
                                    TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtAnswer" 
                                     CssClass="failureNotification" 
                                    ErrorMessage="Kindly answer the security question." ToolTip="&lt;img id='Img1' style='cursor:help' " 
                                     ValidationGroup="vgLogin"><img id='Img1' style='cursor:help' 
                                        src='images/icons/rfvIcon.png'/></asp:RequiredFieldValidator>
                            </p>
                            <p>
                                &nbsp;<br />
                                
                                <%--<asp:CheckBox ID="RememberMe" runat="server"/>
                                <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Keep me logged in</asp:Label>--%>
                            </p>
                            
                            <%--<p>
                                <asp:CheckBox ID="RememberMe" runat="server"/>
                                <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Keep me logged in</asp:Label>
                            </p>--%>
                        </fieldset>
                        <p class="submitButton">
                            <asp:Button ID="btnValidate" runat="server" Text="Validate" 
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
