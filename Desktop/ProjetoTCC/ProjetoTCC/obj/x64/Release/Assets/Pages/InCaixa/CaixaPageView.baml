   M S B A M L   `   `   `  ���� E  AProjetoTCC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:ProjetoTCC.Assets.Pages.InCaixaProjetoTCC.Assets.Pages.InCaixa  ;"clr-namespace:ProjetoTCC.ViewModelProjetoTCC.ViewModel  J FProjetoTCC.Util, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD3clr-namespace:Util.Convert;assembly=ProjetoTCC.UtilUtil.Convert O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem O KAditionalControlsWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY@clr-namespace:AditionalControlsWPF;assembly=AditionalControlsWPFAditionalControlsWPF 3    -ProjetoTCC.Assets.Pages.InCaixa.CaixaPageView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ?local-clr-namespace:ProjetoTCC.Assets.Pages.InCaixa     X	 TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f46custom)http://schemas.xceed.com/wpf/xaml/toolkit 	 2	viewmodel"clr-namespace:ProjetoTCC.ViewModel 	 C	converter3clr-namespace:Util.Convert;assembly=ProjetoTCC.Util 	 3System&clr-namespace:System;assembly=mscorlib 	 Jadc@clr-namespace:AditionalControlsWPF;assembly=AditionalControlsWPF 	 -     � Language$  pt-Br� N� 
Background
 ����� N� Title$ CaixaPageView�� � 	Resources  �� MergedDictionaries �� Source��  �� $ CaixaViewResources.xaml?�%    .��� ����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF4A1B8D��	 � Offset$	 0Q�� $ 	#FF1B7C7C��$	 1Q�.+��� ���	#FFECECEC$
��Left=�$��72��$��	10,10,0,0q�$	��Top=�$	��706���� ���	#FFB9FF88$
��Left=�$��73��$��724,560,0,0q�$	��Top=�$	��454���� ���	#FF939393$
��Left=�$	��541��$��
724,10,0,0q�$	��Top=�$	��554��
 J� Opacity$	
 0.5Q��� ���	#FF404040$
��Left=�$��54��$��740,267,0,0q�$	��Top=�$	��218���� ���	#FF404040$
��Left=�$��54��$��740,409,0,0q�$	��Top=�$	��218���� ���	#FF404040$
��Left=�$��54��$��740,338,0,0q�$	��Top=�$	��218���� $
��Left=�$	��219��$��
740,28,0,0q�$	��Top=�$	��219������  �� Color$ 	#CCF3F3F3�� �� Opacity$	 0.5Q��� -    ��Name$ 
label_Copy��$��Right=�$��Preço��$
��Left=�$��752,263,0,0q�$	��Top=�$��54��$	��198��$��36(����	#FFE8E8E8�� -   $ label��$��Inserir Produto:��$
��Left=�$��	21,26,0,0q�$	��Top=�$��40��$	��168��$��24(��� -   $ label_Copy2��$��Right=�$��
Total Item��$
��Left=�$��752,405,0,0q�$	��Top=�$��54��$	��198��$��36(����	#FFE8E8E8�� -   $ label_Copy1��$��Right=�$��
Quantidade��$
��Left=�$��752,334,0,0q�$	��Top=�$��54��$	��198��$��36(����	#FFE8E8E8�� -   $ label1��$��TOTAL:��$
��Left=�$��736,576,0,0q�$	��Top=�$��48��$	��108��$��25(�$
��Bold"�$��Italic$����	#FF013A0E�� -    ��Name$ btnCancelar��$��X��$
��Left=�$��1207,481,0,0q�$	��Top=�$��54��$��50��$��20(�$��Microsoft JhengHei)����	#FFBD2F2F
������� J� RenderTransformOrigin$ 
0.833,0.35&����� *RemoverItem+��Z� �� -   $ btnAdicionar��$��	Confirmar��$
��Left=�$��963,481,0,0q�$	��Top=�$	��239��$��50��$��20(�$��Microsoft JhengHei)����	#FF04126E
�������$ 
0.833,0.35&����� *	Confirmar+1  +System.Diagnostics.PresentationTraceSources   
TraceLevel$
 High=���Z� �� -	   $ btnNext��$��>��$
��Left=�$��1185,559,0,0q�$	��Top=�$��95��$��75��$��50(�$��
Lucida Fax)�$��Italic$�$
��Bold"����	#FF72FF53���	#FF053A03��Z� ���� *OpenPagamento+&   System.Windows.Controls.DataGrid  -
     Name$ DataGridAdicionados��   nice#��[  $��	10,92,0,0q�$	��542������ *ProdutosCompra+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem �� *ItemSelecionadoCarrinho+$ PropertyChanged=�   Columns 4  .System.Windows.Controls.DataGridTemplateColumn    img,  &System.Windows.Controls.DataGridColumn   	CellStyle# [    Header$  ��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 45    
IsReadOnly .    CellTemplate �� .R���  �� BitmapScalingMode$ HighQuality=����� *	Picture+0  *System.Windows.Controls.DataGridTextColumn   . $ Id��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+   . $
 Nome�� 	 price# [  �� *Nome+   . $ Preço�� �� *Preco+ �� StringFormat$ {0:C}��  $ 
Quantidade�� . # [  �� *
Quantidade+ �� Mode$ TwoWay=�$ PropertyChanged=�   . $ 
Total Item�� �� *	TotalItem+$ {0:C}��$ TwoWay=�$ PropertyChanged=� � ContextMenu �� .@�m� $��Remover�� m� Command$  ��  m� Icon  ��   x-small#��[ �� -   ! ��Name$! txtPesquisa��  base#��[ $��
194,26,0,0q����� *TextoPesquisa+$ TwoWay=�$ PropertyChanged=��� -   " ��Name$" 
imgProduto��$
��Left=�$	��219��$��
740,28,0,0q�$	��Top=�$	��218������ *Imagem+�� -   $! txtPreco��$��963,267,0,0q�  co#��[ ���� *Preco+$ TwoWay=�$ PropertyChanged=�$ {0:C}���� -   $! txtTotalItem��$��963,409,0,0q�#��[ ���� *	TotalItem+$ PropertyChanged=�$ TwoWay=�$ {0:C}��(  "AditionalControlsWPF.NumericUpDown  -   #  Name$# txtQuantidade��  nudQuant#��[ $��964,339,0,0q�$   MaxValue$$ 98��%   Value% �� *
Quantidade+$ TwoWay=�$ PropertyChanged=��� -   $! txtNomeProduto��$��964,194,0,0q�#��[ ���� *Nome+$ PropertyChanged=��� -   & ��Name$& lblTotal��$��Center=�' �� TextAlignment$' Right=�$
��Left=�$��913,579,0,11q�$��54��$	��247��$��28(����	#FF1F1F1F$
��Bold"�$ 0.481,0.427&����� *Total+$ {0:C}��$ TwoWay=�$ PropertyChanged=��� -   ( ��Name$( 
SearchList��  
SearchList#��[ $��
194,66,0,0q����� *ItensPesquisados+$ TwoWay=�$ PropertyChanged=� �� *ItemSelecionadoPesquisa+���� .R��  	 grido#��[ ) � ColumnDefinitions) �� $	��120 ��� $��1* �.+��� ���� * �� ImageSource$@* :/ProjetoTCC;component/Assets/Imagens/default_new_image.jpg��+ j� Stretch$+ UniformToFill=��� $ HighQuality=����� *	Picture+�� $��25(�$��	15,15,0,0q� 	 	textblock#��[	 ���� *Nome+�� $��	15,40,0,0q�#��[	 ���� *	CodBarras+�� $
��COD:��$��	15,75,0,0q�$��SemiBold"�#��[	 �� $��	75,75,0,0q�$��SemiBold"�#��[	 ���� *Id+�� $��PREÇO:��$��
167,75,0,0q�$��SemiBold"�#��[	 �� $��
240,75,0,0q�$��SemiBold"����#0D8D02#��[	 ���� *Preco+$ R$ 0.00������ , �� 
TargetType", ��.�-   