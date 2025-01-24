<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="ExpositoresWeb03.src.pages.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 d-flex justify-content-center flex-column align-items-center text-light " style="height: 90vh">
        <h1 class="my-3">Mantenimiento </h1>
        <div style="max-width: 500px">

            <asp:Image ID="Imagelogo" CssClass="w-100" runat="server" ImageUrl="~/src/images/logoEventosLeon01.png" />
        </div>
        <p class="fs-1">Eventos Leon S.A</p>
        <asp:Label ID="LabelUsuario" runat="server" Text=""></asp:Label>
    </div>
    
  
    <asp:Panel ID="pnlModal" runat="server" CssClass="modal-panel">
        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
            <ContentTemplate>


        <div style="padding: 20px; background-color: #fff; border: 1px solid #ccc;">
            <h2>Autenticación</h2>
            <asp:TextBox CssClass="my-2 p-1" placeHolder="Usuario" ID="TextBoxNombre" runat="server">alaos</asp:TextBox>
            <br />
            <asp:TextBox CssClass="my-2 p-1" placeHolder="Contraseña" ID="TextBoxPassword" runat="server">09876</asp:TextBox>
             <hr />
            <asp:Label ID="laberErrorUser" runat="server" Text=""></asp:Label>
            
            <hr />
            <asp:Button ID="btnClose" runat="server" Text="Entrar" OnClick="btnClose_Click" />

         </di>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnClose" EventName="click" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>

    <ajaxToolkit:ModalPopupExtender
        ID="ModalPopupExtenderAuth" 
        runat="server"
        TargetControlID="btnShowModal" 
        PopupControlID="pnlModal"
        BackgroundCssClass="modal-background">
    </ajaxToolkit:ModalPopupExtender>
  <asp:Button ID="btnShowModal" CssClass="d-none "    runat="server" Text="Abrir Modal" />

    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel8">
    <ProgressTemplate>
        <div class="bg-light" style="display: flex; align-items: center; justify-content: center;">
            <div class="spinner-border" role="status">
            <span class="visually-hidden">Loading...</span>
            </div>
            <span style="margin-left: 10px;">Cargando, por favor espere...</span>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>

</asp:Content>
