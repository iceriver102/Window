   M S B A M L   `   `   `  ����  Alta_Media_ManagerA    ;Alta_Media_Manager.Alta_view.View_List_Terminal_In_Schedule   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $��Verdana)�5   7   .��5      �� -   5          ��Name$  
mainLayout��5      $
��1346��6!   $	��663��6.   .+�5	   
   �� $
��1046��6   $	��500��6   
 �� Top$ 50��6+    �� Left$	 150��6;   
���   �$��1q�6a   
�������._�5
      �  � RowDefinitions 5      �� 5      $	��42* �6$   �� 5      $	��55* �6$   �� 5      $
��355* �6$   �� 5      $	��46* �6$   .+�5      �� 
���   �$��0q�6-   $��Stretch=�6A   $��Stretch=�6`   
���   �._�5      ��  �� TextAlignment$ Center=�6    
�������$��18(�6J   $��
Màn hình��6X   $��Center=�6h   $
��Bold"�6�   6�   5      �� 5      -   5         ��Name$ lb_data��5      $��2��6,   $
��Auto=�69   $��Hidden=�6i    � 	Resources 5       �� 
TargetType �� Property	 �� Value��%r   '��       �� 5      " ��6    .�5      ��  � ��	 .  6:   �� 5       � |�	 .  6:   5      5      ��5      �� 5      .R�5       � ��6(   �� * (FrameworkElement.ActualWidth)+
 �� RelativeSource
 ��  �� AncestorType$ ScrollContentPresenterL� � 	ItemWidth 5!      �� *(ListView.View).ItemWidth+
 �� $ ListViewL���5"      �� *	ItemWidth+
 �� *Self+ � 
ItemHeight 5#      �� *(ListView.View).ItemHeight+
 �� $ ListViewL�5$      ��5&      �� 5'      " ��6    .�5(      ��  � ��$	 0q�6@   �� 5)       � ��$	 8q�67   �� 5*       � ��$	 0q�68   5+      5-      �� 5.      -   5        $�� ��5.         btn_tmp#���   6$   $��32��6J   $��32��6U   $��1��6a   $��Right=�6n   $��Center=�6�   $��
0,12,10,11q�6�   $��0q�6�   ��6�   Z� ��5/      �� 50       j� Stretch$ Uniform=�6%    �� ImageSource$H B/Alta_Media_Manager;component/Asset/Alta_Btn/ic_action_refresh.png��67   52      �� 53      -   5         ��Name$ 	btnAction��53      $
��Lưu��6-    � Cursor$
 Hand��6;   $
��Left=�6I   $��	944,0,0,0q�6d   $��3��6w   $��Center=�6�   $��75��6�   6�   54      55      �� 56   
   -   5        $�� ��56      #���   6   $
 1178��6A   $ 36��6T   $��28��6d   $��28��6o   $��0q�6�   ��6{   Z� ��57      �� 58      $ Uniform=�6   $D >/Alta_Media_Manager;component/Asset/Alta_Btn/btn_close_box.png��6/   5:      5;      5<      