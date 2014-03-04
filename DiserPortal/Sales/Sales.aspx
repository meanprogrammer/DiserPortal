<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Sales.aspx.vb" Inherits="DiserPortal.Sales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <center>
<div class="dataWrapper">
<asp:UpdatePanel ID="updTM" runat="server">
<ContentTemplate>

<div id="main_wrap">  
	<div style="height:50px;float:right;">
		<asp:UpdateProgress ID="PageUpdateProgress2" runat="server">
			<progresstemplate>
				<div style="padding: 10px; vertical-align:bottom;float:right;">
					<asp:Image runat="server" Height="20px" ImageUrl="~/images/icons/loading.gif" ImageAlign="AbsMiddle" />
				</div>
			</progresstemplate>
		</asp:UpdateProgress>
	</div>

	<div id="tab_wrap">
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

		<div style="FLOAT: middle">
			Week Coverage: &nbsp;
			<asp:DropDownList id="ddlWeek" runat="server" AutoPostBack="True"></asp:DropDownList><br/>
			<asp:Button id="btnCreate" onclick="btnCreate_Click" runat="server" Text="Create Report" />
			<asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 	Text="Submit Report" />
			<asp:Button ID="btnUpload" runat="server" Text="Upload File" /><br/>
		</div>
	</div><!-- end tab wrap -->

	<div style="CLEAR: both"></div>

	<div id="cont_wrap">


<!-- START PLACING CONTENT HERE -->

	<br/>
	<asp:Label id="lbleMsg" runat="server" ForeColor="red"/>
	<asp:ImageButton id="imbYes" onclick="imbYes_Click" runat="server" visible="false" ImageUrl="~/images/icons/yes.png" Height="16px"></asp:ImageButton>&nbsp;
	<asp:ImageButton id="imbNo" onclick="imbNo_Click" runat="server" visible="false" ImageUrl="~/images/icons/no.png"></asp:ImageButton>


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
            ImageUrl="~/images/icons/cancel.png" ></asp:ImageButton>
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


