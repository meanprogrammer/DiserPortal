<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
CodeBehind="SalesReport.aspx.vb" Inherits="DiserPortal.SalesReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <center>
<div class="dataWrapper">
<asp:UpdatePanel ID="updSearchApp" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<CENTER><TABLE style="FONT-SIZE: 13px" class="main"><TBODY><TR><TD style="WIDTH: 85px" class="tr_space" colSpan=1></TD><TD style="WIDTH: 210px" class="tr_space" colSpan=1></TD></TR><TR><TD class="tr_space" colSpan=2><asp:Button id="btnBack" onclick="btnView_Click" runat="server" Text="Return to Sales Form"></asp:Button></TD></TR><TR><TD class="tr_space" colSpan=2><asp:Label id="lbleMsg" runat="server" CssClass="errMsg" ToolTip=".: Required Field :.">
    </asp:Label> </TD></TR><TR><TD style="FONT-WEIGHT: bolder; FONT-SIZE: 17px; width: 85px;" align=right>Promodiser: </TD><TD style="FONT-WEIGHT: bolder; FONT-SIZE: 17px; WIDTH: 210px" colSpan=1><asp:Label id="lblDiser" runat="server" Text="Label"></asp:Label></TD></TR><TR><TD style="FONT-WEIGHT: bolder; FONT-SIZE: 17px; width: 85px;" align=right>Week Coverage:</TD><TD style="FONT-WEIGHT: bolder; FONT-SIZE: 17px; WIDTH: 210px" colSpan=1><asp:Label id="lblWeek" runat="server" Text="Label"></asp:Label></TD></TR><TR><TD style="FONT-WEIGHT: bolder; FONT-SIZE: 17px; width: 85px;" align=right>Date Submitted:</TD><TD style="FONT-WEIGHT: bolder; FONT-SIZE: 17px; WIDTH: 210px" colSpan=1><asp:Label id="lblDSub" runat="server" Text="Label"></asp:Label></TD></TR><TR><TD style="WIDTH: 85px" class="tr_space" colSpan=1></TD><TD style="WIDTH: 210px" class="tr_space" colSpan=1></TD></TR><TR><TD style="WIDTH: 85px" class="tr_space" colSpan=1></TD><TD style="WIDTH: 210px" class="tr_space" colSpan=1></TD></TR><TR><TD class="tr_space" colSpan=2><asp:GridView id="grdSearch" runat="server" CssClass="gridRow" Width="100%" DataSourceID="sqlDS_Search" AutoGenerateColumns="False" BorderColor="Black" ShowFooter="True" DataKeyNames="subID" PageSize="30">
<PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom"></PagerSettings>

<RowStyle CssClass="RowStyle"></RowStyle>

<EmptyDataRowStyle CssClass="EmptyDataRowStyle"></EmptyDataRowStyle>
<Columns>
<asp:BoundField DataField="subID" Visible="False"></asp:BoundField>
<asp:BoundField DataField="cName" HeaderText="Customer"></asp:BoundField>
<asp:BoundField DataField="cAddress" HeaderText="Address"></asp:BoundField>
<asp:BoundField DataField="contact" HeaderText="Contact"></asp:BoundField>
<asp:BoundField DataField="qty" HeaderText="Qty"></asp:BoundField>
<asp:BoundField DataField="product" HeaderText="Product"></asp:BoundField>
<asp:BoundField DataField="brand" HeaderText="Brand"></asp:BoundField>
<asp:BoundField DataField="model" HeaderText="Model"></asp:BoundField>
<asp:BoundField DataField="capacity" HeaderText="Capacity"></asp:BoundField>
<asp:BoundField DataField="variant" HeaderText="Variant"></asp:BoundField>
<asp:BoundField DataField="dPurchased" HeaderText="Date Purchased" SortExpression="city"></asp:BoundField>
<asp:BoundField DataField="serial" HeaderText="Serial"></asp:BoundField>
<asp:BoundField DataField="invoice" HeaderText="Invoice"></asp:BoundField>
<asp:BoundField DataField="subID" ReadOnly="True" InsertVisible="False">
<ControlStyle CssClass="hiddencol"></ControlStyle>

<FooterStyle CssClass="hiddencol"></FooterStyle>

<HeaderStyle CssClass="hiddencol"></HeaderStyle>

<ItemStyle CssClass="hiddencol"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle CssClass="FooterStyle"></FooterStyle>
<PagerTemplate>
    <TABLE>
    <TBODY>
    <TR vAlign=middle>
    <TD>
        <asp:ImageButton id="imbFirst" runat="server" 
            CommandName="Page" 
            ImageUrl="~/images/icons/first.gif" CommandArgument="First" AlternateText="First Page"></asp:ImageButton> <asp:ImageButton id="imbPrev" runat="server" CommandName="Page" ImageUrl="~/images/icons/prev.gif" CommandArgument="Prev" AlternateText="Previous Page"></asp:ImageButton> </TD><TD>Page&nbsp; <asp:DropDownList id="ddlPageNo" runat="server" AutoPostBack="true" Width="50px" ></asp:DropDownList> &nbsp;of&nbsp; <asp:Label id="lblPageCount" runat="server"></asp:Label> </TD><TD><asp:ImageButton id="imbNext" runat="server" CommandName="Page" ImageUrl="~/images/icons/next.gif" CommandArgument="Next" AlternateText="Next Page"></asp:ImageButton> <asp:ImageButton id="imbLast" runat="server" CommandName="Page" ImageUrl="~/images/icons/last.gif" CommandArgument="Last" AlternateText="Last Page"></asp:ImageButton> </TD></TR></TBODY></TABLE>
</PagerTemplate>

<PagerStyle CssClass="PagerRowStyle"></PagerStyle>

<SelectedRowStyle CssClass="SelectedRowStyle"></SelectedRowStyle>

<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>

<EditRowStyle CssClass="EditRowStyle"></EditRowStyle>

<AlternatingRowStyle CssClass="AlternatingRowStyle"></AlternatingRowStyle>
</asp:GridView> <BR /></TD></TR>

<%--SQL Connections--%>
<asp:SqlDataSource id="sqlDS_Search" runat="server" 
    ConnectionString="<%$ ConnectionStrings:conString %>" 
    SelectCommand="SELECT * FROM vw_SalesSub 
                    WHERE userID = @userID
                    ORDER BY subID DESC">
<SelectParameters>
                <asp:SessionParameter Name="userID" 
                    SessionField="userID" Type="Int64" />
            </SelectParameters>
</asp:SqlDataSource></TBODY></TABLE></CENTER>
</ContentTemplate>
</asp:UpdatePanel>
</div>
</center>
</asp:Content>
