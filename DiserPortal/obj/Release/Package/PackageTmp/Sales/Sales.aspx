<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
CodeBehind="Sales.aspx.vb" Inherits="DiserPortal.Sales" %>

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
                Text="Product<br />Registration<br />" 
                OnClick="lnkProd_Click"></asp:LinkButton> </LI>
        <LI id="lCompete" runat="server"><br /><asp:LinkButton id="lnkCompete" onclick="lnkCompete_Click" runat="server" 
                CssClass="tabprop-selected" 
                Text="Competitor<br />Sales<br />"></asp:LinkButton></LI>
        <LI id="lStocks" runat="server"><br />
            <asp:LinkButton ID="lnkStocks" runat="server" CssClass="tabprop-selected" OnClick="lnkStocks_Click"
                Text="Stocks<br />Run Out<br />"></asp:LinkButton></LI>
        <LI id="lInventory" runat="server"><br />
            <asp:LinkButton ID="lnkInventory" runat="server" CssClass="tabprop-selected" OnClick="lnkInventory_Click"
                Text="Stocks<br />Inventory<br />"></asp:LinkButton><A href="#"></A></LI>
    </UL>
                
    <DIV style="FLOAT: right">
    </DIV>
</DIV>
<!-- end tab wrap -->

<DIV style="CLEAR: both"></DIV>

<DIV id="cont_wrap">

<!-- START PLACING CONTENT HERE -->
<DIV style="HEIGHT: 30px">
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
    </asp:UpdateProgress>--%>
    </DIV>

<DIV style="PADDING-LEFT: 15px; FLOAT: left; text-align:left; width:100%; height:30px;">
    Week Coverage:&nbsp; 
    <asp:DropDownList id="ddlWeek" runat="server" AutoPostBack="True">
    </asp:DropDownList>
    &nbsp;&nbsp; 
    <asp:Button id="btnCreate" onclick="btnCreate_Click" runat="server" Text="Create Report"></asp:Button>
                                                                                                                                                                            
    <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
        Text="Submit Report" />
    <asp:Button ID="btnUpload" runat="server" 
        Text="Upload File" />
    &nbsp; &nbsp;&nbsp; <asp:Label id="lbleMsg" runat="server" ForeColor="red" text=""></asp:Label>
    &nbsp;&nbsp;&nbsp; 
    <asp:ImageButton id="imbYes" onclick="imbYes_Click" runat="server" visible="false" 
        ImageUrl="~/images/icons/yes.png" Height="16px"></asp:ImageButton>&nbsp;
    <asp:ImageButton id="imbNo" onclick="imbNo_Click" runat="server" 
        visible="false" ImageUrl="~/images/icons/no.png"></asp:ImageButton><BR />
</DIV>
<BR /><BR />

<!-- INFO -->
<asp:Panel ID="panInfo" runat="server" visible="false" 
    style="height:250px; overflow-y:scroll; overflow-x:none;width:80%; border:2px solid black;" >

<p>
<table width="95%">
<tr>
<td align="left" style="font-weight: bold; font-size: 14px; vertical-align:middle;">
    <div>
    <div style="float:left;vertical-align:middle;">
        PRODUCT:&nbsp;&nbsp;
        <asp:Label ID="lblifProd" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; BRAND:&nbsp;&nbsp;
        <asp:Label ID="lblifBrand" runat="server"></asp:Label>
    </div>
    <div style="float:right;vertical-align:middle;">
        <asp:ImageButton ID="imbClose" runat="server" Height="16px" 
            ImageUrl="~/images/icons/cancel.gif" ></asp:ImageButton>
    </div>
    </div>
    </td>
</tr>

<tr><td></td>
    </tr>

</table>
</p>

<div>
    <asp:GridView ID="grdInfo" runat="server" 
        AutoGenerateColumns="False"
        CssClass="gridRow" DataKeyNames="itemID" DataSourceID="sqlDS_Info" 
        ShowFooter="True" Width="95%">
        <FooterStyle BackColor="#312515" Font-Size="12px" />
        <HeaderStyle BackColor="#312515" Font-Bold="True" Font-Size="14px" 
            ForeColor="White" />
        <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
        <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
        <AlternatingRowStyle BackColor="#F8DCB1" Font-Size="12px" ForeColor="Black" />
        <Columns>
            <asp:BoundField DataField="itemID" HeaderText="" Visible="False">
            </asp:BoundField>
            <asp:BoundField DataField="shortCode" HeaderText="Short Code"></asp:BoundField>
            <asp:BoundField DataField="longCode" HeaderText="Long Code"></asp:BoundField>
            <asp:BoundField DataField="itemDesc" HeaderText="Item Description"></asp:BoundField>
            <asp:BoundField DataField="capacity" HeaderText="Capacity"></asp:BoundField>
            <asp:BoundField DataField="variant" HeaderText="Variant"></asp:BoundField>
            <asp:BoundField DataField="itemID" InsertVisible="False" ReadOnly="True">
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
        <EditRowStyle CssClass="EditRowStyle" />
        <RowStyle BackColor="#FBEC99" Font-Size="12px" ForeColor="Black" />
    </asp:GridView>
</div>

</asp:Panel>

