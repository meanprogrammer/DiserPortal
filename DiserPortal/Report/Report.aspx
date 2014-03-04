<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
CodeBehind="Report.aspx.vb" Inherits="DiserPortal.Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<center>
<div class="dataWrapper">
<asp:UpdatePanel ID="updTM" runat="server">
<ContentTemplate>

<DIV id="main_wrap">
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
    </asp:UpdateProgress>
</div>
<DIV id="tab_wrap">
    <UL class="tabprop">
        <LI id="lProd" runat="server"><br />
            <asp:LinkButton id="lnkProd" runat="server" CssClass="tabprop-Selected" 
                Text="Sales Report"></asp:LinkButton></LI>
        <LI id="lCompete" runat="server"><br />
            <asp:LinkButton ID="lnkCompete" runat="server" CssClass="tabprop" 
                Text="Competitor Sales Report"></asp:LinkButton></LI>
        <LI id="lStocks" runat="server"><br />
            <asp:LinkButton ID="lnkStocks" runat="server" CssClass="tabprop" 
                Text="Stock Runs Out Report"></asp:LinkButton></LI>
        <LI id="lInventory" runat="server"><br />
            <asp:LinkButton ID="lnkInventory" runat="server" CssClass="tabprop" 
                Text="Stocks Inventory Report"></asp:LinkButton></LI>
    </UL>
</DIV>
</DIV>
<!-- end tab wrap -->
<%--
<DIV style="CLEAR: both">
</DIV>--%>

<DIV id="cont_wrap">

<%--<DIV style="HEIGHT: 50px">
    <asp:UpdateProgress ID="PageUpdateProgress2" runat="server">
        <progresstemplate>
            <div style="width:100%">
            <div style="padding: 15px; vertical-align:middle;float:left;">
                <asp:Image runat="server" Height="20px" ImageUrl="~/images/icons/loading.gif" />
            </div>
            <div style="padding:15px; text-align:right;vertical-align:middle;float:right;">
                <asp:Image runat="server" Height="20px" ImageUrl="~/images/icons/loading.gif" />
            </div></div>
        </progresstemplate>
    </asp:UpdateProgress>
    </DIV>--%>
    <DIV style="height:15px; color:Red;font-weight:bolder;bgcolor:dimgray;vertical-align:bottom;padding:7px;">
    <asp:Label ID="lbleMsg" runat="server" ForeColor="red" text=""></asp:Label></DIV>



