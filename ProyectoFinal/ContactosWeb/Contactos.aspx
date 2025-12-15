<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="Contactos.aspx.cs" Inherits="ContactosWeb.Pages.Contactos" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Agenda de Contactos</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
            background-color: #f9f9f9;
        }

        h1 {
            text-align: center;
            color: #2c3e50;
            margin-bottom: 20px;
            font-weight: normal;
        }

        h3 {
            margin-bottom: 5px;
            font-weight: normal;
            color: #34495e;
        }

        h4 {
            margin-top: 0;
            margin-bottom: 10px;
            font-weight: normal;
            color: #7f8c8d;
            font-size: 14px;
        }

        input[type="text"], .aspNetDisabled {
            padding: 6px;
            border: 1px solid #ccc;
            border-radius: 4px;
            width: 250px;
            margin-bottom: 10px;
        }

        input[type="submit"], button, .aspNetDisabled {
            background-color: #3498db;
            color: white;
            border: none;
            padding: 8px 15px;
            margin: 5px;
            border-radius: 4px;
            cursor: pointer;
        }

        input[type="submit"]:hover {
            background-color: #2980b9;
        }

        .gridview {
            border-collapse: collapse;
            width: 100%;
            margin-top: 15px;
        }

        .gridview th, .gridview td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: center;
        }

        .gridview th {
            background-color: #3498db;
            color: white;
        }

        .gridview tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        .gridview tr:hover {
            background-color: #ddd;
        }

        #lblMensaje {
            display: block;
            margin-top: 15px;
            font-weight: bold;
            color: #27ae60;
        }
    </style>

    <!-- Validaciones con JavaScript -->
    <script type="text/javascript">
        function validarFormulario() {
            var nombre = document.getElementById("<%= txtNombre.ClientID %>").value.trim();
            var telefono = document.getElementById("<%= txtTelefono.ClientID %>").value.trim();
            var correo = document.getElementById("<%= txtCorreo.ClientID %>").value.trim();

            if (nombre === "" || telefono === "" || correo === "") {
                alert("Debe completar todos los campos antes de guardar o actualizar.");
                return false;
            }

            var regexCorreo = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            if (!regexCorreo.test(correo)) {
                alert("Ingrese un correo válido.");
                return false;
            }

            var regexTelefono = /^[0-9\-]+$/;
            if (!regexTelefono.test(telefono)) {
                alert("Ingrese un teléfono válido (solo números y guiones).");
                return false;
            }

            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Agenda de Contactos</h1>

            <!-- BUSCAR -->
            <h3>Buscar contacto por nombre</h3>
            <h4>No ingrese caracteres especiales*</h4>
            <asp:TextBox ID="txtBuscar" runat="server" CssClass="textbox" />
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="button" />
            <asp:Button ID="btnMostrarTodos" runat="server" Text="Mostrar Todos" OnClick="btnMostrarTodos_Click" CssClass="button" />
            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" CssClass="button" />
            <asp:Button ID="btnReportePdf" runat="server" Text="Generar PDF" OnClick="btnReportePdf_Click" CssClass="button" />

            <hr />

            <!-- TABLA -->
            <asp:GridView ID="GridContactos" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
                OnSelectedIndexChanged="GridContactos_SelectedIndexChanged" CssClass="gridview">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Editar" />
                </Columns>
            </asp:GridView>

            <hr />

            <!-- FORMULARIO -->
            <h3>Formulario de Contacto</h3>
            <asp:HiddenField ID="txtId" runat="server" />

            Nombre:<br />
            <asp:TextBox ID="txtNombre" runat="server" CssClass="textbox" /><br />

            Teléfono:<br />
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="textbox" /><br />

            Correo:<br />
            <asp:TextBox ID="txtCorreo" runat="server" CssClass="textbox" /><br /><br />

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar"
                OnClick="btnGuardar_Click" OnClientClick="return validarFormulario();" CssClass="button" />

            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar"
                OnClick="btnActualizar_Click" OnClientClick="return validarFormulario();" CssClass="button" />

            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CssClass="button" />

            <asp:Label ID="lblMensaje" runat="server" />
        </div>
    </form>
</body>
</html>

