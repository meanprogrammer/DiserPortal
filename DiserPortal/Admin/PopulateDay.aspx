<%@ Page Title="" Language="vb" MasterPageFile="~/Site_blank.Master" AutoEventWireup="false" CodeBehind="PopulateDay.aspx.vb" Inherits="DiserPortal.populateday" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <p>
		<asp:Panel ID="pnlAdd" runat="server" Visible="false">
			<br/>
			Date: <asp:textbox id="a_wDay" name="n_wDay" runat="server" size="20" />&nbsp;Example: Dec 9, 2014&nbsp;<b><font color="red">*</font></b><br/>
			Week ID: <asp:textbox id="a_weekID" name="n_weekID" runat="server" size="20" />&nbsp;Example: 1 (range is 1-52)<br/>
			<asp:HiddenField ID="a_hidden" runat="server" />
			<b><font color="red">*</font></b>&nbsp;Trailing zeroes (0) are not allowed.<br/>
			&nbsp;&nbsp;For example, if Dec 9, 2014 is entered as Dec 09, 2014, an error will occur.<br/>
			<asp:Button ID="submit_add" runat="server" text="Add" />
		</asp:Panel>

		<asp:Panel ID="pnlEdit" runat="server" Visible="false">
			<br/>
			Date: <asp:textbox id="i_wDay" name="n_wDay" runat="server" size="20" />&nbsp;<b><font color="red">*</font></b><br/>
			weekID: <asp:textbox id="i_weekID" name="n_weekID" runat="server" size="20" /><br/>
			<asp:HiddenField ID="i_hidden" runat="server" />
			<b><font color="red">*</font></b>&nbsp;Trailing zeroes (0) are not allowed.<br/>
			&nbsp;&nbsp;For example, if Dec 9, 2014 is entered as Dec 09, 2014, an error will occur.<br/>
			<asp:Button ID="submit_edit" runat="server" text="Edit" />
		</asp:Panel>

		<asp:Panel ID="pnlDelete" runat="server" Visible="false">

		</asp:Panel>

		<br/>

		Populate the Day(s) table:<br/>
		<asp:Literal ID="litWDTable" runat="server"/>

		<br/>

    </p>
</asp:Content>