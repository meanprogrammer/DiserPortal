<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
CodeBehind="Community.aspx.vb" Inherits="DiserPortal.Community" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            height: 24px;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<%--</DIV>--%>
<asp:UpdatePanel ID="updTM" runat="server" >
<ContentTemplate>

<%--<DIV id="main_wrap">--%>
<div style="float:left; height:100%; width:250px; background-color:#7eb037; color:White; margin-left:0px;">
<table class="mItem" style="height:100%; padding-top:20px; padding-bottom:20px;">
<tr>
<td><b style="font-size:14px;">AWARDS</b></td>
</tr>

<tr>
<td>
    <asp:LinkButton ID="lkbDiser" CssClass="mItem" runat="server" text="Top Ten Disers"></asp:LinkButton>
    </td>
</tr>

<tr>
<td><asp:LinkButton ID="lkbFC" class="mItem" runat="server" text="Top Ten FCs"></asp:LinkButton>
</td>
</tr>

<tr>
<td><asp:LinkButton ID="lkbAssess" class="mItem" runat="server" text="Top Ten Assessments"></asp:LinkButton></td>
</tr>

<tr>
<td><asp:LinkButton ID="lkbDisplay" class="mItem" runat="server" text="Top Ten Store Displays"></asp:LinkButton></td>
</tr>



<tr>
<td style="height:30px;"></td>
</tr>

<tr>
<td><b style="font-size:14px;">EVENTS</b></td>
</tr>

<tr>
<td>
    <asp:LinkButton ID="lkbDAct" CssClass="mItem" runat="server" text="Diser Activities"></asp:LinkButton>
    </td>
</tr>

<tr>
<td><asp:LinkButton ID="lkbGallery" class="mItem" runat="server" text="Gallery"></asp:LinkButton>
</td>
</tr>


<tr>
<td style="height:30px;"></td>
</tr>

<tr>
<td><b style="font-size:14px;">DISER'S NOOK</b></td>
</tr>

<tr>
<td><asp:LinkButton ID="lkbIncentive" class="mItem" runat="server" text="Incentive Payouts"></asp:LinkButton></td>
</tr>

<tr>
<td><asp:LinkButton ID="lkbBday" class="mItem" runat="server" text="Birthday Greetings"></asp:LinkButton></td>
</tr>

<tr>
<td><asp:LinkButton ID="lkbSaveh" class="mItem" runat="server" text="Ano Saveh"></asp:LinkButton></td>
</tr>

<tr>
<td><asp:LinkButton ID="lkbKwento" class="mItem" runat="server" text="Kwento Kutsero"></asp:LinkButton></td>
</tr>

<tr>
<td><asp:LinkButton ID="lkbSpoofs" class="mItem" runat="server" text="Spoofs & Caricatures"></asp:LinkButton></td>
</tr>
</table>
</div>

<div style="float:left;padding-left:20px;">
<asp:Panel ID="panDiser" runat="server">
    &nbsp;<table width="100%">
<tr>
<td rowspan="10">
    <asp:Image ID="imgDiser" runat="server" Height="250px" 
        Width="200px" ImageUrl="~/images/announcePics/announce.jpg"></asp:Image></td>
<td>&nbsp;</td>
    <td colspan="2">
        &nbsp;</td>
</tr>

<tr>
<td width="30px">&nbsp;</td>
    <td colspan="2" style="font-weight: bold; font-size: 17px;">
        <asp:Label ID="lblDNote" runat="server" Text="#1 Merchandiser for "></asp:Label>
    </td>
</tr>

<tr>
<td>&nbsp;</td>
    <td>
        &nbsp;</td>
<td>&nbsp;</td>
</tr>

<tr>
<td>&nbsp;</td>
    <td>
        Verified Sales:</td>
<td>
    <asp:Label ID="lblSales" runat="server"></asp:Label>
    </td>
</tr>

<tr>
<td>&nbsp;</td>
    <td>
        Merchandiser:</td>
<td>
    <asp:Label ID="lblDiser" runat="server"></asp:Label>
    </td>
</tr>

<tr>
<td>&nbsp;</td>
    <td>
        Field Coordinator:</td>
<td width="300px">
    <asp:Label ID="lblFC" runat="server"></asp:Label>
    </td>
</tr>

<tr>
<td>&nbsp;</td>
    <td width="150px">
        Sr. Field Coordinator:</td>
<td>
    <asp:Label ID="lblSFC" runat="server"></asp:Label>
    </td>
</tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            Store:</td>
        <td>
            <asp:Label ID="lblStore" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            Location:</td>
        <td>
            <asp:Label ID="lblLoc" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style1">
        </td>
        <td class="style1">
        </td>
        <td class="style1">
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <asp:GridView ID="grdDiser" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CssClass="gridRow" DataKeyNames="userID" 
                DataSourceID="sqlDS_Diser" ShowFooter="True" Width="95%">
                <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
                <RowStyle CssClass="RowStyle" />
                <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
                <Columns>
                    <asp:BoundField DataField="userID" Visible="False"></asp:BoundField>
                    <asp:BoundField DataField="empName" HeaderText="Merchandiser"></asp:BoundField>
                    <asp:BoundField DataField="totalSales" HeaderText="Sales"></asp:BoundField>
                    <asp:BoundField DataField="FCName" HeaderText="FC"></asp:BoundField>
                    <asp:BoundField DataField="SFCName" HeaderText="SFC"></asp:BoundField>
                    <asp:BoundField DataField="dealerLoc" HeaderText="Store - Location">
                    </asp:BoundField>
                    <asp:BoundField DataField="userID" InsertVisible="False" ReadOnly="True">
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <FooterStyle CssClass="hiddencol" />
                        <HeaderStyle CssClass="hiddencol" />
                        <ItemStyle CssClass="hiddencol" />
                    </asp:BoundField>
                </Columns>
                <EmptyDataTemplate>
                    <div style="text-align:center">No Record Found!</div>
                </EmptyDataTemplate>
                <FooterStyle CssClass="FooterStyle" />
                <PagerTemplate>
                    <table>
                        <tbody>
                            <tr valign="middle">
                                <td align="center">
                                    <asp:ImageButton ID="imbFirst" runat="server" AlternateText="First Page" 
                                        CommandArgument="First" CommandName="Page" 
                                        ImageUrl="~/images/icons/first.gif" />
                                    <asp:ImageButton ID="imbPrev" runat="server" AlternateText="Previous Page" 
                                        CommandArgument="Prev" CommandName="Page" ImageUrl="~/images/icons/prev.gif" />
                                </td>
                                <td>
                                    Page&nbsp;
                                    <asp:DropDownList ID="ddlPageNo" runat="server" AutoPostBack="true" Width="50px">
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
        </td>
    </tr>
</table>
</asp:Panel>
</div>

<DIV style="CLEAR: both">
    <asp:SqlDataSource ID="sqlDS_Diser" runat="server" 
        ConnectionString="<%$ ConnectionStrings:conString %>" 
        SelectCommand="SELECT * FROM vw_TopDiser
                        WHERE wMonthID = @monthID AND wYear = @wYr">
        <SelectParameters>
            <asp:SessionParameter Name="monthID" SessionField="monthID" Type="Int64" />
            <asp:SessionParameter Name="wYr" SessionField="wYr" Type="String" />
        </SelectParameters>
        </asp:SqlDataSource>
</DIV>
<%--</DIV>--%>


</ContentTemplate>
</asp:UpdatePanel>
<%--</div>--%>

</asp:Content>

