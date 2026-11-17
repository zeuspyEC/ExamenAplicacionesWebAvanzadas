<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecetaFormulario.aspx.cs" Inherits="Costa.Erick.Ex1.RecetaFormulario" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8" />
    <title>Receta</title>
    <link href="Estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <%-- CREATE (sin id) y UPDATE (con ?id=N) en el mismo formulario --%>
        <h1><asp:Label ID="lblTitulo" runat="server" Text="Nueva receta" /></h1>

        <table class="formulario">
            <tr>
                <td>Nombre:</td>
                <td><asp:TextBox ID="txtNombre" runat="server" MaxLength="100" />
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Obligatorio" CssClass="error" /></td>
            </tr>
            <tr>
                <td>País de origen:</td>
                <td><asp:TextBox ID="txtPais" runat="server" MaxLength="60" />
                    <asp:RequiredFieldValidator ID="rfvPais" runat="server" ControlToValidate="txtPais" ErrorMessage="Obligatorio" CssClass="error" /></td>
            </tr>
            <tr>
                <td>Ingredientes:</td>
                <td><asp:TextBox ID="txtIngredientes" runat="server" TextMode="MultiLine" Rows="4" />
                    <asp:RequiredFieldValidator ID="rfvIngredientes" runat="server" ControlToValidate="txtIngredientes" ErrorMessage="Obligatorio" CssClass="error" /></td>
            </tr>
            <tr>
                <td>Tiempo de preparación (min):</td>
                <td><asp:TextBox ID="txtTiempo" runat="server" MaxLength="4" />
                    <asp:RequiredFieldValidator ID="rfvTiempo" runat="server" ControlToValidate="txtTiempo" ErrorMessage="Obligatorio" CssClass="error" Display="Dynamic" />
                    <asp:RangeValidator ID="rvTiempo" runat="server" ControlToValidate="txtTiempo" Type="Integer" MinimumValue="1" MaximumValue="1440"
                        ErrorMessage="Entre 1 y 1440" CssClass="error" Display="Dynamic" /></td>
            </tr>
            <tr>
                <td>Vegetariana:</td>
                <td><asp:RadioButtonList ID="rblVegetariana" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Sí" Value="1" />
                        <asp:ListItem Text="No" Value="0" Selected="True" />
                    </asp:RadioButtonList></td>
            </tr>
        </table>

        <p>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="boton" OnClick="btnGuardar_Click" />
            <a href="Default.aspx">Cancelar</a>
        </p>
        <asp:Label ID="lblError" runat="server" CssClass="error" />
    </form>
</body>
</html>
