   M S B A M L   `   `   `  ����   Alta_Media_Manager4    .Alta_Media_Manager.Alta_view.alta_edit_manhinh   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     $��Verdana)�  � 	Resources     TypeTerminalListTemplate��%.   &	        �� .R��� ���� *	alta_name+.��� -   ���	#804F4F4F � RowDefinitions �� $	��15* ��� $
��200* ��� $	��15* �.+��� -   
������ $��1q�$��Center=�$	��500��$��0q�$��1��$��Center=�$	��400��._�� 
������� � ColumnDefinitions �� $	��91* ��� $
��305* � �� $	��39* ��� $	��47* ��� $	��46* ��� $	��46* ��� $	��46* ��� $	��46* ��� $	��37* ��� $	��86* ��� $	��46* ��� $��4* ��� $	��41* �.+��� $��0��$��2��
������ $��0q�$��Stretch=�$��0q�$��Stretch=����	#FF040404._��� -    ��Name$ 	title_txt��$��Stretch=� �� TextAlignment$ Center=�$��0q�$��1��$
��Wrap=�$!��Sửa Thông Tin Màn Hình��$��Center=�
�������$��16(�$
��Bold"� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 4Q�   	Direction$	 330Q�   Color$ 	#FFB83A00��	   Opacity$		 0.5Q�
   
BlurRadius$
 4Q��� $��Stretch=�$��	0,15,0,16q�$��1��$
��Wrap=�$��Tên:��$��Center=�$��16��$ Right=��� $��Stretch=�$��	0,16,0,14q�$��2��$
��Wrap=�$	��IP:��$��Center=�$��16��$ Right=��� $��Stretch=�$��	0,10,0,11q�$��6��$
��Wrap=�$��	Mô tả:��$��Center=�$��16��$ Right=��� -    ��Name$ txt_name��$	��3,5q�$��1��$��Stretch=�$��30��$��	10,9,10,8q�$��1�� �� TextWrapping$ NoWrap=�$�� ��$��Center=��� -   $ txt_file��$	��3,5q�$��1��$��30��$��Stretch=�$
��10,8q�$��2��$��Center=�G� -    G�Name$ txt_Pass��$	��3,5q�$��1��$��30��$��Stretch=�$��	10,9,10,7q�$��3��$��Center=��� $��Stretch=�$��0,16.5,0,14.5q�$��3��$
��Wrap=�$��Mật khẩu:��$��Center=�$��16��$ Right=�G� -   $ txt_Pass_retype��$	��3,5q�$��1��$��30��$��Stretch=�$��	10,9,10,7q�$��4��$��Center=��� -    ��Name$ cb_type_terminal��#���   $��1��$��5��$��Center=�$
��10,0q�$��27���� $��Stretch=�$��	0,16,0,14q�$��4��$
��Wrap=�$��Nhập lại:��$��Center=�$��16��$ Right=�G� -	   $ txt_Pass_Old��$	��3,5q�$��1��$��30��$��Stretch=�$��10,9.5,10,7.5q�$��8��$��Center=��� $��Stretch=�$��0,16.5,0,14.5q�$��8��$
��Wrap=�$��Mật khẩu cũ:��$��Center=�$��16��$ Right=��� -
   $ txt_content�� �� AcceptsReturn . $	��3,5q�$��1��$��Stretch=�$	��100��$��10q�$��6��$
 Wrap=�$�� ��$��Center=�$��2���� $��0��$��2��$��10��
���   �$��0,1,0,0q�._��  �� $��1* �.+��� -    � Cursor$
 Hand��  btnTmplNormal#���  $
��Lưu��$��Center=�$��0q�$��Center=�$��76��$��29��
�������$��1������  j� Stretch$ Uniform=� �� ImageSource$A ;/Alta_Media_Manager;component/Asset/Alta_Btn/btn_normal.png���� $��Stretch=�$��0,16.5,0,14.5q�$��5��$
��Wrap=�$��Loại:��$��Center=�$��16��$ Right=��� -   $��0q�$
 Hand��$��Center=�$��859,27,459,522q�$��Center=�$��28��$��28��  btn_tmp#���  
�������$��0��$��1����Z� ���� $ Uniform=�$D >/Alta_Media_Manager;component/Asset/Alta_Btn/btn_close_box.png��