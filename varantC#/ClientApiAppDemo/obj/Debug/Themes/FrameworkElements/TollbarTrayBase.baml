   M S B A M L   `   `   `  ����W  SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ToolBarButtonBaseStyle  �� 
TargetType �� Property �� Value  Button.Foreground.Static �� 
TargetType ��Name �� Triggers P� Property P� Value  Button.MouseOver.Foreground  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Foreground  Button.Pressed.Background  Button.Pressed.Border �� BasedOn-   'System.Windows.Input.KeyboardNavigation  TextBox.Static.Foreground 	 TextBox.Static.Background 
 TextBox.Static.Border  TextBox.Border.Thickness  TextBox.Corner.Radius	 �� Padding
 �� CornerRadius ��Name  ToolBarThumbStyle J� SnapsToDevicePixels j� Viewport j� ViewportUnits j� Viewbox j� ViewboxUnits j� TileMode L� Drawing # Toggle.Button.Static.Foreground � Brush � Geometry  ToolBarOverflowButtonStyle # Toggle.Button.Static.Background F�Name & "Toggle.Button.MouseOver.Foreground & "Toggle.Button.MouseOver.Background $  Toggle.Button.Pressed.Foreground $  Toggle.Button.Pressed.Background % !Toggle.Button.Disabled.Background ! Toggle.Button.Disabled.Border  Page.Border  Page.Background.2 c� HasOverflowItems �� 	ClickMode d� 	IsChecked �� Mode �� RelativeSource �Name � AllowsTransparency � 	StaysOpen   ComboBox.Static.Popup.Border $  ComboBox.Static.Popup.Background b�Name b� 	WrapWidth     TabNavigation!    DirectionalNavigation" � FocusVisualStyle# n�Name$ a�Name% K� IsItemsHost& �� Triggers' �� 
