﻿#pragma checksum "..\..\..\Alta_view\add_user_view.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4D60DC60E3EDB29F66272A1842A15409"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Windows.Themes;
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


namespace Alta_Media_Manager.Alta_view {
    
    
    /// <summary>
    /// add_user_view
    /// </summary>
    public partial class add_user_view : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\Alta_view\add_user_view.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock title_txt;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Alta_view\add_user_view.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_name;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Alta_view\add_user_view.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_username;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Alta_view\add_user_view.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txt_pass;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Alta_view\add_user_view.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_email;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Alta_view\add_user_view.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_phone;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Alta_view\add_user_view.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_type_user;
        
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
            System.Uri resourceLocater = new System.Uri("/Alta_Media_Manager;component/alta_view/add_user_view.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Alta_view\add_user_view.xaml"
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
            
            #line 13 "..\..\..\Alta_view\add_user_view.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Hide_View_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 19 "..\..\..\Alta_view\add_user_view.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.nothing_click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.title_txt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.txt_name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txt_username = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txt_pass = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 7:
            this.txt_email = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txt_phone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.cb_type_user = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            
            #line 60 "..\..\..\Alta_view\add_user_view.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_save_click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 75 "..\..\..\Alta_view\add_user_view.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_Close_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

