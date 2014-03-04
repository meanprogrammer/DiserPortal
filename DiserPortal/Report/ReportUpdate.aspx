<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ReportUpdate.aspx.vb" Inherits="DiserPortal.ReportUpdate" %>
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
            
								<div style="padding: 10px; vertical-align:top;float:left;">
									<asp:Image runat="server" Height="20px" ImageUrl="~/images/icons/loading.gif" />
								</div>
								<%--<div style="padding:15px; text-align:left;vertical-align:middle;float:right;">
								<asp:Image runat="server" Height="20px" ImageUrl="~/images/icons/loading.gif" />
								</div>--%>
							</progresstemplate>
						</asp:UpdateProgress>
					</div>
					<div id="tab_wrap">
						<ul class="tabprop">
							<li id="lProd" runat="server"><br />
								<asp:LinkButton id="lnkProd" runat="server" CssClass="tabprop-Selected" Text="BI Sales<br/>Report"></asp:LinkButton>
							</li>
							<li id="lTMSales" runat="server"><br />
								<asp:LinkButton ID="lnkTMSales" runat="server" CssClass="tabprop" Text="TM Sales<br/>Report"></asp:LinkButton>
							</li>
							<li id="lCompete" runat="server"><br />
								<asp:LinkButton ID="lnkCompete" runat="server" CssClass="tabprop" Text="Competitor<br/>Sales Report"></asp:LinkButton>
							</li>
							<li id="lStocks" runat="server"><br />
								<asp:LinkButton ID="lnkStocks" runat="server" CssClass="tabprop" Text="Stock Runs<br/>Out Report"></asp:LinkButton>
							</li>
							<li id="lInventory" runat="server"><br />
								<asp:LinkButton ID="lnkInventory" runat="server" CssClass="tabprop" Text="Stocks Inventory<br/>Report"></asp:LinkButton>
							</li>
						</ul>
					</div>
				</div>
				<!-- end tab wrap -->

				<div id="cont_wrap">
					<div style="height:15px; color:Red;font-weight:bolder;bgcolor:dimgray;vertical-align:bottom;padding:7px;">
						<asp:Label ID="lbleMsg" runat="server" ForeColor="red" text=""></asp:Label>
					</div>
					<!-- INFO -->
					<asp:Panel ID="panInfo" runat="server" visible="false" style="height:250px; overflow-y:scroll; overflow-x:none;width:80%; border:2px solid black;" >

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
											<asp:ImageButton ID="imbClose" runat="server" ImageUrl="~/images/icons/cancel.png" ></asp:ImageButton>
										</div>
									</div>
									</td>
								</tr>
								<tr>
									<td>&nbsp;</td>
								</tr>
							</table>
						</p>

						<div>
							<asp:GridView ID="grdInfo" runat="server" AutoGenerateColumns="False" CssClass="gridRow" DataKeyNames="itemID" DataSourceID="sqlDS_Info" ShowFooter="True" Width="95%">
								<FooterStyle BackColor="#312515" Font-Size="12px" />
								<HeaderStyle BackColor="#312515" Font-Bold="True" Font-Size="14px" ForeColor="White" />
								<PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
								<EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
								<AlternatingRowStyle BackColor="#F8DCB1" Font-Size="12px" ForeColor="Black" />
								<Columns>
									<asp:BoundField DataField="itemID" HeaderText="" Visible="False"></asp:BoundField>
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
									<div style="text-align:center; vertical-align:middle;">No Records Found!</div>
								</EmptyDataTemplate>
								<EditRowStyle CssClass="EditRowStyle" />
								<RowStyle BackColor="#FBEC99" Font-Size="12px" ForeColor="Black" />
							</asp:GridView>
						</div>
					</asp:Panel>


					<!-- BI SALES -->
					<asp:Panel ID="panSales" runat="server">
						<div style="text-align:left; padding-left:25px;">
							<table width="100%">
								<asp:Panel ID="panFilter" runat="server">
									<table width="800">
										<tr>
											<td width="120">Filter By:</td>
											<td width="20">&nbsp;</td>
											<td width="250">
												<asp:DropDownList ID="ddlFilter" runat="server" AutoPostBack="True">
													<asp:ListItem></asp:ListItem>
													<asp:ListItem Value="2">Weekly</asp:ListItem>
													<asp:ListItem Value="3">Monthly</asp:ListItem>
													<asp:ListItem Value="4">Yearly</asp:ListItem>
												</asp:DropDownList>
											</td>
											<td width="20">&nbsp;</td>
											<asp:Panel ID="pnlUtype" runat="server">
												<td>User Type: </td>
												<td>&nbsp;</td>
												<td>
                                                <asp:DropDownList ID="ddlUserType" runat="server" AutoPostBack="True">
                                                    <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Field Coordinator" />
                                                    <asp:ListItem Value="2" Text="Promodiser" />
                                                </asp:DropDownList>
                                                </td>
												<td>&nbsp;</td>
											</asp:Panel>
										</tr>

										<tr>
											<td><asp:Label ID="lblDate" runat="server" Text="Date Coverage:" Visible="False"></asp:Label></td>
											<td>&nbsp;</td>
											<td>
												<asp:DropDownList ID="ddlDate" runat="server" AutoPostBack="True" Visible="False"></asp:DropDownList>
											</td>
											<td>&nbsp;</td>
											<td width="150"><asp:Label ID="FCPromoLabel" runat="server" Text="" /></td>
											<td width="20">&nbsp;</td>
											<td width="200">
												<asp:DropDownList ID="ddlEmp" runat="server" Visible="false" AutoPostBack="True"></asp:DropDownList>
