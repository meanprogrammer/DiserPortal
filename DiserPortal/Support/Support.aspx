<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
CodeBehind="Support.aspx.vb" Inherits="DiserPortal.Support" %>

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
            <asp:LinkButton id="lnkSubmit" runat="server" CssClass="tabprop-Selected" Text="Submit a<br/>Support Ticket"></asp:LinkButton> </LI>
        <LI><br /><asp:LinkButton id="lnkMyTicket" runat="server" CssClass="tabprop" 
                Text="My Support<br/>Tickets"></asp:LinkButton></LI>
        <UL>
</DIV>
</DIV>
<!-- end tab wrap -->

<%--<DIV style="CLEAR: both">
</DIV>--%>

<DIV id="cont_wrap">
<br />
<asp:Label ID="lbleMsg" runat="server" ForeColor="red" text=""></asp:Label>

<%--SUBMIT A SUPPORT TICKET--%>
<asp:Panel ID="panSubmit" runat="server">
<div style="text-align:left; padding-left:25px;">
    <table>
    <tr>
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
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    </tr>

        <tr>
            <td class="style1" colspan="8">
                <h2>
                    Submit a Support Ticket</h2>
            </td>
            <td class="style1">
            </td>
            <td class="style1">
            </td>
            <td class="style1">
            </td>
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
    <td style="height:30px;">
        &nbsp;</td>
    <td style="height:30px;">
        &nbsp;</td>
    <td style="height:30px;">
        &nbsp;</td>
    </tr>

    <tr>
    <td colspan="2" align="left"><strong>Subject:</strong></td>
    <td colspan="9">
        <asp:DropDownList ID="ddlSubj" runat="server" Width="450px" 
            AutoPostBack="True">
        </asp:DropDownList>
        </td>
    </tr>

    <tr>
    <td width="150px">&nbsp;</td>
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
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    </tr>

    <tr>
    <td align="left" valign="top"><strong>Comments:</strong></td>
    <td>
        &nbsp;</td>
    <td colspan="6">
        <asp:TextBox ID="txtComments" runat="server" Rows="20" TextMode="MultiLine" 
            Width="445px"></asp:TextBox>
        </td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    </tr>

        <tr>
            <td align="left" valign="top">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td colspan="6">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" />
            </td>
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
            <td width="50px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td width="75px">
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
            <td width="50px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td width="75px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table><br /><br />
    </div>
</asp:Panel>


<%--SUBMIT A SUPPORT TICKET--%>
<asp:Panel ID="panMyTicket" runat="server" visible="false">
<div style="text-align:left; padding-left:25px;">
    <table width="100%">
    <tr>
    <td colspan="2">
        &nbsp;</td>
    </tr>

        <tr>
            <td colspan="2">
                <h2>
                    My Support Tickets</h2>
            </td>
        </tr>

    <tr>
    <td style="height:30px;" colspan="2">
    </td>
        </tr>

    <tr>
    <td colspan="2" style="height: 30px;">
        <%--<asp:DropDownList ID="ddlSubj" runat="server" Width="450px" 
            AutoPostBack="True">
        </asp:DropDownList>--%>
        <asp:Panel ID="panSDetails" runat="server" visible="False" width="100%">
            <table width="100%">
            <tr>
            <td>Ticket No.:</td>
            <td>
                <asp:Label ID="lblTNo" runat="server"></asp:Label>
            </td>
            </tr>

            <tr>
            <td width="250px">Date Created:</td>
            <td>
                <asp:Label ID="lblDCreated" runat="server"></asp:Label>
            </td>
            </tr>

                <tr>
                    <td width="250px">
                        &nbsp;</td>
                    <td height="25px">
                        &nbsp;</td>
                </tr>

            <tr>
            <td>Subject:</td>
            <td>
            <asp:Label runat="server" ID="lblSubj" Width="600px"></asp:Label>
            </td>
            </tr>

            <tr>
            <td>Comment:</td>
            <td>
            <asp:Label runat="server" ID="lblComment" Width="600px"></asp:Label>
            </td>
            </tr>

                <tr>
                    <td>
                        Status:</td>
                    <td>
                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td height="30px">
                        &nbsp;</td>
                </tr>


                <tr>
<td align="left" colspan="2">
<asp:Panel ID="panReply" runat="server" Width="100%" visible="false">
<table width="100%">
<tr>
            <td align="left" valign="top" width="250px">
                <strong>Type your reply here:</strong></td>
            <td align="left">
                <asp:TextBox ID="txtReply" runat="server" Rows="10" TextMode="MultiLine" 
                    Width="400px"></asp:TextBox>
            </td>
        </tr>

<tr>
<td>&nbsp;</td>
<td align="left">
    <asp:RadioButtonList ID="rblSStat" runat="server" 
        RepeatDirection="Horizontal">
        <asp:ListItem Selected="True" Value="1">Open</asp:ListItem>
        <asp:ListItem Value="2">Resolved</asp:ListItem>
    </asp:RadioButtonList>
    </td>
</tr>

        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="lbleMsg4" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        
