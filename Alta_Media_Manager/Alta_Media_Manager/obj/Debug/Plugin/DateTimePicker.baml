   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5       Alta_Media_Manager.   (Alta_Media_Manager.Plugin.DateTimePicker   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      a ]DevExpress.Xpf.Core.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      0sys&clr-namespace:System;assembly=mscorlib  5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      &   DevExpress.Xpf.Core.ThemeManager    	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$  DXStyle 5	      $��Arial)�5
      
������� � 	Resources 5         dt
 �� Now
 � Tag  	angleHour T� X �� Source T� Y u� Matrix  angleMinute  angleSecond �� ScaleX	 �� 
TargetType
 �� Property �� Value��%H  &	        &	      7   7   &	 �     7   7   &	 O    7   'F� �    � 5   
   # Z 6&   V� 5   
   .~�5      T�  5      �� *
Tag.Hour+8    5      �� *
Tag.Minute+8  u� 5      $ 30 0 0.5 1 0 0x�6   5      V� 5   
   .~�5       T�  5!      �� *
Tag.Minute+8    5"      �� *
Tag.Second+8  u� 5#      $ 6 0 0.1 1 0 0x�6   5$      V� 5(   
   .~�5)      ��  5*      �� *
Tag.Second+8   �� 5+      $ 6Q�6   5,      �� 50   
   "	 F�6   .�51      �� 
 � ��# � ��52      �� 53      
 � ��$ 3��60   �� 54      
 �@��StrokeStartLineCap$ Round=�63   �� 55      
 �@��StrokeEndLineCap$ Round=�61   �� 56      
 �@��StrokeLineJoin$ Round=�6/   �� 57      
 �@��StrokeDashCap$ Round=�6.   58      59       � Triggers 5:      :� 5;   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5<      �� .��5=      �� .��5>      W�  �� 
TargetName$ 	xformHour��6&    �� TargetProperty$ Angle�5?   &    W� From$ 0X�5@   &   	 W� To$	 360X�6/    g� Duration$ 12:0:0D�68    W� 
IsAdditive .  g� RepeatBehavior$ Forever��5B   &   W� 5D      $ xformMinute��6&   $ Angle�5E   &   $ 0X�5F   &   $	 360X�6/   $ 1:0:0D�68    . $ Forever��5H   &   W� 5J      $ xformSecond��6&   $ Angle�5K   &   $ 0X�5L   &   $	 360X�6/   $ 0:1:0D�68    . $ Forever��5N   &   5O      5P      5Q      .��5S      �� ���	#FFFF670F$��2q�6%   ._�5T   
   �  � RowDefinitions 5U      �� 5V      $
��291* �6    �� 5W      $	��55* �6     � ColumnDefinitions 5Y      �� 5Z      $
��179* �6#   �� 5[      $
��119* �6#   .+�5]      �� $	��200��6   $	��200��6"   $��1��6.   $	��Top=�6>   $��
24,20,14,0q�6V   $��Center=�6j   z�5^      T� 5_      $	 100Q�6)   $	 100Q�61   .+�5d      F� %����    ���������������J]�J]	 �� StrokeDashArray$ 	0 3.14157R�5e      F� 5g      %����    ���������������J]�J]	$ 0 7.854R�5h      $��6��5i      F� 5l      +����    ��� р��     �     yl�рig�    	#��� ��5m      z�5n      �� 5o      -   5        	xformHour�� �� Angle 5p      �� *Value.OffsetX+# [ 5r      F� 5v      +����     -1�@KL     �     L;������    	#��� ��5w      z�5x      �� 5y      -   5        xformMinute�� 5z      �� *Value.OffsetX+# [ 5|      F� 5~      ����    ��� �     L;�	z�5      �� 5�      -   5        xformSecond�� 5�      �� *	Value.M11+# [ 5�      5�      8  2DevExpress.Xpf.Editors.DateNavigator.DateNavigator  5�      -   5          Name$ dateNavigater��5�          ShowTodayButton .     CalendarView$ Month=�6O   $��Stretch=�6f   $��0��6�   $��0��6�   $��0,20,0,0q�6�   �� 5�      -   5        $��Today��5�      $
��Left=�6%   $��	10,10,0,0q�6@   $	��Top=�6S   $��60��6k   $��32��6v   $��1��6�   6�   �� 5�      -   5        $��Clear��5�      $
��Left=�6%   $��
106,10,0,0q�6@   $	��Top=�6T   $��60��6l   $��32��6w   $��1��6�   6�   �� 5�      -   5        $��OK��5�      $
��Left=�6"   $��
153,10,0,0q�6=   $	��Top=�6Q   $��60��6i   $��32��6t   $��1��6�   $��1��6�   6�   �� 5�      -   5        $��Cancel��5�      $
��Left=�6&   $��	58,10,0,0q�6A   $	��Top=�6T   $��60��6l   $��32��6w   $��1��6�   $��1��6�   6�   �� 5�      $��1��6    �� Orientation$ 
Horizontal=�6*   $��Center=�6C   $��40��6`   $��	68,0,62,5q�6l   $��Bottom=�6   $	��108��6�   .+�5�      �� -	   5         ��Name$
 hour��5�   M   $	��0,7q�6   $��16(�6(    �� TextAlignment$ Center=�66   $��32��6[   $
��Left=�6h    �� TextWrapping$ NoWrap=�6�   $��00��6�   $��Center=�6�   $��32��6�   $��0q�6�   6�   �� 5�      $��:��6   $��18(�6$   $��Center=�62   $
��Bold"�6M   �� 5�      -
   5        $ minute��5�   M   $��16(�6   $	��0,7q�6(   $ Center=�66   $��32��6^   $
��Left=�6k   $ NoWrap=�6�   $��00��6�   $��Center=�6�   $��32��6�   $	��0,4q�6�   6�   �� 5�      $��18(�6   $��:��6&   $��Center=�62   $
��Bold"�6M   �� 5�      -   5        $ second��5�   M   $��16(�6   $	��0,7q�6(   $ Center=�66   $��32��6^   $
��Left=�6k   $ NoWrap=�6�   $��00��6�   $��Center=�6�   $��32��6�   $	��0,4q�6�   6�   5�      5�      5�      5�      