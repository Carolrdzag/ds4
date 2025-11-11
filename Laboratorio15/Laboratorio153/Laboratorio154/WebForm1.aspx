<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Laboratorio154.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="SUMA DE 2 NÚMEROS"></asp:Label>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Ingrese el primer número:"></asp:Label>
            <asp:TextBox ID="txtNum1" runat="server" Width="155px"></asp:TextBox>
        </p>
        <asp:Label ID="Label3" runat="server" Text="Ingrese el segundo número:"></asp:Label>
        <asp:TextBox ID="txtNum2" runat="server" Width="162px"></asp:TextBox>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sumar" />
        </p>
        <asp:Label ID="lblResultado" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
