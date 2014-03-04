<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
CodeBehind="DownloadedFile.aspx.vb" Inherits="DiserPortal.DownloadedFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<center>
<div class="dataWrapper">
<asp:UpdatePanel ID="updTM" runat="server">
<ContentTemplate>

<DIV id="main_wrap">  


<DIV id="cont_wrap">
<div style="height:50px;">
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
<div style="float:left;padding:15px;">
Week Coverage:&nbsp;<asp:Label ID="lblWeek" runat="server"></asp:Label>
                &nbsp;&nbsp;
                <asp:Button ID="btnLoadFile" runat="server" Text="Load Data to Sales Form" />
                &nbsp;<asp:Label ID="lbleMsg" runat="server" ForeColor="red" text=""></asp:Label>
</div>
</DIV>
<!-- START PLACING CONTENT HERE -->

<%--SALES--%>
<asp:Panel ID="panSales" runat="server">
<div style="text-align:left; padding-left:25px;">
    <table width="100%">
       
        <tr>
        <td colspan="8">

<!-- panData -->
<div>
<asp:Panel ID="panData" runat="server" Visible="False">
<table width="100%">
    <tr>
        <td align="left" valign="top">
            Customer:</td>
        <td align="left" style="font-size:9px;">
            <asp:TextBox ID="txtFname" runat="server" Width="250px"></asp:TextBox>
            <asp:TextBox ID="txtLname" runat="server" Width="150px"></asp:TextBox>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; First 
            Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            Last Name<br />
        </td>
    </tr>

<tr>
<td align="left">Address:</td>
<td align="left" style="font-size:9px;">
    <asp:TextBox ID="txtAdd" runat="server" Width="250px"></asp:TextBox>
    <asp:DropDownList ID="ddlCity" runat="server" Width="150px">
    </asp:DropDownList>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; # / Lot / Block / Bldg. / St. / Village / 
    District&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; City<br />
</td>
</tr>

<tr>
<td>Contact No.:</td>
<td height="px">
    <asp:TextBox ID="txtContact" runat="server" Width="400px"></asp:TextBox>
    </td>
</tr>

<tr>
<td align="left" valign="top">Qty:</td>
<td align="left">
    <asp:Label ID="lblQty" runat="server" Width="400px"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlQty" runat="server" Width="400px">
        <asp:ListItem>Select the Quantity</asp:ListItem>
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>6</asp:ListItem>
        <asp:ListItem>7</asp:ListItem>
        <asp:ListItem>8</asp:ListItem>
        <asp:ListItem>9</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>11</asp:ListItem>
        <asp:ListItem>12</asp:ListItem>
        <asp:ListItem>13</asp:ListItem>
        <asp:ListItem>14</asp:ListItem>
        <asp:ListItem>15</asp:ListItem>
        <asp:ListItem>16</asp:ListItem>
        <asp:ListItem>17</asp:ListItem>
        <asp:ListItem>18</asp:ListItem>
        <asp:ListItem>19</asp:ListItem>
        <asp:ListItem>20</asp:ListItem>
    </asp:DropDownList>
</td>
</tr>

<tr>
<td align="left" valign="top">Product:</td>
<td align="left">
    <asp:Label ID="lblProd" runat="server" Width="400px"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlProd" runat="server" Width="400px" AutoPostBack="True">
    </asp:DropDownList>
</td>
</tr>

<tr>
<td align="left" valign="top">Brand:</td>
<td align="left">
    <asp:Label ID="lblBrand" runat="server" Width="400px"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlBrand" runat="server" Width="400px" 
        AutoPostBack="True">
    </asp:DropDownList>
</td>
</tr>

<tr>
<td align="left" valign="top">Short Code:</td>
<td align="left">
    <asp:Label ID="lblSCode" runat="server" Width="400px"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlSCode" runat="server" Width="400px">
    </asp:DropDownList>
</td>
</tr>