<!-- SALES -->
<asp:Panel id="panSales" runat="server"><BR />
    <asp:GridView id="grdSales" runat="server" CssClass="gridRow" Enabled="False" 
        AutoGenerateColumns="False" BorderColor="Black" DataKeyNames="salesID" 
        DataSourceID="sqlDS_Sales" PageSize="30" ShowFooter="True" AllowSorting="True" Width="100%">

    <Columns>
        <asp:BoundField DataField="salesID" HeaderText="ID" Visible="False"></asp:BoundField>
        
        <asp:TemplateField HeaderText="Customer" SortExpression="customer">
            <EditItemTemplate>
                <table>
                <tr>
                <td colspan="2"></td>
                </tr>

                <tr>
                <td style="height:30px;"></td>
                </tr>

                <tr>
                <td>
                    <asp:TextBox id="txteFname" runat="server" Text='<%# Bind("fname") %>' 
                        Width="70px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox id="txteLname" runat="server" Text='<%# Bind("lname") %>' 
                        Width="80px"></asp:TextBox>
                </td>
                </tr>

                <tr>
                <td align="center" style="font-size:8px;">First Name</td>
                <td align="center" style="font-size:8px;">Last Name</td>
                </tr>
                </table>
            </EditItemTemplate>
            <HeaderTemplate>
                <table>
                <tr>
                <td colspan="2" style="height:30px;">CUSTOMER</td>
                </tr>

                <tr>
                <td colspan="2" style="height:30px;"></td>
                </tr>
                
                <tr>
                <td style="height:30px;">
                    <asp:TextBox id="txtaFname" runat="server" Text='<%# Bind("fname") %>' 
                            Width="70px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox id="txtaLname" runat="server" Text='<%# Bind("lname") %>' 
                            Width="80px"></asp:TextBox>
                </td>
                </tr>

                <tr>
                <td align="center" style="font-size:8px;">First Name</td>
                <td align="center" style="font-size:8px;">Last Name</td>
                </tr>
                </table>
                <%--<DIV style="VERTICAL-ALIGN: top">CUSTOMER</DIV>
                <DIV style="HEIGHT: 15px"></DIV>
                <DIV style="HEIGHT: 15px"></DIV>
                <DIV style="VERTICAL-ALIGN: bottom; width: 160px;">
                    <div style="float:left;">
                        
                    </div>
                    <div style="float:right;">
                        
                    </div>
                    <div style="float:left; padding-left:17px; font-weight:normal; font-size:8px;">First Name</div>
                    <div style="float:right; padding-right:25px; font-weight:normal; font-size:8px;">Last Name</div>
                </DIV>--%>
            </HeaderTemplate>
            <ItemTemplate>
                <table>
                <tr>
                <td>
                    <asp:Label id="lbliCustomer" runat="server" Text='<%# Bind("cName") %>' Width="150px"></asp:Label> 

                </td></tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Address" SortExpression="cAddress">
            <EditItemTemplate>
                <table>
                <tr>
                <td colspan="2" style="height:30px;"><asp:Label id="lbleAdd" runat="server" Text='<%# Bind("cAddress") %>' width="145px"></asp:Label></td>
                </tr>

                <tr>
                <td>
                    <asp:TextBox id="txteAdd" runat="server" Text='<%# Bind("cAdd") %>' 
                            Width="145px"></asp:TextBox>
                </td>
                <td>
                    <asp:DropDownList ID="ddleCity" runat="server" width="145px"></asp:DropDownList>
                </td>
                </tr>

                <tr>
                <td align="center" style="font-size:8px;">#, Street, Brgy.</td>
                <td align="center" style="font-size:8px;">City</td>
                </tr>
                </table>
                <%--<DIV style="HEIGHT: 30px"></DIV>
                <DIV style="VERTICAL-ALIGN: bottom; width:300px; text-align:left;">
                    <div style="float:left; width:145px;">
                        
                    </div>
                    <div style="float:right; width:145px;">
                        
                    </div>
                    <div style="float:left; font-weight:normal; font-size:8px; "></div>
                    <div style="float:right; font-weight:normal; font-size:8px;"></div>
                </DIV>--%>
            </EditItemTemplate>
            <HeaderTemplate>
                <table>
                <tr>
                <td colspan="2" style="height:30px;">ADDRESS</td>
                </tr>

                <tr><td colspan="2" style="height:30px;"></td></tr>

                <tr>
                <td style="height:30px;">
                    <asp:TextBox id="txtaAdd" runat="server" Text='<%# Bind("cAdd") %>' 
                            Width="145px"></asp:TextBox>
                </td>
                <td>
                    <asp:DropDownList ID="ddlaCity" runat="server" width="145px"></asp:DropDownList>
                </td>
                </tr>

                <tr>
                <td align="center" style="font-size:8px;">#, Street, Brgy.</td>
                <td align="center" style="font-size:8px;">City</td>
                </tr>
                </table>
                <%--<DIV style="VERTICAL-ALIGN: top">ADDRESS</DIV>
                <DIV style="HEIGHT: 30px"></DIV>
                <DIV style="VERTICAL-ALIGN: bottom; width:300px; text-align:left;">
                    <div style="float:left; width:145px;">
                        
                    </div>
                    <div style="float:right; width:145px;">
                        
                    </div>
                    <div style="float:left; font-weight:normal; font-size:8px; "></div>
                    <div style="float:right; font-weight:normal; font-size:8px;"></div>
                </DIV>--%>
            </HeaderTemplate>
            <ItemTemplate>
                <table>
                <tr>
                <td colspan="2">
                    <asp:Label id="lbliAdd" runat="server" Text='<%# Bind("cAddress") %>' Width ="200px"></asp:Label> 
                </td>
                </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Contact Nos" SortExpression="contact">
            <EditItemTemplate>
                <table>
                <tr><td></td></tr>
                <tr><td style="height:30px;"></td></tr>
                <tr><td>
                    <asp:TextBox id="txtEContact" runat="server" Text='<%# Bind("contact") %>' 
                        Width="120px" AutoPostBack="True" ontextchanged="txtEContact_TextChanged"></asp:TextBox> 
                </td></tr> 
                </table>
                <%--<BR />
                <DIV style="HEIGHT: 30px"></DIV>--%>
            </EditItemTemplate>
            <HeaderTemplate>
                <table>
                <tr><td style="height:30px;">TEL NO</td></tr>
                <tr><td style="height:30px;"></td></tr>
                <tr><td style="height:30px;">
                    <asp:TextBox id="txtAContact" runat="server" Text='<%# Bind("contact") %>' 
                        Width="120px" AutoPostBack="True" ontextchanged="txtAContact_TextChanged"></asp:TextBox>
                </td></tr>
                <tr><td style="font-size:8px;">&nbsp;</td></tr>
                </table>
                <%--<DIV style="VERTICAL-ALIGN: top">CONTACT </DIV>
                <DIV style="HEIGHT: 30px">NUMBER </DIV>
                <DIV style="VERTICAL-ALIGN: bottom">
                    &nbsp;
                </DIV>
                <div></div>--%>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label id="lbliContact" runat="server" Text='<%# Bind("contact") %>' Width="120px"></asp:Label> 
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Qty" SortExpression="qty">
            <EditItemTemplate>
                <table>
                <tr>
                <td style="height:30px;">
                    &nbsp;</td>
                </tr>

                <tr><td style="height:30px;"></td></tr>

                <tr>
                <td style="height:30px;">
                <asp:TextBox ID="ddleQty" width="40px" Text='<%# Bind("qty") %>' runat="server" 
                        MaxLength="3"></asp:TextBox>
                </td>
                </tr>

                <tr><td style="font-size:8px;">&nbsp;</td></tr>
                </table>
                <%--<BR />
                <DIV style="HEIGHT: 30px"></DIV>--%>                 
            </EditItemTemplate>
            <HeaderTemplate>
                <table>
                <tr><td style="height:30px;">QTY</td></tr>
                <tr><td style="height:30px;"></td></tr>
                <tr>
                <td style="height:30px;">
                    <asp:TextBox ID="ddlAQty" width="40px" Text='<%# Bind("qty") %>' runat="server" 
                        MaxLength="3"></asp:TextBox>
                    </td>
                </tr>
                <tr><td style="font-size:8px;">&nbsp;</td></tr>
                </table>
                <%--<DIV style="VERTICAL-ALIGN: top"> </DIV>
                <DIV style="HEIGHT: 30px"></DIV>
                <DIV style="VERTICAL-ALIGN: bottom">&nbsp;
                </DIV>--%>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label id="lbliQty" runat="server" Text='<%# Bind("qty") %>' Width="60px"></asp:Label> 
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Product" SortExpression="product">
            <EditItemTemplate>
                <table>
                <tr>
                <td>
                    <asp:Label id="lbleProd" runat="server" Text='<%# Bind("product") %>' Width="150px"></asp:Label>
                </td>
                </tr>
                <tr><td style="height:30px;"></td></tr>
                <tr>
                <td>
                    <asp:DropDownList id="ddlEProd" runat="server" Width="150px" AutoPostBack="True" 
                    OnSelectedIndexChanged="ddlEProd_SelectedIndexChanged" DataTextField="product" 
                    DataValueField="productID"></asp:DropDownList>
                </td>
                </tr>
                <tr><td style="font-size:8px;"></td></tr>
                </table>
                <%--<BR />
                <DIV style="HEIGHT: 30px"></DIV>--%>                 
            </EditItemTemplate>
            <HeaderTemplate>
                <table>
                <tr><td style="height:30px;">PRODUCT</td></tr>
                <tr><td style="height:30px;"></td></tr>
                <tr>
                <td style="height:30px;">
                    <asp:DropDownList id="ddlAProd" runat="server" Width="150px" AutoPostBack="True" 
                    OnSelectedIndexChanged="ddlAProd_SelectedIndexChanged"></asp:DropDownList>
                </td>
                </tr>
                <tr><td style="font-size:8px;">&nbsp;</td></tr>
                </table>
                <%--<DIV style="VERTICAL-ALIGN: top"></DIV>
                <DIV style="HEIGHT: 30px"></DIV>
                <DIV style="VERTICAL-ALIGN: bottom">
                &nbsp;</DIV>--%>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label id="lbliProd" runat="server" Text='<%# Bind("product") %>' Width="150px"></asp:Label> 
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Brand" SortExpression="brand">
            <EditItemTemplate>
                <table>
                <tr>
                <td>
                    <asp:Label id="lbleBrand" runat="server" Text='<%# Bind("brand") %>' Width="120px"></asp:Label>
                </td>
                </tr>
                <tr><td style="height:30px;"></td></tr>
                <tr>
                <td>
                    <asp:DropDownList id="ddlEBrand" runat="server" Width="120px" 
                        AutoPostBack="True" OnSelectedIndexChanged="ddlEBrand_SelectedIndexChanged"></asp:DropDownList> 
                </td>
                </tr>
                <tr><td style="font-size:8px;">&nbsp;</td></tr>
                </table>
                <%--&nbsp;
                <DIV style="HEIGHT: 30px"></DIV>--%>                    
            </EditItemTemplate>
            <HeaderTemplate>
                <table>
                <tr><td style="height:30px;">BRAND</td></tr>
                <tr><td style="height:30px;"></td></tr>
                <tr><td style="height:30px;">
                    <asp:DropDownList id="ddlABrand" runat="server" Width="120px" AutoPostBack="True" 
                        OnSelectedIndexChanged="ddlABrand_SelectedIndexChanged"></asp:DropDownList>
                </td></tr>
                <tr><td style="font-size:8px;"></td></tr>
                </table>
                <%--<DIV style="VERTICAL-ALIGN: top"></DIV>
                <DIV style="HEIGHT: 30px"></DIV>
                <DIV style="VERTICAL-ALIGN: bottom">
                    &nbsp;</DIV>--%>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label id="lbliBrand" runat="server" Text='<%# Bind("brand") %>' Width="120px"></asp:Label> 
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Short Code" SortExpression="shortCode">
            <EditItemTemplate>
                <table>
                <tr>
                <td colspan="2">
                    <asp:Label id="lbleSCode" runat="server" Text='<%# Bind("shortCode") %>' 
                    Width="120px"></asp:Label>
                </td>
                </tr>
                <tr><td style="height:30px;"></td></tr>
                <tr>
                <td>
                    <asp:DropDownList id="ddleSCode" runat="server" Width="120px"></asp:DropDownList>
                </td>
                <td>
                    <asp:ImageButton ID="imbeRef" runat="server" 
                    AlternateText="Open Reference Table" Height="16px" 
                    ImageUrl="~/images/icons/search.gif" onclick="imbeRef_Click" 
                    ToolTip="Open Reference Table" ></asp:ImageButton>
                </td>
                </tr>
                <tr><td colspan="2" style="font-size:8px;"></td></tr>
                </table>
                <%--<BR />
                <DIV style="HEIGHT: 30px"></DIV>--%>
            </EditItemTemplate>
            <HeaderTemplate>
                <table>
                <tr><td colspan="2" style="height:30px;">SHORT CODE</td></tr>
                <tr><td colspan="2" style="height:30px;"></td></tr>
                <tr>
                <td style="height:30px;">
                    <asp:DropDownList id="ddlaSCode" runat="server" Width="120px"></asp:DropDownList>
                </td>
                <td style="font-size:8px;">
                    <asp:ImageButton ID="imbaRef" runat="server" 
                        AlternateText="Open Reference Table" Height="16px" 
                        ImageUrl="~/images/icons/search.gif" onclick="imbaRef_Click" 
                        ToolTip="Open Reference Table" ></asp:ImageButton>
                </td>
                </tr>
                <tr><td colspan="2" style="font-size:8px;"></td></tr>
                </table>
                <%--<DIV style="VERTICAL-ALIGN: top"></DIV><DIV style="HEIGHT: 30px"></DIV>
                <DIV style="VERTICAL-ALIGN: bottom">--%>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label id="lbliSCode" runat="server" Text='<%# Bind("shortCode") %>' Width="120px"></asp:Label> 
            </ItemTemplate>
        </asp:TemplateField>

        <%--<asp:TemplateField HeaderText="Capacity" SortExpression="capacity">
            <EditItemTemplate>
                <asp:Label id="lbleCap" runat="server" Text='<%# Bind("capacity") %>'></asp:Label><BR />
                <DIV style="HEIGHT: 30px"></DIV>
            </EditItemTemplate>
            <HeaderTemplate>
                <DIV style="VERTICAL-ALIGN: top">CAPACITY</DIV>
                <DIV style="HEIGHT: 30px"></DIV>
                <DIV style="VERTICAL-ALIGN: bottom">
                    &nbsp;<asp:Label ID="lblaCap" runat="server" Text='<%# Bind("capacity") %>'></asp:Label>
                </DIV>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label id="lbliCap" runat="server" Text='<%# Bind("capacity") %>'></asp:Label> 
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Variant" SortExpression="variant">
            <EditItemTemplate>
                <asp:Label id="lbleVariant" runat="server" Text='<%# Bind("variant") %>' Width="100px"></asp:Label><BR />
                <DIV style="HEIGHT: 30px"></DIV>
                &nbsp; 
            </EditItemTemplate>
            <HeaderTemplate>
                <DIV style="VERTICAL-ALIGN: top">VARIANT</DIV>
                <DIV style="HEIGHT: 30px"></DIV><DIV style="VERTICAL-ALIGN: bottom">&nbsp;
                <asp:Label ID="lblaVariant" runat="server" Text='<%# Bind("variant") %>' 
                    Width="100px"></asp:Label>
                </DIV>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label id="lbliVariant" runat="server" Text='<%# Bind("variant") %>' Width="100px"></asp:Label> 
            </ItemTemplate>
        </asp:TemplateField>--%>

        <asp:TemplateField HeaderText="Date Purchased" SortExpression="dpurchased">
            <EditItemTemplate>
                <asp:Label id="lblEDP" runat="server" Text='<%# Bind("dpurchased") %>' Width="110px"></asp:Label><BR />
                <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></DIV>
                <asp:DropDownList ID="ddleDP" runat="server" Width="110px">
                </asp:DropDownList>
            </EditItemTemplate>
            <HeaderTemplate>
                <DIV style="height:30px;">DATE</DIV>
                <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px">PURCHASED</DIV>
                <DIV style="height:30px;">
                    <asp:DropDownList ID="ddlaDP" runat="server" Width="110px">
                    </asp:DropDownList>
                    &nbsp;</DIV>
                <div style="font-size:8px;"></div>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label id="lbliDP" runat="server" Text='<%# Bind("dpurchased") %>' Width="110px"></asp:Label> 
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Serial Number" SortExpression="serial">
            <EditItemTemplate>
                <BR />
                <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></DIV>
                <asp:TextBox id="txtESerial" runat="server" Text='<%# Bind("serial") %>' 
                    Width="100px" AutoPostBack="True" ontextchanged="txtESerial_TextChanged"></asp:TextBox> 
            </EditItemTemplate>
            <HeaderTemplate>
                <DIV style="height:30px;">SERIAL</DIV>
                <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px">NUMBER</DIV>
                <DIV style="height:30px;">
                <asp:TextBox id="txtASerial" runat="server" Text='<%# Bind("serial") %>' 
                    Width="100px" AutoPostBack="True" ontextchanged="txtASerial_TextChanged"></asp:TextBox></DIV>
                <div style="font-size:8px;"></div>
            </HeaderTemplate>
            
            <ItemTemplate>
                <asp:Label id="lbliSerial" runat="server" Text='<%# Bind("serial") %>' Width="100px"></asp:Label> 
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Invoice" SortExpression="invoice">
            <EditItemTemplate>
                <BR />
                <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></DIV>
                <asp:TextBox id="txtEInvoice" runat="server" Text='<%# Bind("invoice") %>' Width="70px"></asp:TextBox> 
            </EditItemTemplate>
            <HeaderTemplate>
                <DIV style="height:30px;">INVOICE</DIV>
                <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px">NUMBER</DIV>
                <DIV style="height:30px;"><asp:TextBox id="txtAInvoice" runat="server" Text='<%# Bind("invoice") %>' Width="70px"></asp:TextBox>&nbsp;</DIV>
                <div style="font-size:8px;"></div>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label id="lbliInvoice" runat="server" Text='<%# Bind("invoice") %>'></asp:Label> 
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Status" SortExpression="status">
            <EditItemTemplate>
                <BR />
                <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></DIV>
                <asp:Label id="lbleStatus" runat="server" Text='<%# Bind("recStatus") %>'></asp:Label>
            </EditItemTemplate>
            <HeaderTemplate>
                <DIV style="height:30px;">STATUS</DIV>
                <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></DIV>
                <DIV style="height:30px;">
                    <asp:Label id="lblaStatus" runat="server" Text='<%# Bind("recStatus") %>'></asp:Label>
                </DIV>
                <div style="font-size:8px;"></div>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label id="lbliStatus" runat="server" Text='<%# Bind("recStatus") %>' width="100px"></asp:Label> 
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:BoundField DataField="salesID" ReadOnly="True" InsertVisible="False">
            <ControlStyle CssClass="hiddencol"></ControlStyle>
            <FooterStyle CssClass="hiddencol"></FooterStyle>
            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
            <ItemStyle CssClass="hiddencol"></ItemStyle>
        </asp:BoundField>
        
        <asp:TemplateField ShowHeader="False">
            <EditItemTemplate>
                <div style="width:80px;">
                    <div style="width:80px;">
                        <div style="width:40px; float:left;">
                            <asp:ImageButton id="imbAUpdate" runat="server" Text="Select" CommandName="Update" 
                                ToolTip="Modify Record" ImageUrl="~/images/icons/save.gif" AlternateText="Update Record" 
                                    CausesValidation="False"></asp:ImageButton> 
                        </div>
                        <div style="width:40px; float:right;">
                            <asp:ImageButton id="imbACancel" runat="server" Text="Select" 
                                CommandName="Cancel" ToolTip="Cancel" 
                                ImageUrl="~/images/icons/cancel.gif" AlternateText="Delete Record" 
                                CausesValidation="False"></asp:ImageButton>
                        </div>  
                    </div>
                </div>
            </EditItemTemplate>
            <HeaderTemplate>
                <asp:ImageButton id="imbASave" onclick="imbASave_Click" runat="server" ToolTip="Save Record" 
                    ImageUrl="~/images/icons/save.gif" AlternateText="Save Record"></asp:ImageButton> 
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Panel ID="panModify" runat="server">
                    
                    <div style="width:80px;">
                        <div style="width:40px; float:left;">
                            <asp:ImageButton id="imbAModify" runat="server" 
                                CommandName="Edit" ImageUrl="~/Images/icons/modify.gif" 
                                AlternateText="Modify Details">
                            </asp:ImageButton>
                        </div>
                        <div style="width:40px; float:right;">
                            <asp:LinkButton id="lnkADelete" 
                                onclick="lnkADelete_Click" runat="server" CssClass="deleteBtn" 
                                CommandArgument='<%# Eval("salesID") %>' causesvalidation="false"></asp:LinkButton> 
                        </div>
                    </div>
                    </asp:Panel> 
                    <asp:Panel ID="panDelete" runat="server">
                    <asp:Label id="lblAConfirm" runat="server" Text="Are you sure?" CssClass="errMsg" Visible="False"></asp:Label> 
                    <div style="width:40px; float:left;">
                        <asp:ImageButton id="imbAYes" 
                            onclick="imbAYes_Click" runat="server" Visible="False" 
                            ImageUrl="~/images/icons/yes.png">
                        </asp:ImageButton>
                    </div>
                    <div style="width:40px; float:right;">
                        <asp:ImageButton id="imbANo" 
                            onclick="imbANo_Click" runat="server" Visible="False" 
                            ImageUrl="~/images/icons/cancel.gif">
                        </asp:ImageButton>
                    </div> 
                </asp:Panel>
           </ItemTemplate>
        </asp:TemplateField>
    </Columns>

    <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom"></PagerSettings>
    <RowStyle CssClass="RowStyle"></RowStyle>
    <EmptyDataRowStyle CssClass="EmptyDataRowStyle"></EmptyDataRowStyle>
    <FooterStyle CssClass="FooterStyle"></FooterStyle>
    <PagerStyle CssClass="PagerRowStyle"></PagerStyle>
    <SelectedRowStyle CssClass="SelectedRowStyle"></SelectedRowStyle>
    <HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
    <EditRowStyle CssClass="EditRowStyle"></EditRowStyle>
    <AlternatingRowStyle CssClass="AlternatingRowStyle"></AlternatingRowStyle>

    <PagerTemplate>
            <TABLE>
            <TBODY>
            <TR vAlign=middle>
            <TD>
                <asp:ImageButton id="imbFirst" runat="server" 
                    CommandName="Page" 
                    ImageUrl="~/images/icons/first.gif" 
                    CommandArgument="First" 
                    AlternateText="First Page"></asp:ImageButton> 
                <asp:ImageButton id="imbPrev" runat="server" 
                    CommandName="Page" ImageUrl="~/images/icons/prev.gif" 
                    CommandArgument="Prev" AlternateText="Previous Page">
                    </asp:ImageButton> </TD>
            <TD>Page&nbsp; <asp:DropDownList id="ddlPageNo" runat="server" AutoPostBack="true" Width="50px" ></asp:DropDownList> &nbsp;of&nbsp; <asp:Label id="lblPageCount" runat="server"></asp:Label> </TD><TD><asp:ImageButton id="imbNext" runat="server" CommandName="Page" ImageUrl="~/images/icons/next.gif" CommandArgument="Next" AlternateText="Next Page"></asp:ImageButton> <asp:ImageButton id="imbLast" runat="server" CommandName="Page" ImageUrl="~/images/icons/last.gif" CommandArgument="Last" AlternateText="Last Page"></asp:ImageButton> </TD></TR></TBODY></TABLE>
    </PagerTemplate>

    <EmptyDataTemplate>
        <div style="text-align:center; margin:auto;">No Records Available</div> 
    </EmptyDataTemplate>