<%--                                                <asp:Panel ID="pnlFC" runat="server" Visible="false">
												    <td>Field Coordinator:</td>
												    <td>&nbsp;</td>
												    <td>--%>
                                                    <asp:DropDownList ID="ddlFC" runat="server" Visible="false" AutoPostBack="True"></asp:DropDownList>
		<%--										</td><td>&nbsp;</td>--%>
											<%--</asp:Panel>--%>
											</td>
											<td width="20">&nbsp;</td>
										</tr>
										<tr>
											<td colspan="8">&nbsp;</td>
										</tr>
									</table>
								</asp:Panel>
		
								<tr>
									<td>
										<asp:GridView ID="grdSales" runat="server" AutoGenerateColumns="False" CssClass="gridRow" DataKeyNames="subID" DataSourceID="sqlDS_Sales" PageSize="30" ShowFooter="True" Width="95%" AllowPaging="True" AllowSorting="True">
										<PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
										<RowStyle CssClass="RowStyle" />
										<EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
										<Columns>
											<asp:CommandField ButtonType="Image" SelectImageUrl="~/images/icons/modify.png" ShowSelectButton="True">
											</asp:CommandField>
											<asp:BoundField DataField="subID" Visible="False"></asp:BoundField>
											<asp:BoundField DataField="dealer" HeaderText="Dealer" SortExpression="dealer"></asp:BoundField>
											<asp:BoundField DataField="location" HeaderText="Store Location" SortExpression="location"></asp:BoundField>
											<asp:BoundField DataField="parentBP" HeaderText="Parent BP" SortExpression="parentBP"></asp:BoundField>
											<asp:BoundField DataField="childBP1" HeaderText="Child BP1" SortExpression="childBP1"></asp:BoundField>
											<asp:BoundField DataField="childBP2" HeaderText="Child BP2" SortExpression="childBP2"></asp:BoundField>
											<asp:BoundField DataField="childBP3" HeaderText="Child BP3" SortExpression="childBP3"></asp:BoundField>
											<asp:BoundField DataField="Region" HeaderText="Region" SortExpression="region"></asp:BoundField>
											<asp:BoundField DataField="product" HeaderText="Product" SortExpression="product"></asp:BoundField>
											<asp:BoundField DataField="brand" HeaderText="Brand" SortExpression="brand"></asp:BoundField>
											<asp:BoundField DataField="shortCode" HeaderText="Short Code" SortExpression="shortCode"></asp:BoundField>
											<asp:BoundField DataField="model" HeaderText="Model" SortExpression="model"></asp:BoundField>
											<asp:BoundField DataField="capacity" HeaderText="Capacity" SortExpression="capacity"></asp:BoundField>
											<asp:BoundField DataField="variant" HeaderText="Variant" SortExpression="variant"></asp:BoundField>
											<asp:BoundField DataField="longCode" HeaderText="Long Code" SortExpression="longCode"></asp:BoundField>
											<asp:BoundField DataField="dPurchased" HeaderText="Purchased Date" SortExpression="dPurchased"></asp:BoundField>
											<asp:BoundField DataField="qty" HeaderText="Qty" SortExpression="qty"></asp:BoundField>
											<asp:BoundField DataField="empName" HeaderText="Employee" SortExpression="empName"></asp:BoundField>
											<asp:BoundField DataField="dSubmitted" HeaderText="Submission Date" SortExpression="dSubmitted"></asp:BoundField>
											<asp:BoundField DataField="subID" InsertVisible="False" ReadOnly="True">
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
										<FooterStyle CssClass="FooterStyle" />
										<PagerTemplate>
											<table align="center">
												<tbody>
													<tr valign="middle">
														<td>
															<asp:ImageButton ID="imbFirst" runat="server" AlternateText="First Page" CommandArgument="First" CommandName="Page" 	ImageUrl="~/images/icons/first.gif" />
															<asp:ImageButton ID="imbPrev" runat="server" AlternateText="Previous Page" CommandArgument="Prev" CommandName="Page" ImageUrl="~/images/icons/prev.gif" />
														</td>
														<td>
															Page&nbsp;
															<asp:DropDownList ID="ddlPageNo" runat="server" AutoPostBack="true" Width="50px" onselectedindexchanged="ddlPageNo_SelectedIndexChanged">
															</asp:DropDownList>
															&nbsp;of&nbsp;
															<asp:Label ID="lblPageCount" runat="server"></asp:Label>
														</td>
														<td>
															<asp:ImageButton ID="imbNext" runat="server" AlternateText="Next Page" CommandArgument="Next" CommandName="Page" ImageUrl="~/images/icons/next.gif" />
															<asp:ImageButton ID="imbLast" runat="server" AlternateText="Last Page" CommandArgument="Last" CommandName="Page" ImageUrl="~/images/icons/last.gif" />
														</td>
													</tr>
												</tbody>
											</table>
										</PagerTemplate>
										<PagerStyle CssClass="PagerRowStyle" />
										<HeaderStyle CssClass="HeaderStyle" />
										<EditRowStyle CssClass="EditRowStyle" />
										<AlternatingRowStyle CssClass="AlternatingRowStyle" />
										<SelectedRowStyle Font-Bold="True" />
									</asp:GridView>

      
                <!-- panData -->
									<div>
										<asp:Panel ID="panData" runat="server" Visible="False" width="100%">
											<table style="padding-left:30px;">
												<tr>
													<td align="left">&nbsp;</td>
													<td align="left">&nbsp;</td>
												</tr>
												<tr>
													<td align="left" valign="top" colspan="2">
														<h3 style="padding-bottom:15px;">Customer Information</h3>
													</td>
												</tr>
												<tr>
													<td align="left" valign="top">
														Name:
													</td>
													<td align="left" style="font-size: 9px;">
														<asp:TextBox ID="txtFname" runat="server" ReadOnly="True" Width="220px"></asp:TextBox>
														<asp:TextBox ID="txtLname" runat="server" ReadOnly="True" Width="225px"></asp:TextBox>
														<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; First 
            Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; Last Name
													</td>
												</tr>
												<tr>
													<td align="left">Address:</td>
													<td align="left">
														<asp:TextBox ID="txtAdd" runat="server" ReadOnly="True" Width="245px"></asp:TextBox>
														<asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="True" Enabled="False" Width="200px"></asp:DropDownList>
													</td>
												</tr>

												<tr>
													<td align="left" valign="top">Contact No/s:</td>
													<td align="left">
														<asp:TextBox ID="txtContact" runat="server" ReadOnly="True" Rows="10" Width="445px"></asp:TextBox>
													</td>
												</tr>

												<tr>
													<td align="left" valign="top">&nbsp;</td>
													<td align="left">&nbsp;</td>
												</tr>
												<tr>
													<td align="left" colspan="2" valign="top">
														<h3 style="padding-bottom:15px;">Product Details</h3>
													</td>
												</tr>

												<tr>
													<td align="left" valign="top">Product:</td>
													<td align="left">
														<asp:DropDownList ID="ddlProd" runat="server" AutoPostBack="True" Enabled="False" Width="450px"></asp:DropDownList>
													</td>
												</tr>

												<tr>
													<td align="left" valign="top">Brand:</td>
													<td align="left">
														<asp:DropDownList ID="ddlDBrand" runat="server" Width="450px" Enabled="False" AutoPostBack="True"></asp:DropDownList>
													</td>
												</tr>

												<tr>
													<td align="left" valign="top">
													Short Code:
													<asp:ImageButton ID="imbShow" runat="server" AlternateText="Save" ImageUrl="~/images/icons/search.png" ToolTip="Search Short Code" />
													</td>
													<td align="left">
													<asp:DropDownList ID="ddlSCode" runat="server" Width="450px" Enabled="False"></asp:DropDownList>
													</td>
												</tr>

												<tr>
													<td align="left" valign="top">Quantity:</td>
													<td align="left">
														<asp:TextBox ID="txtQty" runat="server" ReadOnly="True" Rows="10" Width="445px" MaxLength="3"></asp:TextBox>
													</td>
												</tr>

												<tr>
													<td align="left" valign="top" width="150px">Date Purchased:</td>
													<td align="left" style="font-size: 9px;">
														<asp:DropDownList ID="ddlWeek" runat="server" Enabled="False" Width="225px" AutoPostBack="True"></asp:DropDownList>
														<asp:DropDownList ID="ddlDP" runat="server" Enabled="False" Width="220px" AutoPostBack="True"></asp:DropDownList>
														<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Week 
            Coverage&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            Select the Date
													</td>
												</tr>
												
												<tr>
													<td align="left" valign="top">Serial Number:</td>
													<td align="left">
														<asp:TextBox ID="txtSerial" runat="server" ReadOnly="True" Rows="10" 	Width="445px"></asp:TextBox>
													</td>
												</tr>

												<tr>
													<td align="left" valign="top">Invoice Number:</td>
													<td align="left">
														<asp:TextBox ID="txtInvoice" runat="server" ReadOnly="True" Rows="10" Width="445px"></asp:TextBox>
													</td>
												</tr>

												<tr>
													<td align="left" valign="top">&nbsp;</td>
													<td align="left">&nbsp;</td>
												</tr>

												<tr>
													<td align="left">&nbsp;</td>
													<td align="right">
														<asp:Button ID="btnModify" runat="server" Text="Modify" />
														<asp:Button ID="btnCancel" runat="server" Text="Cancel" />&nbsp;
													</td>
												</tr>

												<tr>
													<td align="left">&nbsp;</td>
													<td align="right">&nbsp;</td>
												</tr>
											</table>
										</asp:Panel>	
									</div>
									</td>
								</tr>
							</table><br /><br />
						</div>
					</asp:Panel>


					<!-- COMPETITOR -->
					<asp:Panel ID="panCompete" runat="server" visible="false">
						<div style="text-align:left; padding-left:25px;">
							<table width="100%">
								<asp:Panel ID="panCFilter" runat="server">
									<table>
										<tr>
											<td width="100px">Filter By:</td>
											<td width="35px">&nbsp;</td>
											<td>
												<asp:DropDownList ID="ddlCFilter" runat="server" AutoPostBack="True">
												<asp:ListItem></asp:ListItem>
												<asp:ListItem Value="2">Weekly</asp:ListItem>
												<asp:ListItem Value="3">Monthly</asp:ListItem>
												<asp:ListItem Value="4">Yearly</asp:ListItem>
												</asp:DropDownList>
											</td>
											<td width="35px">&nbsp;</td>
											<td width="100px">Per Brand:</td>
											<td width="35px">&nbsp;</td>
											<td>
												<asp:DropDownList ID="ddlBrand" runat="server" AutoPostBack="True" Width="250px"></asp:DropDownList>
											</td>
											<td>&nbsp;</td>
										</tr>

										<tr>
											<td>
												<asp:Label ID="lblCDate" runat="server" Text="Date Coverage:" Visible="False"></asp:Label>
											</td>
											<td width="35px">&nbsp;</td>
											<td>
												<asp:DropDownList ID="ddlCDate" runat="server" AutoPostBack="True" Visible="False"></asp:DropDownList>
											</td>
											<td>&nbsp;</td>
											<td>&nbsp;</td>
											<td>&nbsp;</td>
											<td>&nbsp;</td>
											<td>&nbsp;</td>
										</tr>

										<tr>
											<td>&nbsp;</td>
											<td width="35px">&nbsp;</td>
											<td>&nbsp;</td>
											<td>&nbsp;</td>
											<td>&nbsp;</td>
											<td>&nbsp;</td>
											<td>&nbsp;</td>
											<td>&nbsp;</td>
										</tr>
									</table>
								</asp:Panel>

        <tr>
            <td>
                <asp:GridView ID="grdCompete" runat="server" AutoGenerateColumns="False" 
                    CssClass="gridRow" DataKeyNames="cSubID" 
                    DataSourceID="sqlDS_Compete" PageSize="30" ShowFooter="True" Width="95%" 
                    AllowPaging="True" AllowSorting="True">
                    <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
                    <RowStyle CssClass="RowStyle" />
                    <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
                    <Columns>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/icons/modify.png" 
                            SelectText="Modify" ShowSelectButton="True"></asp:CommandField>
                        <asp:BoundField DataField="cSubID" Visible="False"></asp:BoundField>
                        
                        <asp:BoundField DataField="cBrand" HeaderText="Brand" SortExpression="cBrand"></asp:BoundField>
                        <asp:BoundField DataField="cCapacity" HeaderText="Capacity" 
                            SortExpression="cCapacity"></asp:BoundField>
                        <asp:BoundField DataField="qty" HeaderText="Qty" SortExpression="qty"></asp:BoundField>
                        <asp:BoundField DataField="csDate" HeaderText="Date" SortExpression="csDate"></asp:BoundField>
                        <asp:BoundField DataField="factor" HeaderText="Factor" SortExpression="factor"></asp:BoundField>

                        <asp:BoundField DataField="empName" HeaderText="Employee" 
                            SortExpression="empName"></asp:BoundField>
                        <asp:BoundField DataField="dSubmitted" HeaderText="Submission Date" 
                            SortExpression="dSubmitted"></asp:BoundField>
                        <asp:BoundField DataField="cSubID" InsertVisible="False" ReadOnly="True">
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
                        <center>No Record Found</center>
                    </EmptyDataTemplate>
                    <FooterStyle CssClass="FooterStyle" />
                    <PagerTemplate>
						<table align="center">
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
                                            Width="50px" onselectedindexchanged="ddlCPageNo_SelectedIndexChanged">
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
                    <EditRowStyle CssClass="EditRowStyle" />
                    <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                    <SelectedRowStyle Font-Bold="True" />
                </asp:GridView>

                                <!-- panData -->
