   M S B A M L   `   `   `  ����M  IAlta_Media_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Alta_Media_Manager.PluginAlta_Media_Manager.Plugin  5	      +    %Alta_Media_Manager.ManaView.Mana_Plan   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      a ]DevExpress.Xpf.Core.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      f bDevExpress.Xpf.Grid.v13.2.Core, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5      6plugin'clr-namespace:Alta_Media_Manager.Plugin   5	      &   DevExpress.Xpf.Core.ThemeManager    	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$  DXStyle 5      $��Arial)�5      .��5      �� -   5         ��Name$ 
layoutMana��5      $	��693��6!   $
��1346��6.   
������ .+�5   
   �� -   5         ��Name$ loading��5      
������� �� Left$ 0��65   
 �� Top$ 0��6E   $	��693��6T   $
��1346��6a    J� Opacity$ 1Q�6n   ._�5      r� -   5         r�Name$ mediaLoading��5      $	��128��62   $	��128��6>    r� UnloadedBehavior$ Manual=�6M    r� LoadedBehavior$
 Play=�6g   	 r� Stretch$
	 None=�6~   $��Center=�6�   $��Center=�6�   5      � 5   
   -   5        
 �Name$
 grid_layout_plan��5      $ 0��6*   $ 0��6:   $	��693��6I   $
��1346��6V   
������  � ColumnDefinitions 5      �� 5      $
��522* �6#   �� 5      $
��151* �6#    � RowDefinitions 5      �� 5      $	��77* �6    �� 5      $	��52* �6    �� 5      $
��279* �6    �� 5      $
��285* �6    .+�5      ��  �� Orientation$ 
Horizontal=�6   $��0��63   $��0��6@   $��2��6P   $��Center=�6e   $	��0,5q�6�   $��Stretch=�6�   ��5      �� 5       �� ImageSource$> 8/Alta_Media_Manager;component/Asset/Image/bar_action.png��6!   .+�5!      %  DevExpress.Xpf.Editors.TextEdit  -   5          Name$ 
txt_Search��5!      $	��421��63   $��30,13,10,13q�6?   $��33��6T   6`   �� 5"      -   5         � Cursor$
 Hand��5"      $��Search��6'   $��65��68   $
��9,14q�6\   5#      �� 5$      $ 
Horizontal=�6   $��20,0,0,0q�62   $��0��6D   $��Stretch=�6T   $��1��6s   $��Stretch=�6�   $��2��6�   .+�5%      �� -   5        $
 Hand��5%      $��Thêm��6'   $
��5,10q�67   $��75��6G   6R   �� 5&      -   5        $
 Hand��5&      $
��Xoá��6'   $
��5,10q�66   $��75��6E   6P   �� 5'      -	   5        $
 Hand��5'      $��Sửa��6'   $
��5,10q�66   $��75��6F   6Q   �� 5(      -
   5        $
 Hand��5(      $��Tải lại��6'   $
��5,10q�6:   $��75��6I   6T   5)      � 5*      $��0��6   $��Stretch=�6#   $��2��6B   $��Stretch=�6O   $��2��6k    5+      �� 5,      $
��245* �6$   �� 5-      $	��37* �6$   5/      %  DevExpress.Xpf.Grid.GridControl  50      -   5          Name$ grid_view_plan��50      )  #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$ AddNew=�66   $��Stretch=�6�   $��0q�6�   $��2��6�   $��Stretch=�6�   $��2��6     View 51      #  DevExpress.Xpf.Grid.TableView  52      &   DevExpress.Xpf.Grid.DataViewBase   ShowTotalSummary .     MultiSelectMode$	 Row=�6>      	AutoWidth . 6U      Columns 54      $  DevExpress.Xpf.Grid.GridColumn  55      $	  DevExpress.Xpf.Grid.ColumnBase 	  	FieldName$ index��6%   $
  DevExpress.Xpf.Grid.BaseColumn 
  Header)  #DevExpress.Xpf.Core.ObjectConverter$	 Stt 67    	  ReadOnly .  
  Width$ 30��6T     56      $ 	plan_name��6%   $ Tên  6;     57      $ user_id.full_name��6%    . $ Người tạo 6S     58      $ plan_date_begin��6%    . $ Thời gian phát 6Q    	  EditSettings 59      6  0DevExpress.Xpf.Editors.Settings.DateEditSettings  5:      6  0DevExpress.Xpf.Editors.Settings.BaseEditSettings   DisplayFormat$ HH:mm dd/MM/yyyy��63   6  0DevExpress.Xpf.Editors.Settings.TextEditSettings   Mask$ HH:mm dd/MM/yyyy��6T   5<        5=      $ plan_date_end��6%    . $ Thời gian kết thúc 6O    5>        5?      $ HH:mm dd/MM/yyyy��63   $ HH:mm dd/MM/yyyy��6T   5A        5B      $ plan_everyday��6%    . $ Hằng ngày 6O   $ 60��6b     5C      $ plan_status��6%    . $ Trạng thái 6M   $ 50��6a     5D      $ details��6%    . $ 
Chi tiết 6I   $ 40��6[   5F      �� 5H      $	��Top=�6   $��1��6-   $��2��6=   $��Center=�6J   $	��282��6g   $	��232��6s   
���   �$��1q�6�    �� CornerRadius$ 5��6�   $
��10,0q�6�   ._�5I      �� 
�������$��0q�6,   $	��280��67   $	��230��6C     J� Clip  5J      � 5K      .��5L      �� ! �� RadiusX$! 6Q�61   " �� RadiusY$" 6Q�6=   # �� Rect$# 0,0,280,230�6I   5M      .+�5O      8  2DevExpress.Xpf.Editors.DateNavigator.DateNavigator  -   5        $ 0��5O   (   $	��280��68   $	��230��6D   $ 0��6Q   
�������6�   5Q      5R      5T      5U      5V      