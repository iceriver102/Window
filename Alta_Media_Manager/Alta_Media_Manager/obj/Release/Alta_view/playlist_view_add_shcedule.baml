   M S B A M L   `   `   `  ����   Alta_Media_Manager=    7Alta_Media_Manager.Alta_view.playlist_view_add_shcedule   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     $��Verdana)�.���� -     ��Name$  
mainlayout��$
��1346��$	��663�����	#7f000000.+��� -    ��Name$ layoutContent��$	��400��$	��220��$��1q� �� Left$	 473��
 �� Top$	 221��
�������._��  � ColumnDefinitions �� $	��51* ��� $
��148* � � RowDefinitions �� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* �.+��� 
���   �$��2��._��� -    ��Name$ title��$��Tạo lịch phát��
�������$��Center=�$��Center=�$��20(��� -   $��279,-12,-11,28q�$��1��$��28��$��28��   btn_tmp#���   ��Z� ����  j� Stretch$ Uniform=� �� ImageSource$D >/Alta_Media_Manager;component/Asset/Alta_Btn/btn_close_box.png���� $��Media:��$��0��$��1��$��Center=�$��Right=��� -   	 ��Name$	 txt_name��$��	10,0,70,0q�$	��0,6q�$��1��$��Stretch=�$��1��
 �� TextWrapping$

 Wrap=�$�� ��$��Center=�$��30���� $��Giờ bắt đầu:��$��0��$��2��$��Center=�$��Right=��� -   $	 
hour_start��$��
10,0,252,0q� �� TextAlignment$ Center=�$	��0,5q�$��1��$��Stretch=�$��28��$��2��$

 Wrap=�$�� ��$��Center=��� $��:��$��1��$��2��$��Center=�$��42,7,0,7q�$��Center=�$
��Left=�$��25��$��15���� -   $	 minute_start��$��
55,0,208,0q�$ Center=�$	��0,5q�$��1��$��Stretch=�$��2��$

 Wrap=�$�� ��$��Center=�$��28���� $��Giờ kết thúc:��$��0��$��3��$��Center=�$��Right=��� -   $	 hour_end��$��
10,0,252,0q�$ Center=�$	��0,5q�$��1��$��Stretch=�$��28��$��3��$

 Wrap=�$�� ��$��Center=��� $��:��$��1��$��3��$��Center=�$��42,7,0,7q�$��Center=�$
��Left=�$��26��$��15���� -	   $	 
minute_end��$��
55,0,208,0q�$ Center=�$	��0,5q�$��1��$��Stretch=�$��28��$��3��$

 Wrap=�$�� ��$��Center=��� -
   $ 
bar_action��$y�Hidden=�$��4��$��2��
���   �$��0,1,0,0q�._�� $��0�� �� $��1* ��� $��1* �.+��� -   $
��Lưu��$��70��  btnTmplNormal#���  
�������$��30��$��1������ $ Uniform=�$A ;/Alta_Media_Manager;component/Asset/Alta_Btn/btn_normal.png���� -   $��0��$
��Xóa��$��70��#���  
�������$��30������ $ Uniform=�$A ;/Alta_Media_Manager;component/Asset/Alta_Btn/btn_normal.png���� -   $ bar_action_new��$��4��$��2��
���   �$��0,1,0,0q�._�� .+��� -   $
��Lưu��$��70��#���  
�������$��30��$��1������ $ Uniform=�$A ;/Alta_Media_Manager;component/Asset/Alta_Btn/btn_normal.png���� -   $��chọn��$��1��$��30��$��Right=�$��1��$��Center=�$��50��$
��10,0q�#���   