<div>
<asp:Panel ID="panCData" runat="server" Visible="False" width="100%">
<table style="padding-left:30px;">

    <tr>
        <td align="left">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
    </tr>
    
<tr>
<td align="left" valign="top">Brand:</td>
<td align="left">
    <asp:DropDownList ID="ddlCDBrand" runat="server" Width="450px" Enabled="False" 
        AutoPostBack="True">
    </asp:DropDownList>
</td>
</tr>

    <tr>
        <td align="left" valign="top">
            Capacity:
        </td>
        <td align="left">
            <asp:DropDownList ID="ddlCCap" runat="server" Width="450px" Enabled="False">
            </asp:DropDownList>
        </td>
    </tr>

    <tr>
        <td align="left" valign="top">
            Quantity:</td>
        <td align="left">
            <asp:TextBox ID="txtCQty" runat="server" ReadOnly="True" Rows="10" 
                Width="445px" MaxLength="3"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="left" valign="top" width="150px">
            Date:</td>
        <td align="left" style="font-size: 9px;">
            <asp:DropDownList ID="ddlCWeek" runat="server" Enabled="False" Width="225px" 
                AutoPostBack="True">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlCDP" runat="server" Enabled="False" Width="220px" 
                AutoPostBack="True">
            </asp:DropDownList>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Week 
            Coverage&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            Select the Date</td>
    </tr>
    <tr>
        <td align="left" valign="top" width="200px">
            Factors Affecting Sell Out:</td>
        <td align="left">
            <asp:TextBox ID="txtFactor" runat="server" ReadOnly="True" Rows="10" 
                Width="445px"></asp:TextBox>
        </td>
    </tr>
    
    <tr>
        <td align="left" valign="top">
            &nbsp;</td>
        <td align="left">
            
            
            &nbsp;</td>
    </tr>
    <tr>
        <td align="left">
            &nbsp;</td>
        <td align="right">
            <asp:Button ID="btnCModify" runat="server" Text="Modify" />
            <asp:Button ID="btnCCancel" runat="server" Text="Cancel" />
            &nbsp;</td>
    </tr>
    <tr>
        <td align="left">
            &nbsp;</td>
        <td align="right">
            &nbsp;</td>
    </tr>
