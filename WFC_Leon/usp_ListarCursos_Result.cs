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
    
    public partial class usp_ListarCursos_Result
    {
        public string cod_curso { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> horas_teoria { get; set; }
        public Nullable<int> horas_practica { get; set; }
        public string nivel_dificultad { get; set; }
        public string comentarios { get; set; }
        public Nullable<int> IdEspecialidad { get; set; }
        public string DescEspecialidad { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
        public string usuario_registro { get; set; }
        public string usuario_ult_modificacion { get; set; }
        public Nullable<System.DateTime> fecha_ult_modificacion { get; set; }
        public Nullable<int> estado_cur { get; set; }
        public string tipo_estado { get; set; }
    }
}
