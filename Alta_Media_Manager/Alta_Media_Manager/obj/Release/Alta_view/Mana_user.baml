   M S B A M L   `   `   `  ����   Alta_Media_Manager,    &Alta_Media_Manager.Alta_view.Mana_user   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     $��Verdana)�.���� -     ��Name$  main_layout��$	��663��$
��1346��.+�� -    �Name$ Grid_content��$��Stretch=�$��Stretch=� �� Left$ 0��
 �� Top$ 0��$
��1346��$	��663�� � ColumnDefinitions �� $
��109* ��� $
��449* ��� $
��115* � � RowDefinitions �� $	��18* ��� $
��200* ��� $	��18* �.+��� ���	#7FF48120$	��0,1q�$��1��$��3��$��Stretch=�$��Stretch=�._��� -    ��Name$ list_Box_Item�� �� SelectionMode$ Single=�$��1��$��15,0,0,0q�$��Stretch=�$��Stretch=�$
��Auto=�$��Hidden=���Z� ��Z� ��Z�  � 	Resources 	 �� 
TargetType
 �� Property �� Value��%?   '��       �� "	 ��.��� 
 � �� .  �� 
 � |� .  ���� .R�� ���� * (FrameworkElement.ActualWidth)+ �� RelativeSource ��  �� AncestorType$ ScrollContentPresenterL� � 	ItemWidth �� *(ListView.View).ItemWidth+ �� $ ListViewL����� *	ItemWidth+ �� *Self+ � 
ItemHeight �� *(ListView.View).ItemHeight+ �� $ ListViewL����� "	 ��.��� 
 � ��$ 0q��� 
 � ��$ 8q��� 
 � ��$ 0q��� $��1��$��0��$��Center=�$��Stretch=� �� Orientation$ 
Horizontal=�.+��� $��NoWrap=�$��Tìm kiếm:��$��Center=�$	��5,0q��� -    ��Name$ txt_Key_Search�� �� TextWrapping$ NoWrap=�$��0q�$�� ��$��Center=�$��	5,14,5,13q�$��26��$	��311��$	��8,5q�
���������Z� .������  �� ImageSource$D >/Alta_Media_Manager;component/Asset/Alta_Images/txt_search.png�� j� Stretch$ Uniform=�.���� -    ��Name$ 	btnSearch��$��24��$��24��$��Center=�$	��5,0q�   btn_tmp_search#���   ���� $ Uniform=�$H B/Alta_Media_Manager;component/Asset/Alta_Btn/btn_search_normal.png���� -   $ btnAdd��$��2��$��Right=�$��5q�$��Center=�$��43��$��41��  btn_tmp_add#���  $��0q���Z� ���� $ Uniform=�$E ?/Alta_Media_Manager;component/Asset/Alta_Btn/btn_add_normal.png���� $��2��$��Right=�$
��55,0q�$
��Wrap=�$��Thêm User:��$��Center=��� -    ��Name$ Cb_Sort��$��Right=�$
��10,0q�$��Center=�$	��110��$��25��$��5q�.@��� -    ��Name$ 	sort_time��$��Thời gian tạo��$��25��
��������� -	   $ 	sort_name��$��	Tên User��$��Stretch=�$��25��
��������� $
��Left=�$��10q�$
��Wrap=�$��Sắp xếp theo:��$��Center=�� $��1��$��Center=�$��2��$��Stretch=�$��80��$��409,2q� �� $	��45* ��� $	��45* �.+��� -
   $ btn_backPage��  btnTmplNormal#���  $��0q�$��Center=�$��Center=�$��32��$��32��
���������Z� ���� $ Uniform=�$G A/Alta_Media_Manager;component/Asset/Alta_Btn/btn_back_disable.png���� -   $ btn_nextPage��$��0q�#���  $��Center=�$��Center=�$��32��$��32��$��1��
���������Z� ���� $ Uniform=�$? 9/Alta_Media_Manager;component/Asset/Alta_Btn/btn_next.png���� -   $ 	lb_status��$��status��$
��Left=�$��	0,10,0,12q�$��2��$��Center=�$��2��$	��474��$��24��