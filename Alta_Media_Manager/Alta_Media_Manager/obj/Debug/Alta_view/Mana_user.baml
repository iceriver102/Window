   M S B A M L   `   `   `  ����  Alta_Media_Manager,    &Alta_Media_Manager.Alta_view.Mana_user   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $��Verdana)�5   8   .��5      �� -   5          ��Name$  main_layout��5      $	��663��6"   $
��1346��6/   .+�5	   
   � -   5         �Name$ Grid_content��5	      $��Stretch=�6%   $��Stretch=�6A    �� Left$ 0��6_   
 �� Top$ 0��6o   $
��1346��6~   $	��663��6�    � ColumnDefinitions 5
      �� 5      $
��109* �6#   �� 5      $
��449* �6#   �� 5      $
��115* �6#    � RowDefinitions 5      �� 5      $	��18* �6    �� 5      $
��200* �6    �� 5      $	��18* �6    .+�5      �� ���	#7FF48120$	��0,1q�6.   $��1��6D   $��3��6Q   $��Stretch=�6e   $��Stretch=�6�   ._�5      �� -   5         ��Name$ list_Box_Item��5       �� SelectionMode$ Single=�61   $��1��6I   $��15,0,0,0q�6V   $��Stretch=�6h   $��Stretch=�6�   $
��Auto=�6�   $��Hidden=�6�   ��6  Z� ��6  Z� ��63  Z�  � 	Resources 5      	 �� 
TargetType
 �� Property �� Value��%r   '��       �� 5      "	 ��6    .�5      �� 
 � �� .  6:   �� 5      
 � |� .  6:   5      5      ��5      �� 5      .R�5      � ��6(   �� * (FrameworkElement.ActualWidth)+ �� RelativeSource ��  �� AncestorType$ ScrollContentPresenterL� � 	ItemWidth 5      �� *(ListView.View).ItemWidth+ �� $ ListViewL���5       �� *	ItemWidth+ �� *Self+ � 
ItemHeight 5!      �� *(ListView.View).ItemHeight+ �� $ ListViewL�5"      ��5$      �� 5%      "	 ��6    .�5&      �� 
 � ��$ 0q�6@   �� 5'      
 � ��$ 8q�67   �� 5(      
 � ��$ 0q�68   5)      5+      5,      �� 5-      $��1��6   $��0��6*   $��Center=�67   $��Stretch=�6V    �� Orientation$ 
Horizontal=�6r   .+�5.      �� $��NoWrap=�6   $��Tìm kiếm:��62   $��Center=�6C   $	��5,0q�6^   �� 5/      -   5         ��Name$ txt_Key_Search��5/       �� TextWrapping$ NoWrap=�62   $��0q�6H   $�� ��6\   $��Center=�6d   $��	5,14,5,13q�6   $��26��6�   $	��311��6�   $	��8,5q�6�   
���������6�   Z� .��6�   ��50      �� 51       �� ImageSource$D >/Alta_Media_Manager;component/Asset/Alta_Images/txt_search.png��6%    j� Stretch$ Uniform=�6r   .��52   *   53      �� 54      -   5         ��Name$ 	btnSearch��54      $��24��6,   $��24��67   $��Center=�6D   $	��5,0q�6_      btn_tmp_search#���   6l   ��55      �� 56      $ Uniform=�6%   $H B/Alta_Media_Manager;component/Asset/Alta_Btn/btn_search_normal.png��67   58      59      �� 5:      -   5        $ btnAdd��5:      $��2��6&   $��Right=�66   $��5q�6R   $��Center=�6]   $��43��6x   $��41��6�     btn_tmp_add#���  6�   $��0q�6�   ��6�   Z� ��5;      �� 5<      $ Uniform=�6!   $E ?/Alta_Media_Manager;component/Asset/Alta_Btn/btn_add_normal.png��63   5>      �� 5?      $��2��6   $��Right=�6(   $
��55,0q�6D   $
��Wrap=�6R   $��Thêm User:��6f   $��Center=�6x   �� 5@      -   5         ��Name$ Cb_Sort��5@      $��Right=�6(   $
��10,0q�6D   $��Center=�6R   $	��110��6m   $��25��6y   $��5q�6�   .@�5A      �� -   5         ��Name$ 	sort_time��5A      $��Thời gian tạo��6+   $��25��6D   
�������6P   �� 5B      -	   5        $ 	sort_name��5B      $��	Tên User��6+   $��Stretch=�6>   $��25��6]   
�������6i   5C      �� 5D      $
��Left=�6   $��10q�63   $
��Wrap=�6?   $��Sắp xếp theo:��6S   $��Center=�6h   � 5E      $��1��6   $��Center=�6#   $��2��6A   $��Stretch=�6N   $��80��6j   $��409,2q�6u    5F      �� 5G      $	��45* �6'   �� 5H      $	��45* �6'   .+�5J      �� -
   5        $ btn_backPage��5J        btnTmplNormal#���  60   $��0q�6\   $��Center=�6h   $��Center=�6�   $��32��6�   $��32��6�   
���������6�   Z� ��5K      �� 5L      $ Uniform=�6%   $G A/Alta_Media_Manager;component/Asset/Alta_Btn/btn_back_disable.png��67   5N      �� 5O      -   5        $ btn_nextPage��5O      $��0q�60   #���  6;   $��Center=�6f   $��Center=�6�   $��32��6�   $��32��6�   $��1��6�   
���������6�   Z� ��5P      �� 5Q      $ Uniform=�6%   $? 9/Alta_Media_Manager;component/Asset/Alta_Btn/btn_next.png��67   5S      5T      �� 5U      -   5        $ 	lb_status��5U      $��status��6'   $
��Left=�68   $��	0,10,0,12q�6S   $��2��6f   $��Center=�6s   $��2��6�   $	��474��6�   $��24��6�   5V      5W      5X      