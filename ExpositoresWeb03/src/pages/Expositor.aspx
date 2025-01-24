<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Expositor.aspx.cs" Inherits="ExpositoresWeb03.src.pages.Expositor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-lg">


        <br />
        <h3 class="fs-3 text-light" > Expositor </h3>
        <br />
  
   
        <div class="row justify-content-start w-100" style="overflow:auto" >
   
        <div style="min-width:1000px;min-height:500px;overflow:auto" >

        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate >
                     
        <div class="m-2 p-0" > 
           
             <div class="d-flex justify-content-center input-group mb-3" style="max-width:500px">
                   <asp:TextBox Class="" ID="search" CssClass="form-control" runat="server" AutoPostBack="true" Placeholder="Buscar por apellido" OnTextChanged="search_TextChanged"></asp:TextBox>
     
                 <button class="btn">
                  <span class="input-group-text" id="basic-addon1" onclick="search_TextChanged" >
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
                    <path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001q.044.06.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1 1 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0"/>
                     </svg>
                  </span>
                 </button>
              </div>
      
         </div>
              <asp:GridView CssClass="w-100" ID="idExpositorGrid" runat="server" BackColor="Silver" BorderColor="#CCCCCC"
            BorderStyle="None" BorderWidth="1px" CellPadding="7" GridLines="Horizontal"
            AutoGenerateColumns="False" AllowPaging="True"
            OnPageIndexChanging="idExpositorGrid_PageIndexChanging" CellSpacing="5" OnRowDataBound="idExpositorGrid_RowDataBound" OnSelectedIndexChanged="idExpositorGrid_SelectedIndexChanged1" AutoGenerateSelectButton="True" HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="Id_Expositor" HeaderText="Nro" />
                <asp:BoundField DataField="Apellido_materno" HeaderText="Ape.Paterno" />
                <asp:BoundField DataField="Apellido_paterno" HeaderText="Ape.Materno" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                <asp:BoundField DataField="Comentario" HeaderText="Comentario" />
 
               <asp:TemplateField HeaderText="Foto">
               <ItemTemplate>
                    <asp:Image ID="imgFoto" runat="server" ImageUrl='<%# Eval("Foto_Expositor") %>' Width="100px" Height="100px" />
               </ItemTemplate>
               </asp:TemplateField>
 
                <asp:BoundField DataField="tipo_estado" HeaderText="Estado" />
 
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" BorderColor="White" BorderStyle="Dotted" />
            <SelectedRowStyle Font-Bold="False" />
            <PagerStyle BackColor="Black" ForeColor="White" HorizontalAlign="center" />
        
        </asp:GridView>

        </ContentTemplate>
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="idExpositorGrid" EventName="PageIndexChanging" />
        </Triggers>
        </asp:UpdatePanel>

        </div>
        </div>
              
                <asp:Label ID="ErrorMsg" runat="server" Text=""></asp:Label>
              
        <br />

         <div class="d-flex justify-content-around  m-0 p-2 rounded" style="position:sticky;bottom:0px;background-color:#5d6d7e" >
             
            <asp:Label Style="font-weight:bold" CssClass="fs-3 text-danger px-2 w-100" ID="smgOfDelete" runat="server" Text=""></asp:Label>
           <br />
             <asp:Button CssClass="mx-2 btn btn-outline-light"  ID="Button1" runat="server" PostBackUrl="~/src/pages/view/ViewAdd.aspx" Text="Añadir" />
            <asp:Button CssClass="mx-2 btn btn-outline-warning" ID="btnviewUpdate" runat="server" PostBackUrl="~/src/pages/view/ViewUpdate.aspx" Text="Actualizar" />
   
              <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                <ContentTemplate >
                    <asp:Button   class="mx-2 btn btn-outline-danger" type="button"  ID="Button3" data-bs-toggle="modal" data-bs-target="#staticBackdrop" runat="server" Text="Eliminar" OnClick="Button3_Click" />
         </ContentTemplate>
         <Triggers>
               <asp:AsyncPostBackTrigger ControlID="Button3"  EventName="Click" />

         </Triggers>
         </asp:UpdatePanel>

             <asp:Label CssClass="mx-2 text-light" ID="count" runat="server" Text=""></asp:Label>

         </div>

    </div>

<!-- Modal -smg - delete -->
<div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h1 class="modal-title fs-5" id="staticBackdropLabel">Eliminar</h1>
      </div>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate >
      <div class="modal-body">
        
          <asp:Label ID="LabelModalsmg" runat="server" Text=""></asp:Label>
            <asp:Label CssClass="fs-4 badge text-info" ID="labelConfirmar"  runat="server" Text=""></asp:Label>
      </div>
      <div class="modal-footer">
       
          <asp:Button type="button" Class="btn btn-secondary" ID="btnclosemodal" data-bs-dismiss="modal" runat="server" Text="Close" OnClick="btnclosemodal_Click"  />

          <asp:Button type="button" Class="btn btn-danger" ID="Button2" runat="server" Text="Confirmar" OnClick="Button2_Click" />
         </ContentTemplate>
         <Triggers>
               <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="Button3" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btnclosemodal" EventName="Click" />
         </Triggers>
         </asp:UpdatePanel>


      </div>
    </div>
  </div>

</asp:Content>
