   M S B A M L   `   `   `  ����M  IAlta_Media_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:Alta_Media_Manager.Alta_view.Item_mana&Alta_Media_Manager.Alta_view.Item_mana  5      ,    &Alta_Media_Manager.Alta_view.Mana_Plan   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      EItem4clr-namespace:Alta_Media_Manager.Alta_view.Item_mana     5      $��Verdana)�5   8   .��5	      �� -   5          ��Name$  main_layout��5	      $	��663��6"   $
��1346��6/   .+�5
   
   � $��Stretch=�6   $��Stretch=�6+    �� Left$ 0��6I   
 �� Top$ 0��6Y   $
��1346��6h   $	��663��6u    � ColumnDefinitions 5      �� 5      $
��109* �6#   �� 5      $
��449* �6#   �� 5      $
��115* �6#    � RowDefinitions 5      �� 5      $	��18* �6    �� 5      $
��200* �6    �� 5      $	��18* �6    .+�5      �� ���	#7FF48120$	��0,1q�6.   $��1��6D   $��3��6Q   $��Stretch=�6e   $��Stretch=�6�   ._�5      �� -   5         ��Name$ list_Box_Item��5       �� SelectionMode$ Single=�61   $��1��6I   $��15,0,0,0q�6V   $��Stretch=�6h   $��Stretch=�6�   $
��Auto=�6�   $��Hidden=�6�   ��6  Z� ��6  Z� ��63  Z�  � 	Resources 5       �� 
TargetType	 �� Property
 �� Value��%r   '��       �� 5      " ��6    .�5      �� 	 � ��
 .  6:   �� 5      	 � |�
 .  6:   5      5      ��5      �� 5      .R�5      � ��6(   �� * (FrameworkElement.ActualWidth)+ �� RelativeSource ��  �� AncestorType$ ScrollContentPresenterL� � 	ItemWidth 5       �� *(ListView.View).ItemWidth+ �� $ ListViewL���5!      �� *	ItemWidth+ �� *Self+ � 
ItemHeight 5"      �� *(ListView.View).ItemHeight+ �� $ ListViewL�5#      ��5%      �� 5&      " ��6    .�5'      �� 	 � ��$
 0q�6@   �� 5(      	 � ��$
 8q�67   �� 5)      	 � ��$
 0q�68   5*      5,      5-      �� 5.      $��1��6   $��0��6*   $��Center=�67   $��Stretch=�6V    �� Orientation$ 
Horizontal=�6r   .+�5/      �� $��NoWrap=�6   $��Tìm kiếm:��62   $��Center=�6C   $	��5,0q�6^   �� 50      -   5         ��Name$ txt_Key_Search��50       �� TextWrapping$ NoWrap=�62   $��0q�6H   $�� ��6\   $��Center=�6d   $��	5,14,5,13q�6   $��26��6�   $	��311��6�   $	��8,5q�6�   
���������6�   Z� .��6�   ��51      �� 52       �� ImageSource$D >/Alta_Media_Manager;component/Asset/Alta_Images/txt_search.png��6%    j� Stretch$ Uniform=�6r   .��53   *   54      �� 55      -   5        $��24��55      $��24��6$   $��Center=�61   $	��5,0q�6L      btn_tmp_search#���   6Y   ��56      �� 57      $ Uniform=�6%   $H B/Alta_Media_Manager;component/Asset/Alta_Btn/btn_search_normal.png��67   59      5:      �� 5;      -   5        $��2��5;      $��Right=�6&   $��0,5,79,5q�6B   $��Center=�6T   $��43��6o   $��41��6z     btn_tmp_add#���  6�   $��0q�6�   ��6�   Z� ��5<      �� 5=      $ Uniform=�6!   $E ?/Alta_Media_Manager;component/Asset/Alta_Btn/btn_add_normal.png��63   5?      �� 5@      $��2��6   $��Right=�6(   $��0,18,129,18q�6D   $
��Wrap=�6Y   $��Thêm playlist:��6m   $��Center=�6�   �� 5A      -   5         ��Name$ Cb_Sort��5A      $��Right=�6(   $��0,13,857,13q�6D   $��Center=�6Y   $	��110��6t   $��25��6�   $��5q�6�   $��2��6�   .@�5B      �� -   5         ��Name$ 	sort_time��5B      $��Thời gian tạo��6+   $��25��6D   
�������6P   �� 5C      -   5        $ 	sort_name��5C      $��Tên playlist��6+   $��Stretch=�6B   $��25��6a   
�������6m   5D      �� 5E      $
��Left=�6   $��
61,18,0,18q�63   $
��Wrap=�6G   $��Sắp xếp theo:��6[   $��Center=�6p   � 5F      $��1��6   $��Center=�6#   $��2��6A   $��Stretch=�6N   $��80��6j   $��409,2q�6u    5G      �� 5H      $	��45* �6'   �� 5I      $	��45* �6'   .+�5K      �� -	   5         ��Name$ btn_backPage��5K        btnTmplNormal#���  60   $��0q�6\   $��Center=�6h   $��Center=�6�   $��32��6�   $��32��6�   
���������6�   Z� ��5L      �� 5M      $ Uniform=�6%   $G A/Alta_Media_Manager;component/Asset/Alta_Btn/btn_back_disable.png��67   5O      �� 5P      -
   5        $ btn_nextPage��5P      $��0q�60   #���  6;   $��Center=�6f   $��Center=�6�   $��32��6�   $��32��6�   $��1��6�   
���������6�   Z� ��5Q      �� 5R      $ Uniform=�6%   $? 9/Alta_Media_Manager;component/Asset/Alta_Btn/btn_next.png��67   5T      5U      �� 5V      -   5        $ 	lb_status��5V      $��status��6'   $
��Left=�68   $��	0,10,0,12q�6S   $��2��6f   $��Center=�6s   $��2��6�   $	��474��6�   $��24��6�   �� 5W      -   5        $ btn_back_navigation��5W        btn_tmp#���  62   $�� ��6W   $��Center=�6b   $��Center=�6�   $��32��6�   $��32��6�   $��10,9,176,10q�6�   $��0q�6�   $y�Hidden=�6	  ��6�   Z� ��5X      �� 5Y      $ Uniform=�6!   $? 9/Alta_Media_Manager;component/Asset/Alta_Btn/btn_back.png��63   5[      5\      5]      5_      