<%--SALES--%>
<asp:Panel ID="panSales" runat="server">
<div style="text-align:left; padding-left:25px;">
    <table width="100%">
    <%--<tr>
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
    </tr>--%>

    <%--<tr>
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
    </tr>--%>

    <tr>
    <td width="100px">Filter By:</td>
    <td width="35px">
        &nbsp;</td>
    <td>
        <asp:DropDownList ID="ddlFilter" runat="server" AutoPostBack="True">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem Value="2">Weekly</asp:ListItem>
            <asp:ListItem Value="3">Monthly</asp:ListItem>
            <asp:ListItem Value="4">Yearly</asp:ListItem>
        </asp:DropDownList>
        </td>
    <td width="35px">
        &nbsp;</td>
    <td width="150px">
            Promodiser:</td>
    <td width="35px">
        <asp:DropDownList ID="ddlEmp" runat="server" AutoPostBack="True" Width="250px">
        </asp:DropDownList>
        </td>
    <td>
        &nbsp;&nbsp;&nbsp;&nbsp;
        </td>
    <td>
        &nbsp;</td>
    </tr>

        <tr>
            <td>
                <asp:Label ID="lblDate" runat="server" Text="Date Coverage:" Visible="False"></asp:Label>
            </td>
            <td width="35px">
                &nbsp;</td>
            <td>
                <asp:DropDownList ID="ddlDate" runat="server" AutoPostBack="True" 
                    Visible="False">
                </asp:DropDownList>
            </td>
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
            <td>
                &nbsp;</td>
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
        </tr>
        <tr>
            <td colspan="8">
                <asp:GridView ID="grdSales" runat="server" AutoGenerateColumns="False" 
                    CssClass="gridRow" DataKeyNames="subID" 
                    DataSourceID="sqlDS_Sales" PageSize="30" ShowFooter="True" Width="95%" 
                    AllowPaging="True">
                    <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
                    <RowStyle CssClass="RowStyle" />
                    <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
                    <Columns>
                        <asp:BoundField DataField="subID" Visible="False"></asp:BoundField>
                        
                        <asp:BoundField DataField="dealer" HeaderText="Dealer"></asp:BoundField>
                        <asp:BoundField DataField="location" HeaderText="Store Location"></asp:BoundField>
                        <asp:BoundField DataField="parentBP" HeaderText="Parent BP"></asp:BoundField>
                        <asp:BoundField DataField="childBP1" HeaderText="Child BP1"></asp:BoundField>
                        <asp:BoundField DataField="childBP2" HeaderText="Child BP2"></asp:BoundField>
                        <asp:BoundField DataField="childBP3" HeaderText="Child BP3"></asp:BoundField>
                        <asp:BoundField DataField="Region" HeaderText="Region"></asp:BoundField>

                        <%--<asp:BoundField DataField="cName" HeaderText="Employee"></asp:BoundField>
                        <asp:BoundField DataField="cAddress" HeaderText="Address"></asp:BoundField>
                        <asp:BoundField DataField="contact" HeaderText="Contact"></asp:BoundField>--%>
                        
                        <asp:BoundField DataField="product" HeaderText="Product"></asp:BoundField>
                        <asp:BoundField DataField="brand" HeaderText="Brand"></asp:BoundField>
                        <asp:BoundField DataField="shortCode" HeaderText="Short Code"></asp:BoundField>
                        <asp:BoundField DataField="model" HeaderText="Model"></asp:BoundField>
                        <asp:BoundField DataField="capacity" HeaderText="Capacity"></asp:BoundField>
                        <asp:BoundField DataField="variant" HeaderText="Variant"></asp:BoundField>
                        <asp:BoundField DataField="longCode" HeaderText="Long Code"></asp:BoundField>
                        <asp:BoundField DataField="dPurchased" HeaderText="Purchased Date" 
                            SortExpression="city"></asp:BoundField>

                        <asp:BoundField DataField="qty" HeaderText="Qty"></asp:BoundField>
                        <asp:BoundField DataField="empName" HeaderText="Employee"></asp:BoundField>
                        <asp:BoundField DataField="dSubmitted" HeaderText="Submission Date" 
                            SortExpression="city"></asp:BoundField>
                        <%--<asp:BoundField DataField="serial" HeaderText="Serial"></asp:BoundField>
                        <asp:BoundField DataField="invoice" HeaderText="Invoice"></asp:BoundField>--%>
                        <asp:BoundField DataField="subID" InsertVisible="False" ReadOnly="True">
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
                                        <asp:ImageButton ID="imbFirst" runat="server" AlternateText="First Page" 
                                            CommandArgument="First" CommandName="Page" 
                                            ImageUrl="~/images/icons/first.gif" />
                                        <asp:ImageButton ID="imbPrev" runat="server" AlternateText="Previous Page" 
                                            CommandArgument="Prev" CommandName="Page" ImageUrl="~/images/icons/prev.gif" />
                                    </td>
                                    <td>
                                        Page&nbsp;
                                        <asp:DropDownList ID="ddlPageNo" runat="server" AutoPostBack="true" 
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
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <EditRowStyle CssClass="EditRowStyle" />
                    <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                </asp:GridView>
            </td>
        </tr>
    </table><br /><br />
    </div>
</asp:Panel>


