   M S B A M L   `   `   `  ���� M  IAlta_Media_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Alta_Media_Manager.PluginAlta_Media_Manager.Plugin  1    +Alta_Media_Manager.Alta_view.View_list_user   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     :plugin'clr-namespace:Alta_Media_Manager.Plugin     $��Verdana)�.���� -     ��Name$  
mainLayout��$
��1346��$	��663�����	#7F000000.+��� -    ��Name$ layoutContent��$
��1046��$	��500��
 �� Top$ 50�� �� Left$	 150��
���   �$��1q�
�������._��  � RowDefinitions �� $	��42* ��� $	��55* ��� $
��384* ��� $	��17* �.+��� 
���   �$��0q�$��Stretch=�$��Stretch=�
���   �._���  �� TextAlignment$ Center=�
�������$��18(�$
��User��$��Center=�$
��Bold"��� $��Tìm kiếm:��$
��Left=�$��
10,16,0,15q�$��1��$��Center=�$��24��$��71��0   *Alta_Media_Manager.Plugin.AutoCompleteUser  -     Name$ 
txt_Search��0   *Alta_Media_Manager.Plugin.AutoCompleteUser   Compled$ Search_Completed��   
ReLoadData$ ReLoad_Data��$
��Left=�$��28��$��
85,14,0,13q�$��1��$��Center=�$	��285��	   	DelayTime$		 800��
   	Threshold$
 3��   
AutoSearch . �� -    ��Name$ lb_data��$��2��$
��Auto=�$��Hidden=� � 	Resources  �� 
TargetType �� Property �� Value��%?   '��       �� " ��.���  � �� .  ��  � |� .  ���� .R�� ���� * (FrameworkElement.ActualWidth)+ �� RelativeSource ��  �� AncestorType$ ScrollContentPresenterL� � 	ItemWidth �� *(ListView.View).ItemWidth+ �� $ ListViewL����� *	ItemWidth+ �� *Self+ � 
ItemHeight �� *(ListView.View).ItemHeight+ �� $ ListViewL����� " ��.���  � ��$ 0q���  � ��$ 8q���  � ��$ 0q��� -   $�� ��   btn_tmp#���   $��32��$��32��$��1��$��Right=�$��Center=�$��
0,12,10,11q�$��0q���Z� ����  j� Stretch$ Uniform=� �� ImageSource$H B/Alta_Media_Manager;component/Asset/Alta_Btn/ic_action_refresh.png���� -   $�� ��#���   $��28��$��28��$��0q�$��1029,-13,-13,27q���Z� ���� $ Uniform=�$D >/Alta_Media_Manager;component/Asset/Alta_Btn/btn_close_box.png��