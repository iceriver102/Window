   M S B A M L   `   `   `  ���� M  IAlta_Media_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Alta_Media_Manager.PluginAlta_Media_Manager.Plugin  2    ,Alta_Media_Manager.Alta_view.View_list_media   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     :plugin'clr-namespace:Alta_Media_Manager.Plugin     $��Verdana)�  � 	Resources     VideoListTemplate � ColumnDefinitions  btn_tmp
 � Tag j� Stretch �� ImageSource  CameraListTemplate��%�  &	        &	 �    �� .R�� $	��390��$��45�� �� $	��49* ��� $
��293* ��� $	��48* �.+��� $��Stretch=�$��Stretch=�$��0������ *	imgSource+�� $��Center=�$��Stretch=�$��1��$��16(�$
��10,0q����� *	alta_name+�� -   $��2��$��Stretch=�$��Stretch=�#���  $��32�� �� *	alta_id+��Z� ���� $ Uniform=�$D >/Alta_Media_Manager;component/Asset/Alta_Btn/ic_action_new.png���� .R�� $	��390��$��45�� �� $	��49* ��� $
��293* ��� $	��48* �.+��� $��Stretch=�$��Stretch=�$��0��$I��C/Alta_Media_Manager;component/Asset/Alta_Avatar/av_camera_small.png���� $��Center=�$��Stretch=�$��1��$��16(�$
��10,0q����� *	alta_name+�� -   $��2��$��Stretch=�$��Stretch=�#���  $��32�� �� *	alta_id+��Z� ���� $ Uniform=�$D >/Alta_Media_Manager;component/Asset/Alta_Btn/ic_action_new.png��.���� -    ��Name$ 
mainLayout��$
��1346��$	��663��.+��� $
��1046��$	��500��
 �� Top$ 50�� �� Left$	 150��
���   �$��1q�
�������._��  � RowDefinitions �� $	��42* ��� $	��55* ��� $
��355* ��� $	��46* �.+��� 
���   �$��0q�$��Stretch=�$��Stretch=�
���   �._��� 	 �� TextAlignment$	 Center=�
�������$��18(�$��Video và Camera��$��Center=�$
��Bold"��� $��Tìm kiếm:��$
��Left=�$��
10,16,0,15q�$��1��$��Center=�$��24��$��71��1   +Alta_Media_Manager.Plugin.AutoCompleteMedia  -   
  Name$
 
txt_Search��1   +Alta_Media_Manager.Plugin.AutoCompleteMedia   Compled$ Search_Completed��   
ReLoadData$ ReLoad_Data��$
��Left=�$��28��$��
85,14,0,13q�$��1��$��Center=�$	��285��   	DelayTime$	 800��   	Threshold$ 3��   
AutoSearch . �� -    ��Name$ lb_data��$��2��$
��Auto=�$��Hidden=�   �� 
TargetType �� Property �� Value��%?   '��       �� " ��.���  � �� .  ��  � |� .  ���� .R�� ���� * (FrameworkElement.ActualWidth)+ �� RelativeSource ��  �� AncestorType$ ScrollContentPresenterL� � 	ItemWidth �� *(ListView.View).ItemWidth+ �� $ ListViewL����� *	ItemWidth+ �� *Self+ � 
ItemHeight �� *(ListView.View).ItemHeight+ �� $ ListViewL����� " ��.���  � ��$ 0q���  � ��$ 8q���  � ��$ 0q��� -   $�� ��#���  $��32��$��32��$��1��$��Right=�$��Center=�$��
0,12,10,11q�$��0q���Z� ���� $ Uniform=�$H B/Alta_Media_Manager;component/Asset/Alta_Btn/ic_action_refresh.png���� -    ��Name$ 	btnAction��$
��Lưu�� � Cursor$
 Hand��$
��Left=�$��	944,0,0,0q�$��3��$��Center=�$��75���� -   $�� ��#���  $
 1178��$ 36��$��28��$��28��$��0q���Z� ���� $ Uniform=�$D >/Alta_Media_Manager;component/Asset/Alta_Btn/btn_close_box.png��