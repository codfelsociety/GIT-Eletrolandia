   M S B A M L   `   `   `  ���� O  KAditionalControlsWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:AditionalControlsWPFAditionalControlsWPF  &     AditionalControlsWPF.ImagePicker   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     4local"clr-namespace:AditionalControlsWPF     -   $��uc��  #� VisualTextRenderingMode$  Aliased=� �� BitmapScalingMode$ HighQuality=����#ccc$	��0.5q�.���  � 	Resources    lvitemstyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup	   States   System.Windows.VisualState
   
Storyboard �� 
TargetName �� TargetProperty8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value��%�  &	        �� " ��.���  � ��$ 5,-1,0,0q���  � �� �� " ��.R��� $ border��
������    CommonStates��.	   
Normal��  Disabled��  SelectionStates��.	   
Unselected��  Selected��.
 �� .���� $ border��$0 *(Panel.Background).(SolidColorBrush.Color)�.g�  $ 0��$ 	LightBlue��  SelectedUnfocused��.
 �� .���� $ border��$0 *(Panel.Background).(SolidColorBrush.Color)�.g�  $ 0��$ SkyBlue��._��� .+��� -   $��
listImages��#��[  $��-7, -2,-3,-4q�$��0,0,39,0q�$��Disabled=�
�����������  �� ElementName$ uc�� �� Path$ Height���Z� ���� .R�� ���� .R�� $
��lvit��
����������� $ uc��$ Height� � ColumnDefinitions �� ���� $ uc��$ Height�.+���  J� Opacity$ 1Q�$
��Fill=����� *Image+�� ���#ccc$��1��$	��Top=�$��Right=����� $ uc��$ Height����� $ uc��$ Height����� " �����  � �� Z� ��  �@J�Opacity$ 1Q� �� Triggers ��  �� Binding �� $
 lvit��$ IsMouseOver� �� Value True.a���  � �� 
� .���  � Color$ 	#00000000�� � Offset$ 0.418Q�� $ 	#86021C49��$ 1Q�� $ 	#5C005687��$ 0.728Q��� -   ���� " �����  � �� �#ff6666��  �@�Cursor$
 Hand����  � ��$
 30px����  � ��$
 30px����  � ��$ 0,1,1,0q���  �@J�Opacity$	 0.8Q���  � ��$	 Top=���  � ��$ Right=���  � y�$ Hidden=� P�  P� Property �@J�IsMouseOver P� Value . . ���  � �� �#B00F0F��  � ��$ 1����  �� $ labelX��$ IsMouseOver� True.a���  � �� �#B00F0F��  � ��$ 1����  �� $
 lvit��$ IsMouseOver� True.a���  � y�$ Visible=��� $��labelX��-    ��%<  '��       �� " �����  � ��$	 Top=���  �@�Cursor$
 Hand����  � ��
 �������  � ��$
 Bold"���  � ��$ Italic$���  � ��$ Right=���  � ��$ 0,3,8,0q���  � y�$ Hidden=� ��  �� $
 lvit��$ IsMouseOver� True.a���  � y�$ Visible=� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 3Q�   ShadowDepth$ 2Q�$��X��� ���� " �.���  � ��$ 40����  � ��$ Right=� � RowDefinitions �� $
��0.5* ��� $
��0.5* �.+��� -   $��recAdd������ " ��.���  � �� �#A0FFD5��  � ��$ 0,1,0,0q� ��  �� $ 	labelPlus��$ IsMouseOver� True.a���  � �� �#F2FF62P�  �@J�IsMouseOver . . ���  � �� �#F2FF62��  �@�Cursor$
 Hand���� -   $��	labelPlus��$��24(�$��Segoe MDL2 Assets)����#00566A$��8,0,0,0q�$��0,2,0,0q�$��Center=����� " �� P�  �@J�IsMouseOver . . ���  �@�Cursor$
 Hand��.���� -   $��recDeleteAll��$��1������ " ��.���  � �� �#FFD1A0��  � ��$ 0,1,0,0q� ��  �� $ labelDeleteAll��$ IsMouseOver� True.a���  � �� �#F2FF62P�  �@J�IsMouseOver . . ���  � �� �#F2FF62��  �@�Cursor$
 Hand���� -   $��labelDeleteAll��$��1��$��24(�$��Segoe MDL2 Assets)����#6A0000$��9,0,0,0q�$��0,2,0,0q�$��Center=����� " �� P�  �@J�IsMouseOver . . ���  �@�Cursor$
 Hand��.��