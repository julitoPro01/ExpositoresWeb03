﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExpositoresWeb03.ServiceReferenceUsuario {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UsuarioDc", Namespace="http://schemas.datacontract.org/2004/07/WFC_Leon")]
    [System.SerializableAttribute()]
    public partial class UsuarioDc : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Login_UsuarioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int Niv_UsuarioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Pass_UsuarioField;
        
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
        public string Login_Usuario {
            get {
                return this.Login_UsuarioField;
            }
            set {
                if ((object.ReferenceEquals(this.Login_UsuarioField, value) != true)) {
                    this.Login_UsuarioField = value;
                    this.RaisePropertyChanged("Login_Usuario");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Niv_Usuario {
            get {
                return this.Niv_UsuarioField;
            }
            set {
                if ((this.Niv_UsuarioField.Equals(value) != true)) {
                    this.Niv_UsuarioField = value;
                    this.RaisePropertyChanged("Niv_Usuario");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Pass_Usuario {
            get {
                return this.Pass_UsuarioField;
            }
            set {
                if ((object.ReferenceEquals(this.Pass_UsuarioField, value) != true)) {
                    this.Pass_UsuarioField = value;
                    this.RaisePropertyChanged("Pass_Usuario");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceUsuario.IUsuario")]
    public interface IUsuario {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuario/consultarUsuario", ReplyAction="http://tempuri.org/IUsuario/consultarUsuarioResponse")]
        ExpositoresWeb03.ServiceReferenceUsuario.UsuarioDc consultarUsuario(string usuario, string contraseña);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuario/consultarUsuario", ReplyAction="http://tempuri.org/IUsuario/consultarUsuarioResponse")]
        System.Threading.Tasks.Task<ExpositoresWeb03.ServiceReferenceUsuario.UsuarioDc> consultarUsuarioAsync(string usuario, string contraseña);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuario/validarUsuario", ReplyAction="http://tempuri.org/IUsuario/validarUsuarioResponse")]
        bool validarUsuario();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuario/validarUsuario", ReplyAction="http://tempuri.org/IUsuario/validarUsuarioResponse")]
        System.Threading.Tasks.Task<bool> validarUsuarioAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUsuarioChannel : ExpositoresWeb03.ServiceReferenceUsuario.IUsuario, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UsuarioClient : System.ServiceModel.ClientBase<ExpositoresWeb03.ServiceReferenceUsuario.IUsuario>, ExpositoresWeb03.ServiceReferenceUsuario.IUsuario {
        
        public UsuarioClient() {
        }
        
        public UsuarioClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UsuarioClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UsuarioClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UsuarioClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ExpositoresWeb03.ServiceReferenceUsuario.UsuarioDc consultarUsuario(string usuario, string contraseña) {
            return base.Channel.consultarUsuario(usuario, contraseña);
        }
        
        public System.Threading.Tasks.Task<ExpositoresWeb03.ServiceReferenceUsuario.UsuarioDc> consultarUsuarioAsync(string usuario, string contraseña) {
            return base.Channel.consultarUsuarioAsync(usuario, contraseña);
        }
        
        public bool validarUsuario() {
            return base.Channel.validarUsuario();
        }
        
        public System.Threading.Tasks.Task<bool> validarUsuarioAsync() {
            return base.Channel.validarUsuarioAsync();
        }
    }
}
