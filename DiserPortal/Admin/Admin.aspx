<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
CodeBehind="Admin.aspx.vb" Inherits="DiserPortal.Admin" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%--<div style="padding:15px; text-align:left;vertical-align:middle;float:right;">
                <asp:Image runat="server" Height="20px" ImageUrl="~/images/icons/loading.gif" />
            </div>--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <center>
<div class="dataWrapper">

<asp:UpdatePanel ID="updTM" runat="server">
<ContentTemplate>

<DIV id="main_wrap"><br />
<div style="height:50px;float:right;">
        <asp:UpdateProgress ID="PageUpdateProgress2" runat="server">
            <progresstemplate>
            
            <div style="padding: 10px; vertical-align:top;float:left;">
                <asp:Image runat="server" Height="20px" ImageUrl="~/images/icons/loading.gif" />
            </div>
            <%--<div style="padding:15px; text-align:left;vertical-align:middle;float:right;">
                <asp:Image runat="server" Height="20px" ImageUrl="~/images/icons/loading.gif" />
            </div>--%>
        </progresstemplate>
    </asp:UpdateProgress></div>
<DIV id="tab_wrap">
    <UL class="tabprop">
        <LI><br />
            <asp:LinkButton ID="lnkAnnounce" runat="server" CssClass="tabprop-Selected" 
                Text="Announcements"></asp:LinkButton></LI>
        <LI><br />
            <asp:LinkButton ID="lnkSupport" runat="server" CssClass="tabprop-selected" 
                Text="Support<br/>Submissions"></asp:LinkButton></LI>
        <LI><br />
            <asp:LinkButton ID="lnkAccnt" runat="server" CssClass="tabprop-selected" 
                Text="User<br/>Accounts"></asp:LinkButton></LI>
        <LI><br />
            <asp:LinkButton id="lnkAType" runat="server" CssClass="tabprop" 
                Text="User Account<br/>Type"></asp:LinkButton> </LI>
        <LI><br /><asp:LinkButton id="lnkData" runat="server" CssClass="tabprop-selected" 
                Text="Data<br/>Build-Up"></asp:LinkButton></LI>
        <%--<asp:Label ID="lblNote" runat="server" Text="<br />Coming Soon!" 
            style="height:46px;font-weight:bolder;font-size:15px;vertical-align:middle;color:Red;float:left;padding-top:12px;margin-top:-12px;padding-left:15px;" 
            Visible="False"></asp:Label>--%>
        
    </UL>
</DIV></DIV>
<!-- end tab wrap -->


<%--<DIV style="CLEAR: both">
</DIV>--%>

<DIV id="cont_wrap">

    <%--<asp:UpdateProgress ID="PageUpdateProgress2" runat="server">
        <progresstemplate>
            <div style="width:100%">
            <div style="padding: 15px; vertical-align:middle;float:left;">
                <asp:Image runat="server" Height="20px" ImageUrl="~/images/icons/loading.gif" />
            </div>
            <div style="text-align:center;"><asp:Label ID="lbleMsg" runat="server" ForeColor="red" text=""></asp:Label></div>
            <div style="padding:15px; text-align:right;vertical-align:middle;float:right;">
                <asp:Image runat="server" Height="20px" ImageUrl="~/images/icons/loading.gif" />
            </div></div>
        </progresstemplate>
    </asp:UpdateProgress>--%>
    <DIV style="height:15px; color:Red;font-weight:bolder;bgcolor:#104996;vertical-align:bottom;padding:7px;">
    <asp:Label ID="lbleMsg" runat="server" ForeColor="red" text=""></asp:Label></DIV>


<%--ACCOUNT TYPE--%>
<asp:Panel ID="panAType" runat="server" Visible="False">
<div style="text-align:left; padding-left:25px; vertical-align: top;">
    .<table>
        <tr>
            <td class="" colspan="3">
                <h2 style="vertical-align:top;">
                    User Account Types</h2>
            </td>
            <td class="style1" colspan="5">
                &nbsp;</td>
            <td class="style1">
            </td>
            <td class="style1">
            </td>
            <td class="style1">
            </td>
        </tr>

    <tr>

    
    <td style="height:90px;" colspan="8">
        <p>CREATE - To create a new User Account Type please click on the ‘Create’ button.<br />
           MODIFY - To edit an existing User Account Type please select the desired account type to edit its permissions.</p>
    </td>
    <td style="height:90px;">
        &nbsp;</td>
    <td style="height:90px;">
        &nbsp;</td>
    <td style="height:90px;">
        &nbsp;</td>
    </tr>

    <tr>
    <td colspan="2"><strong>User Account:</strong></td>
    <td colspan="9">
        <asp:DropDownList ID="ddlAType" runat="server" Width="350px" 
            AutoPostBack="True">
        </asp:DropDownList>
        <asp:TextBox ID="txtAType" runat="server" Visible="False" Width="345px"></asp:TextBox>
        <asp:Button ID="btnCreate" runat="server" Text="Create" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="False" />

        </td>
    </tr>

    <tr>
    <td>
    </td>
    <td width="35px">
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    </tr>

    <tr>
    <td><strong>FORMS:</strong></td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;<asp:CheckBox ID="chkFSales" runat="server" 
            Text="Sales Form" Enabled="False" AutoPostBack="True">
        </asp:CheckBox>
        </td>
    <td width="50px">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
    <td>
        <strong>REPORTS:</strong>
        </td>
    <td>
        &nbsp;</td>
    <td>
        <asp:CheckBox ID="chkRSales" runat="server" 
            Text="Sales Form" Enabled="False" AutoPostBack="True">
        </asp:CheckBox>
        </td>
    <td width="75px">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
    <td>
        <strong>ADMIN:&nbsp; </strong>
        </td>
    <td>
        &nbsp;</td>
    <td>
        <asp:CheckBox ID="chkData" runat="server" 
            Text="Data Management" Enabled="False">
        </asp:CheckBox>
        </td>
    </tr>

    <tr>
    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
    <td>
        &nbsp;&nbsp; &nbsp;</td>
    <td>
        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:CheckBox ID="chkFProd" runat="server" Text="Product Registration" 
            Enabled="False" AutoPostBack="True">
        </asp:CheckBox>
        </td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        &nbsp;</td>
    <td>
        &nbsp;&nbsp; &nbsp;</td>
    <td>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="chkRProd" runat="server" Text="Product Registration" 
            Enabled="False" AutoPostBack="True">
        </asp:CheckBox>
        </td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
    <td>
        &nbsp;&nbsp; &nbsp;</td>
    <td>
        <asp:CheckBox ID="chkAnnounce" runat="server" 
            Text="Announcement" Enabled="False">
        </asp:CheckBox>
        </td>
    </tr>

    <tr>
    <td>&nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:CheckBox ID="chkFCompete" runat="server" Text="Competitor Sales" 
            Enabled="False" AutoPostBack="True">
        </asp:CheckBox>
        </td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="chkRCompete" runat="server" Text="Competitor Sales" 
            Enabled="False" AutoPostBack="True">
        </asp:CheckBox>
        </td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        <asp:CheckBox ID="chkContent" runat="server" 
            Text="Content Management" Enabled="False">
        </asp:CheckBox>
        </td>
    </tr>

    <tr>
    <td>&nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="chkFStocks" runat="server" 
            Text="Stocks Run Out" Enabled="False" AutoPostBack="True">
        </asp:CheckBox>
        </td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="chkRStocks" runat="server" Text="Stocks Run Out" 
            Enabled="False" AutoPostBack="True">
        </asp:CheckBox>
        </td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    </tr>

    <tr>
    <td>&nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="chkFInventory" runat="server" 
            Text="Stocks Inventory" Enabled="False" AutoPostBack="True">
        </asp:CheckBox>
        </td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="chkRInventory" runat="server" 
            Text="Stocks Inventory" Enabled="False" AutoPostBack="True">
        </asp:CheckBox>
        </td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    </tr>

	<tr>
		<td>&nbsp;</td>
		<td>&nbsp;</td>
		<td>&nbsp;</td>
		<td>&nbsp;</td>
		<td>&nbsp;</td>
		<td>&nbsp;</td>
		<td>
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:CheckBox ID="chkRTM" runat="server" Text="TM Sales" Enabled="False" AutoPostBack="True">
			</asp:CheckBox>
		</td>
		<td>&nbsp;</td>
		<td>&nbsp;</td>
		<td>&nbsp;</td>
		<td>&nbsp;</td>
    </tr>

    <tr>
    <td>&nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        <asp:CheckBox ID="chkFVisual" runat="server" 
            Text="Visual Mechandising" Enabled="False">
        </asp:CheckBox>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        <asp:CheckBox ID="chkRVisual" runat="server" 
            Text="Visual Merchandising Report" Enabled="False">
        </asp:CheckBox>
        </td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    </tr>

    <tr>
    <td>&nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        <asp:CheckBox ID="chkFTrade" runat="server" 
            Text="Trade Highlights" Enabled="False">
        </asp:CheckBox>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        <asp:CheckBox ID="chkRTrade" runat="server" 
            Text="Trade Highlights" Enabled="False">
        </asp:CheckBox>
        </td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    </tr>

    <tr>
    <td>&nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        <asp:CheckBox ID="chkFSupport" runat="server" Enabled="False" Text="Support" />
        </td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        <asp:CheckBox ID="chkRSupport" runat="server" Enabled="False" Text="Support" />
        <br />
        </td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    </tr>
    </table><br /><br />
    </div>
</asp:Panel>







<%--DATA BUILD-UP--%>
<asp:Panel ID="panData" runat="server" visible="false">

<DIV style="CLEAR: both"></DIV>

<DIV>

<!-- START PLACING CONTENT HERE -->
<%--<DIV style="HEIGHT: 20px"></DIV>     style="PADDING-LEFT: 20px; FLOAT: left"--%>
<DIV style="width:100%;">
<table width="100%" style="padding-left:20px;padding-right:20px;" align="left">
<tr>
<td>
</td>
<td>
</td>
</tr>

    <tr>
        <td align="left" rowspan="2" valign="top" bgcolor="#104996" 
            style="padding: 5px;" width="160px">
            <asp:Button ID="btnHGeneral" runat="server" Text="General" 
                Width="150px" BackColor="#FFE24C" />
            <br />
            <asp:Button ID="btnHSupport" runat="server" Text="Support" Width="150px" />
            <br />
            <br />
            <asp:Button ID="btnHStore" runat="server" Text="Store Data" Width="150px" />
            <br />
            <asp:Button ID="btnHCCAC" runat="server" Text="CCAC Data" Width="150px" />
            <br />
            <asp:Button ID="btnHCompete" runat="server" Text="Competitors' Data" 
                Width="150px" />
            <br />
            <asp:Button ID="btnHReport" runat="server" Text="Performance Tracker" 
                Width="150px" />
            <br />
			<br />
			<asp:Button ID="btnPopDay" runat="server" Text="Populate Days" Width="150px" OnClick="btnPopDay_Click" />
			<br />
			<asp:Button ID="btnPopWeek" runat="server" Text="Populate Weeks" Width="150px" OnClick="btnPopWeek_Click" />
            <br />
            <asp:Button ID="btnHSA" runat="server" Text="SA" Visible="False" 
                Width="150px" />
            <br />
            <asp:TextBox ID="txtSA" runat="server" Visible="False" Width="30px" 
                TextMode="Password" BackColor="#104996" BorderStyle="None"></asp:TextBox>
        </td>
        <td style="padding: 5px;" align="right" bgcolor="#104996">
            <asp:Button ID="btnProd" runat="server" Text="Product" 
                Visible="False" Width="150px" />
            <asp:Button ID="btnBrand" runat="server" Text="Brand" Visible="False" 
                Width="150px" />
            <asp:Button ID="btnItem" runat="server" Text="Item" Visible="False" 
                Width="150px" />
            <asp:Button ID="btnModel" runat="server" Text="Model" Visible="False" 
                Width="150px" />
            <asp:Button ID="btnCap" runat="server" Text="Capacity" Visible="False" 
                Width="150px" />
            <asp:Button ID="btnVariant" runat="server" Text="Variant" Visible="False" 
                Width="150px" />
            <asp:Button ID="btnAction" runat="server" Text="Action Taken" Visible="False" 
                Width="150px" />
            <asp:Button ID="btnDealer" runat="server" Text="Dealer" Visible="False" 
                Width="150px" />
            <asp:Button ID="btnStore" runat="server" Text="Store" Visible="False" 
                Width="150px" />
            <asp:Button ID="btnCity" runat="server" Text="City" Width="150px" />
            <asp:Button ID="btnProv" runat="server" Text="Province" Width="150px" />
            <asp:Button ID="btnRegion" runat="server" Text="Region" Width="150px" />
            
            <asp:Button ID="btnQuestion" runat="server" Text="Security Question" 
                Width="150px" />
            <asp:Button ID="btnCBrand" runat="server" Text="Competitors' Brand" 
                Visible="False" Width="150px" />
            <asp:Button ID="btnCCap" runat="server" Text="Capacity" Visible="False" 
                Width="150px" />
            <asp:Button ID="btnSubject" runat="server" Text="Subject" Visible="False" 
                Width="150px" />
            <asp:Button ID="btnTarget" runat="server" Text="Target Setup" Visible="False" 
                Width="150px" />
            
        </td>
    </tr>

