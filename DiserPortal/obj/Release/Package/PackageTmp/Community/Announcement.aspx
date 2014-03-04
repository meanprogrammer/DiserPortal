<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
CodeBehind="Announcement.aspx.vb" Inherits="DiserPortal.Announcement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<center>
<div class="dataWrapper">
<asp:UpdatePanel ID="updTM" runat="server">
<ContentTemplate>

<DIV id="main_wrap">

<div style="height:30px;"></div>

<div>
<h2 style="vertical-align:middle;">Announcements</h2>
</div>

<div style="height:30px;"></div>

<div>
    <asp:GridView ID="grdAnnounce" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" BorderColor="Black" 
        CssClass="gridRow" DataKeyNames="announceID" DataSourceID="sqlDS_Announce" 
        ShowFooter="True" Width="75%" Visible="False">
        <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
        <RowStyle CssClass="RowStyle" />
        <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
        <Columns>
            <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/icons/maximize.gif" 
                ShowSelectButton="True"></asp:CommandField>
            <asp:BoundField DataField="announceID" HeaderText="announceID" Visible="False">
            </asp:BoundField>
            <asp:BoundField DataField="aTitle" HeaderText="Title"></asp:BoundField>
            <asp:BoundField DataField="intro" HeaderText="Introduction"></asp:BoundField>
            <asp:BoundField DataField="dateCreated" HeaderText="Date Created">
            </asp:BoundField>
            <asp:BoundField DataField="cBy" HeaderText="Created  By"></asp:BoundField>
            <asp:BoundField DataField="lastUpdate" HeaderText="Date Last Modified">
            </asp:BoundField>
            <asp:BoundField DataField="mBy" HeaderText="Modified By"></asp:BoundField>
            <asp:BoundField DataField="announceID" InsertVisible="False" ReadOnly="True">
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
            <table>
                <tbody>
                    <tr valign="middle">
                        <td>
                            <asp:ImageButton ID="imbFirst" runat="server" AlternateText="First Page" 
                                CommandArgument="First" CommandName="Page" 
                                ImageUrl="~/images/icons/first.gif" />
                            <asp:ImageButton ID="imbPrev" runat="server" AlternateText="Previous Page" 
                                CommandArgument="Prev" CommandName="Page" ImageUrl="~/images/icons/prev.gif" />
                        </td>
                        <td>
                            Page&nbsp;&nbsp;<asp:DropDownList ID="ddlPageNo" runat="server" AutoPostBack="true" 
                                 Width="50px">
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
        <SelectedRowStyle Font-Bold="True" />
    </asp:GridView>
</div>

<div style="height:30px;">
</div>

<div>
<asp:Panel ID="panAnnounce" runat="server">

<table>
<tr>
<td align="center" colspan="2">
    <asp:Image ID="imgPic" runat="server"  />
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
            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="15px"></asp:Label>
        </td>
    </tr>

<tr>
<td align="left">Intro:</td>
<td align="left">
    <asp:Label ID="lblIntro" runat="server" CssClass="iJustify" Font-Italic="True" 
        Width="400px"></asp:Label>
</td>
</tr>

<tr>
<td></td>
<td height="px">
    &nbsp;</td>
</tr>

<tr>
<td align="left">Story:</td>
<td align="left">
    <asp:Label ID="lblStory" runat="server" CssClass="iJustify" Width="400px"></asp:Label>
</td>
</tr>

<tr>
<td align="left">&nbsp;</td>
<td align="left" height="30px">
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
        <td align="left">
            &nbsp;</td>
        <td align="right">
            <asp:LinkButton ID="lnkAll" runat="server">View All</asp:LinkButton>
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
</DIV>

<asp:SqlDataSource id="sqlDS_Announce" runat="server"
SelectCommand="SELECT *
                FROM vw_Announce
                WHERE aStatusID = 1
                ORDER BY announceID DESC" 
ConnectionString="<%$ ConnectionStrings:conString %>">
</asp:SqlDataSource>

</ContentTemplate>
</asp:UpdatePanel>
</div>
</center>

</asp:Content>
