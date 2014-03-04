<%@ Page Title="Session Refresh" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="Feedback.aspx.vb" Inherits="DiserPortal.Feedback" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Your report has been submitted</h2>
    <p>
        Do you have any additional questions, issues or concerns?
    </p>
	<p>
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button runat="server" Text="No" ID="btnNo" OnClick="btnNo_Click"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Button runat="server" Text="Yes" ID="btnYes" OnClick="btnYes_Click"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Button runat="server" Text="Logout" ID="btnLogout" OnClick="btnLogout_Click"></asp:Button>
	</p>
</asp:Content>