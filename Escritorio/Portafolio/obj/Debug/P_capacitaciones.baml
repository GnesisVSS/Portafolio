   M S B A M L   `   `   `  ����E  APortafolio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Portafolio
Portafolio  5      !    Portafolio.P_capacitaciones   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Portafolio     5      _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5      $
��1116��5	       $	��690��6-   .��5
      � 
�������.+�5   
   )  #MaterialDesignThemes.Wpf.DialogHost     MaterialDesignDevider#���   6$       DialogContent  5      � 5      $	��300��6   $	��150��6#   $��Center=�60   .+�5      ��  �� Orientation$ 
Horizontal=�6!   $��15q�6:   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ QuestionMark=�62     PrimaryHueMidBrush#��[ 6F   $��50��6w   $��50��6�   �� 5      
�������$	��200��66   $
��15 5q�6B   $
��Wrap=�6P   (&Desea generar una nueva capacitación?5      5      �� 5      $ 
Horizontal=�6!   $��Right=�6:   $��Bottom=�6V   $��15q�6q   .+�5      ��    CloseDialogCommand#��Z 6!     MaterialDesignFlatButton#���  6c   $��4q�6�   $��Center=�6�   .��6�   
Cancelar5      5      �� 5      $ 
Horizontal=�6!   $
��Left=�6:   $��Bottom=�6U   $��15q�6p   .+�5      �� -   5         ��Name$ boton_confirmacion��5   !   #��Z 6=   #���  6   $��4q�6�   $��Center=�6�   .��6�   	Confirmar5      5      5      .��5!      �� -   5        $ btnPago��5!      $��	Confirmar��6&   $��Bottom=�6:   $��52��6U   $��Right=�6a   $	��140��6}   $��	0,0,30,45q�6�   
�������
���   �$
��Bold"�6�      OpenDialogCommand#��Z 6�   ��5"      �� 5#       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5$      �  � Color$ 	#FF00A2FF��6'   	 � Offset$	 0Q�69   � 5%      $ 	#FF1700FF��6'   $	 1Q�69   5&      5(      5)      &   System.Windows.Controls.DataGrid  5*   
   -   5        
  Name$
 	dgEmpresa��5*      $	��141��6&   $��508,518,0,0q�63   $	��Top=�6H   $	��141��6`   $y�Hidden=�6l      HeadersVisibility$
 None=�6�      
IsReadOnly . $
��Left=�6�   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6�   |�.     EnableRowVirtualization .     CanUserReorderColumns .   � OverridesDefaultStyle .  6i  �� 5+   
   -   5        $ 	btnVolver��5+      $��volver��6$   $
��Left=�65   $	��114��6P   $��36��6\   $��Bottom=�6h   $��	56,0,0,45q�6�   
�������
�������
���   �6�   �� 5,   
   -   5         ��Name$ lblFecha��5,      $��Fecha��6"   $
��Left=�62   $��416,170,0,0q�6M   $	��Top=�6b   $��26��6z   $��40��6�   (  "System.Windows.Controls.DatePicker  5-   
   -   5          Name$ dtFecha��5-      $
��Left=�6&   $��506,170,0,0q�6A   $	��Top=�6V   $��26��6n   $	��150��6z   6�   �� 5.   
   -   5        $ lblHora��5.      $
��Hora��6!   $
��Left=�60   $��416,280,0,0q�6K   $	��Top=�6`   $��26��6x   $��36��6�   �� 5/   
   -   5         ��Name$ cboHora��5/      $
��Left=�6$   $��506,280,0,0q�6?   $	��Top=�6T   $��64��6l   *  $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ HH��6w   $��26��6�   .@�50      �� $��9��6   $��Right=�6'   $��64��6C   �� 51      $��10��6   $��Right=�6(   $��64��6D   �� 52      $��11��6   $��Right=�6(   $��64��6D   �� 53      $��12��6   $��Right=�6(   $��64��6D   �� 54      $��13��6   $��Right=�6(   $��64��6D   �� 55      $��14��6   $��Right=�6(   $��64��6D   �� 56      $��15��6   $��Right=�6(   $��64��6D   �� 57      $��16��6   $��Right=�6(   $��64��6D   �� 58      $��17��6   $��Right=�6(   $��64��6D   �� 59      $��18��6   $��Right=�6(   $��64��6D   5:      �� 5;   
   -	   5        $ lblSeparador��5;      $��:��6&   $
��Left=�62   $��572,280,0,0q�6M   $	��Top=�6b   $��26��6z   $��14��6�   �� 5<   
   -
   5        $ 	cboMinuto��5<      $
��Left=�6&   $��592,280,0,0q�6A   $	��Top=�6V   $��64��6n   $ MM��6y   $��26��6�   .@�5=      �� $��00��6   $
��Left=�6(   $��64��6C   �� 5>      $��15��6   $
��Left=�6(   $��64��6C   �� 5?      $��30��6   $
��Left=�6(   $��64��6C   �� 5@      $��40��6   $
��Left=�6(   $��64��6C   �� 5A      $��45��6   $
��Left=�6(   $��64��6C   5B      �� 5C   
   -   5        $ lblAsistente��5C      $��Cant Asistentes��6&   $
��Left=�6@   $��416,378,0,0q�6[   $	��Top=�6p   $��26��6�   $��94��6�   �� 5D   
   -   5         ��Name$ txtAsistente��5D      $
��Left=�6(   $��26��6C   $��506,378,0,0q�6O    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��150��6�   $ Rut del Asistente��6�    �� 	MaxLength$ 20��6�   �� 5E   
   -   5        $ 
lblEmpresa��5E      $��Empresa��6$   $
��Left=�66   $��416,492,0,0q�6Q   $	��Top=�6f   $��26��6~   $��54��6�   �� 5F   
   -   5        $ lblTituloProfesional��5F      $��Capacitaciones��6.   $
��Left=�6G   $��
398,42,0,0q�6b   $	��Top=�6v   ���	#FF5B5B5B$��36(�6�   $��Bahnschrift Light)�6�   $
��Bold"�6�   $��49��6�   �� 5G   
   $��654,29,388,593q�6   $��	users.png��6(   $��Uniform=�6;   �� 5H   
   -   5        $ txtRunEmpresa��5H      $
��Left=�6)   $��26��6D   $��506,492,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��150��6�   $ Rut del Asistente��6�   $ 15��6�   �� 5I   
   -   5        $ 	btnBuscar��5I      $
��Left=�6$   $	��Top=�6@   $��38��6X   $��28��6d   
������ 
������ 
���   �$
��Bold"�6�   $��702,490,0,0q�6�   $��0q�6�   .��5J      �� $��28��6   $��buscar(2).png��6    $��Uniform=�67   $��38��6I   5K      �� 5L   
   -   5        $ btnCancelar��5L      $
��Left=�6&   $	��Top=�6B   $��26��6Z   $��26��6f   
������ 
������ 
���   �$
��Bold"�6�   $��664,490,0,0q�6�   $��0q�6�    J� RenderTransformOrigin$ 0.5,0.5&�6  .��5M      �� $��cancelar.png��6   $��Uniform=�6*   $��22��6<   $��26��6H    � UseLayoutRounding .  6S   5N      5O      5P      