<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio202.Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Matriz N x N</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Matriz con diagonal inversa</h2>

        <asp:Label ID="Label1" runat="server" Text="Ingrese N: "></asp:Label>
        <asp:TextBox ID="txtN" runat="server"></asp:TextBox>
        <asp:Button ID="btnGenerar" runat="server" Text="Generar" OnClick="btnGenerar_Click" />

        <br /><br />
        <asp:Literal ID="litMatriz" runat="server"></asp:Literal>
    </form>
</body>
</html>