<tr>
<td>

<!-- PRODUCT -->
<asp:Panel id="panProd" runat="server" Visible="False" Width="100%">
<TABLE align="left"><TBODY>
<tr>
<td cols></td>
    <td cols="">
        &nbsp;</td>
    <td>
    </td>
</tr>
<TR>
<TD width="120px" align="right">Product:</TD>
    <td width="50px">
        &nbsp;</td>
<TD align="left">
    <asp:TextBox id="txtProd" runat="server" Width="300px"></asp:TextBox>
    <asp:ImageButton id="imbAProd" runat="server" 
        ImageUrl="~/images/icons/save.png" AlternateText="Save" ToolTip="Save"></asp:ImageButton> 
    &nbsp;<asp:ImageButton id="imbMProd"  runat="server" ToolTip="Edit" 
        ImageUrl="~/images/icons/modify.png" AlternateText="Edit"></asp:ImageButton>
</td>
</TR>
<tr>
<td></td>
    <td>
        &nbsp;</td>
<td>
    <asp:ListBox id="lstProd" runat="server" Height="300px" width="350px"></asp:ListBox> 
</td>
</tr>
</TBODY></TABLE>
</asp:Panel> 


<!-- BRAND -->
<asp:Panel id="panBrand" runat="server" Visible="false" Width="100%">
<TABLE align="left"><TBODY>
<tr>
<td cols></td>
    <td cols="">
        &nbsp;</td>
    <td>
    </td>
</tr>
<TR>
<TD width="120px" align="right">Product:</TD>
    <td width="50px">
        &nbsp;</td>
<TD align="left">
    <asp:DropDownList ID="ddlBProd" runat="server" Width="350px">
    </asp:DropDownList>
</td>
</TR>
<tr>
<td align="right">Brand:</td>
    <td width="50px">
        &nbsp;</td>
<td align="left">
    <asp:TextBox ID="txtBrand" runat="server" Width="300px"></asp:TextBox>
    <asp:ImageButton ID="imbABrand" runat="server" AlternateText="Save" Tooltip="Save"
        ImageUrl="~/images/icons/save.png" />
    &nbsp;<asp:ImageButton ID="imbMBrand" runat="server" AlternateText="Edit" 
        ImageUrl="~/images/icons/modify.png" ToolTip="Edit" />
</td>
</tr>
    <tr>
        <td>
        </td>
        <td>
            &nbsp;</td>
        <td align="left">
            <asp:GridView ID="grdBrand" runat="server" AutoGenerateColumns="False" 
                CssClass="gridRow" DataKeyNames="brandID" DataSourceID="sqlDS_Brand" 
                PageSize="30" ShowFooter="True" ToolTip="Edit">
                <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
                <RowStyle CssClass="RowStyle" />
                <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
                <Columns>
                    <asp:CommandField ButtonType="Image" 
                        SelectImageUrl="~/images/icons/modify.png" ShowSelectButton="True" 
                        SelectText="Edit">
                    </asp:CommandField>
                    <asp:BoundField DataField="brandID" Visible="False"></asp:BoundField>
                    <asp:BoundField DataField="product" HeaderText="Product"></asp:BoundField>
                    <asp:BoundField DataField="brand" HeaderText="Brand"></asp:BoundField>
                    <asp:BoundField DataField="brandID" InsertVisible="False" ReadOnly="True">
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <FooterStyle CssClass="hiddencol" />
                        <HeaderStyle CssClass="hiddencol" />
                        <ItemStyle CssClass="hiddencol" />
                    </asp:BoundField>
                </Columns>
                <FooterStyle CssClass="FooterStyle" />
                <PagerTemplate>
                    <table>
                        <tbody>
                            <tr valign="middle">
                                <td>
                                    <asp:ImageButton ID="imbCFirst" runat="server" AlternateText="First Page" 
                                        CommandArgument="First" CommandName="Page" 
                                        ImageUrl="~/images/icons/first.png" />
                                    <asp:ImageButton ID="imbCPrev" runat="server" AlternateText="Previous Page" 
                                        CommandArgument="Prev" CommandName="Page" ImageUrl="~/images/icons/prev.png" />
                                </td>
                                <td>
                                    Page&nbsp;
                                    <asp:DropDownList ID="ddlCPageNo" runat="server" AutoPostBack="true" 
                                        Width="50px">
                                    </asp:DropDownList>
                                    &nbsp;of&nbsp;
                                    <asp:Label ID="lblCPageCount" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:ImageButton ID="imbCNext" runat="server" AlternateText="Next Page" 
                                        CommandArgument="Next" CommandName="Page" ImageUrl="~/images/icons/next.gif" />
                                    <asp:ImageButton ID="imbCLast" runat="server" AlternateText="Last Page" 
                                        CommandArgument="Last" CommandName="Page" ImageUrl="~/images/icons/last.gif" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </PagerTemplate>
                <PagerStyle CssClass="PagerRowStyle" />
                <HeaderStyle CssClass="HeaderStyle" />
                <EditRowStyle CssClass="EditRowStyle" />
                <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                <SelectedRowStyle Font-Bold="True" />
            </asp:GridView>
        </td>
    </tr>
</TBODY></TABLE>
</asp:Panel> 


<!-- MODEL -->
<asp:Panel id="panModel" runat="server" Visible="false" Width="100%">
<TABLE align="left"><TBODY>
<tr>
<td cols></td>
    <td cols="">
        &nbsp;</td>
    <td>
    </td>
</tr>
<TR>
<TD valign="top" align="right" width="120px">Product:</TD>
    <td width="50px">
        &nbsp;</td>
<TD align="left">
    <asp:DropDownList ID="ddlMProd" runat="server" Width="350px">
    </asp:DropDownList>
</td>
</TR>
<tr>
<td width="120px" align="right">Brand:</td>
    <td width="50px">
        &nbsp;</td>
<td align="left">
    <asp:DropDownList ID="ddlMBrand" runat="server" Width="350px">
    </asp:DropDownList>
</td>
</tr>
    <tr>
        <td align="right" width="120px">
            Model:</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:TextBox ID="txtModel" runat="server" Width="345px"></asp:TextBox>
            &nbsp;</td>
    </tr>
    <tr>
        <td align="left">
            &nbsp;</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:Button ID="btnMCreate" runat="server" Text="Save" />
            <asp:Button ID="btnMCancel" runat="server" Text="Reset" />
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            &nbsp;</td>
        <td align="left">
            <asp:GridView ID="grdModel" runat="server" AutoGenerateColumns="False" 
                CssClass="gridRow" DataKeyNames="modelID" DataSourceID="sqlDS_Model" 
                PageSize="30" ShowFooter="True" ToolTip="Edit">
                <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
                <RowStyle CssClass="RowStyle" />
                <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
                <Columns>
                    <asp:CommandField ButtonType="Image" 
                        SelectImageUrl="~/images/icons/modify.png" ShowSelectButton="True" 
                        SelectText="Edit">
                    </asp:CommandField>
                    <asp:BoundField DataField="modelID" Visible="False"></asp:BoundField>
                    <asp:BoundField DataField="product" HeaderText="Product"></asp:BoundField>
                    <asp:BoundField DataField="brand" HeaderText="Brand"></asp:BoundField>
                    <asp:BoundField DataField="model" HeaderText="Model">
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                    </asp:BoundField>
                    <asp:BoundField DataField="modelID" InsertVisible="False" ReadOnly="True">
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <FooterStyle CssClass="hiddencol" />
                        <HeaderStyle CssClass="hiddencol" />
                        <ItemStyle CssClass="hiddencol" />
                    </asp:BoundField>
                </Columns>
                <FooterStyle CssClass="FooterStyle" />
                <PagerTemplate>
                    <table>
                        <tbody>
                            <tr valign="middle">
                                <td>
                                    <asp:ImageButton ID="imbCFirst1" runat="server" AlternateText="First Page" 
                                        CommandArgument="First" CommandName="Page" 
                                        ImageUrl="~/images/icons/first.png" />
                                    <asp:ImageButton ID="imbCPrev1" runat="server" AlternateText="Previous Page" 
                                        CommandArgument="Prev" CommandName="Page" ImageUrl="~/images/icons/prev.png" />
                                </td>
                                <td>
                                    Page&nbsp;
                                    <asp:DropDownList ID="ddlCPageNo1" runat="server" AutoPostBack="true" 
                                        Width="50px">
                                    </asp:DropDownList>
                                    &nbsp;of&nbsp;
                                    <asp:Label ID="lblCPageCount1" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:ImageButton ID="imbCNext1" runat="server" AlternateText="Next Page" 
                                        CommandArgument="Next" CommandName="Page" ImageUrl="~/images/icons/next.gif" />
                                    <asp:ImageButton ID="imbCLast1" runat="server" AlternateText="Last Page" 
                                        CommandArgument="Last" CommandName="Page" ImageUrl="~/images/icons/last.gif" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </PagerTemplate>
                <PagerStyle CssClass="PagerRowStyle" />
                <HeaderStyle CssClass="HeaderStyle" />
                <EditRowStyle CssClass="EditRowStyle" />
                <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                <SelectedRowStyle Font-Bold="True" />
            </asp:GridView>
        </td>
    </tr>
</TBODY></TABLE>
</asp:Panel> 


<!-- ITEM CODE -->
<asp:Panel id="panItem" runat="server" Visible="false" Width="100%">
<TABLE align="left"><TBODY>
<tr>
<td cols></td>
    <td cols="">
        &nbsp;</td>
    <td>
    </td>
</tr>
<TR>
<TD class="style2" align="right" width="120px">Product:</TD>
    <td width="50px" class="style2">
        </td>
<TD align="left" class="style2">
    <asp:DropDownList ID="ddliProd" runat="server" AutoPostBack="True" 
        Width="350px">
    </asp:DropDownList>
    </td>
</TR>
<tr>
<td width="120px" align="right">Brand:</td>
    <td width="50px">
        &nbsp;</td>
<td align="left">
    <asp:DropDownList ID="ddliBrand" runat="server" AutoPostBack="True" 
        Width="350px">
    </asp:DropDownList>
