   M S B A M L   `   `   `  ����M  IAlta_Media_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Alta_Media_Manager.Item_UCAlta_Media_Manager.Item_UC  5   	   $    Alta_Media_Manager.Window_Main   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   >	item_menu(clr-namespace:Alta_Media_Manager.Item_UC     5   	   -   5          � Title$  Media��5   	   $	��768��6   $
��1366��6$    � AllowsTransparency .  � WindowStyle$
 None=�6K    � 
ResizeMode$ 	CanResize=�6^    � WindowState$ 	Maximized=�6u   $��Verdana)�6�    � 	Resources 5         btnTmpl �� 
TargetType ��Name �� Padding��%�   &	        �� 5   
   " ��6*   .R�5	      �� $ border��6   $ 1,1,1,25q�6%   $��0q�68   
������ #��z��6f   ._�5
      �� $��Center=�6$   $��Center=�6A   5      5      5      .��5      �� -   5        	 ��Name$	 
layoutMain��5      $��Stretch=�6!   $	��768��6?   $��Stretch=�6L   $
��1366��6h   ���	#FFF5F5F4.+�5   
   �� -   5        $	 header_canvas��5      

 �� Top$	
 -80��6(   $
��1366��69   $	��159��6F   ��5      �� 5       �� ImageSource$" Asset/Alta_Btn/bg_header.png��6    j� Stretch$ Uniform=�6H   .+�5      *   $Alta_Media_Manager.Item_UC.Item_Menu  -   5          Name$
 item��5   �   *   $Alta_Media_Manager.Item_UC.Item_Menu   	ItemClick$ view_user_mana��6�      Text_display$
 User��6#   $y�Visible=�68      Source$B </Alta_Media_Manager;component/Asset/Alta_Items/item_User.png��6M   $��65��6�   $��70��6�    �� Left$	 387��6�   $
 70��6�   6�     5      -   5        $ item2��5   �   $ view_schedule_mana��6�   $ Lịch chiếu��6"   $y�Visible=�6<   $F @/Alta_Media_Manager;component/Asset/Alta_Items/item-calendar.png��6Q   $��65��6�   $��70��6�   $	 655��6�   $
 70��6�   6�     5      -   5        $ item3��5   �   $ View_thietbi_mana��6�   $ Thiết bị��6"   $y�Visible=�6:   $F @/Alta_Media_Manager;component/Asset/Alta_Items/item-terminal.png��6O   $��65��6�   $��70��6�   $	 476��6�   $
 70��6�   6�     5      -   5        $ item4��5   �   $ View_Plan_Mana��6�   $ Playlist��6"   $y�Visible=�6:   $F @/Alta_Media_Manager;component/Asset/Alta_Items/item-playlist.png��6O   $��65��6�   $��70��6�   $	 566��6�   $
 70��6�   6�     5      -   5        $ item5��5   �   $ View_video_mana��6�   $ Video��6"   $y�Visible=�67   $C =/Alta_Media_Manager;component/Asset/Alta_Items/item-video.png��6L   $��65��6�   $��70��6�   $	 748��6�   $
 70��6�   6�     5      -	   5        $ item6��5   �   $ View_camera_Mana��6�   $ Camera��6"   $y�Visible=�68   $C =/Alta_Media_Manager;component/Asset/Alta_Items/item-tvcap.png��6M   $��65��6�   $��70��6�   $	 828��6�   $
 70��6�   6�     5      -
   5        $ item7��5   �   $ View_Setting��6�   $ Setting��6"   $y�Visible=�69   $E ?/Alta_Media_Manager;component/Asset/Alta_Items/item_setting.png��6N   $��65��6�   $��70��6�   $	 930��6�   $
 70��6�   6�   5      �� 5   
   -   5        #���   5      $��0q�69   $y�Visible=�6M   $	��882��6c   }�.  � Cursor$
 Hand��6�   $��Center=�6�   $��Center=�6�   $��63��6�   $	 252��6�   ��6o   Z� ��5      �� 5      .+�5      �� $
��Menu��6    $��22(�6,   $��0,13,0,0q�6:    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5          
BlurRadius$ 10Q�6/      Color$ 	#FFDADADA��6?      ShadowDepth$ 0Q�6Q      Opacity$	 0.7Q�6a   5"      5#      ��5%      �� 5&      $! Asset/Alta_Btn/btn_menu.png��6   $ Uniform=�6G   5(      �� 5)   
   -   5        $	 layoutContent��5)      $	��663��6(   $ 10��65   $
 95��6F   $
��1346��6V   5+      5-      5.      