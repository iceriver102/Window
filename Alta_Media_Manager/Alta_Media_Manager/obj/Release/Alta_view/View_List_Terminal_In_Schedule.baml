   M S B A M L   `   `   `  ����   Alta_Media_ManagerA    ;Alta_Media_Manager.Alta_view.View_List_Terminal_In_Schedule   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     $��Verdana)�.���� -     ��Name$  
mainLayout��$
��1346��$	��663��.+��� $
��1046��$	��500��
 �� Top$ 50�� �� Left$	 150��
���   �$��1q�
�������._��  � RowDefinitions �� $	��42* ��� $	��55* ��� $
��355* ��� $	��46* �.+��� 
���   �$��0q�$��Stretch=�$��Stretch=�
���   �._���  �� TextAlignment$ Center=�
�������$��18(�$��
Màn hình��$��Center=�$
��Bold"��� -    ��Name$ lb_data��$��2��$
��Auto=�$��Hidden=� � 	Resources  �� 
TargetType �� Property	 �� Value��%?   '��       �� " ��.���  � ��	 .  ��  � |�	 .  ���� .R�� ���� * (FrameworkElement.ActualWidth)+
 �� RelativeSource
 ��  �� AncestorType$ ScrollContentPresenterL� � 	ItemWidth �� *(ListView.View).ItemWidth+
 �� $ ListViewL����� *	ItemWidth+
 �� *Self+ � 
ItemHeight �� *(ListView.View).ItemHeight+
 �� $ ListViewL����� " ��.���  � ��$	 0q���  � ��$	 8q���  � ��$	 0q��� -   $�� ��   btn_tmp#���   $��32��$��32��$��1��$��Right=�$��Center=�$��
0,12,10,11q�$��0q���Z� ����  j� Stretch$ Uniform=� �� ImageSource$H B/Alta_Media_Manager;component/Asset/Alta_Btn/ic_action_refresh.png���� -    ��Name$ 	btnAction��$
��Lưu�� � Cursor$
 Hand��$
��Left=�$��	944,0,0,0q�$��3��$��Center=�$��75���� -   $�� ��#���   $
 1178��$ 36��$��28��$��28��$��0q���Z� ���� $ Uniform=�$D >/Alta_Media_Manager;component/Asset/Alta_Btn/btn_close_box.png��