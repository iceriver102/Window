   M S B A M L   `   `   `  ���� M  IAlta_Media_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Alta_Media_Manager.PluginAlta_Media_Manager.Plugin  >    8Alta_Media_Manager.Alta_view.admin_add_playlist_terminal   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     :plugin'clr-namespace:Alta_Media_Manager.Plugin     $��Verdana)�.���� -     ��Name$  
mainlayout��$
��1346��$	��663�����	#7f000000.+��� -    ��Name$ layoutContent��$	��400��$	��250��$��1q� �� Left$	 473��
 �� Top$	 221��
�������._��  � ColumnDefinitions �� $	��51* ��� $
��148* � � RowDefinitions �� $	��30* ��� $��0* ��� $	��45* ��� $	��37* ��� $	��37* ��� $	��33* �.+��� 
���   �$��2��._��� -    ��Name$ title��$%��Sửa lịch phát cho Playlist��
�������$��Center=�$��Center=�$��20(��� -   $��279,-14,-13,30q�$��1��   btn_tmp#���   $��30��$��30����Z� ����  j� Stretch$ Uniform=� �� ImageSource$D >/Alta_Media_Manager;component/Asset/Alta_Btn/btn_close_box.png���� $��Ngày bắt đầu:��$��0��$��3��$��Center=�$��Right=�*   $Alta_Media_Manager.Plugin.dateChoose  -   	  Name$	 
txtDateStd��$	��190��$
��Auto��$��1��$��3��$
��Left=�$��	10,10,0,9q��� $��Ngày kết thúc:��$��0��$��4��$��Center=�$��Right=�  -   $	 
txtDateEnd��$	��190��$
��Auto��$��1��$��4��$
��Left=�$��
10,10,0,10q��� -   $ 
bar_action��$y�Visible=�$��5��$��2��
���   �$��0,1,0,0q�._�� $��0�� �� $��1* ��� $��1* �.+��� -   $
��Lưu��$��70��  btnTmplNormal#���  
�������$��30��$��1������ $ Uniform=�$A ;/Alta_Media_Manager;component/Asset/Alta_Btn/btn_normal.png���� -	   $��0��$
��Xóa��$��70��#���  
�������$��30������ $ Uniform=�$A ;/Alta_Media_Manager;component/Asset/Alta_Btn/btn_normal.png���� -
   $ bar_action_new��$��5��$��2��
���   �$��0,1,0,0q�$y�Visible=�._�� .+��� -   $��1��$
��Lưu��$��70��#���  
�������$��30������ $ Uniform=�$A ;/Alta_Media_Manager;component/Asset/Alta_Btn/btn_normal.png���� $��Màn hình:��$��0��$��2��$��Center=�$��Right=��� -   
 ��Name$
 txt_name_terminal��$��	10,0,70,0q�$	��0,6q�$��1��$��Stretch=�$��2�� �� TextWrapping$
 Wrap=�$�� ��$��Center=�$��30���� -   $��chọn��$��1��$��30��$��Right=�$��2��$��Center=�$��50��$��0,0,10,0q�#���   