</table>
</asp:Panel>
</div>
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

    <asp:Panel ID="panSFilter" runat="server">
		<table width="800">
			<tr>
				<td width="120">Filter By:</td>
				<td width="20">&nbsp;</td>
				<td width="250">
					<asp:DropDownList ID="ddlSFilter" runat="server" AutoPostBack="True">
						<asp:ListItem></asp:ListItem>
						<asp:ListItem Value="2">Weekly</asp:ListItem>
						<asp:ListItem Value="3">Monthly</asp:ListItem>
						<asp:ListItem Value="4">Yearly</asp:ListItem>
					</asp:DropDownList>
				</td>
				<td width="20">&nbsp;</td>
				<asp:Panel ID="pnlSFC" runat="server" Visible="false">
					<td>Field Coordinator:</td>
					<td>&nbsp;</td>
					<td><asp:DropDownList ID="ddlSFC" runat="server" AutoPostBack="True"></asp:DropDownList></td>
					<td>&nbsp;</td>
				</asp:Panel>
			</tr>

			<tr>
				<td>
					<asp:Label ID="lblSDate" runat="server" Text="Date Coverage:" Visible="False"></asp:Label>
				</td>
				<td>&nbsp;</td>
				<td>
					<asp:DropDownList ID="ddlSDate" runat="server" AutoPostBack="True" Visible="False"></asp:DropDownList>
				</td>
				<td>&nbsp;</td>
				<td width="150">Promodiser:</td>
				<td width="20">&nbsp;</td>
				<td width="200">
					<asp:DropDownList ID="ddlSEmp" runat="server" AutoPostBack="True"></asp:DropDownList>
				</td>
				<td width="20">&nbsp;</td>
			</tr>

			<tr>
				<td colspan="8">&nbsp;</td>
			</tr>
        </table>
        </asp:Panel>


        <tr>
            <td>
                <asp:GridView ID="grdStocks" runat="server" AutoGenerateColumns="False" 
                    CssClass="gridRow" DataKeyNames="sSubID" 
                    DataSourceID="sqlDS_Stocks" PageSize="30" ShowFooter="True" Width="95%" 
                    AllowPaging="True" AllowSorting="True">
                    <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
                    <RowStyle CssClass="RowStyle" />
                    <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
                    <Columns>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/icons/modify.png" 
                            SelectText="Modify" ShowSelectButton="True"></asp:CommandField>
                        <asp:BoundField DataField="sSubID" Visible="False"></asp:BoundField>
                        
                        <asp:BoundField DataField="product" HeaderText="Product" 
                            SortExpression="product"></asp:BoundField>
                        <asp:BoundField DataField="brand" HeaderText="Brand" SortExpression="brand"></asp:BoundField>
                        <asp:BoundField DataField="shortCode" HeaderText="Short Code" 
                            SortExpression="shortCode"></asp:BoundField>

                        <asp:BoundField DataField="longCode" HeaderText="Long Code" 
                            SortExpression="longCode"></asp:BoundField>
                        <asp:BoundField DataField="itemDesc" HeaderText="Item Description" 
                            SortExpression="itemDesc"></asp:BoundField>
                        <asp:BoundField DataField="capacity" HeaderText="Capacity" 
                            SortExpression="capacity"></asp:BoundField>
                        <asp:BoundField DataField="variant" HeaderText="Variant" 
                            SortExpression="variant"></asp:BoundField>
                        <asp:BoundField DataField="model" HeaderText="Model" SortExpression="model"></asp:BoundField>
                        
                        <asp:BoundField DataField="dWhen" HeaderText="Date" SortExpression="dWhen"></asp:BoundField>
                        <asp:BoundField DataField="actTake" HeaderText="Action Taken" 
                            SortExpression="actTake"></asp:BoundField>
                        <asp:BoundField DataField="promo" HeaderText="Competitor Promo Activities" 
                            SortExpression="promo"></asp:BoundField>
                        <asp:BoundField DataField="empName" HeaderText="Employee" 
                            SortExpression="empName"></asp:BoundField>
                        <asp:BoundField DataField="dSubmitted" HeaderText="Submission Date" 
                            SortExpression="dSubmitted"></asp:BoundField>

                        <asp:BoundField DataField="sSubID" InsertVisible="False" ReadOnly="True">
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
                        <center>No Record Found</center>
                    </EmptyDataTemplate>
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
                                            Width="50px" onselectedindexchanged="ddlSPageNo_SelectedIndexChanged">
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
                    <EditRowStyle CssClass="EditRowStyle" />
                    <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                    <SelectedRowStyle Font-Bold="True" />
                </asp:GridView>

                                                <!-- panSData -->
