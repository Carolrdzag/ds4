<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio20.Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Tabla de Multiplicar</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Tabla de Multiplicar hasta 25</h2>
            <asp:Label ID="Label1" runat="server" Text="Ingrese un número: "></asp:Label>
            <asp:TextBox ID="txtNumero" runat="server"></asp:TextBox>
            <asp:Button ID="btnGenerar" runat="server" Text="Generar" OnClick="btnGenerar_Click" />

            <br /><br />
            <asp:Literal ID="litTabla" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>