</td>
</tr>
    <tr>
        <td class="style2" width="120px" align="right">
            Short Code:</td>
        <td class="style2" width="50px">
            &nbsp;</td>
        <td align="left" class="style2">
            <asp:TextBox ID="txtItem" runat="server" AutoPostBack="True" Width="345px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style2" width="120px" align="right">
            LongCode:</td>
        <td class="style2" width="50px">
        </td>
        <td align="left" class="style2">
            <asp:TextBox ID="txtLCode" runat="server" AutoPostBack="True" Width="345px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style2" width="120px" align="right" valign="top">
            Item Description:</td>
        <td class="style2" width="50px">
            &nbsp;</td>
        <td align="left" class="style2">
            <asp:TextBox ID="txtDesc" runat="server" AutoPostBack="True" 
                TextMode="MultiLine" Width="345px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td width="120px" align="right">
            Model:</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:DropDownList ID="ddliModel" runat="server" AutoPostBack="True" 
                Width="350px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td width="120px" align="right">
            Variant:</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:DropDownList ID="ddliVariant" runat="server" AutoPostBack="True" 
                Width="350px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td width="120px" align="right">
            Capacity:</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:DropDownList ID="ddliCap" runat="server" AutoPostBack="True" Width="350px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td width="120px">
            &nbsp;</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:Button ID="btnICreate" runat="server" Text="Save" />
            <asp:Button ID="btnICancel" runat="server" Text="Reset" />
        </td>
    </tr>
    <tr>
        <td width="120px">
            &nbsp;</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:GridView ID="grdItem" runat="server" AutoGenerateColumns="False" 
                CssClass="gridRow" DataKeyNames="itemID" DataSourceID="sqlDS_Item" 
                ShowFooter="True" AllowPaging="True" Width="95%" ToolTip="Edit">
                <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
                <RowStyle CssClass="RowStyle" />
                <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
                <Columns>
                    <asp:CommandField ButtonType="Image" 
                        SelectImageUrl="~/images/icons/modify.png" SelectText="Edit" ShowSelectButton="True">
                    </asp:CommandField>
                    <asp:BoundField DataField="itemID" Visible="False"></asp:BoundField>
                    <asp:BoundField DataField="product" HeaderText="Product"></asp:BoundField>
                    <asp:BoundField DataField="brand" HeaderText="Brand"></asp:BoundField>
                    <asp:BoundField DataField="shortCode" HeaderText="Short Code"></asp:BoundField>
                    <asp:BoundField DataField="longCode" HeaderText="Long Code"></asp:BoundField>
                    <asp:BoundField DataField="itemDesc" HeaderText="Item Description">
                    </asp:BoundField>
                    <asp:BoundField DataField="model" HeaderText="Model"></asp:BoundField>
                    <asp:BoundField DataField="variant" HeaderText="Variant"></asp:BoundField>
                    <asp:BoundField DataField="capacity" HeaderText="Capacity"></asp:BoundField>
                    <asp:BoundField DataField="itemID" InsertVisible="False" ReadOnly="True">
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <FooterStyle CssClass="hiddencol" />
                        <HeaderStyle CssClass="hiddencol" />
                        <ItemStyle CssClass="hiddencol" />
                    </asp:BoundField>
                </Columns>
                <FooterStyle CssClass="FooterStyle" />
                <PagerTemplate>
                    <table>
                        <tbody>
                            <tr valign="middle">
                                <td>
                                    <asp:ImageButton ID="imbiFirst" runat="server" AlternateText="First Page" 
                                        CommandArgument="First" CommandName="Page" 
                                        ImageUrl="~/images/icons/first.png" />
                                    <asp:ImageButton ID="imbiPrev" runat="server" AlternateText="Previous Page" 
                                        CommandArgument="Prev" CommandName="Page" ImageUrl="~/images/icons/prev.png" />
                                </td>
                                <td>
                                    Page&nbsp;
                                    <asp:DropDownList ID="ddliPageNo" runat="server" AutoPostBack="true" 
                                        Width="50px" onselectedindexchanged="ddliPageNo_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    &nbsp;of&nbsp;
                                    <asp:Label ID="lbliPageCount" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:ImageButton ID="imbiNext" runat="server" AlternateText="Next Page" 
                                        CommandArgument="Next" CommandName="Page" ImageUrl="~/images/icons/next.gif" />
                                    <asp:ImageButton ID="imbiLast" runat="server" AlternateText="Last Page" 
                                        CommandArgument="Last" CommandName="Page" ImageUrl="~/images/icons/last.gif" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </PagerTemplate>
                <PagerStyle CssClass="PagerRowStyle" />
                <HeaderStyle CssClass="HeaderStyle" />
                <EditRowStyle CssClass="EditRowStyle" />
                <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                <SelectedRowStyle Font-Bold="True" />
            </asp:GridView>
        </td>
    </tr>
</TBODY></TABLE>
</asp:Panel> 


<!-- CAPACITY -->
<asp:Panel id="panCap" runat="server" Visible="false" Width="100%">
<TABLE align="left"><TBODY>
<tr>
<td cols></td>
    <td cols="">
        &nbsp;</td>
    <td>
    </td>
</tr>
<TR>
<TD align="right" width="120px">Product:</TD>
    <td width="50px">
        &nbsp;</td>
<TD align="left">
    <asp:DropDownList ID="ddlCProd" runat="server" Width="350px" 
        AutoPostBack="True">
    </asp:DropDownList>
</td>
</TR>
<tr>
<td width="120px" align="right">Brand:</td>
    <td width="50px">
        &nbsp;</td>
<td align="left">
    <asp:DropDownList ID="ddlCBrand" runat="server" AutoPostBack="True" 
        Width="350px">
    </asp:DropDownList>
</td>
</tr>
    <tr>
        <td align="right" width="120px">
            Capacity:</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:TextBox ID="txtCap" runat="server" Width="345px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td width="75px">
            &nbsp;</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:Button ID="btnCapCreate" runat="server" Text="Save" />
            <asp:Button ID="btnCapCancel" runat="server" Text="Reset" />
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            &nbsp;</td>
        <td align="left">
            <asp:GridView ID="grdCap" runat="server" AutoGenerateColumns="False" 
                CssClass="gridRow" DataKeyNames="capacityID" DataSourceID="sqlDS_Cap" 
                ShowFooter="True" Width="95%" AllowPaging="True" ToolTip="Edit">
                <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
                <RowStyle CssClass="RowStyle" />
                <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
                <Columns>
                    <asp:CommandField ButtonType="Image" 
                        SelectImageUrl="~/images/icons/modify.png" SelectText="Edit" ShowSelectButton="True">
                    </asp:CommandField>
                    <asp:BoundField DataField="capacityID" Visible="False"></asp:BoundField>
                    <asp:BoundField DataField="product" HeaderText="Product"></asp:BoundField>
                    <asp:BoundField DataField="brand" HeaderText="Brand"></asp:BoundField>
                    <asp:BoundField DataField="capacity" HeaderText="Capacity">
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                    </asp:BoundField>
                    <asp:BoundField DataField="capacityID" InsertVisible="False" ReadOnly="True">
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <FooterStyle CssClass="hiddencol" />
                        <HeaderStyle CssClass="hiddencol" />
                        <ItemStyle CssClass="hiddencol" />
                    </asp:BoundField>
                </Columns>
                <FooterStyle CssClass="FooterStyle" />
                <PagerTemplate>
                    <table align="center">
                        <tbody>
                            <tr valign="middle">
                                <td>
                                    <asp:ImageButton ID="imbCaFirst" runat="server" AlternateText="First Page" 
                                        CommandArgument="First" CommandName="Page" 
                                        ImageUrl="~/images/icons/first.png" />
                                    <asp:ImageButton ID="imbCaPrev" runat="server" AlternateText="Previous Page" 
                                        CommandArgument="Prev" CommandName="Page" ImageUrl="~/images/icons/prev.png" />
                                </td>
                                <td>
                                    Page&nbsp;
                                    <asp:DropDownList ID="ddlCaPageNo" runat="server" AutoPostBack="true" 
                                        Width="50px" onselectedindexchanged="ddlCaPageNo_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    &nbsp;of&nbsp;
                                    <asp:Label ID="lblCaPageCount" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:ImageButton ID="imbCaNext" runat="server" AlternateText="Next Page" 
                                        CommandArgument="Next" CommandName="Page" ImageUrl="~/images/icons/next.gif" />
                                    <asp:ImageButton ID="imbCaLast" runat="server" AlternateText="Last Page" 
                                        CommandArgument="Last" CommandName="Page" ImageUrl="~/images/icons/last.gif" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </PagerTemplate>
                <PagerStyle CssClass="PagerRowStyle" />
                <HeaderStyle CssClass="HeaderStyle" />
                <EditRowStyle CssClass="EditRowStyle" />
                <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                <SelectedRowStyle Font-Bold="True" />
            </asp:GridView>
        </td>
    </tr>
</TBODY></TABLE>
</asp:Panel> 


<!-- VARIANT -->
<asp:Panel id="panVariant" runat="server" Visible="false" Width="100%">
<TABLE align="left"><TBODY>
<tr>
<td cols></td>
    <td cols="">
        &nbsp;</td>
    <td>
    </td>
</tr>
<tr>
<td width="120px" align="right">Variant:</td>
    <td width="50px">
        &nbsp;</td>
<td align="left">
    <asp:TextBox ID="txtVariant" runat="server" Width="300px"></asp:TextBox>
    <asp:ImageButton ID="imbAVariant" runat="server" AlternateText="Save" ToolTip="Save" 
        ImageUrl="~/images/icons/save.png" />
    &nbsp;<asp:ImageButton ID="imbMVariant" runat="server" AlternateText="Edit" 
        ImageUrl="~/images/icons/modify.png" ToolTip="Edit" />
</td>
</tr>
    <tr>
        <td>
        </td>
        <td>
            &nbsp;</td>
        <td>
            <asp:ListBox ID="lstVariant" runat="server" Height="300px" width="350px">
            </asp:ListBox>
        </td>
    </tr>
</TBODY></TABLE>
</asp:Panel> 




<!-- DEALER -->
<asp:Panel id="panDealer" runat="server" Visible="false" Width="100%">
<TABLE align="left"><TBODY>
<tr>
<td cols></td>
    <td cols="">
        &nbsp;</td>
    <td>
    </td>
</tr>
<TR>
<TD width="120px" align="right">Dealer:</TD>
    <td width="50px">
        &nbsp;</td>
<TD align="left">
    <asp:TextBox id="txtDealer" runat="server" Width="300px"></asp:TextBox>
    <asp:ImageButton id="imbADealer" runat="server" ToolTip="Save" 
        ImageUrl="~/images/icons/save.png" AlternateText="Save"></asp:ImageButton> 
    &nbsp;<asp:ImageButton id="imbMDealer"  runat="server" ToolTip="Edit" 
        ImageUrl="~/images/icons/modify.png" AlternateText="Edit"></asp:ImageButton>
</td>
</TR>
<tr>
<td></td>
    <td>
        &nbsp;</td>
<td>
    <asp:ListBox id="lstDealer" runat="server" Height="300px" width="350px"></asp:ListBox> 
</td>
</tr>
</TBODY></TABLE>
</asp:Panel> 


<!-- STORE LOCATION -->
<asp:Panel id="panLoc" runat="server" Visible="false" Width="100%">
<TABLE align="left"><TBODY>
<tr>
<td cols></td>
    <td cols="">
        &nbsp;</td>
    <td>
    </td>
</tr>
<TR>
<TD width="120px" align="right">Location:</TD>
    <td width="50px">
        &nbsp;</td>
<TD align="left">
    <asp:TextBox id="txtLoc" runat="server" Width="300px"></asp:TextBox>
    <asp:ImageButton id="imbALoc"  runat="server" ToolTip="Save" 
        ImageUrl="~/images/icons/save.png" AlternateText="Save"></asp:ImageButton> 
    &nbsp;<asp:ImageButton id="imbMLoc"  runat="server" ToolTip="Edit" 
        ImageUrl="~/images/icons/modify.png" AlternateText="Edit"></asp:ImageButton>
</td>
</TR>
<tr>
<td></td>
    <td>
        &nbsp;</td>
<td>
    <asp:ListBox id="lstLoc" runat="server" Height="300px" width="350px"></asp:ListBox> 
</td>
</tr>
</TBODY></TABLE>
</asp:Panel> 


<!-- STORE -->
<asp:Panel id="panStore" runat="server" Visible="false" Width="100%">
<TABLE align="left"><TBODY>
<tr>
<td cols></td>
    <td cols="">
        &nbsp;</td>
    <td>
    </td>
</tr>
<TR>
<TD width="120px" align="right">Store Code:</TD>
    <td width="50px">
        &nbsp;</td>
<TD align="left">
    <asp:TextBox id="txtSC" runat="server" Width="345px"></asp:TextBox>
</td>
</TR>
    <tr>
        <td align="right" width="120px">
            Dealer:</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:DropDownList ID="ddlSCDealer" runat="server" Width="350px" 
                AutoPostBack="True">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right" width="120px">
            Location:</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:DropDownList ID="ddlSCLoc" runat="server" Width="350px" 
                AutoPostBack="True">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right" width="120px">
            Region:</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:DropDownList ID="ddlSCRegion" runat="server" AutoPostBack="True" 
                Width="350px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right" width="120px">
            Parent BP:</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:TextBox ID="txtParent" runat="server" Width="345px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" width="120px">
            Child BP 1:</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:TextBox ID="txtChild1" runat="server" Width="345px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" width="120px">
            Child BP 2:</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:TextBox ID="txtChild2" runat="server" Width="345px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" width="120px">
            Child BP 3:</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:TextBox ID="txtChild3" runat="server" Width="345px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="left" width="75px">
            &nbsp;</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:Button ID="btnSCCreate" runat="server" Text="Save" />
            <asp:Button ID="btnSCCancel" runat="server" Text="Reset" />
        </td>
    </tr>