<div>
<asp:Panel ID="panSData" runat="server" Visible="False" width="100%">
<table style="padding-left:30px;">

    <tr>
        <td align="left">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
    </tr>
   
    <tr>
<td align="left" valign="top">Product:
        </td>
<td align="left">
    <asp:DropDownList ID="ddlSProd" runat="server" AutoPostBack="True" 
        Enabled="False" Width="450px">
    </asp:DropDownList>
</td>
</tr>

<tr>
<td align="left" valign="top">Brand:</td>
<td align="left">
    <asp:DropDownList ID="ddlSDBrand" runat="server" Width="450px" Enabled="False" 
        AutoPostBack="True">
    </asp:DropDownList>
</td>
</tr>

    <tr>
        <td align="left" valign="top">
            Short Code:
            <asp:ImageButton ID="imbSShow" runat="server" AlternateText="Save" 
                ImageUrl="~/images/icons/search.png" ToolTip="Search Short Code" />
        </td>
        <td align="left">
            <asp:DropDownList ID="ddlSSCode" runat="server" Width="450px" Enabled="False">
            </asp:DropDownList>
        </td>
    </tr>

    <tr>
        <td align="left" valign="top" width="150px">
            Date:</td>
        <td align="left" style="font-size: 9px;">
            <asp:DropDownList ID="ddlSWeek" runat="server" Enabled="False" Width="225px" 
                AutoPostBack="True">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlSDP" runat="server" Enabled="False" Width="220px" 
                AutoPostBack="True">
            </asp:DropDownList>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Week 
            Coverage&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            Select the Date</td>
    </tr>
    <tr>
        <td align="left" valign="top">
            Action Taken:</td>
        <td align="left">
            <asp:DropDownList ID="ddlAction" runat="server" Enabled="False" Width="220px" 
                AutoPostBack="True">
            </asp:DropDownList>
            <asp:TextBox ID="txtOthers" runat="server" ReadOnly="True" Rows="10" 
                Width="445px" visible="false"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="left" valign="top">
            Competitor Promo Activities:</td>
        <td align="left">
            <asp:TextBox ID="txtPromo" runat="server" ReadOnly="True" Rows="10" 
                Width="445px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="left" valign="top">
            &nbsp;</td>
        <td align="left">
            
            
            &nbsp;</td>
    </tr>
    <tr>
        <td align="left">
            &nbsp;</td>
        <td align="right">
            <asp:Button ID="btnSModify" runat="server" Text="Modify" />
            <asp:Button ID="btnSCancel" runat="server" Text="Cancel" />
            &nbsp;</td>
    </tr>
    <tr>
        <td align="left">
            &nbsp;</td>
        <td align="right">
            &nbsp;</td>
    </tr>