</asp:GridView>
</asp:Panel> 


<!-- COMPETITOR -->
<asp:Panel id="panCompete" runat="server" visible="false"><BR />

<asp:GridView id="grdCompetitor" runat="server" CssClass="gridRow" 
    Enabled="False" AutoGenerateColumns="False" BorderColor="Black" 
    DataKeyNames="competeID" DataSourceID="sqlDS_Competitor" PageSize="30" 
    ShowFooter="True" AllowSorting="True" Width="95%">
    
    <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom"></PagerSettings>

<Columns>
<asp:BoundField DataField="competeID" HeaderText="ID" Visible="False"></asp:BoundField>

<asp:TemplateField HeaderText="Brand" SortExpression="cBrand">
    <EditItemTemplate>
        <asp:Label runat="server" id="lbleCBrand" Text='<%# Bind("cBrand") %>' Width="150px"></asp:Label>
        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></DIV>
        <asp:DropDownList id="ddlECBrand" runat="server" Width="150px">
        </asp:DropDownList>
    </EditItemTemplate>
    <HeaderTemplate>
        <DIV style="VERTICAL-ALIGN: top">BRAND</DIV>
        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></DIV>
        <DIV style="VERTICAL-ALIGN: bottom">
            <asp:DropDownList id="ddlACBrand" runat="server" Width="150px"></asp:DropDownList>
    </HeaderTemplate>
    <ItemTemplate>
        <asp:Label id="lbliCBrand" runat="server" Text='<%# Bind("cBrand") %>' Width="150px"></asp:Label> 
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Capacity" SortExpression="capacity">
    <EditItemTemplate>
        <asp:Label runat="server" id="lbleCCap" Text='<%# Bind("cCapacity") %>' 
            Width="70px"></asp:Label>
        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></DIV>
        <asp:DropDownList id="ddleCCap" runat="server" Width="70px">
        </asp:DropDownList>
    </EditItemTemplate>
    <HeaderTemplate>
        <DIV style="VERTICAL-ALIGN: top">CAPACITY</DIV>
        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></DIV>
        <DIV style="VERTICAL-ALIGN: bottom">
            <asp:DropDownList id="ddlaCCap" runat="server" Width="70px"></asp:DropDownList>
    </HeaderTemplate>
    <ItemTemplate>
        <asp:Label id="lbliCCap" runat="server" Text='<%# Bind("cCapacity") %>' 
            Width="70px"></asp:Label> 
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Qty" SortExpression="qty">
    <EditItemTemplate>
        
        <BR  />
        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></DIV>
        <asp:TextBox ID="ddleCQty" width="40px" Text='<%# Bind("qty") %>' runat="server" 
                        MaxLength="3"></asp:TextBox>
        </EditItemTemplate>
    <HeaderTemplate>
        <DIV style="VERTICAL-ALIGN: top">QTY</DIV>
        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></DIV>
        <DIV style="VERTICAL-ALIGN: top">
            <asp:TextBox ID="ddlaCQty" width="40px" Text='<%# Bind("qty") %>' runat="server" 
                        MaxLength="3"></asp:TextBox>
            </DIV>
    </HeaderTemplate>
    <ItemTemplate>
        <div>
        <asp:Label id="lbliCQty" runat="server" Text='<%# Bind("qty") %>' Width="130px"></asp:Label>
        </div>
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Date" SortExpression="csDate">
    <EditItemTemplate>
        <asp:Label id="lbleCDate" runat="server" Text='<%# Bind("csDate") %>' Width="130px"></asp:Label>
        <BR  />
        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></DIV>
        <asp:DropDownList id="ddleCDate" runat="server" Width="130px"></asp:DropDownList>
    </EditItemTemplate>
    <HeaderTemplate>
        <DIV style="VERTICAL-ALIGN: top">DATE</DIV>
        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></DIV>
        <DIV style="VERTICAL-ALIGN: top">
            <asp:DropDownList id="ddlaCDate" runat="server" Width="130px"></asp:DropDownList>
        </DIV>
    </HeaderTemplate>
    <ItemTemplate>
        <asp:Label id="lbliCDate" runat="server" Text='<%# Bind("csDate") %>' Width="130px"></asp:Label> 
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Factors Affecting Sell Out" SortExpression="factor">
    <EditItemTemplate>
        <BR />
        <asp:TextBox id="txteFactor" runat="server" Text='<%# Bind("factor") %>' Width="400px"></asp:TextBox> 
    </EditItemTemplate>
    <HeaderTemplate>
        <DIV style="VERTICAL-ALIGN: top">FACTORS AFFECTING SELL OUT</DIV>
        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></DIV>
        <DIV style="VERTICAL-ALIGN: top">
            <asp:TextBox id="txtaFactor" runat="server" Text='<%# Bind("factor") %>' 
                Width="400px"></asp:TextBox>&nbsp;
        </DIV>
    </HeaderTemplate>
    <ItemTemplate>
        <asp:Label id="lbliFactor" runat="server" Text='<%# Bind("factor") %>' Width="400px"></asp:Label> 
    </ItemTemplate>
