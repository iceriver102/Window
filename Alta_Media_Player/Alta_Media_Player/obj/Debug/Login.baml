   M S B A M L   `   `   `  ����  Alta_Media_Player    Alta_Media_Player.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Login��5   	   $	��600��6   $
��1067��6$    � AllowsTransparency .  � WindowStyle$
 None=�6K   
�������$��Verdana)�6q    � 
ResizeMode$ CanResizeWithGrip=�6�    � WindowStartupLocation$ CenterScreen=�6�    � WindowState$ 	Maximized=�6�    � 	Resources 5         btnTmpl �� 
TargetType � Cursor  btnTmplClose��%�  &	        &	 �     �� 5   
   " ��6*   .R�5      �� $��border��6   $
 Hand��6#   $��0q�62   
������ #��z��6`   ._�5      �� $��Center=�6#   $��Center=�6@   5	      5
      �� 5   
   " ��6/   .R�5      �� $��border��6   $
 Hand��6#   $��0q�62   
������ #��z��6`   ._�5      �� $��Center=�6#   $��Center=�6@   5      5      5      .��5      �� -   5        	 ��Name$	 
mainLayout��5      $
��1390��6!   $	��782��6.   .+�5   
   �� $
��1390��6   $	��782��6   
 �� Left$
 0��6,   
 �� Top$ 0��6<   
�������$��1q�6^   ._�5      � $
��1390��6   $	��782��6    ��5      �� 5       �� ImageSource$  Asset/Images/bg_images.png��6!   .+�5      �� $��Center=�6   $	��128��65   $��	0,100,0,0q�6B   $	��Top=�6U   $	��130��6m   $��Asset/Images/logo.png��6y   �� 5      $��Center=�6   $��	0,228,0,0q�6:   $	��Top=�6M   $	��340��6e   $	��130��6q   .+�5      �� -   5         ��Name$ txt_msg��5       $��Stretch=�62   $	��0,5q�6P   $��1��6]   $
��Wrap=�6j   $�� ��6~   $	��Top=�6�   $��14(�6�   $��Italic$�6�   ���	#FFFD1C26$��20��6�   �� 5      -   5         ��Name$ txt_user��5      $��0q�60   $��10q�6D   $��15(�6Q   $��Stretch=�6_   $��40��6}    �� TextWrapping$ NoWrap=�6�   $�� ��6�   $	��Top=�6�   $
��23,0q�6�   ��6�   Z� .��6�   ��5      �� 5      $# Asset/Themes/txt_username.png��6)    j� Stretch$ Uniform=�6U   .��5   .   5      G� 5      -   5         G�Name$ txt_pass��5   "   $��16(�64   $��0q�6C   $��10q�6W   $��Stretch=�6d   $��40��6�   $��23,10q�6�   ��5       �� 5!      $ Uniform=�6)   $ Asset/Themes/txt_pass.png��6;   5#      5$      �� 5%      -   5        $
��Left=�5%      $��Login��65   $��0q�6E     btnTmplNormal#���  6Y   $��767,372,0,0q�6�   $	��Top=�6�   $��75��6�   $��30��6�   
���������6�   Z� ��5&      �� 5'      $ Uniform=�6%   $! Asset/Themes/btn_normal.png��67   5)      �� 5*      $��Center=�6   $
��0,10q�69   $
��Wrap=�6G   $��© Altamedia 2013��6[   $��18(�6s   $��Bottom=�6�   ���	#E5000000 J� Effect 5+      3  -System.Windows.Media.Effects.DropShadowEffect  5,         
BlurRadius$ 4Q�6+      Color$ 	#E5C1C1C1��6:      	Direction$	 340Q�6L      ShadowDepth$ 3Q�6\   5.      �� 5/      -   5         � ToolTip$ Close��5/      $��Right=�6)   $��12q�6E   $	��Top=�6Q   $��20��6i   $��20��6t   #���  6�   ��50      �� 51      $ Uniform=�6%   $' !Asset/Themes/ic_action_remove.png��67   53      54      55      56      57      