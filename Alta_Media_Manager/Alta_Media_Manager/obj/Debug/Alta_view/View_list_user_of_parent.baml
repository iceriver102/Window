   M S B A M L   `   `   `  ����M  IAlta_Media_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Alta_Media_Manager.PluginAlta_Media_Manager.Plugin  5      ;    5Alta_Media_Manager.Alta_view.View_list_user_of_parent   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :plugin'clr-namespace:Alta_Media_Manager.Plugin     5      $��Verdana)�5   8   .��5	      �� -   5          ��Name$  
mainLayout��5	      $
��1346��6!   $	��663��6.   ���	#7F000000.+�5
   
   �� -   5         ��Name$ layoutContent��5
      $
��1046��6(   $	��500��65   
 �� Top$ 50��6B    �� Left$	 150��6R   
���   �$��1q�6x   
�������._�5      �  � RowDefinitions 5      �� 5      $	��42* �6$   �� 5      $	��55* �6$   �� 5      $
��384* �6$   �� 5      $	��17* �6$   .+�5      �� 
���   �$��0q�6-   $��Stretch=�6A   $��Stretch=�6`   
���   �._�5      ��  �� TextAlignment$ Center=�6    
�������$��18(�6J   $
��User��6X   $��Center=�6d   $
��Bold"�6   6�   5      �� 5      $��Tìm kiếm:��6   $
��Left=�6,   $��
10,16,0,15q�6G   $��1��6[   $��Center=�6h   $��24��6�   $��71��6�   0   *Alta_Media_Manager.Plugin.AutoCompleteUser  5      -   5          Name$ 
txt_Search��5   *   0   *Alta_Media_Manager.Plugin.AutoCompleteUser   Compled$ Search_Completed��6�      
ReLoadData$ ReLoad_Data��6�   $
��Left=�6>   $��28��6Y   $��
85,14,0,13q�6e   $��1��6y   $��Center=�6�   $	��285��6�   	   	DelayTime$		 800��6�   
   	Threshold$
 3��6�      
AutoSearch . 6�   �� 5      -   5         ��Name$ lb_data��5      $��2��6,   $
��Auto=�69   $��Hidden=�6i    � 	Resources 5       �� 
TargetType �� Property �� Value��%r   '��       �� 5      " ��6    .�5      ��  � �� .  6:   �� 5       � |� .  6:   5      5      ��5      �� 5       .R�5!      � ��6(   �� * (FrameworkElement.ActualWidth)+ �� RelativeSource ��  �� AncestorType$ ScrollContentPresenterL� � 	ItemWidth 5"      �� *(ListView.View).ItemWidth+ �� $ ListViewL���5#      �� *	ItemWidth+ �� *Self+ � 
ItemHeight 5$      �� *(ListView.View).ItemHeight+ �� $ ListViewL�5%      ��5'      �� 5(      " ��6    .�5)      ��  � ��$ 0q�6@   �� 5*       � ��$ 8q�67   �� 5+       � ��$ 0q�68   5,      5.      �� 5/      -   5        $�� ��5/         btn_tmp#���   6$   $��32��6J   $��32��6U   $��1��6a   $��Right=�6n   $��Center=�6�   $��
0,12,10,11q�6�   $��0q�6�   ��6�   Z� ��50      �� 51       j� Stretch$ Uniform=�6%    �� ImageSource$H B/Alta_Media_Manager;component/Asset/Alta_Btn/ic_action_refresh.png��67   53      �� 54      -   5        $�� ��54      #���   6$   $��28��6I   $��28��6T   $��0q�6w   $��1029,-13,-13,27q�6�   ��6`   Z� ��55      �� 56      $ Uniform=�6%   $D >/Alta_Media_Manager;component/Asset/Alta_Btn/btn_close_box.png��67   58      5:      5;      5=      5>      