   M S B A M L   `   `   `  ���� E  AProjetoTCC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:ProjetoTCC.Assets.Pages.InSuppliers#ProjetoTCC.Assets.Pages.InSuppliers  8    2ProjetoTCC.Assets.Pages.InSuppliers.SuppliersCover   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Clocal1clr-namespace:ProjetoTCC.Assets.Pages.InSuppliers       N� Title$  SuppliersCover�� � 	Resources  #  Body_Content_DataGrid_Centering �� 
TargetType*  $System.Windows.Controls.DataGridCell �� Property �� Value �� 
TargetType 	 price �� Color  nice&   System.Windows.Controls.DataGrid  ok)  #System.Windows.Controls.DataGridRow �� Triggers P� Property	 P� Value  rhs:  4System.Windows.Controls.Primitives.DataGridRowHeader��%  &	        &	 L     &	 �     &	 
    &	 �    �� "  .���  � �� �� "  .R�� #��z��.+��� $��Center=��� "  .���  � �� �� "  .R�� #��z��.+��� $��Center=���  � �� �� $ 	#FF007400���� "  .���  � �� �#fff��  �@��AlternationCount$ 2���� "   P�  �@��AlternationIndex$	 1��. ���  � �� �#eeeP�  �@��AlternationIndex$	 0��. ���  � ��
 ������� "  .���  � ��
 �  ����  � ��$ 20(�.��� .+�  -   
  Name$
 	dataGrid1��   GridLinesVisibility$
 None=�#��[    RowHeaderStyle# [    RowStyle# [    	CellStyle# [     AutoGenerateColumns .  $��20(�$��Nirmala UI Semilight)�   CanUserReorderColumns .     CanUserResizeColumns .     CanUserAddRows .     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ ID��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *COD+     
Foreground
 ��  � . $
 Nome�� �� *NOME+   . $
 CNPJ�� �� *CNPJ+ �� StringFormat$ ## ### ### / ####-##��  
 ��  � . $ Ins. Estadual�� �� *INS_ESTADUAL+$ ### ### ### ###��   . $ Cidade�� �� *CIDADE+  
 ��  � . $ UF�� �� *UF+   . $ Bairro�� �� *BAIRRO+  
 ��  � . $	 Rua�� �� *RUA+   . $ Telefone�� �� *
TELEFONE+$ (##) ####-####��  
 ��  � . $ Celular�� �� *	CELULAR+$ (##) #####-####��   . $ Email�� �� *EMAIL+  
 ��  � . $	 Cep�� �� *CEP+$ {0:#####-###}��