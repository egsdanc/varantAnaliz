   M S B A M L   `   `   `  ���� R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType �� Property   ProgressBar.Progress �� Value  ProgressBar.Background  ProgressBar.Border �� 
TargetType �Name'   !System.Windows.VisualStateManager    VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard g� RepeatBehavior	 �� TargetProperty
 �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value8  2System.Windows.Media.Animation.EasingPointKeyFrame $� KeyTime $� Value ��Name J� RenderTransformOrigin �� Triggers P� Property P� Value �� 
TargetName �� Angle  Loading.Bar.Infinite ��Name �� CornerRadius ' #Progress.Bar.Track.Background.Brush j� TileMode j� Stretch j� Viewbox j� Viewport j� ViewportUnits �� RelativeTransform T� X T� Y  L� Drawing 1 -Progress.Bar.Track.Background.Alternate.Brush! � Brush" � Geometry# � Triggers$ :� RoutedEvent% W� From	& W� To' g� Duration�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      %�  '�       &	 �    �� "  �.���  � ��# �   ��  � ��# �  ��  � ��# �  ��  � ��$ 1q���  � �� �� " �.R��� #��z��#��z��#��z��._�� $ TemplateRoot��   CommonStates��.   Determinate��  Indeterminate��. �� $ Forever��.��U� $V	 P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�$
 	Animation��.\�  $ 0��$
 0.25Q�  $ 0:0:1��$
 0.25Q�  $ 0:0:2��$
 0.25Q�*� $'	 !(UIElement.RenderTransformOrigin)�$
 	Animation��.'�  $ 0��$ -0.5,0.5&�  $ 0:0:1��$ 0.5,0.5&�  $ 0:0:2��$ 1.5,0.5&�.+��� $ 
PART_Track��� $ PART_Indicator��}�. $
��Left=�.+��� $ 	Indicator��#��z���� $ 	Animation��#��z��$ 0.5,0.5&�z�V� .~��� �� �� T�  P�  �@�Orientation$ Vertical=�. ��� $ TemplateRoot�� �@�LayoutTransform �� $	 -90Q�P�  �@�IsIndeterminate . . ��� $ 	Indicator�� � y�$ 	Collapsed=��� "  �.���  � �� �� " �.R��� $ BorderBackground��$ 0��$��0q�._��    CommonStates��.   Determinate��  Indeterminate��.+��� $ 
PART_Track��$��0q�$��0q�$ 3���� $ PART_Indicator��$��0q�$��0q�$ 3��$
��Left=�#���  }�. ._��� $ DiagonalDecorator��$
��5000����L� $
 Tile=�$
 None=�$ 0,0,1,1�$ 	0,0,36,34�$ Absolute=� T� $ 0Q�$ 0Q�  � #! �  +" ��        р�    � Q%��р���	# :� $$ FrameworkElement.Loaded��.[��� .���� .��W� $Q	 K(Border.Background).(DrawingBrush.RelativeTransform).(TranslateTransform.X)�$% 0X�$	& .36X�$ Forever��$' 0:0:36D