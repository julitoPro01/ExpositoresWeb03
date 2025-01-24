<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavBar.ascx.cs" Inherits="ExpositoresWeb03.src.Components.NavBar" %>

<nav class="navbar navbar-expand-lg rounded-bottom" style="background-color:#5d6d7e">
  <div class="container-md ">
   
      <asp:HyperLink CssClass="navbar-brand text-light" NavigateUrl="~/src/pages/Inicio.aspx" ID="HyperLink1" runat="server">Eventos Leon</asp:HyperLink>
    <button class="navbar-toggler text-bg-light" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse position-relative" id="navbarNavDropdown">
      <ul class="navbar-nav">
        <li class="nav-item">
         <asp:HyperLink CssClass="nav-link active text-light" NavigateUrl="~/src/pages/Inicio.aspx" ID="HyperLink2" runat="server">Inicio</asp:HyperLink>
          
        </li>
        <li class="nav-item">

         <asp:HyperLink CssClass="nav-link active text-light" NavigateUrl="~/src/pages/Expositor.aspx" ID="HyperLink3" runat="server">Expositor</asp:HyperLink>
        </li>
          <li class="nav-item">

        <asp:HyperLink CssClass="nav-link active text-light" NavigateUrl="~/src/pages/Asociado.aspx" ID="HyperLink5" runat="server">Asociados</asp:HyperLink>
        </li>
          <li class="nav-item">

        <asp:HyperLink CssClass="nav-link active text-light" NavigateUrl="~/src/pages/Curso.aspx" ID="HyperLink6" runat="server">Cursos</asp:HyperLink>
        </li>
        <li class="nav-item">
         <asp:HyperLink CssClass="nav-link active text-light" NavigateUrl="~/src/pages/Inicio.aspx" ID="HyperLink4" runat="server">Sobre Nosotros</asp:HyperLink>
        </li>
        <li class="nav-item text-light">
            <asp:Button Style="margin-left:auto" CssClass=" btn btn-outline-dark rounded" ID="CerrarEventoLeon" runat="server" Text="Cerrar" OnClick="CerrarEventoLeon_Click" />
        </li>
      </ul>
    </div>
      <asp:Label CssClass="position-absolute top-100 end-0 text-light" ID="LabelUser" runat="server" Text="Label"> Usuario </asp:Label>
  </div>
</nav>