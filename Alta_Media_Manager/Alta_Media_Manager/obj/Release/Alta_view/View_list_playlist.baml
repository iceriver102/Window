   M S B A M L   `   `   `  ���� M  IAlta_Media_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Alta_Media_Manager.PluginAlta_Media_Manager.Plugin  5    /Alta_Media_Manager.Alta_view.View_list_playlist   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     :plugin'clr-namespace:Alta_Media_Manager.Plugin     $��Verdana)�  � 	Resources     DevicesListTemplate � ColumnDefinitions  btn_tmp
 � Tag j� Stretch �� ImageSource��%�  &	        �� .R�� $	��390��$��45�� �� $	��49* ��� $
��293* ��� $	��48* �.+��� $��Stretch=�$��Stretch=�$��0��$K��E/Alta_Media_Manager;component/Asset/Alta_Avatar/av_playlist_small.png���� $��Center=�$��Stretch=�$��1��$��16(�$
��10,0q����� *	alta_name+�� -   $��2��$��Stretch=�$��Stretch=�#���  $��32�� �� *	alta_id+��Z� ���� $ Uniform=�$D >/Alta_Media_Manager;component/Asset/Alta_Btn/ic_action_new.png��.���� -    ��Name$ 
mainLayout��$
��1346��$	��663��.+��� $	��400��$	��500��
 �� Top$ 50�� �� Left$	 473��
���   �$��1q�
�������._��  � RowDefinitions �� $	��42* ��� $	��55* ��� $
��401* �.+��� 
���   �$��0q�$��Stretch=�$��Stretch=�
���   �._��� 	 �� TextAlignment$	 Center=�
�������$��18(�$��Playlist��$��Center=�$
��Bold"��� $��Tìm kiếm:��$
��Left=�$��
10,16,0,15q�$��1��$��Center=�$��24��$��71��3   -Alta_Media_Manager.Plugin.AutoCompleteTextBox  -   
  Name$
 
txt_Search��3   -Alta_Media_Manager.Plugin.AutoCompleteTextBox   Compled$ Search_Completed��$
��Left=�$��28��$��85,0,0,0q�$��1��$��Center=�$	��285��   	DelayTime$	 500��   	Threshold$ 3��   
AutoSearch . �� -    ��Name$ lb_data��  MetroListBoxItemStyle#���  #���   $��2��$
��Auto=�$��Hidden=��� -   $�� ��#���  $	 858��$ 32��$��28��$��28��$��0q���Z� ���� $ Uniform=�$D >/Alta_Media_Manager;component/Asset/Alta_Btn/btn_close_box.png��