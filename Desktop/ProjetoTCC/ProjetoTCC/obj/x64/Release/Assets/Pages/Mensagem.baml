   M S B A M L   `   `   `  ���� E  AProjetoTCC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:ProjetoTCC.ViewModelProjetoTCC.ViewModel  A%clr-namespace:ProjetoTCC.Assets.PagesProjetoTCC.Assets.Pages  &     ProjetoTCC.Assets.Pages.Mensagem   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1vm"clr-namespace:ProjetoTCC.ViewModel     7local%clr-namespace:ProjetoTCC.Assets.Pages       N� Title$  Mensagem��$	��690��$
��1288�� � DataContext ,   &ProjetoTCC.ViewModel.MensagemViewModel   � 	Resources  �� MergedDictionaries �� Source��  �� $&  Mensagens/MensagemResources.xaml?�%    .��� 
�������.+��� $
��Left=�$��87��$	��Top=�$
��1288������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&� �� RelativeTransform V� .~���  �� CenterY$	 0.5Q�	 �� CenterX$		 0.5Q��� 
 �� CenterY$	
 0.5Q� �� CenterX$	 0.5Q���  �� Angle$ 90Q� �� CenterY$	 0.5Q� �� CenterX$	 0.5Q�T� .���  � Color$ 	#FF179589�� � Offset$ 0Q�� $ 	#FF152F4D��$ 1Q�&   System.Windows.Controls.DataGrid  -     Name$ 
dtMensagem��   nice#��[  $��21(�$
��Left=�   CanUserAddRows .     AutoGenerateColumns .  $	��579��$��	10,99,0,0q�$	��Top=�$	��528�����	#FF293399
������� �� SelectedItem �� *MensagemSelecionada+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 0  *System.Windows.Controls.DataGridTextColumn     FontSize$ 22Q�   
Foreground
 ��  �,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$   NOME ��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *NOME+4  .System.Windows.Controls.DataGridTemplateColumn   .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 250 $   MENSAGEM ��   CellTemplate �� .R��� $��Center=�$
��Wrap=� �� TextAlignment$ Justify=����� *
MENSAGEM+�� $��	Responder��$��25(�$
��Left=�$��547,623,0,0q�$	��Top=�$	��731��$��55�����	#FF31A446
����������	#FF3BDA7C���� *	Confirmar+�� $��	Mensagens��$
��Left=�$��	14,14,0,0q�$	��Top=�$��66��$	��228��$��Center=�$��48(�
�������$.��(/ProjetoTCC;component/Fonts/#HighSociety)���Z�   J� Effect  3  -System.Windows.Media.Effects.DropShadowEffect  !   Color$! White��"   ShadowDepth$" 0Q�� $
��Left=�$	��511��$��
547,99,0,0q�$	��Top=�$	��731�����	#FF91C7BB.+��� -   # ��Name$# textBox��{�.  $
��Left=�$��10,0,0,0q�$��Center=�$��46��$��
103,10,0,0q�$ �� TextWrapping$
$ Wrap=�$	��Top=�$	��618��$��24(�
���   �$��Segoe UI Semibold)����� *Email+$ TwoWay=�$ PropertyChanged=���Z� �� -   % ��Name$% label��$��E-mail: ��$
��Left=�$��	10,10,0,0q�$	��Top=�& J� RenderTransformOrigin$& 0.342,1&�$��24(�
�������    �� -   $# textBox_Copy��$
��Left=�$��10,0,0,0q�$��Center=�$��46��$��
117,64,0,0q�$
$ Wrap=�$	��Top=�$	��604��$��24(����� *	Assunto+$ TwoWay=�$ PropertyChanged=���Z� �� -   $% 
label_Copy��$��	Assunto: ��$
��Left=�$��	10,64,0,0q�$	��Top=�$& 0.342,1&�$��24(�
�������    �� -   $# textBox_Copy1��' �� AcceptsReturn' . $
��Left=�$��20q�( �� TextAlignment$( Justify=�$	��383��$��
10,118,0,0q�$
$ Wrap=�$	��Top=�$	��711��$��24(����� *
Conteudo+$ TwoWay=�$ PropertyChanged=���Z� 