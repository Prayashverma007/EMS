<%@ Page Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="Manage-Registration-Add.aspx.cs" Inherits="Manage_Registration_Add" %>
<%@ Register Src="includes/ucRightMenu.ascx" TagName="ucRightMenu" TagPrefix="uc1" %>
<asp:Content ID="cMainContent" runat="server" ContentPlaceHolderID="cphMain">

    <div class="title">+Add/Edit Registration Details<br /><br /></div>
        <table cellpadding="5" cellspacing="5" border="0" width="450" align="center">
        <tr>
        <td colspan="2" align="center">
            <asp:Image ID="imgPhoto" runat="server" Height="100px" Width="100px" /></td>
        </tr>
        <tr>
        <td>EmployeeName</td>
        <td><asp:DropDownList ID="ddlEmployee" runat="server" Style="width: 300px">
            </asp:DropDownList></td>
        </tr>
        <tr>
        <td>DriverName</td>
        <td><asp:TextBox ID="TxtDrivername" runat="server" CssClass="input300"></asp:TextBox>
            <asp:TextBox ID="txtDateofEntry" runat="server" Visible="False"></asp:TextBox>
                                </td>
        </tr>
        <tr>
        <td>Locationfrom</td>
        <td><asp:DropDownList ID="ddlLocationfrm" runat="server" Style="width: 300px">
            </asp:DropDownList></td>
        </tr>
        <tr>
        <td>Locationto</td>
        <td><asp:DropDownList ID="ddlLocationto" runat="server" Style="width: 300px">
            </asp:DropDownList></td>
        </tr>
        <tr>
        <td>
            TripType</td>
        <td>
            <asp:DropDownList ID="ddlTriptype" runat="server" Style="width: 300px">
                <asp:ListItem Value="1">Local</asp:ListItem> 
                <asp:ListItem Value="0">Outstation</asp:ListItem>
            </asp:DropDownList></td>
        </tr>
            <tr>
                <td>
                    Starting Km</td>
                <td>
                    <asp:TextBox ID="txtStartKm" runat="server" CssClass="input300"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Closing Km</td>
                <td>
                    <asp:TextBox ID="txtCloseKm" runat="server" CssClass="input300"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Starting Time</td>
                <td>
                    <asp:TextBox ID="txtStarttime" runat="server" CssClass="input300"></asp:TextBox></td>
            </tr>            
            <tr>
                <td>
                    Closing Time</td>
                <td>
                    <asp:TextBox ID="txtClosingTime" runat="server" CssClass="input300"></asp:TextBox></td>
            </tr>
        <tr>
        <td>
            Date of Travel</td>
        <td><asp:TextBox ID="txtDOT" runat="server" CssClass="input300"></asp:TextBox>&nbsp;<a href="javascript:NewCal('<%=txtDOT.ClientID %>','mmddyyyy')"><img src="images/cal.gif" width="16" height="16" border="0" alt="Pick a date"></a></td>
        </tr>
        <tr>
        <td>
            Company Name</td>
        </td>
        <td>
            <asp:DropDownList ID="ddlCompanyName" runat="server" Style="width: 300px">
            </asp:DropDownList></td>
        </tr>
        <tr>
        <td>
            AdvancetoDriver</td>
        <td><asp:TextBox ID="txtAdvance" runat="server" CssClass="input300"></asp:TextBox>
            </td>
        </tr>
        <tr>
        <td>
            Diesel</td>
        <td><asp:TextBox ID="txtDiesel" runat="server" CssClass="input300"></asp:TextBox>
            </td>
        </tr>
        <td colspan="2" align="center">
        <asp:Button ID="btnSave" runat="server" CssClass="buttonBlue" Text="Save" OnClick="btnSave_Click" />
        <asp:Button ID="btnUpdate" runat="server" CssClass="buttonBlue" Text="Update" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnCancel" runat="server" CssClass="buttonBlue" Text="Cancel" CausesValidation="False" OnClick="btnCancel_Click" />
        </td>
        </tr>
        </table>
</asp:Content>
<asp:Content ID="cRightMenu" runat="server" ContentPlaceHolderID="cphRight">
    <uc1:ucRightMenu ID="UcRightMenu1" runat="server" />
</asp:Content>