<!-- PRODUCT REGISTRATION -->

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
                <td style="height:15px;"></td>
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
                <td colspan="2" style="height:15px;">CUSTOMER</td>
                </tr>

                <tr>
                <td colspan="2" style="height:15px;"></td>
                </tr>
                
                <tr>
                <td style="height:15px;">
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
                <%--<div style="VERTICAL-ALIGN: top">CUSTOMER</div>
                <div style="HEIGHT: 15px"></div>
                <div style="HEIGHT: 15px"></div>
                <div style="VERTICAL-ALIGN: bottom; width: 160px;">
                    <div style="float:left;">
                        
                    </div>
                    <div style="float:right;">
                        
                    </div>
                    <div style="float:left; padding-left:17px; font-weight:normal; font-size:8px;">First Name</div>
                    <div style="float:right; padding-right:25px; font-weight:normal; font-size:8px;">Last Name</div>
                </div>--%>
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
                <td colspan="2" style="height:15px;"><asp:Label id="lbleAdd" runat="server" Text='<%# Bind("cAddress") %>' width="145px"></asp:Label></td>
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
                <%--<div style="HEIGHT: 30px"></div>
                <div style="VERTICAL-ALIGN: bottom; width:300px; text-align:left;">
                    <div style="float:left; width:145px;">
                        
                    </div>
                    <div style="float:right; width:145px;">
                        
                    </div>
                    <div style="float:left; font-weight:normal; font-size:8px; "></div>
                    <div style="float:right; font-weight:normal; font-size:8px;"></div>
                </div>--%>
            </EditItemTemplate>
            <HeaderTemplate>
                <table>
                <tr>
                <td colspan="2" style="height:15px;">ADDRESS</td>
                </tr>

                <tr><td colspan="2" style="height:15px;"></td></tr>

                <tr>
                <td style="height:15px;">
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
                <%--<div style="VERTICAL-ALIGN: top">ADDRESS</div>
                <div style="HEIGHT: 30px"></div>
                <div style="VERTICAL-ALIGN: bottom; width:300px; text-align:left;">
                    <div style="float:left; width:145px;">
                        
                    </div>
                    <div style="float:right; width:145px;">
                        
                    </div>
                    <div style="float:left; font-weight:normal; font-size:8px; "></div>
                    <div style="float:right; font-weight:normal; font-size:8px;"></div>
                </div>--%>
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
                <tr><td style="height:15px;">&nbsp;</td></tr>
                <tr>
					<td>
						<asp:TextBox id="txtEContact" runat="server" Text='<%# Bind("contact") %>' 
                        Width="120px" AutoPostBack="True" ontextchanged="txtEContact_TextChanged"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td align="center" style="font-size:8px;">&nbsp;</td>
				</tr> 
                </table>
                <%--<BR />
                <div style="HEIGHT: 30px"></div>--%>
            </EditItemTemplate>
            <HeaderTemplate>
                <table>
                <tr><td style="height:15px;">TEL NO</td></tr>
                <tr><td style="height:15px;"></td></tr>
                <tr><td style="height:15px;">
                    <asp:TextBox id="txtAContact" runat="server" Text='<%# Bind("contact") %>' 
                        Width="120px" AutoPostBack="True" ontextchanged="txtAContact_TextChanged"></asp:TextBox>
                </td></tr>
                <tr><td style="font-size:8px;">&nbsp;</td></tr>
                </table>
                <%--<div style="VERTICAL-ALIGN: top">CONTACT </div>
                <div style="HEIGHT: 30px">NUMBER </div>
                <div style="VERTICAL-ALIGN: bottom">
                    &nbsp;
                </div>
                <div></div>--%>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label id="lbliContact" runat="server" Text='<%# Bind("contact") %>' Width="120px"></asp:Label> 
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Qty" SortExpression="qty">
            <EditItemTemplate>
                <table align="center">
                <tr><td style="height:15px;">&nbsp;</td></tr>
                <tr>
					<td style="height:15px;">
						<asp:TextBox ID="ddleQty" width="40px" Text='<%# Bind("qty") %>' runat="server" MaxLength="3"></asp:TextBox>
					</td>
                </tr>
                <tr><td style="font-size:8px;">&nbsp;</td></tr>
                </table>
                <%--<BR />
                <div style="HEIGHT: 30px"></div>--%>                 
            </EditItemTemplate>
            <HeaderTemplate>
                <table align="center">
                <tr><td style="height:15px;">QTY</td></tr>
                <tr><td style="height:15px;"></td></tr>
                <tr>
                <td style="height:15px;">
                    <asp:TextBox ID="ddlAQty" width="40px" Text='<%# Bind("qty") %>' runat="server" 
                        MaxLength="3"></asp:TextBox>
                    </td>
                </tr>
                <tr><td style="font-size:8px;">&nbsp;</td></tr>
                </table>
                <%--<div style="VERTICAL-ALIGN: top"> </div>
                <div style="HEIGHT: 30px"></div>
                <div style="VERTICAL-ALIGN: bottom">&nbsp;
                </div>--%>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label id="lbliQty" runat="server" Text='<%# Bind("qty") %>' Width="60px"></asp:Label> 
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Product" SortExpression="product">
            <EditItemTemplate>
                <table>
                <tr>
					<td style="height:15px;">
						<asp:Label id="lbleProd" runat="server" Text='<%# Bind("product") %>' Width="150px"></asp:Label>
					</td>
                </tr>
                <tr>
					<td>
						<asp:DropDownList id="ddlEProd" runat="server" Width="150px" AutoPostBack="True" 
							OnSelectedIndexChanged="ddlEProd_SelectedIndexChanged" DataTextField="product" 
							DataValueField="productID"></asp:DropDownList>
					</td>
                </tr>
                <tr><td style="font-size:8px;">&nbsp;</td></tr>
                </table>
                <%--<BR />
                <div style="HEIGHT: 30px"></div>--%>                 
            </EditItemTemplate>
            <HeaderTemplate>
                <table>
                <tr><td style="height:15px;">PRODUCT</td></tr>
                <tr><td style="height:15px;"></td></tr>
                <tr>
                <td style="height:15px;">
                    <asp:DropDownList id="ddlAProd" runat="server" Width="150px" AutoPostBack="True" 
                    OnSelectedIndexChanged="ddlAProd_SelectedIndexChanged"></asp:DropDownList>
                </td>
                </tr>
                <tr><td style="font-size:8px;">&nbsp;</td></tr>
                </table>
                <%--<div style="VERTICAL-ALIGN: top"></div>
                <div style="HEIGHT: 30px"></div>
                <div style="VERTICAL-ALIGN: bottom">
                &nbsp;</div>--%>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label id="lbliProd" runat="server" Text='<%# Bind("product") %>' Width="150px"></asp:Label> 
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Brand" SortExpression="brand">
            <EditItemTemplate>
                <table>
					<tr>
						<td style="height:15px;">
							<asp:Label id="lbleBrand" runat="server" Text='<%# Bind("brand") %>' Width="120px"></asp:Label>
						</td>
					</tr>
					<tr>
						<td>
							<asp:DropDownList id="ddlEBrand" runat="server" Width="120px" 
								AutoPostBack="True" OnSelectedIndexChanged="ddlEBrand_SelectedIndexChanged"></asp:DropDownList> 
						</td>
					</tr>
                <tr><td style="font-size:8px;">&nbsp;</td></tr>
                </table>
                <%--&nbsp;
                <div style="HEIGHT: 30px"></div>--%>                    
            </EditItemTemplate>
            <HeaderTemplate>
                <table>
                <tr><td style="height:15px;">BRAND</td></tr>
                <tr><td style="height:15px;"></td></tr>
                <tr>
					<td style="height:15px;">
                    <asp:DropDownList id="ddlABrand" runat="server" Width="120px" AutoPostBack="True" 
                        OnSelectedIndexChanged="ddlABrand_SelectedIndexChanged"></asp:DropDownList>
					</td>
				</tr>
                <tr><td style="font-size:8px;">&nbsp;</td></tr>
                </table>
                <%--<div style="VERTICAL-ALIGN: top"></div>
                <div style="HEIGHT: 30px"></div>
                <div style="VERTICAL-ALIGN: bottom">
                    &nbsp;</div>--%>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label id="lbliBrand" runat="server" Text='<%# Bind("brand") %>' Width="120px"></asp:Label> 
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Short Code" SortExpression="shortCode">
            <EditItemTemplate>
                <table>
                <tr>
					<td colspan="2" style="height:15px;">
						<asp:Label id="lbleSCode" runat="server" Text='<%# Bind("shortCode") %>' Width="120px"></asp:Label>
					</td>
                </tr>
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
                <tr><td colspan="2" style="font-size:8px;">&nbsp;</td></tr>
                </table>
                <%--<BR />
                <div style="HEIGHT: 30px"></div>--%>
            </EditItemTemplate>
            <HeaderTemplate>
                <table>
				<tr><td colspan="2" style="font-size:1px;">&nbsp;</td></tr>
                <tr><td colspan="2" style="height:15px;">SHORT CODE</td></tr>
                <tr><td colspan="2" style="font-size:7px;">&nbsp;</td></tr>
                <tr>
					<td style="height:8px;">
						<asp:DropDownList id="ddlaSCode" runat="server" Width="120px"></asp:DropDownList>
					</td>
					<td style="font-size:8px;">
						<asp:ImageButton ID="imbaRef" runat="server" 
							AlternateText="Open Reference Table" Height="25px"
							ImageUrl="~/images/icons/search.png" onclick="imbaRef_Click" 
							ToolTip="Open Reference Table" ></asp:ImageButton>
					</td>
                </tr>
                <tr><td colspan="2" style="font-size:8px;">&nbsp;</td></tr>
                </table>
       
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label id="lbliSCode" runat="server" Text='<%# Bind("shortCode") %>' Width="120px"></asp:Label> 
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Date Purchased" SortExpression="dpurchased">
            <EditItemTemplate>
				<table>
				<tr>
					<td style="height:15px;">
						<asp:Label id="lblEDP" runat="server" Text='<%# Bind("dpurchased") %>' Width="110px"></asp:Label>
					</td>
				</tr>
                <tr>
					<td style="height:15px;">
						<asp:DropDownList ID="ddleDP" runat="server" Width="110px"></asp:DropDownList>
					</td>
				</tr>
				<tr><td align="center" style="font-size:8px;">&nbsp;</td></tr> 
				</table>
            </EditItemTemplate>
            <HeaderTemplate>
				<table>
				<tr><td style="height:15px;">DATE</td></tr>
				<tr><td style="height:15px;">PURCHASED</td></tr>
				<tr>
					<td style="height:15px;">
                    <asp:DropDownList ID="ddlaDP" runat="server" Width="110px"></asp:DropDownList>
					</td>
				</tr>
                <tr><td style="font-size:8px;">&nbsp;</td></tr>
				</table>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label id="lbliDP" runat="server" Text='<%# Bind("dpurchased") %>' Width="110px"></asp:Label> 
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Serial Number" SortExpression="serial">
            <EditItemTemplate>
				<table width="200">
					<tr><td style="height:15px;">&nbsp;</td></tr>
					<tr>
						<td align="center">
							<asp:TextBox id="txtESerial" runat="server" Text='<%# Bind("serial") %>' Width="200px" AutoPostBack="True" ontextchanged="txtESerial_TextChanged"></asp:TextBox>
						</td>
					</tr>
					<tr><td align="center" style="font-size:8px;">&nbsp;</td></tr>
				</table>
            </EditItemTemplate>
            <HeaderTemplate>
				<table width="200">
				<tr><td style="height:15px;">SERIAL</td></tr>
                <tr><td style="height:15px;">NUMBER</td></tr>
				<tr>
					<td style="height:15px;">
					<asp:TextBox id="txtASerial" runat="server" Text='<%# Bind("serial") %>' Width="200px" AutoPostBack="True" ontextchanged="txtASerial_TextChanged"></asp:TextBox>
					</td>
				</tr>
                <tr><td style="font-size:8px;">&nbsp;</td></tr>
				</table>
            </HeaderTemplate>
            
            <ItemTemplate>
				<table width="200">
					<tr>
						<td align="center"><asp:Label id="lbliSerial" runat="server" Text='<%# Bind("serial") %>'></asp:Label></td>
					</tr>
				</table>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Invoice" SortExpression="invoice">
            <EditItemTemplate>
				<table>
					<tr><td style="height:15px;">&nbsp;</td></tr>
					<tr>
						<td>
							<asp:TextBox id="txtEInvoice" runat="server" Text='<%# Bind("invoice") %>' Width="70px"></asp:TextBox>
						</td>
					</tr>
					<tr><td align="center" style="font-size:8px;">&nbsp;</td></tr>
				</table>
            </EditItemTemplate>
            <HeaderTemplate>
				<table>
				<tr><td style="height:15px;">INVOICE</td></tr>
                <tr><td style="height:15px;">NUMBER</td></tr>
				<tr>
					<td style="height:15px;">
					<asp:TextBox id="txtAInvoice" runat="server" Text='<%# Bind("invoice") %>' Width="70px"></asp:TextBox>
					</td>
				</tr>
                <tr><td style="font-size:8px;">&nbsp;</td></tr>
				</table>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label id="lbliInvoice" runat="server" Text='<%# Bind("invoice") %>'></asp:Label> 
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Status" SortExpression="status">
            <EditItemTemplate>
				<table align="center">
                <tr><td style="height:15px;">&nbsp;</td></tr>
                <tr>
					<td>
						<asp:Label id="lbleStatus" runat="server" Text='<%# Bind("recStatus") %>'></asp:Label>
					</td>
				</tr>
				<tr>
					<td align="center" style="font-size:8px;">&nbsp;</td>
				</tr> 
                </table>
            </EditItemTemplate>
            <HeaderTemplate>
				<table align="center">
				<tr><td style="height:15px;">STATUS</td></tr>
				<tr><td style="height:15px;"></td></tr>
				<tr>
					<td style="height:15px;">
                    <asp:Label id="lblaStatus" runat="server" Text='<%# Bind("recStatus") %>'></asp:Label>
					</td>
				</tr>
                <tr><td style="font-size:8px;">&nbsp;</td></tr>
				</table>
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
                                ToolTip="Save" ImageUrl="~/images/icons/save.png" AlternateText="Update Record" 
                                    CausesValidation="False"></asp:ImageButton> 
                        </div>
                        <div style="width:40px; float:right;">
                            <asp:ImageButton id="imbACancel" runat="server" Text="Select" 
                                CommandName="Cancel" ToolTip="Cancel" 
                                ImageUrl="~/images/icons/cancel.png" AlternateText="Delete Record" 
                                CausesValidation="False"></asp:ImageButton>
                        </div>  
                    </div>
                </div>
            </EditItemTemplate>
            <HeaderTemplate>
				<table align="center">
				<tr><td style="height:15px;">&nbsp;</td></tr>
				<tr><td style="height:15px;">&nbsp;</td></tr>
				<tr>
					<td style="height:10px;">
						<asp:ImageButton id="imbASave" onclick="imbASave_Click" runat="server" ToolTip="Save Record" ImageUrl="~/images/icons/save.png" AlternateText="Save Record"></asp:ImageButton>
					</td>
				</tr>
				<tr><td style="font-size:8px;">&nbsp;</td></tr>
				</table>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Panel ID="panModify" runat="server">
                    
                    <div style="width:80px;">
                        <div style="width:40px; float:left;">
                            <asp:ImageButton id="imbAModify" runat="server" 
                                CommandName="Edit" ImageUrl="~/Images/icons/modify.png" 
                                AlternateText="Modify Record" ToolTip="Modify Record">
                            </asp:ImageButton>
                        </div>
                        <div style="width:40px; float:right;">
                            <asp:LinkButton id="lnkADelete" 
                                onclick="lnkADelete_Click" runat="server" CssClass="deleteBtn" 
                                CommandArgument='<%# Eval("salesID") %>' causesvalidation="false"
								AlternateText="Delete Record" ToolTip="Delete Record"></asp:LinkButton> 
                        </div>
                    </div>
                    </asp:Panel> 
                    <asp:Panel ID="panDelete" runat="server">
						<div style="width:80px;">
							<asp:Label id="lblAConfirm" runat="server" Text="Are you sure?" CssClass="errMsg" Visible="False"></asp:Label> 
						</div>
						<div style="width:40px; float:left;">
							<asp:ImageButton id="imbAYes" 
								onclick="imbAYes_Click" runat="server" Visible="False" 
								ImageUrl="~/images/icons/yes.png" ToolTip="Yes">
							</asp:ImageButton>
						</div>
						<div style="width:40px; float:right;">
							<asp:ImageButton id="imbANo" 
								onclick="imbANo_Click" runat="server" Visible="False" 
								ImageUrl="~/images/icons/cancel.png" ToolTip="No">
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


