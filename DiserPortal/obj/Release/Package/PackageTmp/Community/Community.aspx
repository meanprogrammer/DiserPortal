<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
CodeBehind="Community.aspx.vb" Inherits="DiserPortal.Community" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<center>
<div class="dataWrapper">
<asp:UpdatePanel ID="updTM" runat="server">
<ContentTemplate>

<DIV id="main_wrap">
<DIV id="tab_wrap">
    <UL class="tabprop">
        <LI><br />
            <asp:LinkButton id="lnkAType" runat="server" CssClass="tabprop-Selected" Text="User Account Type"></asp:LinkButton> </LI>
        <LI><br /><asp:LinkButton id="lnkData" runat="server" CssClass="tabprop-selected" 
                Text="Data Build-Up"></asp:LinkButton></LI>
        <LI><br />
            <asp:LinkButton ID="lnkAnnounce" runat="server" CssClass="tabprop-selected" 
                Text="Announcements"></asp:LinkButton></LI>
    </UL>
</DIV>
</DIV>
<!-- end tab wrap -->

<DIV style="CLEAR: both">
</DIV>

<DIV id="cont_wrap">
<br />
<asp:Label ID="lbleMsg" runat="server" ForeColor="red" text=""></asp:Label>

<%--ACCOUNT TYPE--%>
<asp:Panel ID="panAType" runat="server">
<div style="text-align:left; padding-left:25px;">
    <table>
    <tr>
    <td colspan="3">
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
            <td class="style1" colspan="3">
                <h2>
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
    <td style="height:30px;" colspan="3">
    </td>
    <td style="height:30px;">
        &nbsp;</td>
    <td style="height:30px;">
        &nbsp;</td>
    <td style="height:30px;">
        &nbsp;</td>
    <td style="height:30px;">
        &nbsp;</td>
    <td style="height:30px;">
        &nbsp;</td>
    <td style="height:30px;">
        &nbsp;</td>
    <td style="height:30px;">
        &nbsp;</td>
    <td style="height:30px;">
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
    <td>&nbsp;</td>
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

</DIV>

</ContentTemplate>
</asp:UpdatePanel>
</div>
</center>

</asp:Content>

