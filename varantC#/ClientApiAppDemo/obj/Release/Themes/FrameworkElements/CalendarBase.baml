   M S B A M L   `   `   `  ���� R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   CalendarButtonStyle  �� 
TargetType7   1System.Windows.Controls.Primitives.CalendarButton �� Property " Calendar.Day.Active.Foreground �� Value $  Calendar.Day.Selected.Background �� 
TargetType ��Name J� Opacity �� RadiusY �� RadiusX ��Name	 �� Triggers
 P� Property P� Value �� 
TargetName ' #Calendar.Today.MouseOver.Foreground  CalendarDayButtonStyle:  4System.Windows.Controls.Primitives.CalendarDayButton � 	Resources  Key F�Name  Calendar.Blackout.Path J� RenderTransformOrigin �� Stretch $  Calendar.Day.Inactive.Foreground ! Calendar.Day.Today.Foreground ]� 
Conditions �� Property �� Value  	 Calendar.Day.Selected.Border %
 !Calendar.Day.MouseOver.Background  PreviousButtonTemplate � Cursor ��Name �� CornerRadius % !Calendar.Header.Static.Background % !Calendar.Header.Static.Foreground ( $Calendar.Header.MouseOver.Foreground ( $Calendar.Header.MouseOver.Background  NextButtonTemplate  HeaderButtonTemplate5  /System.Windows.Controls.Primitives.CalendarItem   Calendar.DayNames.Foreground �Name � ColumnDefinitions � RowDefinitions ��Name  Calendar.Disabled.Color �� Value �� Binding �� RelativeSource �� AncestorType&   System.Windows.Controls.Calendar  DefaultCalendar  Calendar.Static.Background  Calendar.Static.Border ��Name   Name�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      %�  &	        &	 K    &	 �    &	 �    &	     '  �    7  &	 _    7   7  �� "    .���  � ��# �  ��  � ��# �  ��  � ��$ 40����  � ��$ 42����  � ��$ 10(���  � ��$ Center=���  � ��$ Center=���  � �� �� "   .R�� .+��� $ SelectedBackground��#��z��$ 0Q�$ 1��$ 1���� $ 
NormalText��#��z��#��z��$��1,0,1,1q�#��z��	 P� 
 �@J�IsMouseOver . . ��� $ 
NormalText��# �   � ���� $ SelectedBackground�� �@J�Opacity$ 1Q�P� 
 �@  HasSelectedDays . . ��� $ 
NormalText��# �   � ���� $ SelectedBackground�� �@J�Opacity$ 1Q��� "   .���  � ��$ 5����  � ��$ 5����  � ��$ 10(���  � ��$ Center=���  � ��$ Center=���  � �� �� "   ���� Storyboard1 .R�� .+��� $ bd��
������ $ 1��$ 1���� $ 
NormalText��#��z��$��5,1,5,1q�#��z��F� $ Blackout��+�����˾ @X5 �@X5 �u� �@X5 �˾ ��˾ (�Q #���  $��Stretch=�$��10��$ 0Q�$ 0.5,0.5&�$
 Fill=�$��Stretch=�	 P� 
 �@ 
IsInactive .  . ��� $ 
NormalText��# �   � ��P� 
 �@ 
IsInactive . . ��� $ 
NormalText��# �   � ��P� 
 �@ IsToday . . ��� $ 
NormalText��# �   � ���� $ bd��# �   � ��]�  ��  �@ 
IsSelected .  ��  �@ IsToday . /��� $ bd�� Z�  � ���� $ bd��# � 	  � ���� $ bd�� � ��$ 1��]�  ��  �@ IsBlackedOut .  ��  �@J�IsMouseOver . /��� $ 
NormalText��# �   � ���� $ bd��# � 
  � ��P� 
 �@ 
IsSelected . . ��� $ 
NormalText��# �   � ���� $ bd��# �   � ��P� 
 �@ IsBlackedOut . . ��� $ Blackout�� �@J�Opacity$	 0.7Q��� " ��.R�� $
 Hand��.+��� $ bd��$��26��$��Stretch=�$ 0,0,0,2��#���  ._�F� $
 path��#���  $��Center=�$��Center=�$ Uniform=�������[7 @H ��:C 0i  Q ����V �� �8[ �� ��U ȴ `�I ؓ  Ѹ�4 �s5 Ө�( �NA ��( h�T ��4 x�` �`�I  ~u ӈ�U HY�   [ @0� V P9� � Q �:� �:C Ȩ� �[7 �ɇ � |" �r ��  g  � �3Y �� �*T Ӱ����%O ����X�F �� H�A � �  �< � /  |"  (# ��[7 @H 	 P� 
 �@J�IsMouseOver . . ��� $
 path��# �   � ���� $ bd��# �   � ���� " ��.R�� $
 Hand��.+��� $ bd��$��26��$��Stretch=�$ 0,0,2,0��#���  ._�F� $
 path��#���  $��Center=�$��Center=�$ Uniform=������#P `H� ӐDD p'� �q6 �� ph1 ��� �Hc, 讟 ��1 �ߑ �= ��� ��R q ��^ �Ae �^ 8�Q �R (�E ����K7@P1 ���1 @;% 0g, 0h Xl1  _ �hu6 �Y �DD �� �'P ���x�& @�He x�3 �X�p ��? h�~ �`M x �iR ӈˈ �rW �ˈ 0�_ x @�d �He �l� Ѡ#P `H� 	 P� 
 �@J�IsMouseOver . . ��� $
 path��# �   � ���� $ bd��# �   � ���� " ��.R�� $
 Hand��.+��� $ bd��#���  $	��1,0q�$��26��._��� $ buttonContent��#��z��#��z��#���  #��z��$��Center=�	 P� 
 �@J�IsMouseOver . . ��� $ buttonContent��# �   � ���� "   .���  � ��$ 0,3,0,3q���  � �� �� "   ���� (��       **(CalendarItem.DayTitleTemplateResourceKey+).R��� #���  $
��Bold"�$	��9.5(�$��Center=�$��0,6,0,6q�$��Center=����� .R�� $ 	PART_Root��.+��� #��z��#��z��#��z��$ 0��._��  �� $
��Auto ��� $��* ��� $
��Auto � �� $
��Auto ��� $��* �.+��� $ PART_PreviousButton��$��0��|�.  $
��Left=�$��0��#���  �� $ PART_HeaderButton��$��1��$
��Bold"�|�.  $
��10.5(�$��Stretch=�$��0��8��  $��Center=��� $ PART_NextButton��$��2��|�.  $��Right=�$��0��#���  � $ PART_MonthView��$��3��$��Center=�$��6,-1,6,6q�$��1��$y�Visible=� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �� $ PART_YearView��$��3��$��Center=�$��6,-3,7,6q�$��1��$y�Hidden=� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $ PART_DisabledVisual��#���  $ 0Q�$ 2��$ 2��$
 Fill=�#���  $��1��$y�	Collapsed=�	 P� 
 � {� .  . ��� $ PART_DisabledVisual�� � y�$ Visible=��� $
 Year�� �� *DisplayMode+ �� *FindAncestor+"  .a��� $ PART_MonthView�� � y�$ Hidden=��� $ PART_YearView�� � y�$ Visible=��� $ Decade�� �� *DisplayMode+ �� *FindAncestor+"  .a��� $ PART_MonthView�� � y�$ Hidden=��� $ PART_YearView�� � y�$ Visible=��� "   .���  �@�OverridesDefaultStyle . ��  �@ CalendarButtonStyle8   ��  �@ CalendarDayButtonStyle8  ��  � ��# �  ��  � ��# �  ��  � ��$ 1q���  � �� �� "  .R��� $ 	PART_Root��$��Center=�.+�  $  PART_CalendarItem��#��z��#��z��#��z��