<!-- COMPETITOR SALES-->

<asp:Panel id="panCompete" runat="server" visible="false"><BR />

<asp:GridView id="grdCompetitor" runat="server" CssClass="gridRow" 
    Enabled="False" AutoGenerateColumns="False" BorderColor="Black" 
    DataKeyNames="competeID" DataSourceID="sqlDS_Competitor" PageSize="30" 
    ShowFooter="True" AllowSorting="True" Width="75%">
    
    <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom"></PagerSettings>

<Columns>
<asp:BoundField DataField="competeID" HeaderText="ID" Visible="False"></asp:BoundField>

<asp:TemplateField HeaderText="Product" SortExpression="cProduct">
	<EditItemTemplate></EditItemTemplate>
	<HeaderTemplate>
		<div style="VERTICAL-ALIGN: top">PRODUCT</div>
		<div style="VERTICAL-ALIGN: top">&nbsp;</div>
		<div style="VERTICAL-ALIGN: bottom">
			<asp:DropDownList ID="ddlACProduct" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlACProdProduct_SelectedIndexChanged">
				<asp:ListItem></asp:ListItem>
				<asp:ListItem Value="1">WRAC</asp:ListItem>
				<asp:ListItem Value="2">Split</asp:ListItem>
			</asp:DropDownList>
	</HeaderTemplate>
	<ItemTemplate>
        <asp:Label id="cProductLabel" runat="server" Text='<%# Bind("cProductID") %>'></asp:Label> 
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Brand" SortExpression="cBrand">
		<EditItemTemplate>
		<asp:Label runat="server" id="lbleCBrand" Text='<%# Bind("cBrand") %>'></asp:Label><br/>
		<asp:DropDownList id="ddlECBrand" runat="server"></asp:DropDownList>
		</EditItemTemplate>
		<HeaderTemplate>
			<div style="VERTICAL-ALIGN: top">BRAND</div>
			<div style="VERTICAL-ALIGN: top">&nbsp;</div>
			<div style="VERTICAL-ALIGN: bottom">
				<asp:DropDownList id="ddlACBrand" runat="server"></asp:DropDownList>
		</HeaderTemplate>
		<ItemTemplate>
        <asp:Label id="lbliCBrand" runat="server" Text='<%# Bind("cBrand") %>'></asp:Label> 
		</ItemTemplate>
	</asp:TemplateField>

