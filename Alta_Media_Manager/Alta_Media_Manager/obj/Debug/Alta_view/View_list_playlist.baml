   M S B A M L   `   `   `  ����M  IAlta_Media_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Alta_Media_Manager.PluginAlta_Media_Manager.Plugin  5      5    /Alta_Media_Manager.Alta_view.View_list_playlist   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :plugin'clr-namespace:Alta_Media_Manager.Plugin     5      $��Verdana)�5   8     � 	Resources  5	         DevicesListTemplate � ColumnDefinitions  btn_tmp
 � Tag j� Stretch �� ImageSource��%�  &	        �� 5
   
   .R�5      � $	��390��6   $��45��6    5      �� 5      $	��49* �6'   �� 5      $
��293* �6'   �� 5      $	��48* �6'   .+�5      �� $��Stretch=�6   $��Stretch=�67   $��0��6S   $K��E/Alta_Media_Manager;component/Asset/Alta_Avatar/av_playlist_small.png��6c   �� 5      $��Center=�67   $��Stretch=�6R   $��1��6p   $��16(�6�   $
��10,0q�6�   ��6   �� *	alta_name+6�   �� 5      -   5        $��2��5   1   $��Stretch=�6A   $��Stretch=�6_   #���  6�   $��32��6�    6   �� *	alta_id+��6{   Z� ��5      �� 5      $ Uniform=�6%   $D >/Alta_Media_Manager;component/Asset/Alta_Btn/ic_action_new.png��67   5      5      5      5      .��5      �� -   5         ��Name$ 
mainLayout��5      $
��1346��6!   $	��663��6.   .+�5   
   �� $	��400��6   $	��500��6   
 �� Top$ 50��6*    �� Left$	 473��6:   
���   �$��1q�6`   
�������._�5      �  � RowDefinitions 5      �� 5      $	��42* �6$   �� 5       $	��55* �6$   �� 5!      $
��401* �6$   .+�5#      �� 
���   �$��0q�6-   $��Stretch=�6A   $��Stretch=�6`   
���   �._�5$      �� 	 �� TextAlignment$	 Center=�6    
�������$��18(�6J   $��Playlist��6X   $��Center=�6h   $
��Bold"�6�   6�   5%      �� 5&      $��Tìm kiếm:��6   $
��Left=�6,   $��
10,16,0,15q�6G   $��1��6[   $��Center=�6h   $��24��6�   $��71��6�   3   -Alta_Media_Manager.Plugin.AutoCompleteTextBox  5(      -   5        
  Name$
 
txt_Search��5(   -   3   -Alta_Media_Manager.Plugin.AutoCompleteTextBox   Compled$ Search_Completed��6�   $
��Left=�6A   $��28��6\   $��85,0,0,0q�6h   $��1��6z   $��Center=�6�   $	��285��6�      	DelayTime$	 500��6�      	Threshold$ 3��6�      
AutoSearch . 6�   �� 5)      -   5         ��Name$ lb_data��5)   W     MetroListBoxItemStyle#���  6   #���   6h   $��2��6�   $
��Auto=�6�   $��Hidden=�6�   5*      5+      �� 5,   
   -   5        $�� ��5,      #���  6   $	 858��6A   $ 32��6S   $��28��6c   $��28��6n   $��0q�6�   ��6z   Z� ��5-      �� 5.      $ Uniform=�6   $D >/Alta_Media_Manager;component/Asset/Alta_Btn/btn_close_box.png��6/   50      51      52      