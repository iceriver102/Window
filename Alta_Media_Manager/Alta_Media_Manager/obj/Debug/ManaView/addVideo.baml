   M S B A M L   `   `   `  ����M  IAlta_Media_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Alta_Media_Manager.PluginAlta_Media_Manager.Plugin  5
      *    $Alta_Media_Manager.ManaView.addVideo   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      a ]DevExpress.Xpf.Core.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      4plugin'clr-namespace:Alta_Media_Manager.Plugin  5
      &   DevExpress.Xpf.Core.ThemeManager    	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$  DXStyle 5      $��Arial)�5   8   $��14(�6K   .��5      � -   5         �Name$ 
Grid_Video��5      $��Stretch=�6   $��Stretch=�6=   $	��693��6Z   $
��1346��6g   ���	#4C0A0A0A � RowDefinitions 5   
   �� 5      $	��74* �6   �� 5      $	��50* �6   �� 5      $
��543* �6   .+�5   
   �� $	��360��6   $	��320��6   $
��0,10q�6*   $��2��69   $��Center=�6F   $	��Top=�6c   
���   �$��2q�6�   ._�5      � 
�������$��Stretch=�6'   $��Stretch=�6E    � ColumnDefinitions 5      �� 5      $	��91* �6'   �� 5      $
��305* �6'    5      �� 5      $��9* �6$   �� 5      $	��10* �6$   �� 5      $	��10* �6$   �� 5      $	��10* �6$   �� 5      $	��10* �6$   �� 5       $	��10* �6$   �� 5!      $	��11* �6$   .+�5#      �� 
���   �$��0��6.   $��0,0,0,1q�6<   $��2��6V   ��5$      �� 5%       �� EndPoint$ 0.5,1&�6.    �� 
StartPoint$ 0.5,0&�6?   .��5&      �  � Color$ 	#99FFA84C��6+    � Offset$ 0Q�6=   � 5'      $ 	#99FF7B0D��6+   $ 1Q�6=   5(      ._�5*      �� -   5         ��Name$ 	title_txt��5*       $�� ��63   	 �� TextAlignment$	 Center=�6;   $��Stretch=�6R   $��Center=�6p   $��17(�6�   $
��Bold"�6�   5+      �� 5,      $��Stretch=�6   $��0q�6:   $��1��6E   $
��Wrap=�6R   $��Tên:��6f   $��Center=�6r   $��16��6�   $	 Right=�6�   �� 5-      $��Stretch=�6   $��0q�6:   $��2��6E   $
��Wrap=�6R   $��File:��6f   $��Center=�6s   $��16��6�   $	 Right=�6�   �� 5.      $��Stretch=�6   $��0q�6:   $��3��6E   $
��Wrap=�6R   $��	Mô tả:��6f   $��Center=�6t   $��16��6�   $	 Right=�6�   �� 5/      -   5        
 ��Name$
 txt_name��5/      $	��3,5q�6,   $��1��6:   $��Stretch=�6J   $��30��6h   $
��10,0q�6t   $��1��6�    �� TextWrapping$ NoWrap=�6�   $�� ��6�   $��Center=�6�   '  !DevExpress.Xpf.Editors.ButtonEdit  50      -   5          Name$ txt_file��50   !   )  #DevExpress.Xpf.Editors.TextEditBase   Text$  ��63   $��1��6;   $��30��6K   $��Stretch=�6W   $
��10,0q�6u   $��2��6�   $��Center=�6�   6�   �� 51      -   5        $
 txt_content��51       �� AcceptsReturn . $	��3,5q�6E   $��1��6S   $��Stretch=�6c   $��90��6�   $
��10,0q�6�   $��3��6�   $
 Wrap=�6�   $�� ��6�   $��Center=�6�   $��2��6�   �� 52      -   5         � Cursor$
 Hand��52      $
��Lưu��6'   $��1��65   $
��Left=�6E   $��
138,9,0,12q�6`   $��7��6t   $��Center=�6�   $��76��6�   $��29��6�   6�   �� 53      -   5        $
 Hand��53      $��Đóng��6'   $��Center=�66   $��23,10,198,16q�6S   $��6��6i   $��Center=�6v   $��75��6�   $��29��6�   $��2��6�   *   $Alta_Media_Manager.Plugin.ftp_upload  54      -   5          Name$	 ftp��54   $   $��Stretch=�61   $��12��6O   $��
10,10,10,0q�6[   $��5��6o   $	��Top=�6|   $��2��6�   56      57      59      5:      