<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
CodeBehind="DataBuildUp.aspx.vb" Inherits="DiserPortal.DataBuildUp" %>

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
            <asp:LinkButton id="lnkProd" runat="server" CssClass="tabprop-Selected" Text="Product" 
                OnClick="lnkProd_Click"></asp:LinkButton> </LI>
        <LI><br /><asp:LinkButton id="lnkCompete" onclick="lnkCompete_Click" runat="server" CssClass="tabprop-selected" 
                Text="Brand"></asp:LinkButton></LI>
        <LI><br />
            <asp:LinkButton ID="lnkStocks" runat="server" CssClass="tabprop-selected" OnClick="lnkStocks_Click"
                Text="Model"></asp:LinkButton></LI>
        <LI><br />
            <asp:LinkButton ID="lnkInventory" runat="server" CssClass="tabprop-selected" OnClick="lnkInventory_Click"
                Text="Variant"></asp:LinkButton><A href="#"></A>
        </LI>
    </UL>
</DIV></DIV>
<!-- end tab wrap -->

<DIV style="CLEAR: both"></DIV>

<DIV id="cont_wrap">

<!-- START PLACING CONTENT HERE -->
<DIV style="HEIGHT: 20px"></DIV>
<DIV style="PADDING-LEFT: 20px; FLOAT: left">


<!-- END OF CONTENT PLACEMENT -->
</DIV><!-- end cont wrap -->
</DIV><!-- end main wrap -->

</ContentTemplate>
</asp:UpdatePanel> 
</div>  
</center>

</asp:Content>
