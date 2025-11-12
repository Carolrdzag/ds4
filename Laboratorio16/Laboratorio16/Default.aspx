<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio16._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    
        <div class="row">

            <div style="height:200px; width:500px;">
                <asp:Label ID="lblMensaje" runat="server" BackColor="White" BorderColor="Black" BorderStyle="None"></asp:Label>
               <asp:label ID="lbMensaje" runnat="server" ForeColor="Red" Font-Size="35px"/>

             </div>   
            <div style=""heght:200px; wiidth:500px;">
                <asp:Button ID="btnMensaje" Text="Mostrar Mensaje" Tooltip="Dar click para mostrar mensaje" runat="server" onClick="btnMensaje_Click"/>
             </div> 
        </div>
   

</asp:Content>
