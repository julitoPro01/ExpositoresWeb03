<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ViewUpdateAsociado.aspx.cs" Inherits="ExpositoresWeb03.src.pages.view.ViewUpdateAsociado" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="py-3 mb-4">

    <asp:Button CssClass="btn btn-outline-secondary fs-3" ID="Button1" runat="server" Text="<-|" OnClick="Button1_Click" />

    <h3 class="mx-4 pt-2 text-light" style="display:inline-block" >Actualizar</h3>



<hr style="color:gray" />
 <span class="text-light fs-2">Codigo: </span>   <asp:Label CssClass="text-danger fs-3" ID="idLabelAsociado" runat="server" Text=""></asp:Label>
</div>

    
        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
        <ContentTemplate>
           <asp:Panel ID="IDcontainer_panel" runat="server">


    <div class="row row-cols-1 row-cols-sm-2 row-cols-md-2 g-2">

    <table class="pe-4 auto-style15">
        <tr>
            <td>
                <p class="text-nowrap m-0">
                <asp:Label ID="LabelPat" runat="server" Text="Apellido paterno* :" ForeColor="White"></asp:Label>
                </p>
            </td>
            <td>
                <asp:TextBox Class="form-control input_focus " ID="InputPat" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <p class="text-nowrap m-0">
                <asp:Label ID="LabelMat" runat="server" Text="Apellido Materno* :" ForeColor="White"></asp:Label>
                </p>
            </td>
            <td>
                <asp:TextBox CssClass="form-control" ID="InputMat" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelNom" runat="server" Text="Nombre* :" ForeColor="White"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="form-control" ID="InputNom" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelTelDom" runat="server" Text="Número tel. de Domicilio* :" ForeColor="White"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="form-control" ID="InputTel" runat="server" MaxLength="9"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelTelCel" runat="server" Text="Numero de Celular* :" ForeColor="White"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="InputCel" runat="server" CssClass="w-100 p-2 rounded" MaxLength="9"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelEma" runat="server" Text="Email* :" ForeColor="White"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="form-control" ID="InputEma" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelDni" runat="server" Text="DNI* :" ForeColor="White"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="form-control" ID="InputDni" runat="server" MaxLength="8"></asp:TextBox>
            </td>
        </tr>
        <tr>
             <td>
            <asp:Label ID="LabelEmpre" runat="server" Text="Empresa* :" ForeColor="White"></asp:Label>
            </td>
            <td>
            <asp:DropDownList ID="DropDownListEmp" runat="server" CssClass="w-100 rounded">
            </asp:DropDownList>
            </td>
        </tr>
        
    </table>
    <br />
    <br />
    <div class="m-0 p-0 row px-3">
        <div class="col-12 col-lg-6" >

            <span class="text-light mt-2" > Fecha de Ingreso* :  </span>  <label for="fechaIngreso" ID="Labelfechaingreso" runat="server" class="text-info badge fs-6 mt-2" ></label>         
            <asp:Calendar ID="fechaIngreso" runat="server" CssClass="calendar text-dark bg-light" />
        </div>
        <div class="col-12 col-lg-6" >

            <span class="text-light mt-2" > Ultima capacitación* : </span>   <label for="fechaUlCap" ID="LabelfechaUlCap" runat="server" class="text-info badge fs-6 mt-2" ></label>        
            <asp:Calendar ID="fechaUlCap" runat="server" CssClass="calendar text-dark bg-light" />
       </div>
        <div>

            <div class=" form-floating mt-2">
                <asp:TextBox  CssClass="form-control my-1" placeholder="Dirección" ID="InputDir" runat="server"></asp:TextBox>
                <label for="textDir" id="LabelDir">Dirección*</label>
            </div>
        </div>
        <div>

            <div class=" form-floating">
                <asp:TextBox    CssClass="form-control my-2" placeholder="Ubigeo" ID="InputUbi" runat="server" MaxLength="6">010110</asp:TextBox>
                <label for="textUbi" id="LabelUbi">Ubigeo*</label>
            </div>
        </div>

    <asp:RadioButtonList CssClass="mt-2" ID="RadioButtonList1" runat="server" ForeColor="White">
        <asp:ListItem Text="Activo" Value="Activo" Selected ></asp:ListItem>
        <asp:ListItem Text="Inactivo" Value="Inactivo"></asp:ListItem>
   </asp:RadioButtonList>
    </div >
        
    <div class=" col-12 my-3">
          <asp:Label ID="LabelFoto" runat="server" Text="Seleccionar Foto :" ForeColor="White"></asp:Label>
                  
        <ajaxToolkit:AsyncFileUpload ID="asyncFileUpload" runat="server" 
            OnUploadedComplete="asyncFileUpload_UploadedComplete" 
            ClientIDMode="Static"  />

          <asp:Image Width="100" Height="100" ID="ImageFoto" runat="server" />

 
    </div>
</div>
    <hr style="border-color:gray" />

    <asp:Label ID="LabelError" CssClass=" fs-3 text-danger text-danger" runat="server" EnableViewState="false" Text=""></asp:Label>
    <div class="d-flex justify-content-end pt-3">

      <asp:Button class="btn btn-outline-success my-3" ID="btn_save" runat="server" Text="Guardar" OnClick="btn_save_Click" />

    </div>


               
           </asp:Panel>

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
        <p class="text-success fs-3 badge "> Se actualizo Correctamente </p>
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