<tr>
<td></td>
    <td>
        &nbsp;</td>
<td>
    <asp:GridView ID="grdStore" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" CssClass="gridRow" DataKeyNames="storeID" 
        DataSourceID="sqlDS_Store" ShowFooter="True" Width="95%" ToolTip="Edit">
        <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
        <RowStyle CssClass="RowStyle" />
        <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
        <Columns>
            <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/icons/modify.png" SelectText="Edit"
                ShowSelectButton="True"></asp:CommandField>
            <asp:BoundField DataField="storeID" Visible="False"></asp:BoundField>
            <asp:BoundField DataField="storeCode" HeaderText="Store Code"></asp:BoundField>
            <asp:BoundField DataField="dealer" HeaderText="Dealer"></asp:BoundField>
            <asp:BoundField DataField="location" HeaderText="Location" 
                SortExpression="region"></asp:BoundField>
            <asp:BoundField DataField="region" HeaderText="Region"></asp:BoundField>
            <asp:BoundField DataField="parentBP" HeaderText="Parent BP"></asp:BoundField>
            <asp:BoundField DataField="childBP1" HeaderText="Child BP 1"></asp:BoundField>
            <asp:BoundField DataField="childBP2" HeaderText="Child BP 2"></asp:BoundField>
            <asp:BoundField DataField="childBP3" HeaderText="Child BP 3"></asp:BoundField>
        </Columns>
        <FooterStyle CssClass="FooterStyle" />
        <PagerTemplate>
            <table align="CENTER">
                <tbody>
                    <tr align="center" valign="middle">
                        <td>
                            <asp:ImageButton ID="imbStFirst" runat="server" AlternateText="First Page" 
                                CommandArgument="First" CommandName="Page" 
                                ImageUrl="~/images/icons/first.png" />
                            <asp:ImageButton ID="imbStPrev" runat="server" AlternateText="Previous Page" 
                                CommandArgument="Prev" CommandName="Page" ImageUrl="~/images/icons/prev.png" />
                        </td>
                        <td>
                            Page&nbsp;
                            <asp:DropDownList ID="ddlStPageNo" runat="server" AutoPostBack="true" 
                                Width="50px" onselectedindexchanged="ddlStPageNo_SelectedIndexChanged">
                            </asp:DropDownList>
                            &nbsp;of&nbsp;
                            <asp:Label ID="lblStPageCount" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:ImageButton ID="imbStNext" runat="server" AlternateText="Next Page" 
                                CommandArgument="Next" CommandName="Page" ImageUrl="~/images/icons/next.gif" />
                            <asp:ImageButton ID="imbStLast" runat="server" AlternateText="Last Page" 
                                CommandArgument="Last" CommandName="Page" ImageUrl="~/images/icons/last.gif" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </PagerTemplate>
        <PagerStyle CssClass="PagerRowStyle" />
        <HeaderStyle CssClass="HeaderStyle" />
        <EditRowStyle CssClass="EditRowStyle" />
        <AlternatingRowStyle CssClass="AlternatingRowStyle" />
        <SelectedRowStyle Font-Bold="True" />
    </asp:GridView>
</td>
</tr>
</TBODY></TABLE>
</asp:Panel> 


<!-- CITY -->
<asp:Panel id="panCity" runat="server" Width="100%">
<TABLE align="left"><TBODY>
<tr>
<td cols></td>
    <td cols="">
        &nbsp;</td>
    <td>
    </td>
</tr>
<TR>
<TD width="120px" align="right">Region:</TD>
    <td width="50px">
        &nbsp;</td>
<TD align="left">
    <asp:DropDownList ID="ddlCRegion" runat="server" AutoPostBack="True" 
        Width="350px">
    </asp:DropDownList>
</td>
</TR>
    <tr>
        <td align="right" width="120px">
            Province:</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:DropDownList ID="ddlCProv" runat="server" AutoPostBack="True" 
                Width="350px">
            </asp:DropDownList>
        </td>
    </tr>
<tr>
<td width="120px" align="right">City:</td>
    <td width="50px">
        &nbsp;</td>
<td align="left">
    <asp:TextBox ID="txtCity" runat="server" Width="345px"></asp:TextBox>
    &nbsp;</td>
</tr>
    <tr>
        <td width="75px">
            &nbsp;</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:Button ID="btnCCreate" runat="server" Text="Save" />
            <asp:Button ID="btnCCancel" runat="server" Text="Reset" />
        </td>
    </tr>
<tr>
<td></td>
    <td>
        &nbsp;</td>
<td align="left">
    <asp:GridView ID="grdCity" runat="server" AutoGenerateColumns="False" 
        CssClass="gridRow" DataSourceID="sqlDS_City" ToolTip="Edit"
        ShowFooter="True" AllowPaging="True" DataKeyNames="cityID" Width="95%">
        <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
        <RowStyle CssClass="RowStyle" />
        <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
        <Columns>
            <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/icons/modify.png" SelectText="Edit"
                ShowSelectButton="True" ShowHeader="true" HeaderText="Edit"></asp:CommandField>
            <asp:BoundField DataField="cityID" Visible="False"></asp:BoundField>
            <asp:BoundField DataField="city" HeaderText="City"></asp:BoundField>
            <asp:BoundField DataField="province" HeaderText="Province" 
                SortExpression="province"></asp:BoundField>
            <asp:BoundField DataField="region" HeaderText="Region" SortExpression="region">
            </asp:BoundField>
        </Columns>
        <FooterStyle CssClass="FooterStyle" />
        <PagerTemplate>
            <table align="center">
                <tbody>
                    <tr valign="middle" align="center">
                        <td>
                            <asp:ImageButton ID="imbCFirst" runat="server" AlternateText="First Page" 
                                CommandArgument="First" CommandName="Page" 
                                ImageUrl="~/images/icons/first.png" />
                            <asp:ImageButton ID="imbCPrev" runat="server" AlternateText="Previous Page" 
                                CommandArgument="Prev" CommandName="Page" ImageUrl="~/images/icons/prev.png" />
                        </td>
                        <td>
                            Page&nbsp;
                            <asp:DropDownList ID="ddlCPageNo" runat="server" AutoPostBack="true" 
                                Width="50px" onselectedindexchanged="ddlCPageNo_SelectedIndexChanged">
                            </asp:DropDownList>
                            &nbsp;of&nbsp;
                            <asp:Label ID="lblCPageCount" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:ImageButton ID="imbCNext" runat="server" AlternateText="Next Page" 
                                CommandArgument="Next" CommandName="Page" ImageUrl="~/images/icons/next.gif" />
                            <asp:ImageButton ID="imbCLast" runat="server" AlternateText="Last Page" 
                                CommandArgument="Last" CommandName="Page" ImageUrl="~/images/icons/last.gif" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </PagerTemplate>
        <PagerStyle CssClass="PagerRowStyle" />
        <HeaderStyle CssClass="HeaderStyle" />
        <EditRowStyle CssClass="EditRowStyle" />
        <AlternatingRowStyle CssClass="AlternatingRowStyle" />
        <SelectedRowStyle Font-Bold="True" />
    </asp:GridView>
</td>
</tr>
</TBODY></TABLE>
</asp:Panel> 


<!-- PROVINCE -->
<asp:Panel id="panProv" runat="server" Width="100%">
<TABLE align="left"><TBODY>
<tr>
<td cols></td>
    <td cols="">
        &nbsp;</td>
    <td>
    </td>
</tr>
<TR>
<TD width="120px" align="right">Region:</TD>
    <td width="50px">
        &nbsp;</td>
<TD align="left">
    <asp:DropDownList ID="ddlPRegion" runat="server" AutoPostBack="True" 
        Width="350px">
    </asp:DropDownList>
</td>
</TR>
    
<tr>
<td width="120px" align="right">Province:</td>
    <td width="50px">
        &nbsp;</td>
<td align="left">
    <asp:TextBox ID="txtProvince" runat="server" Width="345px"></asp:TextBox>
    &nbsp;</td>
</tr>
    <tr>
        <td width="75px">
            &nbsp;</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:Button ID="btnPCreate" runat="server" Text="Save" />
            <asp:Button ID="btnPCancel" runat="server" Text="Reset" />
        </td>
    </tr>
<tr>
<td></td>
    <td>
        &nbsp;</td>
<td align="left">
    <asp:GridView ID="grdProv" runat="server" AutoGenerateColumns="False" 
        CssClass="gridRow" DataSourceID="sqlDS_Prov" ToolTip="Edit" 
        ShowFooter="True" AllowPaging="True" DataKeyNames="provinceID" Width="95%">
        <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
        <RowStyle CssClass="RowStyle" />
        <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
        <Columns>
            <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/icons/modify.png" SelectText="Edit"
                ShowSelectButton="True" ShowHeader="true" HeaderText="Edit"></asp:CommandField>
            <asp:BoundField DataField="provinceID" Visible="False"></asp:BoundField>
            <asp:BoundField DataField="province" HeaderText="Province" 
                SortExpression="province"></asp:BoundField>
            <asp:BoundField DataField="region" HeaderText="Region" SortExpression="region">
            </asp:BoundField>
        </Columns>
        <FooterStyle CssClass="FooterStyle" />
        <PagerTemplate>
            <table align="center">
                <tbody>
                    <tr valign="middle" align="center">
                        <td>
                            <asp:ImageButton ID="imbPFirst" runat="server" AlternateText="First Page" 
                                CommandArgument="First" CommandName="Page" 
                                ImageUrl="~/images/icons/first.png" />
                            <asp:ImageButton ID="imbPPrev" runat="server" AlternateText="Previous Page" 
                                CommandArgument="Prev" CommandName="Page" 
                                ImageUrl="~/images/icons/prev.png" />
                        </td>
                        <td>
                            Page&nbsp;
                            <asp:DropDownList ID="ddlPPageNo" runat="server" AutoPostBack="true" 
                                Width="50px" onselectedindexchanged="ddlPPageNo_SelectedIndexChanged">
                            </asp:DropDownList>
                            &nbsp;of&nbsp;
                            <asp:Label ID="lblPPageCount" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:ImageButton ID="imbPNext" runat="server" AlternateText="Next Page" 
                                CommandArgument="Next" CommandName="Page" 
                                ImageUrl="~/images/icons/next.gif" />
                            <asp:ImageButton ID="imbPLast" runat="server" AlternateText="Last Page" 
                                CommandArgument="Last" CommandName="Page" 
                                ImageUrl="~/images/icons/last.gif" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </PagerTemplate>
        <PagerStyle CssClass="PagerRowStyle" />
        <HeaderStyle CssClass="HeaderStyle" />
        <EditRowStyle CssClass="EditRowStyle" />
        <AlternatingRowStyle CssClass="AlternatingRowStyle" />
        <SelectedRowStyle Font-Bold="True" />
    </asp:GridView>
</td>
</tr>
</TBODY></TABLE>
</asp:Panel> 



<!-- REGION -->
<asp:Panel id="panRegion" runat="server" Visible="false" Width="100%">
<TABLE align="left"><TBODY>
<tr>
<td cols></td>
    <td cols="">
        &nbsp;</td>
    <td>
    </td>
</tr>
<TR>
<TD width="120px" align="right">Region:</TD>
    <td width="50px">
        &nbsp;</td>
<TD align="left">
    <asp:TextBox id="txtRegion" runat="server" Width="300px"></asp:TextBox>
    <asp:ImageButton id="imbARegion"  runat="server" 
        ImageUrl="~/images/icons/save.png" AlternateText="Save" ToolTip="Save"></asp:ImageButton> 
    &nbsp;<asp:ImageButton id="imbMRegion"  runat="server" 
        ImageUrl="~/images/icons/modify.png" AlternateText="Edit" 
        ToolTip="Edit"></asp:ImageButton>
</td>
</TR>
<tr>
<td></td>
    <td>
        &nbsp;</td>
<td>
    <asp:ListBox id="lstRegion" runat="server" Height="300px" width="350px"></asp:ListBox> 
</td>
</tr>
</TBODY></TABLE>
</asp:Panel> 


<!-- Action Taken -->
<asp:Panel id="panAction" runat="server" Visible="false" Width="100%">
<TABLE align="left"><TBODY>
<tr>
<td cols></td>
    <td cols="">
        &nbsp;</td>
    <td>
    </td>
</tr>
<TR>
<TD width="120px" align="right">Action Taken:</TD>
    <td width="50px">
        &nbsp;</td>
