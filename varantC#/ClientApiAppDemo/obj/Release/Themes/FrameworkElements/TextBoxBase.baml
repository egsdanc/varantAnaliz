   M S B A M L   `   `   `  ���� R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   TextBoxContextMenu  m� Command �� 
TargetType �� Property �� Value  Input.Border.Static  Input.Foreground.Static  Input.Background.Static  Input.Static.Caret  Input.Static.Selection  TextBox.Border.Thickness  TextBox.Corner.Radius  TextBox.Padding-   'System.Windows.Input.KeyboardNavigation �� 
TargetType ��Name �� CornerRadius J� SnapsToDevicePixels ��Name	 �� Triggers
 P� Property P� Value �� 
TargetName 	 Input.Border.MouseOver 
 Input.Foreground.MouseOver  Input.Background.MouseOver  Input.Border.Focused  Input.Foreground.Focused  Input.Background.Focused  Input.Border.Disabled  Input.Foreground.Disabled  Input.Background.Disabled  Simple.TextBox.Style $  Simple.TextBox.Static.Background # Simple.TextBox.Border.Thickness   Simple.TextBox.Corner.Radius ' #Simple.TextBox.MouseOver.Background # Simple.TextBox.Focus.Background  TextBoxWithLabel  TextBox.Selection.Brush  Page.Foreground � ColumnDefinitions
 J� Uid ��Name �� 
AcceptsTab  Simple.PasswordBox.Style�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      %�  &	        '�� t     '�� �     7   &	 �    7   &	 	    7   'G� �
    &	 �    �� .@�m� $  ApplicationCommands.Copy��m� $  ApplicationCommands.Cut��m� $  ApplicationCommands.Paste���� " ��.���  � ��$ Center=��� " ��.���  �@�FocusVisualStyle Z� ��  �@�OverridesDefaultStyle . ��  �@�ContextMenu8   ��  � ��# �  ��  � ��# �  ��  � ��# �  ��  �@��
CaretBrush# �  ��  �@��SelectionBrush# �  ��  � ��# �  ��  �@��CornerRadius# �  ��  � ��# �  ��  �@  TabNavigation$
 None=���  � ��$ Stretch=���  � ��$ Center=���  � ��$
 Left=���  � ��$ Center=���  �@J�	AllowDrop . ��  �@��PanningMode$ VerticalFirst=���  �@��IsFlicksEnabled .  ��  � �� �� " ��.R��� $ border��#��z��#��z��#��z��# z  . ._��� $ PART_ContentHost��|�.  $��Hidden=�$��Hidden=�	 P� 
 �@J�IsMouseOver . . ��� $ border��# � 	  � ���� # � 
  � ���� $ border��# �   � ��P� 
 �@J�IsKeyboardFocused . . ��� $ border��# �   � ���� # �   � ���� $ border��# �   � ��P� 
 � {� .  . ��� $ border��# �   � ���� # �   � ���� $ border��# �   � ���� " ��.���  �@�FocusVisualStyle Z� ��  �@�OverridesDefaultStyle . ��  �@�ContextMenu8   ��  �@��
CaretBrush# �  ��  �@��SelectionBrush# �  ��  � ��# �  ��  � ��# �  ��  � ��# �  ��  � ��# �  ��  �@��CornerRadius# �  ��  � ��$ 5q���  �@  TabNavigation$
 None=���  � ��$ Stretch=���  � ��$ Center=���  � ��$
 Left=���  � ��$ Center=���  �@J�	AllowDrop . ��  �@��PanningMode$ VerticalFirst=���  �@��IsFlicksEnabled .  ��  � �� �� " ��.R��� $ border��#��z��#��z��#��z�� . # z ._��� $ PART_ContentHost��|�.  $��Hidden=�$��Hidden=�	 P� 
 �@J�IsMouseOver . . ��� $ border��# � 	  � ���� # � 
  � ���� $ border��# �   � ��P� 
 �@J�IsKeyboardFocused . . ��� $ border��# �   � ���� # �   � ���� $ border��# �   � ��P� 
 � {� .  . ��� $ border��# �   � ���� # �   � ���� $ border��# �   � ���� " ��.���  �@�OverridesDefaultStyle . ��  �@�ContextMenu8   ��  �@��SelectionBrush# �  ��  � ��$ 1q���  �@J�Uid$ 
Label Text����  � ��$ TextBox Text����  � ��# �  ��  � �� �� " ��.R��  �� $
��Auto ��� $��* �.+��� $��0��$��Center=�#��z #���  $	��5,0q��� $ TxtBox��$��Center=�#��z��$��Stretch=�$��Stretch=�$��1��#��z��$��5,0,5,0q�
������  .  �� " G�.���  �@G�PasswordChar$	 ●����  �@G�
CaretBrush# �  ��  �@G�SelectionBrush# �  ��  � ��# �  ��  � ��# �  ��  � ��# �  ��  �@��CornerRadius# �  ��  � ��$ 1q���  �@  TabNavigation$
 None=���  � ��$
 Left=���  � ��$ Center=���  �@J�	AllowDrop . ��  � ��$ 5q���  �@��PanningMode$ VerticalFirst=���  �@��IsFlicksEnabled .  ��  � �� �� " G�.R��� $ border��#��z��#��z��#��z�� . # z ._��� $ PART_ContentHost��|�.  $��Hidden=�$��Hidden=�	 P� 
 �@J�IsMouseOver . . ��� $ border��# � 	  � ���� # � 
  � ���� $ border��# �   � ��P� 
 �@J�IsKeyboardFocused . . ��� $ border��# �   � ���� # �   � ���� $ border��# �   � ��P� 
 � {� .  . ��� $ border��# �   � ���� # �   � ���� $ border��# �   � ���� " G�.���  �@G�PasswordChar$	 ●����  �@G�
CaretBrush# �  ��  �@G�SelectionBrush# �  ��  � ��# �  ��  � ��# �  ��  � ��# �  ��  � ��# �  ��  �@��CornerRadius# �  ��  �@  TabNavigation$
 None=���  � ��$
 Left=���  � ��$ Center=���  �@J�	AllowDrop . ��  � ��$ 5q���  �@��PanningMode$ VerticalFirst=���  �@��IsFlicksEnabled .  ��  � �� �� " G�.R��� $ border��#��z��#��z��#��z�� . # z ._��� $ PART_ContentHost��|�.  $��Hidden=�$��Hidden=�	 P� 
 �@J�IsMouseOver . . ��� $ border��# � 	  � ���� # � 
  � ���� $ border��# �   � ��P� 
 �@J�IsKeyboardFocused . . ��� $ border��# �   � ���� # �   � ���� $ border��# �   � ��P� 
 � {� .  . ��� $ border��# �   � ���� # �   � ���� $ border��# �   � ��