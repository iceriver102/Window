   M S B A M L   `   `   `  ����M  IAlta_Media_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Alta_Media_ManagerAlta_Media_Manager  5
      ,    &Alta_Media_Manager.ManaView.Mana_Video   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      a ]DevExpress.Xpf.Core.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      f bDevExpress.Xpf.Grid.v13.2.Core, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	      ,local clr-namespace:Alta_Media_Manager  5
      &   DevExpress.Xpf.Core.ThemeManager    	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$  DXStyle 5      
������ .��5      �� -   5         ��Name$ 
layoutMana��5      $	��693��6"   $
��1346��6/   
������ .+�5   
   �� -   5         ��Name$ loading��5      
������� �� Left$ 0��65   
 �� Top$ 0��6E   $	��693��6T   $
��1346��6a    J� Opacity$ 1Q�6n   ._�5      r� -   5         r�Name$ mediaLoading��5      $	��128��62   $	��128��6>    r� UnloadedBehavior$ Manual=�6M    r� LoadedBehavior$
 Play=�6g   	 r� Stretch$
	 None=�6~   $��Center=�6�   $��Center=�6�   5      � 5   
   -   5        
 �Name$
 
Grid_Video��5      $ 0Q�6#   $ 0��6/   $ 0��6>   $��Stretch=�6N   $��Stretch=�6l   $	��693��6�   $
��1346��6�   
������  � RowDefinitions 5      �� 5      $	��74* �6    �� 5      $	��50* �6    �� 5      $
��543* �6    .+�5      ��  �� Orientation$ 
Horizontal=�6   $��0��63   $��Stretch=�6@   $��398,7q�6^   $��Stretch=�6m   ��5      �� 5       �� ImageSource$> 8/Alta_Media_Manager;component/Asset/Image/bar_action.png��6!   .+�5      %  DevExpress.Xpf.Editors.TextEdit  -   5          Name$ 
txt_Search��5      $	��421��63   $��30,13,10,13q�6?   $��33��6T   6`   �� 5      -   5         � Cursor$
 Hand��5      $��Search��6'   $��65��68   $
��9,14q�6\   5      �� 5       $ 
Horizontal=�6   $��1��62   $��Stretch=�6@   $��Stretch=�6^   $��20,0,0,0q�6z   .+�5!      �� -   5        $
 Hand��5!      $��Thêm��6'   $��75��66   $
��5,10q�6A   6O   �� 5"      -   5        $
 Hand��5"      $
��Xoá��6'   $��75��65   $
��5,10q�6@   6N   �� 5#      -	   5        $
 Hand��5#      $��Sửa��6'   $��75��65   $
��5,10q�6@   6N   �� 5$      -
   5         ��Name$ btnDuyet��5$   '   $
 Hand��6   $��Duyệt��69   $��75��6I   $
��5,10q�6T   6b   �� 5%      -   5        $ btnDuyetCancel��5%   '   $
 Hand��6   $��Bỏ duyệt��6?   $��75��6R   $
��5,10q�6]   6k   �� 5&      -   5        $
 Hand��5&      $��Tải lại��6'   $��75��69   $
��5,10q�6D   6R   5'      � 5(      $��2��6   $��Stretch=�6    $��Stretch=�6>   .+�5)      %  DevExpress.Xpf.Grid.GridControl  -   5          Name$ grid_video_View��5)   "      View 5*      #  DevExpress.Xpf.Grid.TableView  5+      -   5          Name$ tbView_video��5+   (   &   DevExpress.Xpf.Grid.DataViewBase   ShowTotalSummary .     MultiSelectMode$	 Row=�6W      	AutoWidth . 6n      Columns 5-      $  DevExpress.Xpf.Grid.GridColumn  5.      $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ index��6)   $	  DevExpress.Xpf.Grid.BaseColumn 	  Header)
  #DevExpress.Xpf.Core.ObjectConverter$	 Stt
 6;      ReadOnly .  	  Width$ 30��6X     5/      $ 
media_name��6)   $ 	Tên File
 6@     50      $ 	media_url��6)    . $ Thư mục chứa file
 6O     51      $ user_id.full_name��6)    . $ Người tạo
 6W     52      $ media_status��6)    . $ Duyệt
 6R   $ 30��6a   54      55      56      57      58      