<TD align="left">
    <asp:TextBox id="txtAction" runat="server" Width="300px"></asp:TextBox>
    <asp:ImageButton id="imbAAction"  runat="server" ToolTip="Save" 
        ImageUrl="~/images/icons/save.png" AlternateText="Save"></asp:ImageButton> 
    &nbsp;<asp:ImageButton id="imbMAction"  runat="server" ToolTip="Edit" 
        ImageUrl="~/images/icons/modify.png" AlternateText="Edit"></asp:ImageButton>
</td>
</TR>
<tr>
<td></td>
    <td>
        &nbsp;</td>
<td>
    <asp:ListBox id="lstAction" runat="server" Height="300px" width="350px"></asp:ListBox> 
</td>
</tr>
</TBODY></TABLE>
</asp:Panel> 


<!-- Security Question -->
<asp:Panel id="panQuestion" runat="server" Visible="false" Width="100%">
<TABLE align="left"><TBODY>
<tr>
<td cols></td>
    <td cols="">
        &nbsp;</td>
    <td>
    </td>
</tr>
<TR>
<TD width="120px" align="right">Security Question:</TD>
    <td width="50px">
        &nbsp;</td>
<TD align="left">
    <asp:TextBox id="txtQuestion" runat="server" Width="300px"></asp:TextBox>
    <asp:ImageButton id="imbAQuestion"  runat="server" ToolTip="Save" 
        ImageUrl="~/images/icons/save.png" AlternateText="Save"></asp:ImageButton> 
    &nbsp;<asp:ImageButton id="imbMQuestion"  runat="server" ToolTip="Edit" 
        ImageUrl="~/images/icons/modify.png" AlternateText="Edit"></asp:ImageButton>
</td>
</TR>
<tr>
<td></td>
    <td>
        &nbsp;</td>
<td>
    <asp:ListBox id="lstQuestion" runat="server" Height="300px" width="350px"></asp:ListBox> 
</td>
</tr>
</TBODY></TABLE>
</asp:Panel> 


<!-- CBrand -->
<asp:Panel id="panCBrand" runat="server" Visible="false" Width="100%">
<TABLE align="left"><TBODY>
<tr>
<td cols></td>
    <td cols="">
        &nbsp;</td>
    <td>
    </td>
</tr>
<TR>
<TD width="120px" align="right">Competitor&#39;s Brand:</TD>
    <td width="50px">
        &nbsp;</td>
<TD align="left">
    <asp:TextBox id="txtCBrand" runat="server" Width="300px"></asp:TextBox>
    <asp:ImageButton id="imbACBrand"  runat="server" ToolTip="Save" 
        ImageUrl="~/images/icons/save.png" AlternateText="Save"></asp:ImageButton> 
    &nbsp;<asp:ImageButton id="imbMCBrand"  runat="server" ToolTip="Edit" 
        ImageUrl="~/images/icons/modify.png" AlternateText="Edit"></asp:ImageButton>
</td>
</TR>
<tr>
<td></td>
    <td>
        &nbsp;</td>
<td>
    <asp:ListBox id="lstCBrand" runat="server" Height="300px" width="350px"></asp:ListBox> 
</td>
</tr>
</TBODY></TABLE>
</asp:Panel> 


<!-- CCap -->
<asp:Panel id="panCCap" runat="server" Visible="false" Width="100%">
<TABLE align="left"><TBODY>
<tr>
<td cols></td>
    <td cols="">
        &nbsp;</td>
    <td>
    </td>
</tr>
<TR>
<TD width="120px" align="right">Competitor&#39;s Brand Capacity:</TD>
    <td width="50px">
        &nbsp;</td>
<TD align="left">
    <asp:TextBox id="txtCCap" runat="server" Width="300px"></asp:TextBox>
    <asp:ImageButton id="imbACCap"  runat="server" ToolTip="Save" 
        ImageUrl="~/images/icons/save.png" AlternateText="Save"></asp:ImageButton> 
    &nbsp;<asp:ImageButton id="imbMCCap"  runat="server" ToolTip="Edit" 
        ImageUrl="~/images/icons/modify.png" AlternateText="Edit"></asp:ImageButton>
</td>
</TR>
<tr>
<td></td>
    <td>
        &nbsp;</td>
<td>
    <asp:ListBox id="lstCCap" runat="server" Height="300px" width="350px"></asp:ListBox> 
</td>
</tr>
</TBODY></TABLE>
</asp:Panel> 


<!-- Subject -->
<asp:Panel id="panSubject" runat="server" Visible="false" Width="100%">
<TABLE align="left"><TBODY>
<tr>
<td cols></td>
    <td cols="">
        &nbsp;</td>
    <td>
    </td>
</tr>
<TR>
<TD width="120px" align="right">Subject:</TD>
    <td width="50px">
        &nbsp;</td>
<TD align="left">
    <asp:TextBox id="txtSubject" runat="server" Width="300px"></asp:TextBox>
    <asp:ImageButton id="imbASubject"  runat="server" ToolTip="Save" 
        ImageUrl="~/images/icons/save.png" AlternateText="Save"></asp:ImageButton> 
    &nbsp;<asp:ImageButton id="imbMSubject"  runat="server" ToolTip="Edit" 
        ImageUrl="~/images/icons/modify.png" AlternateText="Edit"></asp:ImageButton>
</td>
</TR>
<tr>
<td></td>
    <td>
        &nbsp;</td>
<td>
    <asp:ListBox id="lstSubject" runat="server" Height="300px" width="350px"></asp:ListBox> 
</td>
</tr>
</TBODY></TABLE>
</asp:Panel> 


<!-- Target -->
<asp:Panel id="panTarget" runat="server" Visible="false" Width="100%">
<TABLE align="left"><TBODY>
<tr>
<td cols></td>
    <td cols="">
        &nbsp;</td>
    <td>
    </td>
</tr>
<TR>
<TD width="120px" align="right">Product:</TD>
    <td width="50px">
        &nbsp;</td>
<TD align="left">
    <asp:DropDownList ID="ddlTProd" runat="server" AutoPostBack="True" 
        Width="350px">
    </asp:DropDownList>
</td>
</TR>
    <tr>
        <td align="left" width="100">
            &nbsp;</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="right" width="120px">
            Week Coverage:</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:DropDownList ID="ddlTWeek" runat="server" AutoPostBack="True" 
                Width="350px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right" width="120px">
            Week Quota:</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:TextBox ID="txtWeek" runat="server" Width="345px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="left" width="75px">
            &nbsp;</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:Button ID="btnTWCreate" runat="server" Text="Save" />
            <asp:Button ID="btnTWCancel" runat="server" Text="Reset" />
        </td>
    </tr>
    <tr>
        <td align="left" width="75px">
            &nbsp;</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="right" width="120px">
            Month:</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" 
                Width="350px">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem Value="1">January</asp:ListItem>
                <asp:ListItem Value="2">February</asp:ListItem>
                <asp:ListItem Value="3">March</asp:ListItem>
                <asp:ListItem Value="4">April</asp:ListItem>
                <asp:ListItem Value="5">May</asp:ListItem>
                <asp:ListItem Value="6">June</asp:ListItem>
                <asp:ListItem Value="7">July</asp:ListItem>
                <asp:ListItem Value="8">August</asp:ListItem>
                <asp:ListItem Value="9">September</asp:ListItem>
                <asp:ListItem Value="10">October</asp:ListItem>
                <asp:ListItem Value="11">November</asp:ListItem>
                <asp:ListItem Value="12">December</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right" width="120px">
            Year:</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:DropDownList ID="ddlMYear" runat="server" AutoPostBack="True" 
                Width="350px">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>2013</asp:ListItem>
                <asp:ListItem>2014</asp:ListItem>
                <asp:ListItem>2015</asp:ListItem>
                <asp:ListItem>2016</asp:ListItem>
                <asp:ListItem>2017</asp:ListItem>
                <asp:ListItem>2018</asp:ListItem>
                <asp:ListItem Value="2019"></asp:ListItem>
                <asp:ListItem Value="2020"></asp:ListItem>
                <asp:ListItem Value="2021"></asp:ListItem>
                <asp:ListItem Value="2022"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right" width="120px">
            Month&#39;s Quota:</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:TextBox ID="txtMonth" runat="server" Width="345px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="left" width="75px">
            &nbsp;</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:Button ID="btnTMCreate" runat="server" Text="Save" />
            <asp:Button ID="btnTMCancel" runat="server" Text="Reset" />
        </td>
    </tr>
    <tr>
        <td align="left" width="75px">
            &nbsp;</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="right" width="120px">
            Year:</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" Width="350px">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>2013</asp:ListItem>
                <asp:ListItem>2014</asp:ListItem>
                <asp:ListItem>2015</asp:ListItem>
                <asp:ListItem>2016</asp:ListItem>
                <asp:ListItem>2017</asp:ListItem>
                <asp:ListItem>2018</asp:ListItem>
                <asp:ListItem Value="2019"></asp:ListItem>
                <asp:ListItem Value="2020"></asp:ListItem>
                <asp:ListItem Value="2021"></asp:ListItem>
                <asp:ListItem Value="2022"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right" width="120px">
            Year&#39;s Quota:</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:TextBox ID="txtYear" runat="server" Width="345px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="left" width="75px">
            &nbsp;</td>
        <td width="50px">
            &nbsp;</td>
        <td align="left">
            <asp:Button ID="btnTYCreate" runat="server" Text="Save" />
            <asp:Button ID="btnTYCancel" runat="server" Text="Reset" />
        </td>
    </tr>
<tr>
<td></td>
    <td>
        &nbsp;</td>
<td>
    <asp:GridView ID="grdTarget" runat="server" 
        AutoGenerateColumns="False" CssClass="gridRow" DataKeyNames="targetID" 
        DataSourceID="sqlDS_Target" ShowFooter="True" Width="95%" 
        AllowPaging="True" ToolTip="Edit">
        <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
        <RowStyle CssClass="RowStyle" />
        <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
        <Columns>
            <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/icons/modify.png" SelectText="Edit"
                ShowSelectButton="True"></asp:CommandField>
            <asp:BoundField DataField="targetID" Visible="False"></asp:BoundField>
            <asp:BoundField DataField="product" HeaderText="Product"></asp:BoundField>
            <asp:BoundField DataField="weekCoverage" HeaderText="Week Coverage">
            </asp:BoundField>
            <asp:BoundField DataField="TQWeek" HeaderText="Week Quota"></asp:BoundField>
            <asp:BoundField DataField="monthNo" HeaderText="Month"></asp:BoundField>
            <asp:BoundField DataField="TQMonth" HeaderText="Month Quota"></asp:BoundField>
            <asp:BoundField DataField="yr" HeaderText="Year"></asp:BoundField>
            <asp:BoundField DataField="TQYear" HeaderText="Year Quota"></asp:BoundField>
        </Columns>
        <FooterStyle CssClass="FooterStyle" />
        <PagerTemplate>
            <table align="CENTER">
                <tbody>
                    <tr align="center" valign="middle">
                        <td>
                            <asp:ImageButton ID="imbTFirst" runat="server" AlternateText="First Page" 
                                CommandArgument="First" CommandName="Page" 
                                ImageUrl="~/images/icons/first.png" />
                            <asp:ImageButton ID="imbTPrev" runat="server" AlternateText="Previous Page" 
                                CommandArgument="Prev" CommandName="Page" ImageUrl="~/images/icons/prev.png" />
                        </td>
                        <td>
                            Page&nbsp;
                            <asp:DropDownList ID="ddlTPageNo" runat="server" AutoPostBack="true" 
                                Width="50px" onselectedindexchanged="ddlTPageNo_SelectedIndexChanged">
                            </asp:DropDownList>
                            &nbsp;of&nbsp;
                            <asp:Label ID="lblTPageCount" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:ImageButton ID="imbTNext" runat="server" AlternateText="Next Page" 
                                CommandArgument="Next" CommandName="Page" ImageUrl="~/images/icons/next.gif" />
                            <asp:ImageButton ID="imbTLast" runat="server" AlternateText="Last Page" 
                                CommandArgument="Last" CommandName="Page" ImageUrl="~/images/icons/last.gif" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </PagerTemplate>
        <PagerStyle CssClass="PagerRowStyle" />
        <HeaderStyle CssClass="HeaderStyle" />
        <EditRowStyle CssClass="EditRowStyle" />
        <AlternatingRowStyle CssClass="AlternatingRowStyle" />
        <SelectedRowStyle Font-Bold="True" />
    </asp:GridView>