TargetName�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      5      %�  &	        (�� E    5"      *ToolBar.ButtonStyleKey+)7   (�� b    5#      *ToolBar.ToggleButtonStyleKey+)7   (��     5$      *ToolBar.CheckBoxStyleKey+)7   (�� �    5%      *ToolBar.RadioButtonStyleKey+)7   (�� �    5'      *ToolBar.TextBoxStyleKey+)&	 �    &	 �    'c� �    '`� D    �� 5      "  ��6+   .�5   
   ��  �@J�SnapsToDevicePixels . 60   �� 5   
    �@�OverridesDefaultStyle . 62   �� 5   
    � ��# �  6'   �� 5   
    � ��
 ���� 6'   �� 5	   
    � ��
 ���� 6(   �� 5
   
    � ��$ 0q�6,   �� 5   
    � �� 5      �� 5      " ��6"   .R�5      �� $ Border��6   #��z��6-   #��z��6a   #��z��6�   ._�5      �� $��2q�6+   $��Center=�66   $��Center=�6S   ��. 6n   5      5      5       5   
   P� 5       �@J�IsMouseOver . . �5      ��  � ��# �  6/   �� 5       � ��# �  6/   �� 5       � ��# �  60   5      P� 5       � �� . . �5      ��  � ��# �  6/   �� 5       � ��# �  6/   �� 5       � ��# �  60   5      5       �� 5"      8   "  ��6h   �� 5#      8   "  d�6n   �� 5$      8   "  ��6j   �� 5%      8   "  	�6m   �� 5'      "  ��67   .�5(   
   ��  �@J�SnapsToDevicePixels . 60   �� 5)   
    �@�OverridesDefaultStyle . 62   �� 5*   
    �@  TabNavigation$
 None=�6=   �� 5+   
    �@�FocusVisualStyle 6-   Z� �� 5,   
    �@J�	AllowDrop . 6&   �� 5-   
    � ��# �  6'   �� 5.   
    � ��# � 	 6'   �� 5/   
    � ��# � 
 6(   �� 50   
    � ��# �  6,   �� 51   
    �@��CornerRadius# �  60   �� 52   
    � �� 53      �� 54      " ��6"   .R�55      �� $ Border��6   $	 2q�6-   #
 z
 69   #��z��6n   #��z��6�   #��z��6�   ._�56      �� $ PART_ContentHost��62   $��0q�6'   62   57      58      5:      5;      �� 5=      "  n�6&   .�5>   
   ��  �@�OverridesDefaultStyle . 62   �� 5?   
    �@�Cursor$ SizeAll��6#   �� 5@   
    � �� 5A      �� 5B      " n�6"   .R�5C      �� 
������  . ._�5D      �� $	��0,2q�6$   ��5E      L� 5F   "   $ 0,0,4,4�6/   $ Absolute=�6B   $ 0,0,8,8�6[   $ Absolute=�6m   $
 Tile=�6�    5G   &   I� 5H   *   .��5I   .   � # �  6>   + �� 	=  	= � 	=  z � z  z � z  	= 	6x   5J   +   5L   #   5N      5O      5P      5R      5S      �� 5U      "  d�6/   .�5V   
   ��  �@�OverridesDefaultStyle . 62   �� 5W   
    � ��# �  6'   �� 5X   
    � ��# �  6'   �� 5Y   
    � �� 5Z      �� 5[      " d�6"   .R�5\      �� $ Border��6   $
 0,3,3,0��6-    . #��z��6_   ._�5]      � .+�5^      F� $ Arrow��6#   #��z��62   $��Bottom=�6V   $	��2,3q�6q   "�����^����- �`�S ��- Ѡ%& ��[ 	6~   �� 5_      5`      5a      5b      5d       5e   
   P� 5f       �@J�IsMouseOver . . �5g      ��  � ��# �  6/   �� 5h       � ��# �  6/   5i      P� 5j       � �� . . �5k      ��  � ��# �  6/   �� 5l       � ��# �  6/   5m      P� 5n       � {� .  . �5o      ��  � ��# �  6/   �� 5p       � ��# �  60   5q      5s      �� 5u      "  c�6%   .�5v   
   ��  �@J�SnapsToDevicePixels . 60   �� 5w   
    �@�OverridesDefaultStyle . 62   �� 5x   
    � ��$ 1q�6,   �� 5y   
    � ��# �  6(   �� 5z   
    � ��# �  6'   �� 5{   
    � �� 5|      �� 5}      " c�6"   .R�5~      �� $ Border��6   #��z��6-   #��z��6a   #��z��6�   ._�5      ]� .+�5�      d� $��Right=�6+   #{�z 6B   #���  6q   $ Press=�6�    6�   �� *IsOverflowOpen+$ TwoWay=� �� *TemplatedParent+.��5�   "   � $ OverflowPopup��6(    . $��Bottom=�6Y    .  |�.  $��Slide=�6�   ��6�   �� *IsOverflowOpen+ �� *TemplatedParent+.��5�   &   �� $ DropDownBorder��6-   $��1q�6E   #���  6Y   #���  6�   ._�5�   *   b� $ PART_ToolBarOverflowPanel��6?   $��2q�6b   $	 200Q�6m   |�. $  Cycle=�6�   $! Cycle=�6�   " 6�   Z� 6�   5�   '   5�   #   5�      n� 5�      $# ToolBarThumb��6$   #���  6:   $��10��6f   a� 5�      $$ PART_ToolBarPanel��6+   % . $��0,1,2,2q�6Y   5�      5�      & 5�      P� 5�       �@c�IsOverflowOpen . . �5�      �� $' ToolBarThumb��6%    � {� .  6T   5�      P� 5�       �@`�IsLocked . . �5�      �� $' ToolBarThumb��6%    � y�$ 	Collapsed=�6U   5�      5�      5�      5�      �� 5�      "  `�6)   .�5�   
   ��  �@`�
Background# �  6'   5�      5�      