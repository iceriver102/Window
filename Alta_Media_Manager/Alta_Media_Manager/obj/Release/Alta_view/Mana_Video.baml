   M S B A M L   `   `   `  ���� M  IAlta_Media_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:Alta_Media_Manager.Alta_view.Item_mana&Alta_Media_Manager.Alta_view.Item_mana  -    'Alta_Media_Manager.Alta_view.Mana_Video   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Eitem4clr-namespace:Alta_Media_Manager.Alta_view.Item_mana     $��Verdana)�  � 	Resources  ��%    .���� -    ��Name$ main_layout��$	��663��$
��1346��.+�� $��Stretch=�$��Stretch=� �� Left$ 0��
 �� Top$ 0��$
��1346��$	��663�� � ColumnDefinitions �� $
��109* ��� $
��449* ��� $
��115* � � RowDefinitions �� $	��51* ��� $
��566* ��� $	��46* �.+��� ���	#7FF48120$	��0,1q�$��1��$��3��$��Stretch=�$��Stretch=�._��� -    ��Name$ list_Box_Item�� �� SelectionMode$ Single=�$��15,0,0,0q�$��Stretch=�$��Stretch=�$
��Auto=�$��Hidden=���Z� ��Z� ��Z�    �� 
TargetType	 �� Property
 �� Value��%?   '��       �� " ��.��� 	 � ��
 .  �� 	 � |�
 .  ���� .R�� ���� * (FrameworkElement.ActualWidth)+ �� RelativeSource ��  �� AncestorType$ ScrollContentPresenterL� � 	ItemWidth �� *(ListView.View).ItemWidth+ �� $ ListViewL����� *	ItemWidth+ �� *Self+ � 
ItemHeight �� *(ListView.View).ItemHeight+ �� $ ListViewL����� " ��.��� 	 � ��$
 0q��� 	 � ��$
 8q��� 	 � ��$
 0q��� $��1��$��0��$��Center=�$��Stretch=� �� Orientation$ 
Horizontal=�$��236,0q�$	��426��.+��� $��NoWrap=�$��Tìm kiếm:��$��Center=�$	��5,0q��� -    ��Name$ txt_Key_Search�� �� TextWrapping$ NoWrap=�$��0q�$�� ��$��Center=�$��	5,14,5,13q�$��26��$	��311��$	��8,5q�
���������Z� .������  �� ImageSource$D >/Alta_Media_Manager;component/Asset/Alta_Images/txt_search.png�� j� Stretch$ Uniform=�.���� -   $��24��$��24��$��Center=�$	��5,0q�   btn_tmp_search#���   ���� $ Uniform=�$H B/Alta_Media_Manager;component/Asset/Alta_Btn/btn_search_normal.png���� -   $��2��$��Right=�$��0,5,75,5q�$��Center=�$��43��$��41��  btn_tmp_add#���  $��0q���Z� ���� $ Uniform=�$E ?/Alta_Media_Manager;component/Asset/Alta_Btn/btn_add_normal.png���� $��2��$��Right=�$��0,18,125,18q�$
��Wrap=�$��Thêm video:��$��Center=�$��15��$��76���� -    ��Name$ Cb_Sort��$��Right=�$��0,13,855,13q�$��Center=�$	��110��$��25��$��5q�$��2��.@��� -    ��Name$ 	sort_time��$��Thời gian tạo��$��25��
��������� -   $ 	sort_name��$��
Tên Video��$��Stretch=�$��25��
��������� $
��Left=�$��
63,18,0,18q�$
��Wrap=�$��Sắp xếp theo:��$��Center=�$��15��$��85��� $��1��$��Center=�$��2��$��Stretch=�$��80��$��409,2q� �� $	��45* ��� $	��45* �.+��� -	    ��Name$ btn_backPage��  btn_tmp#���  $��0q�$��0q�$��Center=�$��Center=�$��32��$��32��
���������Z� ���� $ Uniform=�$? 9/Alta_Media_Manager;component/Asset/Alta_Btn/btn_back.png���� -
   $ btn_nextPage��#���  $��0q�$��Center=�$��Center=�$��32��$��32��$��1��
���������Z� ���� $ Uniform=�$? 9/Alta_Media_Manager;component/Asset/Alta_Btn/btn_next.png���� -   $ 	lb_status��$��status��$
��Left=�$��	0,10,0,12q�$��2��$��Center=�$��2��$	��474��$��24���� -   $ btn_back_navigation��#���  $�� ��$��Center=�$��Center=�$��32��$��32��$��10,9,176,10q�$��0q�$y�Hidden=���Z� ���� $ Uniform=�$? 9/Alta_Media_Manager;component/Asset/Alta_Btn/btn_back.png��