</td>
</tr>
</TBODY></TABLE>
</asp:Panel> 


<!-- POPULATE DAYS --->
<asp:Panel id="pnlPopDay" runat="server" Visible="false" Width="100%">
	<iframe src="PopulateDay.aspx" width="100%" height="600px"></iframe> 
</asp:Panel>

<!-- POPULATE WEEKS --->
<asp:Panel id="pnlPopWeek" runat="server" Visible="false" Width="100%">
	<iframe src="PopulateWeek.aspx" width="100%" height="600px"></iframe> 
</asp:Panel>

</td>
</tr>
</table>

<!-- END OF CONTENT PLACEMENT -->
</DIV><!-- end cont wrap -->
</asp:Panel>




<!-- ANNOUNCEMENTS -->
<asp:Panel ID="panAnnounce" runat="server">
<div></div>

<!-- panData -->
<div>
<asp:Panel ID="panAData" runat="server" Visible="False">
<table>
<tr>
<td align="center" colspan="2">
    <p><asp:Image ID="imgPic" runat="server" Visible="False" />
    <asp:ImageButton ID="imbPicRemove" runat="server" 
        ImageUrl="~/images/icons/delete.png" Visible="False" /></p>
    </td>
</tr>

    <tr>
        <td align="left">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="left" style="font-size: 15px; font-weight: bold">
            Title:</td>
        <td align="left">
            <asp:TextBox ID="txtTitle" runat="server" ReadOnly="True" Width="400px"></asp:TextBox>
        </td>
    </tr>

<tr>
<td align="left">Intro:</td>
<td align="left">
    <asp:TextBox ID="txtIntro" runat="server" ReadOnly="True" Width="400px"></asp:TextBox>
</td>
</tr>

<tr>
<td></td>
<td height="px">
    &nbsp;</td>
</tr>

<tr>
<td align="left" valign="top">Story:</td>
<td align="left">
    <asp:TextBox ID="txtStory" runat="server" ReadOnly="True" Rows="10" 
        TextMode="MultiLine" Width="400px"></asp:TextBox>
</td>
</tr>

<tr>
<td align="left">&nbsp;</td>
<td align="left" height="30px">
    <asp:RadioButtonList ID="rblPublish" runat="server" 
        RepeatDirection="Horizontal">
        <asp:ListItem Selected="True" Value="1">Publish</asp:ListItem>
        <asp:ListItem Value="2">Unpublish</asp:ListItem>
    </asp:RadioButtonList>
    </td>
</tr>

    <tr>
        <td align="left">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
    </tr>

    <tr>
        <td align="left">
            Date Created:</td>
        <td align="left">
            <asp:Label ID="lblCDate" runat="server" Text=""></asp:Label>
        </td>
    </tr>

<tr>
<td align="left">Created By:</td>
<td align="left">
    <asp:Label ID="lblCBy" runat="server" Text=""></asp:Label>
</td>
</tr>

<tr>
<td align="left" width="150px">
    <asp:Label ID="iMDate" runat="server" Text="Date Last Modified:"></asp:Label>
    </td>
<td align="left">
    <asp:Label ID="lblMDate" runat="server" Text=""></asp:Label>
</td>
</tr>

<tr>
<td align="left">
    <asp:Label ID="iMBy" runat="server" Text="Modified By:"></asp:Label>
    </td>
<td align="left">
    <asp:Label ID="lblMBy" runat="server" Text=""></asp:Label>
</td>
</tr>
    <tr>
        <td align="left">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <asp:Label ID="lbleMsg1" runat="server" ForeColor="Red"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="left">
            &nbsp;</td>
        <td align="right">
            <asp:Button ID="btnModify" runat="server" Text="Modify" />
            <asp:Button ID="btnACancel" runat="server" Text="Cancel" Visible="False" />
            <asp:Button ID="btnAddPic" runat="server" Text="Add Picture" Visible="False" />
        </td>
    </tr>
</table>
</asp:Panel>
</div>

<div>
<p><br /><asp:Button runat="server" Text="Create Announcement" ID="btnACreate"></asp:Button></p>
</div>

<!-- grdAnnounce1 -->
<div>
    <asp:GridView ID="grdAnnounce" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" BorderColor="Black" 
        CssClass="gridRow" DataKeyNames="announceID" DataSourceID="sqlDS_Announce" 
        ShowFooter="True" Width="95%" ToolTip="View">
        <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
        <RowStyle CssClass="RowStyle" />
        <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
        <Columns>
			<asp:CommandField ButtonType="Image" SelectImageUrl="~/images/icons/search.png" ShowSelectButton="True" ShowHeader="true" HeaderText="View"></asp:CommandField>
            <asp:BoundField DataField="announceID" HeaderText="announceID" Visible="False">
            </asp:BoundField>
            <asp:BoundField DataField="aTitle" HeaderText="Title"></asp:BoundField>
            <asp:BoundField DataField="intro" HeaderText="Introduction"></asp:BoundField>
            <asp:BoundField DataField="lastUpdate" HeaderText="Date"></asp:BoundField>
            <asp:BoundField DataField="aStatus" HeaderText="Status">
            </asp:BoundField>
            <asp:BoundField DataField="announceID" InsertVisible="False" ReadOnly="True">
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <FooterStyle CssClass="hiddencol" />
                <HeaderStyle CssClass="hiddencol" />
                <ItemStyle CssClass="hiddencol" />
            </asp:BoundField>
        </Columns>
        <EmptyDataTemplate>
            <div style="text-align:center; vertical-align:middle;">
                No Records Found!
            </div>
        </EmptyDataTemplate>
        <FooterStyle CssClass="FooterStyle" />
        <PagerTemplate>
            <table align="center">
                <tbody>
                    <tr valign="middle">
                        <td>
                            <asp:ImageButton ID="imbFirst" runat="server" AlternateText="First Page" 
                                CommandArgument="First" CommandName="Page" 
                                ImageUrl="~/images/icons/first.png" />
                            <asp:ImageButton ID="imbPrev" runat="server" AlternateText="Previous Page" 
                                CommandArgument="Prev" CommandName="Page" ImageUrl="~/images/icons/prev.png" />
                        </td>
                        <td>
                            Page&nbsp;&nbsp;<asp:DropDownList ID="ddlPageNo" runat="server" AutoPostBack="true" 
                                 Width="50px" onselectedindexchanged="ddlPageNo_OnSelectedIndexChanged">
                            </asp:DropDownList>
                            &nbsp;of&nbsp;
                            <asp:Label ID="lblPageCount" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:ImageButton ID="imbNext" runat="server" AlternateText="Next Page" 
                                CommandArgument="Next" CommandName="Page" ImageUrl="~/images/icons/next.gif" />
                            <asp:ImageButton ID="imbLast" runat="server" AlternateText="Last Page" 
                                CommandArgument="Last" CommandName="Page" ImageUrl="~/images/icons/last.gif" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </PagerTemplate>
        <PagerStyle CssClass="PagerRowStyle" />
        <HeaderStyle CssClass="HeaderStyle" />
        <EditRowStyle CssClass="EditRowStyle" />
        <AlternatingRowStyle CssClass="AlternatingRowStyle" />
        <SelectedRowStyle BackColor="#6699FF" Font-Bold="True" />
    </asp:GridView>
</div>

</asp:Panel>




<!-- SUPPORT -->
<asp:Panel ID="panSupport" runat="server" Visible="False">

<!-- panSData -->
<div>
<asp:Panel ID="panSData" runat="server" Visible="False" Width="100%">
    <table>
<tr>
<td align="center" colspan="2">

</td>
</tr>


        <tr>
            <td align="left">
                <strong>Ticket No:</strong></td>
            <td align="left">
                <asp:Label ID="lblTNo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <strong>Date Created:</strong></td>
            <td align="left">
                <asp:Label ID="lblDCreated" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <strong>Created By:</strong></td>
            <td align="left">
                <asp:Label ID="lblSCBy" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;</td>
            <td align="left" height="25px">
                &nbsp;</td>
        </tr>
    <tr>
        <td align="left" style="font-size: 15px; font-weight: bold">
            Subject:</td>
        <td align="left">
            <asp:Label ID="lblSubj" runat="server" Width="600px"></asp:Label>
        </td>
    </tr>

<tr>
<td align="left" valign="top" width="250px"><strong>Comment:</strong></td>
<td align="left">
    <asp:Label ID="lblComment" runat="server" Width="600px"></asp:Label>
</td>
</tr>

        <tr>
            <td align="left">
                <strong>Status:</strong></td>
            <td align="left">
                <asp:Label ID="lblStatus" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" height="30px">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>

<tr>
<td align="left" colspan="2">
<asp:Panel ID="panReply" runat="server" Width="100%" visible="false">
<table>
<tr>
            <td align="left" valign="top" width="250px">
                <strong>Type your reply here:</strong></td>
            <td align="left">
                <asp:TextBox ID="txtReply" runat="server" Rows="10" TextMode="MultiLine" 
                    Width="400px"></asp:TextBox>
            </td>
        </tr>

<tr>
<td>&nbsp;</td>
<td height="px" align="left">
    <asp:RadioButtonList ID="rblSStat" runat="server" 
        RepeatDirection="Horizontal">
        <asp:ListItem Selected="True" Value="1">Open</asp:ListItem>
        <asp:ListItem Value="2">Resolved</asp:ListItem>
    </asp:RadioButtonList>
    </td>
</tr>

        <tr>
            <td colspan="2">
                <asp:Label ID="lbleMsg4" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        
</table>
</asp:Panel>
</td>
</tr>
        
        <tr>
            <td>
            </td>
            <td align="right" height="px">
                <asp:Button ID="btnSubmit" runat="server" Text="Post a Reply" />
                <asp:Button ID="btnAllSupport" runat="server" Text="Show All Tickets" />
            </td>
        </tr>

<tr>
<td>&nbsp;</td>
<td align="right" height="px">
    &nbsp;</td>
</tr>

<tr>
<td align="center" valign="top" colspan="2">
    <asp:GridView ID="grdSTrans" runat="server" AutoGenerateColumns="False" 
        BorderColor="Black" CssClass="gridRow" DataKeyNames="supportTransID" 
        DataSourceID="sqlDS_STrans" PageSize="20" ShowFooter="True" Width="95%" ToolTip="View">
        <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
        <RowStyle CssClass="RowStyle" />
        <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
        <Columns>
            <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/icons/search.png" 
                ShowSelectButton="True" Visible="False" ShowHeader="True" HeaderText="View"></asp:CommandField>
            <asp:BoundField DataField="supportTransID" HeaderText="Support Trans ID" 
                Visible="False"></asp:BoundField>
            <asp:TemplateField HeaderText="Reply">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("reply") %>' width="500px"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Replied By">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("repliedBy") %>' 
                        width="275px"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("repliedBy") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date Replied">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("dateReplied") %>' 
                        width="200px"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("dateReplied") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("supportStatus") %>' 
                        width="70px"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("supportStatus") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="supportTransID" HeaderText="support trans id" 
                InsertVisible="False" ReadOnly="True" Visible="False">
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <FooterStyle CssClass="hiddencol" />
                <HeaderStyle CssClass="hiddencol" />
                <ItemStyle CssClass="hiddencol" />
            </asp:BoundField>
        </Columns>
        <EmptyDataTemplate>
            <div style="text-align:center; vertical-align:middle;">
                No previous replies!
            </div>
        </EmptyDataTemplate>
        <FooterStyle CssClass="FooterStyle" />
        <PagerTemplate>
            <table>
                <tbody>
                    <tr valign="middle">
                        <td>
                            <asp:ImageButton ID="imbFirst0" runat="server" AlternateText="First Page" 
                                CommandArgument="First" CommandName="Page" 
                                ImageUrl="~/images/icons/first.png" />
                            <asp:ImageButton ID="imbPrev0" runat="server" AlternateText="Previous Page" 
                                CommandArgument="Prev" CommandName="Page" ImageUrl="~/images/icons/prev.png" />
                        </td>
                        <td>
                            Page&nbsp;&nbsp;<asp:DropDownList ID="ddlPageNo0" runat="server" AutoPostBack="true" 
                                Width="50px">
                            </asp:DropDownList>
                            &nbsp;of&nbsp;
                            <asp:Label ID="lblPageCount0" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:ImageButton ID="imbNext0" runat="server" AlternateText="Next Page" 
                                CommandArgument="Next" CommandName="Page" ImageUrl="~/images/icons/next.gif" />
                            <asp:ImageButton ID="imbLast0" runat="server" AlternateText="Last Page" 
                                CommandArgument="Last" CommandName="Page" ImageUrl="~/images/icons/last.gif" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </PagerTemplate>
        <PagerStyle CssClass="PagerRowStyle" />
        <HeaderStyle CssClass="HeaderStyle" />
        <EditRowStyle CssClass="EditRowStyle" />
        <AlternatingRowStyle CssClass="AlternatingRowStyle" />
        <SelectedRowStyle BackColor="#6699FF" Font-Bold="True" />
    </asp:GridView>
    </td>
