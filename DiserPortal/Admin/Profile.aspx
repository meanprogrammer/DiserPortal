<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
CodeBehind="Profile.aspx.vb" Inherits="DiserPortal.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<center>
<div class="dataWrapper">
<asp:UpdatePanel ID="updSearchApp" runat="server">
<ContentTemplate>
<CENTER><TABLE class="main">
<TBODY><TR><TD style="HEIGHT: 30px" class="tr_space" colSpan=2></TD></TR>
<TR><TD class="title" colSpan=2><H2>My Account</H2></TD></TR>
<TR><TD align="left" width="180">&nbsp;</TD><TD align="left" height="30px">
    &nbsp;</TD></TR>
    <tr>
        <td align="left" valign="top">
            Name:</td>
        <td align="left">
            <asp:Label ID="txtName" runat="server" Width="350px" Font-Bold="True"></asp:Label>
            </td>
    </tr>
    <TR><TD align="left">Store Designation:</TD><TD align="left">
        <asp:Label id="txtStore" 
            runat="server" Width="350px"></asp:Label> </TD></TR>
    <tr>
        <td align="left" valign="top">
            FC Name:</td>
        <td align="left">
            <asp:Label ID="txtFC" runat="server" Width="350px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="left" valign="top">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="left" valign="top">
            Address:</td>
        <td align="left">
            <asp:Label ID="txtAdd" runat="server" Width="350px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="left" valign="top">
            Contact Number/s:</td>
        <td align="left">
            <asp:Label ID="txtContact" runat="server" Width="350px"></asp:Label>
        </td>
    </tr>
    <TR>
    <TD colSpan=2></TD></TR><TR><TD align="left">Username:</TD><TD align="left">
    <asp:Label id="txtUname" runat="server" Width="350px"></asp:Label> </TD></TR><TR>
    <TD align="left">Password: 
        <asp:ImageButton id="imbMPwd" onclick="imbMPwd_Click" runat="server" 
            ImageUrl="~/images/icons/modify.png" AlternateText="Modify" __designer:wfdid="w7" Tooltip="Edit"></asp:ImageButton> 
        <asp:ImageButton id="imbCPwd" onclick="imbCPwd_Click" runat="server" Visible="False" 
            ImageUrl="~/images/icons/cancel.png" AlternateText="Cancel" __designer:wfdid="w9" Tooltip="Cancel"></asp:ImageButton>
    </TD><TD align="left">
            <asp:TextBox ID="txtPwd" runat="server" Visible="False" Width="350px"></asp:TextBox>
        <asp:Label id="lblPwd" 
        runat="server" Width="350px"></asp:Label> <BR />
            <asp:TextBox id="txtCPwd" 
        runat="server" Width="350px" textmode="password" visible="False"></asp:TextBox> </TD></TR><TR>
        <TD align="left">
    User Account Type:</TD><TD align="left">
            <asp:Label id="txtAType" runat="server" visible="False" Width="350px" 
                __designer:wfdid="w1"></asp:Label></TD></TR><TR>
        <TD align="left" width="150px">Security Question:</TD><TD align="left">
        <asp:DropDownList id="ddlQuestion" runat="server" Width="350px" 
            __designer:wfdid="w4"></asp:DropDownList> 
        <asp:Label id="txtQuestion" runat="server" visible="False" Width="350px" 
            __designer:wfdid="w2"></asp:Label></TD></TR><TR>
    <TD align="left">Security Answer: 
        <asp:ImageButton id="imbMAns" onclick="imbMAns_Click" runat="server" 
            ImageUrl="~/images/icons/modify.png" AlternateText="Modify" Tooltip="Edit"
            __designer:wfdid="w8"></asp:ImageButton> 
        <asp:ImageButton id="imbCAns" onclick="imbCAns_Click" runat="server" Visible="False" 
            ImageUrl="~/images/icons/cancel.png" AlternateText="Cancel" __designer:wfdid="w10" Tooltip="Cancel"></asp:ImageButton> 
    </TD><TD align="left">
    <asp:Label id="lblAnswer" runat="server" Width="350px"></asp:Label> 
    <asp:TextBox id="txtAnswer" runat="server" Width="350px" Visible="False"></asp:TextBox> 
        
    </TD></TR><TR><TD class="tr_space" colSpan=2></TD></TR><TR>
    <TD align="left">User Status:</TD><TD align="left">
    <asp:Label id="txtUStatus" 
        runat="server" Width="350px"></asp:Label> </TD></TR><TR>
    <TD align="left">Locked Count:</TD><TD align="left">
        <asp:Label id="txtLCount" 
            runat="server" Width="350px"></asp:Label> </TD></TR><TR><TD class="tr_space" colSpan=2></TD></TR><TR>
    <TD colSpan=2>
    <p><asp:Label id="lbleMsg" runat="server" CssClass="errMsg" __designer:wfdid="w3" 
            ToolTip=".: Required Field :." ForeColor="Red"></asp:Label></p></TD></TR><TR><TD class="tr_space" colSpan=2>
    &nbsp;&nbsp;&nbsp; </TD></TR><TR><TD class="tr_space" colSpan=2></TD></TR></TBODY></TABLE></CENTER>
</ContentTemplate>
</asp:UpdatePanel>
</div>
</center>

</asp:Content>
