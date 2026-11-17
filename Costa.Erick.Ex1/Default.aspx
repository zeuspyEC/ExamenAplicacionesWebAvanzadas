<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Costa.Erick.Ex1._Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8" />
    <title>Recetas de cocina</title>
    <link href="Estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <h1>Recetas de cocina</h1>
        <p><a class="boton" href="RecetaFormulario.aspx">+ Nueva receta</a></p>

        <asp:Label ID="lblMensaje" runat="server" CssClass="mensaje" />

        <%-- READ: tabla con las recetas. DELETE: botón Eliminar de cada fila --%>
        <asp:GridView ID="gvRecetas" runat="server" AutoGenerateColumns="false" DataKeyNames="RecetaId"
            OnRowDeleting="gvRecetas_RowDeleting" EmptyDataText="No hay recetas registradas.">
            <Columns>
                <asp:BoundField DataField="RecetaId" HeaderText="Id" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="PaisOrigen" HeaderText="País de origen" />
                <asp:BoundField DataField="Ingredientes" HeaderText="Ingredientes" />
                <asp:BoundField DataField="TiempoPreparacion" HeaderText="Tiempo (min)" />
                <asp:TemplateField HeaderText="Vegetariana">
                    <ItemTemplate><%# (bool)Eval("Vegetariana") ? "Sí" : "No" %></ItemTemplate>
                </asp:TemplateField>
                <asp:HyperLinkField Text="Editar" DataNavigateUrlFields="RecetaId"
                    DataNavigateUrlFormatString="RecetaFormulario.aspx?id={0}" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEliminar" runat="server" CommandName="Delete" Text="Eliminar"
                            OnClientClick="return confirm('¿Eliminar esta receta?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
