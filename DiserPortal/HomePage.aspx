<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="HomePage.aspx.vb" MasterPageFile="~/Site.Master" Inherits="DiserPortal.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<asp:UpdatePanel id="updClient" runat="server" >
		<contenttemplate>
			<div class="main_wrap" style="margin:auto; text-align:center;"><br />
				<center>
					<table id="Table_01" width="1000" border="0" cellpadding="0" cellspacing="0">
						<tr>
							<td rowspan="5">
								<img id="main" src="images/home/main2.png" width="500" height="250" alt="" /></td>
							<td>
							<img id="top" src="images/home/top.png" width="500" height="36" alt="" /></td>
						</tr>
						<tr>
							<td>
								<asp:ImageButton ID="imbSales" runat="server" 
									imageurl="~/images/home/sales.png" 
									onmouseover="this.src='../images/home/salesHover.png'" 
									onmouseout="this.src='../images/home/sales.png'"></asp:ImageButton>
							</td>
						</tr>
						<tr>
							<td>
								<asp:ImageButton ID="imbReport" runat="server"
									imageurl="~/images/home/report.png" 
									onmouseover="this.src='../images/home/reportHover.png'" 
									onmouseout="this.src='../images/home/report.png'"></asp:ImageButton>
							</td>
						</tr>
						<tr>
							<td>
								<asp:ImageButton ID="imbSupport" runat="server"
									imageurl="~/images/home/help.png" 
									onmouseover="this.src='../images/home/helpHover.png'" 
									onmouseout="this.src='../images/home/help.png'"></asp:ImageButton>
							</td>
						</tr>
						<tr>
							<td>
								<asp:ImageButton ID="imbComm" runat="server"
									imageurl="~/images/home/comm.png" 
									onmouseover="this.src='../images/home/commHover.png'" 
									onmouseout="this.src='../images/home/comm.png'"></asp:ImageButton>
							</td>
						</tr>
					</table>
				</center>
			</div>

			<div style="height:30px"></div>

			<center>
				<div style="width:1000px;margin:0;height:0;">
					<div style="float:left;vertical-align:top;">
						<h2>Announcements</h2><br />
						<asp:GridView ID="grdAnnounce" runat="server" AutoGenerateColumns="False" 
						BorderColor="Black" DataKeyNames="announceID" DataSourceID="sqlDS_Announce" 
						PageSize="1" AllowPaging="True">
						<PagerSettings Mode="NextPreviousFirstLast" PageButtonCount="1" />
						<RowStyle CssClass="RowStyle" />
						<EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
						<Columns>
						<asp:BoundField DataField="announceID" HeaderText="ID" Visible="False" />
						<asp:TemplateField>
							<HeaderTemplate></HeaderTemplate>
							<ItemTemplate>
							<div style="text-align:left;">
							<asp:Label ID="lblTitle" runat="server" Text='<%# Bind("aTitle") %>' 
							Width="400px" Font-Bold="True" Font-Size="15px"></asp:Label><br />
							Last Updated:&nbsp;&nbsp;
							<asp:Label ID="lblDate" runat="server" Text='<%# Bind("header") %>' 
							Width="400px"></asp:Label>
							</div><br />
							<div style="text-align:justify;">
							<asp:Image runat="server" width="50px" height="50px" ID="imgPic" 
							ImageUrl="~/images/announce.jpg"></asp:Image>
							<asp:Label ID="lblIntro" runat="server" Text='<%# Bind("intro") %>' 
							width="400px"></asp:Label><br />
							</div>
							<div style="text-align:right">
							<asp:LinkButton ID="lnkMore" runat="server" 
							commandargument='<%# Bind("announceID") %>' text="..More" 
							onclick="lnkMore_Click"></asp:LinkButton>
							</div>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:BoundField DataField="announceID" InsertVisible="False" ReadOnly="True">
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
						<div style="95%">
						<div style="float:left;padding-left:5px;">
						<asp:LinkButton ID="lnkView" runat="server" onclick="lnkView_Click">View All</asp:LinkButton>
						</div>
						<div style="float:right;padding-right:5px;">
						<asp:ImageButton ID="i1" runat="server" ImageUrl="~/images/icons/blueIC.png" 
						onclick="i1_Click" Visible="false" ></asp:ImageButton>
						<asp:ImageButton ID="i2" runat="server" ImageUrl="~/images/icons/blueIC.png" 
						Visible="false" onclick="i2_Click" ></asp:ImageButton>
						<asp:ImageButton ID="i3" runat="server" ImageUrl="~/images/icons/blueIC.png" 
						Visible="false" onclick="i3_Click" ></asp:ImageButton>
						<asp:ImageButton ID="i4" runat="server" ImageUrl="~/images/icons/blueIC.png" 
						Visible="false" onclick="i4_Click" ></asp:ImageButton>
						<asp:ImageButton ID="i5" runat="server" ImageUrl="~/images/icons/blueIC.png" 
						Visible="false" onclick="i5_Click" ></asp:ImageButton>
						</div>
						</div>
						</PagerTemplate>
						<PagerStyle CssClass="PagerRowStyle" />
						<EmptyDataTemplate>
						<div style="text-align:center; margin:auto;">
						No Announcements Available</div>
						</EmptyDataTemplate>
						<SelectedRowStyle CssClass="SelectedRowStyle" />
						<HeaderStyle CssClass="HeaderStyle" />
						<EditRowStyle CssClass="EditRowStyle" />
						<AlternatingRowStyle CssClass="AlternatingRowStyle" />
						</asp:GridView>

						<br/>
					</div>

					<%--Performance Tracker--%>
					<div style="float:right;vertical-align:top;">
						<h2>Performance Tracker</h2><br/>
					

						<asp:GridView ID="grdPerf" runat="server" AutoGenerateColumns="False" 
							BorderColor="Black" DataKeyNames="perfID" DataSourceID="sqlDS_Perf1" 
							PageSize="1" AllowPaging="False" ShowFooter="True">
							<PagerSettings Mode="NextPreviousFirstLast" PageButtonCount="1" />
							<RowStyle CssClass="RowStyle" />
							<EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
							<Columns>
								<asp:BoundField DataField="perfID" HeaderText="ID" Visible="False" />
								<asp:TemplateField>
									<HeaderTemplate></HeaderTemplate>
									<ItemTemplate>
										<div style="text-align:left;">
											<asp:Label ID="lblName" runat="server" Text='<%# Bind("empName") %>'
												Width="400px" Font-Bold="True" Font-Size="15px"></asp:Label><br />
										</div><br />
										<div style="text-align:center;">
											<asp:GridView ID="grdPerf1" runat="server" AutoGenerateColumns="False" 
												DataKeyNames="perfID" DataSourceID="sqlDS_Perf1" width="95%" PageSize="1">
												<Columns>
													<asp:TemplateField HeaderText="Product">
														<EditItemTemplate>
															<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("product") %>'></asp:TextBox>
														</EditItemTemplate>
														<ItemTemplate>
															<asp:Label ID="Label1" runat="server" Text='<%# Bind("product") %>' 
																Width="100px"></asp:Label>
														</ItemTemplate>
													</asp:TemplateField>
													<asp:TemplateField HeaderText="W1">
														<EditItemTemplate>
															<asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("w1") %>'></asp:TextBox>
														</EditItemTemplate>
														<ItemTemplate>
															<asp:Label ID="Label2" runat="server" Text='<%# Bind("w1") %>' Width="40px"></asp:Label>
														</ItemTemplate>
													</asp:TemplateField>
													<asp:TemplateField HeaderText="W2">
														<EditItemTemplate>
															<asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("w2") %>'></asp:TextBox>
														</EditItemTemplate>
														<ItemTemplate>
															<asp:Label ID="Label3" runat="server" Text='<%# Bind("w2") %>' Width="40px"></asp:Label>
														</ItemTemplate>
													</asp:TemplateField>
													<asp:TemplateField HeaderText="W3">
														<EditItemTemplate>
															<asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("w3") %>'></asp:TextBox>
														</EditItemTemplate>
														<ItemTemplate>
															<asp:Label ID="Label4" runat="server" Text='<%# Bind("w3") %>' Width="40px"></asp:Label>
														</ItemTemplate>
													</asp:TemplateField>
													<asp:TemplateField HeaderText="W4">
														<EditItemTemplate>
															<asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("w4") %>'></asp:TextBox>
														</EditItemTemplate>
														<ItemTemplate>
															<asp:Label ID="Label5" runat="server" Text='<%# Bind("w4") %>' Width="40px"></asp:Label>
														</ItemTemplate>
													</asp:TemplateField>
													<asp:TemplateField HeaderText="W5">
														<EditItemTemplate>
															<asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("w5") %>'></asp:TextBox>
														</EditItemTemplate>
														<ItemTemplate>
															<asp:Label ID="Label8" runat="server" Text='<%# Bind("w5") %>' Width="40px"></asp:Label>
														</ItemTemplate>
													</asp:TemplateField>
													<asp:TemplateField HeaderText="Month">
														<EditItemTemplate>
															<asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("mTotal") %>'></asp:TextBox>
														</EditItemTemplate>
														<ItemTemplate>
															<asp:Label ID="Label6" runat="server" Text='<%# Bind("mTotal") %>' Width="40px"></asp:Label>
														</ItemTemplate>
													</asp:TemplateField>
													<asp:TemplateField HeaderText="Year">
														<EditItemTemplate>
															<asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("yTotal") %>'></asp:TextBox>
														</EditItemTemplate>
														<ItemTemplate>
															<asp:Label ID="Label7" runat="server" Text='<%# Bind("yTotal") %>' Width="40px"></asp:Label>
														</ItemTemplate>
													</asp:TemplateField>
												</Columns>
												<HeaderStyle ForeColor="Black" />
											</asp:GridView>

											<asp:GridView ID="grdPerf2" runat="server" AutoGenerateColumns="False" 
											   DataKeyNames="perfID" DataSourceID="sqlDS_Perf2" width="95%" PageSize="1" 
												ShowHeader="False">
												<Columns>
													<asp:TemplateField HeaderText="Product">
														<EditItemTemplate>
															<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("product") %>'></asp:TextBox>
														</EditItemTemplate>
														<ItemTemplate>
															<asp:Label ID="Label1" runat="server" Text='<%# Bind("product") %>' 
																Width="100px"></asp:Label>
														</ItemTemplate>
													</asp:TemplateField>
													<asp:TemplateField HeaderText="W1">
														<EditItemTemplate>
															<asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("w1") %>'></asp:TextBox>
														</EditItemTemplate>
														<ItemTemplate>
															<asp:Label ID="Label2" runat="server" Text='<%# Bind("w1") %>' Width="40px"></asp:Label>
														</ItemTemplate>
													</asp:TemplateField>
													<asp:TemplateField HeaderText="W2">
														<EditItemTemplate>
															<asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("w2") %>'></asp:TextBox>
														</EditItemTemplate>
														<ItemTemplate>
															<asp:Label ID="Label3" runat="server" Text='<%# Bind("w2") %>' Width="40px"></asp:Label>
														</ItemTemplate>
													</asp:TemplateField>
													<asp:TemplateField HeaderText="W3">
														<EditItemTemplate>
															<asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("w3") %>'></asp:TextBox>
														</EditItemTemplate>
														<ItemTemplate>
															<asp:Label ID="Label4" runat="server" Text='<%# Bind("w3") %>' Width="40px"></asp:Label>
														</ItemTemplate>
													</asp:TemplateField>
													<asp:TemplateField HeaderText="W4">
														<EditItemTemplate>
															<asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("w4") %>'></asp:TextBox>
														</EditItemTemplate>
														<ItemTemplate>
															<asp:Label ID="Label5" runat="server" Text='<%# Bind("w4") %>' Width="40px"></asp:Label>
														</ItemTemplate>
													</asp:TemplateField>
													<asp:TemplateField HeaderText="W5">
														<EditItemTemplate>
															<asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("w5") %>'></asp:TextBox>
														</EditItemTemplate>
														<ItemTemplate>
															<asp:Label ID="Label8" runat="server" Text='<%# Bind("w5") %>' Width="40px"></asp:Label>
														</ItemTemplate>
													</asp:TemplateField>
													<asp:TemplateField HeaderText="Month">
														<EditItemTemplate>
															<asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("mTotal") %>'></asp:TextBox>
														</EditItemTemplate>
														<ItemTemplate>
															<asp:Label ID="Label6" runat="server" Text='<%# Bind("mTotal") %>' Width="40px"></asp:Label>
														</ItemTemplate>
													</asp:TemplateField>
													<asp:TemplateField HeaderText="Year">
														<EditItemTemplate>
															<asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("yTotal") %>'></asp:TextBox>
														</EditItemTemplate>
														<ItemTemplate>
															<asp:Label ID="Label7" runat="server" Text='<%# Bind("yTotal") %>' Width="40px"></asp:Label>
														</ItemTemplate>
													</asp:TemplateField>
												</Columns>
												<HeaderStyle ForeColor="Black" />
											</asp:GridView>
										</div>
									</ItemTemplate>
								</asp:TemplateField>
								<asp:BoundField DataField="perfID" InsertVisible="False" ReadOnly="True">
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

							<PagerStyle CssClass="PagerRowStyle" />
							<EmptyDataTemplate>
								<div style="text-align:center; margin:auto;">
									No Records Available</div>
							</EmptyDataTemplate>
							<SelectedRowStyle CssClass="SelectedRowStyle" />
							<FooterStyle BackColor="#FFFF99" />
							<HeaderStyle CssClass="HeaderStyle" />
							<EditRowStyle CssClass="EditRowStyle" />
							<AlternatingRowStyle CssClass="AlternatingRowStyle" />
						</asp:GridView>
					</div>
				</div>
			</center>

			<asp:SqlDataSource id="sqlDS_Announce" runat="server" 
				ConnectionString= "<%$ ConnectionStrings:conString %>"
				SelectCommand="SELECT TOP 5 * FROM    [vw_Announce] WHERE aStatusID = 1 ORDER BY announceID DESC">
			</asp:SqlDataSource> 
			<asp:SqlDataSource ID="sqlDS_Perf1" runat="server" 
				ConnectionString="<%$ ConnectionStrings:conString %>" 
				SelectCommand="SELECT TOP 5 * FROM [vw_Perf] WHERE userID = 35 and productID = 1">
				<SelectParameters>
					<asp:SessionParameter Name="userID" SessionField="userID" Type="Int64" />
				</SelectParameters>
			</asp:SqlDataSource>
			<asp:SqlDataSource ID="sqlDS_Perf2" runat="server" 
				ConnectionString="<%$ ConnectionStrings:conString %>" 
				SelectCommand="SELECT TOP 5 * FROM [vw_Perf] WHERE userID = 35 and productID = 2">
				<SelectParameters>
					<asp:SessionParameter Name="userID" SessionField="userID" Type="Int64" />
				</SelectParameters>
			</asp:SqlDataSource>
			<asp:SqlDataSource id="sqlDS_High" runat="server" 
				ConnectionString="<%$ ConnectionStrings:conString %>" 
				SelectCommand="SELECT TOP 3 * FROM    [vw_High] ORDER BY highID DESC">
			</asp:SqlDataSource>

		</contenttemplate>
	</asp:UpdatePanel>
</asp:Content>