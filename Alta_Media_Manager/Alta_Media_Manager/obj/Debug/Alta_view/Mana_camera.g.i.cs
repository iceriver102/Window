﻿#pragma checksum "..\..\..\Alta_view\Mana_camera.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2DD5908970ECBF4F32AB43FB7D984A1F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Alta_Media_Manager.Alta_view.Item_mana;
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
    /// Mana_camera
    /// </summary>
    public partial class Mana_camera : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\Alta_view\Mana_camera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas main_layout;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Alta_view\Mana_camera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox list_Box_Item;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Alta_view\Mana_camera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Key_Search;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\Alta_view\Mana_camera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Cb_Sort;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Alta_view\Mana_camera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label sort_time;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\Alta_view\Mana_camera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label sort_name;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Alta_view\Mana_camera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_backPage;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\Alta_view\Mana_camera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_nextPage;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\Alta_view\Mana_camera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb_status;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\Alta_view\Mana_camera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_back_navigation;
        
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
            System.Uri resourceLocater = new System.Uri("/Alta_Media_Manager;component/alta_view/mana_camera.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Alta_view\Mana_camera.xaml"
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
            this.main_layout = ((System.Windows.Controls.Canvas)(target));
            return;
            case 2:
            this.list_Box_Item = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.txt_Key_Search = ((System.Windows.Controls.TextBox)(target));
            
            #line 48 "..\..\..\Alta_view\Mana_camera.xaml"
            this.txt_Key_Search.KeyUp += new System.Windows.Input.KeyEventHandler(this.KeyUpEnter);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 53 "..\..\..\Alta_view\Mana_camera.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Btn_Search_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 59 "..\..\..\Alta_view\Mana_camera.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_Add_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Cb_Sort = ((System.Windows.Controls.ComboBox)(target));
            
            #line 65 "..\..\..\Alta_view\Mana_camera.xaml"
            this.Cb_Sort.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Cb_Sort_Selected_Change);
            
            #line default
            #line hidden
            return;
            case 7:
            this.sort_time = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.sort_name = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.btn_backPage = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\Alta_view\Mana_camera.xaml"
            this.btn_backPage.Click += new System.Windows.RoutedEventHandler(this.btn_backPage_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btn_nextPage = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\..\Alta_view\Mana_camera.xaml"
            this.btn_nextPage.Click += new System.Windows.RoutedEventHandler(this.btn_nextPage_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.lb_status = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.btn_back_navigation = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\..\Alta_view\Mana_camera.xaml"
            this.btn_back_navigation.Click += new System.Windows.RoutedEventHandler(this.btn_back_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

