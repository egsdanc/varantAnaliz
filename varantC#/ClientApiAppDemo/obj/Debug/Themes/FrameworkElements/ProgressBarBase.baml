   M S B A M L   `   `   `  ����W  SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType �� Property   ProgressBar.Progress �� Value  ProgressBar.Background  ProgressBar.Border �� 
TargetType �Name'   !System.Windows.VisualStateManager    VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard g� RepeatBehavior	 �� TargetProperty
 �� 
TargetName9   3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value8   2System.Windows.Media.Animation.EasingPointKeyFrame $� KeyTime $� Value ��Name J� RenderTransformOrigin �� Triggers P� Property P� Value �� 
TargetName �� Angle  Loading.Bar.Infinite ��Name �� CornerRadius ' #Progress.Bar.Track.Background.Brush j� TileMode j� Stretch j� Viewbox j� Viewport j� ViewportUnits �� RelativeTransform T� X T� Y  L� Drawing 1 -Progress.Bar.Track.Background.Alternate.Brush! � Brush" � Geometry# � Triggers$ :� RoutedEvent% W� From	& W� To' g� Duration�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      5      %a  '�       &	 �    �� 5      "  �6   .�5   
   ��  � ��# �   6'   �� 5   
    � ��# �  6'   �� 5   
    � ��# �  6(   �� 5   
    � ��$ 1q�6,   �� 5	   
    � �� 5
      �� 5      " �6"   .R�5      �� #��z��6   #��z��6I   #��z��6}   ._�5      � $ TemplateRoot��6    5        5   "   CommonStates��. 5   &     Determinate��62     5   &   Indeterminate��. 5   *   �� $ Forever��65   .��5   .   U� $V	 P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6L   $
 	Animation��6�   .\�5   2     $ 0��6G   $
 0.25Q�6S     5   2   $ 0:0:1��6G   $
 0.25Q�6W     5   2   $ 0:0:2��6G   $
 0.25Q�6W   5   /   *� 5   .   $'	 !(UIElement.RenderTransformOrigin)�6K   $
 	Animation��6�   .'�5   2     $ 0��6F   $ -0.5,0.5&�6R     5   2   $ 0:0:1��6F   $ 0.5,0.5&�6V     5   2   $ 0:0:2��6F   $ 1.5,0.5&�6V   5   /   5   +   5   '   5   #   .+�5!      �� $ 
PART_Track��6(   � 5"      $ PART_Indicator��6#   }�. $
��Left=�6O   .+�5#   "   �� $ 	Indicator��6,   #��z��6?   �� 5$   "   $ 	Animation��6,   #��z��6?   $ 0.5,0.5&�6c   z�5%   &   V� 5&   *   .~�5'   .   �� �� 5(   .   �� 5)   .   T� 5*   .   5+   +   5-   #   5.      5/      50       52      P� 53       �@�Orientation$ Vertical=�69   . �54      �� $ TemplateRoot��6@    �@�LayoutTransform 55   "   �� 56   &   $	 -90Q�66   58      59      P� 5:       �@�IsIndeterminate . . �5;      �� $ 	Indicator��6;    � y�$ 	Collapsed=�6R   5<      5>      5@      5A      �� 5E      "  �6)   .�5F   
   ��  � �� 5G      �� 5H      " �6"   .R�5I      �� $ BorderBackground��6   $ 0��67   $��0q�6H   ._�5J      �  5K        5L   "   CommonStates��. 5M   &     Determinate��62     5N   &   Indeterminate��62   5O   #   .+�5Q      �� $ 
PART_Track��6%   $��0q�69   $��0q�6D   $ 3��6X   �� 5R      $ PART_Indicator��6%   $��0q�6=   $��0q�6H   $ 3��6\   $
��Left=�6m   #���  5S   %   }�. ._�5T   "   �� $ DiagonalDecorator��6)   $
��5000��6D   ��5U   &   L� 5V   *   $
 Tile=�67   $
 None=�6G   $ 0,0,1,1�6V   $ 	0,0,36,34�6h   $ Absolute=�6}    5W   .   T� 5X   2   $ 0Q�6E   $ 0Q�6K     5Z   .   � 5[   2   #! �  6B   +" ��        р�    � Q%��р���	6�   5]   +   # 5_   &   :� 5`   *   $$ FrameworkElement.Loaded��67   .[�5a   .   �� .��5b   2   �� .��5c   6   W� $Q	 K(Border.Background).(DrawingBrush.RelativeTransform).(TranslateTransform.X)�5d   9   $% 0X�5e   9   $	& .36X�6B   $ Forever��6K   $' 0:0:36D�6d   5f   3   5g   /   5h   +   5j   #   5k      5l      5m      5n      5p      5q      5s      