</table>
</asp:Panel>
</div>

                                
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

    <asp:Panel ID="panIFilter" runat="server">
		<table width="800">
			<tr>
				<td width="120">Filter By:</td>
				<td width="20">&nbsp;</td>
				<td width="250">
					<asp:DropDownList ID="ddlIFilter" runat="server" AutoPostBack="True">
						<asp:ListItem></asp:ListItem>
						<asp:ListItem Value="2">Weekly</asp:ListItem>
						<asp:ListItem Value="3">Monthly</asp:ListItem>
						<asp:ListItem Value="4">Yearly</asp:ListItem>
					</asp:DropDownList>
				</td>
				<td width="20">&nbsp;</td>
				<asp:Panel ID="pnlIFC" runat="server" Visible="false">
					<td>Field Coordinator:</td>
					<td>&nbsp;</td>
					<td><asp:DropDownList ID="ddlIFC" runat="server" AutoPostBack="True"></asp:DropDownList></td>
					<td>&nbsp;</td>
				</asp:Panel>
			</tr>

			<tr>
				<td><asp:Label ID="lblIDate" runat="server" Text="Date Coverage:" Visible="False"></asp:Label></td>
				<td>&nbsp;</td>
				<td>
					<asp:DropDownList ID="ddlIDate" runat="server" AutoPostBack="True" Visible="False"></asp:DropDownList>
				</td>
				<td>&nbsp;</td>
				<td width="150">Promodiser:</td>
				<td width="20">&nbsp;</td>
				<td width="200">
					<asp:DropDownList ID="ddlIEmp" runat="server" AutoPostBack="True" Width="250px"></asp:DropDownList>
				</td>
				<td width="20">&nbsp;</td>
			</tr>

			<tr>
				<td colspan="8">&nbsp;</td>
			</tr>
		</table>
	</asp:Panel>

        <tr>
            <td>
                <asp:GridView ID="grdInventory" runat="server" AutoGenerateColumns="False" 
                    CssClass="gridRow" DataKeyNames="iSubID" 
                    DataSourceID="sqlDS_Inventory" PageSize="30" ShowFooter="True" Width="95%" 
                    AllowPaging="True" AllowSorting="True">
                    <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
                    <RowStyle CssClass="RowStyle" />
                    <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
                    <Columns>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/icons/modify.png" 
                            SelectText="Modify" ShowSelectButton="True"></asp:CommandField>
                        <asp:BoundField DataField="iSubID" Visible="False"></asp:BoundField>
                        
                        <asp:BoundField DataField="product" HeaderText="Product" 
                            SortExpression="product"></asp:BoundField>
                        <asp:BoundField DataField="brand" HeaderText="Brand" SortExpression="brand"></asp:BoundField>
                        <asp:BoundField DataField="shortCode" HeaderText="Short Code" 
                            SortExpression="shortCode"></asp:BoundField>
                        <asp:BoundField DataField="longCode" HeaderText="Long Code" 
                            SortExpression="longCode"></asp:BoundField>
                        <asp:BoundField DataField="itemDesc" HeaderText="Item Description" 
                            SortExpression="itemDesc"></asp:BoundField>
                        <asp:BoundField DataField="capacity" HeaderText="Capacity" 
                            SortExpression="capacity"></asp:BoundField>
                        <asp:BoundField DataField="variant" HeaderText="Variant" 
                            SortExpression="variant"></asp:BoundField>

                        <asp:BoundField DataField="model" HeaderText="Model" SortExpression="model"></asp:BoundField>
                        <asp:BoundField DataField="qty" HeaderText="Qty" SortExpression="qty"></asp:BoundField>
                        <asp:BoundField DataField="comments" HeaderText="Comments" 
                            SortExpression="comments"></asp:BoundField>
                        <asp:BoundField DataField="empName" HeaderText="Employee" 
                            SortExpression="empName"></asp:BoundField>
                        <asp:BoundField DataField="dSubmitted" HeaderText="Submission Date" 
                            SortExpression="dSubmitted"></asp:BoundField>

                        <asp:BoundField DataField="iSubID" InsertVisible="False" ReadOnly="True">
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
                        <center>No Record Found</center>
                    </EmptyDataTemplate>
                    <FooterStyle CssClass="FooterStyle" />
                    <PagerTemplate>
                        <table align="center">
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
                                            Width="50px" onselectedindexchanged="ddlIPageNo_SelectedIndexChanged">
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
                    <EditRowStyle CssClass="EditRowStyle" />
                    <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                    <SelectedRowStyle Font-Bold="True" />
                </asp:GridView>

                <!-- panIData -->
<div>
<asp:Panel ID="panIData" runat="server" Visible="False" width="100%">
<table style="padding-left:30px;">

    <tr>
        <td align="left">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
    </tr>
    
    <tr>
<td align="left" valign="top">Product:</td>
<td align="left">
    <asp:DropDownList ID="ddlIProd" runat="server" AutoPostBack="True" 
        Enabled="False" Width="450px">
    </asp:DropDownList>
</td>
</tr>

<tr>
<td align="left" valign="top">Brand:</td>
<td align="left">
    <asp:DropDownList ID="ddlIDBrand" runat="server" Width="450px" Enabled="False" 
        AutoPostBack="True">
    </asp:DropDownList>
</td>
</tr>

    <tr>
        <td align="left" valign="top">
            Short Code:
            <asp:ImageButton ID="imbIShow" runat="server" AlternateText="Save" 
                ImageUrl="~/images/icons/search.png" ToolTip="Search Short Code" />
        </td>
        <td align="left">
            <asp:DropDownList ID="ddlISCode" runat="server" Width="450px" Enabled="False">
            </asp:DropDownList>
        </td>
    </tr>

    <tr>
        <td align="left" valign="top">
            Quantity:</td>
        <td align="left">
            <asp:TextBox ID="txtIQty" runat="server" ReadOnly="True" Rows="10" 
                Width="445px" MaxLength="3"></asp:TextBox>
        </td>
    </tr>
    
    <tr>
        <td align="left" valign="top" width="175px">
            Comments & Suggestions:</td>
        <td align="left">
            <asp:TextBox ID="txtComments" runat="server" ReadOnly="True" Rows="10" 
                Width="445px"></asp:TextBox>
        </td>
    </tr>
        
        <tr>
        <td align="left" valign="top">
            &nbsp;</td>
        <td align="left">
            
            
            &nbsp;</td>
    </tr>
    <tr>
        <td align="left">
            &nbsp;</td>
        <td align="right">
            <asp:Button ID="btnIModify" runat="server" Text="Modify" />
            <asp:Button ID="btnICancel" runat="server" Text="Cancel" />
            &nbsp;</td>
    </tr>
    <tr>
        <td align="left">
            &nbsp;</td>
        <td align="right">
            &nbsp;</td>
    </tr>