<asp:TemplateField HeaderText="Capacity" SortExpression="capacity">
    <EditItemTemplate>
        <asp:Label runat="server" id="lbleCCap" Text='<%# Bind("cCapacity") %>'></asp:Label><br/>
        <asp:DropDownList id="ddleCCap" runat="server"></asp:DropDownList>
    </EditItemTemplate>
    <HeaderTemplate>
        <div style="VERTICAL-ALIGN: top">CAPACITY</div>
        <div style="VERTICAL-ALIGN: top">&nbsp;</div>
        <div style="VERTICAL-ALIGN: bottom">
            <asp:DropDownList id="ddlaCCap" runat="server"></asp:DropDownList>
    </HeaderTemplate>
    <ItemTemplate>
        <asp:Label id="lbliCCap" runat="server" Text='<%# Bind("cCapacity") %>'></asp:Label> 
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Qty" SortExpression="qty">
    <EditItemTemplate>
        <div style="VERTICAL-ALIGN: bottom">&nbsp;</div>
		<asp:TextBox ID="ddleCQty" Text='<%# Bind("qty") %>' runat="server" MaxLength="3"></asp:TextBox>
	</EditItemTemplate>
    <HeaderTemplate>
        <div style="VERTICAL-ALIGN: top">QTY</div>
        <div style="VERTICAL-ALIGN: top">&nbsp;</div>
        <div style="VERTICAL-ALIGN: top">
            <asp:TextBox ID="ddlaCQty" Text='<%# Bind("qty") %>' runat="server" MaxLength="3"></asp:TextBox>
		</div>
    </HeaderTemplate>
    <ItemTemplate>
        <asp:Label id="lbliCQty" runat="server" Text='<%# Bind("qty") %>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Date" SortExpression="csDate">
    <EditItemTemplate>
        <asp:Label id="lbleCDate" runat="server" Text='<%# Bind("csDate") %>'></asp:Label><br/>
        <asp:DropDownList id="ddleCDate" runat="server"></asp:DropDownList>
    </EditItemTemplate>
    <HeaderTemplate>
        <div style="VERTICAL-ALIGN: top">DATE</div>
        <div style="VERTICAL-ALIGN: top">&nbsp;</div>
        <div style="VERTICAL-ALIGN: top">
            <asp:DropDownList id="ddlaCDate" runat="server"></asp:DropDownList>
        </div>
    </HeaderTemplate>
    <ItemTemplate>
        <asp:Label id="lbliCDate" runat="server" Text='<%# Bind("csDate") %>'></asp:Label> 
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Factors Affecting Sell Out" SortExpression="factor">
    <EditItemTemplate>
		<div style="VERTICAL-ALIGN: bottom">&nbsp;</div>
        <asp:TextBox id="txteFactor" runat="server" Text='<%# Bind("factor") %>'></asp:TextBox> 
    </EditItemTemplate>
    <HeaderTemplate>
        <div style="VERTICAL-ALIGN: top">FACTORS AFFECTING SELL OUT</div>
        <div style="VERTICAL-ALIGN: top">&nbsp;</div>
        <div style="VERTICAL-ALIGN: top">
            <asp:TextBox id="txtaFactor" runat="server" Text='<%# Bind("factor") %>'></asp:TextBox>
        </div>
    </HeaderTemplate>
    <ItemTemplate>
        <asp:Label id="lbliFactor" runat="server" Text='<%# Bind("factor") %>'></asp:Label> 
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
		<div style="width:80px;">
			<div style="width:40px; float:left;">
				<asp:ImageButton id="imbCUpdate" runat="server" Text="Select" CommandName="Update" ToolTip="Modify Record" ImageUrl="~/images/icons/save.png" AlternateText="Update Record" CausesValidation="False"></asp:ImageButton> 
			</div>
			<div style="width:40px; float:right;">
				<asp:ImageButton id="imbCCancel" runat="server" Text="Select" CommandName="Cancel" ToolTip="Delete Record" ImageUrl="~/images/icons/cancel.png" AlternateText="Delete Record" CausesValidation="False"></asp:ImageButton>
			</div>
		</div>
    </EditItemTemplate>
    <HeaderTemplate>
		<div style="VERTICAL-ALIGN: top">&nbsp;</div>
		<div style="VERTICAL-ALIGN: top">&nbsp;</div>
		<div style="VERTICAL-ALIGN: top"><asp:ImageButton ID="imbCSave" OnClick="imbCSave_Click" runat="server" ToolTip="Save Record" ImageUrl="~/images/icons/save.png" AlternateText="Save Record"></asp:ImageButton></div>
    </HeaderTemplate>
    <ItemTemplate>
		<div style="width:80px;">
			<div style="width:80px;">
				<div style="width:40px; float:left;">
					<asp:ImageButton id="imbCModify" runat="server" CommandName="Edit" ImageUrl="~/Images/icons/modify.png" AlternateText="Modify Record" ToolTip="Modify Record"></asp:ImageButton>
				</div>
				 <div style="width:40px; float:right;">
					<asp:LinkButton id="lnkCDelete" onclick="lnkCDelete_Click" runat="server" CssClass="deleteBtn" CommandArgument='<%# Eval("competeID") %>' causesvalidation="false" AlternateText="Delete Record" ToolTip="Delete Record"></asp:LinkButton>
				</div>
			</div>
			<div style="width:80px;">
				<asp:Label id="lblCConfirm" runat="server" Text="Are you sure?" CssClass="errMsg" Visible="False"></asp:Label>
			</div>
			<div style="width:40px; float:left;">
				<asp:ImageButton id="imbCYes" onclick="imbCYes_Click" runat="server" Visible="False" ImageUrl="~/images/icons/yes.png"></asp:ImageButton>
			</div>
			<div style="width:40px; float:right;">
				<asp:ImageButton id="imbCNo" onclick="imbCNo_Click" runat="server" Visible="False" ImageUrl="~/images/icons/cancel.png"></asp:ImageButton>
			</div>
		</div>
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