<tr>
<td align="left" valign="top">Date Purchased:</td>
<td align="left">
    <asp:Label ID="lblDP" runat="server" Width="400px"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlDP" runat="server" Width="400px">
    </asp:DropDownList>
</td>
</tr>

<tr>
<td align="left" valign="top">Serial No.:</td>
<td align="left">
    <asp:Textbox ID="txtSerial" runat="server" Width="400px"></asp:Textbox>
</td>
</tr>

<tr>
<td align="left" valign="top">Invoice No.:</td>
<td align="left">
    <asp:Textbox ID="txtInvoice" runat="server" Width="400px"></asp:Textbox>
</td>
</tr>

 
    <tr>
        <td align="left" valign="top">
            Status:</td>
        <td align="left">
            <asp:Label ID="lblStatus" runat="server" Width="400px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="left" valign="top">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
    </tr>

 
 <tr>
        <td align="left" colspan="2">
            <asp:Button ID="btnModify" runat="server" Text="Update" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
        </td>
    </tr>
    <tr>
        <td align="left" colspan="2">
            &nbsp;</td>
    </tr>
</table>
</asp:Panel>
</div>

                <asp:GridView ID="grdUpload" runat="server" 
                    CssClass="gridRow" PageSize="30" ShowFooter="True" Width="95%" 
                    AutoGenerateColumns="False" DataKeyNames="eID,upStat,uploadDate" 
                    DataSourceID="sqlDS_Upload">
                    <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
                    <RowStyle CssClass="RowStyle" />
                    <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
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
                    <HeaderStyle CssClass="HeaderStyle" />
                    <Columns>
                        <asp:CommandField ButtonType="Image" 
                            SelectImageUrl="~/images/icons/modify.gif" ShowSelectButton="True">
                        </asp:CommandField>
                        <asp:BoundField DataField="eID" Visible="False"></asp:BoundField>
                        <asp:BoundField DataField="fname" HeaderText="First Name"></asp:BoundField>
                        <asp:BoundField DataField="lname" HeaderText="Last Name"></asp:BoundField>
                        <asp:BoundField DataField="cAdd" HeaderText="Address"></asp:BoundField>
                        <asp:BoundField DataField="city" HeaderText="City"></asp:BoundField>
                        <asp:BoundField DataField="contact" HeaderText="Contact No"></asp:BoundField>
                        <asp:BoundField DataField="qty" HeaderText="Qty"></asp:BoundField>
                        <asp:BoundField DataField="product" HeaderText="Product"></asp:BoundField>
                        <asp:BoundField DataField="brand" HeaderText="Brand"></asp:BoundField>
                        <asp:BoundField DataField="sCode" HeaderText="Short Code"></asp:BoundField>
                        <asp:BoundField DataField="dpurchased" HeaderText="Date Purchased">
                        </asp:BoundField>
                        <asp:BoundField DataField="serialNo" HeaderText="Serial No"></asp:BoundField>
                        <asp:BoundField DataField="invoice" HeaderText="Invoice No"></asp:BoundField>
                        <asp:BoundField DataField="upStat" HeaderText="Upload Status"></asp:BoundField>
                        <asp:BoundField DataField="uploadDate" HeaderText="Upload Date">
                        </asp:BoundField>
                    </Columns>
                    <EditRowStyle CssClass="EditRowStyle" />
                    <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                    <SelectedRowStyle Font-Bold="True" />
                </asp:GridView>

                
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="sqlDS_Upload" runat="server" 
        ConnectionString="<%$ ConnectionStrings:conString %>" 
        
        SelectCommand="SELECT * FROM [tbl_ExcelUpload] 
                        WHERE (userID = @userID AND [uploadDate] = @uploadDate)">
        <SelectParameters>
            <asp:SessionParameter Name="userID" SessionField="userID" Type="Int64"  />
            <asp:SessionParameter Name="uploadDate" SessionField="uploadDate" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    </div>
</asp:Panel>


