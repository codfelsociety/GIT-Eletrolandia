   M S B A M L   `   `   `  ���� E  AProjetoTCC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ProjetoTCC.Assets.PagesProjetoTCC.Assets.Pages  ;"clr-namespace:ProjetoTCC.ViewModelProjetoTCC.ViewModel  *    $ProjetoTCC.Assets.Pages.PaginaVendas   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:ProjetoTCC.Assets.Pages     1vm"clr-namespace:ProjetoTCC.ViewModel       � Language$  pt-BR� N� 
Background
 ����� N� Title$ PaginaVendas�� � DataContext *   $ProjetoTCC.ViewModel.VendasViewModel  .��� .+�&   System.Windows.Controls.DataGrid  -     Name$ dataGrid��$��25(�   AutoGenerateColumns .     CanUserAddRows .  $
��Left=�$	��301��$��	10,70,0,0q�$	��Top=�$
��1268�� �� SelectedItem �� *VendaSelecionada+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=����� *Vendas+$ TwoWay=�$	 PropertyChanged=�
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	COD_VENDA��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
ID_VENDA+  $ 
DATA_VENDA�� �� *
DATA_VENDA+�� $
��Left=�$��60��$	��Top=�$
��1288�����	#FFF4F4F5�� -    ��Name$ label��$��Total Hoje:��$
��Left=�$��9,10,0,0q�$	��Top=�$��24(�$-��'/ProjetoTCC;component/Fonts/#Lemon/Milk)��� -    ��Name$ 	textBlock��$
��Left=�$��
183,15,0,0q�$
��Wrap=�$	��Top=�$��40��$	��183��$��24(����� *	TotalHoje+$ TwoWay=�$	 PropertyChanged=� �� StringFormat$ {0:C}��  -   $ 	dataGrid1��$��25(� .   .  $
��Left=�$	��269��$��
10,397,0,0q�$	��Top=�$
��1268������ *ProdutosVenda+$ TwoWay=�$	 PropertyChanged=�
   $
 Nome�� �� *NOME+  $ Preço�� �� *
PRECO_UNIT+$ {0:C}��  $ 
Quantidade�� �� *
QUANTIDADE+