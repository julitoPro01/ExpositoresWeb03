﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExpositoresWeb03.ServiceReferenceExpositor {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ExpositorDC", Namespace="http://schemas.datacontract.org/2004/07/WFC_Leon")]
    [System.SerializableAttribute()]
    public partial class ExpositorDC : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Apellido_maternoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Apellido_paternoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ComentarioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DepartamentoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DireccionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DistritoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DniField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> Fec_RegistroField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> Fec_Ult_ModField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] Foto_ExpositorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Id_ExpositorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Id_UbigeoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProvinciaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TelefonoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Usu_Ult_ModField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> estado_expField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string tipo_estadoField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Apellido_materno {
            get {
                return this.Apellido_maternoField;
            }
            set {
                if ((object.ReferenceEquals(this.Apellido_maternoField, value) != true)) {
                    this.Apellido_maternoField = value;
                    this.RaisePropertyChanged("Apellido_materno");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Apellido_paterno {
            get {
                return this.Apellido_paternoField;
            }
            set {
                if ((object.ReferenceEquals(this.Apellido_paternoField, value) != true)) {
                    this.Apellido_paternoField = value;
                    this.RaisePropertyChanged("Apellido_paterno");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Comentario {
            get {
                return this.ComentarioField;
            }
            set {
                if ((object.ReferenceEquals(this.ComentarioField, value) != true)) {
                    this.ComentarioField = value;
                    this.RaisePropertyChanged("Comentario");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Departamento {
            get {
                return this.DepartamentoField;
            }
            set {
                if ((object.ReferenceEquals(this.DepartamentoField, value) != true)) {
                    this.DepartamentoField = value;
                    this.RaisePropertyChanged("Departamento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Direccion {
            get {
                return this.DireccionField;
            }
            set {
                if ((object.ReferenceEquals(this.DireccionField, value) != true)) {
                    this.DireccionField = value;
                    this.RaisePropertyChanged("Direccion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Distrito {
            get {
                return this.DistritoField;
            }
            set {
                if ((object.ReferenceEquals(this.DistritoField, value) != true)) {
                    this.DistritoField = value;
                    this.RaisePropertyChanged("Distrito");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Dni {
            get {
                return this.DniField;
            }
            set {
                if ((object.ReferenceEquals(this.DniField, value) != true)) {
                    this.DniField = value;
                    this.RaisePropertyChanged("Dni");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> Fec_Registro {
            get {
                return this.Fec_RegistroField;
            }
            set {
                if ((this.Fec_RegistroField.Equals(value) != true)) {
                    this.Fec_RegistroField = value;
                    this.RaisePropertyChanged("Fec_Registro");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> Fec_Ult_Mod {
            get {
                return this.Fec_Ult_ModField;
            }
            set {
                if ((this.Fec_Ult_ModField.Equals(value) != true)) {
                    this.Fec_Ult_ModField = value;
                    this.RaisePropertyChanged("Fec_Ult_Mod");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Foto_Expositor {
            get {
                return this.Foto_ExpositorField;
            }
            set {
                if ((object.ReferenceEquals(this.Foto_ExpositorField, value) != true)) {
                    this.Foto_ExpositorField = value;
                    this.RaisePropertyChanged("Foto_Expositor");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Id_Expositor {
            get {
                return this.Id_ExpositorField;
            }
            set {
                if ((object.ReferenceEquals(this.Id_ExpositorField, value) != true)) {
                    this.Id_ExpositorField = value;
                    this.RaisePropertyChanged("Id_Expositor");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Id_Ubigeo {
            get {
                return this.Id_UbigeoField;
            }
            set {
                if ((object.ReferenceEquals(this.Id_UbigeoField, value) != true)) {
                    this.Id_UbigeoField = value;
                    this.RaisePropertyChanged("Id_Ubigeo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Provincia {
            get {
                return this.ProvinciaField;
            }
            set {
                if ((object.ReferenceEquals(this.ProvinciaField, value) != true)) {
                    this.ProvinciaField = value;
                    this.RaisePropertyChanged("Provincia");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Telefono {
            get {
                return this.TelefonoField;
            }
            set {
                if ((object.ReferenceEquals(this.TelefonoField, value) != true)) {
                    this.TelefonoField = value;
                    this.RaisePropertyChanged("Telefono");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Usu_Ult_Mod {
            get {
                return this.Usu_Ult_ModField;
            }
            set {
                if ((object.ReferenceEquals(this.Usu_Ult_ModField, value) != true)) {
                    this.Usu_Ult_ModField = value;
                    this.RaisePropertyChanged("Usu_Ult_Mod");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> estado_exp {
            get {
                return this.estado_expField;
            }
            set {
                if ((this.estado_expField.Equals(value) != true)) {
                    this.estado_expField = value;
                    this.RaisePropertyChanged("estado_exp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string tipo_estado {
            get {
                return this.tipo_estadoField;
            }
            set {
                if ((object.ReferenceEquals(this.tipo_estadoField, value) != true)) {
                    this.tipo_estadoField = value;
                    this.RaisePropertyChanged("tipo_estado");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UbigeoDc", Namespace="http://schemas.datacontract.org/2004/07/WFC_Leon")]
    [System.SerializableAttribute()]
    public partial class UbigeoDc : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DepartamentoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DistritoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IdDepaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IdDistField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IdProvField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Id_UbigeoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProvinciaField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Departamento {
            get {
                return this.DepartamentoField;
            }
            set {
                if ((object.ReferenceEquals(this.DepartamentoField, value) != true)) {
                    this.DepartamentoField = value;
                    this.RaisePropertyChanged("Departamento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Distrito {
            get {
                return this.DistritoField;
            }
            set {
                if ((object.ReferenceEquals(this.DistritoField, value) != true)) {
                    this.DistritoField = value;
                    this.RaisePropertyChanged("Distrito");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IdDepa {
            get {
                return this.IdDepaField;
            }
            set {
                if ((object.ReferenceEquals(this.IdDepaField, value) != true)) {
                    this.IdDepaField = value;
                    this.RaisePropertyChanged("IdDepa");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IdDist {
            get {
                return this.IdDistField;
            }
            set {
                if ((object.ReferenceEquals(this.IdDistField, value) != true)) {
                    this.IdDistField = value;
                    this.RaisePropertyChanged("IdDist");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IdProv {
            get {
                return this.IdProvField;
            }
            set {
                if ((object.ReferenceEquals(this.IdProvField, value) != true)) {
                    this.IdProvField = value;
                    this.RaisePropertyChanged("IdProv");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Id_Ubigeo {
            get {
                return this.Id_UbigeoField;
            }
            set {
                if ((object.ReferenceEquals(this.Id_UbigeoField, value) != true)) {
                    this.Id_UbigeoField = value;
                    this.RaisePropertyChanged("Id_Ubigeo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Provincia {
            get {
                return this.ProvinciaField;
            }
            set {
                if ((object.ReferenceEquals(this.ProvinciaField, value) != true)) {
                    this.ProvinciaField = value;
                    this.RaisePropertyChanged("Provincia");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceExpositor.IServicioExpositores")]
    public interface IServicioExpositores {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioExpositores/ListarExpositor", ReplyAction="http://tempuri.org/IServicioExpositores/ListarExpositorResponse")]
        ExpositoresWeb03.ServiceReferenceExpositor.ExpositorDC[] ListarExpositor();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioExpositores/ListarExpositor", ReplyAction="http://tempuri.org/IServicioExpositores/ListarExpositorResponse")]
        System.Threading.Tasks.Task<ExpositoresWeb03.ServiceReferenceExpositor.ExpositorDC[]> ListarExpositorAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioExpositores/ActualizarExpositor", ReplyAction="http://tempuri.org/IServicioExpositores/ActualizarExpositorResponse")]
        bool ActualizarExpositor(ExpositoresWeb03.ServiceReferenceExpositor.ExpositorDC Expositor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioExpositores/ActualizarExpositor", ReplyAction="http://tempuri.org/IServicioExpositores/ActualizarExpositorResponse")]
        System.Threading.Tasks.Task<bool> ActualizarExpositorAsync(ExpositoresWeb03.ServiceReferenceExpositor.ExpositorDC Expositor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioExpositores/EliminarExpositor", ReplyAction="http://tempuri.org/IServicioExpositores/EliminarExpositorResponse")]
        bool EliminarExpositor(string strCodigo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioExpositores/EliminarExpositor", ReplyAction="http://tempuri.org/IServicioExpositores/EliminarExpositorResponse")]
        System.Threading.Tasks.Task<bool> EliminarExpositorAsync(string strCodigo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioExpositores/InsertarExpositor", ReplyAction="http://tempuri.org/IServicioExpositores/InsertarExpositorResponse")]
        bool InsertarExpositor(ExpositoresWeb03.ServiceReferenceExpositor.ExpositorDC Expositor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioExpositores/InsertarExpositor", ReplyAction="http://tempuri.org/IServicioExpositores/InsertarExpositorResponse")]
        System.Threading.Tasks.Task<bool> InsertarExpositorAsync(ExpositoresWeb03.ServiceReferenceExpositor.ExpositorDC Expositor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioExpositores/ConsultarExpositor", ReplyAction="http://tempuri.org/IServicioExpositores/ConsultarExpositorResponse")]
        ExpositoresWeb03.ServiceReferenceExpositor.ExpositorDC ConsultarExpositor(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioExpositores/ConsultarExpositor", ReplyAction="http://tempuri.org/IServicioExpositores/ConsultarExpositorResponse")]
        System.Threading.Tasks.Task<ExpositoresWeb03.ServiceReferenceExpositor.ExpositorDC> ConsultarExpositorAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioExpositores/ConsultarUbigeo", ReplyAction="http://tempuri.org/IServicioExpositores/ConsultarUbigeoResponse")]
        ExpositoresWeb03.ServiceReferenceExpositor.UbigeoDc ConsultarUbigeo(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioExpositores/ConsultarUbigeo", ReplyAction="http://tempuri.org/IServicioExpositores/ConsultarUbigeoResponse")]
        System.Threading.Tasks.Task<ExpositoresWeb03.ServiceReferenceExpositor.UbigeoDc> ConsultarUbigeoAsync(string id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicioExpositoresChannel : ExpositoresWeb03.ServiceReferenceExpositor.IServicioExpositores, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicioExpositoresClient : System.ServiceModel.ClientBase<ExpositoresWeb03.ServiceReferenceExpositor.IServicioExpositores>, ExpositoresWeb03.ServiceReferenceExpositor.IServicioExpositores {
        
        public ServicioExpositoresClient() {
        }
        
        public ServicioExpositoresClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicioExpositoresClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioExpositoresClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioExpositoresClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ExpositoresWeb03.ServiceReferenceExpositor.ExpositorDC[] ListarExpositor() {
            return base.Channel.ListarExpositor();
        }
        
        public System.Threading.Tasks.Task<ExpositoresWeb03.ServiceReferenceExpositor.ExpositorDC[]> ListarExpositorAsync() {
            return base.Channel.ListarExpositorAsync();
        }
        
        public bool ActualizarExpositor(ExpositoresWeb03.ServiceReferenceExpositor.ExpositorDC Expositor) {
            return base.Channel.ActualizarExpositor(Expositor);
        }
        
        public System.Threading.Tasks.Task<bool> ActualizarExpositorAsync(ExpositoresWeb03.ServiceReferenceExpositor.ExpositorDC Expositor) {
            return base.Channel.ActualizarExpositorAsync(Expositor);
        }
        
        public bool EliminarExpositor(string strCodigo) {
            return base.Channel.EliminarExpositor(strCodigo);
        }
        
        public System.Threading.Tasks.Task<bool> EliminarExpositorAsync(string strCodigo) {
            return base.Channel.EliminarExpositorAsync(strCodigo);
        }
        
        public bool InsertarExpositor(ExpositoresWeb03.ServiceReferenceExpositor.ExpositorDC Expositor) {
            return base.Channel.InsertarExpositor(Expositor);
        }
        
        public System.Threading.Tasks.Task<bool> InsertarExpositorAsync(ExpositoresWeb03.ServiceReferenceExpositor.ExpositorDC Expositor) {
            return base.Channel.InsertarExpositorAsync(Expositor);
        }
        
        public ExpositoresWeb03.ServiceReferenceExpositor.ExpositorDC ConsultarExpositor(string id) {
            return base.Channel.ConsultarExpositor(id);
        }
        
        public System.Threading.Tasks.Task<ExpositoresWeb03.ServiceReferenceExpositor.ExpositorDC> ConsultarExpositorAsync(string id) {
            return base.Channel.ConsultarExpositorAsync(id);
        }
        
        public ExpositoresWeb03.ServiceReferenceExpositor.UbigeoDc ConsultarUbigeo(string id) {
            return base.Channel.ConsultarUbigeo(id);
        }
        
        public System.Threading.Tasks.Task<ExpositoresWeb03.ServiceReferenceExpositor.UbigeoDc> ConsultarUbigeoAsync(string id) {
            return base.Channel.ConsultarUbigeoAsync(id);
        }
    }
}
