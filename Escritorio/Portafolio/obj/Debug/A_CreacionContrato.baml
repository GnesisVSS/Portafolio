   M S B A M L   `   `   `  ����E  APortafolio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Portafolio
Portafolio  5      #    Portafolio.A_CreacionContrato   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $localclr-namespace:Portafolio  5      $
��1116��5      $	��690��6,   .��5	      � 
�������.+�5   
   �� $��Creación Contrato��6   ���	#FF5B5B5B$��36(�6D   $��Bahnschrift Light)�6R   $
��Bold"�6q   $
��Left=�6�   $	��Top=�6�   $��50��6�   $��
372,46,0,0q�6�   $	��304��6�   � 5   
   $	��690��6   .+�5      )  #MaterialDesignThemes.Wpf.DialogHost     MaterialDesignDevider#���   6(       DialogContent  5      � 5      $	��300��6   $	��150��6'   $��Center=�64   .+�5      ��  �� Orientation$ 
Horizontal=�6%   $��15q�6>   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ QuestionMark=�66     PrimaryHueMidBrush#��[ 6J   $��50��6{   $��50��6�   �� 5      
�������$	��200��6:   $
��15 5q�6F   $
��Wrap=�6T   75Desea registrar en el sistema a la empresa ingresada?5      5      �� 5      $ 
Horizontal=�6%   $��Right=�6>   $��Bottom=�6Z   $��15q�6u   .+�5      ��    CloseDialogCommand#��Z 6%     MaterialDesignFlatButton#���  6g   $��4q�6�   $��Center=�6�   .��6�   
Cancelar5      5      �� 5      $ 
Horizontal=�6%   $
��Left=�6>   $��Bottom=�6Y   $��15q�6t   .+�5      �� -   5         ��Name$ boton_confirmacion��5   %   #��Z 6A   #���  6�   $��4q�6�   $��Center=�6�   .��6�   	Registrar5      5       5!      .��5$      �� -   5        $ btnRegistrarContrato��5$      $��	Registrar��67   $
��Bold"�6K   
���   �$��Bottom=�6�   $��52��6�   $��Right=�6�   $��94��6�   $��	0,0,30,53q�6�      OpenDialogCommand#��Z 6�   
���������5%      �� 5&       �� EndPoint$ 0.5,1&�6.    �� 
StartPoint$ 0.5,0&�6?   .��5'      �  � Color$ Black��6+   	 � Offset$	 0Q�69   � 5(      $ 	#FF1700FF��6+   $	 1Q�6=   � 5)      $ 	#FF00A2FF��6+   5*      5,      5.      �� 5/      $&�� *Continuar Registro de Asesoría��6   $
��Left=�6>   $��957,636,0,0q�6Y   $	��Top=�6n   $��9(�6�   �� 50      -   5        
 ��Name$
 lblFechaInicio��50      $��Fecha Inicio��6,   $��Stretch=�6C   $��Stretch=�6b   $��23��6~   $	��138��6�   $��56,174,922,493q�6�   (  "System.Windows.Controls.DatePicker  51      -   5          Name$ dpFechaInicio��51      $��Stretch=�61   $��Stretch=�6P   $��23��6l   $	��150��6x   $��265,174,701,493q�6�   6�   �� 52      $��671,30,371,592q�6   $��	users.png��6,   $��Uniform=�6?   �� 53      -   5        $ 	btnVolver��53      $��volver��6(   
�������
�������
�������$
��Left=�6�   $	��114��6�   $��36��6�   $��Bottom=�6�   $��	56,0,0,57q�6�   &   System.Windows.Controls.DataGrid  54      -   5          Name$ 	dgEmpresa��54      $
��Left=�6*   $	��292��6E   $��489,218,0,0q�6R   $	��Top=�6g   $	��603��6      
IsReadOnly . ���	#1F2300FF6�   �� 55      -   5        $
 lblRunAsociado��55      $��Rut de la empresa��6,   $
��Left=�6H   $��489,175,0,0q�6c   $	��Top=�6x   $	��109��6�   �� 56      -   5         ��Name$ txtRunAsociado��56      $
��Left=�6.   $��25��6I   $��603,174,0,0q�6U    �� TextWrapping$
 Wrap=�6j   $�� ��6~   $	��Top=�6�   $��94��6�    �� 	MaxLength$ 9��6�   �� 57      -	   5        $
 	lblRutRep��57      $��Rut Empresa ��6'   $
��Left=�6>   $��499,537,0,0q�6Y   $	��Top=�6n   $��81��6�   �� 58      -
   5        $ 	txtRutEmp��58      $
��Left=�6)   $��25��6D   $��585,536,0,0q�6P   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��151��6�   {�.  6�   �� 59      -   5        $
 lblNombreAsociado��59      $��Nombre de la empresa��6/   $
��Left=�6N   $��800,174,0,0q�6i   $	��Top=�6~   $	��136��6�   �� 5:      -   5        $ txtNombreAsociado��5:      $
��Left=�61   $��25��6L   $��930,171,0,0q�6X   $
 Wrap=�6m   $�� ��6�   $	��Top=�6�   $	��100��6�    �� IsUndoEnabled . $ 15��6�   �� 5;      -   5        $ btnBuscarNombre��5;      $
��Left=�6.   $	��Top=�6J   $��38��6b   $��29��6n   
������ 
������ 
���   �$
��Bold"�6�   $��1058,171,0,0q�6�   $��0q�6  .��5<      �� $��29��6   $��buscar(2).png��6$   $��Uniform=�6;   $��38��6M   5=      �� 5>      -   5        $ btnBuscarRun��5>      $
��Left=�6+   $	��Top=�6G   $��38��6_   $��30��6k   
������ 
������ 
���   �$
��Bold"�6�   $��723,170,0,0q�6�   $��0q�6�   .��5?      �� $��29��6   $��buscar(2).png��6$   $��Uniform=�6;   $��38��6M   5@      �� 5A      -   5        $ btnCancelar��5A      $
��Left=�6*   $	��Top=�6F   $��16��6^   $��18��6j   
������ 
������ 
���   �$
��Bold"�6�   $��1030,178,0,0q�6�   $��0q�6�    J� RenderTransformOrigin$ 0.5,0.5&�6
  .��5B      �� $��boton-x.png��6   $��Uniform=�6-   $��13��6?   $��14��6K   5C      �� 5D      -   5        $ btnCancelar2��5D      $
��Left=�6+   $	��Top=�6G   $��17��6_   $��18��6k   
������ 
������ 
���   �$
��Bold"�6�   $��697,182,0,0q�6�   $��0q�6�   $ 0.5,0.5&�6  .��5E      �� $��boton-x.png��6   $��Uniform=�6-   $��13��6?   $��14��6K   5F      5G      5I      5J      