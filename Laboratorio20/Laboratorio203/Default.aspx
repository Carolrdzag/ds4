<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio203.Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>CRUD Laptops - WebForms</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Laboratorio 20 - Parte 3</h2>

        <label>ID:</label>
        <asp:TextBox ID="txtId" runat="server" Width="100"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" /><br /><br />

        <label>Nombre:</label>
        <asp:TextBox ID="txtNombre" runat="server" Width="250"></asp:TextBox><br /><br />

        <label>Precio:</label>
        <asp:TextBox ID="txtPrecio" runat="server" Width="120"></asp:TextBox><br /><br />

        <label>Stock:</label>
        <asp:TextBox ID="txtStock" runat="server" Width="120"></asp:TextBox><br /><br />

        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" /><br /><br />

        <asp:Button ID="btnSalir" runat="server" Text="Salir" OnClick="btnSalir_Click" />

    </form>
</body>
</html>