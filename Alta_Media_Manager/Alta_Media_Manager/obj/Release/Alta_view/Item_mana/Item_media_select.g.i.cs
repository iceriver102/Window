﻿#pragma checksum "..\..\..\..\Alta_view\Item_mana\Item_media_select.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D86F45610117B2B0437229E123F53FAD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace Alta_Media_Manager.Alta_view.Item_mana {
    
    
    /// <summary>
    /// Item_media_select
    /// </summary>
    public partial class Item_media_select : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\..\..\Alta_view\Item_mana\Item_media_select.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_check;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\Alta_view\Item_mana\Item_media_select.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label txt_alta_name;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\Alta_view\Item_mana\Item_media_select.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label txt_alta_userCreate;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\Alta_view\Item_mana\Item_media_select.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label txt_alta_date;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\Alta_view\Item_mana\Item_media_select.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_icon_status;
        
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
            System.Uri resourceLocater = new System.Uri("/Alta_Media_Manager;component/alta_view/item_mana/item_media_select.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Alta_view\Item_mana\Item_media_select.xaml"
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
            
            #line 7 "..\..\..\..\Alta_view\Item_mana\Item_media_select.xaml"
            ((Alta_Media_Manager.Alta_view.Item_mana.Item_media_select)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.click_mouse_click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_check = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\..\Alta_view\Item_mana\Item_media_select.xaml"
            this.btn_check.Click += new System.Windows.RoutedEventHandler(this.btn_select_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txt_alta_name = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.txt_alta_userCreate = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.txt_alta_date = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.btn_icon_status = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

