   M S B A M L   `   `   `  ����E  APortafolio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Portafolio
Portafolio  5           Portafolio.P_VisitaTerreno   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Portafolio     5      _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5      $
��1116��5	      $	��690��6,   .��5
      � 
�������.+�5   
   )  #MaterialDesignThemes.Wpf.DialogHost     MaterialDesignDevider#���   6$       DialogContent  5      � 5      $	��300��6   $	��150��6#   $��Center=�60   .+�5      ��  �� Orientation$ 
Horizontal=�6!   $��15q�6:   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ QuestionMark=�62     PrimaryHueMidBrush#��[ 6F   $��50��6w   $��50��6�   �� 5      
�������$	��200��66   $
��15 5q�6B   $
��Wrap=�6P   #!Desea generar un nuevo documento?5      5      �� 5      $ 
Horizontal=�6!   $��Right=�6:   $��Bottom=�6V   $��15q�6q   .+�5      ��    CloseDialogCommand#��Z 6!     MaterialDesignFlatButton#���  6c   $��4q�6�   $��Center=�6�   .��6�   
Cancelar5      5      �� 5      $ 
Horizontal=�6!   $
��Left=�6:   $��Bottom=�6U   $��15q�6p   .+�5      �� -   5         ��Name$ boton_confirmacion��5   !   #��Z 6=   #���  6   $��4q�6�   $��Center=�6�   .��6�   	Confirmar5      5      5      .��5       �� -   5        $ btnDocumento��5       $��Generar PDF/Documento��6+   $��Bottom=�6K   $��52��6f   $��Right=�6r   $	��203��6�   $��	0,0,30,45q�6�   
�������
���   �$
��Bold"�6�      OpenDialogCommand#��Z 6�   ��5!      �� 5"       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5#      �  � Color$ 	#FF00A2FF��6'   	 � Offset$	 0Q�69   � 5$      $ 	#FF1700FF��6'   $	 1Q�69   5%      5'      5(      �� 5)   
   -   5        $ 	btnVolver��5)      $��volver��6$   $
��Left=�65   $	��114��6P   $��36��6\   $��Bottom=�6h   $��	56,0,0,45q�6�   
�������
�������
���   �6�   �� 5*   
   -   5        
 ��Name$
 
lblEmpresa��5*      $��Empresa��6$   $
��Left=�66   $��285,178,0,0q�6Q   $	��Top=�6f   �� 5+   
   -   5        $
 lblFecha��5+      $��Fecha Visita��6"   $
��Left=�69   $��563,178,0,0q�6T   $	��Top=�6i   �� 5,   
   -   5         ��Name$ 
txtEmpresa��5,      $
��Left=�6&   $��23��6A   $��345,178,0,0q�6M    �� TextWrapping$
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��120��6�   *  $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ 	Empresa 1��6�    �� 
IsReadOnly . {�.  6�   �� 5-   
   -   5        $ txtFecha��5-      $
��Left=�6$   $��23��6?   $��659,178,0,0q�6K   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��120��6�   $ 
11.11.1111��6�    . {�.  6�   �� 5.   
   -   5         ��Name$	 ch1��5.      $��Item1��6    $
��Left=�60   $��306,294,0,0q�6K   $	��Top=�6`   �� 5/   
   -	   5        $	 ch2��5/      $��Item2��6    $
��Left=�60   $��306,378,0,0q�6K   $	��Top=�6`   �� 50   
   -
   5        $	 ch3��50      $��Item3��6    $
��Left=�60   $��306,454,0,0q�6K   $	��Top=�6`   �� 51   
   -   5        $	 ch4��51      $��Item4��6    $
��Left=�60   $��574,297,0,0q�6K   $	��Top=�6`   �� 52   
   -   5        $	 ch5��52      $��Item5��6    $
��Left=�60   $��574,378,0,0q�6K   $	��Top=�6`   �� 53   
   -   5        $	 ch6��53      $��Item6��6    $
��Left=�60   $��574,454,0,0q�6K   $	��Top=�6`   �� 54   
   $
��Left=�6   $��34��6-   $��380,290,0,0q�69   $
 Wrap=�6N   $�� ��6b   $	��Top=�6j   $	��120��6�   " �� VerticalScrollBarVisibility$ Visible=�6�   $ Comentarios��6�   �� 55   
   $
��Left=�6   $��34��6-   $��380,378,0,0q�69   $
 Wrap=�6N   $�� ��6b   $	��Top=�6j   $	��120��6�   $ Visible=�6�   $ Comentarios��6�   �� 56   
   $
��Left=�6   $��36��6-   $��380,448,0,0q�69   $
 Wrap=�6N   $�� ��6b   $	��Top=�6j   $	��120��6�   $ Visible=�6�   $ Comentarios��6�   �� 57   
   $
��Left=�6   $��34��6-   $��648,290,0,0q�69   $
 Wrap=�6N   $�� ��6b   $	��Top=�6j   $	��120��6�   $ Visible=�6�   $ Comentarios��6�   �� 58   
   $
��Left=�6   $��34��6-   $��648,378,0,0q�69   $
 Wrap=�6N   $�� ��6b   $	��Top=�6j   $	��120��6�   $ Visible=�6�   $ Comentarios��6�   �� 59   
   $
��Left=�6   $��34��6-   $��648,450,0,0q�69   $
 Wrap=�6N   $�� ��6b   $	��Top=�6j   $	��120��6�   $ Visible=�6�   $ Comentarios��6�   �� 5:   
   $��688,27,374,597q�6   $��mapa-de-pines.png��6(   $��Uniform=�6C   �� 5;   
   -   5        $
 lblTituloProfesional��5;      $�� Visita a Terreno��6.   $
��Left=�6J   $��
414,44,0,0q�6e   $	��Top=�6y   ���	#FF5B5B5B$��36(�6�   $��Bahnschrift Light)�6�   $
��Bold"�6�   $��49��6�   5=      5>      