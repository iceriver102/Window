﻿#pragma checksum "..\..\..\..\Alta_view\Item_mana\Item_view_camera.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C0CD0027E039D14E851E3C3E41A9320A"
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
    /// Item_view_camera
    /// </summary>
    public partial class Item_view_camera : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 61 "..\..\..\..\Alta_view\Item_mana\Item_view_camera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label txt_alta_name;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Alta_view\Item_mana\Item_view_camera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label txt_num_playlist;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Alta_view\Item_mana\Item_view_camera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label txt_alta_userCreate;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\Alta_view\Item_mana\Item_view_camera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label txt_alta_date;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Alta_view\Item_mana\Item_view_camera.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Alta_Media_Manager;component/alta_view/item_mana/item_view_camera.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Alta_view\Item_mana\Item_view_camera.xaml"
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
            
            #line 40 "..\..\..\..\Alta_view\Item_mana\Item_view_camera.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_Play_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 45 "..\..\..\..\Alta_view\Item_mana\Item_view_camera.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_edit_click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 50 "..\..\..\..\Alta_view\Item_mana\Item_view_camera.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_del_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txt_alta_name = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.txt_num_playlist = ((System.Windows.Controls.Label)(target));
            
            #line 64 "..\..\..\..\Alta_view\Item_mana\Item_view_camera.xaml"
            this.txt_num_playlist.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.View_Playlist_Click_Btn);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txt_alta_userCreate = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.txt_alta_date = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.btn_icon_status = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\..\Alta_view\Item_mana\Item_view_camera.xaml"
            this.btn_icon_status.Click += new System.Windows.RoutedEventHandler(this.btn_duyet_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