</asp:TemplateField>

<asp:BoundField DataField="competeID" ReadOnly="True" InsertVisible="False">
    <ControlStyle CssClass="hiddencol"></ControlStyle>
    <FooterStyle CssClass="hiddencol"></FooterStyle>
    <HeaderStyle CssClass="hiddencol"></HeaderStyle>
    <ItemStyle CssClass="hiddencol"></ItemStyle>
</asp:BoundField>

<asp:TemplateField ShowHeader="False">
    <EditItemTemplate>
        <TABLE style="WIDTH: 60px"><TBODY><TR align=center><TD style="WIDTH: 30px">
            <asp:ImageButton id="imbCUpdate" runat="server" Text="Select" 
                CommandName="Update" ToolTip="Modify Record" ImageUrl="~/images/icons/save.gif" 
                AlternateText="Update Record" CausesValidation="False"></asp:ImageButton> 
        </TD><TD style="WIDTH: 30px">
            <asp:ImageButton id="imbCCancel" runat="server" Text="Select" 
                CommandName="Cancel" ToolTip="Delete Record" ImageUrl="~/images/icons/cancel.gif" 
                AlternateText="Delete Record" CausesValidation="False"></asp:ImageButton>
        </TD></TR></TBODY></TABLE>
    </EditItemTemplate>
    <HeaderTemplate>
        <asp:ImageButton ID="imbCSave" runat="server" AlternateText="Save"
            CausesValidation="False" CommandName="Update" ImageUrl="~/images/icons/save.gif"
            OnClick="imbCSave_Click" Text="Select" ToolTip="Modify Record" />
    </HeaderTemplate>
    <ItemTemplate>
        <TABLE><TBODY>
        <TR><TD>
            <asp:ImageButton id="imbCModify" runat="server" CommandName="Edit" 
                ImageUrl="~/Images/icons/modify.gif" AlternateText="Modify Details">
            </asp:ImageButton> 
        </TD><TD>
            <asp:LinkButton id="lnkCDelete" onclick="lnkCDelete_Click" runat="server" 
                CssClass="deleteBtn" CommandArgument='<%# Eval("competeID") %>' causesvalidation="false">
            </asp:LinkButton> 
        </TD></TR><TR><TD colspan="2">
            <asp:Label id="lblCConfirm" runat="server" Text="Are you sure?" CssClass="errMsg" Visible="False">
            </asp:Label> 
        </TD></TR><TR><TD>
            <asp:ImageButton id="imbCYes" onclick="imbCYes_Click" runat="server" Visible="False" 
                ImageUrl="~/images/icons/yes.png">
            </asp:ImageButton> 
        </TD><TD>
            <asp:ImageButton id="imbCNo" onclick="imbCNo_Click" runat="server" Visible="False" 
                ImageUrl="~/images/icons/cancel.gif">
            </asp:ImageButton> 
        </TD></TR></TBODY></TABLE>
    </ItemTemplate>
