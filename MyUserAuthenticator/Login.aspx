<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyUserAuthenticator.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Welcome !!<br />
            <br />
            <br />
            <asp:Label ID="txtUserName" runat="server"></asp:Label>
&nbsp;<br />
            <asp:Label ID="txtUserRole" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Enter Name"></asp:Label>
            <br />
            <asp:TextBox ID="txtUserNameInput" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Enter Role"></asp:Label>
            <br />
            <asp:DropDownList ID="ddlUserRoles" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <br />
        </div>
        <asp:Button ID="BtnLogin" runat="server" OnClick="Button1_Click" Text="Login" />
    </form>
</body>
</html>
