   M S B A M L   `   `   `  ���� E  AProjetoTCC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ProjetoTCC
ProjetoTCC      ProjetoTCC.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:ProjetoTCC       � Language$  pt-BR� � Title$ 
MainWindow��$	��768��$
��1366�� � WindowState$ 	Maximized=� � WindowStyle$
 None=�$	��800��$	��600��.��� ����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF228095�� � Offset$ 0Q�� $ 	#FF005B76��$ 1Q� � ColumnDefinitions �� $��48 ��� $��1* �	 � RowDefinitions	 �� $��48 ��� $��1* �
 � 	Resources
    expandButton �� 
TargetType  defaultButton �� BasedOn �� Property �� Value  leftMenuWidthNormal  menuLateral �� 	Resources  leftMenuWidthExpanded �� ElementName �� 
TargetType �� Triggers P� Property P� Value ^� 
Conditions �� Binding1  +System.Diagnostics.PresentationTraceSources   
TraceLevel �� Value �� UpdateSourceTrigger N� EnterActions �� BeginStoryboardName ��Name �� TargetProperty	 W� To g� Duration  :� RoutedEvent 
 lblTop  strHome��%8  &	        7  7  &	 �     7  7  7  7  7  7  7  7  7  7  &	 6    �� " ��8   .���  � ��$ Segoe MDL2 Assets)���  � ��$	 ����  � ��$ 20(���  � �� �#333��  � ��
 �������  � ��$ 2����  � ��8  ��  � ��$
 Left=��� " ]�.���  � ��8   ��  � ��$
 Left=���  � �� �#eee��  � ��$ 1����  � ��$ 0����  � ��$ 2�� ���� '��       " ��8  .���  � ��$ Segoe UI Light)���  � ��8  ��  � ��$ 44����  � �� �#333��  � ��$ 16(���  � �� �� *
Background+$ menuLateral����  � �� �� " ��.R��� #��z��$��0q�._��� $
��Left=�$��Center=� P�  �@J�IsMouseOver . . ���  � �� �� $ 0,0.5&�$ 1,0.5&�.��� $ 	#FFDDDDDD��$ 1Q�� $ 	#FFC6C6C6��$ 0Q���  �@J�Opacity$ 1Q� ���� '��       " ��.���  � ��$ Segoe MDL2 Assets)���  � ��$ 9,0,0,0q���  � ��$ 21(���  � �� �#333�� '��       " ��.���  � ��8  ��  � ��$ 5����  � ��$ 0,0,0,0q���  � ��$
 Left=���  � �� �#bbb ^�  ��  �� *	IsPressed+$ btnExpandirMenu��$
 High=� True�� 8   �� *Width+$ menuLateral��$
 High=�$ PropertyChanged=� �� $	 OUT���� $ FECHAR���� $ IN��.���� .��W� $ Width�8  $ 0:00:0.2D�^�  ��  �� *	IsPressed+$ btnExpandirMenu�� True�� 8   �� *ActualWidth+$ menuLateral�� �� $ IN���� $	 IN2���� $	 OUT��.���� .��W� $ Width�8  $ 0:00:0.2D�:� $  DockPanel.MouseEnter��.[��� $	 OUT���� $ FECHAR���� $	 IN2��.���� .��W� $ Width�8  $ 0:00:0.2D�:� $  DockPanel.MouseLeave��.[��� $ IN���� $	 IN2���� $ FECHAR��.���� .��W� $ Width�8 	 $ 0:00:0.2D��� " ��.���  � ��$ 48����  � ��$ Center=���  � ��$ 18(���  � ��$ 10,0,0,0q���  � ��
 �������  � ��$ Light"���  � ��# �  .+��� $��1��$��0�����#555! J� Effect! 3  -System.Windows.Media.Effects.DropShadowEffect  "   ShadowDepth$" 0Q�#   
BlurRadius$# 2Q�.+��� -   $ ��Name$$ lblOpenedPage��#��[ $��
10,0,100,0q�� $��1��$��1��$��15q����#fff!   $" 0Q�$# 7Q�%   	Direction$	% 300Q�&   Opacity$& 0.865Q�'   Color$' 	#FF0F0044��.+� � -   $��fmPage���� -   $��btnExpandirMenu��
�������#��[  ]� -   $��menuLateral����. #��[ .+��� -   $��btnHome��$	��Top=�.��� .+��� $	������ $��20,6,0,0q�#���  �� $	��Top=��� -   $��btnProdutos��$	��Top=�.��� .+��� $)��#../../Assets/Icons/product_icon.png��$��11,0,0,0q�$��25��$��25��$
��Fill=��� $��25��$��24,0,0,0q�$��Produtos���� -   $��btnSuppliers��$	��Top=�.��� .+��� $%��../../Assets/Icons/provider.png��$��13,0,0,0q�$��23��$��25��$
��Fill=��� $��25��$��24,0,0,0q�$��Fornecedores���� -   $��	btnOrders��$	��Top=�.��� .+��� $'��!../../Assets/Icons/order-icon.png��$��11,0,0,0q�$��25��$��23��$
��Fill=��� $��25��$��24,0,0,0q�$��Entrega���� -	   $��btnUsers��$	��Top=�.��� .+��� $$��../../Assets/Icons/id-card.png��$��11,0,0,0q�$��25��$��23��$
��Fill=��� $��25��$��24,0,0,0q�$��Usuarios���� -
   $��btnCaixa��$y�Visible=�$	��Top=�.��� .+��� ���	#FFFFC604$��6,0,0,0q�$��25(�$	������ $��20,6,0,0q�$��Caixa���� -   $��	btnVendas��$y�Visible=�$	��Top=�.��� .+��� ���#20BE96$��6,0,0,0q�$��25(�$	������ $��20,6,0,0q�$��Vendas���� -   $��btnMensagem��$y�Visible=�$	��Top=�.��� .+��� 
����  �$��6,0,0,0q�$��25(�$	������ $��20,6,0,0q�$��Mensagem���� -   $��
btnClients��$y�Hidden=�$	��Top=�.��� .+��� ���#26B000$	������ $��20,6,0,0q�  
strClients#���  �� -   $��btnSettings��$��Bottom=�.��� .+��� $	������ $��20,4,0,0q�  strSettings#���  �� $��Bottom=��� $��0��$��0���� -   ( ��Name$( buttonClose��$��X��$��1�� 	 close-circle#��[	 $
��Left=�$��
1272,7,0,0q����#C33838
�������$	��Top=�$��34��$��34��