   M S B A M L   `   `   `  ����  Alta_Media_Manager/    )Alta_Media_Manager.Plugin.autoSearchMedia   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      a ]DevExpress.Xpf.Core.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      &   DevExpress.Xpf.Core.ThemeManager    	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$  DXStyle 5       � 	Resources 5
         MetroListBoxItemStyle �� 
TargetType �� Property �� Value �� RelativeSource �� AncestorLevel �� AncestorType J� SnapsToDevicePixels	 �� StrokeDashArray
 �� 
TargetType ��Name �� Padding �� ContentStringFormat �� ContentStringFormat �� Triggers ]� 
Conditions �� Property �� Value �� 
TargetName P� Property P� Value  MetroListBoxItemTemplate � ColumnDefinitions �� Path �� Mode��%-	  &	        &	     �� 5   
   " ��6.   .�5      ��  �@J�SnapsToDevicePixels . 64   �� 5       � ��$	 4,1q�6(   �� 5       � �� 6;   �� *HorizontalContentAlignment+ �� *FindAncestor+$ 1��" ���� 5       � �� 69   �� *VerticalContentAlignment+ �� *FindAncestor+$ 1��" ���� 5       � ��
 ���� 6+   �� 5       � ��
 ���� 6,   �� 5       � ��$ 1q�60   �� 5       �@�FocusVisualStyle 5      �� 5      .�5      ��  � �� 5      �� 5   "   .R�5   &   �� $��2q�60    . #��� ��6V   $��1��6�   $		 1 2R�6�   5   #   5      5      5      �� 5        � �� 5!      �� 5"      "
 ��6&   .R�5#      �� $ Bd��6!   #��z��6-   #��z��6Y   #��z��6�   # z��6�    . ._�5$      �� #��z��6/   #��z��6c   # z 6�   #��z��6�   # z 6  #��z��6B  5%       5&      ]� 5'       5(   "   �� 5)   &    �@J�IsMouseOver . 6G   �� 5*   &    �@��
IsSelected .  6F   ./�5,   "   �� $ Bd��6?    � �� �	#FFDED9D96O   �� 5-   "   $ Bd��6@    6P   Z�  � ���� 5.   "    � ��
 �   �6?   5/      ]� 50       51   "   �� 52   &    �@J�IsMouseOver .  6G   �� 53   &    �@��
IsSelected .  6F   ./�55   "   �� $ Bd��6?    6O   Z�  � ���� 56   "   $ Bd��6@    6P   Z�  � ���� 57   "    � ��
 �   �6?   58      ]� 59       5:   "   �� 5;   &    �@��
IsSelected . 6F   ./�5=   "   �� $ Bd��6?    � �� �	#FF3993DE6O   �� 5>   "   $ Bd��6@    6P   Z�  � ���� 5?   "    � ��
 �����6?   5@      P� 5A       � {� .  . �5B   "   �� $ Bd��6K   # � ��6[    � ��5C      5E      5G      5H      �� 5I   
   .R�5J      �  5K      �� 5L      $��40 �6'   �� 5M      $	��200 �6'   .+�5P      �� $��Uniform=�64   $��28��6F   $��28��6Q   ��6   �� $	 Img�6Q   �� 5Q      $��1��6   $��5q�6-   .+�5R      �� $��Segoe UI Light)�66   $��20(�6R   ��6    �� *Name+��5S      ��  �� $ ListBoxItemL�$ FindAncestor=�$ 
Foreground�5T      �� 5U      
������ $��0��6_   $��0��6i   ��6   �� *Id+��6I   Z� 6i   5V      5W      5X      .��5Y      �  5Z   
   �� 5\      $	��23* �6   �� 5]      $��7* �6    � RowDefinitions 5_   
   �� 5`      $	��15* �6   �� 5a      $	��85* �6   .+�5c   
   �� -   5         ��Name$ txt_key_search��5c      $��0��6*   $��24��6;   $	��5,0q�6G    �� TextWrapping$
 Wrap=�6T   $�� ��6h   $��Center=�6p   �� 5d   
   -   5         ��Name$ lisview��5d      #���   6$   #���  6b   $��0��6�   $��2��6�   $��0q�6�   $��1��6�   $��Stretch=�6�   5f      �� 5g   
    � Cursor$
 Hand��6   $
��Tìm��6   $��1��6-   $��Center=�6=   $��Center=�6[   $��25��6v   $��58��6�   5i      5j      