</asp:TemplateField>
</Columns>

<FooterStyle CssClass="FooterStyle"></FooterStyle>
<PagerTemplate>
<TABLE>
<TBODY>
<TR vAlign=middle>
<TD>
    <asp:ImageButton id="imbCFirst" runat="server" 
        CommandName="Page" ImageUrl="~/images/icons/first.gif" 
        CommandArgument="First" AlternateText="First Page">
    </asp:ImageButton> 
    <asp:ImageButton id="imbCPrev" runat="server" CommandName="Page" 
        ImageUrl="~/images/icons/prev.gif" CommandArgument="Prev" 
        AlternateText="Previous Page"></asp:ImageButton> 
</TD>
<TD>
    Page&nbsp; 
    <asp:DropDownList id="ddlCPageNo" runat="server" 
        AutoPostBack="true" Width="50px" ></asp:DropDownList> 
    &nbsp;of&nbsp; 
    <asp:Label id="lblCPageCount" runat="server"></asp:Label> 
</TD>
<TD>
    <asp:ImageButton id="imbCNext" runat="server" CommandName="Page" 
        ImageUrl="~/images/icons/next.gif" CommandArgument="Next" 
        AlternateText="Next Page"></asp:ImageButton> 
    <asp:ImageButton id="imbCLast" runat="server" CommandName="Page" 
        ImageUrl="~/images/icons/last.gif" CommandArgument="Last" 
        AlternateText="Last Page"></asp:ImageButton> 
</TD>
</TR>
</TBODY>
</TABLE>
</PagerTemplate>

<RowStyle CssClass="RowStyle"></RowStyle>
<EmptyDataRowStyle CssClass="EmptyDataRowStyle"></EmptyDataRowStyle>
<PagerStyle CssClass="PagerRowStyle"></PagerStyle>
<EmptyDataTemplate>
<div style="text-align:center; margin:auto;">No Records Available</div> 
</EmptyDataTemplate>

<SelectedRowStyle CssClass="SelectedRowStyle"></SelectedRowStyle>
<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
<EditRowStyle CssClass="EditRowStyle"></EditRowStyle>
<AlternatingRowStyle CssClass="AlternatingRowStyle"></AlternatingRowStyle>
</asp:GridView>
</asp:Panel> 



