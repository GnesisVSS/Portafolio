   M S B A M L   `   `   `  ����E  APortafolio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Portafolio
Portafolio  5      !    Portafolio.A_ReporteGeneral   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Portafolio     5      _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $
��1116��5	      $	��690��6,   .��5
      � 
�������.+�5   
   �� -   5          ��Name$  lblRunAsociado��5      $��Run del Asociado��6(   $
��Left=�6C   $��376,213,0,0q�6^   $	��Top=�6s   �� 5   
   -   5         ��Name$ txtRunAsociado��5      $
��Left=�6*   $��23��6E   $��478,213,0,0q�6Q    �� TextWrapping$
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��154��6�   �� 5   
   -   5         ��Name$ 	btnBuscar��5      $��Buscar��6$   $
��Left=�65   $��636,213,0,0q�6P   $	��Top=�6e   $��96��6}   $��26��6�   
�������
����  �
���   �$
��Bold"�6�   &   System.Windows.Controls.DataGrid  5   
   $
��Left=�6   $	��158��6.   $��210,276,0,0q�6;   $	��Top=�6P   $	��681��6h      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Empresa��6%     5      $ Cantidad de Actividades��6%     5      $ Cantidad de Accidentes��6%     5      $ Profesional a Cargo��6%     5      $ Asesorías solicitadas��6%   5      )  #MaterialDesignThemes.Wpf.DialogHost  5   
      MaterialDesignDevider#���   6$      DialogContent 5      � 5      $	��300��6   $	��150��6#   $��Center=�60   .+�5      ��  �� Orientation$ 
Horizontal=�6!   $��15q�6:   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ QuestionMark=�62     PrimaryHueMidBrush#��[ 6F   $��50��6w   $��50��6�   �� 5      
�������$	��200��66   $
��15 5q�6B   $
��Wrap=�6P   42Desea generar un nuevo informe de reporte general?5      5       �� 5!      $ 
Horizontal=�6!   $��Right=�6:   $��Bottom=�6V   $��15q�6q   .+�5"      �� 	   CloseDialogCommand#��Z	 6!     MaterialDesignFlatButton#���  6c   $��4q�6�   $��Center=�6�   .��6�   
Cancelar5$      5%      �� 5&      $ 
Horizontal=�6!   $
��Left=�6:   $��Bottom=�6U   $��15q�6p   .+�5'      �� -   5        $ boton_confirmacion��5'   !   #��Z	 6=   #���  6   $��4q�6�   $��Center=�6�   .��6�   	Generar5)      5*      5+      .��5.      �� -   5        $ btnGenerarReporte��5.      $��Generar Reporte��60   $��Bottom=�6J   $��52��6e   $��Right=�6q   $	��148��6�   $��	0,0,30,45q�6�   
�������
���   �$
��Bold"�6�   
   OpenDialogCommand#��Z
 6�   ��5/      �� 50       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��51      �  � Color$ 	#FF00A2FF��6'    � Offset$ 0Q�69   � 52      $ 	#FF1700FF��6'   $ 1Q�69   53      55      57      �� 58   
   $��Reporte General��6   $
��Left=�6*   $��
376,48,0,0q�6E   $	��Top=�6Y   ���	#FF5B5B5B$��36(�6�   $��Bahnschrift Light)�6�   $
��Bold"�6�   $	��269��6�   �� 59   
   $��650,36,381,597q�6   $��grafico-de-barras.png��6(   $��Uniform=�6G   5;      5<      