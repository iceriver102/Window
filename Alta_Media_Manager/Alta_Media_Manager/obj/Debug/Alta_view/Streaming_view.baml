   M S B A M L   `   `   `  ����U  QVlc.DotNet.Wpf, Version=1.2.0.0, Culture=neutral, PublicKeyToken=84529da31f4eb963G4clr-namespace:Vlc.DotNet.Wpf;assembly=Vlc.DotNet.WpfVlc.DotNet.Wpf  5      H DWebcamControl, Version=3.0.0.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:WebcamControl;assembly=WebcamControlWebcamControl 5       Alta_Media_Manager1   +Alta_Media_Manager.Alta_view.Streaming_view   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      DWpf4clr-namespace:Vlc.DotNet.Wpf;assembly=Vlc.DotNet.Wpf     5      Bcam2clr-namespace:WebcamControl;assembly=WebcamControl     5      $��Verdana)�5	   8   ���	#7F000000  � 	Resources  5
         DevicesListTemplate��%I   &	        �� 5   
   .R�5      �� ��6   �� *Name+5      5      .��5      �� $	��550��6   $	��680��6   
�������.+�5   
   � $	��680��6   $	��550��6    � ColumnDefinitions 5      �� 5      $
��167* �6#   �� 5      $
��173* �6#    � RowDefinitions 5      �� 5      $	��50* �6    �� 5      $	��50* �6    �� 5      $
��450* �6    .+�5      �� $��Video Devices:��6   $
��Left=�6-   $��
10,12,0,12q�6H   $��Center=�6\   $	��107��6w   $��26��6�   �� 5      -   5         ��Name$ cb_video��5      $��0��6)   $��0��69   $
��Left=�6F   $��117,14,0,10q�6a   $��Center=�6v   $	��195��6�   $��26��6�   #��[  6�   �� 5      $��Audio Devices:��6   $��1��6-   $
��Left=�6=   $��
10,14,0,14q�6X   $��Center=�6l   $	��106��6�   $��22��6�   �� 5      -   5        $ cb_audio��5      $��1��6)   $��0��6:   $
��Left=�6G   $��120,12,0,12q�6b   $��Center=�6w   $	��215��6�   $��26��6�   #��[  6�   �� 5      -   5        $��Preview��5      $��0��6'   $��1��67   $
��Left=�6D   $��256,12,0,12q�6_   $��Center=�6t   $��75��6�   $��26��6�   6�   �� 5      -   5        $��Start Streaming��5      $��1��6/   $
��Left=�6<   $��	2,12,0,12q�6W   $��Center=�6j   $	��105��6�   $��26��6�   $��1��6�   �� 5       -   5        $��Stop Streaming��5       $��1��6.   $��1��6;   $
��Left=�6K   $��111,12,0,12q�6f   $��Center=�6{   $	��105��6�   $��26��6�   6�   �� 5!      -   5        $��Run Background��5!      $��1��6.   $��1��6;   $
��Left=�6K   $��225,12,0,12q�6f   $��Center=�6{   $	��105��6�   $��26��6�   6�      Vlc.DotNet.Wpf.VlcControl  5#      -   5          Name$ myVlcControl��5#      �� 5$      $��0��6   $��2��6%   $��2��63   $��0q�6G   
���   �$��0,1,0,1q�6f   ���	#4C686868._�5%      �� -   5         ��Name$ imgVideo��5%      $��0q�6d   $��Stretch=�6o   $��Stretch=�6�   ��6+   �� *VideoSource+ �� ElementName$ myVlcControl��6�   5&      5(      �� 5)   
   -	   5        $�� ��5)       �� Left$	 666��6   $��28��6.   
 �� Top$	 -14��69   $��28��6J   $��0q�6m     btn_tmp#���  6�   ��6V   Z� ��5*      �� 5+      	 j� Stretch$	 Uniform=�6   
 �� ImageSource$D
 >/Alta_Media_Manager;component/Asset/Alta_Btn/btn_close_box.png��6/   5-      5.      5/      