</table>
</asp:Panel>
</td>
</tr>
        
        <tr>
            <td>
            </td>
            <td align="right" style="padding-right:30px;">
                <asp:Button ID="btnSubmit1" runat="server" Text="Post a Reply" />
                <asp:Button ID="btnAllSupport" runat="server" Text="Show All Tickets" />
            </td>
        </tr>

        <tr>
        <td style="height:20px;" colspan="2"></td>
        </tr>
                <tr>
                    <td align="left" colspan="2">
                        <asp:GridView ID="grdSTrans" runat="server" AutoGenerateColumns="False" 
                            BorderColor="Black" CssClass="gridRow" DataKeyNames="supportTransID,supportID" 
                            DataSourceID="sqlDS_STrans" PageSize="20" ShowFooter="True" Width="95%">
                            <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
                            <RowStyle CssClass="RowStyle" />
                            <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/icons/view.png" 
                                    ShowSelectButton="True" Visible="False"></asp:CommandField>
                                <asp:BoundField DataField="supportTransID" HeaderText="Trans ID" 
                                    Visible="False"></asp:BoundField>
                                <asp:TemplateField HeaderText="Reply">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("reply") %>' 
                                            Width="500px"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("reply") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Replied By">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("repliedBy") %>' width="275px"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("repliedBy") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date Replied">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("dateReplied") %>' width="200px"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("dateReplied") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("supportStatus") %>' width="70px"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("supportStatus") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="supportTransID" HeaderText="Trans ID" 
                                    InsertVisible="False" ReadOnly="True">
                                    <controlstyle cssclass="hiddencol" />
                                    <controlstyle cssclass="hiddencol" />
                                    <controlstyle cssclass="hiddencol" />
                                    <controlstyle cssclass="hiddencol" />
                                    <controlstyle cssclass="hiddencol" />
                                    <controlstyle cssclass="hiddencol" />
                                    <controlstyle cssclass="hiddencol" />
                                    <controlstyle cssclass="hiddencol" />
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
                                                <asp:ImageButton ID="imbFirst0" runat="server" AlternateText="First Page" 
                                                    CommandArgument="First" CommandName="Page" 
                                                    ImageUrl="~/images/icons/first.gif" />
                                                <asp:ImageButton ID="imbPrev0" runat="server" AlternateText="Previous Page" 
                                                    CommandArgument="Prev" CommandName="Page" ImageUrl="~/images/icons/prev.gif" />
                                            </td>
                                            <td>
                                                Page&nbsp;&nbsp;<asp:DropDownList ID="ddlPageNo0" runat="server" AutoPostBack="true" 
                                                    Width="50px">
                                                </asp:DropDownList>
                                                &nbsp;of&nbsp;
                                                <asp:Label ID="lblPageCount0" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="imbNext0" runat="server" AlternateText="Next Page" 
                                                    CommandArgument="Next" CommandName="Page" ImageUrl="~/images/icons/next.gif" />
                                                <asp:ImageButton ID="imbLast0" runat="server" AlternateText="Last Page" 
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
                            <SelectedRowStyle BackColor="#6699FF" Font-Bold="True" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        </td>
    </tr>

    <tr>
    <td colspan="2">
        <%--<asp:DropDownList ID="ddlSubj" runat="server" Width="450px" 
            AutoPostBack="True">
        </asp:DropDownList>--%>
            <asp:Panel ID="panSupport" runat="server" width="100%">
            <table style="width:100%"><tr><td>
            <asp:GridView ID="grdSupport" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" BorderColor="Black" CssClass="gridRow" 
                DataKeyNames="supportID" DataSourceID="sqlDS_Support" PageSize="20" 
                ShowFooter="True" Width="95%">
                <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
                <RowStyle CssClass="RowStyle" />
                <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
                <Columns>
                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/icons/view.png" 
                        ShowSelectButton="True"></asp:CommandField>
                    <asp:BoundField DataField="supportID" HeaderText="Support ID">
                    </asp:BoundField>
                    <asp:BoundField DataField="subject" HeaderText="Subject"></asp:BoundField>
                    <asp:BoundField DataField="trimmedComment" HeaderText="Comments"></asp:BoundField>
                    <asp:BoundField DataField="dateSubmitted" HeaderText="Date Created">
                    </asp:BoundField>
                    <asp:BoundField DataField="supportStatus" HeaderText="Status"></asp:BoundField>
                    <asp:BoundField DataField="supportID" HeaderText="support" 
                        InsertVisible="False" ReadOnly="True">
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
                        <controlstyle cssclass="hiddencol" />
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
                <SelectedRowStyle BackColor="#6699FF" Font-Bold="True" />
            </asp:GridView>
            </td></tr></table>
            </asp:Panel>

        </td>
    </tr>

        <tr>
            <td colspan="2">
                &nbsp;</td>
            </tr>

    </table><br />
    <asp:SqlDataSource ID="sqlDS_Support" runat="server" 
        ConnectionString="<%$ ConnectionStrings:conString %>" SelectCommand="SELECT *
                FROM vw_Support
                WHERE userID = @userID 
                ORDER BY supportID DESC"
                >
    <SelectParameters>
                <asp:SessionParameter Name="userID" 
                    SessionField="userID" Type="Int64"  />
            </SelectParameters>            
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sqlDS_STrans" runat="server" 
        ConnectionString="<%$ ConnectionStrings:conString %>" SelectCommand="SELECT *
                FROM vw_SupportTrans
                WHERE supportID = @supportID 
                ORDER BY supportTransID DESC"
                >
    <SelectParameters>
        <asp:SessionParameter Name="supportID" 
            SessionField="supportID" Type="Int64"  />
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
