   M S B A M L   `   `   `  ���� O  KAditionalControlsWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY@clr-namespace:AditionalControlsWPF;assembly=AditionalControlsWPFAditionalControlsWPF  E AProjetoTCC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:ProjetoTCC.Assets.Pages.InCaixaProjetoTCC.Assets.Pages.InCaixa ;"clr-namespace:ProjetoTCC.ViewModelProjetoTCC.ViewModel 7   1ProjetoTCC.Assets.Pages.InCaixa.PaginaDePagamento   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     aAditionalControlsWPF@clr-namespace:AditionalControlsWPF;assembly=AditionalControlsWPF     ?local-clr-namespace:ProjetoTCC.Assets.Pages.InCaixa     X TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f46custom)http://schemas.xceed.com/wpf/xaml/toolkit  2	ViewModel"clr-namespace:ProjetoTCC.ViewModel    � Language$  pt-BR� N� Title$ 	Pagamento��$	��644��$
��1288�� #� VisualTextRenderingMode$ 	ClearType=� N� 
Background ��  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&� �� RelativeTransform V� .~���  �� CenterY$	 0.5Q� �� CenterX$	 0.5Q��� 	 �� CenterY$		 0.5Q�
 �� CenterX$	
 0.5Q���  �� Angle$ 118.61Q� �� CenterY$	 0.5Q� �� CenterX$	 0.5Q�T� .���  � Color$ 	#FF143899�� � Offset$ 0Q�� $ 	#FF4BE6FF��$ 1Q�.��� .+��� $
��Left=�$��52��$��
33,202,0,0q�$	��Top=�$	��350�����	#19000000�� $
��Left=�$��52��$��
34,576,0,0q�$	��Top=�$	��350��
��������� ���	#FFF3F3F3$
��Left=�$��43��$��
33,101,0,0q�$	��Top=�$	��350���� -    ��Name$ label1_Copy��$��TOTAL:��$
��Left=�$��
43,204,0,0q�$	��Top=�$��52��$	��131��$��30(�
�������$
��Bold"�$��Source Sans Pro)��� -   $ label1_Copy2��$��
Pagamento:��$
��Left=�$��
106,20,0,0q�$	��Top=�$��59��$	��222��$��36(�$
��Bold"�$��Italic$�
�������$��Segoe UI Light)� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  �� -   $ label1_Copy6��$��FRETE:��$
��Left=�$��
43,102,0,0q�$	��Top=�$��42��$	��131��$��24(����	#FF1B1B1B$
��Bold"�$��Source Sans Pro)��� ���	#FFF3F3F3$
��Left=�$��44��$��
33,151,0,0q�$	��Top=�$	��350���� -   $ label1_Copy12��$��	SUBTOTAL:��$
��Left=�$��
43,154,0,0q�$	��Top=�$��43��$	��183��$��24(����	#FF1B1B1B$
��Bold"�$��Source Sans Pro)��� -    ��Name$ chkEntregar��$�� ��$
��Left=�$��
566,39,0,0q�$	��Top=�$��22(�$��Center=��� -    ��Name$ btnDinheiro��$��Dinheiro��$
��Left=�$��
32,259,0,0q�$	��Top=�$	��133��$��54��$��24(�$��Microsoft JhengHei UI)����	#FF3FE97D���	#FF0C1F40��Z�       
BlurRadius$ 0Q�   Opacity$	 0.5Q�   ShadowDepth$ 1Q��� -   $ 
btnCredito��$��Crédito��$
��Left=�$��170,259,0,0q�$	��Top=�$	��105��$��54��$��24(�$��Microsoft JhengHei UI)����	#FFFFDE49���	#FF0C1F40��Z�    $ 0Q�$	 0.5Q�$ 1Q��� -   $ 	btnDebito��$��Débito��$
��Left=�$��279,259,0,0q�$	��Top=�$	��105��$��54��$��24(�$��Microsoft JhengHei UI)����	#FFFFEE3F���	#FF0C1F40��Z�    $ 0Q�$	 0.5Q�$ 1Q��� -	   $
��Left=�   return-circle#��[  ���	#FF3AAFDF$��	32,26,0,0q�$	��Top=�$��60��$��60��
��������� -
   $ btnConfirmar��  confirm-circle#��[ $
��Left=�$��1196,553,0,0q�$	��Top=�$��75��$��75�����	#4CFFFFFF
�������{��� *StatusConfirmar+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=����� *	Confirmar+�� $
��Left=�$��
44,578,0,0q�$	��Top=�$��52��$	��131��$��30(�
�������$��Source Sans Pro)����� *	TextoInfo+$ TwoWay=�$ PropertyChanged=� �� FallbackValue$ TROCO��      Color$ White��$ 0Q�$ 6Q���  �� TextAlignment$ Right=�$
��Left=�$��183,208,0,0q�$	��Top=�$��39��$	��183��$��30(�$
��Bold"�
����������� *Total+ �� StringFormat$ {0:C}��$ PropertyChanged=��� -    ��Name$ lblTroco��$
��Left=�$ Right=�$��154,582,0,0q�$	��Top=�$��38��$	��220��$��30(�
�������$��Source Sans Pro)����� *Troco+$ PropertyChanged=�$ TwoWay=�$ {0:C}��   $ White��$ 0Q�$ 6Q��� $
��Left=�$��183,157,0,0q�$ Right=�$	��Top=�$��32��$	��191��$��24(����	#FF1B1B1B$
��Bold"�$��Yu Gothic UI Semibold)����� *Total+$ PropertyChanged=�$ {0:C}��$ R$ 0,00���� $��R$ 0,00��$
��Left=�$��154,106,0,0q�$ Right=�$	��Top=�$��45��$	��220��$��24(����	#FF1B1B1B$
��Bold"�$��Yu Gothic UI Semibold)�� $
��Left=�$��60��$��416,101,0,0q�$	��Top=�$	��448�����	#4CFFFFFF.+��� -   $ label3��$
��CPF:��$
��Left=�$��10,6,0,0q�$	��Top=� J� RenderTransformOrigin$ 0.908,1.288&�$��24(�%  Xceed.Wpf.Toolkit.MaskedTextBox     Mask$ 000,000,000-00��$
��Left=�$��36��$��	73,11,0,0q�  �� TextWrapping$
  Wrap=�$	��Top=�$	��365��$��22(�$��5,0,0,0q����� *Cpf+$ TwoWay=�$ PropertyChanged=���Z� � -   ! �Name$! 	gridVista��$
��Left=�$��50��$��
33,320,0,0q�$	��Top=�$	��350�����	#FFFCFCFC$y�Hidden=�.+��� -   $ label1_Copy5��$��Val. Recebido:��$
��Left=�$��2,7,0,0q�$	��Top=�$��36��$	��157��$��24(����	#FF1B1B1B$��Berlin Sans FB)�$��Right=�*   $AditionalControlsWPF.CurrencyTextBox  $
��Left=�$��	159,7,0,0q�$
  Wrap=�$	��Top=�$��36��$	��184��$��22(�$	��5,0q�"   Number" �� *ValorRecebido+$ {0:C}��$ TwoWay=�$ PropertyChanged=���Z� � -   $! 	gridPrazo��$
��Left=�$	��143��$��
33,377,0,0q�$	��Top=�$	��350�����	#FFC1C1C1$y�Hidden=�.+��� -   $ label1_Copy7��$��Val. à Pagar:��$
��Left=�$��2,10,0,0q�$	��Top=�$��43��$	��153��$��24(����	#FF1B1B1B$��Berlin Sans FB)�$��Right=��� -   $ label1_Copy8��$��Em��$
��Left=�$��	98,53,0,0q�$	��Top=�$��36��$��56��$��24(����	#FF1B1B1B$��Berlin Sans FB)�$��Right=��� -   $ label1_Copy9��$��vezes��$
��Left=�$��
273,53,0,0q�$	��Top=�$��36��$��67��$��24(����	#FF1B1B1B$��Berlin Sans FB)�$��Right=��� -   $ label1_Copy10��$��De��$
��Left=�$��	98,96,0,0q�$	��Top=�$��36��$��56��$��24(����	#FF1B1B1B$��Berlin Sans FB)�$��Right=�  -   #  Name$# txtValPagar��$
��Left=�$��
158,11,0,0q�$
  Wrap=�$	��Top=�$��36��$	��185��$��22(�$	��5,0q���Z� (   "AditionalControlsWPF.NumericUpDown  -   $  Name$$ 	nudXvezes��$
��Left=�$��
159,53,0,0q�$	��Top=�$	��109��$��36�����	#FF819EFF$��1q�$��22(�  -   $# txtXde��$
��Left=�$��
158,96,0,0q�$
  Wrap=�$	��Top=�$��36��$	��185��$��22(�$	��5,0q�% �� 	IsEnabled% . ��Z� 9� -   & 9�Name$& expander��$��À entregar��$
��Left=�$	��445��$��
398,28,0,0q�$	��Top=�$	��818��$��28(���Z� .��� 
�������.+�� $
��Left=�$��57��$��	12,12,0,0q�$	��Top=�$	��794�����	#FFDBDCCF.+��� ���	#FF959595$
��Left=�$��35��$��
316,11,0,0q�$	��Top=�$	��144���� -   $ label2��$��Nome:��$
��Left=�$��3,7,0,0q�$	��Top=�$��22(��� -   $ label2_Copy��$��Sexo:��$
��Left=�$��	318,8,0,0q�$	��Top=�$��22(����	#FFF9F9F9�� -   $ label2_Copy1��$
��CPF:��$��	461,7,0,0q�$	��Top=�$��22(�$��Right=�$
��Left=�$��53���� -   ' ��Name$' txtNomeCliente��$
��Left=�$��35��$��	80,11,0,0q�$
  Wrap=�$�� ��$	��Top=�$	��228��$��22(�$��5,0,0,0q�	� $��M��$
��Left=�$��
379,15,0,0q�$	��Top=�$��Center=�$��22(����	#FFF9F9F9( d� 	IsChecked$
( TrueY�) 	� 	GroupName$) rbSexo��	� -   * 	�Name$* radioButton_Copy��$��F��$
��Left=�$��
423,15,0,0q�$	��Top=�$��Center=�$��22(����	#FFF9F9F9$) rbSexo��  $ 000,000,000-00��$
��Left=�$��35��$��
516,11,0,0q�$
  Wrap=�$	��Top=�$	��269��$��22(�$��5,0,0,0q�� $
��Left=�$	��145��$��	12,77,0,0q�$	��Top=�$	��794�����	#FFD8D8D8.+��� -   $ label2_Copy2��$��Estado:��$
��Left=�$��	246,6,0,0q�$	��Top=�$��22(��� -   $ label2_Copy3��$��Cidade:��$
��Left=�$��	488,6,0,0q�$	��Top=�$��22(��� $
��CEP:��$
��Left=�$��10,6,0,0q�$	��Top=�$��22(�$ 0.231,0.385&��� -   $ label2_Copy5��$��Bairro:��$
��Left=�$��	10,50,0,0q�$	��Top=�$��22(��� -    $ label2_Copy6��$
��Rua:��$
��Left=�$��
280,50,0,0q�$	��Top=�$��22(�$ 0.231,0.385&��� -!   $ label2_Copy7��$	��Nº��$
��Left=�$��
674,50,0,0q�$	��Top=�$��22(�$ 0.231,0.385&��� -"   $ label2_Copy8��$��Complemento:��$
��Left=�$��	10,94,0,0q�$	��Top=�$��22(�$ 0.231,0.385&�  $ 	00000-000��$
��Left=�$��35��$��	67,10,0,0q�$
  Wrap=�$	��Top=�$	��169��$��22(�$��5,0,0,0q��� $
��Left=�$��35��$��
575,10,0,0q�$
  Wrap=�$	��Top=�$	��209��$��22(�$��5,0,0,0q��� $
��Left=�$��35��$��
331,10,0,0q�$
  Wrap=�$	��Top=�$	��149��$��22(�$��5,0,0,0q��� $
��Left=�$��35��$��	86,54,0,0q�$
  Wrap=�$	��Top=�$	��187��$��22(�$��5,0,0,0q��� $
��Left=�$��35��$��
341,54,0,0q�$
  Wrap=�$	��Top=�$	��328��$��22(�$��5,0,0,0q��� $
��Left=�$��35��$��
715,54,0,0q�$
  Wrap=�$	��Top=�$��69��$��22(�$��5,0,0,0q��� $
��Left=�$��35��$��
163,98,0,0q�$
  Wrap=�$	��Top=�$	��621��$��22(�$��5,0,0,0q�� $
��Left=�$	��101��$��
12,231,0,0q�$	��Top=�$	��794�����	#FFDCD3C0.+��� -#   $ label2_Copy9��$��E-mail:��$
��Left=�$��	12,52,0,0q�$	��Top=�$��22(��� -$   $ label2_Copy11��$��Telefone Fixo:��$
��Left=�$��10,6,0,0q�$	��Top=�$��22(�$ 0.231,0.385&��� -%   $ label2_Copy12��$��Celular:��$
��Left=�$��	429,8,0,0q�$	��Top=�$��22(�$ 0.231,0.385&�  $ (00) 0000-0000��$
��Left=�$��35��$��
162,10,0,0q�$
  Wrap=�$	��Top=�$	��246��$��22(�$��5,0,0,0q�  $ (00) 00000-0000��$
��Left=�$��35��$��
536,10,0,0q�$
  Wrap=�$	��Top=�$	��248��$��22(�$��5,0,0,0q��� $
��Left=�$��36��$��
102,54,0,0q�$
  Wrap=�$	��Top=�$	��682��$��22(�$��5,0,0,0q�� $
��Left=�$��57��$��
12,340,0,0q�$	��Top=�$	��794�����	#FF595959.+��� ���	#FF959595$
��Left=�$��35��$��	12,10,0,0q�$	��Top=�$	��269���� -&   $ label2_Copy10��$��Tipo:��$
��Left=�$��14,7,0,0q�$	��Top=�$��22(����	#FFF9F9F9$��60��	� $��Normal��$
��Left=�$��	72,14,0,0q�$	��Top=�$��Center=�$��22(����	#FFF9F9F9$
( TrueY�$) rbTipoFrete��	� $��Expressa��$
��Left=�$��
171,14,0,0q�$	��Top=�$��Center=�$��22(����	#FFF9F9F9$) rbTipoFrete��