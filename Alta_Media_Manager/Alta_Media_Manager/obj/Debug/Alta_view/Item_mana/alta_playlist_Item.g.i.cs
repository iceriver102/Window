﻿#pragma checksum "..\..\..\..\Alta_view\Item_mana\alta_playlist_Item.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "51777309627D072D008505A532337330"
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
    /// alta_playlist_Item
    /// </summary>
    public partial class alta_playlist_Item : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\..\Alta_view\Item_mana\alta_playlist_Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb_name;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Alta_view\Item_mana\alta_playlist_Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb_user;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Alta_view\Item_mana\alta_playlist_Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb_date;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Alta_view\Item_mana\alta_playlist_Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel st_terminal;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Alta_view\Item_mana\alta_playlist_Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_more;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Alta_view\Item_mana\alta_playlist_Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid_action;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\Alta_view\Item_mana\alta_playlist_Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_status;
        
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
            System.Uri resourceLocater = new System.Uri("/Alta_Media_Manager;component/alta_view/item_mana/alta_playlist_item.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Alta_view\Item_mana\alta_playlist_Item.xaml"
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
            
            #line 7 "..\..\..\..\Alta_view\Item_mana\alta_playlist_Item.xaml"
            ((Alta_Media_Manager.Alta_view.Item_mana.alta_playlist_Item)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Show_Action_Bar);
            
            #line default
            #line hidden
            
            #line 7 "..\..\..\..\Alta_view\Item_mana\alta_playlist_Item.xaml"
            ((Alta_Media_Manager.Alta_view.Item_mana.alta_playlist_Item)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Hide_Action_Bar);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lb_name = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.lb_user = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.lb_date = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.st_terminal = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.btn_more = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.grid_action = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.btn_status = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\..\Alta_view\Item_mana\alta_playlist_Item.xaml"
            this.btn_status.Click += new System.Windows.RoutedEventHandler(this.btn_Status_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 55 "..\..\..\..\Alta_view\Item_mana\alta_playlist_Item.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_del_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 61 "..\..\..\..\Alta_view\Item_mana\alta_playlist_Item.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_add_ScreenClick);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 67 "..\..\..\..\Alta_view\Item_mana\alta_playlist_Item.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_Add_media_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 72 "..\..\..\..\Alta_view\Item_mana\alta_playlist_Item.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_view_terminal_click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 77 "..\..\..\..\Alta_view\Item_mana\alta_playlist_Item.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_view_details_click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

