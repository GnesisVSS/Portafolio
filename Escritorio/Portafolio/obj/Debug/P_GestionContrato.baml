   M S B A M L   `   `   `  ����E  APortafolio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Portafolio
Portafolio  5      "    Portafolio.P_GestionContrato   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Portafolio     5      _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $
��1116��5      $	��690��6,   .��5	      � 
�������.+�5
   
   )  #MaterialDesignThemes.Wpf.DialogHost     MaterialDesignDevider#���   6$       DialogContent  5      � 5      $	��300��6   $	��150��6#   $��Center=�60   .+�5      ��  �� Orientation$ 
Horizontal=�6!   $��15q�6:   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ QuestionMark=�62     PrimaryHueMidBrush#��[ 6F   $��50��6w   $��50��6�   �� 5      
�������$	��200��66   $
��15 5q�6B   $
��Wrap=�6P   0.Desea generar una nueva notificación de pago?5      5      �� 5      $ 
Horizontal=�6!   $��Right=�6:   $��Bottom=�6V   $��15q�6q   .+�5      ��    CloseDialogCommand#��Z 6!     MaterialDesignFlatButton#���  6c   $��4q�6�   $��Center=�6�   .��6�   
Cancelar5      5      �� 5      $ 
Horizontal=�6!   $
��Left=�6:   $��Bottom=�6U   $��15q�6p   .+�5      �� -   5         ��Name$ boton_confirmacion��5   !   #��Z 6=   #���  6   $��4q�6�   $��Center=�6�   .��6�   	Aceptar5      5      5      5       &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$ 
dgContrato��5!      $��132,165,120,207q�6'   6@   �� 5"   
   $��Gestión Contrato��6   $
��Left=�6+   $��
364,23,0,0q�6F   $	��Top=�6Z   ���	#FF5B5B5B$��36(�6�   $��Bahnschrift Light)�6�   $
��Bold"�6�   $	��290��6�   �� 5#   
   $��654,11,388,611q�6   $��	users.png��6(   $��Uniform=�6;   �� 5$   
   -   5         ��Name$ lblRunCliente��5$      $��Run Representante��6'   $
��Left=�6C   $��546,124,0,0q�6^   $	��Top=�6s   �� 5%   
   -   5         ��Name$ txtRunCliente��5%      $
��Left=�6)   $��24��6D   $��661,120,0,0q�6P    �� TextWrapping$
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��120��6�   	 �� 	MaxLength$	 9��6�   �� 5&   
   -   5        $ 	lblFiltro��5&      $��Filtrar por empresa��6#   $
��Left=�6A   $��144,120,0,0q�6\   $	��Top=�6q   �� 5'   
   -   5        $ 
txtEmpresa��5'      $
��Left=�6&   $��24��6A   $��262,120,0,0q�6M   $
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��156��6�   $	 15��6�   �� 5(   
   -   5        $ 	btnBuscar��5(      $
��Left=�6$   $	��Top=�6@   $��38��6X   $��29��6d   
������ 
������ 
���   �$
��Bold"�6�   $��815,115,0,0q�6�   $��0q�6�   .��5)      �� $��29��6   $��buscar(2).png��6    $��Uniform=�67   $��38��6I   5*      �� 5+   
   -   5        $ btnCancelar��5+      $
��Left=�6&   $	��Top=�6B   $��26��6Z   $��26��6f   
������ 
������ 
���   �$
��Bold"�6�   $��418,115,0,0q�6�   $��0q�6�   
 J� RenderTransformOrigin$
 0.5,0.5&�6  .��5,      �� $��boton-x.png��6   $��Uniform=�6)   $��14��6;   $��14��6G   5-      �� 5.   
   -	   5        $ btnCancelar2��5.      $
��Left=�6'   $	��Top=�6C   $��26��6[   $��26��6g   
������ 
������ 
���   �$
��Bold"�6�   $��784,118,0,0q�6�   $��0q�6�   $
 0.5,0.5&�6  .��5/      �� $��boton-x.png��6   $��Uniform=�6)   $��14��6;   $��14��6G   50      52      53      