<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ViewAddCurso.aspx.cs" Inherits="ExpositoresWeb03.src.pages.view.ViewAddCurso" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="py-3 mb-4">

    <asp:Button CssClass="btn btn-outline-secondary fs-3" ID="Button1" runat="server" Text="<-|" OnClick="Button1_Click" />

    <h3 class="mx-4 pt-2 text-light" style="display:inline-block" >Añadir</h3>
<hr style="color:gray" />
</div>


        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
        <ContentTemplate>

    <div class="row row-cols-1 row-cols-sm-2 row-cols-md-2 g-2">

    <table class="pe-4 auto-style15" aria-multiline="True">
        <tr>
            <td>
                <p class="text-nowrap m-0">
                <asp:Label ID="LabelDesc" runat="server" Text="Descripción* :" ForeColor="White"></asp:Label>
                </p>
            </td>
            <td>
                <asp:TextBox Class="form-control input_focus " ID="InputDesc" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <p class="text-nowrap m-0">
                <asp:Label ID="LabelTeo" runat="server" Text="Horas de Teoria* :" ForeColor="White"></asp:Label>
                </p>
            </td>
            <td>
                <asp:TextBox CssClass="form-control" ID="InputTeo" runat="server" MaxLength="2"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelPrac" runat="server" Text="Horas de Practica* :" ForeColor="White"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="form-control" ID="InputPrac" runat="server" MaxLength="2"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelNiv" runat="server" Text="Nivel de Dificultad* :" ForeColor="White"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownListNivel" CssClass="w-100 rounded" runat="server" DataTextField="---Seleccione el nivel--" DataValueField="0">
                    <asp:ListItem Selected="True" Value="0">--Seleccione un nivel--</asp:ListItem>
                    <asp:ListItem>Baja</asp:ListItem>
                    <asp:ListItem>Media</asp:ListItem>
                    <asp:ListItem>Alta</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelEsp" runat="server" Text="Especialidad* :" ForeColor="White"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownListEsp" runat="server" CssClass="w-100 rounded">
                    <asp:ListItem Value="0">--Seleccione una especialidad</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        
    </table>
    <br />
    <br />

    <div class="px-3">
        <asp:TextBox CssClass="mt-2 w-100 rounded "  ID="InputCom" Placeholder="Comentario"  runat="server" TextMode="MultiLine"></asp:TextBox>
    <asp:RadioButtonList CssClass="mt-2" ID="RadioButtonList1" runat="server" ForeColor="White">
        <asp:ListItem Text="Activo" Value="Activo" Selected ></asp:ListItem>
        <asp:ListItem Text="Inactivo" Value="Inactivo"></asp:ListItem>
   </asp:RadioButtonList>
    </div >

</div>
    <hr style="border-color:gray" />

    <asp:Label ID="LabelError" CssClass=" fs-3 text-danger text-danger" runat="server" EnableViewState="false" Text=""></asp:Label>
    <div class="d-flex justify-content-end pt-3">

      <asp:Button class="btn btn-outline-success my-3" ID="btn_save" runat="server" Text="Guardar" OnClick="btn_save_Click" />

    </div>



        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger EventName="Click" ControlID="btn_save" />
        </Triggers>
    </asp:UpdatePanel>


<div class="modal fade" id="pageAddModal" tabindex="-1" aria-labelledby="pageAddModalLabel" aria-hidden="true">
<div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h1 class="modal-title fs-5" id="pageAddModalLabel">Alerta!</h1>
        </div>
      <div class="modal-body">
        <p class="text-success fs-3 badge "> Se añadio Correctamente </p>
          <asp:Label ID="IDmsgModal" runat="server" ></asp:Label>
      </div>
    </div>
  </div>
</div>

        <script type="text/javascript" >
        function openModal() {
            var modal = document.getElementById("pageAddModal");
            var showModal = new bootstrap.Modal(modal);
            showModal.show();
            }


        </script>


</asp:Content>
