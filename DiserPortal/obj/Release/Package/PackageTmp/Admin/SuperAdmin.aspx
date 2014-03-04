<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
CodeBehind="SuperAdmin.aspx.vb" Inherits="DiserPortal.SuperAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="dataWrapper">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:UpdatePanel ID="updTM" runat="server">
<ContentTemplate>

<div id="cont_wrap">


<asp:Panel ID="panMain" runat="server">
<table>
<tr>
<td colspan="4">
    &nbsp;</td>
</tr>
    <tr>
        <td>
            &nbsp;</td>
        <td colspan="3">
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            FREESTYLE&nbsp;</td>
        <td colspan="3">
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Type Here:</td>
        <td colspan="3">
            <asp:TextBox ID="txtQry" runat="server" Height="90px" 
                style="margin-bottom: 0px" TextMode="MultiLine" Width="500px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Table Name:</td>
        <td colspan="3">
            <asp:TextBox ID="txtTblName" runat="server" Width="500px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td valign="top">
            SQL Select<br />
            <asp:Button ID="btnGo" runat="server" Text="Populate Table" />
        </td>
        <td colspan="3" valign="top">
            <asp:TextBox ID="txtSQL" runat="server" Height="60px" 
                style="margin-bottom: 0px" TextMode="MultiLine" Width="500px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="center" colspan="4">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center" colspan="4">
            <asp:Label ID="lbleMsg" runat="server" ForeColor="red" text=""></asp:Label>
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
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="4">
            <asp:GridView ID="grdResult" runat="server" DataSourceID="sqlDS">
            </asp:GridView>
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
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="4">
            <asp:Panel ID="panWeek" runat="server">
                <table>
                <tr>
                <td><strong>DELETE DATA</strong></td>
                <td>
                    <asp:Button ID="btnDelete" runat="server" Text="DELETE" />
                    </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                </tr>

                <tr>
                <td>Table Name:</td>
                <td><asp:TextBox ID="txtDTable" runat="server"></asp:TextBox></td>
                <td>Where:</td>
                <td><asp:TextBox ID="txtDWhere" runat="server" TextMode="MultiLine" Width="400px"></asp:TextBox></td>
                </tr>

                <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                </tr>

                    <tr>
                        <td>
                            <strong>SET ID = 1</strong></td>
                        <td>
                            <asp:Button ID="btnSet" runat="server" Text="SET TO 1" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            Table Name:</td>
                        <td>
                            <asp:TextBox ID="txtSTable" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
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
                            <strong>ADD FLD ON TABLE</strong></td>
                        <td>
                            <asp:Button ID="btnAlter" runat="server" Text="ALTER TABLE" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            Table Name:</td>
                        <td>
                            <asp:TextBox ID="txtATable" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            Field Name:</td>
                        <td>
                            <asp:TextBox ID="txtFld" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            Data Type:</td>
                        <td>
                            <asp:TextBox ID="txtDType" runat="server"></asp:TextBox>
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
                        <td>
                            <strong>DROP VIEW</strong></td>
                        <td>
                            <asp:Button ID="btnDrop" runat="server" Text="DROP VIEW" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            View Name:</td>
                        <td>
                            <asp:TextBox ID="txtDView" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
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
                            <strong>CREATE VIEW</strong></td>
                        <td>
                            <asp:Button ID="btnCView" runat="server" Text="CREATE VIEW" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td valign="top">
                            View Name:</td>
                        <td valign="top">
                            <asp:TextBox ID="txtCView" runat="server"></asp:TextBox>
                        </td>
                        <td valign="top">
                            SQL Code:</td>
                        <td>
                            <asp:TextBox ID="txtView" runat="server" Height="90px" Rows="10" 
                                TextMode="MultiLine" Width="400px"></asp:TextBox>
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
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <strong>ENCRYPT/DECRYPT</strong></td>
                        <td>
                            <asp:Button ID="btnED" runat="server" Text="Encrypt/Decrypt" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            Item to Encrypt:</td>
                        <td>
                            <asp:TextBox ID="txtIE" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            Result:</td>
                        <td>
                            <asp:TextBox ID="txtIER" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Item to Decrypt:</td>
                        <td>
                            <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            Result:</td>
                        <td>
                            <asp:TextBox ID="txtIDR" runat="server"></asp:TextBox>
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
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
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
                            SPECIAL RUNS</td>
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
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>

                <tr>
                <td colspan="4">
                    <asp:Button ID="btnWeek" runat="server" Text="Update Week Table" />
                    <asp:Button ID="btnUpdUname" runat="server" Text="Update Uname" />
                    <asp:Button ID="btnUpdPwd" runat="server" Text="Update Pwd" />
                    <asp:Button ID="btnUpdPB" runat="server" Text="Update Excel Prod &amp; Brand" />
                    <asp:Button ID="btnUpdCap" runat="server" Text="Update Capacity" />
                    <br />
                    </td>
                </tr>

                <tr>
                <td colspan="4">
                    <asp:Button ID="btnUpdTCap" runat="server" Text="Update tbl_Capacity" />
                    <asp:Button ID="btnUpdStore" runat="server" 
                        Text="Update tbl_Store - Location " />
                    <asp:Button ID="btnUpdUserStore" runat="server" 
                        Text="Update tbl_User - Store" />
                    </td>
                </tr>
                </table>
            </asp:Panel>
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
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="4" style="font-weight: 700">
            <asp:Button ID="btnUpMann" runat="server" Text="Update Dealer on Manning" />
            <asp:Button ID="btnUpMLoc" runat="server" Text="Update Location on Manning" />
            <asp:Button ID="btnUpMID" runat="server" Text="Update userid on Manning" />
            <asp:Button ID="btnUpMRegion" runat="server" Text="Update region on manning" />
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
            &nbsp;</td>
    </tr>
    <asp:SqlDataSource ID="sqlDS" runat="server" ConnectionString="<%$ ConnectionStrings:conString %>"
                        SelectCommand=""></asp:SqlDataSource>
                <asp:SqlDataSource ID="sqlDS_Week" runat="server" ConnectionString="<%$ ConnectionStrings:conString %>"
                        SelectCommand="SELECT * FROM tbl_Week"></asp:SqlDataSource>
</table>
</asp:Panel>

</div>

</ContentTemplate>
</asp:UpdatePanel>



</div>

<div>

<asp:Panel ID="panFUP" runat="server">
<table>
<tr>
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
                            <strong>UPLOAD CAPACITY</strong></td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:FileUpload ID="fupUpCap" runat="server" />
                        </td>
                        <td>
                            <asp:Button ID="btnUpCap" runat="server" Text="Upload Capacity" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
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
                            <strong>UPLOAD ITEMS</strong></td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:FileUpload ID="fupUpItems" runat="server" />
                        </td>
                        <td>
                            <asp:Button ID="btnUpItems" runat="server" Text="Upload Items" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
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
            <strong>UPLOAD DEALER</strong></td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:FileUpload ID="fupUpDealer" runat="server" />
        </td>
        <td>
            <asp:Button ID="btnUpDealer" runat="server" Text="Upload Dealer" />
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
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
            <strong>UPLOAD LOCATION</strong></td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:FileUpload ID="fupUpLoc" runat="server" />
        </td>
        <td>
            <asp:Button ID="btnUpLoc" runat="server" Text="Upload Location" />
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
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
        <td style="font-weight: 700">
            UPLOAD STORE</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="font-weight: 700">
            <asp:FileUpload ID="fupUpStore" runat="server" />
        </td>
        <td>
            <asp:Button ID="btnUpStore" runat="server" Text="Upload Store" />
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Panel>

</div>


</asp:Content>
