   M S B A M L   `   `   `  ����  Alta_Media_Manager4    .Alta_Media_Manager.Alta_view.alta_add_playlist   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $��Verdana)�5   8   .��5      � -   5        ���	#804F4F4F  � RowDefinitions  5	   
   �� 5
      $	��15* �6   �� 5      $
��200* �6   �� 5      $	��15* �6   .+�5   
   �� -   5        
������ $��1q�5   +   $��Center=�6?   $	��320��6\   $��0q�6i   $��1��6t   $��Center=�6�   $	��400��6�   ._�5      � 
������� � ColumnDefinitions 5      �� 5      $	��91* �6'   �� 5      $
��305* �6'     5      �� 5      $	��40* �6$   �� 5      $	��49* �6$   �� 5      $	��38* �6$   �� 5      $	��73* �6$   �� 5      $	��23* �6$   �� 5      $	��42* �6$   .+�5      �� $��0��6   $��2��6)   
������ $��0q�6W   $��Stretch=�6k   $��0q�6�   $��Stretch=�6�   ���	#FF040404._�5      �� -   5         ��Name$ 	title_txt��5       $��Stretch=�63    �� TextAlignment$ Center=�6Q   $��0q�6h   $��1��6s   $
��Wrap=�6�   $��Thêm Playlist��6�   $��Center=�6�   
�������$��16(�6�   $
��Bold"�6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 4Q�6/      	Direction$	 330Q�6?      Color$ 	#FFB83A00��6O      Opacity$	 0.5Q�6a   	   
BlurRadius$	 4Q�5       5"      5#      �� 5$      $��Stretch=�6   $��	0,16,0,17q�6:   $��1��6M   $
��Wrap=�6Z   $��Tên:��6n   $��Center=�6z   $��16��6�   $ Right=�6�   �� 5&      $��Stretch=�6   $
��0,11q�6:   $��2��6H   $
��Wrap=�6U   $��	Mô tả:��6i   $��Center=�6w   $��16��6�   $ Right=�6�   �� 5'      -   5        
 ��Name$
 txt_name��5'      $	��3,5q�6,   $��1��6:   $��Stretch=�6J   $��30��6h   $��
10,10,10,9q�6t   $��1��6�    �� TextWrapping$ NoWrap=�6�   $�� ��6�   $��Center=�6�   �� 5)      -   5        $
 txt_content��5)       �� AcceptsReturn . $	��3,5q�6E   $��1��6S   $��Stretch=�6c   $	��109��6�   $��10,15,10,10q�6�   $��2��6�   $
 Wrap=�6�   $�� ��6�   $��Center=�6�   $��2��6�   � 5+      $��0��6   $��Stretch=�6'   $��0q�6E   $��5��6P   $��Stretch=�6]   $��2��6y    5,      �� 5.      $��1* �6+   .+�50      �� -   5         � Cursor$
 Hand��50         btnTmplNormal#���   6+   $
��Lưu��6V   $��Center=�6d   $��0q�6�   $��Center=�6�   $��76��6�   $��29��6�   
�������$��1��6�   ��51      �� 52       j� Stretch$ Uniform=�6)    �� ImageSource$A ;/Alta_Media_Manager;component/Asset/Alta_Btn/btn_normal.png��6;   54      55      58      59      �� 5:   
   -   5        $��0q�5:      $
 Hand��6%   $��Center=�63   $��Center=�6P   $��28��6k   $��28��6v     btn_tmp#���  6�   
�������$��0��6�   $��855,118,463,431q�6�   $��1��6  ��6�   Z� ��5;      �� 5<      $ Uniform=�6   $D >/Alta_Media_Manager;component/Asset/Alta_Btn/btn_close_box.png��6/   5>      5?      5@      