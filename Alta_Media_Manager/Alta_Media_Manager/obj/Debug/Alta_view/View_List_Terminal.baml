   M S B A M L   `   `   `  ����M  IAlta_Media_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Alta_Media_Manager.PluginAlta_Media_Manager.Plugin  5      5    /Alta_Media_Manager.Alta_view.View_List_Terminal   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :plugin'clr-namespace:Alta_Media_Manager.Plugin     5      $��Verdana)�5   8     � 	Resources  5	         DevicesListTemplate � ColumnDefinitions  btn_tmp
 � Tag j� Stretch �� ImageSource��%�  &	        �� 5
   
   .R�5      � $	��390��6   $��45��6    5      �� 5      $	��49* �6'   �� 5      $
��293* �6'   �� 5      $	��48* �6'   .+�5      �� $��Stretch=�6   $��Stretch=�67   $��0��6S   $K��E/Alta_Media_Manager;component/Asset/Alta_Avatar/av_playlist_small.png��6c   �� 5      $��Center=�67   $��Stretch=�6R   $��1��6p   $��16(�6�   $
��10,0q�6�   ��6   �� *	alta_name+6�   �� 5      -   5        $��2��5   1   $��Stretch=�6A   $��Stretch=�6_   #���  6�   $��32��6�    6   �� *	alta_id+��6{   Z� ��5      �� 5      $ Uniform=�6%   $D >/Alta_Media_Manager;component/Asset/Alta_Btn/ic_action_new.png��67   5      5      5      5      .��5      �� -   5         ��Name$ 
mainLayout��5      $
��1346��6!   $	��663��6.   ���	#7F000000.+�5   
   �� -   5         ��Name$ MainView��5      $	��400��6#   $	��500��6/   
 �� Top$ 50��6<    �� Left$	 473��6L   
���   �$��1q�6r   
�������._�5      � 	 � RowDefinitions	 5      �� 5      $	��42* �6$   �� 5       $	��55* �6$   �� 5!      $
��401* �6$   .+�5#      �� 
���   �$��0q�6-   $��Stretch=�6A   $��Stretch=�6`   
���   �._�5$      �� 
 �� TextAlignment$
 Center=�6    
�������$��18(�6J   $��Màn hình chiếu��6X   $��Center=�6n   $
��Bold"�6�   6�   5%      �� 5&      $��Tìm kiếm:��6   $
��Left=�6,   $��
10,16,0,15q�6G   $��1��6[   $��Center=�6h   $��24��6�   $��71��6�   3   -Alta_Media_Manager.Plugin.AutoCompleteTextBox  5(      -   5          Name$ 
txt_Search��5(   -   3   -Alta_Media_Manager.Plugin.AutoCompleteTextBox   Compled$ Search_Completed��6�   $
��Left=�6A   $��28��6\   $��85,0,0,0q�6h   $��1��6z   $��Center=�6�   $	��285��6�      	DelayTime$	 500��6�      	Threshold$ 3��6�      
AutoSearch . 6�   �� 5)      -   5         ��Name$ lb_data��5)   W     MetroListBoxItemStyle#���  6   #���   6h   $��2��6�   $
��Auto=�6�   $��Hidden=�6�   5*      5+      �� 5,   
   -   5        $�� ��5,      #���  6   $	 858��6A   $ 32��6S   $��28��6c   $��28��6n   $��0q�6�   ��6z   Z� ��5-      �� 5.      $ Uniform=�6   $D >/Alta_Media_Manager;component/Asset/Alta_Btn/btn_close_box.png��6/   50      �� 51   
   -   5        $ DateChooseView��51      $y�Visible=�6)   $	��350��6>   $	��180��6J   
���   �
�������$��1q�6~   $	 499��6�   $	 150��6�   ._�52      �  53      �� 54      $
��130* �6'   �� 55      $
��260* �6'   	 57      �� 58      $	��19* �6$   �� 59      $	��30* �6$   �� 5:      $	��30* �6$   �� 5;      $	��20* �6$   .+�5=      �� $��0��6   
���   �$��2��69   ._�5>      �� $��Center=�6    $��16(�6;   $
��Bold"�6I   
�������$
 Center=�6n   $��Stretch=�6�   $��Chọn Ngày phát��6�   5?      �� 5@      -   5        $��217,-10,-13,10q�5@      #���  61   $��1��6m   $��28��6}   $��28��6�   ��5A      �� 5B      $ Uniform=�6%   $D >/Alta_Media_Manager;component/Asset/Alta_Btn/btn_close_box.png��67   5D      �� 5E      $��Ngày phát:��6   $��24��6-   $
��Left=�69   $
��10,0q�6T   $��1��6b   $��Center=�6o   $	��100��6�   �� 5F      $��Ngày kết thúc:��6   $��26��61   $
��Left=�6=   $
��10,0q�6X   $��2��6f   $��Center=�6s   $	��100��6�   *   $Alta_Media_Manager.Plugin.dateChoose  5G      -	   5          Name$ txt_date_start��5G   $   $
��Left=�6=   $��24��6X   $��
10,18,0,18q�6d   $��1��6x   $��Center=�6�   $	��200��6�   $��1��6�     5H      -
   5        $ txt_date_end��5H   $   $
��Left=�6:   $��26��6U   $��
10,20,0,20q�6a   $��2��6u      Text$ 
dd/mm/yyyy��6�   $��Center=�6�   $	��200��6�   $��1��6�   � 5I      $��3��6   $��0��6$   $��2��64   .+�5J      �� -   5         � Cursor$
 Hand��5J      $��Right=�6+   $��Center=�6G   $
��20,0q�6b   $
��Lưu��6p   $	 768��6~   $	 318��6�   $��60��6�   $��26��6�   6�   5K      5L      5N      5P      5Q      