<!-- STOCKS -->
    <asp:Panel ID="panStocks" runat="server" Visible="false"><BR />
        <asp:GridView id="grdStocks" runat="server" CssClass="gridRow" Enabled="False" AutoGenerateColumns="False" 
            BorderColor="Black" DataKeyNames="stocksID" DataSourceID="sqlDS_Stocks" PageSize="30" ShowFooter="True" AllowSorting="True">
            <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
            <RowStyle CssClass="RowStyle" />
            <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />

            <Columns>
                <asp:BoundField DataField="stocksID" HeaderText="ID" Visible="False" />

                <asp:TemplateField HeaderText="Product" SortExpression="product">
                    <EditItemTemplate>
                        <asp:Label ID="lbleSProd" runat="server" Text='<%# Bind("product") %>' 
                            Width="150px"></asp:Label>
                        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px">
                        </div>
                        <asp:DropDownList id="ddlESProd" runat="server" Width="150px" 
                            AutoPostBack="True" 
                            onselectedindexchanged="ddlESProd_SelectedIndexChanged">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <DIV style="VERTICAL-ALIGN: top">
                            PRODUCT</div>
                        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px">
                        </div>
                        <DIV style="VERTICAL-ALIGN: bottom">
                            <asp:DropDownList id="ddlASProd" runat="server" Width="150px" 
                                AutoPostBack="True" 
                                onselectedindexchanged="ddlASProd_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbliSProd" runat="server" Text='<%# Bind("product") %>' 
                            Width="150px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Brand" SortExpression="brand">
                    <EditItemTemplate>
                        <asp:Label ID="lbleSBrand" runat="server" Text='<%# Bind("brand") %>' Width="150px"></asp:Label>
                        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px">
                        </div>
                        <asp:DropDownList id="ddlESBrand" runat="server" Width="150px" 
                            AutoPostBack="True" onselectedindexchanged="ddlESBrand_SelectedIndexChanged">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <DIV style="VERTICAL-ALIGN: top">BRAND</div>
                        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></div>
                        <DIV style="VERTICAL-ALIGN: bottom">
                            <asp:DropDownList id="ddlASBrand" runat="server" Width="150px" 
                                AutoPostBack="True" onselectedindexchanged="ddlASBrand_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbliSBrand" runat="server" Text='<%# Bind("brand") %>' Width="150px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Short Code" SortExpression="shortCode">
                    <EditItemTemplate>
                        <table>
                        <tr>
                        <td colspan="2">
                            <asp:Label ID="lbleSSCode" runat="server" Text='<%# Bind("shortCode") %>' Width="150px"></asp:Label>    
                        </td>
                        </tr>

                        <tr><td colspan="2" style="height:30px;"></td></tr>
                            
                        <tr>
                        <td>
                            <asp:DropDownList id="ddlESSCode" runat="server" Width="150px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:ImageButton ID="imbeSRef" runat="server" 
                                AlternateText="Open Reference Table" Height="16px" 
                                ImageUrl="~/images/icons/search.gif" onclick="imbeSRef_Click" 
                                ToolTip="Open Reference Table" ></asp:ImageButton>
                        </td>
                        </tr>
                        </table>
                        <%--<DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px">
                        </div>--%>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <table>
                        <tr><td colspan="2">SHORT CODE</td></tr>

                        <tr><td style="height:30px;"></td></tr>

                        <tr>
                        <td>
                            <asp:DropDownList id="ddlASSCode" runat="server" Width="150px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:ImageButton ID="imbaSRef" runat="server" 
                                AlternateText="Open Reference Table" Height="16px" 
                                ImageUrl="~/images/icons/search.gif" onclick="imbaSRef_Click" 
                                ToolTip="Open Reference Table" ></asp:ImageButton>
                        </td>
                        </tr>
                        </table>
                        <%--<DIV style="VERTICAL-ALIGN: top"></div>
                        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></div>
                        <DIV style="VERTICAL-ALIGN: bottom">
                            
                        </div>--%>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbliSSCode" runat="server" Text='<%# Bind("shortCode") %>' Width="150px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <%--<asp:TemplateField HeaderText="Capacity" SortExpression="capacity">
                    <EditItemTemplate>
                        <asp:Label ID="lbleSCap" runat="server" Text='<%# Bind("capacity") %>' Width="50px"></asp:Label>
                        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></div>
                        <asp:DropDownList id="ddlESCap" runat="server" Width="50px">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <DIV style="VERTICAL-ALIGN: top">CAPACITY</div>
                        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></div>
                        <DIV style="VERTICAL-ALIGN: bottom">
                            <asp:DropDownList id="ddlASCap" runat="server" Width="50px">
                            </asp:DropDownList>
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbliSCap" runat="server" Text='<%# Bind("capacity") %>' Width="50px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>

                <%--<asp:TemplateField HeaderText="Variant" SortExpression="variant">
                    <EditItemTemplate>
                        <asp:Label ID="lbleSVariant" runat="server" Text='<%# Bind("variant") %>' Width="100px"></asp:Label>
                        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></div>
                        <asp:DropDownList id="ddlESVariant" runat="server" Width="100px">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <DIV style="VERTICAL-ALIGN: top">VARIANT</div>
                        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></div>
                        <DIV style="VERTICAL-ALIGN: bottom">
                            <asp:DropDownList id="ddlASVariant" runat="server" Width="100px">
                            </asp:DropDownList>
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbliSVariant" runat="server" Text='<%# Bind("variant") %>' Width="100px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>

                <asp:TemplateField HeaderText="When" SortExpression="dWhen">
                    <EditItemTemplate>
                        <asp:Label ID="lbleWhen" runat="server" Text='<%# Bind("dWhen") %>' Width="120px"></asp:Label>
                        <BR  />
                        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></div>
                        <asp:DropDownList id="ddleWhen" runat="server" Width="120px">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <DIV style="VERTICAL-ALIGN: top">WHEN</div>
                        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></div>
                        <DIV style="VERTICAL-ALIGN: top">
                            <asp:DropDownList id="ddlaWhen" runat="server" Width="120px">
                            </asp:DropDownList>
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbliWhen" runat="server" Text='<%# Bind("dWhen") %>' Width="120px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Action Taken" SortExpression="actionTaken">
                    <EditItemTemplate>
                        <asp:Label ID="lbleAction" runat="server" Text='<%# Bind("actTake") %>' Width="300px"></asp:Label>
                        <BR  />
                        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px">
                        </div>
                        <asp:DropDownList id="ddleAction" runat="server" Width="300px" 
                            AutoPostBack="True" onselectedindexchanged="ddleAction_SelectedIndexChanged">
                        </asp:DropDownList><br />
                        <asp:TextBox ID="txteAction" runat="server" Width="300px" 
                            Text='<%# Bind("otherAct") %>' visible="false" AutoPostBack="True"></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <DIV style="VERTICAL-ALIGN: top">ACTION TAKEN</div>
                        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></div>
                        <DIV style="VERTICAL-ALIGN: top">
                            <asp:DropDownList id="ddlaAction" runat="server" Width="300px" 
                                AutoPostBack="True" onselectedindexchanged="ddlaAction_SelectedIndexChanged">
                            </asp:DropDownList><br />
                            <asp:TextBox ID="txtaAction" runat="server" Width="300px" visible="false" 
                                AutoPostBack="True"></asp:TextBox>&nbsp;</div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbliAction" runat="server" Text='<%# Bind("actTake") %>' Width="130px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Competitor Promo Activities" SortExpression="promo">
                    <EditItemTemplate>
                        <BR />
                        <asp:TextBox ID="txtePromo" runat="server" Text='<%# Bind("promo") %>' Width="400px"></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <DIV style="VERTICAL-ALIGN: top">
                            COMPETITOR PROMO ACTIVITIES</div>
                        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px">
                        </div>
                        <DIV style="VERTICAL-ALIGN: top">
                            <asp:TextBox ID="txtaPromo" runat="server" Text='<%# Bind("promo") %>' Width="400px"></asp:TextBox>&nbsp;</div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbliPromo" runat="server" Text='<%# Bind("promo") %>' Width="400px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="stocksID" ReadOnly="True" InsertVisible="False">
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

                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <div style="width:80px;">
                                <div style="width:40px; float:left;">
                                        <asp:ImageButton ID="imbSUpdate" runat="server" AlternateText="Update Record" CausesValidation="False"
                                            CommandName="Update" ImageUrl="~/images/icons/save.gif" Text="Select" ToolTip="Modify Record" />
                                </div>
                                <div style="width:40px; float:right;">
                                        <asp:ImageButton ID="imbSCancel" runat="server" AlternateText="Delete Record" CausesValidation="False"
                                            CommandName="Cancel" ImageUrl="~/images/icons/cancel.gif" Text="Select" ToolTip="Delete Record" />
                                </div>
                        </div>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:ImageButton ID="imbSSave" runat="server" AlternateText="Save Record" ImageUrl="~/images/icons/save.gif"
                            OnClick="imbSSave_Click" ToolTip="Save Record" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div style="width:80px;">
                            <div style="width:80px;">
                                <div style="width:40px; float:left;">
                                        <asp:ImageButton ID="imbSModify" runat="server" AlternateText="Modify Details" CommandName="Edit"
                                            ImageUrl="~/Images/icons/modify.gif" />
                                </div>
                                <div style="width:40px; float:right;">
                                        <asp:LinkButton ID="lnkSDelete" runat="server" CausesValidation="false" CommandArgument='<%# Eval("stocksID") %>'
                                            CssClass="deleteBtn" OnClick="lnkSDelete_Click"></asp:LinkButton>
                                </div>
                            </div>
                            <div style="width:80px;">
                                <asp:Label ID="lblSConfirm" runat="server" CssClass="errMsg" Text="Are you sure?"
                                            Visible="False">
                                </asp:Label>
                                <div style="width:40px; float:left;">
                                    <asp:ImageButton ID="imbSYes" runat="server" ImageUrl="~/images/icons/yes.png"
                                            OnClick="imbSYes_Click" Visible="False" />
                                </div>
                                <div style="width:40px; float:right;">
                                        <asp:ImageButton ID="imbSNo" runat="server" ImageUrl="~/images/icons/cancel.gif"
                                            OnClick="imbSNo_Click" Visible="False" />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <FooterStyle CssClass="FooterStyle" />
            <PagerTemplate>
                <TABLE>
                    <TBODY>
                        <TR vAlign=middle>
                            <TD>
                                <asp:ImageButton ID="imbSFirst" runat="server" AlternateText="First Page" CommandArgument="First"
                                    CommandName="Page" ImageUrl="~/images/icons/first.gif" />
                                <asp:ImageButton ID="imbSPrev" runat="server" AlternateText="Previous Page" CommandArgument="Prev"
                                    CommandName="Page" ImageUrl="~/images/icons/prev.gif" />
                            </td>
                            <TD>
                                Page&nbsp;
                                <asp:DropDownList id="ddlSPageNo" runat="server" 
        AutoPostBack="true" Width="50px" >
                                </asp:DropDownList>
                                &nbsp;of&nbsp;
                                <asp:Label ID="lblSPageCount" runat="server"></asp:Label>
                            </td>
                            <TD>
                                <asp:ImageButton ID="imbSNext" runat="server" AlternateText="Next Page" CommandArgument="Next"
                                    CommandName="Page" ImageUrl="~/images/icons/next.gif" />
                                <asp:ImageButton ID="imbSLast" runat="server" AlternateText="Last Page" CommandArgument="Last"
                                    CommandName="Page" ImageUrl="~/images/icons/last.gif" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </PagerTemplate>
            <PagerStyle CssClass="PagerRowStyle" />
            <EmptyDataTemplate>
                <div style="text-align:center; margin:auto;">
                    No Records Available</div>
            </EmptyDataTemplate>
            <SelectedRowStyle CssClass="SelectedRowStyle" />
            <HeaderStyle CssClass="HeaderStyle" />
            <EditRowStyle CssClass="EditRowStyle" />
            <AlternatingRowStyle CssClass="AlternatingRowStyle" />
        </asp:GridView>
    </asp:Panel>
    


    
    <!-- INVENTORY -->
    <asp:Panel ID="panInventory" runat="server" Visible="false"><BR />
        <asp:GridView id="grdInventory" runat="server" CssClass="gridRow" Enabled="False" 
            AutoGenerateColumns="False" BorderColor="Black" 
            DataKeyNames="inventoryID" DataSourceID="sqlDS_Inventory" PageSize="30" 
            ShowFooter="True" AllowSorting="True">
            <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
            <RowStyle CssClass="RowStyle" />
            <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
            
            <Columns>
                <asp:BoundField DataField="inventoryID" HeaderText="ID" Visible="False" />
            
                <asp:TemplateField HeaderText="Product" SortExpression="product">
                    <EditItemTemplate>
                        <asp:Label ID="lbleIProd" runat="server" Text='<%# Bind("product") %>' Width="150px"></asp:Label>
                        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px">
                        </div>
                        <asp:DropDownList id="ddleIProd" runat="server" Width="150px" 
                            AutoPostBack="True" onselectedindexchanged="ddleIProd_SelectedIndexChanged">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <DIV style="VERTICAL-ALIGN: top">PRODUCT</div>
                        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></div>
                        <DIV style="VERTICAL-ALIGN: bottom">
                            <asp:DropDownList id="ddlaIProd" runat="server" Width="150px" 
                                AutoPostBack="True" onselectedindexchanged="ddlaIProd_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbliIProd" runat="server" Text='<%# Bind("product") %>' Width="150px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Brand" SortExpression="brand">
                    <EditItemTemplate>
                        <asp:Label ID="lbleIBrand" runat="server" Text='<%# Bind("brand") %>' Width="150px"></asp:Label>
                        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></div>
                        <asp:DropDownList id="ddleIBrand" runat="server" Width="150px" 
                            AutoPostBack="True" onselectedindexchanged="ddleIBrand_SelectedIndexChanged">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <DIV style="VERTICAL-ALIGN: top">BRAND</div>
                        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></div>
                        <DIV style="VERTICAL-ALIGN: bottom">
                            <asp:DropDownList id="ddlaIBrand" runat="server" Width="150px" 
                                AutoPostBack="True" onselectedindexchanged="ddlaIBrand_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbliIBrand" runat="server" Text='<%# Bind("brand") %>' Width="150px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Short Code" SortExpression="shortCode">
                    <EditItemTemplate>
                        <table>
                        <tr>
                        <td colspan="2">
                            <asp:Label ID="lbleISCode" runat="server" Text='<%# Bind("shortCode") %>' Width="150px"></asp:Label>    
                        </td>
                        </tr>

                        <tr><td colspan="2" style="height:30px;"</tr>
                            
                        <tr>
                        <td>
                            <asp:DropDownList id="ddleISCode" runat="server" Width="150px" 
                            AutoPostBack="True">
                        </asp:DropDownList>
                        </td>
                        <td>
                            <asp:ImageButton ID="imbeIRef" runat="server" 
                                AlternateText="Open Reference Table" Height="16px" 
                                ImageUrl="~/images/icons/search.gif" onclick="imbeIRef_Click" 
                                ToolTip="Open Reference Table" ></asp:ImageButton>
                        </td>
                        </tr>
                        </table>
                        <%--<DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></div>--%>                        
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <table>
                        <tr><td colspan="2">SHORT CODE</td></tr>

                        <tr><td colspan="2" style="height:30px;"></td></tr>

                        <tr>
                        <td>
                            <asp:DropDownList id="ddlaISCode" runat="server" Width="150px"  AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:ImageButton ID="imbaIRef" runat="server" 
                                AlternateText="Open Reference Table" Height="16px" 
                                ImageUrl="~/images/icons/search.gif" onclick="imbaIRef_Click" 
                                ToolTip="Open Reference Table" ></asp:ImageButton>
                        </td>
                        </tr>
                        </table>
                        <%--<DIV style="VERTICAL-ALIGN: top"></div>
                        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></div>
                        <DIV style="VERTICAL-ALIGN: bottom">
                            
                        </div>--%>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbliISCode" runat="server" Text='<%# Bind("shortCode") %>' Width="150px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <%--<asp:TemplateField HeaderText="Capacity" SortExpression="capacity">
                    <EditItemTemplate>
                        <asp:Label ID="lbleICap" runat="server" Text='<%# Bind("capacity") %>' Width="50px"></asp:Label>
                        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></div>
                        <asp:DropDownList id="ddleICap" runat="server" Width="50px" AutoPostBack="True">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <DIV style="VERTICAL-ALIGN: top">CAPACITY</div>
                        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></div>
                        <DIV style="VERTICAL-ALIGN: bottom">
                            <asp:DropDownList id="ddlaICap" runat="server" Width="50px" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbliICap" runat="server" Text='<%# Bind("capacity") %>' Width="50px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Variant" SortExpression="variant">
                    <EditItemTemplate>
                        <asp:Label ID="lbleIVariant" runat="server" Text='<%# Bind("variant") %>' Width="100px"></asp:Label>
                        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></div>
                        <asp:DropDownList id="ddleIVariant" runat="server" Width="100px" 
                            AutoPostBack="True">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <DIV style="VERTICAL-ALIGN: top">VARIANT</div>
                        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></div>
                        <DIV style="VERTICAL-ALIGN: bottom">
                            <asp:DropDownList id="ddlaIVariant" runat="server" Width="100px">
                            </asp:DropDownList>
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbliIVariant" runat="server" Text='<%# Bind("variant") %>' Width="100px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>

                <asp:TemplateField HeaderText="Qty" SortExpression="qty">
                    <EditItemTemplate>
                        <BR  />
                        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px">
                        </div>
                        <asp:TextBox ID="ddleIQty" width="40px" Text='<%# Bind("qty") %>' runat="server" 
                        MaxLength="3"></asp:TextBox>
                                            </EditItemTemplate>
                    <HeaderTemplate>
                        <DIV style="VERTICAL-ALIGN: top">QTY</div>
                        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></div>
                        <DIV style="VERTICAL-ALIGN: top">
                        <asp:TextBox ID="ddlaIQty" width="40px" Text='<%# Bind("qty") %>' runat="server" 
                        MaxLength="3"></asp:TextBox>
                                                </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbliIQty" runat="server" Text='<%# Bind("qty") %>' Width="40px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <%--<asp:TemplateField HeaderText="Location" SortExpression="location">
                    <EditItemTemplate>
                        <asp:Label ID="lbleLoc" runat="server" Text='<%# Bind("location") %>' Width="200px"></asp:Label><br />
                        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px">
                        </div>
                        <asp:DropDownList ID="ddleLoc" runat="server" Width="200px">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <DIV style="VERTICAL-ALIGN: top">LOCATION</div>
                        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></div>
                        <DIV style="VERTICAL-ALIGN: top">
                            <asp:DropDownList ID="ddlaLoc" runat="server" Width="200px">
                            </asp:DropDownList>&nbsp;</div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbliLoc" runat="server" Text='<%# Bind("location") %>' Width="200px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>

                <asp:TemplateField HeaderText="Comments &amp; Suggestion" SortExpression="comments">
                    <EditItemTemplate>
                        <BR />
                        <asp:TextBox ID="txteComments" runat="server" Text='<%# Bind("comments") %>' Width="400px"></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <DIV style="VERTICAL-ALIGN: top">COMMENTS &amp; SUGGESTIONS</div>
                        <DIV style="VERTICAL-ALIGN: top; HEIGHT: 30px"></div>
                        <DIV style="VERTICAL-ALIGN: top">
                            <asp:TextBox ID="txtaComments" runat="server" Text='<%# Bind("comments") %>' Width="400px"></asp:TextBox>&nbsp;</div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbliComments" runat="server" Text='<%# Bind("comments") %>' Width="400px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:BoundField DataField="inventoryID" ReadOnly="True" InsertVisible="False">
                    <ControlStyle CssClass="hiddencol" />
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
                
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <div style="width:80px;">
                            <div style="width:40px; float:left;">
                                <asp:ImageButton ID="imbIUpdate" runat="server" AlternateText="Update Record" CausesValidation="False"
                                    CommandName="Update" ImageUrl="~/images/icons/save.gif" Text="Select" ToolTip="Modify Record" />
                            </div>
                            <div style="width:40px; float:right;">
                                <asp:ImageButton ID="imbICancel" runat="server" AlternateText="Delete Record" CausesValidation="False"
                                    CommandName="Cancel" ImageUrl="~/images/icons/cancel.gif" Text="Select" ToolTip="Delete Record" />
                            </div>
                        </div>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:ImageButton ID="imbISave" runat="server" AlternateText="Save Record" ImageUrl="~/images/icons/save.gif"
                            OnClick="imbISave_Click" ToolTip="Save Record" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div style="width:80px;">
                            <div style="width:80px;">
                                <div style="width:40px; float:left;">
                                    <asp:ImageButton ID="imbIModify" runat="server" AlternateText="Modify Details" CommandName="Edit"
                                        ImageUrl="~/Images/icons/modify.gif" />
                                </div>
                                <div style="width:40px; float:right;">
                                    <asp:LinkButton ID="lnkIDelete" runat="server" CausesValidation="false" CommandArgument='<%# Eval("inventoryID") %>'
                                            CssClass="deleteBtn" OnClick="lnkIDelete_Click">
                                    </asp:LinkButton>
                                </div>
                            </div>
                            <div style="width:80px;">
                                <asp:Label ID="lblIConfirm" runat="server" CssClass="errMsg" Text="Are you sure?"
                                            Visible="False"></asp:Label>
                                <div style="width:40px; float:left;">
                                    <asp:ImageButton ID="imbIYes" runat="server" ImageUrl="~/images/icons/yes.png"
                                            OnClick="imbIYes_Click" Visible="False" />
                                </div>
                                <div style="width:40px; float:right;">
                                    <asp:ImageButton ID="imbINo" runat="server" ImageUrl="~/images/icons/cancel.gif"
                                            OnClick="imbINo_Click" Visible="False" />
                                </div>
                            </div>
                        </div>
                     </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle CssClass="FooterStyle" />
            <PagerTemplate>
                <TABLE>
                    <TBODY>
                        <TR vAlign=middle>
                            <TD>
                                <asp:ImageButton ID="imbIFirst" runat="server" AlternateText="First Page" CommandArgument="First"
                                    CommandName="Page" ImageUrl="~/images/icons/first.gif" />
                                <asp:ImageButton ID="imbIPrev" runat="server" AlternateText="Previous Page" CommandArgument="Prev"
                                    CommandName="Page" ImageUrl="~/images/icons/prev.gif" />
                            </td>
                            <TD>
                                Page&nbsp;
                                <asp:DropDownList id="ddlIPageNo" runat="server" 
        AutoPostBack="true" Width="50px" >
                                </asp:DropDownList>
                                &nbsp;of&nbsp;
                                <asp:Label ID="lblIPageCount" runat="server"></asp:Label>
                            </td>
                            <TD>
                                <asp:ImageButton ID="imbINext" runat="server" AlternateText="Next Page" CommandArgument="Next"
                                    CommandName="Page" ImageUrl="~/images/icons/next.gif" />
                                <asp:ImageButton ID="imbILast" runat="server" AlternateText="Last Page" CommandArgument="Last"
                                    CommandName="Page" ImageUrl="~/images/icons/last.gif" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </PagerTemplate>
            <PagerStyle CssClass="PagerRowStyle" />
            <EmptyDataTemplate>
                <div style="text-align:center; margin:auto;">
                    No Records Available</div>
            </EmptyDataTemplate>
            <SelectedRowStyle CssClass="SelectedRowStyle" />
            <HeaderStyle CssClass="HeaderStyle" />
            <EditRowStyle CssClass="EditRowStyle" />
            <AlternatingRowStyle CssClass="AlternatingRowStyle" />
        </asp:GridView>
    </asp:Panel>
    

    <!-- SQL - INFO -->
