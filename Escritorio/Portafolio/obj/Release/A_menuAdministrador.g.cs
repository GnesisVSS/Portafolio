#pragma checksum "..\..\A_menuAdministrador.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3E6F64D126F6021F6EB4254528409DA9B0D91338"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Portafolio;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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


namespace Portafolio {
    
    
    /// <summary>
    /// A_menuAdministrador
    /// </summary>
    public partial class A_menuAdministrador : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\A_menuAdministrador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPerfil;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\A_menuAdministrador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_cerrar;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\A_menuAdministrador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCerrar;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\A_menuAdministrador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMaximizar;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\A_menuAdministrador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMinimizar;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\A_menuAdministrador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Menu;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\A_menuAdministrador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridMain;
        
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
            System.Uri resourceLocater = new System.Uri("/Portafolio;component/a_menuadministrador.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\A_menuAdministrador.xaml"
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
            
            #line 9 "..\..\A_menuAdministrador.xaml"
            ((Portafolio.A_menuAdministrador)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            
            #line 9 "..\..\A_menuAdministrador.xaml"
            ((Portafolio.A_menuAdministrador)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            
            #line 9 "..\..\A_menuAdministrador.xaml"
            ((Portafolio.A_menuAdministrador)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnPerfil = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\A_menuAdministrador.xaml"
            this.btnPerfil.Click += new System.Windows.RoutedEventHandler(this.BtnPerfil_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_cerrar = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\A_menuAdministrador.xaml"
            this.btn_cerrar.Click += new System.Windows.RoutedEventHandler(this.Btn_cerrar_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnCerrar = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\A_menuAdministrador.xaml"
            this.btnCerrar.Click += new System.Windows.RoutedEventHandler(this.btnCerrar_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnMaximizar = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\A_menuAdministrador.xaml"
            this.btnMaximizar.Click += new System.Windows.RoutedEventHandler(this.btnMaximizar_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnMinimizar = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\A_menuAdministrador.xaml"
            this.btnMinimizar.Click += new System.Windows.RoutedEventHandler(this.btnMinimizar_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Menu = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 8:
            this.GridMain = ((System.Windows.Controls.Grid)(target));
            return;
            case 9:
            
            #line 67 "..\..\A_menuAdministrador.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