</tr>

    <tr>
        <td align="left">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            &nbsp;</td>
    </tr>
</table>
</asp:Panel>


<asp:Panel ID="panSGrid" runat="server" Visible="True" width="100%">
<div>
<asp:GridView ID="grdSupport" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" BorderColor="Black" CssClass="gridRow" 
                DataKeyNames="supportID" DataSourceID="sqlDS_Support" PageSize="20" 
                ShowFooter="True" Width="95%" ToolTip="View">
                <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
                <RowStyle CssClass="RowStyle" />
                <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
                <Columns>
                    <asp:CommandField ButtonType="Image" ShowHeader="True" HeaderText="View" SelectImageUrl="~/images/icons/search.png" 
                        ShowSelectButton="True"></asp:CommandField>
                    <asp:TemplateField HeaderText="Ticket No.">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("supportID") %>' 
                                Width="70px"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("supportID") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Subject">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("subject") %>' 
                                Width="250px"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("subject") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Comments">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("trimmedComment") %>'
                                Width="500px"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("trimmedComment") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date Created">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("dateSubmitted") %>'
                                Width="170px"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("dateSubmitted") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("supportStatus") %>'
                                Width="70px"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("supportStatus") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="supportID" HeaderText="support" 
                        InsertVisible="False" ReadOnly="True">
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <FooterStyle CssClass="hiddencol" />
                        <HeaderStyle CssClass="hiddencol" />
                        <ItemStyle CssClass="hiddencol" />
                    </asp:BoundField>
                </Columns>
                <EmptyDataTemplate>
                    <div style="text-align:center; vertical-align:middle;">
                        No Records Found!
                    </div>
                </EmptyDataTemplate>
                <FooterStyle CssClass="FooterStyle" />
                <PagerTemplate>
                    <table align="center">
                        <tbody>
                            <tr valign="middle">
                                <td>
                                    <asp:ImageButton ID="imbSFirst" runat="server" AlternateText="First Page" 
                                        CommandArgument="First" CommandName="Page" 
                                        ImageUrl="~/images/icons/first.png" />
                                    <asp:ImageButton ID="imbSPrev" runat="server" AlternateText="Previous Page" 
                                        CommandArgument="Prev" CommandName="Page" ImageUrl="~/images/icons/prev.png" />
                                </td>
                                <td>
                                    Page&nbsp;&nbsp;<asp:DropDownList ID="ddlSPageNo" runat="server" AutoPostBack="true" 
                                        Width="50px" onselectedindexchanged="ddlSPageNo_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    &nbsp;of&nbsp;
                                    <asp:Label ID="lblSPageCount" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:ImageButton ID="imbSNext" runat="server" AlternateText="Next Page" 
                                        CommandArgument="Next" CommandName="Page" ImageUrl="~/images/icons/next.gif" />
                                    <asp:ImageButton ID="imbSLast" runat="server" AlternateText="Last Page" 
                                        CommandArgument="Last" CommandName="Page" ImageUrl="~/images/icons/last.gif" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </PagerTemplate>
                <PagerStyle CssClass="PagerRowStyle" />
                <HeaderStyle CssClass="HeaderStyle" />
                <EditRowStyle CssClass="EditRowStyle" />
                <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                <SelectedRowStyle BackColor="#6699FF" Font-Bold="True" />
            </asp:GridView>
            </div>
</asp:Panel>
</div>
</asp:Panel>


<!-- ACCOUNTS -->
<asp:Panel ID="panAccount" runat="server" visible="false" width="100%">
<div>
		<asp:Button runat="server" Text="Add User" ID="btnAEmp"></asp:Button>
		<asp:Button ID="btnUnlock" runat="server" Text="View Locked Users"></asp:Button>
		<asp:Button ID="btnReactivate" runat="server" Text="View Deactivated Users"></asp:Button>
</div>
<br/>
<!-- grdAccount -->
<asp:Panel DefaultButton="btnSearch" ID="panUsers" runat="server">
    <asp:Panel ID="panUSearch" runat="server">
		<div>
			<strong>Search:</strong> &nbsp;&nbsp; &nbsp;<asp:TextBox ID="txtSearch" runat="server" width="300px"></asp:TextBox> &nbsp;&nbsp;&nbsp;
			<asp:Button runat="server" ID="btnSearch" Text="Search User"></asp:Button>
		</div>
		<br/>
		<div>
			<strong>Filter By:</strong> &nbsp;Account Type&nbsp;&nbsp;<asp:DropDownList ID="ddlFType" runat="server" AutoPostBack="True"></asp:DropDownList>
			&nbsp;&nbsp;&nbsp;&nbsp; Account Status:&nbsp;&nbsp;
			<asp:DropDownList ID="ddlFStatus" runat="server" AutoPostBack="True"></asp:DropDownList>
		</div>
    </asp:Panel>

	<br/>

	<div>
		<asp:GridView ID="grdAccount" runat="server" AllowPaging="True" 
			AutoGenerateColumns="False" BorderColor="Black" 
			CssClass="gridRow" DataKeyNames="userID" DataSourceID="sqlDS_Account" 
			ShowFooter="True" Width="95%" PageSize="20" ToolTip="Edit">
			<PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
			<RowStyle CssClass="RowStyle" />
			<EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
			<Columns>
				<asp:CommandField ButtonType="Image" SelectImageUrl="~/images/icons/modify.png" SelectText="Edit"
					ShowSelectButton="True" ShowHeader="true" HeaderText="Edit"></asp:CommandField>
				<asp:BoundField DataField="userID" HeaderText="userID" Visible="False">
				</asp:BoundField>
				<asp:BoundField DataField="empName" HeaderText="Name"></asp:BoundField>
				<asp:BoundField DataField="uname" HeaderText="Username"></asp:BoundField>
				<asp:BoundField DataField="accntType" HeaderText="Account Type"></asp:BoundField>
				<asp:BoundField DataField="sLoc" HeaderText="Store"></asp:BoundField>
				<asp:BoundField DataField="FCname" HeaderText="FC"></asp:BoundField>
				<asp:BoundField DataField="minorDiser" HeaderText="Double"></asp:BoundField>

				<asp:BoundField DataField="userID" InsertVisible="False" ReadOnly="True">
					<controlstyle cssclass="hiddencol" />
					<controlstyle cssclass="hiddencol" />
					<controlstyle cssclass="hiddencol" />
					<controlstyle cssclass="hiddencol" />
					<controlstyle cssclass="hiddencol" />
					<controlstyle cssclass="hiddencol" />
					<controlstyle cssclass="hiddencol" />
					<controlstyle cssclass="hiddencol" />
					<controlstyle cssclass="hiddencol" />
					<controlstyle cssclass="hiddencol" />
					<controlstyle cssclass="hiddencol" />
					<FooterStyle CssClass="hiddencol" />
					<HeaderStyle CssClass="hiddencol" />
					<ItemStyle CssClass="hiddencol" />
				</asp:BoundField>
			</Columns>
			<EmptyDataTemplate>
				<div style="text-align:center; vertical-align:middle;">
					No Records Found!</div>
			</EmptyDataTemplate>
			<FooterStyle CssClass="FooterStyle" />
			<PagerTemplate>
				<table align="center">
					<tbody>
						<tr valign="middle" align="center">
							<td>
								<asp:ImageButton ID="imbAFirst" runat="server" AlternateText="First Page" 
									CommandArgument="First" CommandName="Page" 
									ImageUrl="~/images/icons/first.png" />
								<asp:ImageButton ID="imbAPrev" runat="server" AlternateText="Previous Page" 
									CommandArgument="Prev" CommandName="Page" ImageUrl="~/images/icons/prev.png" />
							</td>
							<td>
								Page&nbsp;&nbsp;<asp:DropDownList ID="ddlAPageNo" runat="server" AutoPostBack="true" 
									 Width="50px" onselectedindexchanged="ddlAPageNo_SelectedIndexChanged">
								</asp:DropDownList>
								&nbsp;of&nbsp;
								<asp:Label ID="lblAPageCount" runat="server"></asp:Label>
							</td>
							<td>
								<asp:ImageButton ID="imbANext" runat="server" AlternateText="Next Page" 
									CommandArgument="Next" CommandName="Page" ImageUrl="~/images/icons/next.gif" />
								<asp:ImageButton ID="imbALast" runat="server" AlternateText="Last Page" 
									CommandArgument="Last" CommandName="Page" ImageUrl="~/images/icons/last.gif" />
							</td>
						</tr>
					</tbody>
				</table>
			</PagerTemplate>
			<PagerStyle CssClass="PagerRowStyle" />
			<HeaderStyle CssClass="HeaderStyle" />
			<EditRowStyle CssClass="EditRowStyle" />
			<AlternatingRowStyle CssClass="AlternatingRowStyle" />
			<SelectedRowStyle Font-Bold="True" />
		</asp:GridView>
	</div>
</asp:Panel>


<!-- grdDeactivate -->
<asp:Panel ID="panDeactivate" runat="server" visible="false">
    <asp:GridView ID="grdDeactivate" runat="server" 
        AutoGenerateColumns="False" BorderColor="Black" 
        CssClass="gridRow" DataKeyNames="userID" DataSourceID="sqlDS_Deactivate" 
        ShowFooter="True" Width="95%" PageSize="20">
        <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
        <RowStyle CssClass="RowStyle" />
        <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
        <Columns>
            <asp:BoundField DataField="userID" HeaderText="userID" Visible="False">
            </asp:BoundField>
            <asp:BoundField DataField="empName" HeaderText="Name"></asp:BoundField>
            <asp:BoundField DataField="sLoc" HeaderText="Store"></asp:BoundField>
            <asp:BoundField DataField="uname" HeaderText="Username"></asp:BoundField>
            <asp:BoundField DataField="accntType" HeaderText="Account Type"></asp:BoundField>
            <asp:BoundField DataField="loginStatus" HeaderText="Status"></asp:BoundField>

            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkReactivate" runat="server" text="Reactivate User" 
                        CommandArgument='<%# Eval("userID") %>' onclick="lnkReactivate_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="userID" InsertVisible="False" ReadOnly="True">
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <FooterStyle CssClass="hiddencol" />
                <HeaderStyle CssClass="hiddencol" />
                <ItemStyle CssClass="hiddencol" />
            </asp:BoundField>
        </Columns>
        <EmptyDataTemplate>
            <div style="text-align:center; vertical-align:middle;">
                No Deactivated Users
            </div>
        </EmptyDataTemplate>
        <FooterStyle CssClass="FooterStyle" />
        <PagerTemplate>
            <table>
                <tbody>
                    <tr valign="middle" align="center">
                        <td>
                            <asp:ImageButton ID="imbDFirst" runat="server" AlternateText="First Page" 
                                CommandArgument="First" CommandName="Page" 
                                ImageUrl="~/images/icons/first.png" />
                            <asp:ImageButton ID="imbDPrev" runat="server" AlternateText="Previous Page" 
                                CommandArgument="Prev" CommandName="Page" ImageUrl="~/images/icons/prev.png" />
                        </td>
                        <td>
                            Page&nbsp;&nbsp;<asp:DropDownList ID="ddlDPageNo" runat="server" AutoPostBack="true" 
                                 Width="50px"></asp:DropDownList>
                            &nbsp;of&nbsp;
                            <asp:Label ID="lblDPageCount" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:ImageButton ID="imbDNext" runat="server" AlternateText="Next Page" 
                                CommandArgument="Next" CommandName="Page" ImageUrl="~/images/icons/next.gif" />
                            <asp:ImageButton ID="imbDLast" runat="server" AlternateText="Last Page" 
                                CommandArgument="Last" CommandName="Page" ImageUrl="~/images/icons/last.gif" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </PagerTemplate>
        <PagerStyle CssClass="PagerRowStyle" />
        <HeaderStyle CssClass="HeaderStyle" />
        <EditRowStyle CssClass="EditRowStyle" />
        <AlternatingRowStyle CssClass="AlternatingRowStyle" />
        <SelectedRowStyle BackColor="#6699FF" Font-Bold="True" />
    </asp:GridView>
