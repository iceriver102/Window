   M S B A M L   `   `   `  ���� G  CWpfScheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA0clr-namespace:WpfScheduler;assembly=WpfSchedulerWpfScheduler   Alta_Media_Manager0   *Alta_Media_Manager.Alta_view.alta_Schedule   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Eschedule0clr-namespace:WpfScheduler;assembly=WpfScheduler     $��Verdana)�.���� -     ��Name$  main_layout��$	��663��$
��1346��.+�� -    �Name$ layout_content��$	��663��$
��1346�� �� Left$ 0��
 �� Top$ 0�� � ColumnDefinitions �� $
��109* ��� $
��449* ��� $
��115* � � RowDefinitions �� $	��51* ��� $
��566* ��� $	��46* �.+�� $��0��$��1��$��3��.+�   WpfScheduler.Scheduler  -     Name$ Alta_Schedule��   Mode$ Month=�$��0,0,5,0q��� $��1�� �� Orientation$ 
Horizontal=�$��2��$��
780,0,10,0q�.+��� 	 �� CornerRadius$	 3,0,0,3��$��Center=�$��50��$��25�����	#ffff8800$��1,1,0,1q�._��� -   $��Center=�$��52��$��25��   btn_tmp_navigation#���   
������ $��-1,0,0,0q�
 J� Clip
 ��  �� RadiusX$	 6.5Q� �� RadiusY$	 5.5Q� �� Rect$ 	0,0,53,25�����  j� Stretch$ Uniform=� �� ImageSource$N H/Alta_Media_Manager;component/Asset/Alta_Btn/ic_action_previous_item.png���� ���	#FFFF8800$��1,1,0,1q�$��75��$��25��
������� � Cursor$
 Hand��._��� -   $��Month��$��0q�$��25��$��Center=�$��75��
������ ���	#FF1C94C4
������ $
��Bold"��� $��Center=�$��75��
����������	#FFFF8800$��25��$��1q�}�. $
 Hand��._��� -   $
��Week��$��0q�$��25��$
��Bold"�$��Center=�$��74��
������ 
������ ���	#FF1C94C4�� ���	#FFFF8800$��0,1,1,1q�$��25��$��75��}�. 
�������$
 Hand��._��� -   $	��Day��$��0q�$��25��$
��Bold"�$��Center=�$��75��
������ 
������ ���	#FF1C94C4�� $	 0,3,3,0�����	#ffff8800$��0,1,1,1q�$��50��$��25��}�. ._��� -   $��Center=�$��50��$��24��#���   
������ $��0q�$��0,1,-1,0q�
 �� $	 4.5Q�$ 4Q�$ 
-1,0,50,25����� $ Uniform=�$J D/Alta_Media_Manager;component/Asset/Alta_Btn/ic_action_next_item.png���� $��Thêm Lịch Phát:��$��Center=�$	��110��$
��Left=�$��60,0,0,0q��� -	   $��0q�$��Center=�$��36��$��36��$��	170,0,0,0q�  btn_tmp#���  ��Z� ���� $ Uniform=�$> 8/Alta_Media_Manager;component/Asset/Alta_Btn/btn_add.png��