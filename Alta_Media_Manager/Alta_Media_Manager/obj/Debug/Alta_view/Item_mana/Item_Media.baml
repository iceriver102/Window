   M S B A M L   `   `   `  ����  Alta_Media_Manager7    1Alta_Media_Manager.Alta_view.Item_mana.Item_Media   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        $��Vedena)�5   i     � 	Resources  5         btn_tmp �� 
TargetType ��Name � Cursor �� Padding��%�   &	        �� 5	   
   " ��6*   .R�5
      �� $ border��6   $
 Hand��6%   $ 0q�63   $��0q�6?   
������ #��z��6m   ._�5      �� $��Center=�6$   $��Center=�6A   5      5      5      .��5      � $	��190��6   $	��Top=�6   .+�5   
   �� -   5        $ 
border_out��5      $��8q�6%   
������ $��2q�5      ��5      �� 5       j� Stretch$
 Fill=�6    �� ImageSource$; 5/Alta_Media_Manager;component/Asset/Image/bg_item.png��6,    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 12Q�6#   	   	Direction$		 320Q�63   
   Color$
 	#FFC1C0C0��6C   ._�5      � $��0q�6    � RowDefinitions 5      �� 5      $	��69* �6$   �� 5      $	��71* �6$    � ColumnDefinitions 5      �� 5      $
��144* �6'   �� 5       $
��215* �6'   �� 5!      $	��45* �6'   .+�5#      �� $��0��6   $��0��6-   $��2��6;    �� Orientation$ Vertical=�6L   .+�5$      �� $=��7/Alta_Media_Manager;component/Asset/Icon/video_icon.png��6   $	��129��6^   �� 5%      -   5         ��Name$ txt_alta_userCreate��5%       $��Admin��6=   $��16(�6J   
������� �� TextAlignment$ Right=�6k   $
 Hand��6�   $��0,5,10,0q�6�   5&      �� 5'      $
 Hand��6   #���   6'   $�� ��6L   $��1��6W   $
��Left=�6g   $��154,65,0,-20q�6�   $��1��6�   $	��Top=�6�   $��38��6�   $��38��6�   ��6�   Z� ��5(      �� 5)      $= 7/Alta_Media_Manager;component/Asset/Icon/video_play.png��6%   $ Uniform=�6k   5+      �� 5,      $
 Hand��6   #���   6'   $��2��6M   $�� ��6]   $��Center=�6   $	��Top=�6�   $��24��6�   $��24��6�   $��0,5,0,0q�6�   ��6h   Z� ��5-      �� 5.      $; 5/Alta_Media_Manager;component/Asset/Icon/del_icon.png��6%   $ Uniform=�6i   50      �� 51      $��Stretch=�6   $��1��6<   $��0��6L   .+�52      �� -   5        $ txt_alta_name��52       $
��Tên��67   $	��Top=�6B   $��0,10,0,0q�6Z   ���	#FFECECEC$
��Bold"�6�   $��14(�6�    � ToolTip 6�   ��  �� ElementName$ txt_alta_name�� �� Path$
 Text��� 53      -   5        $ txt_alta_url��53       $��Data/video01.avi��66   $	��Top=�6N   $��0,5,0,0q�6f   ���	#FFECECEC 6�   �� $ txt_alta_url��$
 Text��� 54      -   5        $ txt_alta_date��54       $��
12/09/2014��67   $	��Top=�6I   $��0,5,0,0q�6a   ���	#FFECECEC6t   55      �� 56      -   5         ��Name$ list_playlist��56      $
 Hand��64   $��1��6B   $��Stretch=�6S   $	��Top=�6q   $��65��6�   $��1��6�   58      �� 59      #���   6   $��2��6>   $��1��6N   $��Center=�6r   $��Bottom=�6�   $��24��6�   $��24��6�   $��0,0,0,5q�6�   ��6[   Z� ��5:      �� 5;      $; 5/Alta_Media_Manager;component/Asset/Icon/btn_link.png��6%   $ Uniform=�6i   5=      �� 5>      -   5        $ txt_link_more��5>      $
��more��63   $��Right=�6?   $	��Top=�6[   $��2��6s   $��1��6�   $
��Bold"�6�   #��� ��6�   $��	0,10,10,0q�6�   $
 Hand��6�   $��14��6  $��30��6  5@      5A      5B      5C      