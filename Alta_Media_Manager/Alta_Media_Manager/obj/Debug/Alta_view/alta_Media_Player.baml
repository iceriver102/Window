   M S B A M L   `   `   `  ����U  QVlc.DotNet.Wpf, Version=1.2.0.0, Culture=neutral, PublicKeyToken=84529da31f4eb963G4clr-namespace:Vlc.DotNet.Wpf;assembly=Vlc.DotNet.WpfVlc.DotNet.Wpf  5      M IAlta_Media_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Alta_Media_Manager.PluginAlta_Media_Manager.Plugin 5      4   .Alta_Media_Manager.Alta_view.alta_Media_Player   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      DWpf4clr-namespace:Vlc.DotNet.Wpf;assembly=Vlc.DotNet.Wpf     5      :plugin'clr-namespace:Alta_Media_Manager.Plugin     5      $��Verdana)�5	   8   .��5
      � -   5        $��Stretch=�5
      $��Stretch=�6)   
������ .+�5   
   �� ���	#CCA4A3A3$	��670��6(   $
��1340��68   $	��600��6H   $
��1067��6U   
�������$��2q�6v     �� CornerRadius$  3��6�   $��Center=�6�   $	��top=�6�   ._�5      � $	��670��6   $
��1340��6#    � RowDefinitions 5      �� 5      $��33 �6$   �� 5      $
��490* �6$   �� 5      $	��75* �6$   .+�5         Vlc.DotNet.Wpf.VlcControl  -   5          Name$ myVlcControl��5   !   �� 5      -   5         ��Name$ imgVideo��5   G   $��0��6   $��0��6(   $��3��66   $��0q�6�   ��6Y   �� *VideoSource+ �� ElementName$ myVlcControl��6�   � 5      -   5         �Name$ Title_Layout��5      $��Stretch=�6.   $��Stretch=�6L   $��0q�6h   $��0��6s    � ColumnDefinitions 5      �� 5      $
��342* �6+   �� 5      $	��13* �6+   .+�5      �� -   5         ��Name$ txt_alta_media_name��5       $��Stretch=�6=   $
��Wrap=�6\   $��	22,6,10,5q�6p   $��	Tên file��6�   $��Stretch=�6�   
�������$��18(�6�   $��0��6�   5      � 5      -   5        $ ControlPlayer_Layout��5      $��Stretch=�65   $��0��6S   $��2��6d   $��Stretch=�6q   
���   � 5      �� 5      $��13 �6(   �� 5       $��62 �6(    5"      �� 5#      $��1* �6+   �� 5$      $��1* �6+   �� 5%      $��1* �6+   .+�5'      � -   5         �Name$ barTimeSeek��5'   "   $��0��67   $��3��6G   $��0��6[   $��Stretch=�6i   $	��Top=�6�   $��6��6�   
�������$
��30,0q�6�   ���	#FFF48120	 � Cursor$
	 Hand��6w  �� 5(      -   5        
 ��Name$
 btn_play��5(      $�� ��6/      btn_tmp#���   6:   $��Center=�6_   $��Center=�6|   $��24��6�   $��1��6�   $��24��6�   $��1��6�   ��6�   Z� ��5)      �� 5*       j� Stretch$ Uniform=�6)    �� ImageSource$= 7/Alta_Media_Manager;component/Asset/Images/btn_play.png��6;   5,      �� 5-      -	   5        $�� ��5-      #���   6(   $��Center=�6M   $��Center=�6h   $��210,0,100,0q�6�   $��1��6�   $��24��6�   $��24��6�   $��1��6�   ��6�   Z� ��5.      �� 5/      $ Uniform=�6)   $= 7/Alta_Media_Manager;component/Asset/Images/btn_next.png��6;   51      �� 52      -
   5        $�� ��52      #���   6(   $��1��6M   $��Center=�6]   $��24��6z   $��1��6�   $��Center=�6�   $��24��6�   $��100,0,210,0q�6�   ��6�   Z� ��53      �� 54      $ Uniform=�6)   $= 7/Alta_Media_Manager;component/Asset/Images/btn_back.png��6;   56      �� 58      -   5        $y�Hidden=�58      $��Center=�61   #���   6N   $��24��6s   $��24��6   $��0q�6�   $��Center=�6�   $��1��6�   $��
29,0,294,0q�6�   $��1��6�   ��6�   Z� ��6  Z� ��59      �� 5:      $= 7/Alta_Media_Manager;component/Asset/Images/btn_open.png��6)   $ Uniform=�6o   5<      �� 5=      -   5        $��1��5=      #���   6.   $��22��6S   $��22��6_   $��1��6j   $��
294,0,29,0q�6�   ��6w   Z� ��5>      �� 5?      $= 7/Alta_Media_Manager;component/Asset/Images/btn_stop.png��6)   $ Uniform=�6o   5A      �� 5B      -   5        $ alta_txt_curTime��5B       $��2��6:   $��Center=�6J   $��
10,0,200,0q�6g   $��1��6{   $
��Wrap=�6�   $��00:00:00��6�   $��Center=�6�   ���	#FFE8E5E56�   �� 5C       �� Orientation$ 
Horizontal=�6!   $��1��6:   $
��25,0q�6G   .+�5E      �� -   5        $
 btn_mute��5E   !   $�� ��63   $
��Left=�6>   $��0q�6Y   $��1��6d   $��Center=�6q   $��32��6�   $��32��6�   #���   6�   ��6�   Z� ��5G      �� 5H   "   $: 4/Alta_Media_Manager;component/Asset/Images/sound.png��6-   $ Uniform=�6p   5J      �� 5K      -   5         ��Name$ alta_volume��5K   !   $
��Left=�68   $��0q�6S   $��Center=�6_   $	��100��6z   ���	#00000000 � Maximum$	 100Q�6�    � Minimum$ 0Q�6�    � Value$	 100Q�6�   5M      5N      �� 5O      -   5        $
 
btn_status��5O      #���   61   $��2��6V   $��Right=�6f   $
��10,0q�6�   $��22��6�   $��1��6�   $��Center=�6�   $��27��6�   $��0q�6�   ��6�   Z� ��5P      �� 5Q      $ Uniform=�6)   $B </Alta_Media_Manager;component/Asset/Alta_icon/icon-duyet.png��6;   5S      5T      �� 5U      -   5         ��Name$ demoTxt��5U   .   $y�Hidden=�6   $
��Left=�6?   $��23��6Z   $��
10,457,0,0q�6f   $��1��6z    �� TextWrapping$
 Wrap=�6�   $��TextBox��6�   $	��Top=�6�   $	��789��6�   ,  &Alta_Media_Manager.Plugin.ftp_download  5V      -   5          Name$ ftp_download��5V   :   ,  &Alta_Media_Manager.Plugin.ftp_download   	Completed$ Download_Completed��6[      StartDownload$ Start_DownLoad��6�   $y�Hidden=�6&   $��5��6P   $��	0,0,0,480q�6z   $��1��6�   6�   5W      5X      �� 5Y   
   -   5        #���   5Y      $
��Left=�66   $��1187,-10,0,0q�6Q   $	��Top=�6g   $��32��6   $��32��6�   ��5Z      �� 5[      $ Uniform=�6   $D >/Alta_Media_Manager;component/Asset/Alta_Btn/btn_close_box.png��6/   5]      5^      5_      