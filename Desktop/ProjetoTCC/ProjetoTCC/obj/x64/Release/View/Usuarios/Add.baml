   M S B A M L   `   `   `  ���� E  AProjetoTCC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ProjetoTCC.View.UsuariosProjetoTCC.View.Usuarios  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem O KAditionalControlsWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY@clr-namespace:AditionalControlsWPF;assembly=AditionalControlsWPFAditionalControlsWPF "    ProjetoTCC.View.Usuarios.Add   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     8local&clr-namespace:ProjetoTCC.View.Usuarios     6sys&clr-namespace:System;assembly=mscorlib     X TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f46custom)http://schemas.xceed.com/wpf/xaml/toolkit  XaditionalControls@clr-namespace:AditionalControlsWPF;assembly=AditionalControlsWPF    � Language$  pt-BR� N� Title$	 Add��&   System.Windows.Media.TextOptions   TextRenderingMode$ 	ClearType=�   TextFormattingMode$ Ideal=� � 	Resources  �� 
TargetType   SplitRectangle �� Property �� Value��%J   &	        �� " ��.���  � ��$	 Top=���  � �� �#F9F9F9.��� ���#ECECEC  �� 	Resources	 � LayoutTransform
 �� Angle �� 
TargetType �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName  	LightGrey �� Color,  &AditionalControlsWPF.RestrictedTextBox �� BasedOn(  "AditionalControlsWPF.NumericUpDown��%�  '��       &	 )    '�� <    &	  �    '�� <    7  '�� �    7  '  �    7  '�� O    7��'  �    7  �� " ��.���  � ��$ 0,0,1,0q���  � �� �#ddd��  � ��$ 16(���  � ��$ Global User Interface)� ���� '��       " ��.���  � �� �#444��  � �� �� .R��� #��z��	 �� $
 90Q���  � �� �� " ��.R��� $��Border��$��0q�
�������$ 0��$��	-1,0,-2,0q�._��� $ ContentSite��$��Center=�$��Center=�$��Header��$
��5,10q� P�  �@��
IsSelected . . ��� $ Border�� � ��
 ��·�P�  �@��
IsSelected .  . ��� $ Border�� � ��
 ������� $ #FCFCFC���� " ��.���  � ��$ 31����  � ��$ Calibri Light)���  � ��$ 18(���  � �� �#333333��  � ��$	 Top=���  � ��$ Center=���  � ��$ Right=��� " ��.���  � ��$	 Top=���  � �� �#F9F9F9�� " ��.���  � ��8   ��  �@��RadiusX$ 1����  �@��RadiusY$ 1����  � �� �#B8B8B8��  � ��$ 31����  � ��$	 Top=��� " ��.���  � ��$ 4q���  � ��$ 1q���  � ��
 ���� ��  � ��8   ��  � ��$ Center=���  � ��$ 15(���  � ��$ 27����  � �� �#3B3B3B��  � ��$	 Top=��� "  .���  � ��$ 0q���  � ��8   ��  � ��$ Center=���  � ��$ 27����  � �� �#3B3B3B��  � ��$	 Top=��� " ��8   .���  � ��$ 30����  � ��$	 Top=��� "  .���  � ��$ 29�� ���� '��       " ��.���  � ��$ 4,1,0,0q���  � ��$ 0q���  � ��$ Center=���  � ��8   ��  � ��$ 29��.+���  �� TabStripPlacement$ Right=�.@��� $��0,-2,0,0q�$��General��.��� $��-2q����#D6D6D6 � ColumnDefinitions �� $
��0.5* ��� $
��0.5* �.+��� $
��Auto=�.���  �� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* �.+��� #��[  $��	3,3,1.5,3q�$��40��$��0��$��20�����#ECECEC�� #��[  $��4,46,0,0q�$	��536��$��0��$��20���� $��3,8,0,0q�$��Center=�$��0��$��5��.��Data Cadastro�� $��5��$��7��$��0,8,0,0q��� -    ��Name$ txtDataCadastro��{�.  $��Center=�$��5��$��7�����#777$��2,10,2,2q����� *DataCadastro+�� $��0,8,0,0q�$��Center=�$��11��$��3��.��ID�� $��15��$��5��$��0,8,10,0q��� -   $ txtID�� �� 
IsReadOnly . {�.  $��Center=�$��15�����#777$��5��$��	2,10,12,2q����� *Id+ �� Mode$ TwoWay=� �� StringFormat$ 00000000���� #��[  $��21,170,16,0q����	#FFFFFBD1$	��207��$��20���� $��1��$��3��$��0,60,9,0q�.��Nome�� $��3��$��12��$��
28,60,29,0q�  -     Name$ txtNome��$��4��$��10��$��0,62,1,0q�$��0��   RestrictedTo$ LettersOnly��   BorderColor �� *NomeBorderColor+$ TwoWay=�   Text �� *Nome+$ TwoWay=��� -    ��Name$ 	recSenhas��#��[  $��	6,290,8,0q����	#FFFFFEF3$��81��$��17��$��2���� $��5��$��3��$��
0,296,10,0q�$��Usuário���� $��8��$��11��$��
0,296,12,0q��� -   $ 
txtUsuario�� .  �� 	MaxLength$ 30��$��8��$��11��$��
2,298,14,0q�$��4������ *
Username+�� $��5��$��3��$��
0,177,10,0q�$��E-mail���� $��8��$��11��$��
0,177,12,0q��� -   $ txtEmail��$��8��$ 30��$��11��$��
2,179,14,0q�$��5������ *EmailBorderColor+���� *Email+$ TwoWay=�  �� UpdateSourceTrigger$  PropertyChanged=��� $��5��$��3��$��	0,254,0,0q�$��Acesso��$��69���� -   ! ��Name$! cbAcesso��" �� SelectedIndex$" 0��# �� DisplayMemberPath$# 	Descricao��$ �� SelectedValuePath$$ Id��$��8��$��11��$��
0,254,12,0q�$��6��% �� SelectedValue% �� *Acesso+���� *AcessoSource+�� $��6��$��2��$��
0,333,10,0q�$��Senha���� $��8��$��11��$��
0,334,12,0q��� -   $ txtSenha�� . $��8��$��11��$��2,336,14,281q�$��Center=�$��5������ *Senha+$  PropertyChanged=���Z� ��Z� &   AditionalControlsWPF.ImagePicker  -	   &  Name$& 
imgUsuario��$��6��$
��Left=�'   Limit$' 1��$��	17,59,0,0q�$	��Top=�$	��105��$	��156��$��14�����	#FF7A7979(   Picture( �� *Foto+$ TwoWay=�$  PropertyChanged=��� $��4��$��0,95,8,0q�$��	Sobrenome��$��93���� $��3��$��12��$��
28,95,29,0q�  -
   $ txtSobrenome��$ LettersOnly��$��4��$��10��$��0,97,1,0q�$��1�� �� *SobrenomeBorderColor+$ TwoWay=� �� *	Sobrenome+$ TwoWay=��� $��2��$��	0,131,7,0q�$
��Sexo��$��45��$��2���� $��12��$��3��$
��Left=�$��32��$��
28,131,0,0q�$	��Top=�$	��321�����	#FF5B5B5B��Z� 	� -   ) 	�Name$) rbMasculino��$��	Masculino��$��5��$
��Left=�$��
11,140,0,0q�$	��Top=�$��4��$��98��
�������* 	� 	GroupName$
* Sexo��$��2��+ d� 	IsChecked+ �� *	Masculino+	� -   $) 
rbFeminino��$��Feminino��$��9��$
��Left=�$��
24,140,0,0q�$	��Top=�$��4��$	��101��
�������$
* Sexo��$��3���� -   , ��Name$, 	btnSalvar��$��0��$��7��$��4,0,26,4q�$��0q����#006FA3$��20(�
�������- � Cursor$
- Hand��$��Bottom=�$��50��$��Salvar������ *	Confirmar+�� -   $, 	btnLimpar��$��7��$��7��$��2,0,27,4q�$��0q����#006FA3$��20(�
�������$
- Hand��$��Bottom=�$��50��$��Limpar���� $��6��$��2��$��	0,216,7,0q�$��Status��$��56���� -   $! cbStatus��$" 0��$# 	Descricao��$$ Id��$��8��$��11��$��
0,216,12,0q�$��6��% �� *Status+���� *StatusSource+�� -   . ��Name$. label��$��20��/ �� 
LineHeight$/ 27�����	#FF802525$��Nirmala UI Semilight)�$
��Left=�$��
21,381,0,0q�$	��Top=�$	��109��$	��593��$��18(�0 �� Padding$0 0,5,0,0q����� *ErrorMessage+$ TwoWay=�$  PropertyChanged=�� $��1�� �� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* ��� $��0.05* �