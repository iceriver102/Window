   M S B A M L   `   `   `  ����G  CWpfScheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA0clr-namespace:WpfScheduler;assembly=WpfSchedulerWpfScheduler  5       Alta_Media_Manager0   *Alta_Media_Manager.Alta_view.alta_Schedule   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Eschedule0clr-namespace:WpfScheduler;assembly=WpfScheduler     5      $��Verdana)�5   8   .��5	      �� -   5          ��Name$  main_layout��5	      $	��663��6"   $
��1346��6/   .+�5
   
   � -   5         �Name$ layout_content��5
      $	��663��6'   $
��1346��64    �� Left$ 0��6A   
 �� Top$ 0��6Q    � ColumnDefinitions 5      �� 5      $
��109* �6#   �� 5      $
��449* �6#   �� 5      $
��115* �6#    � RowDefinitions 5      �� 5      $	��51* �6    �� 5      $
��566* �6    �� 5      $	��46* �6    .+�5      � $��0��6   $��1��6#   $��3��60   .+�5         WpfScheduler.Scheduler  -   5          Name$ Alta_Schedule��5   %      Mode$ Month=�6<   $��0,0,5,0q�6I   5      5      �� 5      $��1��6    �� Orientation$ 
Horizontal=�6*   $��2��6C   $��
780,0,10,0q�6W   .+�5      �� 	 �� CornerRadius$	 3,0,0,3��6   $��Center=�60   $��50��6K   $��25��6V   ���	#ffff8800$��1,1,0,1q�6z   ._�5      �� -   5        $��Center=�5      $��52��68   $��25��6C      btn_tmp_navigation#���   6P   
������ $��-1,0,0,0q�6�   
 J� Clip
 5      �� 5       �� RadiusX$	 6.5Q�61    �� RadiusY$	 5.5Q�6?    �� Rect$ 	0,0,53,25�6M   ��5      �� 5        j� Stretch$ Uniform=�6)    �� ImageSource$N H/Alta_Media_Manager;component/Asset/Alta_Btn/ic_action_previous_item.png��6;   5"      5#      �� 5%      ���	#FFFF8800$��1,1,0,1q�62   $��75��6L   $��25��6W   
������� � Cursor$
 Hand��6v   ._�5&      �� -   5        $��Month��5&      $��0q�6-   $��25��6A   $��Center=�6N   $��75��6i   
������ ���	#FF1C94C4
������ $
��Bold"�6�   6�   5'      �� 5(      $��Center=�6   $��75��64   
����������	#FFFF8800$��25��6k   $��1q�6w   }�. $
 Hand��6�   ._�5)      �� -   5        $
��Week��5)      $��0q�6-   $��25��6A   $
��Bold"�6M   $��Center=�6`   $��74��6{   
������ 
������ ���	#FF1C94C46�   5*      �� 5+      ���	#FFFF8800$��0,1,1,1q�61   $��25��6K   $��75��6W   }�. 
�������$
 Hand��6�   ._�5,      �� -   5        $	��Day��5,      $��0q�6,   $��25��6@   $
��Bold"�6L   $��Center=�6^   $��75��6y   
������ 
������ ���	#FF1C94C46�   5-      �� 5.      $	 0,3,3,0��6   ���	#ffff8800$��0,1,1,1q�6J   $��50��6d   $��25��6o   }�. ._�5/      �� -   5        $��Center=�5/      $��50��68   $��24��6C   #���   6O   
������ $��0q�6�   $��0,1,-1,0q�6�   
 50      �� 51      $	 4.5Q�61   $ 4Q�6?   $ 
-1,0,50,25�6K   ��53      �� 54      $ Uniform=�6)   $J D/Alta_Media_Manager;component/Asset/Alta_Btn/ic_action_next_item.png��6;   56      57      58      �� 59      $��Thêm Lịch Phát:��6   $��Center=�6/   $	��110��6J   $
��Left=�6V   $��60,0,0,0q�6q   �� 5:      -	   5        $��0q�5:      $��Center=�6*   $��36��6E   $��36��6P   $��	170,0,0,0q�6\     btn_tmp#���  6�   ��6o   Z� ��5;      �� 5<      $ Uniform=�6!   $> 8/Alta_Media_Manager;component/Asset/Alta_Btn/btn_add.png��63   5>      5@      5A      5B      