   M S B A M L   `   `   `  ����   Alta_Media_Manager0    *Alta_Media_Manager.Alta_view.add_user_view   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     $��Verdana)�  � 	Resources     TypeUserListTemplate��%.   &	        �� .R��� ���� *	alta_name+.��� -   ���	#804F4F4F � RowDefinitions �� $	��15* ��� $
��200* ��� $	��15* �.+��� -   
������ $��1q�$��Center=�$	��450��$��0q�$��1��$��Center=�$	��400��._�� 
������� � ColumnDefinitions �� $	��91* ��� $
��305* � �� $	��30* ��� $	��38* ��� $	��38* ��� $	��38* ��� $	��38* ��� $	��38* ��� $	��38* ��� $	��20* ��� $	��38* �.+��� $��0��$��2��
������ $��0q�$��Stretch=�$��0q�$��Stretch=����	#FF040404._��� -    ��Name$ 	title_txt��$��Stretch=� �� TextAlignment$ Center=�$��0q�$��1��$
��Wrap=�$��
Thêm User��$��Center=�
�������$��16(�$
��Bold"� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 4Q�   	Direction$	 330Q�   Color$ 	#FFB83A00��	   Opacity$		 0.5Q�
   
BlurRadius$
 4Q��� $��Stretch=�$��	0,16,0,17q�$��1��$
��Wrap=�$��Tên:��$��Center=�$��16��$ Right=��� $��Stretch=�$��	0,17,0,15q�$��2��$
��Wrap=�$��	Username:��$��Center=�$��16��$ Right=��� $��Stretch=�$
��0,11q�$��3��$
��Wrap=�$��Mật khẩu:��$��Center=�$��16��$ Right=��� $��Stretch=�$��0,19.5q�$��4��$
��Wrap=�$��Email:��$��Center=�$��16��$ Right=��� $��Stretch=�$��0,19.5q�$��5��$
��Wrap=�$��Phone:��$��Center=�$��16��$ Right=��� $��Stretch=�$��0,19.5q�$��6��$
��Wrap=�$��Type:��$��Center=�$��16��$ Right=��� -    ��Name$ txt_name��$	��3,5q�$��1��$��Stretch=�$��30��$
��10,0q�$��1�� �� TextWrapping$ NoWrap=�$�� ��$��Center=��� -   $ txt_username��$	��3,5q�$��1��$��30��$��Stretch=�$
��10,0q�$��2��$��Center=�G� -    G�Name$ txt_pass��$	��3,5q�$��1��$��30��$��Stretch=�$
��10,0q�$��3��$��Center=��� -   $ 	txt_email��$	��3,5q�$��1��$��30��$��Stretch=�$
��10,0q�$��4��$��Center=��� -   $ 	txt_phone��$	��3,5q�$��1��$��30��$��Stretch=�$
��10,0q�$��5��$��Center=��� -	    ��Name$ cb_type_user��#���   $��1��$��6��$��30��$
��10,0q�� $��0��$��Stretch=�$��0q�$��8��$��Stretch=�$��2�� �� $��1* �.+��� -
    � Cursor$
 Hand��  btnTmplNormal#���  $
��Lưu��$��Center=�$��0q�$��Center=�$��76��$��29��
�������$��1������  j� Stretch$ Uniform=� �� ImageSource$A ;/Alta_Media_Manager;component/Asset/Alta_Btn/btn_normal.png���� -   $��0q�$
 Hand��$��Center=�$��859,49,459,500q�$��Center=�$��28��$��28��  btn_tmp#���  
�������$��1����Z� ���� $ Uniform=�$D >/Alta_Media_Manager;component/Asset/Alta_Btn/btn_close_box.png��