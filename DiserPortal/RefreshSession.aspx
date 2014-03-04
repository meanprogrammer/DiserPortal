<%@ Page Title="Session Refresh" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="RefreshSession.aspx.vb" Inherits="DiserPortal.RefreshSession" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Your session is about to expire</h2>
    <p>
        <b>Note:</b> Your user session will expire in less than 5 minutes. Please select an option below:
    </p>
	<ul>
		<li><asp:Button runat="server" Text="Extend session" ID="btnExtendSes" OnClick="btnExtendSes_Click"></asp:Button></li>
		<li><asp:Button runat="server" Text="Logout" ID="btnLogout" OnClick="btnLogout_Click"></asp:Button></li>
	</ul>
</asp:Content>