</table>
</asp:Panel>
</div>
            </td>
        </tr>
    </table><br /><br />
    </div>
</asp:Panel>


<!-- TM SALES-->
<asp:Panel ID="panTMSales" runat="server">
<div style="text-align:left; padding-left:25px;">
    <table width="100%">

	<asp:Panel ID="panTFilter" runat="server">
		<table width="800">
			<tr>
				<td width="120">Filter By:</td>
				<td width="20">&nbsp;</td>
				<td width="250">
					<asp:DropDownList ID="ddlTFilter" runat="server" AutoPostBack="True">
					<asp:ListItem></asp:ListItem>
					<asp:ListItem Value="2">Weekly</asp:ListItem>
					<asp:ListItem Value="3">Monthly</asp:ListItem>
					<asp:ListItem Value="4">Yearly</asp:ListItem>
					</asp:DropDownList>
				</td>
				<td width="20">&nbsp;</td>
				<asp:Panel ID="pnlTFC" runat="server" Visible="false">
					<td>Field Coordinator:</td>
					<td>&nbsp;</td>
					<td><asp:DropDownList ID="ddlTFC" runat="server" AutoPostBack="True"></asp:DropDownList></td>
					<td>&nbsp;</td>
				</asp:Panel>
			</tr>

			<tr>
				<td><asp:Label ID="lblTDate" runat="server" Text="Date Coverage:" Visible="False"></asp:Label></td>
				<td>&nbsp;</td>
				<td>
					<asp:DropDownList ID="ddlTDate" runat="server" AutoPostBack="True" Visible="False"></asp:DropDownList>
				</td>
				<td>&nbsp;</td>
				<td width="150">Promodiser:</td>
				<td width="20">&nbsp;</td>
				<td width="200">
					<asp:DropDownList ID="ddlTEmp" runat="server" AutoPostBack="True" Width="250px"></asp:DropDownList>
				</td>
				<td>&nbsp;</td>
			</tr>

			<tr>
				<td colspan="8">&nbsp;</td>
			</tr>
        </table>
	</asp:Panel>
		
        <tr>
            <td>
                <asp:GridView ID="grdTM" runat="server" AutoGenerateColumns="False" 
                    CssClass="gridRow" DataKeyNames="subID" 
                    DataSourceID="sqlDS_TMSales" PageSize="30" ShowFooter="True" Width="95%" 
                    AllowPaging="True" AllowSorting="True">
                    <PagerSettings Mode="NextPreviousFirstLast" Position="TopAndBottom" />
                    <RowStyle CssClass="RowStyle" />
                    <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
                    <Columns>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/icons/modify.png" SelectText="Modify" ShowSelectButton="True"></asp:CommandField>
						<asp:BoundField DataField="subID" Visible="False"></asp:BoundField>
                        
                        <asp:BoundField DataField="cName" HeaderText="Customer" SortExpression="cName"></asp:BoundField>
						<asp:BoundField DataField="cAddress" HeaderText="Address" SortExpression="cAddress"></asp:BoundField>
						<asp:BoundField DataField="contact" HeaderText="Tel. No." SortExpression="contact"></asp:BoundField>
						<asp:BoundField DataField="qty" HeaderText="Qty" SortExpression="qty"></asp:BoundField>
                        <asp:BoundField DataField="product" HeaderText="Product" SortExpression="product"></asp:BoundField>
						<asp:BoundField DataField="brand" HeaderText="Brand" SortExpression="brand"></asp:BoundField>
						<asp:BoundField DataField="shortCode" HeaderText="Short Code" SortExpression="shortCode"></asp:BoundField>
						<asp:BoundField DataField="dPurchased" HeaderText="Date Purchased" SortExpression="dPurchased"></asp:BoundField>
						<asp:BoundField DataField="serial" HeaderText="Serial No." SortExpression="serial"></asp:BoundField>
						<asp:BoundField DataField="invoice" HeaderText="Invoice No." SortExpression="invoice"></asp:BoundField>
						<asp:BoundField DataField="FCName" HeaderText="FC" SortExpression="FCName"></asp:BoundField>
						<asp:BoundField DataField="mName" HeaderText="Diser" SortExpression="mName"></asp:BoundField>
						<asp:BoundField DataField="recStatusID" HeaderText="Status" SortExpression="recStatusID"></asp:BoundField>

                        <asp:BoundField DataField="subID" InsertVisible="False" ReadOnly="True">
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
                        <center>No Record Found</center>
                    </EmptyDataTemplate>
                    <FooterStyle CssClass="FooterStyle" />
                    <PagerTemplate>
                        <table align="center">
                            <tbody>
                                <tr valign="middle">
                                    <td>
                                        <asp:ImageButton ID="imbTFirst" runat="server" AlternateText="First Page" 
                                            CommandArgument="First" CommandName="Page" 
                                            ImageUrl="~/images/icons/first.gif" />
                                        <asp:ImageButton ID="imbTPrev" runat="server" AlternateText="Previous Page" 
                                            CommandArgument="Prev" CommandName="Page" ImageUrl="~/images/icons/prev.gif" />
                                    </td>
                                    <td>
                                        Page&nbsp;
                                        <asp:DropDownList ID="ddlTPageNo" runat="server" AutoPostBack="true" 
                                            Width="50px" onselectedindexchanged="ddlTPageNo_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        &nbsp;of&nbsp;
                                        <asp:Label ID="lblTPageCount" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="imbTNext" runat="server" AlternateText="Next Page" 
                                            CommandArgument="Next" CommandName="Page" ImageUrl="~/images/icons/next.gif" />
                                        <asp:ImageButton ID="imbTLast" runat="server" AlternateText="Last Page" 
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
                    <SelectedRowStyle Font-Bold="True" />
                </asp:GridView>

      
                <!-- panTData -->
