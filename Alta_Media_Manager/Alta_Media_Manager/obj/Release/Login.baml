   M S B A M L   `   `   `  ���� M  IAlta_Media_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Alta_Media_Manager.PluginAlta_Media_Manager.Plugin      Alta_Media_Manager.Login   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     :plugin'clr-namespace:Alta_Media_Manager.Plugin       � Title$  Login��$	��768��$
��1366�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowState$ 	Maximized=� � WindowStartupLocation$ CenterScreen=�$��Verdana)� � AllowsTransparency .  � 	Resources    btnTmpl �� 
TargetType � Cursor  btnTmplClose	 �� Triggers
 P� Property P� Value �� 
TargetName �� Property �� Value �� ImageSource �� Opacity��%`  &	        &	 f     �� " ��.R��� $��border��$
 Hand��$��0q�
������ #��z��._��� $��Center=�$��Center=��� " ��.R��� $��border��$
 Hand��$��0q�
������ #��z��._��� $��Center=�$��Center=�	 P� 
 �@J�IsMouseOver . . ��� $ border�� � �� �� $+ %Asset/Alta_Images/btn_close_hover.png��$	 0.6Q�.���� -    ��Name$ 
mainLayout��$
��1366��$	��768��.+�� $
��1366��$	��768�� �� Left$ 0��
 �� Top$ 0������ $% Asset/Alta_Images/bg_images.png��.+��� $��Center=�$	��128��$��-15,200,0,0q�$	��Top=�$	��130��$ ��Asset/Alta_Images/logo.png���� $��Center=�$��	0,310,0,0q�$	��Top=�$	��340��$	��130��.+��� -    ��Name$ txt_msg��$��Stretch=�$	��0,5q�$��1��$
��Wrap=�$�� ��$	��Top=�$��14(�$��Italic$����	#FFFD1C26$��20���� -    ��Name$ txt_user��$��0q�$��10q�$��15(�$��Stretch=�$��40�� �� TextWrapping$ NoWrap=�$�� ��$	��Top=�$
��23,0q���Z� .������ $( "Asset/Alta_Images/txt_username.png�� j� Stretch$ Uniform=�.��G� -    G�Name$ txt_pass��$��16(�$��0q�$��10q�$��Stretch=�$��40��$��23,10q����� $ Uniform=�$$ Asset/Alta_Images/txt_pass.png���� -   $
��Left=�$��Login��$��0q�  btnTmplNormal#���  $��758,445,0,0q�$	��Top=�$��75��$��30��
���������Z� ���� $ Uniform=�$# Asset/Alta_Btn/btn_normal.png���� $��Center=�$
��0,10q�$
��Wrap=�$��© Altamedia 2013��$��18(�$��Bottom=����	#E5000000 J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 4Q�   Color$ 	#E5C1C1C1��   	Direction$	 340Q�   ShadowDepth$ 3Q��� -    � ToolTip$ Close��$��Right=�$��12q�$	��Top=�$��20��$��20��#���  ���� $ Uniform=�$% Asset/Alta_Images/btn_close.png��