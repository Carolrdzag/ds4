<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Respuestas.aspx.cs" Inherits="Parcial3.Respuestas" %>

<!DOCTYPE html>
<html>
<head>
    <title>Respuestas - Sistema de Gestión Legal</title>
    <link rel="stylesheet" 
          href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
</head>
<body class="bg-light">

<div class="container mt-5">

    <h2 class="text-center mb-4">Respuestas del Proyecto</h2>

    <asp:Repeater ID="rptRespuestas" runat="server">
        <ItemTemplate>
            <div class="card mb-3 shadow-sm">
                <div class="card-header bg-dark text-white">
                    <h5><%# Eval("Pregunta") %></h5>
                </div>
                <div class="card-body">
                    <p><%# Eval("Respuesta") %></p>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

</div>

</body>
</html>