﻿#pragma checksum "..\..\ImagePicker.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EFEDA8E86941E03710E6D79C8C72AD1F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AditionalControlsWPF;
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


namespace AditionalControlsWPF {
    
    
    /// <summary>
    /// ImagePicker
    /// </summary>
    public partial class ImagePicker : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 8 "..\..\ImagePicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal AditionalControlsWPF.ImagePicker uc;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\ImagePicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listImages;
        
        #line default
        #line hidden
        
        
        #line 164 "..\..\ImagePicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle recAdd;
        
        #line default
        #line hidden
        
        
        #line 183 "..\..\ImagePicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelPlus;
        
        #line default
        #line hidden
        
        
        #line 195 "..\..\ImagePicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle recDeleteAll;
        
        #line default
        #line hidden
        
        
        #line 214 "..\..\ImagePicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelDeleteAll;
        
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
            System.Uri resourceLocater = new System.Uri("/AditionalControlsWPF;component/imagepicker.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ImagePicker.xaml"
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
            this.uc = ((AditionalControlsWPF.ImagePicker)(target));
            return;
            case 2:
            this.listImages = ((System.Windows.Controls.ListView)(target));
            
            #line 53 "..\..\ImagePicker.xaml"
            this.listImages.Loaded += new System.Windows.RoutedEventHandler(this.listImages_Loaded);
            
            #line default
            #line hidden
            return;
            case 5:
            this.recAdd = ((System.Windows.Shapes.Rectangle)(target));
            
            #line 164 "..\..\ImagePicker.xaml"
            this.recAdd.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.recAdd_MouseDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.labelPlus = ((System.Windows.Controls.Label)(target));
            
            #line 183 "..\..\ImagePicker.xaml"
            this.labelPlus.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.labelPlus_MouseDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.recDeleteAll = ((System.Windows.Shapes.Rectangle)(target));
            
            #line 195 "..\..\ImagePicker.xaml"
            this.recDeleteAll.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.recDeleteAll_MouseDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.labelDeleteAll = ((System.Windows.Controls.Label)(target));
            
            #line 214 "..\..\ImagePicker.xaml"
            this.labelDeleteAll.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.labelDeleteAll_MouseDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 3:
            
            #line 92 "..\..\ImagePicker.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Rectangle_MouseDown);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 123 "..\..\ImagePicker.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.labelX_MouseDown);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

