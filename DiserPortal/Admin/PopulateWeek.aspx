<%@ Page Title="" Language="vb" MasterPageFile="~/Site_blank.Master" AutoEventWireup="false" CodeBehind="PopulateWeek.aspx.vb" Inherits="DiserPortal.populateweek" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <p>
		<asp:Panel ID="pnlAdd" runat="server" Visible="false">
			<br/>
			<table width="700">
				<tr>
					<td width="100">From:</td>
					<td width="600"><asp:textbox id="a_wFrom" name="n_wFrom" runat="server" size="20" />&nbsp;Example: M/D/YYYY&nbsp;<b><font color="red">*</font></b></td>
				</tr>
				<tr>
					<td width="100">To:</td>
					<td width="600"><asp:textbox id="a_wTo" name="n_wTo" runat="server" size="20" />&nbsp;Example: M/D/YYYY&nbsp;<b><font color="red">*</font></b></td>
				</tr>
				<tr>
					<td width="100">Week Coverage:</td>
					<td width="600"><asp:textbox id="a_weekCoverage" name="n_weekCoverage" runat="server" size="20" />&nbsp;Example: Feb 3 - Feb 9, 2014&nbsp;<b><font color="red">*</font></b></td>
				</tr>
				<tr>
					<td width="100">Year:</td>
					<td width="600"><asp:textbox id="a_wYear" name="n_wYear" runat="server" size="20" />&nbsp;2014</td>
				</tr>
				<tr>
					<td width="100">Month ID:</td>
					<td width="600"><asp:textbox id="a_wMonthID" name="n_wMonthID" runat="server" size="20" />&nbsp;Example: 11 (range is 1-12)</td>
				</tr>
				<tr>
					<td width="100">Week No.:</td>
					<td width="600"><asp:textbox id="a_wNo" name="n_wNo" runat="server" size="20" />&nbsp;Example: 3 (range is 1-4 or 1-5)</td>
				</tr>
				<tr>
					<td colspan="2" width="700"><asp:HiddenField ID="a_hidden" runat="server" /><b><font color="red">*</font></b>&nbsp;Trailing zeroes (0) are not allowed.<br/>
				&nbsp;&nbsp;For example, if Dec 9, 2014 is entered as Dec 09, 2014, an error will occur.</td>
				</tr>
				<tr>
					<td colspan="2" width="700"><asp:Button ID="submit_add" runat="server" text="Add" /></td>
				</tr>
			</table>
		</asp:Panel>

		<asp:Panel ID="pnlEdit" runat="server" Visible="false">
			<br/>
			<table width="700">
				<tr>
					<td width="100">From:</td>
					<td width="600"><asp:textbox id="i_wFrom" name="n_wFrom" runat="server" size="20" />&nbsp;Example: M/D/YYYY&nbsp;<b><font color="red">*</font></b></td>
				</tr>
				<tr>
					<td width="100">To:</td>
					<td width="600"><asp:textbox id="i_wTo" name="n_wTo" runat="server" size="20" />&nbsp;Example: M/D/YYYY&nbsp;<b><font color="red">*</font></b></td>
				</tr>
				<tr>
					<td width="100">Week Coverage:</td>
					<td width="600"><asp:textbox id="i_weekCoverage" name="n_weekCoverage" runat="server" size="20" />&nbsp;Example: Feb 3 - Feb 9, 2014&nbsp;<b><font color="red">*</font></b></td>
				</tr>
				<tr>
					<td width="100">Year:</td>
					<td width="600"><asp:textbox id="i_wYear" name="n_wYear" runat="server" size="20" />&nbsp;2014</td>
				</tr>
				<tr>
					<td width="100">Month ID:</td>
					<td width="600"><asp:textbox id="i_wMonthID" name="n_wMonthID" runat="server" size="20" />&nbsp;Example: 11 (range is 1-12)</td>
				</tr>
				<tr>
					<td width="100">Week No.:</td>
					<td width="600"><asp:textbox id="i_wNo" name="n_wNo" runat="server" size="20" />&nbsp;Example: 3 (range is 1-4 or 1-5)</td>
				</tr>
				<tr>
					<td colspan="2" width="700"><asp:HiddenField ID="i_hidden" runat="server" /><b><font color="red">*</font></b>&nbsp;Trailing zeroes (0) are not allowed.<br/>
					&nbsp;&nbsp;For example, if Dec 9, 2014 is entered as Dec 09, 2014, an error will occur.</td>
				</tr>
				<tr>
					<td colspan="2" width="700"><asp:Button ID="submit_edit" runat="server" text="Edit" /></td>
				</tr>
			</table>
		</asp:Panel>

		<asp:Panel ID="pnlDelete" runat="server" Visible="false">

		</asp:Panel>

		<br/>

		Populate the Week(s) table:<br/>
		<asp:Literal ID="litWkTable" runat="server"/>

		<br/>
		
    </p>
</asp:Content>