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
    using System.Collections.Generic;
    
    public partial class Tb_Evento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tb_Evento()
        {
            this.Tb_Asociado = new HashSet<Tb_Asociado>();
        }
    
        public int id_evento { get; set; }
        public Nullable<int> Id_empresa { get; set; }
        public Nullable<System.DateTime> fecha_inicio { get; set; }
        public Nullable<System.DateTime> fecha_fin { get; set; }
        public Nullable<int> id_frecuencia { get; set; }
        public Nullable<int> id_turno { get; set; }
        public Nullable<decimal> presupuesto_requerido { get; set; }
        public string direccion_evento { get; set; }
        public Nullable<int> cupos_programados { get; set; }
        public string Id_Expositor { get; set; }
        public string Id_Ubigeo { get; set; }
        public string cod_curso { get; set; }
        public string usuario_registro { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
        public string usuario_ult_modificacion { get; set; }
        public Nullable<System.DateTime> fecha_ult_modificacion { get; set; }
        public Nullable<int> estado_eve { get; set; }
    
        public virtual Tb_Curso Tb_Curso { get; set; }
        public virtual Tb_Empresa Tb_Empresa { get; set; }
        public virtual Tb_Expositor Tb_Expositor { get; set; }
        public virtual Tb_Ubigeo Tb_Ubigeo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_Asociado> Tb_Asociado { get; set; }
    }
}