<%--competitor--%>
<asp:Panel ID="panCompete" runat="server">
<div style="text-align:left; padding-left:25px;">
    <table width="100%">
        <%--<tr>
            <td colspan="8" style="height:50px;">

                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="8" style="vertical-align:middle;padding-left:20px;text-align:left;">
                Week Coverage:&nbsp;<asp:Label ID="lblCWeek" runat="server"></asp:Label>
                &nbsp;&nbsp;
                <asp:Button ID="btnCLoadFile" runat="server" Text="Load Data to Sales Form" />
                &nbsp;<asp:Label ID="lbleMsg" runat="server" ForeColor="red" text=""></asp:Label>
            </td>
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
        </tr>--%>
        <tr>
            <td colspan="8">

<!-- panData -->
<div>
<asp:Panel ID="panCData" runat="server" Visible="False">
<table width="100%">
<tr>
<td align="left" valign="top">Brand:</td>
<td align="left">
    <asp:Label ID="lblCBrand" runat="server" Width="400px"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlCBrand" runat="server" Width="400px">
    </asp:DropDownList>
</td>
</tr>

<tr>
<td align="left" valign="top">Capacity:</td>
<td align="left">
    <asp:Label ID="lblCCap" runat="server" Width="400px"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlCCap" runat="server" Width="400px">
    </asp:DropDownList>
</td>
</tr>

<tr>
<td align="left" valign="top">Qty:</td>
<td align="left">
    <asp:Label ID="lblCQty" runat="server" Width="400px"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlCQty" runat="server" Width="400px">
        <asp:ListItem>Select the Quantity</asp:ListItem>
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>6</asp:ListItem>
        <asp:ListItem>7</asp:ListItem>
        <asp:ListItem>8</asp:ListItem>
        <asp:ListItem>9</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>11</asp:ListItem>
        <asp:ListItem>12</asp:ListItem>
        <asp:ListItem>13</asp:ListItem>
        <asp:ListItem>14</asp:ListItem>
        <asp:ListItem>15</asp:ListItem>
        <asp:ListItem>16</asp:ListItem>
        <asp:ListItem>17</asp:ListItem>
        <asp:ListItem>18</asp:ListItem>
        <asp:ListItem>19</asp:ListItem>
        <asp:ListItem>20</asp:ListItem>
    </asp:DropDownList>
</td>
</tr>

<tr>
<td align="left" valign="top">Date Purchased:</td>
<td align="left">
    <asp:Label ID="lblCDP" runat="server" Width="400px"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlCDP" runat="server" Width="400px">
    </asp:DropDownList>
</td>
</tr>

<tr>
<td align="left" valign="top">Factors Affecting Sell Out:</td>
<td align="left">
    <asp:Textbox ID="txtFactors" textmode="multiline" runat="server" Width="400px"></asp:Textbox>
</td>
</tr>

    <tr>
        <td align="left" valign="top">
            Status:</td>
        <td align="left">
            <asp:Label ID="lblCStatus" runat="server" Width="400px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="left" valign="top">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
    </tr>

 
 <tr>
        <td align="left" colspan="2">
            <asp:Button ID="btnCModify" runat="server" Text="Update" />
            <asp:Button ID="btnCCancel" runat="server" Text="Cancel" />
        </td>
    </tr>
    <tr>
        <td align="left" colspan="2">
            &nbsp;</td>
    </tr>
