   M S B A M L   `   `   `  ����M  IAlta_Media_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Alta_Media_Manager.PluginAlta_Media_Manager.Plugin  5      2    ,Alta_Media_Manager.Alta_view.View_list_media   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :plugin'clr-namespace:Alta_Media_Manager.Plugin     5      $��Verdana)�5   9     � 	Resources  5	         VideoListTemplate � ColumnDefinitions  btn_tmp
 � Tag j� Stretch �� ImageSource  CameraListTemplate��%�  &	        &	 �    �� 5
   
   .R�5      � $	��390��6   $��45��6    5      �� 5      $	��49* �6'   �� 5      $
��293* �6'   �� 5      $	��48* �6'   .+�5      �� $��Stretch=�6   $��Stretch=�67   $��0��6S   ��6c   �� *	imgSource+�� 5      $��Center=�67   $��Stretch=�6R   $��1��6p   $��16(�6�   $
��10,0q�6�   ��6   �� *	alta_name+6�   �� 5      -   5        $��2��5   1   $��Stretch=�6A   $��Stretch=�6_   #���  6�   $��32��6�    6   �� *	alta_id+��6{   Z� ��5      �� 5      $ Uniform=�6%   $D >/Alta_Media_Manager;component/Asset/Alta_Btn/ic_action_new.png��67   5      5      5      �� 5   
   .R�5      � $	��390��6   $��45��6    5      �� 5      $	��49* �6'   �� 5      $
��293* �6'   �� 5      $	��48* �6'   .+�5!      �� $��Stretch=�6   $��Stretch=�67   $��0��6S   $I��C/Alta_Media_Manager;component/Asset/Alta_Avatar/av_camera_small.png��6c   �� 5"      $��Center=�67   $��Stretch=�6R   $��1��6p   $��16(�6�   $
��10,0q�6�   ��6   �� *	alta_name+6�   �� 5#      -   5        $��2��5#   1   $��Stretch=�6A   $��Stretch=�6_   #���  6�   $��32��6�    6   �� *	alta_id+��6{   Z� ��5$      �� 5%      $ Uniform=�6%   $D >/Alta_Media_Manager;component/Asset/Alta_Btn/ic_action_new.png��67   5'      5(      5)      5*      .��5+      �� -   5         ��Name$ 
mainLayout��5+      $
��1346��6!   $	��663��6.   .+�5,   
   �� $
��1046��6   $	��500��6   
 �� Top$ 50��6+    �� Left$	 150��6;   
���   �$��1q�6a   
�������._�5-      �  � RowDefinitions 5.      �� 5/      $	��42* �6$   �� 50      $	��55* �6$   �� 51      $
��355* �6$   �� 52      $	��46* �6$   .+�54      �� 
���   �$��0q�6-   $��Stretch=�6A   $��Stretch=�6`   
���   �._�55      �� 	 �� TextAlignment$	 Center=�6    
�������$��18(�6J   $��Video và Camera��6X   $��Center=�6o   $
��Bold"�6�   6�   56      �� 57      $��Tìm kiếm:��6   $
��Left=�6,   $��
10,16,0,15q�6G   $��1��6[   $��Center=�6h   $��24��6�   $��71��6�   1   +Alta_Media_Manager.Plugin.AutoCompleteMedia  59      -   5        
  Name$
 
txt_Search��59   +   1   +Alta_Media_Manager.Plugin.AutoCompleteMedia   Compled$ Search_Completed��6�      
ReLoadData$ ReLoad_Data��6�   $
��Left=�6?   $��28��6Z   $��
85,14,0,13q�6f   $��1��6z   $��Center=�6�   $	��285��6�      	DelayTime$	 800��6�      	Threshold$ 3��6�      
AutoSearch . 6   �� 5:      -   5         ��Name$ lb_data��5:      $��2��6,   $
��Auto=�69   $��Hidden=�6i     5;       �� 
TargetType �� Property �� Value��%r   '��       �� 5<      " ��6    .�5=      ��  � �� .  6:   �� 5>       � |� .  6:   5?      5@      ��5A      �� 5B      .R�5C      � ��6(   �� * (FrameworkElement.ActualWidth)+ �� RelativeSource ��  �� AncestorType$ ScrollContentPresenterL� � 	ItemWidth 5D      �� *(ListView.View).ItemWidth+ �� $ ListViewL���5E      �� *	ItemWidth+ �� *Self+ � 
ItemHeight 5F      �� *(ListView.View).ItemHeight+ �� $ ListViewL�5G      ��5I      �� 5J      " ��6    .�5K      ��  � ��$ 0q�6@   �� 5L       � ��$ 8q�67   �� 5M       � ��$ 0q�68   5N      5P      �� 5Q      -   5        $�� ��5Q      #���  6$   $��32��6J   $��32��6U   $��1��6a   $��Right=�6n   $��Center=�6�   $��
0,12,10,11q�6�   $��0q�6�   ��6�   Z� ��5R      �� 5S      $ Uniform=�6%   $H B/Alta_Media_Manager;component/Asset/Alta_Btn/ic_action_refresh.png��67   5U      �� 5V      -   5         ��Name$ 	btnAction��5V      $
��Lưu��6-    � Cursor$
 Hand��6;   $
��Left=�6I   $��	944,0,0,0q�6d   $��3��6w   $��Center=�6�   $��75��6�   6�   5W      5X      �� 5Y   
   -   5        $�� ��5Y      #���  6   $
 1178��6A   $ 36��6T   $��28��6d   $��28��6o   $��0q�6�   ��6{   Z� ��5Z      �� 5[      $ Uniform=�6   $D >/Alta_Media_Manager;component/Asset/Alta_Btn/btn_close_box.png��6/   5]      5^      5_      