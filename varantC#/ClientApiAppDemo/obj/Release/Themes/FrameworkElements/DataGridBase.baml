   M S B A M L   `   `   `  ���� a  ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source   ColumnHeaderGripperStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Padding % !DataGrid.Header.Static.Foreground % !DataGrid.Header.Static.Background ! DataGrid.Header.Static.Border J� SnapsToDevicePixels n�Name	 �� Triggers
 P� Property P� Value ( $DataGrid.Header.MouseOver.Foreground ( $DataGrid.Header.MouseOver.Background & "DataGrid.Header.Pressed.Foreground & "DataGrid.Header.Pressed.Background=   7System.Windows.Controls.Primitives.DataGridColumnHeader3   -Microsoft.Windows.Themes.DataGridHeaderBorder    CanUserSort   IsClickable   	IsPressed J� IsMouseOver   	IsHovered    SortDirection   SortDirection    SeparatorBrush   SeparatorBrush    SeparatorVisibility   SeparatorVisibility  
BaseHeader)  #System.Windows.Controls.DataGridRow ��Name?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid � ColumnDefinitions � RowDefinitions?  9System.Windows.Controls.Primitives.DataGridCellsPresenter   
ItemsPanelA  ;System.Windows.Controls.Primitives.DataGridDetailsPresenter   DetailsVisibility$   SelectiveScrollingOrientation;  5System.Windows.Controls.SelectiveScrollingOrientation   Vertical �� ConverterParameter �� FallbackValue  �� TargetNullValue&   System.Windows.Controls.DataGrid#!   RowDetailsScrollingConverter" �� 	Converter# �� RelativeSource$ �� AncestorType:  4System.Windows.Controls.Primitives.DataGridRowHeader7	  1System.Windows.Controls.DataGridHeadersVisibility
% 	  Row!&   HeadersVisibilityConverter' �� Triggers 	 BaseRow( �� Path*
  $System.Windows.Controls.DataGridCell &
 "DataGrid.Cell.MouseOver.Foreground $  DataGrid.Cell.Focused.Background $  DataGrid.Cell.Focused.Foreground   DataGrid.Cell.Focused.Border) ]� 
Conditions* �� Property+ �� Value & "DataGrid.Cell.MouseOver.Background " DataGrid.Cell.MouseOver.Border % !DataGrid.Cell.Disabled.Foreground  BaseCell  	RightCell % !DataGrid.Cell.Selected.Background % !DataGrid.Cell.Selected.Foreground ! DataGrid.Cell.Selected.Border & "DataGrid.Cell.LostFocus.Background & "DataGrid.Cell.LostFocus.Foreground " DataGrid.Cell.LostFocus.Border  CaptionCell  bool2VisibilityConverter  RowHeaderGripperStyle  BaseRowHeader ) %DataGrid.Row.Header.Static.Background % !DataGrid.Row.Header.Static.Border,   IsRowSelected-   
IsSelected.   Orientation/   SeparatorBrush0   SeparatorVisibility1 �� Orientation , (DataGrid.Row.Header.MouseOver.Background *  &DataGrid.Row.Header.Pressed.Background !! RowHeaderSelectAllButtonStyle " DataGrid.Static.Background # DataGrid.Static.Foreground $ DataGrid.Static.Border ,% (DataGrid.Alternate.Row.Static.Background "& DataGrid.Row.Static.Background (' $DataGrid.Horizontal.GridLines.Border &( "DataGrid.Vertical.GridLines.Border2 ��Name3   SelectAllCommand
4 	  AllG  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter5  Name6 	  Column7 ��Name8 �� CanContentScroll9 ��Name: �� ScrollableHeight; � Maximum< �� Orientation*= �� #ComputedVerticalScrollBarVisibility> �� ViewportHeight? �� ViewportSize@ � ValueA �� ModeB �� ScrollableWidth,C �� %ComputedHorizontalScrollBarVisibilityD �� ViewportWidth ) 	PivotGrid * AkdDataGridRow + AkdDataGridColumnHeader , AkdDataGridCell #- DataGrid.Cell.Static.Foreground . DataGrid.Cell.Static.Border #/ DataGrid.Cell.Static.Background 0 AkdDataGridE � OverridesDefaultStyle 1 CellessDataGridColumnHeader 2 CellessDataGridCell 3 CellessDataGrid 4 NewsBaseHeader 5 NewsBaseRow 6 NewsBaseCell 7 NewsRightCell 8 NewsCaptionCell 9 NewsBaseRowHeader %: !NewsRowHeaderSelectAllButtonStyle ; NewsDataGridStyle�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     UthemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero    �� $ ScrollBarBase.xaml?�%�U  &	        '�� �     7   7   '   �    7   7   &	     7   7   '  k    &		 

    '
  �    &	 �    &	 �    &	 �    &	     &	 	    'n� �    &	 !    7  &	! R    '  �    7  7 	 7  7  &	) �#    7  7 	 7  7  &	* �+    &	+ �+    7   7   &	, t-    &	0 �0    7 , 7 + 7 * &	1 �5    &	2 7    &	3 d8    7 2 7 1 7 	 &	4 &=    7   7   &	5 s?    &	6 ?A    &	7 ,D    &	8 @G    &	9 FH    7  &	: wJ    &	; �K    7 4 7 5 7 6 7 9 �� " n�.���  � ��$ 8����  � ��
 ���� ��  �@�Cursor$ SizeWE����  � �� �� " n�.R��� #��z��# z���� " ��.���  � ��# �  ��  � ��# �  ��  � ��# �  ��  � ��$ 0,0,1,1q���  � ��$	 5,1q���  � ��$ Center=���  � ��$ Stretch=���  � �� �� " ��.R�� .+��� #��z��#��z��#��z��# z��._��� #��z����. # z #��z��n� $ PART_LeftHeaderGripper��$
��Left=�8��  n� $ PART_RightHeaderGripper��$��Right=�8�� 	 P� 
 �@J�IsMouseOver . . ��� # �   � ���� # �   � ��P� 
 � �� . . ��� # �   � ���� # �   � ���� "   .���  � ��# �  ��  � ��# �  ��  � ��# �  ��  � ��$ 0,0,1,1q���  �@  SeparatorVisibility$ Visible=���  � ��$	 5,1q���  � ��$ Center=���  � ��$ Stretch=���  � �� �� "   .R�� .+�  #��z��#��z��#��z��# z # z��# z # z��# z # z # z ._��� #��z����. # z #��z��n� $ PART_LeftHeaderGripper��$
��Left=�8��  n� $ PART_RightHeaderGripper��$��Right=�8�� 	 P� 
 �@J�IsMouseOver . . ��� # �   � ���� # �   � ��P� 
 � �� . . ��� # �   � ���� # �   � ���� "   .���  � ��# �  ��  � ��# �  ��  � ��# �  ��  � ��$ 0,0,1,1q���  �@  SeparatorVisibility$ Visible=���  � ��$	 5,1q���  � ��$ Stretch=���  � ��$ Center=���  � �� �� "   .R�� .+�  #��z��#��z��#��z��# z # z��# z # z��# z # z # z ._��� #��z����. # z #��z��n� $ PART_LeftHeaderGripper��$
��Left=�8��  n� $ PART_RightHeaderGripper��$��Right=�8�� 	 P� 
 �@J�IsMouseOver . . ��� # �   � ���� # �   � ��P� 
 � �� . . ��� # �   � ���� # �   � ���� "  .���  �@J�SnapsToDevicePixels . ��  �@=�ErrorTemplate Z� ��  �@ ValidationErrorTemplate �� .R��� #��z��$��2,0,0,0q�$��!��$��Center=���  � �� �� "  .R��� $ 
DGR_Border��#��z��#��z��#��z�� . ._�   �� $
��Auto ��� $��* � �� $��* ��� $
��Auto �.+�  $��1��#��z # z   $��1��$��1��#y�z  �� *AreRowDetailsFrozen+# Z # Z #  Z #" Z! # �� "$    $��2��$ Vertical=�y��� *HeadersVisibility+# Z% # Z% $  Visible��#" Z& # �� "$  ' P� 
 �@ 	IsNewItem . . ���  � �� �� *NewItemMargin+# �� "$  �� "  .���  �@J�SnapsToDevicePixels . ��  �@=�ErrorTemplate Z� ��  �@ ValidationErrorTemplate �� .R��� #��z��$��2,0,0,0q�$��!��$��Center=���  � �� �� "  .R��� $ 
DGR_Border��#��z��#��z��#��z�� . ._�   �� $
��Auto ��� $��* � �� $��* ��� $
��Auto �.+�  $��1��#��z # z   $��1��$��1��#y�z  �� *AreRowDetailsFrozen+# Z $ Vertical��#" Z! # �� "$    $��2��$ Vertical=�y��� # �� *Self+$:( 4Parent.Parent.Parent.DataGridOwner.HeadersVisibility�#" Z& # Z% ' P� 
 �@ 	IsNewItem . . ���  � �� �� *NewItemMargin+# �� "$  �� " 
 .���  � ��# � 
 ��  � ��
 ���� ��  � ��
 ���� ��  � ��$ 1q���  �@�OverridesDefaultStyle . ��  � ��$ Stretch=���  � ��$ Center=���  � �� �� " 
 .R��� #��z��#��z��#��z��#��z�� . ._��� #��z��# z ' P� 
 �@
 
IsSelected . . ���  � ��# �  ��  � ��# �  ��  � ��# �  P� 
 �@J�IsKeyboardFocusWithin . . ���  � ��# �  ��  � ��# �  ��  � ��# �  ]� ) �� * �@
 
IsSelected+ .  �� * �@J�IsMouseOver+ . ./���  � ��# �  ��  � ��# � 
 ��  � ��# �  ]� ) �� * �@
 
IsSelected+ . �� * �@��IsSelectionActive+ .  ./���  � ��# �  ��  � ��# �  ��  � ��# �  P� 
 � {� .  . ���  � ��# �  �� " 
 .���  � ��# � 
 ��  � ��
 ���� ��  � ��
 ���� ��  � ��$ 1q���  � ��$ Stretch=���  � ��$ Center=���  � �� �� " 
 .R��� #��z��#��z��#��z��#��z�� . ._��� #��z��# z ' P� 
 �@
 
IsSelected . . ���  � ��# �  ��  � ��# �  ��  � ��# �  P� 
 �@J�IsKeyboardFocusWithin . . ���  � ��# �  ��  � ��# �  ��  � ��# �  ]� ) �� * �@
 
IsSelected+ .  �� * �@J�IsMouseOver+ . ./���  � ��# �  ��  � ��# � 
 ��  � ��# �  ]� ) �� * �@
 
IsSelected+ . �� * �@��IsSelectionActive+ .  ./���  � ��# �  ��  � ��# �  ��  � ��# �  P� 
 � {� .  . ���  � ��# �  �� " 
 .���  �@��TextAlignment$ Right=���  � ��
 ���� ��  � ��
 ���� ��  � ��$ 1q���  � ��$ Stretch=���  � ��$ Center=���  � �� �� " 
 .R��� #��z��#��z��#��z��#��z�� . ._��� #��z��# z ' P� 
 �@
 
IsSelected . . ���  � ��# �  ��  � ��# �  ��  � ��# �  P� 
 �@J�IsKeyboardFocusWithin . . ���  � ��# �  ��  � ��# �  ��  � ��# �  ]� ) �� * �@
 
IsSelected+ .  �� * �@J�IsMouseOver+ . ./���  � ��# �  ��  � ��# � 
 ��  � ��# �  ]� ) �� * �@
 
IsSelected+ . �� * �@��IsSelectionActive+ .  ./���  � ��# �  ��  � ��# �  ��  � ��# �  P� 
 � {� .  . ���  � ��# �  �� " 
 .���  � ��# �  ��  � ��# �  ��  � ��
 ���� ��  � ��$ Stretch=���  � ��$ Center=���  � ��$ 0q���  � �� �� " 
 .R��� #��z��#��z��#��z��#��z�� . $ 2q�._��� #��z��# z $
��Bold"��� �� " n�.���  � ��$ 8����  � ��
 ���� ��  �@�Cursor$ SizeNS����  � �� �� " n�.R��� #��z��# z���� " n�.���  � ��$ 8����  � ��
 ���� ��  �@�Cursor$ SizeNS����  � �� �� " n�.R��� #��z��# z���� "  .���  � ��# �  ��  � ��# �  ��  � �� �� "  .R�� .+�  #��z��#��z��#��z��# z��# z #- z, $. 
Horizontal=�# z��# z/ # z0 ._��� $1 
Horizontal=�.+��� ��. # z $��Center=���  .  ���� *ValidationErrorTemplate+# �� "$  y��� *(Validation.HasError)+8"   # �� "$  n� $ PART_TopHeaderGripper��#���  $	��Top=�n� $ PART_BottomHeaderGripper��#���  $��Bottom=�	 P� 
 �@J�IsMouseOver . . ��� # �   � ��P� 
 � �� . . ��� # �    � ���� " ��.���  � ��# �  ��  � ��# �  ��  � ��# �  ��  � ��$ 0,0,1,1q���  � ��$ 3q���  � ��$ Center=���  � �� �� " ��.R��� #��z��#��z��#��z��._��� #��z����. # z #��z��	 P� 
 �@J�IsMouseOver . . ��� # �   � ���� # �   � ��P� 
 � �� . . ��� # �   � ���� # �   � ���� "  .���  �@ 
IsReadOnly . ��  � ��# � " ��  � ��# � # ��  � ��# � $ ��  � ��$ 1q���   �@ RowDetailsVisibilityMode$ VisibleWhenSelected=���  � �� . ��  �@��PanningMode$
 Both=���  �@��IsFlicksEnabled .  ��  �@ AutoGenerateColumns . ��  �@ CanUserAddRows .  ��  �@ CanUserReorderColumns . ��  �@ CanUserResizeColumns . ��  �@ CanUserResizeRows . ��  �@ CanUserSortColumns . ��  �@��AlternationCount$ 2����   �@ AlternatingRowBackground# � % ��  �@ RowBackground# � & ��   �@ HorizontalGridLinesBrush# � ' ��  �@ VerticalGridLinesBrush# � ( ��  �@ ColumnHeaderStyle8   ��  �@ RowStyle8  ��  �@ 	CellStyle8  ��  �@ RowHeaderStyle8  ��  � �� �� "  .R��� #��z��#��z��#��z��# z�� . ._��� $2 DG_ScrollViewer��|�.  ���� " ��.R��  �� $
��Auto ��� $��* ��� $
��Auto � �� $
��Auto ��� $��* ��� $
��Auto �.+��� #��Z3 |�.  #��� ! y��� *HeadersVisibility+# Z4 #" Z& # �� "$  ���� *CellsPanelHorizontalOffset+# �� "$    $!5 PART_ColumnHeadersPresenter��$��1��y��� *HeadersVisibility+# Z6 #" Z& # �� "$  �� $!7 PART_ScrollContentPresenter��#8 z��$��2��$��1���� $9 PART_VerticalScrollBar��$��2��#; z: $< Vertical=�$��1��#y�z= #? z> @ �� *VerticalOffset+$A OneWay=�# �� *TemplatedParent+� $��1��$��2�� �� ���� **(NonFrozenColumnsViewportHorizontalOffset+# �� "$  �� $��* �.+��� $9 PART_HorizontalScrollBar��$��1��#; zB $< 
Horizontal=�#y�zC #? zD @ �� *HorizontalOffset+$A OneWay=�# �� *TemplatedParent+.���� # z ' ]� ) �� * �@��
IsGrouping+ . �� "* �@%�IsVirtualizingWhenGrouping+ .  ./���  � �� .  P� 
 �@ HeadersVisibility$ Column=�. ���  �@ RowHeaderWidth$ 0Q��� "  .���  �@ 
IsReadOnly . ��  � ��# � " ��  � ��# � # ��  � ��# � $ ��  � ��$ 1q���   �@ RowDetailsVisibilityMode$ VisibleWhenSelected=���  � �� . ��  �@��PanningMode$
 Both=���  �@��IsFlicksEnabled .  ��  �@ AutoGenerateColumns . ��  �@ CanUserAddRows .  ��  �@ CanUserReorderColumns . ��  �@ CanUserResizeColumns . ��  �@ CanUserResizeRows . ��  �@ CanUserSortColumns . ��  �@��AlternationCount$ 2����   �@ AlternatingRowBackground# � % ��  �@ RowBackground# � & ��   �@ HorizontalGridLinesBrush# � ' ��  �@ VerticalGridLinesBrush# � ( ��  �@ ColumnHeaderStyle8   ��  �@ RowStyle8  ��  �@ 	CellStyle8  ��  �@ RowHeaderStyle8  ��  � �� �� "  .R��� #��z��#��z��#��z��# z�� . ._��� $2 DG_ScrollViewer��|�.  ���� " ��.R��  �� $
��Auto ��� $��* ��� $
��Auto � �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��Sembol��|�.  #��� ! y��� *HeadersVisibility+# Z4 #" Z& # �� "$  ���� *CellsPanelHorizontalOffset+# �� "$    $!5 PART_ColumnHeadersPresenter��$��1��y��� *HeadersVisibility+# Z6 #" Z& # �� "$  �� $!7 PART_ScrollContentPresenter��#8 z��$��2��$��1���� $9 PART_VerticalScrollBar��$��2��#; z: $< Vertical=�$��1��#y�z= #? z> @ �� *VerticalOffset+$A OneWay=�# �� *TemplatedParent+� $��1��$��2�� �� ���� **(NonFrozenColumnsViewportHorizontalOffset+# �� "$  �� $��* �.+��� $9 PART_HorizontalScrollBar��$��1��#; zB $< 
Horizontal=�#y�zC #? zD @ �� *HorizontalOffset+$A OneWay=�# �� *TemplatedParent+.���� # z ' ]� ) �� * �@��
IsGrouping+ . �� "* �@%�IsVirtualizingWhenGrouping+ .  ./���  � �� .  P� 
 �@ HeadersVisibility$ Column=�. ���  �@ RowHeaderWidth$ 0Q��� "  .���  � ��
 ���� �� "   .���  � ��# �  ��  � ��# �  ��  � ��# �  ��  � ��$ Center=���  � ��$ 0,0,1,0q���  � ��$ 2q���  �@J�SnapsToDevicePixels . ��  � �� �� "   .R�� .+�  #��z��#��z��#��z��# z # z��# z # z��# z # z # z ._��� #��z����. # z #��z��n� $ PART_LeftHeaderGripper��$
��Left=�8��  n� $ PART_RightHeaderGripper��$��Right=�8�� �� " 
 .���  � ��# � - ��  � ��$ 0q���  � ��# � . ��  � ��# � / ��  � ��$ 0q���  � ��$	 2,0q���  � ��$ Stretch=���  � ��$ Center=���  � �� �� " 
 .R�� #��z�� �� $��* ��� $��0 � �� $��* ��� $
��Auto �.+��� $��0��#��z��#��z��# z��#��z��#��z��._��� #��z��' P� 
 �@
 
IsSelected . . ���  � ��# �  ��  � ��# �  ��  � ��# �  P� 
 �@J�IsKeyboardFocusWithin . . ���  � ��# �  ��  � ��# �  ��  � ��# �  ]� ) �� * �@
 
IsSelected+ .  �� * �@J�IsMouseOver+ . ./���  � ��# �  ��  � ��# � 
 ��  � ��# �  ]� ) �� * �@
 
IsSelected+ . �� * �@��IsSelectionActive+ .  ./���  � ��# �  ��  � ��# �  ��  � ��# �  P� 
 � {� .  . ���  � ��# �  �� "  .���  � ��# � " ��  � ��$ 1,1,0,0q���  � ��# � $ ��  �@ SelectionMode$ Extended=���  �@ SelectionUnit$ FullRow=���  � �� . ��  �@ RowHeaderWidth$ 0Q���  �@J�SnapsToDevicePixels . ��  �@ CanUserReorderColumns .  ��   �@ HorizontalGridLinesBrush# � $ ��  �@ VerticalGridLinesBrush# � $ ��  �@ 	CellStyle8   ��  �@ ColumnHeaderStyle8  ��  �@ RowStyle8  ��  � �� �� "  .R��� #��z��#��z��#��z��._��� $��DG_ScrollViewer��|�.  ���� " ��.R��  �� $
��Auto ��� $��* ��� $
��Auto � �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��$��3��#��z��#��z���� $��0��$��0��#��Z3 |�.  E . ���� # �� "$  $( ColumnHeaderHeight����� # �� "$  $( RowHeaderActualWidth�  $��0��$��1��y��� # �� "$  $( HeadersVisibility�#" Z& # Z6 �� $��0��$��1��$��2��#8 z��$��Stretch=�$��Stretch=��� $��PART_VerticalScrollBar��$��1��$��2��$< Vertical=�#; z: #? z> #y�z= @ �� $( VerticalOffset�# �� *TemplatedParent+$A OneWay=�.���� # z ' P� 
 �@��
IsGrouping . . ���  � �� .  �� "   .���  � ��# �  ��  � ��# �  ��  �@�OverridesDefaultStyle . ��  �@J�SnapsToDevicePixels . ��  � �� �� "   .R��  �� $��* ��� $��1 � �� $��* ��� $
��Auto �.+��� $ BackgroundBorder��$��0��#��z��#��z��#��z��$��2���� $��0��$��5q�$��Center=��� " 
 .���  �@�OverridesDefaultStyle . ��  � ��$ Stretch=���  � ��$ Center=���  � �� �� " 
 .R�� #��z��#��z��.+��� #��z��$��3q�' P� 
 �@
 
IsSelected . . ���  � ��# �  ��  � ��# �  P� 
 �@J�IsMouseOver . . ���  � ��# �  ��  � ��# � 
 �� "  .���  �@ RowBackground# � " ��   �@ AlternatingRowBackground# � % ��  � ��# � " ��  � ��# � # ��  �@ SelectionMode$ Extended=���  �@ SelectionUnit$ FullRow=���  � �� . ��  �@ RowHeaderWidth$ 0Q���  �@J�SnapsToDevicePixels . ��   �@ HorizontalGridLinesBrush
 ���� ��  �@ VerticalGridLinesBrush
 ���� ��  �@ 	CellStyle8   ��  �@ ColumnHeaderStyle8  ��  �@ RowStyle8  ��  � �� �� "  .R��� #��z��._��� $��DG_ScrollViewer��|�.  ���� " ��.R��  �� $
��Auto ��� $��* ��� $
��Auto � �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��$��3��$��0q��� $��0��$��0��#��Z3 |�.  E . ���� # �� "$  $( ColumnHeaderHeight����� # �� "$  $( RowHeaderActualWidth�  $��0��$��1��y��� # �� "$  $( HeadersVisibility�#" Z& # Z6 �� $��0��$��1��$��2��#8 z���� $��PART_VerticalScrollBar��$��1��$��2��$< Vertical=�#; z: #? z> #y�z= @ �� $( VerticalOffset�# �� *TemplatedParent+$A OneWay=�.���� # z ' P� 
 �@��
IsGrouping . . ���  � �� .  �� "   .���  � ��# �  ��  � ��# �  ��  � ��# �  ��  � ��$ 0,0,1,1q���  �@  SeparatorVisibility$ Visible=���  � ��$	 5,1q���  � ��$ Center=���  � �� �� "   .R�� .+�  #��z��#��z��#��z��# z # z��# z # z��# z # z # z ._��� #��z����. # z #��z��n� $ PART_LeftHeaderGripper��$
��Left=�8��  n� $ PART_RightHeaderGripper��$��Right=�8�� 	 P� 
 �@J�IsMouseOver . . ��� # �   � ���� # �   � ��P� 
 � �� . . ��� # �   � ���� # �   � ���� "  .���  �@J�SnapsToDevicePixels . ��  �@=�ErrorTemplate Z� ��  �@ ValidationErrorTemplate �� .R��� #��z��$��2,0,0,0q�$��!��$��Center=���  � �� �� "  .R��� $ 
DGR_Border��#��z��#��z��#��z�� . ._�   �� $
��Auto ��� $��* � �� $��* ��� $
��Auto �.+�  $��1��#��z # z ' P� 
 �@ 	IsNewItem . . ���  � �� �� *NewItemMargin+# �� "$  �� " 
 .���  � ��
 ���� ��  � ��
 ���� ��  � ��$ 1q���  � ��$ Stretch=���  � ��$ Center=���  � �� �� " 
 .R��� #��z��#��z��#��z��#��z�� . ._��� #��z��# z ' P� 
 �@
 
IsSelected . . ���  � ��# �  ��  � ��# �  ��  � ��# �  P� 
 �@J�IsKeyboardFocusWithin . . ���  � ��# �  ��  � ��# �  ��  � ��# �  ]� ) �� * �@
 
IsSelected+ .  �� * �@J�IsMouseOver+ . ./���  � ��# �  ��  � ��# � 
 ��  � ��# �  ]� ) �� * �@
 
IsSelected+ . �� * �@��IsSelectionActive+ .  ./���  � ��# �  ��  � ��# �  ��  � ��# �  P� 
 � {� .  . ���  � ��# �  �� " 
 .���  �@��TextAlignment$ Right=���  � ��
 ���� ��  � ��
 ���� ��  � ��$ 1q���  � ��$ Stretch=���  � ��$ Center=���  � �� �� " 
 .R��� #��z��#��z��#��z��#��z�� . ._��� #��z��# z ' P� 
 �@
 
IsSelected . . ���  � ��# �  ��  � ��# �  ��  � ��# �  P� 
 �@J�IsKeyboardFocusWithin . . ���  � ��# �  ��  � ��# �  ��  � ��# �  ]� ) �� * �@
 
IsSelected+ .  �� * �@J�IsMouseOver+ . ./���  � ��# �  ��  � ��# � 
 ��  � ��# �  ]� ) �� * �@
 
IsSelected+ . �� * �@��IsSelectionActive+ .  ./���  � ��# �  ��  � ��# �  ��  � ��# �  P� 
 � {� .  . ���  � ��# �  �� " 
 .���  � ��# �  ��  � ��# �  ��  � ��
 ���� ��  � ��$ 0q���  � ��$ Stretch=���  � ��$ Center=���  � �� �� " 
 .R��� #��z��#��z��#��z��#��z�� . $ 2q�._��� #��z��# z $
��Bold"��� "  .���  � ��# �  ��  � ��# �  ��  � �� �� "  .R�� .+�  #��z��#��z��#��z��# z��# z #- z, $. 
Horizontal=�# z��# z/ # z0 ._��� $1 
Horizontal=�.+��� ��. # z $��Center=���  .  ���� *ValidationErrorTemplate+# �� "$  y��� *(Validation.HasError)+8"   # �� "$  n� $ PART_TopHeaderGripper��#���  $	��Top=�n� $ PART_BottomHeaderGripper��#���  $��Bottom=�	 P� 
 �@J�IsMouseOver . . ��� # �   � ��P� 
 � �� . . ��� # �    � ���� " ��.���  � ��# �  ��  � ��# �  ��  � ��# �  ��  � ��$ 0,0,1,1q���  � ��$ 3q���  � ��$ Center=���  � �� �� " ��.R��� #��z��#��z��#��z��._��� #��z����. # z #��z��	 P� 
 �@J�IsMouseOver . . ��� # �   � ���� # �   � ��P� 
 � �� . . ��� # �   � ���� # �   � ���� "  .���  �@ 
IsReadOnly . ��  � ��# � " ��  � ��# � # ��  � ��# � $ ��  � ��$ 1q���   �@ RowDetailsVisibilityMode$ VisibleWhenSelected=���  � �� . ��  �@��PanningMode$
 Both=���  �@��IsFlicksEnabled .  ��  �@ AutoGenerateColumns . ��  �@ CanUserAddRows .  ��  �@ CanUserReorderColumns . ��  �@ CanUserResizeColumns . ��  �@ CanUserResizeRows . ��  �@ CanUserSortColumns . ��  �@��AlternationCount$ 2����   �@ AlternatingRowBackground# � % ��  �@ RowBackground# � & ��   �@ HorizontalGridLinesBrush# � ' ��  �@ VerticalGridLinesBrush# � ( ��  �@ ColumnHeaderStyle8   ��  �@ RowStyle8  ��  �@ 	CellStyle8  ��  �@ RowHeaderStyle8  ��  � �� �� "  .R��� #��z��#��z��#��z��# z�� . ._��� $2 DG_ScrollViewer��|�.  ���� " ��.R��  �� $
��Auto ��� $��* ��� $
��Auto � �� $
��Auto ��� $��* ��� $
��Auto �.+��� #��Z3 |�.  #��� : y��� *HeadersVisibility+# Z4 #" Z& # �� "$  ���� *CellsPanelHorizontalOffset+# �� "$    $!5 PART_ColumnHeadersPresenter��$��1��y��� *HeadersVisibility+# Z6 #" Z& # �� "$  �� $!7 PART_ScrollContentPresenter��#8 z��$��2��$��1���� $9 PART_VerticalScrollBar��$��2��#; z: $< Vertical=�$��1��#y�z= #? z> @ �� *VerticalOffset+$A OneWay=�# �� *TemplatedParent+� $��1��$��2�� �� ���� **(NonFrozenColumnsViewportHorizontalOffset+# �� "$  �� $��* �.+��� $9 PART_HorizontalScrollBar��$��1��#; zB $< 
Horizontal=�#y�zC #? zD @ �� *HorizontalOffset+$A OneWay=�# �� *TemplatedParent+.���� # z ' ]� ) �� * �@��
IsGrouping+ . �� "* �@%�IsVirtualizingWhenGrouping+ .  ./���  � �� .  P� 
 �@ HeadersVisibility$ Column=�. ���  �@ RowHeaderWidth$ 0Q