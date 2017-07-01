<%@ Page Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="Manage-Registration.aspx.cs" Inherits="Manage_Registration" %>
<%@ Register Src="includes/ucRightMenu.ascx" TagName="ucRightMenu" TagPrefix="uc1" %>
<asp:Content ID="cMainContent" runat="server" ContentPlaceHolderID="cphMain">
    <div class="title">Manage Registration Details<br /><br /></div>
        <div style="text-align:center"><asp:Label ID="lblMessage" runat="server"></asp:Label></div>
        <div style="text-align:right">
              <asp:Button ID="btnSave" runat="server" CssClass="buttonBlue" 
                Text="Add New Registration" style="width:100px" OnClick="btnSave_Click" 
                Width="132px" /></div><br/>
        <asp:GridView ID="gvMaster" runat="server" AutoGenerateColumns="False" CellPadding="2" ForeColor="#333333" GridLines="Both" BorderStyle="Solid" BorderColor="#000000" Width="50%" OnRowCommand="gvMaster_RowCommand" OnRowDataBound="gvMaster_RowDataBound" OnRowDeleting="gvMaster_RowDeleting" AllowPaging="True" OnPageIndexChanging="gvMaster_PageIndexChanging" PageSize="5">
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="lblRegID" runat="server" Text='<%# Eval("RegId").ToString() %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="40px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="EmpName">
                    <ItemTemplate>
                        <asp:Label ID="lblEmpName" runat="server" Text='<%# Eval("Name").ToString() %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="40px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DriverName">
                    <ItemTemplate>
                        <asp:Label ID="lblDriverName" runat="server" Text='<%# Eval("Drivername").ToString() %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="40px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Client">
                    <ItemTemplate>
                        <asp:Label ID="lblClientName" runat="server" Text='<%# Eval("ClientName").ToString() %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="40px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Pickup">
                    <ItemTemplate>
                        <asp:Label ID="lblLocationfrm" runat="server" Text='<%# Eval("LocationfrmName").ToString() %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="40px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Drop">
                    <ItemTemplate>
                        <asp:Label ID="lblLocationto" runat="server" Text='<%# Eval("LocationtoName").ToString() %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="40px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Trip Type">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblTriptype" Text='<%# Eval("TripType").ToString() %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="110px" HorizontalAlign="Center"  />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TravelDate">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblDOT" Text='<%# Eval("DOT").ToString() %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="110px" HorizontalAlign="Center"  />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lbEdit" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("RegId") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="50px" HorizontalAlign="Center"  />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lbDelete" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("RegId") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="50px" HorizontalAlign="Center"  />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PrintBill">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lblPrint" Text="Print" CommandName="Print" CommandArgument='<%# Eval("RegId") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="50px" HorizontalAlign="Center"  />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" CssClass="pager" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <AlternatingRowStyle BackColor="#EFF3FB" />
        </asp:GridView>
    
    
</asp:Content>
<asp:Content ID="cRightMenu" runat="server" ContentPlaceHolderID="cphRight">
    <uc1:ucRightMenu ID="UcRightMenu1" runat="server" />
</asp:Content>
