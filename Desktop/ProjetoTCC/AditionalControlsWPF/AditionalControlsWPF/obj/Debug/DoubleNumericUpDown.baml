   M S B A M L   `   `   `  ����O  KAditionalControlsWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:AditionalControlsWPFAditionalControlsWPF  5      .    (AditionalControlsWPF.DoubleNumericUpDown   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:AditionalControlsWPF     5      .��5	      � -   5          �Name$  Grid1��5	       � RowDefinitions 5
   
   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��25 �6   .+�5   
   �� -   5         ��Name$ txtValue��5      $��0��6H   $��Center=�6X   $��2��6+  ��6z   ��  �� RelativeSource ��  �� AncestorType$ UserControlL� �� Path$
 Text���6�   ��  �� $ UserControlL�$ FontSize���6<  ��  �� $ UserControlL�$ 
Foreground�6�  �� 5   
   -   5         ��Name$ btnIncrease��5      $��1��6&   $��0��66   ���#444$��10(�6U   ���#ccc$	��▲��6u   $��0q�6�    � Cursor 6�   ��  �� $ UserControlL�$ Cursor�6�   �� 5   
   -   5        $ btnDecrease��5      $��1��6&   $��1��66   
�������$��10(�6Y   $	��▼��6g   $��0q�6s    6�   ��  �� $ UserControlL�$ Cursor�6�   5      5      