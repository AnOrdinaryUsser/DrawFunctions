﻿#pragma checksum "..\..\addManually.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BEF299C8579EED4791D02B40AE5CC8E96593A0BCF908EC68A4456A3B64D4DCEA"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using IntegerTextBox;
using Práctica2020;
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


namespace Práctica2020 {
    
    
    /// <summary>
    /// addManuallyWindow
    /// </summary>
    public partial class addManuallyWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\addManually.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal IntegerTextBox.NumericTextBox TextBoxX;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\addManually.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal IntegerTextBox.NumericTextBox TextBoxY;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\addManually.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BotonAniadir;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\addManually.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BotonModificar;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\addManually.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BotonEliminarUno;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\addManually.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbColors;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\addManually.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListViewManual;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\addManually.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockListView;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\addManually.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BotonEliminarTodos;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\addManually.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button butonAniadirPoints;
        
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
            System.Uri resourceLocater = new System.Uri("/Práctica2020;component/addmanually.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\addManually.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.TextBoxX = ((IntegerTextBox.NumericTextBox)(target));
            return;
            case 2:
            this.TextBoxY = ((IntegerTextBox.NumericTextBox)(target));
            return;
            case 3:
            this.BotonAniadir = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\addManually.xaml"
            this.BotonAniadir.Click += new System.Windows.RoutedEventHandler(this.addOneElement);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BotonModificar = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\addManually.xaml"
            this.BotonModificar.Click += new System.Windows.RoutedEventHandler(this.modifyCoordinate);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BotonEliminarUno = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\addManually.xaml"
            this.BotonEliminarUno.Click += new System.Windows.RoutedEventHandler(this.deleteOneElement);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cmbColors = ((System.Windows.Controls.ComboBox)(target));
            
            #line 75 "..\..\addManually.xaml"
            this.cmbColors.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbColors_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ListViewManual = ((System.Windows.Controls.ListView)(target));
            
            #line 97 "..\..\addManually.xaml"
            this.ListViewManual.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.TextBlockListView = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.BotonEliminarTodos = ((System.Windows.Controls.Button)(target));
            
            #line 114 "..\..\addManually.xaml"
            this.BotonEliminarTodos.Click += new System.Windows.RoutedEventHandler(this.deleteAllElements);
            
            #line default
            #line hidden
            return;
            case 10:
            this.butonAniadirPoints = ((System.Windows.Controls.Button)(target));
            
            #line 118 "..\..\addManually.xaml"
            this.butonAniadirPoints.Click += new System.Windows.RoutedEventHandler(this.addPointsToCanvas);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