<%--COMPETITOR--%>
<asp:Panel ID="panCompete" runat="server" visible="false">
<div style="text-align:left; padding-left:25px;">
    <table width="100%">
    <%--<tr>
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
    </tr>--%>

    <tr>
    <td width="100px">Filter By:</td>
    <td width="35px">
        &nbsp;</td>
    <td>
        <asp:DropDownList ID="ddlCFilter" runat="server" AutoPostBack="True">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem Value="2">Weekly</asp:ListItem>
            <asp:ListItem Value="3">Monthly</asp:ListItem>
            <asp:ListItem Value="4">Yearly</asp:ListItem>
        </asp:DropDownList>
        </td>
    <td width="35px">
        &nbsp;</td>
        <td width="100px">
            Per Brand:</td>
    <td width="35px">
        &nbsp;</td>
    <td>
        <asp:DropDownList ID="ddlBrand" runat="server" AutoPostBack="True" Width="250px">
        </asp:DropDownList>
    </td>
    <td>
        &nbsp;</td>
    </tr>

        <tr>
            <td>
                <asp:Label ID="lblCDate" runat="server" Text="Date Coverage:" Visible="False"></asp:Label>
            </td>
            <td width="35px">
                &nbsp;</td>
            <td>
                <asp:DropDownList ID="ddlCDate" runat="server" AutoPostBack="True" 
                    Visible="False">
                </asp:DropDownList>
            </td>
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
            <td>
                &nbsp;</td>
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
        </tr>
        <tr>
            <td colspan="8">
                <asp:GridView ID="grdCompete" runat="server" AutoGenerateColumns="False" 
                    CssClass="gridRow" DataKeyNames="cSubID" 
                    DataSourceID="sqlDS_Compete" PageSize="30" ShowFooter="True" Width="95%" 
                    AllowPaging="True">
                    <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
                    <RowStyle CssClass="RowStyle" />
                    <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
                    <Columns>
                        <asp:BoundField DataField="cSubID" Visible="False"></asp:BoundField>
                        
                        <asp:BoundField DataField="cBrand" HeaderText="Brand"></asp:BoundField>
                        <asp:BoundField DataField="cCapacity" HeaderText="Capacity"></asp:BoundField>
                        <asp:BoundField DataField="qty" HeaderText="Qty"></asp:BoundField>
                        <asp:BoundField DataField="csDate" HeaderText="Date"></asp:BoundField>
                        <asp:BoundField DataField="factor" HeaderText="Factor"></asp:BoundField>

                        <asp:BoundField DataField="empName" HeaderText="Employee"></asp:BoundField>
                        <asp:BoundField DataField="dSubmitted" HeaderText="Submission Date" 
                            SortExpression="city"></asp:BoundField>
                        <asp:BoundField DataField="cSubID" InsertVisible="False" ReadOnly="True">
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
                                            ImageUrl="~/images/icons/first.gif" />
                                        <asp:ImageButton ID="imbCPrev" runat="server" AlternateText="Previous Page" 
                                            CommandArgument="Prev" CommandName="Page" ImageUrl="~/images/icons/prev.gif" />
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
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <EditRowStyle CssClass="EditRowStyle" />
                    <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                </asp:GridView>
            </td>
        </tr>
    </table><br /><br />
    </div>
</asp:Panel>

<%--STOCKS--%>
<asp:Panel ID="panStocks" runat="server" visible="false">
<div style="text-align:left; padding-left:25px;">
    <table width="100%">
   <%-- <tr>
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
    </tr>--%>

    <tr>
    <td width="100px">Filter By:</td>
    <td width="35px">
        &nbsp;</td>
    <td>
        <asp:DropDownList ID="ddlSFilter" runat="server" AutoPostBack="True">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem Value="2">Weekly</asp:ListItem>
            <asp:ListItem Value="3">Monthly</asp:ListItem>
            <asp:ListItem Value="4">Yearly</asp:ListItem>
        </asp:DropDownList>
        </td>
    <td width="35px">
        &nbsp;</td>
        <td width="100px">
            Promodiser:</td>
    <td width="35px">
        &nbsp;</td>
    <td>
        <asp:DropDownList ID="ddlSEmp" runat="server" AutoPostBack="True" Width="250px">
        </asp:DropDownList>
        </td>
    <td>
        &nbsp;</td>
    </tr>

        <tr>
            <td>
                <asp:Label ID="lblSDate" runat="server" Text="Date Coverage:" Visible="False"></asp:Label>
            </td>
            <td width="35px">
                &nbsp;</td>
            <td>
                <asp:DropDownList ID="ddlSDate" runat="server" AutoPostBack="True" 
                    Visible="False">
                </asp:DropDownList>
            </td>
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
            <td>
                &nbsp;</td>
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
        </tr>
        <tr>
            <td colspan="8">
                <asp:GridView ID="grdStocks" runat="server" AutoGenerateColumns="False" 
                    CssClass="gridRow" DataKeyNames="sSubID" 
                    DataSourceID="sqlDS_Stocks" PageSize="30" ShowFooter="True" Width="95%" 
                    AllowPaging="True">
                    <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
                    <RowStyle CssClass="RowStyle" />
                    <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
                    <Columns>
                        <asp:BoundField DataField="sSubID" Visible="False"></asp:BoundField>
                        
                        <asp:BoundField DataField="product" HeaderText="Product"></asp:BoundField>
                        <asp:BoundField DataField="brand" HeaderText="Brand"></asp:BoundField>
                        <asp:BoundField DataField="shortCode" HeaderText="Short Code"></asp:BoundField>

                        <asp:BoundField DataField="longCode" HeaderText="Long Code"></asp:BoundField>
                        <asp:BoundField DataField="itemDesc" HeaderText="Item Description"></asp:BoundField>
                        <asp:BoundField DataField="capacity" HeaderText="Capacity"></asp:BoundField>
                        <asp:BoundField DataField="variant" HeaderText="Variant"></asp:BoundField>
                        <asp:BoundField DataField="model" HeaderText="Model"></asp:BoundField>
                        
                        <asp:BoundField DataField="dWhen" HeaderText="Date"></asp:BoundField>
                        <asp:BoundField DataField="actTake" HeaderText="Action Taken"></asp:BoundField>
                        <asp:BoundField DataField="empName" HeaderText="Employee"></asp:BoundField>
                        <asp:BoundField DataField="dSubmitted" HeaderText="Submission Date" 
                            SortExpression="city"></asp:BoundField>

                        <asp:BoundField DataField="sSubID" InsertVisible="False" ReadOnly="True">
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
                                        <asp:ImageButton ID="imbSFirst" runat="server" AlternateText="First Page" 
                                            CommandArgument="First" CommandName="Page" 
                                            ImageUrl="~/images/icons/first.gif" />
                                        <asp:ImageButton ID="imbSPrev" runat="server" AlternateText="Previous Page" 
                                            CommandArgument="Prev" CommandName="Page" ImageUrl="~/images/icons/prev.gif" />
                                    </td>
                                    <td>
                                        Page&nbsp;
                                        <asp:DropDownList ID="ddlSPageNo" runat="server" AutoPostBack="true" 
                                            Width="50px">
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
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <EditRowStyle CssClass="EditRowStyle" />
                    <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                </asp:GridView>
            </td>
        </tr>
    </table><br /><br />
    </div>
