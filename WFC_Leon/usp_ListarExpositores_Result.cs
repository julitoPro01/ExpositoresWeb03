//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WFC_Leon
{
    using System;
    
    public partial class usp_ListarExpositores_Result
    {
        public string Id_Expositor { get; set; }
        public string Apellido_materno { get; set; }
        public string Apellido_paterno { get; set; }
        public string Nombre { get; set; }
        public string Dirección { get; set; }
        public string Telefono { get; set; }
        public string E_mail { get; set; }
        public string DNI { get; set; }
        public byte[] Foto_Expositor { get; set; }
        public string Comentario { get; set; }
        public string Id_Ubigeo { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
        public string usuario_ult_modificacion { get; set; }
        public Nullable<System.DateTime> fecha_ult_modificacion { get; set; }
        public Nullable<int> estado_exp { get; set; }
        public string tipo_estado { get; set; }
    }
}
