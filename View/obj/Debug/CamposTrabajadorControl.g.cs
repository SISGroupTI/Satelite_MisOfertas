﻿#pragma checksum "..\..\CamposTrabajadorControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "595BFE565B2F7C3538D59834C1561DD0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using LiveCharts.Wpf;
using MahApps.Metro.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using View;


namespace View {
    
    
    /// <summary>
    /// CamposTrabajadorControl
    /// </summary>
    public partial class CamposTrabajadorControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\CamposTrabajadorControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxPerfil;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\CamposTrabajadorControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxLocal;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\CamposTrabajadorControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCorreo;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\CamposTrabajadorControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNombreUsuario;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\CamposTrabajadorControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRut;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\CamposTrabajadorControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtApellidos;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\CamposTrabajadorControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNombre;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\CamposTrabajadorControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtContrasena;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\CamposTrabajadorControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox etIdTrabajador;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/View;component/campostrabajadorcontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CamposTrabajadorControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.cbxPerfil = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.cbxLocal = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.txtCorreo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtNombreUsuario = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtRut = ((System.Windows.Controls.TextBox)(target));
            
            #line 48 "..\..\CamposTrabajadorControl.xaml"
            this.txtRut.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtRut_KeyDown);
            
            #line default
            #line hidden
            
            #line 48 "..\..\CamposTrabajadorControl.xaml"
            this.txtRut.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtRut_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtApellidos = ((System.Windows.Controls.TextBox)(target));
            
            #line 52 "..\..\CamposTrabajadorControl.xaml"
            this.txtApellidos.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtApellidos_KeyDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txtNombre = ((System.Windows.Controls.TextBox)(target));
            
            #line 56 "..\..\CamposTrabajadorControl.xaml"
            this.txtNombre.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtNombre_KeyDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.txtContrasena = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 9:
            this.etIdTrabajador = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