</asp:Panel>


<%--INVENTORY--%>
<asp:Panel ID="panInventory" runat="server" visible="false">
<div style="text-align:left; padding-left:25px;">
    <table width="100%">
    <%--<tr>
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
    </tr>--%>

    <tr>
    <td width="100px">Filter By:</td>
    <td width="35px">
        &nbsp;</td>
    <td>
        <asp:DropDownList ID="ddlIFilter" runat="server" AutoPostBack="True">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem Value="2">Weekly</asp:ListItem>
            <asp:ListItem Value="3">Monthly</asp:ListItem>
            <asp:ListItem Value="4">Yearly</asp:ListItem>
        </asp:DropDownList>
        </td>
    <td width="35px">
        &nbsp;</td>
        <td width="100px">
            Promodiser:</td>
    <td width="35px">
        &nbsp;</td>
    <td>
        <asp:DropDownList ID="ddlIEmp" runat="server" AutoPostBack="True" Width="250px">
        </asp:DropDownList>
        </td>
    <td>
        &nbsp;</td>
    </tr>

        <tr>
            <td>
                <asp:Label ID="lblIDate" runat="server" Text="Date Coverage:" Visible="False"></asp:Label>
            </td>
            <td width="35px">
                &nbsp;</td>
            <td>
                <asp:DropDownList ID="ddlIDate" runat="server" AutoPostBack="True" 
                    Visible="False">
                </asp:DropDownList>
            </td>
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
            <td>
                &nbsp;</td>
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
        </tr>
        <tr>
            <td colspan="8">
                <asp:GridView ID="grdInventory" runat="server" AutoGenerateColumns="False" 
                    CssClass="gridRow" DataKeyNames="iSubID" 
                    DataSourceID="sqlDS_Inventory" PageSize="30" ShowFooter="True" Width="95%" 
                    AllowPaging="True">
                    <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
                    <RowStyle CssClass="RowStyle" />
                    <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
                    <Columns>
                        <asp:BoundField DataField="iSubID" Visible="False"></asp:BoundField>
                        
                        <asp:BoundField DataField="product" HeaderText="Product"></asp:BoundField>
                        <asp:BoundField DataField="brand" HeaderText="Brand"></asp:BoundField>
                        <asp:BoundField DataField="shortCode" HeaderText="Short Code"></asp:BoundField>
                        <asp:BoundField DataField="longCode" HeaderText="Child BP1"></asp:BoundField>
                        <asp:BoundField DataField="itemDesc" HeaderText="Child BP2"></asp:BoundField>
                        <asp:BoundField DataField="capacity" HeaderText="Child BP3"></asp:BoundField>
                        <asp:BoundField DataField="variant" HeaderText="Region"></asp:BoundField>

                        <asp:BoundField DataField="model" HeaderText="Model"></asp:BoundField>
                        <asp:BoundField DataField="qty" HeaderText="Qty"></asp:BoundField>
                        <asp:BoundField DataField="comments" HeaderText="Comments"></asp:BoundField>
                        <asp:BoundField DataField="empName" HeaderText="Employee"></asp:BoundField>
                        <asp:BoundField DataField="dSubmitted" HeaderText="Submission Date" 
                            SortExpression="city"></asp:BoundField>

                        <asp:BoundField DataField="iSubID" InsertVisible="False" ReadOnly="True">
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
                                        <asp:ImageButton ID="imbIFirst" runat="server" AlternateText="First Page" 
                                            CommandArgument="First" CommandName="Page" 
                                            ImageUrl="~/images/icons/first.gif" />
                                        <asp:ImageButton ID="imbIPrev" runat="server" AlternateText="Previous Page" 
                                            CommandArgument="Prev" CommandName="Page" ImageUrl="~/images/icons/prev.gif" />
                                    </td>
                                    <td>
                                        Page&nbsp;
                                        <asp:DropDownList ID="ddlIPageNo" runat="server" AutoPostBack="true" 
                                            Width="50px">
                                        </asp:DropDownList>
                                        &nbsp;of&nbsp;
                                        <asp:Label ID="lblIPageCount" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="imbINext" runat="server" AlternateText="Next Page" 
                                            CommandArgument="Next" CommandName="Page" ImageUrl="~/images/icons/next.gif" />
                                        <asp:ImageButton ID="imbILast" runat="server" AlternateText="Last Page" 
                                            CommandArgument="Last" CommandName="Page" ImageUrl="~/images/icons/last.gif" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </PagerTemplate>
                    <PagerStyle CssClass="PagerRowStyle" />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <EditRowStyle CssClass="EditRowStyle" />
                    <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                </asp:GridView>
            </td>
        </tr>
    </table><br /><br />
    </div>