</table>
</asp:Panel>
</div>

                <asp:GridView ID="grdCUpload" runat="server" 
                    CssClass="gridRow" PageSize="30" ShowFooter="True" Width="95%" 
                    AutoGenerateColumns="False" DataKeyNames="eCID,upStat,uploadDate" 
                    DataSourceID="sqlDS_CUpload" Visible="False">
                    <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
                    <RowStyle CssClass="RowStyle" />
                    <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
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
                    <HeaderStyle CssClass="HeaderStyle" />
                    <Columns>
                        <asp:CommandField ButtonType="Image" 
                            SelectImageUrl="~/images/icons/modify.gif" ShowSelectButton="True">
                        </asp:CommandField>
                        <asp:BoundField DataField="eCID" Visible="False"></asp:BoundField>
                        <asp:BoundField DataField="cBrand" HeaderText="Brand"></asp:BoundField>
                        <asp:BoundField DataField="cCapacity" HeaderText="Capacity"></asp:BoundField>
                        <asp:BoundField DataField="qty" HeaderText="Qty"></asp:BoundField>
                        <asp:BoundField DataField="dpurchased" HeaderText="Date Purchased">
                        </asp:BoundField>
                        <asp:BoundField DataField="factors" HeaderText="Factors Affecting Sell Out"></asp:BoundField>
                        <asp:BoundField DataField="upStat" HeaderText="Upload Status"></asp:BoundField>
                        <asp:BoundField DataField="uploadDate" HeaderText="Upload Date">
                        </asp:BoundField>
                    </Columns>
                    <EditRowStyle CssClass="EditRowStyle" />
                    <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                    <SelectedRowStyle Font-Bold="True" />
                </asp:GridView>

                
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="sqlDS_CUpload" runat="server" 
        ConnectionString="<%$ ConnectionStrings:conString %>" 
        
        SelectCommand="SELECT * FROM [tbl_CExcelUpload] 
                        WHERE (userID = @userID AND [uploadDate] = @uploadDate)">
        <SelectParameters>
            <asp:SessionParameter Name="userID" SessionField="userID" Type="Int64"  />
            <asp:SessionParameter Name="uploadDate" SessionField="uploadDate" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    </div>
</asp:Panel>


<%--stocks--%>
<asp:Panel ID="panStocks" runat="server">
<div style="text-align:left; padding-left:25px;">
    <table width="100%">
       
        <tr>
        <td colspan="8">

<!-- panStocks -->
<div>
<asp:Panel ID="panSData" runat="server" Visible="False">
<table width="100%">
<tr>
<td align="left" valign="top">Product:</td>
<td align="left">
    <asp:Label ID="lblSProd" runat="server" Width="400px"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlSProd" runat="server" Width="400px" AutoPostBack="True">
    </asp:DropDownList>
</td>
</tr>

<tr>
<td align="left" valign="top">Brand:</td>
<td align="left">
    <asp:Label ID="lblSBrand" runat="server" Width="400px"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlSBrand" runat="server" Width="400px" 
        AutoPostBack="True">
    </asp:DropDownList>
</td>
</tr>

<tr>
<td align="left" valign="top">Short Code:</td>
<td align="left">
    <asp:Label ID="lblSSCode" runat="server" Width="400px"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlSSCode" runat="server" Width="400px">
    </asp:DropDownList>
</td>
</tr>

<tr>
<td align="left" valign="top">Date Runs Out:</td>
<td align="left">
    <asp:Label ID="lblSDP" runat="server" Width="400px"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlSDP" runat="server" Width="400px">
    </asp:DropDownList>
</td>
</tr>

<tr>
<td align="left" valign="top">Action Taken:</td>
<td align="left">
    <asp:Label ID="lblAction" runat="server" Width="400px"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlAction" runat="server" Width="400px" 
        AutoPostBack="True">
    </asp:DropDownList><br />
    <asp:Panel ID="panOthers" runat="server" visible="false">
    <asp:Textbox ID="txtOthers" runat="server" Width="400px" Visible="False"></asp:Textbox>
    </asp:Panel>
</td>
</tr>

<tr>
<td align="left" valign="top">Competitor Promo Activities:</td>
<td align="left">
    <asp:Textbox ID="txtPromo" runat="server" Width="400px" textmode="multiline"></asp:Textbox>
