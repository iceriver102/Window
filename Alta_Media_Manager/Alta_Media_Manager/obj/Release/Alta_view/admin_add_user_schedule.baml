   M S B A M L   `   `   `  ���� M  IAlta_Media_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Alta_Media_Manager.PluginAlta_Media_Manager.Plugin  :    4Alta_Media_Manager.Alta_view.admin_add_user_schedule   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     :plugin'clr-namespace:Alta_Media_Manager.Plugin     $��Verdana)�.���� -     ��Name$  
mainlayout��$
��1346��$	��663�����	#7f000000.+��� -    ��Name$ layoutContent��$	��400��$	��300��$��1q� �� Left$	 473��
 �� Top$	 221��
�������._��  � ColumnDefinitions �� $	��51* ��� $
��148* � � RowDefinitions �� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* �.+��� 
���   �$��2��._��� -    ��Name$ title��$!��Tạo lịch phát cho User��
�������$��Center=�$��Center=�$��20(��� -   $��279,-12,-11,28q�$��1��$��28��$��28��   btn_tmp#���   ��Z� ����  j� Stretch$ Uniform=� �� ImageSource$D >/Alta_Media_Manager;component/Asset/Alta_Btn/btn_close_box.png���� $��User:��$��0��$��1��$��Center=�$��Right=��� -   	 ��Name$	 txt_name��$��	10,0,70,0q�$	��0,6q�$��1��$��Stretch=�$��1��
 �� TextWrapping$

 Wrap=�$�� ��$��Center=�$��30���� $��Ngày bắt đầu:��$��0��$��3��$��Center=�$��Right=�*   $Alta_Media_Manager.Plugin.dateChoose  -     Name$ 
txtDateStd��$	��190��$��30��$��1��$��3��$
��Left=�$
��10,0q��� $��Ngày kết thúc:��$��0��$��4��$��Center=�$��Right=�  -   $ 
txtDateEnd��$	��190��$��30��$��1��$��4��$
��Left=�$
��10,0q��� -   $ 
bar_action��$y�Visible=�$��5��$��2��
���   �$��0,1,0,0q�._�� $��0�� �� $��1* ��� $��1* �.+��� -	   $
��Lưu��$��70��  btnTmplNormal#���  
�������$��30��$��1������ $ Uniform=�$A ;/Alta_Media_Manager;component/Asset/Alta_Btn/btn_normal.png���� -
   $��0��$
��Xóa��$��70��#���  
�������$��30������ $ Uniform=�$A ;/Alta_Media_Manager;component/Asset/Alta_Btn/btn_normal.png���� -   $ bar_action_new��$��5��$��2��
���   �$��0,1,0,0q�$y�Hidden=�._�� .+��� -   $��1��$
��Lưu��$��70��#���  
�������$��30������ $ Uniform=�$A ;/Alta_Media_Manager;component/Asset/Alta_Btn/btn_normal.png���� -   $��chọn��$��1��$��30��$��Right=�$��1��$��Center=�$��50��$
��10,0q�#���   �� $��Màn hình:��$��0��$��2��$��Center=�$��Right=��� -   $	 txt_name_terminal��$��10,10,70,10q�$	��0,6q�$��1��$��Stretch=�$��2��$

 Wrap=�$�� ��$��Center=�$��30���� -   $��chọn��$��1��$��30��$��Right=�$��2��$��Center=�$��50��$��
0,10,10,10q�#���   