</asp:Panel>

<!-- grdUnlock -->
<asp:Panel ID="panUnlock" runat="server" visible="false">
    <asp:GridView ID="grdUnlock" runat="server" 
        AutoGenerateColumns="False" BorderColor="Black" 
        CssClass="gridRow" DataKeyNames="userID" DataSourceID="sqlDS_Unlock" 
        ShowFooter="True" Width="95%" PageSize="20">
        <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
        <RowStyle CssClass="RowStyle" />
        <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
        <Columns>
            <asp:BoundField DataField="userID" HeaderText="userID" Visible="False">
            </asp:BoundField>
            <asp:BoundField DataField="empName" HeaderText="Name"></asp:BoundField>
            <asp:BoundField DataField="sLoc" HeaderText="Store"></asp:BoundField>
            <asp:BoundField DataField="uname" HeaderText="Username"></asp:BoundField>
            <asp:BoundField DataField="accntType" HeaderText="Account Type"></asp:BoundField>
            <asp:BoundField DataField="lockedCount" HeaderText="Locked Count"></asp:BoundField>

            <asp:BoundField DataField="lockedDate" HeaderText="Locked Date">
            </asp:BoundField>
            <asp:BoundField DataField="loginStatus" HeaderText="Status"></asp:BoundField>

            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="imbUnlock" runat="server" CommandArgument='<%# Eval("userID") %>'
                        ImageUrl="~/images/icons/unlock1.png" onclick="imbUnlock_Click" Tooltip="Unlock Account" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="userID" InsertVisible="False" ReadOnly="True">
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <controlstyle cssclass="hiddencol" />
                <FooterStyle CssClass="hiddencol" />
                <HeaderStyle CssClass="hiddencol" />
                <ItemStyle CssClass="hiddencol" />
            </asp:BoundField>
        </Columns>
        <EmptyDataTemplate>
            <div style="text-align:center; vertical-align:middle;">
                No Locked Accounts!
            </div>
        </EmptyDataTemplate>
        <FooterStyle CssClass="FooterStyle" />
        <PagerTemplate>
            <table>
                <tbody>
                    <tr valign="middle" align="center">
                        <td>
                            <asp:ImageButton ID="imbUFirst" runat="server" AlternateText="First Page" 
                                CommandArgument="First" CommandName="Page" 
                                ImageUrl="~/images/icons/first.png" />
                            <asp:ImageButton ID="imbUPrev" runat="server" AlternateText="Previous Page" 
                                CommandArgument="Prev" CommandName="Page" ImageUrl="~/images/icons/prev.png" />
                        </td>
                        <td>
                            Page&nbsp;&nbsp;<asp:DropDownList ID="ddlUPageNo" runat="server" AutoPostBack="true" 
                                 Width="50px"></asp:DropDownList>
                            &nbsp;of&nbsp;
                            <asp:Label ID="lblUPageCount" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:ImageButton ID="imbUNext" runat="server" AlternateText="Next Page" 
                                CommandArgument="Next" CommandName="Page" ImageUrl="~/images/icons/next.gif" />
                            <asp:ImageButton ID="imbULast" runat="server" AlternateText="Last Page" 
                                CommandArgument="Last" CommandName="Page" ImageUrl="~/images/icons/last.gif" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </PagerTemplate>
        <PagerStyle CssClass="PagerRowStyle" />
        <HeaderStyle CssClass="HeaderStyle" />
        <EditRowStyle CssClass="EditRowStyle" />
        <AlternatingRowStyle CssClass="AlternatingRowStyle" />
        <SelectedRowStyle BackColor="#6699FF" Font-Bold="True" />
    </asp:GridView>
</asp:Panel>

<!-- panAEmp -->
<div>
<asp:Panel ID="panAEmp" runat="server" Visible="False" width="100%">
<table style="padding-left:30px;">

    <tr>
        <td align="left">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="left" colspan="2">
            <h3 style="padding-bottom:15px;">Personal Information</h3></td>
    </tr>
    <tr>
        <td align="left" valign="top">
            Name:</td>
        <td align="left" style="font-size: 9px;">
            <asp:TextBox ID="txtFname" runat="server" ReadOnly="True" Width="190px"></asp:TextBox>
            <asp:TextBox ID="txtMname" runat="server" ReadOnly="True" Width="95px"></asp:TextBox>
            <asp:TextBox ID="txtLname" runat="server" ReadOnly="True" Width="150px"></asp:TextBox>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; First 
            Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Middle 
            Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Last Name</td>
    </tr>

<tr>
<td align="left">Address:</td>
<td align="left">
    <asp:TextBox ID="txtAAdd" runat="server" ReadOnly="True" 
        Width="445px"></asp:TextBox>
</td>
</tr>

<tr>
<td align="left" valign="top">Contact No/s:</td>
<td align="left">
    <asp:TextBox ID="txtAContact" runat="server" ReadOnly="True" Rows="10" 
        Width="445px"></asp:TextBox>
</td>
</tr>

    <tr>
        <td align="left" valign="top">
            Email Address:</td>
        <td align="left">
            <asp:TextBox ID="txtAEmail" runat="server" ReadOnly="True" Rows="10" 
                Width="445px"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td align="left" valign="top">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="left" colspan="2" valign="top">
            <h3 style="padding-bottom:15px;">Login Details</h3>
            </td>
    </tr>

<tr>
<td align="left" valign="top">Username:</td>
<td align="left">
    <asp:TextBox ID="txtAUname" runat="server" ReadOnly="True" Rows="10" 
        Width="445px"></asp:TextBox>
</td>
</tr>

<tr>
<td align="left" valign="top">Account Type:</td>
<td align="left">
    <asp:DropDownList ID="ddlAAType" runat="server" Width="450px" Enabled="False" 
        AutoPostBack="True">
    </asp:DropDownList>
</td>
</tr>

    <tr>
        <td align="left" valign="top">
            Login Status:</td>
        <td align="left">
            <asp:DropDownList ID="ddlLStat" runat="server" Width="450px" Enabled="False">
            </asp:DropDownList>
        </td>
    </tr>

    <tr>
        <td align="left" valign="top">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="left" colspan="2" valign="top">
        <h3 style="padding-bottom:15px;">Employment Details</h3>
            </td>
    </tr>

    <tr>
        <td align="left" valign="top" width="180px">
            Field Coordinator:</td>
        <td align="left">
            <asp:DropDownList ID="ddlFC" runat="server" AutoPostBack="True" Enabled="False" 
                Width="450px">
            </asp:DropDownList>
        </td>
    </tr>

    <tr>
        <td align="left" valign="top" width="180px">
            <asp:Label ID="lblFC" runat="server" Text="Senior Field Coordinator:"></asp:Label>
        </td>
        <td align="left">
            <asp:DropDownList ID="ddlSFC" runat="server" AutoPostBack="True" 
                Enabled="False" Width="450px">
            </asp:DropDownList>
        </td>
    </tr>

<tr>
<td align="left" valign="top">Double:</td>
<td align="left">
    <asp:TextBox ID="txtADouble" runat="server" ReadOnly="True" Rows="10" 
        Width="445px"></asp:TextBox>
</td>
</tr>

    <tr>
        <td align="left">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
    </tr>

    


    <tr>
        <td align="left" colspan="2">
         <h3 style="padding-bottom:15px;">Store Assignment</h3>
            </td>
    </tr>
    <tr>
        <td align="left">
            Store Location:</td>
        <td align="left">
            <asp:DropDownList ID="ddlStore" runat="server" Width="450px">
            </asp:DropDownList>
        </td>
    </tr>

    


    <tr>
        <td align="center" colspan="2" height="30px">
            <asp:Label ID="lbleMsg3" runat="server" ForeColor="Red"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="left">
            &nbsp;</td>
        <td align="right">
            <asp:Button ID="btnAcModify" runat="server" Text="Modify" />
            <asp:Button ID="btnAcCancel" runat="server" Text="Cancel" />
            &nbsp;&nbsp;
            <asp:Button ID="btnAcReset" runat="server" Text="Reset Password" 
                Visible="False" />
            <asp:Button ID="btnDeactivate" runat="server" Text="Deactivate User" 
                Visible="False" />
        </td>
    </tr>
    <tr>
        <td align="left">
            &nbsp;</td>
        <td align="right">
            &nbsp;</td>
    </tr>
</table>
</asp:Panel>
</div>
<asp:SqlDataSource ID="sqlDS_Deactivate" runat="server" 
        ConnectionString="<%$ ConnectionStrings:conString %>" 
        SelectCommand="SELECT * FROM vw_Users 
                        WHERE loginStatusID = 6 AND userID <> 2
                        ORDER BY empName ">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sqlDS_Unlock" runat="server" 
        ConnectionString="<%$ ConnectionStrings:conString %>" 
        SelectCommand="SELECT * FROM vw_Users 
                        WHERE loginStatusID = 3 AND userID <> 2 AND loginStatusID <> 6
                        ORDER BY empName ">
    </asp:SqlDataSource>

<asp:SqlDataSource id="sqlDS_Announce" runat="server"
SelectCommand="SELECT *
                FROM vw_Announce
                ORDER BY announceID DESC" 
ConnectionString="<%$ ConnectionStrings:conString %>">
</asp:SqlDataSource>

<asp:SqlDataSource id="sqlDS_Account" runat="server"
SelectCommand="SELECT * FROM vw_Users 
                WHERE userID <> 2 AND loginStatusID <> 6 
                ORDER BY userID DESC" 
ConnectionString="<%$ ConnectionStrings:conString %>">
</asp:SqlDataSource>
    
    <asp:SqlDataSource ID="sqlDS_Brand" runat="server" 
        ConnectionString="<%$ ConnectionStrings:conString %>" 
        SelectCommand="SELECT * FROM vw_Brand ORDER BY brandID ">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sqlDS_Item" runat="server" 
        ConnectionString="<%$ ConnectionStrings:conString %>" 
        SelectCommand="SELECT * FROM vw_Info WHERE ISNULL(shortCode, '') &lt;&gt; '' ORDER BY shortCode">
    </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="sqlDS_Model" runat="server" 
        ConnectionString="<%$ ConnectionStrings:conString %>" 
        SelectCommand="SELECT * FROM vw_Model ORDER BY model"></asp:SqlDataSource>
        
        <asp:SqlDataSource ID="sqlDS_Cap" runat="server" 
        ConnectionString="<%$ ConnectionStrings:conString %>" 
        SelectCommand="SELECT * FROM vw_Capacity ORDER BY capacity">
    </asp:SqlDataSource>
        
        <asp:SqlDataSource ID="sqlDS_City" runat="server" 
        ConnectionString="<%$ ConnectionStrings:conString %>" 
        SelectCommand="SELECT * FROM vw_City ORDER BY city"></asp:SqlDataSource>
        
        <asp:SqlDataSource ID="sqlDS_Prov" runat="server" 
        ConnectionString="<%$ ConnectionStrings:conString %>" 
        SelectCommand="SELECT * FROM vw_Province ORDER BY province"></asp:SqlDataSource>

        <asp:SqlDataSource ID="sqlDS_Store" runat="server" 
        ConnectionString="<%$ ConnectionStrings:conString %>" 
        SelectCommand="SELECT * FROM vw_Store ORDER BY location">
    </asp:SqlDataSource>

        <asp:SqlDataSource ID="sqlDS_Support" runat="server" 
        ConnectionString="<%$ ConnectionStrings:conString %>" SelectCommand="SELECT *
                FROM vw_Support
                ORDER BY supportID"
                >
             
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDS_STrans" runat="server" 
        ConnectionString="<%$ ConnectionStrings:conString %>" 
        SelectCommand="SELECT * FROM [vw_SupportTrans] WHERE ([supportID] = @supportID) ORDER BY [supportTransID] DESC">
        <SelectParameters>
            <asp:SessionParameter Name="supportID" SessionField="supportID" Type="Int64" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <asp:SqlDataSource ID="sqlDS_Target" runat="server" 
        ConnectionString="<%$ ConnectionStrings:conString %>" 
        SelectCommand="SELECT * FROM [vw_Target]"></asp:SqlDataSource>
</asp:Panel>
</DIV>

</DIV>

</contenttemplate>
</asp:UpdatePanel>

</asp:Content>