</td>
</tr>

 
    <tr>
        <td align="left" valign="top">
            Status:</td>
        <td align="left">
            <asp:Label ID="lblSStatus" runat="server" Width="400px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="left" valign="top">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
    </tr>

 
 <tr>
        <td align="left" colspan="2">
            <asp:Button ID="btnSModify" runat="server" Text="Update" />
            <asp:Button ID="btnSCancel" runat="server" Text="Cancel" />
        </td>
    </tr>
    <tr>
        <td align="left" colspan="2">
            &nbsp;</td>
    </tr>
</table>
</asp:Panel>
</div>

                <asp:GridView ID="grdSUpload" runat="server" 
                    CssClass="gridRow" PageSize="30" ShowFooter="True" Width="95%" 
                    AutoGenerateColumns="False" DataKeyNames="eSID,upStat,uploadDate" 
                    DataSourceID="sqlDS_SUpload">
                    <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
                    <RowStyle CssClass="RowStyle" />
                    <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
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
                    <HeaderStyle CssClass="HeaderStyle" />
                    <Columns>
                        <asp:CommandField ButtonType="Image" 
                            SelectImageUrl="~/images/icons/modify.gif" ShowSelectButton="True">
                        </asp:CommandField>
                        <asp:BoundField DataField="eSID" Visible="False"></asp:BoundField>
                        <asp:BoundField DataField="product" HeaderText="Product"></asp:BoundField>
                        <asp:BoundField DataField="brand" HeaderText="Brand"></asp:BoundField>
                        <asp:BoundField DataField="sCode" HeaderText="Short Code"></asp:BoundField>
                        <asp:BoundField DataField="dOut" HeaderText="Date Runs Out">
                        </asp:BoundField>
                        <asp:BoundField DataField="actTaken" HeaderText="Action Taken"></asp:BoundField>
                        <asp:BoundField DataField="promo" HeaderText="Competitor Promo Activities"></asp:BoundField>
                        <asp:BoundField DataField="upStat" HeaderText="Upload Status"></asp:BoundField>
                        <asp:BoundField DataField="uploadDate" HeaderText="Upload Date">
                        </asp:BoundField>
                    </Columns>
                    <EditRowStyle CssClass="EditRowStyle" />
                    <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                    <SelectedRowStyle Font-Bold="True" />
                </asp:GridView>

                
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="sqlDS_SUpload" runat="server" 
        ConnectionString="<%$ ConnectionStrings:conString %>" 
        
        SelectCommand="SELECT * FROM [vw_StocksUpload] 
                        WHERE (userID = @userID AND [uploadDate] = @uploadDate)">
        <SelectParameters>
            <asp:SessionParameter Name="userID" SessionField="userID" Type="Int64"  />
            <asp:SessionParameter Name="uploadDate" SessionField="uploadDate" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    </div>
</asp:Panel>



<%--inventory--%>
<asp:Panel ID="panInventory" runat="server">
<div style="text-align:left; padding-left:25px;">
    <table width="100%">
       
        <tr>
        <td colspan="8">

<!-- panInventory -->
<div>
<asp:Panel ID="panIData" runat="server" Visible="False">
<table width="100%">

<tr>
<td align="left" valign="top">Product:</td>
<td align="left">
    <asp:Label ID="lblIProd" runat="server" Width="400px"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlIProd" runat="server" Width="400px" AutoPostBack="True">
    </asp:DropDownList>
</td>
</tr>

<tr>
<td align="left" valign="top">Brand:</td>
<td align="left">
    <asp:Label ID="lblIBrand" runat="server" Width="400px"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlIBrand" runat="server" Width="400px" 
        AutoPostBack="True">
    </asp:DropDownList>
</td>
</tr>

<tr>
<td align="left" valign="top">Short Code:</td>
<td align="left">
    <asp:Label ID="lblISCode" runat="server" Width="400px"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlISCode" runat="server" Width="400px">
    </asp:DropDownList>
</td>
</tr>

