   M S B A M L   `   `   `  ����M  IAlta_Media_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Alta_Media_Manager.PluginAlta_Media_Manager.Plugin  5      )    #Alta_Media_Manager.ManaView.addPlan   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      a ]DevExpress.Xpf.Core.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      Z VWPFToolkit.Extended, Version=1.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4UwpfxJhttp://schemas.microsoft.com/winfx/2006/xaml/presentation/toolkit/extended  5      4plugin'clr-namespace:Alta_Media_Manager.Plugin  5      &   DevExpress.Xpf.Core.ThemeManager    	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$  DXStyle 5	      $��Arial)�5
      .��5      �� -   5         ��Name$ 
layoutMana��5      $	��693��6!   $
��1346��6.   
������ .+�5   
   � -   5         �Name$ grid_layout_plan��5       �� Left$ 0��6*   
 �� Top$ 0��6:   $	��693��6I   $
��1346��6V   ���	#33808080 � RowDefinitions 5      �� 5      $	��77* �6    �� 5      $	��52* �6    �� 5      $
��564* �6    .+�5      �� -   5        $ layoutContent��5      $��2��6,   $��Stretch=�69   .+�5      �� -   5         ��Name$ layout_step_1��5      $y�Hidden=�60   ���	#FFFF670F$��2q�6]   
�������$	 503��6�   $ 40��6�   $	��360��6�   $	��395��6�   ._�5      � -   5        $ layoutInfor��5      $��Stretch=�60   $��Stretch=�6O    � ColumnDefinitions 5      �� 5      $
��160* �6/   �� 5      $
��307* �6/    5      �� 5      $	��45* �6,   �� 5      $	��53* �6,   �� 5      $	��69* �6,   �� 5      $	��61* �6,   �� 5      $	��52* �6,   �� 5       $	��72* �6,   .+�5"      �� $��Stretch=�6"   $��Stretch=�6@   $��0��6\   $��0��6i   $��2��6y   ��5#      �� 5$   "    �� EndPoint$ 0.5,1&�66   	 �� 
StartPoint$	 0.5,0&�6G   .��5%   &   � 
 � Color$
 	#99FFA84C��63    � Offset$ 0Q�6E   � 5&   &   $
 	#99FF7B0D��63   $ 1Q�6E   5'   #   ._�5)      �� $��15,0,0,0q�6(   $��NoWrap=�6:   
�������$ ��Thông tin chương trình��6c   $��Center=�6�   $��19(�6�   $
��Bold"�6�   5*      �� 5+      $��10,17,10,18q�6$   $��1��6:   $
��Wrap=�6G   $��Tên chương trình:��6[    �� TextAlignment$ Right=�6t   $��Center=�6�   �� 5,      $��10,24,10,25q�6$   $��2��6:   $
��Wrap=�6G   $��Thời gian bắt đầu:��6[   $ Right=�6u   $��Center=�6�   �� 5-      $��10,21,10,22q�6$   $��3��6:   $
��Wrap=�6G   $��Thời gian kết thúc:��6[   $ Right=�6v   $��Center=�6�   �� 5.      $��10,16,10,18q�6$   $��4��6:   $
��Wrap=�6G   $��Phát hằng ngày:��6[   $ Right=�6r   $��Center=�6�   �� 5/      $��1��6"   $��1��62    �� TextWrapping$ NoWrap=�6?   $�� ��6U   $��Center=�6]   $��28��6x   $��5q�6�   $��	5,13,5,12q�6�   /  )Microsoft.Windows.Controls.DateTimePicker  50      -   5          Name$ txt_date_begin��50   |   /  )Microsoft.Windows.Controls.DateTimeUpDown   Format$ Custom=�6.      FormatString$ HH:mm dd/MM/yyyy��6>   $��1��6^   $��2��6n   $��Stretch=�6�   $��Center=�6�   $��	5,22,5,23q�6�   $��24��6�     51      -   5        $ txt_date_end��51   |   $ Custom=�6.   $ HH:mm dd/MM/yyyy��6>   $��1��6^   $��3��6n   $��Stretch=�6�   $��Center=�6�   $��	5,17,5,20q�6�   $��24��6�   �� 52      -   5         ��Name$ everyday_cb��52   #   $�� ��68   $��1��6C   $
��Left=�6S   $
��10,0q�6n   $��4��6|   $��Center=�6�   �� 53      -	   5        $��Tiếp��53   !   $��1��60   $��Right=�6@   $��
0,28,21,28q�6\   $��5��6p   $��Center=�6}   $��70��6�   $��24��6�   6�   �� 54      -
   5        $��Huỷ��54   !   $
��Left=�6/   $��
21,28,0,28q�6J   $��5��6^   $��Center=�6k   $��70��6�   $��24��6�   6�   55      56      �� 57      -   5        $ layout_step_2��57      ���	#FFFF670F$��2q�6I   
�������$	 503��6p   $ 40��6�   $	��360��6�   $	��395��6�   ._�58      � -   5        $ grid_layout_plan_details��58      $��Stretch=�6>   $��Stretch=�6\    59      �� 5:      $	��50* �6,   �� 5;      $
��276* �6,   �� 5<      $	��65* �6,   .+�5>      �� $��Stretch=�6"   $��Stretch=�6@   $��0��6\   ��5?      �� 5@   "   $ 0.5,1&�66   $	 0.5,0&�6G   .��5A   &   � $
 	#99FFA84C��63   $ 0Q�6E   � 5B   &   $
 	#99FF7B0D��63   $ 1Q�6E   5C   #   ._�5E      �� $��15,0,0,0q�6(   $��NoWrap=�6:   
�������$��Thêm video��6c   $��Center=�6u   $��19(�6�   $
��Bold"�6�   5F      /   )Alta_Media_Manager.Plugin.autoSearchMedia  5G      -   5          Name$ 
autoSearch��5G   1   $��1��6E   6U   5H      5I      5J      5L      5M      5N      