<!-- STOCKS RUN OUT-->

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
                        <asp:Label ID="lbleSProd" runat="server" Text='<%# Bind("product") %>'></asp:Label>
                        <asp:DropDownList id="ddlESProd" runat="server" AutoPostBack="True" onselectedindexchanged="ddlESProd_SelectedIndexChanged"></asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <div style="VERTICAL-ALIGN: top">PRODUCT</div>
                        <div style="VERTICAL-ALIGN: top">&nbsp;</div>
                        <div style="VERTICAL-ALIGN: bottom">
                            <asp:DropDownList id="ddlASProd" runat="server" AutoPostBack="True" onselectedindexchanged="ddlASProd_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbliSProd" runat="server" Text='<%# Bind("product") %>' 
                            Width="150px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Brand" SortExpression="brand">
                    <EditItemTemplate>
                        <asp:Label ID="lbleSBrand" runat="server" Text='<%# Bind("brand") %>'></asp:Label>
                        <asp:DropDownList id="ddlESBrand" runat="server" AutoPostBack="True" onselectedindexchanged="ddlESBrand_SelectedIndexChanged"></asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <div style="VERTICAL-ALIGN: top">BRAND</div>
                        <div style="VERTICAL-ALIGN: top">&nbsp;</div>
                        <div style="VERTICAL-ALIGN: bottom">
                            <asp:DropDownList id="ddlASBrand" runat="server" AutoPostBack="True" onselectedindexchanged="ddlASBrand_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbliSBrand" runat="server" Text='<%# Bind("brand") %>' Width="150px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Short Code" SortExpression="shortCode">
                    <EditItemTemplate>
                            <asp:Label ID="lbleSSCode" runat="server" Text='<%# Bind("shortCode") %>'></asp:Label>
                            <asp:DropDownList id="ddlESSCode" runat="server" Width="120px"></asp:DropDownList><asp:ImageButton ID="imbeSRef" runat="server" AlternateText="Open Reference Table" Height="25px" ImageUrl="~/images/icons/search.gif" onclick="imbeSRef_Click" ToolTip="Open Reference Table" ImageAlign="AbsMiddle"></asp:ImageButton>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <div style="VERTICAL-ALIGN: top">SHORT CODE</div>
						<div style="VERTICAL-ALIGN: top">&nbsp;</div>
						<div style="VERTICAL-ALIGN: bottom">
							<asp:DropDownList id="ddlASSCode" runat="server" Width="120px"></asp:DropDownList><asp:ImageButton ID="imbaSRef" runat="server" AlternateText="Open Reference Table" Height="25px" ImageUrl="~/images/icons/search.png" onclick="imbaSRef_Click" ToolTip="Open Reference Table" ImageAlign="AbsMiddle"></asp:ImageButton>
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbliSSCode" runat="server" Text='<%# Bind("shortCode") %>' Width="150px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="When" SortExpression="dWhen">
                    <EditItemTemplate>
                        <asp:Label ID="lbleWhen" runat="server" Text='<%# Bind("dWhen") %>'></asp:Label>
                        <asp:DropDownList id="ddleWhen" runat="server"></asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <div style="VERTICAL-ALIGN: top">WHEN</div>
                        <div style="VERTICAL-ALIGN: top">&nbsp;</div>
                        <div style="VERTICAL-ALIGN: bottom">
                            <asp:DropDownList id="ddlaWhen" runat="server"></asp:DropDownList>
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbliWhen" runat="server" Text='<%# Bind("dWhen") %>' Width="120px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Action Taken" SortExpression="actionTaken">
                    <EditItemTemplate>
                        <asp:Label ID="lbleAction" runat="server" Text='<%# Bind("actTake") %>'></asp:Label>
                        <asp:DropDownList id="ddleAction" runat="server" AutoPostBack="True" onselectedindexchanged="ddleAction_SelectedIndexChanged"></asp:DropDownList>
                        <asp:TextBox ID="txteAction" runat="server" Width="200px" Text='<%# Bind("otherAct") %>' visible="false" AutoPostBack="True"></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <div style="VERTICAL-ALIGN: top">ACTION TAKEN</div>
                        <div style="VERTICAL-ALIGN: top">&nbsp;</div>
                        <div style="VERTICAL-ALIGN: bottom">
                            <asp:DropDownList id="ddlaAction" runat="server" AutoPostBack="True" onselectedindexchanged="ddlaAction_SelectedIndexChanged"></asp:DropDownList>
                            <asp:TextBox ID="txtaAction" runat="server" Width="200px" visible="false" AutoPostBack="True"></asp:TextBox>
						</div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbliAction" runat="server" Text='<%# Bind("actTake") %>' Width="130px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Competitor Promo Activities" SortExpression="promo">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtePromo" runat="server" Text='<%# Bind("promo") %>' Width="220px"></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <div style="VERTICAL-ALIGN: top">COMPETITOR PROMO ACTIVITIES</div>
                        <div style="VERTICAL-ALIGN: top">&nbsp;</div>
                        <div style="VERTICAL-ALIGN: bottom">
							<asp:TextBox ID="txtaPromo" runat="server" Text='<%# Bind("promo") %>' Width="220px"></asp:TextBox>
						</div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbliPromo" runat="server" Text='<%# Bind("promo") %>' Width="220px"></asp:Label>
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
                                            CommandName="Update" ImageUrl="~/images/icons/save.png" Text="Select" ToolTip="Modify Record" />
                                </div>
                                <div style="width:40px; float:right;">
                                        <asp:ImageButton ID="imbSCancel" runat="server" AlternateText="Delete Record" CausesValidation="False"
                                            CommandName="Cancel" ImageUrl="~/images/icons/cancel.png" Text="Select" ToolTip="Delete Record" />
                                </div>
                        </div>
                    </EditItemTemplate>
                    <HeaderTemplate>
						<div style="VERTICAL-ALIGN: top">&nbsp;</div>
						<div style="VERTICAL-ALIGN: top">&nbsp;</div>
                        <asp:ImageButton ID="imbSSave" runat="server" AlternateText="Save Record" ImageUrl="~/images/icons/save.png" OnClick="imbSSave_Click" ToolTip="Save Record" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div style="width:80px;">
                            <div style="width:80px;">
                                <div style="width:40px; float:left;">
                                        <asp:ImageButton ID="imbSModify" runat="server" AlternateText="Modify Record" CommandName="Edit"
                                            ImageUrl="~/Images/icons/modify.png" ToolTip="Modify Record" />
                                </div>
                                <div style="width:40px; float:right;">
                                        <asp:LinkButton ID="lnkSDelete" runat="server" CausesValidation="false" CommandArgument='<%# Eval("stocksID") %>'
                                            CssClass="deleteBtn" OnClick="lnkSDelete_Click" AlternateText="Delete Record" ToolTip="Delete Record"></asp:LinkButton>
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
                                        <asp:ImageButton ID="imbSNo" runat="server" ImageUrl="~/images/icons/cancel.png"
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
    
