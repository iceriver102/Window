   M S B A M L   `   `   `  ����M  IAlta_Media_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Alta_Media_Manager.PluginAlta_Media_Manager.Plugin  5   	       Alta_Media_Manager.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   :plugin'clr-namespace:Alta_Media_Manager.Plugin     5   	     � Title$  Login��5   	   $	��768��6   $
��1366��6$    � WindowStyle$
 None=�61    � 
ResizeMode$ NoResize=�6D    � WindowState$ 	Maximized=�6Z    � WindowStartupLocation$ CenterScreen=�6r   $��Verdana)�6�    � AllowsTransparency .  � 	Resources 5         btnTmpl �� 
TargetType � Cursor  btnTmplClose	 �� Triggers
 P� Property P� Value �� 
TargetName �� Property �� Value �� ImageSource �� Opacity��%N  &	        &	 �     �� 5   
   " ��6*   .R�5	      �� $��border��6   $
 Hand��6#   $��0q�62   
������ #��z��6`   ._�5
      �� $��Center=�6#   $��Center=�6@   5      5      �� 5   
   " ��6/   .R�5      �� $��border��6   $
 Hand��6#   $��0q�62   
������ #��z��6`   ._�5      �� $��Center=�6#   $��Center=�6@   5      	 5      P� 5      
 �@J�IsMouseOver . . �5      �� $ border��63    � �� 5      �� 5      $+ %Asset/Alta_Images/btn_close_hover.png��6)   $	 0.6Q�6]   5      5      5      5      .��5      �� -   5         ��Name$ 
mainLayout��5      $
��1366��6!   $	��768��6.   .+�5   
   � $
��1366��6   $	��768��6    �� Left$ 0��6)   
 �� Top$ 0��69   ��5      �� 5      $% Asset/Alta_Images/bg_images.png��6   .+�5!      �� $��Center=�6   $	��128��61   $��-15,200,0,0q�6>   $	��Top=�6S   $	��130��6k   $ ��Asset/Alta_Images/logo.png��6w   �� 5"      $��Center=�6   $��	0,310,0,0q�66   $	��Top=�6I   $	��340��6a   $	��130��6m   .+�5#      �� -   5         ��Name$ txt_msg��5#      $��Stretch=�6.   $	��0,5q�6L   $��1��6Y   $
��Wrap=�6f   $�� ��6z   $	��Top=�6�   $��14(�6�   $��Italic$�6�   ���	#FFFD1C26$��20��6�   �� 5$      -   5         ��Name$ txt_user��5$      $��0q�6,   $��10q�6@   $��15(�6M   $��Stretch=�6[   $��40��6y    �� TextWrapping$ NoWrap=�6�   $�� ��6�   $	��Top=�6�   $
��23,0q�6�   ��6�   Z� .��6�   ��5%      �� 5&      $( "Asset/Alta_Images/txt_username.png��6%    j� Stretch$ Uniform=�6V   .��5'   *   5(      G� 5)      -   5         G�Name$ txt_pass��5)      $��16(�60   $��0q�6?   $��10q�6S   $��Stretch=�6`   $��40��6~   $��23,10q�6�   ��5*      �� 5+      $ Uniform=�6%   $$ Asset/Alta_Images/txt_pass.png��67   5-      5.      �� 5/      -   5        $
��Left=�5/      $��Login��61   $��0q�6A     btnTmplNormal#���  6U   $��758,445,0,0q�6�   $	��Top=�6�   $��75��6�   $��30��6�   
���������6�   Z� ��50      �� 51      $ Uniform=�6!   $# Asset/Alta_Btn/btn_normal.png��63   53      �� 54      $��Center=�6   $
��0,10q�65   $
��Wrap=�6C   $��© Altamedia 2013��6W   $��18(�6o   $��Bottom=�6}   ���	#E5000000 J� Effect 55      3  -System.Windows.Media.Effects.DropShadowEffect  56         
BlurRadius$ 4Q�6'      Color$ 	#E5C1C1C1��66      	Direction$	 340Q�6H      ShadowDepth$ 3Q�6X   58      �� 59      -   5         � ToolTip$ Close��59      $��Right=�6%   $��12q�6A   $	��Top=�6M   $��20��6e   $��20��6p   #���  6|   ��5:      �� 5;      $ Uniform=�6!   $% Asset/Alta_Images/btn_close.png��63   5=      5@      5A      5B      