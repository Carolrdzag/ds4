<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio17._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="row">

            <!-- GridView: Muestra datos en forma de tabla -->
            <!-- DataSourceID="MyDataSource1": se conecta al SqlDataSource -->
            <!-- AllowSorting y AllowPaging: permite ordenar y paginar -->
            <!-- AutoGenerateEditButton: agrega boton para editar registros -->

            <asp:GridView id="MyGridView" DataSourceID="MyDataSource1"  
                AllowSorting="True" AllowPaging="True"
                DataKeyNames="ProductID"
                AutoGenerateEditButton="True"
            Runat="Server"/>

            <!-- Runat="Server": le dice a ASP.NET que ese control debe ser procesado en el servidor, no solo como HTML estático. -->

            <asp:SqlDataSource ID="MyDataSource1" runat="server"
                ConnectionString="data source=LAPTOP-PHQ6JRUD\SQLEXPRESS;initial catalog=northwind;persist security info=true;Integrated Security=SSPI;"
                ProviderName="System.Data.SqlClient"
                SelectCommand="SELECT ProductId, ProductName, UnitPrice From Products"
                UpdateCommand="Update Products Set [ProductName]=@ProductName, [UnitPrice]=@UnitPrice Where [ProductId]=@ProductId">
            </asp:SqlDataSource>
          
        </div>
  

</asp:Content>

<!-- ConnectionString: detalles de conexión a SQL Server -->
<!-- SelectCommand: consulta SQL para seleccionar datos -->
<!-- UpdateCommand: consulta SQL para actualizar datos -->