<asp:SqlDataSource id="sqlDS_Info" runat="server" 
    ConnectionString="<%$ ConnectionStrings:conString %>" 
    SelectCommand="SELECT  * FROM    [vw_Info] 
                    WHERE   (productID = @prodID)
                            AND (brandID = @brandID)">
                        
            <SelectParameters>
                <asp:SessionParameter Name="prodID" 
                    SessionField="prodID" Type="Int64" />
                <asp:SessionParameter Name="brandID" 
                    SessionField="brandID" Type="Int64" />
            </SelectParameters>
        </asp:SqlDataSource> 

    <!-- SQL - SALES -->
<asp:SqlDataSource id="sqlDS_Sales" runat="server" 
    ConnectionString="<%$ ConnectionStrings:conString %>" 
    UpdateCommand="SELECT  * FROM    [vw_Sales] WHERE   (userID = @userID)" 
    DeleteCommand="SELECT  * FROM    [vw_Sales] WHERE   (userID = @userID)" 
    SelectCommand="SELECT  * FROM    [vw_Sales] WHERE   (userID = @userID)">
                        
            <SelectParameters>
                <asp:SessionParameter Name="userID" 
                    SessionField="userID" Type="Int64" />
            </SelectParameters>
            
            <UpdateParameters>
                <asp:SessionParameter Name="userID" 
                    SessionField="userID" Type="Int64" />
            </UpdateParameters>
            
            <DeleteParameters>
                <asp:SessionParameter Name="userID" 
                    SessionField="userID" Type="Int64" />
            </DeleteParameters>
        </asp:SqlDataSource> 
  
  