<div>
<asp:Panel ID="panTData" runat="server" Visible="False" width="100%">
<table style="padding-left:30px;">

<tr>
        <td align="left">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="left" valign="top" colspan="2">
            <h3 style="padding-bottom:15px;">
                Customer Information</h3>
        </td>
    </tr>
    
	<tr>
        <td align="left" valign="top">
            Name:</td>
        <td align="left" style="font-size: 9px;">
            <asp:TextBox ID="txtTFname" runat="server" Width="220px"></asp:TextBox>
            <asp:TextBox ID="txtTLname" runat="server" Width="225px"></asp:TextBox>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; First 
            Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; Last Name</td>
    </tr>

<tr>
<td align="left">Address:</td>
<td align="left">
    <asp:TextBox ID="txtTAdd" runat="server" 
        Width="245px"></asp:TextBox>
    <asp:DropDownList ID="ddlTCity" runat="server" AutoPostBack="True" Enabled="True" Width="200px">
    </asp:DropDownList>
</td>
</tr>

<tr>
<td align="left" valign="top">Contact No/s:</td>
<td align="left">
    <asp:TextBox ID="txtTContact" runat="server" Rows="10" Width="445px"></asp:TextBox>
</td>
</tr>

    <tr>
        <td align="left" valign="top">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="left" colspan="2" valign="top">
            <h3 style="padding-bottom:15px;">Product Details</h3>
            </td>
    </tr>

<tr>
<td align="left" valign="top">Product:</td>
<td align="left">
    <asp:DropDownList ID="ddlTProd" runat="server" AutoPostBack="True" Enabled="False" Width="450px">
    </asp:DropDownList>
</td>
</tr>

<tr>
<td align="left" valign="top">Brand:</td>
<td align="left">
    <asp:DropDownList ID="ddlTDBrand" runat="server" Width="450px" Enabled="False" AutoPostBack="True">
    </asp:DropDownList>
</td>
</tr>

    <tr>
        <td align="left" valign="top">
            Short Code:
        </td>
        <td align="left">
            <asp:DropDownList ID="ddlTSCode" runat="server" Width="450px" Enabled="False">
            </asp:DropDownList>
        </td>
    </tr>

    <tr>
        <td align="left" valign="top">
            Quantity:</td>
        <td align="left">
            <asp:TextBox ID="txtTQty" runat="server" Rows="10" Width="445px" MaxLength="3"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="left" valign="top" width="150px">
            Date Purchased:</td>
        <td align="left" style="font-size: 9px;">
            <asp:DropDownList ID="ddlTWeek" runat="server" Enabled="True" Width="225px" 
                AutoPostBack="True">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlTDP" runat="server" Enabled="True" Width="220px" 
                AutoPostBack="True">
            </asp:DropDownList>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Week 
            Coverage&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            Select the Date</td>
    </tr>
    <tr>
        <td align="left" valign="top">
            Serial Number:</td>
        <td align="left">
            <asp:TextBox ID="txtTSerial" runat="server" Rows="10" 
                Width="445px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="left" valign="top">
            Invoice Number:</td>
        <td align="left">
            <asp:TextBox ID="txtTInvoice" runat="server" Rows="10" 
                Width="445px"></asp:TextBox>
        </td>
    </tr>




    <tr>
        <td align="left" valign="top">
            &nbsp;</td>
        <td align="left">
            
            
            &nbsp;</td>
    </tr>
    <tr>
        <td align="left">
            &nbsp;</td>
        <td align="right">
            <asp:Button ID="btnTModify" runat="server" Text="Modify" />
            <asp:Button ID="btnTCancel" runat="server" Text="Cancel" />
            &nbsp;</td>
    </tr>
    <tr>
        <td align="left">
            &nbsp;</td>
        <td align="right">
            &nbsp;</td>
    </tr>
</table>
</asp:Panel>
</div>
            </td>
        </tr>
    </table><br /><br />
    </div>
</asp:Panel>



<%--SQL Connections--%>

<%--SALES--%>
<asp:SqlDataSource id="sqlDS_Sales" runat="server" 
    ConnectionString="<%$ ConnectionStrings:conString %>" 
    SelectCommand="SELECT * FROM vw_SalesReport 
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
                    ORDER BY sSubID DESC">
<SelectParameters>
                <asp:SessionParameter Name="userID" 
                    SessionField="userID" Type="Int64" />
            </SelectParameters>
</asp:SqlDataSource>

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

<%--INVENTORY--%>
<asp:SqlDataSource id="sqlDS_Inventory" runat="server" 
    ConnectionString="<%$ ConnectionStrings:conString %>" 
    SelectCommand="SELECT * FROM vw_InventoryReport 
                    ORDER BY iSubID DESC">
<SelectParameters>
                <asp:SessionParameter Name="userID" 
                    SessionField="userID" Type="Int64" />
            </SelectParameters>
</asp:SqlDataSource>

<%--TM SALES--%>
<asp:SqlDataSource id="sqlDS_TMSales" runat="server" 
    ConnectionString="<%$ ConnectionStrings:conString %>" 
    SelectCommand="SELECT * FROM vw_SalesReport ORDER BY subID DESC">
<SelectParameters>
                <asp:SessionParameter Name="userID" 
                    SessionField="userID" Type="Int64" />
            </SelectParameters>
</asp:SqlDataSource>


</div>




</ContentTemplate>
</asp:UpdatePanel>
</div>
</center>

</asp:Content>