<!-- STOCKS INVENTORY -->

    <asp:Panel ID="panInventory" runat="server" Visible="false"><BR />
        <asp:GridView id="grdInventory" runat="server" CssClass="gridRow" Enabled="False" AutoGenerateColumns="False" BorderColor="Black" DataKeyNames="inventoryID" DataSourceID="sqlDS_Inventory" PageSize="30" ShowFooter="True" AllowSorting="True" Width="80%">
            <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
            <RowStyle CssClass="RowStyle" />
            <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
            
            <Columns>
                <asp:BoundField DataField="inventoryID" HeaderText="ID" Visible="False" />
            
                <asp:TemplateField HeaderText="Product" SortExpression="product">
                    <EditItemTemplate>
                        <asp:Label ID="lbleIProd" runat="server" Text='<%# Bind("product") %>'></asp:Label>
                        <asp:DropDownList id="ddleIProd" runat="server" AutoPostBack="True" onselectedindexchanged="ddleIProd_SelectedIndexChanged"></asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <div style="VERTICAL-ALIGN: top">PRODUCT</div>
                        <div style="VERTICAL-ALIGN: top">&nbsp;</div>
                        <div style="VERTICAL-ALIGN: bottom">
                            <asp:DropDownList id="ddlaIProd" runat="server" AutoPostBack="True" onselectedindexchanged="ddlaIProd_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbliIProd" runat="server" Text='<%# Bind("product") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Brand" SortExpression="brand">
                    <EditItemTemplate>
                        <asp:Label ID="lbleIBrand" runat="server" Text='<%# Bind("brand") %>'></asp:Label>
                        <asp:DropDownList id="ddleIBrand" runat="server" AutoPostBack="True" onselectedindexchanged="ddleIBrand_SelectedIndexChanged"></asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <div style="VERTICAL-ALIGN: top">BRAND</div>
                        <div style="VERTICAL-ALIGN: top">&nbsp;</div>
                        <div style="VERTICAL-ALIGN: bottom">
                            <asp:DropDownList id="ddlaIBrand" runat="server" AutoPostBack="True" onselectedindexchanged="ddlaIBrand_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbliIBrand" runat="server" Text='<%# Bind("brand") %>' Width="150px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Short Code" SortExpression="shortCode">
                    <EditItemTemplate>
						<asp:Label ID="lbleISCode" runat="server" Text='<%# Bind("shortCode") %>'></asp:Label>    
						<asp:DropDownList id="ddleISCode" runat="server" Width="150px" AutoPostBack="True"></asp:DropDownList>
						<asp:ImageButton ID="imbeIRef" runat="server" AlternateText="Open Reference Table" Height="23px" ImageUrl="~/images/icons/search.gif" onclick="imbeIRef_Click" ToolTip="Open Reference Table" ImageAlign="AbsMiddle"></asp:ImageButton>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <div style="VERTICAL-ALIGN: top">SHORT CODE</div>
                        <div style="VERTICAL-ALIGN: top">&nbsp;</div>
						<asp:DropDownList id="ddlaISCode" runat="server" Width="150px"  AutoPostBack="True"></asp:DropDownList>
						<asp:ImageButton ID="imbaIRef" runat="server" AlternateText="Open Reference Table" Height="23px" ImageUrl="~/images/icons/search.png" onclick="imbaIRef_Click" ToolTip="Open Reference Table" ImageAlign="AbsMiddle"></asp:ImageButton>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbliISCode" runat="server" Text='<%# Bind("shortCode") %>' Width="150px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Qty" SortExpression="qty">
                    <EditItemTemplate>
                        <asp:TextBox ID="ddleIQty" width="40px" Text='<%# Bind("qty") %>' runat="server" MaxLength="3"></asp:TextBox>
					</EditItemTemplate>
                    <HeaderTemplate>
                        <div style="VERTICAL-ALIGN: top">QTY</div>
                        <div style="VERTICAL-ALIGN: top">&nbsp;</div>
                        <div style="VERTICAL-ALIGN: top">
							<asp:TextBox ID="ddlaIQty" width="40px" Text='<%# Bind("qty") %>' runat="server" MaxLength="3"></asp:TextBox>
					</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbliIQty" runat="server" Text='<%# Bind("qty") %>' Width="40px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Comments &amp; Suggestion" SortExpression="comments">
                    <EditItemTemplate>
                         <asp:TextBox ID="txteComments" runat="server" Text='<%# Bind("comments") %>' Width="220px"></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <div style="VERTICAL-ALIGN: top">COMMENTS &amp; SUGGESTIONS</div>
                        <div style="VERTICAL-ALIGN: top">&nbsp;</div>
                        <div style="VERTICAL-ALIGN: top">
                            <asp:TextBox ID="txtaComments" runat="server" Text='<%# Bind("comments") %>' Width="220px"></asp:TextBox>
						</div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbliComments" runat="server" Text='<%# Bind("comments") %>' Width="220px"></asp:Label>
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
                                    CommandName="Update" ImageUrl="~/images/icons/save.png" Text="Select" ToolTip="Modify Record" />
                            </div>
                            <div style="width:40px; float:right;">
                                <asp:ImageButton ID="imbICancel" runat="server" AlternateText="Delete Record" CausesValidation="False"
                                    CommandName="Cancel" ImageUrl="~/images/icons/cancel.png" Text="Select" ToolTip="Delete Record" />
                            </div>
                        </div>
                    </EditItemTemplate>
                    <HeaderTemplate>
						<div style="VERTICAL-ALIGN: top">&nbsp;</div>
						<div style="VERTICAL-ALIGN: top">&nbsp;</div>
                        <asp:ImageButton ID="imbISave" runat="server" AlternateText="Save Record" ImageUrl="~/images/icons/save.png" OnClick="imbISave_Click" ToolTip="Save Record" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div style="width:80px;">
                            <div style="width:80px;">
                                <div style="width:40px; float:left;">
                                    <asp:ImageButton ID="imbIModify" runat="server" AlternateText="Modify Record" CommandName="Edit"
                                        ImageUrl="~/Images/icons/modify.png" ToolTip="Modify Record" />
                                </div>
                                <div style="width:40px; float:right;">
                                    <asp:LinkButton ID="lnkIDelete" runat="server" CausesValidation="false" CommandArgument='<%# Eval("inventoryID") %>'
                                            CssClass="deleteBtn" OnClick="lnkIDelete_Click" AlternateText="Delete Record" ToolTip="Delete Record">
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
                                    <asp:ImageButton ID="imbINo" runat="server" ImageUrl="~/images/icons/cancel.png"
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
</div>


</ContentTemplate>
</asp:UpdatePanel> 
</div>  
</center>

</asp:Content>