<!--SQL - COMPETITOR-->
<asp:SqlDataSource id="sqlDS_Competitor" runat="server" 
    ConnectionString="<%$ ConnectionStrings:conString %>" 
    UpdateCommand="SELECT  * FROM    [vw_Compete] WHERE   (userID = @userID)" 
    DeleteCommand="SELECT  * FROM    [vw_Compete] WHERE   (userID = @userID)" 
    SelectCommand="SELECT  * FROM    [vw_Compete] WHERE   (userID = @userID)">
                        
            <SelectParameters>
                <asp:SessionParameter Name="userID" 
                    SessionField="userID" Type="Int64"  />
            </SelectParameters>
            
            <UpdateParameters>
                <asp:SessionParameter Name="userID" 
                    SessionField="userID" Type="Int64"  />
            </UpdateParameters>
            
            <DeleteParameters>
                <asp:SessionParameter Name="userID" 
                    SessionField="userID" Type="Int64"  />
            </DeleteParameters>
        </asp:SqlDataSource> 
        
        
<!--SQL - STOCKS-->
<asp:SqlDataSource id="sqlDS_Stocks" runat="server" 
    ConnectionString="<%$ ConnectionStrings:conString %>" 
    UpdateCommand="SELECT  * FROM    [vw_Stocks] WHERE   (userID = @userID)" 
    DeleteCommand="SELECT  * FROM    [vw_Stocks] WHERE   (userID = @userID)" 
    SelectCommand="SELECT  * FROM    [vw_Stocks] WHERE   (userID = @userID)">
                        
            <SelectParameters>
                <asp:SessionParameter Name="userID" 
                    SessionField="userID" Type="Int64"  />
            </SelectParameters>
            
            <UpdateParameters>
                <asp:SessionParameter Name="userID" 
                    SessionField="userID" Type="Int64"  />
            </UpdateParameters>
            
            <DeleteParameters>
                <asp:SessionParameter Name="userID" 
                    SessionField="userID" Type="Int64"  />
            </DeleteParameters>
        </asp:SqlDataSource> 
        
<!--SQL - INVENTORY-->
<asp:SqlDataSource id="sqlDS_Inventory" runat="server" 
    ConnectionString="<%$ ConnectionStrings:conString %>" 
    UpdateCommand="SELECT  * FROM    [vw_Inventory] WHERE   (userID = @userID)" 
    DeleteCommand="SELECT  * FROM    [vw_Inventory] WHERE   (userID = @userID)" 
    SelectCommand="SELECT  * FROM    [vw_Inventory] WHERE   (userID = @userID)">
                        
            <SelectParameters>
                <asp:SessionParameter Name="userID" 
                    SessionField="userID" Type="Int64"  />
            </SelectParameters>
            
            <UpdateParameters>
                <asp:SessionParameter Name="userID" 
                    SessionField="userID" Type="Int64"  />
            </UpdateParameters>
            
            <DeleteParameters>
                <asp:SessionParameter Name="userID" 
                    SessionField="userID" Type="Int64"  />
            </DeleteParameters>
        </asp:SqlDataSource> 
        <!-- END OF CONTENT PLACEMENT -->
</DIV>

<!-- end cont wrap -->
<!--</DIV>-->
<!-- end main wrap -->

</ContentTemplate>
</asp:UpdatePanel> 
</div>  
</center>

</asp:Content>
