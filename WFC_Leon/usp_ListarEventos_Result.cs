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
    
    public partial class usp_ListarEventos_Result
    {
        public int id_evento { get; set; }
        public Nullable<int> Id_empresa { get; set; }
        public string Razon_Social { get; set; }
        public Nullable<int> id_frecuencia { get; set; }
        public string frecuencia { get; set; }
        public Nullable<int> id_turno { get; set; }
        public Nullable<System.DateTime> fecha_inicio { get; set; }
        public Nullable<System.DateTime> fecha_fin { get; set; }
        public string Turno { get; set; }
        public Nullable<decimal> presupuesto_requerido { get; set; }
        public string direccion_evento { get; set; }
        public Nullable<int> cupos_programados { get; set; }
        public string Id_Expositor { get; set; }
        public string Apellido_paterno { get; set; }
        public string Nombre { get; set; }
        public string Id_Ubigeo { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string cod_curso { get; set; }
        public string descripcion { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
        public string usuario_ult_modificacion { get; set; }
        public Nullable<System.DateTime> fecha_ult_modificacion { get; set; }
        public Nullable<int> estado_eve { get; set; }
        public string tipo_estado { get; set; }
        public string usuario_registro { get; set; }
    }
}