<tr>
<td align="left" valign="top">Qty:</td>
<td align="left">
    <asp:Label ID="lblIQty" runat="server" Width="400px"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlIQty" runat="server" Width="400px">
        <asp:ListItem>Select the Quantity</asp:ListItem>
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>6</asp:ListItem>
        <asp:ListItem>7</asp:ListItem>
        <asp:ListItem>8</asp:ListItem>
        <asp:ListItem>9</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>11</asp:ListItem>
        <asp:ListItem>12</asp:ListItem>
        <asp:ListItem>13</asp:ListItem>
        <asp:ListItem>14</asp:ListItem>
        <asp:ListItem>15</asp:ListItem>
        <asp:ListItem>16</asp:ListItem>
        <asp:ListItem>17</asp:ListItem>
        <asp:ListItem>18</asp:ListItem>
        <asp:ListItem>19</asp:ListItem>
        <asp:ListItem>20</asp:ListItem>
    </asp:DropDownList>
</td>
</tr>

<tr>
<td align="left" valign="top">Comments & Suggestions:</td>
<td align="left">
    <asp:Textbox ID="txtComments" runat="server" Width="400px" textmode="multiline"></asp:Textbox>
</td>
</tr>

<tr>
<td align="left" valign="top">
    Status:</td>
<td align="left">
    <asp:Label ID="lblIStatus" runat="server" Width="400px"></asp:Label>
</td>
</tr>
    <tr>
        <td align="left" valign="top">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
    </tr>

 
 <tr>
        <td align="left" colspan="2">
            <asp:Button ID="btnIModify" runat="server" Text="Update" />
            <asp:Button ID="btnICancel" runat="server" Text="Cancel" />
        </td>
    </tr>
    <tr>
        <td align="left" colspan="2">
            &nbsp;</td>
    </tr>
</table>
</asp:Panel>
</div>

                <asp:GridView ID="grdIUpload" runat="server" 
                    CssClass="gridRow" PageSize="30" ShowFooter="True" Width="95%" 
                    AutoGenerateColumns="False" DataKeyNames="eIID,upStat,uploadDate" 
                    DataSourceID="sqlDS_IUpload">
                    <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
                    <RowStyle CssClass="RowStyle" />
                    <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
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
                    <HeaderStyle CssClass="HeaderStyle" />
                    <Columns>
                        <asp:CommandField ButtonType="Image" 
                            SelectImageUrl="~/images/icons/modify.gif" ShowSelectButton="True">
                        </asp:CommandField>
                        <asp:BoundField DataField="eIID" Visible="False"></asp:BoundField>
                        <asp:BoundField DataField="product" HeaderText="Product"></asp:BoundField>
                        <asp:BoundField DataField="brand" HeaderText="Brand"></asp:BoundField>
                        <asp:BoundField DataField="sCode" HeaderText="Short Code"></asp:BoundField>
                        <asp:BoundField DataField="qty" HeaderText="Qty"></asp:BoundField>
                        <asp:BoundField DataField="comments" HeaderText="Comments & Suggestions">
                        </asp:BoundField>
                        <asp:BoundField DataField="upStat" HeaderText="Upload Status"></asp:BoundField>
                        <asp:BoundField DataField="uploadDate" HeaderText="Upload Date">
                        </asp:BoundField>
                    </Columns>
                    <EditRowStyle CssClass="EditRowStyle" />
                    <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                    <SelectedRowStyle Font-Bold="True" />
                </asp:GridView>

                
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="sqlDS_IUpload" runat="server" 
        ConnectionString="<%$ ConnectionStrings:conString %>" 
        
        SelectCommand="SELECT * FROM [tbl_IExcelUpload] 
                        WHERE (userID = @userID AND [uploadDate] = @uploadDate)">
        <SelectParameters>
            <asp:SessionParameter Name="userID" SessionField="userID" Type="Int64"  />
            <asp:SessionParameter Name="uploadDate" SessionField="uploadDate" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    </div>
</asp:Panel>
</DIV>


</ContentTemplate>
</asp:UpdatePanel>
</div>
</center>

</asp:Content>
