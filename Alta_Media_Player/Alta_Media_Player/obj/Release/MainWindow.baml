   M S B A M L   `   `   `  ���� U  QVlc.DotNet.Wpf, Version=1.2.0.0, Culture=neutral, PublicKeyToken=84529da31f4eb963G4clr-namespace:Vlc.DotNet.Wpf;assembly=Vlc.DotNet.WpfVlc.DotNet.Wpf   Alta_Media_Player"   Alta_Media_Player.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     DWpf4clr-namespace:Vlc.DotNet.Wpf;assembly=Vlc.DotNet.Wpf     -     � Title$  
MainWindow��$	��600��$
��1067�� � AllowsTransparency .  � WindowStyle$
 None=� � WindowState$ Normal=�
�������$��Verdana)� � 
ResizeMode$ CanResizeWithGrip=� � 	Resources    CustomThumbForSlider �� 
TargetType �� Property �� Value	 �� 
TargetType  MyCustomStyleForSlider
 � RowDefinitions m�Name m� Fill m� 	Placement ��Name �� CornerRadius ��Name ]�Name ]� DecreaseRepeatButton �� DecreaseLarge ]� IncreaseRepeatButton �� IncreaseLarge ]� Thumb n�Name  btnTmpl � Cursor��%5  &	        &	 �     &	 �    �� " n�.���  �@�OverridesDefaultStyle . ��  � �� �� "	 n�.R�A� ���	#FF8F4040���	#FF000000$��15��$��15���� " ��.���  � �� �� "	 ��.R��� #��z��#��z��#��z��._�� 
 �� $
��Auto ��� $
��Auto �#��z���� $
��Auto �.+�m� $ TopTick��$y�	Collapsed=�# z��$	 Top=�$��4��$��0��m� $ 
BottomTick��$y�	Collapsed=�# z��$ Bottom=�$��4��$��0���� $ TrackBackground��$��1q�$ 1��$	��5,0q�$��Center=�$	��5.0��$��1��._��� $��-6,-1q�.+��� $ PART_SelectionRange��$y�Hidden=�$	��5.0��#��� ��#��� ��$	��1.0��]� $ 
PART_Track��$��1�� �� #��Z  �� #��Z  n� $ Thumb��
���   ��� "	 ��.R��� $
 Hand��$��0q�
������ #��z��._��� $��Center=�$��Center=�.���� -    ��Name$ 
MainLayout��$	��782��$
��1390��.+��� ���	#CCA4A3A3
�������$��1q�$ 3��$	��782��$
��1390�� �� Left$ 0��
 �� Top$ 0��._�� 
 �� $��33 ��� $
��490* ��� $	��75* �.+�   Vlc.DotNet.Wpf.VlcControl  -     Name$ myVlcControl���� -    ��Name$ imgVideo��$��0��$��0��$��3��$��0q����� *VideoSource+ �� ElementName$ myVlcControl��� -    �Name$ Title_Layout��$��Stretch=�$��Stretch=�$��0q�$��0��  � ColumnDefinitions  �� $
��342* ��� $	��13* �.+��� -   ! ��Name$! txt_alta_media_name��$��Stretch=�$
��Wrap=�$��	22,6,10,5q�$��	Tên file��$��Stretch=�
�������$��18(�$��0���� -   $��0q�$��1��$��Right=�$��0,4,5,5q�#���  $��Center=�$��24��$��24����Z� ��Z� ���� " j� Stretch$" Uniform=�# �� ImageSource$!# Asset/Images/icon_close.png��� -   $ ControlPlayer_Layout��$��Stretch=�$��0��$��2��$��Stretch=�
 �� $��13 ��� $��62 �  �� $
��355* ��� $
��355* ��� $
��355* ����� $ �� EndPoint$$ 0.5,1&�% �� 
StartPoint$% 0.5,0&�.��� & � Color$& 	#CC636262��' � Offset$' 1Q�� .+�� -	   ( �Name$( barTimeSeek��$��0��$��3��$��0��$��Stretch=�$	��Top=�$��6��
���   �$
��30,0q�
�������$
 Hand���� -
   ) ��Name$) btn_play��$�� ��#���  $��Center=�$��Center=�$��32��$��1��$��32��$��1����Z� ���� $" Uniform=�$%# Asset/Themes/ic_action_play.png���� -   $�� ��#���  $��Center=�$��Center=�$��210,0,100,0q�$��1��$��24��$��24��$��1����Z� ���� $" Uniform=�$%# Asset/Themes/ic_action_next.png���� -   $�� ��#���  $��1��$��Center=�$��24��$��1��$��Center=�$��24��$��100,0,210,0q���Z� ���� $" Uniform=�$)# #Asset/Themes/ic_action_previous.png���� -   $��Center=�#���  $��24��$��24��$��0q�$��Center=�$��1��$��
29,0,294,0q�$��1����Z� ��Z� ���� $# Asset/Images/btn_open.png��$" Uniform=��� -   $��1��#���  $��32��$��32��$��1��$��
294,0,29,0q���Z� ���� $%# Asset/Themes/ic_action_stop.png��$" Uniform=��� -   $) btn_full_screen��$��Center=�$��Right=�$�� ��$��2��$��0,0,30,0q�$��22��$��22��$��1��#���  ��Z� ��Z� ���� $,# &Asset/Themes/ic_action_full_screen.png��$" Uniform=��� -   $! alta_txt_curTime��$��2��$��Center=�$��
10,0,200,0q�$��1��$
��Wrap=�$��00:00:00��$��Center=����	#FFE8E5E5�� * �� Orientation$* 
Horizontal=�$��1��$
��25,0q�.+��� -   $) btn_mute��$�� ��$
��Left=�$��0q�$��1��$��Center=�$��32��$��32��#���  ��Z� ���� $*# $Asset/Themes/ic_action_volume_on.png��$" Uniform=��� -   + ��Name$+ alta_volume��$
��Left=�$��0q�$��Center=�$	��100�����	#00000000, � Maximum$	, 100Q�- � Minimum$- 0Q�. � Value$	. 100Q��� -   / ��Name$/ demoTxt��$y�Hidden=�$
��Left=�$��23��$��
10,457,0,0q�$��1��0 �� TextWrapping$
0 Wrap=�$��TextBox��$	��Top=�$	��789���� -   1 ��Name$1 lb_count��$�� ��$
��Left=�$��	10,10,0,0q�$��1��$	��Top=�$	��161��