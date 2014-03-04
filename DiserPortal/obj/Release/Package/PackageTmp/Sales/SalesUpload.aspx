<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
CodeBehind="SalesUpload.aspx.vb" Inherits="DiserPortal.SalesUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<center>
<asp:UpdatePanel ID="updTM" runat="server">
<ContentTemplate>
<div class="dataWrapper">
    <%--SALES--%>

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


        <div class="main">
            <div style="height:20px;"></div>
            <h2>
                File Download / Upload
            </h2>
            <div style="height:20px;"></div>
                                   
            <div>
                <span class="failureNotification">
                    <asp:Label runat="server" ID="lbleMsg" cssclass="failureNotification"></asp:Label>
                </span>
            </div>
            <div class="accountInfo" style="width:1000px;">
                <div style="float:left;">
                <p>
                <b>DOWNLOAD</b><br /><br />
                To download template, please select the form and click Download.
                </p>
                <fieldset class="login">
                    <p>
                        <asp:Label ID="Temp" runat="server" AssociatedControlID="ddlForm" Width="250px"
                            Font-Bold="True">File Download</asp:Label>
                    </p>
                    <p>
                        <asp:DropDownList ID="ddlForm" runat="server" Width="250px">
                            <asp:ListItem>Please select template to download</asp:ListItem>
                            <asp:ListItem Value="Sales">Product Registration</asp:ListItem>
                            <asp:ListItem Value="Compete">Competitor Sales</asp:ListItem>
                            <asp:ListItem Value="Stocks">Stocks Run Out</asp:ListItem>
                            <asp:ListItem Value="Inventory">Stocks Inventory</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="btnDload" runat="server" Text="Download" Width="100px" />
                    </p>
                </fieldset class="login">
                </div>
                <%--<p>&nbsp;</p>--%>
                <div style="float:right;">
                <p>
                    <b>UPLOAD</b><br /><br />
                    To upload file, click browse, select file and click Upload<br />
                    Only <b>xls</b> <i>(Excel 97-2003 Workbook)</i> file extension is accepted.<br />
                    Please use official template for upload.</p>
                <fieldset class="login">
                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="ddlWeek" 
                            Font-Bold="True">File Upload</asp:Label>
                    <p style="vertical-align: middle;">
                        Week Coverage&nbsp; :&nbsp;&nbsp; 
                        <asp:DropDownList id="ddlWeek" runat="server" AutoPostBack="True" Width="250px">
                        </asp:DropDownList>
                    </p>
                    <p>
                        <asp:DropDownList ID="ddlUForm" runat="server" Width="250px">
                            <asp:ListItem>Please select the form to upload</asp:ListItem>
                            <asp:ListItem Value="Sales">Product Registration</asp:ListItem>
                            <asp:ListItem Value="Compete">Competitor Sales</asp:ListItem>
                            <asp:ListItem Value="Stocks">Stocks Run Out</asp:ListItem>
                            <asp:ListItem Value="Inventory">Stocks Inventory</asp:ListItem>
                        </asp:DropDownList>
                    </p>
                    <p>
                       <asp:FileUpload ID="fupUpload" runat="server" Width="250px" Enabled="False" />
                    </p>
                    <p>
                        <asp:Button ID="btnUpload" runat="server" Text="Upload" Width="100px" 
                                    Enabled="False" />
                    </p>
                </fieldset>
                </div>
            </div>
        </div>

<!-- end tab wrap -->

<DIV style="CLEAR: both"></DIV>

</DIV>



<%--</ContentTemplate>
</asp:UpdatePanel>--%>
</div>
</ContentTemplate>
    <triggers>
        <asp:PostBackTrigger ControlID="btnUpload" />
        <asp:PostBackTrigger ControlID="btnDLoad" />
    </triggers>
</asp:UpdatePanel>
</center>

</asp:Content>