</asp:Panel>
</DIV>


<%--SQL Connections--%>

<%--SALES--%>
<asp:SqlDataSource id="sqlDS_Sales" runat="server" 
    ConnectionString="<%$ ConnectionStrings:conString %>" 
    SelectCommand="SELECT * FROM vw_SalesReport 
                    WHERE userID = @userID
                    ORDER BY subID DESC">
<SelectParameters>
                <asp:SessionParameter Name="userID" 
                    SessionField="userID" Type="Int64" />
            </SelectParameters>
</asp:SqlDataSource>

<%--COMPETITOR--%>
<asp:SqlDataSource id="sqlDS_Compete" runat="server" 
    ConnectionString="<%$ ConnectionStrings:conString %>" 
    SelectCommand="SELECT * FROM vw_CompeteReport 
                    WHERE userID = @userID
                    ORDER BY cSubID DESC">
<SelectParameters>
                <asp:SessionParameter Name="userID" 
                    SessionField="userID" Type="Int64" />
            </SelectParameters>
</asp:SqlDataSource>

<%--STOCKS--%>
<asp:SqlDataSource id="sqlDS_Stocks" runat="server" 
    ConnectionString="<%$ ConnectionStrings:conString %>" 
    SelectCommand="SELECT * FROM vw_StocksReport 
                    WHERE userID = @userID
                    ORDER BY sSubID DESC">
<SelectParameters>
                <asp:SessionParameter Name="userID" 
                    SessionField="userID" Type="Int64" />
            </SelectParameters>
</asp:SqlDataSource>

<%--INVENTORY--%>
<asp:SqlDataSource id="sqlDS_Inventory" runat="server" 
    ConnectionString="<%$ ConnectionStrings:conString %>" 
    SelectCommand="SELECT * FROM vw_InventoryReport 
                    WHERE userID = @userID
                    ORDER BY iSubID DESC">
<SelectParameters>
                <asp:SessionParameter Name="userID" 
                    SessionField="userID" Type="Int64" />
            </SelectParameters>
</asp:SqlDataSource>

</ContentTemplate>
</asp:UpdatePanel>
</div>
</center>

</asp:Content>
