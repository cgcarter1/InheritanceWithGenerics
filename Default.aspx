<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chad Carter Sample Code</title>
    <link href="style/chadcarterSample.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="content">
            <div class="list_form">
                <div class="selection_list">
                    <asp:RadioButtonList ID="rdlPersonType" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" />
                </div>
                <div class="selection_box">
                    <asp:ListBox ID="lbPerson" runat="server" Width="250px" Rows="8" AutoPostBack="true"/>
                </div>
            </div>
            <div class="person_form">
                <table>
                    <caption>Person Information</caption>
                    <tbody>
                        <tr>
                            <td>First Name</td>
                            <td><asp:TextBox ID="txtFirstNM" runat="server" Width="210px" /></td>
                        </tr>
                        <tr>
                            <td>Last Name</td>
                            <td><asp:TextBox ID="txtLastName" runat="server" Width="210px" /></td>
                        </tr>
                        <tr>
                            <td>Address</td>
                            <td><asp:TextBox ID="txtAddress" runat="server" Width="210px" /></td>
                        </tr>
                        <tr>
                            <td>City</td>
                            <td><asp:TextBox ID="txtCity" runat="server" Width="210px" /></td>
                        </tr>
                        <tr>
                            <td>State</td>
                            <td><asp:DropDownList ID="ddlState" runat="server" Width="210px" /></td>
                        </tr>
                        <tr>
                            <td>Zip</td>
                            <td><asp:TextBox ID="txtZip" runat="server" Width="210px" /></td>
                        </tr>
                        <tr>
                            <td>Person Type</td>
                            <td><asp:DropDownList ID="ddlPersonType" runat="server" Width="210px">
                                <asp:ListItem Text="" Value="0" />
                                <asp:ListItem Text="Employee" Value="emp" />
                                <asp:ListItem Text="Customer" Value="cust" />
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td colspan="5"><asp:Label ID="lblSTatus" runat="server" /></td>
                        </tr>
                    </tbody>
                    <tfoot>
                        <tr>
                            <td colspan="5"><asp:Button ID="btnAdd" runat="server" Text="Add Person" /> &nbsp;&nbsp;
                                <asp:Button ID="btnUpdate" runat="server" Text="Update Person" /> &nbsp;&nbsp;
                                <asp:Button ID="btnDelete" runat="server" Text="Delete Person" OnClientClick="return confirm('Are you sure you want to delete this user?');" />
                            </td>
                        </tr>
                    </tfoot>
                </table>
            </div>
            <div class="careerbuilder_example">
                <table>
                    <caption>CareerBuilder Code Sample</caption>
                    <tbody>
                        <tr>
                            <td><asp:TextBox ID="txtReverseString" runat="server" Width="210px" /></td>
                            <td><asp:Button ID="btnReverseString" runat="server" Text="Reverse String" /></td>
                            <td><asp:Label ID="lblReverseString" runat="server" /></td>
                        </tr>
                        <tr>
                            <td><asp:TextBox ID="txtCountCharacters" runat="server" Width="210px" /></td>
                            <td><asp:Button ID="btnCountCharacters" runat="server" Text="Count Characters" /></td>
                            <td><asp:Label ID="lblCharactersCount" runat="server" /></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
