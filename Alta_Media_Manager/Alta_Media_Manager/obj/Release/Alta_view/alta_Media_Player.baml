   M S B A M L   `   `   `  ���� U  QVlc.DotNet.Wpf, Version=1.2.0.0, Culture=neutral, PublicKeyToken=84529da31f4eb963G4clr-namespace:Vlc.DotNet.Wpf;assembly=Vlc.DotNet.WpfVlc.DotNet.Wpf  M IAlta_Media_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Alta_Media_Manager.PluginAlta_Media_Manager.Plugin 4   .Alta_Media_Manager.Alta_view.alta_Media_Player   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     DWpf4clr-namespace:Vlc.DotNet.Wpf;assembly=Vlc.DotNet.Wpf     :plugin'clr-namespace:Alta_Media_Manager.Plugin     $��Verdana)�.��� -   $��Stretch=�$��Stretch=�
������ .+��� ���	#CCA4A3A3$	��670��$
��1340��$	��600��$
��1067��
�������$��2q�  �� CornerRadius$  3��$��Center=�$	��top=�._�� $	��670��$
��1340�� � RowDefinitions �� $��33 ��� $
��490* ��� $	��75* �.+�   Vlc.DotNet.Wpf.VlcControl  -     Name$ myVlcControl���� -    ��Name$ imgVideo��$��0��$��0��$��3��$��0q����� *VideoSource+ �� ElementName$ myVlcControl��� -    �Name$ Title_Layout��$��Stretch=�$��Stretch=�$��0q�$��0�� � ColumnDefinitions �� $
��342* ��� $	��13* �.+��� -    ��Name$ txt_alta_media_name��$��Stretch=�$
��Wrap=�$��	22,6,10,5q�$��	Tên file��$��Stretch=�
�������$��18(�$��0��� -   $ ControlPlayer_Layout��$��Stretch=�$��0��$��2��$��Stretch=�
���   � �� $��13 ��� $��62 � �� $��1* ��� $��1* ��� $��1* �.+�� -    �Name$ barTimeSeek��$��0��$��3��$��0��$��Stretch=�$	��Top=�$��6��
�������$
��30,0q����	#FFF48120	 � Cursor$
	 Hand���� -   
 ��Name$
 btn_play��$�� ��   btn_tmp#���   $��Center=�$��Center=�$��24��$��1��$��24��$��1����Z� ����  j� Stretch$ Uniform=� �� ImageSource$= 7/Alta_Media_Manager;component/Asset/Images/btn_play.png���� -	   $�� ��#���   $��Center=�$��Center=�$��210,0,100,0q�$��1��$��24��$��24��$��1����Z� ���� $ Uniform=�$= 7/Alta_Media_Manager;component/Asset/Images/btn_next.png���� -
   $�� ��#���   $��1��$��Center=�$��24��$��1��$��Center=�$��24��$��100,0,210,0q���Z� ���� $ Uniform=�$= 7/Alta_Media_Manager;component/Asset/Images/btn_back.png���� -   $y�Hidden=�$��Center=�#���   $��24��$��24��$��0q�$��Center=�$��1��$��
29,0,294,0q�$��1����Z� ��Z� ���� $= 7/Alta_Media_Manager;component/Asset/Images/btn_open.png��$ Uniform=��� -   $��1��#���   $��22��$��22��$��1��$��
294,0,29,0q���Z� ���� $= 7/Alta_Media_Manager;component/Asset/Images/btn_stop.png��$ Uniform=��� -   $ alta_txt_curTime��$��2��$��Center=�$��
10,0,200,0q�$��1��$
��Wrap=�$��00:00:00��$��Center=����	#FFE8E5E5��  �� Orientation$ 
Horizontal=�$��1��$
��25,0q�.+��� -   $
 btn_mute��$�� ��$
��Left=�$��0q�$��1��$��Center=�$��32��$��32��#���   ��Z� ���� $: 4/Alta_Media_Manager;component/Asset/Images/sound.png��$ Uniform=��� -    ��Name$ alta_volume��$
��Left=�$��0q�$��Center=�$	��100�����	#00000000 � Maximum$	 100Q� � Minimum$ 0Q� � Value$	 100Q��� -   $
 
btn_status��#���   $��2��$��Right=�$
��10,0q�$��22��$��1��$��Center=�$��27��$��0q���Z� ���� $ Uniform=�$B </Alta_Media_Manager;component/Asset/Alta_icon/icon-duyet.png���� -    ��Name$ demoTxt��$y�Hidden=�$
��Left=�$��23��$��
10,457,0,0q�$��1�� �� TextWrapping$
 Wrap=�$��TextBox��$	��Top=�$	��789��,  &Alta_Media_Manager.Plugin.ftp_download  -     Name$ ftp_download��,  &Alta_Media_Manager.Plugin.ftp_download   	Completed$ Download_Completed��   StartDownload$ Start_DownLoad��$y�Hidden=�$��5��$��	0,0,0,480q�$��1���� -   #���   $
��Left=�$��1187,-10,0,0q�$	��Top=�$��32��$��32������ $ Uniform=�$D >/Alta_Media_Manager;component/Asset/Alta_Btn/btn_close_box.png��