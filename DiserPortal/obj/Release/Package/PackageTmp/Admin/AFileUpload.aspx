<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
CodeBehind="AFileUpload.aspx.vb" Inherits="DiserPortal.AFileUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<center>
<div class="dataWrapper">

<CENTER>
<TABLE id="tbl1" class="main" cellSpacing="0" 
    cellPadding="0" width="887" border="0">
<TBODY>

<TR>
<TD class="tr_space"></TD>
</TR>

<TR>
<TD class="tr_space"></TD>
</TR>

<TR>
<TD class="title">
    <H2>File Uploader</H2>
</TD>
</TR>

<TR>
<TD class="tr_space">
    <asp:Label id="lbleMsg" runat="server" 
        CssClass="errMsg1" ToolTip=".: Required Field :."></asp:Label> 
</TD>
</TR>

<TR>
<TD class="tr_space"></TD>
</TR>

<TR>
<TD class="tr_space" vAlign="middle" align="center">
    <asp:Panel runat="server" ID="panID">
        <asp:Image id="imgApp" runat="server" 
            ImageUrl="~/images/appPics/user.png">
        </asp:Image> 
        <asp:ImageButton id="imbPicRemove" runat="server" 
            ImageUrl="~/images/icons/delete.png">
        </asp:ImageButton> 
        <p>&nbsp;</p>
        <p><asp:FileUpload id="fupPic" runat="server" 
            cssclass="fileUpload" width="400px">
        </asp:FileUpload> 
        <asp:ImageButton id="imbPicAdd" runat="server" 
            ImageUrl="~/images/icons/upload.png">
        </asp:ImageButton> 
        <asp:ImageButton id="imbExit" runat="server" 
            ImageUrl="~/images/icons/exit.png">
        </asp:ImageButton></p>
    </asp:Panel>
</TD>
</TR>

<TR>
<TD class="tr_space" vAlign="middle" align="center">
    <asp:UpdateProgress ID="PageUpdateProgress2" runat="server">
        <progresstemplate>
            <div style="width:100%">
                <div style="padding: 15px; vertical-align:middle;float:left;">
                    <asp:Image runat="server" Height="20px" ImageUrl="~/images/icons/loading.gif" />
                </div>
                <div style="padding:15px; text-align:right;vertical-align:middle;float:right;">
                    <asp:Image runat="server" Height="20px" ImageUrl="~/images/icons/loading.gif" />
                </div>
            </div>
        </progresstemplate>
    </asp:UpdateProgress>
</TD>
</TR>

<TR>
<TD class="tr_space"></TD>
</TR>

<tr>
<td class="tr_space">
    &nbsp;</td>
</tr>

</TBODY>
</TABLE>
</CENTER>

</div>
</center>

</asp:Content>
