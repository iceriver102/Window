   M S B A M L   `   `   `  ���� U  QVlc.DotNet.Wpf, Version=1.2.0.0, Culture=neutral, PublicKeyToken=84529da31f4eb963G4clr-namespace:Vlc.DotNet.Wpf;assembly=Vlc.DotNet.WpfVlc.DotNet.Wpf  H DWebcamControl, Version=3.0.0.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:WebcamControl;assembly=WebcamControlWebcamControl  Alta_Media_Manager1   +Alta_Media_Manager.Alta_view.Streaming_view   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     DWpf4clr-namespace:Vlc.DotNet.Wpf;assembly=Vlc.DotNet.Wpf     Bcam2clr-namespace:WebcamControl;assembly=WebcamControl     $��Verdana)����	#7F000000  � 	Resources     DevicesListTemplate��%)   &	        �� .R��� ���� *Name+.���� $	��550��$	��680��
�������.+�� $	��680��$	��550�� � ColumnDefinitions �� $
��167* ��� $
��173* � � RowDefinitions �� $	��50* ��� $	��50* ��� $
��450* �.+��� $��Video Devices:��$
��Left=�$��
10,12,0,12q�$��Center=�$	��107��$��26���� -    ��Name$ cb_video��$��0��$��0��$
��Left=�$��117,14,0,10q�$��Center=�$	��195��$��26��#��[  �� $��Audio Devices:��$��1��$
��Left=�$��
10,14,0,14q�$��Center=�$	��106��$��22���� -   $ cb_audio��$��1��$��0��$
��Left=�$��120,12,0,12q�$��Center=�$	��215��$��26��#��[  �� -   $��Preview��$��0��$��1��$
��Left=�$��256,12,0,12q�$��Center=�$��75��$��26���� -   $��Start Streaming��$��1��$
��Left=�$��	2,12,0,12q�$��Center=�$	��105��$��26��$��1���� -   $��Stop Streaming��$��1��$��1��$
��Left=�$��111,12,0,12q�$��Center=�$	��105��$��26���� -   $��Run Background��$��1��$��1��$
��Left=�$��225,12,0,12q�$��Center=�$	��105��$��26��   Vlc.DotNet.Wpf.VlcControl  -     Name$ myVlcControl���� $��0��$��2��$��2��$��0q�
���   �$��0,1,0,1q����	#4C686868._��� -    ��Name$ imgVideo��$��0q�$��Stretch=�$��Stretch=����� *VideoSource+ �� ElementName$ myVlcControl���� -	   $�� �� �� Left$	 666��$��28��
 �� Top$	 -14��$��28��$��0q�  btn_tmp#���  ��Z� ���� 	 j� Stretch$	 Uniform=�
 �� ImageSource$D
 >/Alta_Media_Manager;component/Asset/Alta_Btn/btn_close_box.png��