   M S B A M L   `   `   `  ����E  APortafolio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Portafolio
Portafolio  5      "    Portafolio.A_AgregarTipoPlan   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $localclr-namespace:Portafolio  5      $
��1116��5      $	��690��6,   .��5	      � 
�������.+�5
   
   )  #MaterialDesignThemes.Wpf.DialogHost     MaterialDesignDevider#���   6$   $��-1,0,1,0q�6Z       DialogContent  5      � 5      $	��300��6   $	��150��6#   $��Center=�60   .+�5      ��  �� Orientation$ 
Horizontal=�6!   $��15q�6:   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ QuestionMark=�62     PrimaryHueMidBrush#��[ 6F   $��50��6w   $��50��6�   �� 5      
�������$	��200��66   $
��15 5q�6B   $
��Wrap=�6P    Desea registrar un nuevo plan?5      5      �� 5      $ 
Horizontal=�6!   $��Right=�6:   $��Bottom=�6V   $��15q�6q   .+�5      ��    CloseDialogCommand#��Z 6!     MaterialDesignFlatButton#���  6c   $��4q�6�   $��Center=�6�   .��6�   
Cancelar5      5      �� 5      $ 
Horizontal=�6!   $
��Left=�6:   $��Bottom=�6U   $��15q�6p   .+�5      �� -   5         ��Name$ boton_confirmacion��5   !   #��Z 6=   #���  6   $��4q�6�   $��Center=�6�   .��6�   	Registrar5      5      5      .��5       �� -   5        $ btnCrearPlan��5       $��Crear nuevo Plan��6+   $��Bottom=�6F   $��52��6a   $��Right=�6m   $	��161��6�   $��	0,0,80,51q�6�   
�������
���   �$
��Bold"�6�      OpenDialogCommand#��Z 6�   ��5!      �� 5"       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5#      �  � Color$ 	#FF00A2FF��6'   	 � Offset$	 0Q�69   � 5$      $ 	#FF1700FF��6'   $	 1Q�69   5%      5'      5)      �� 5*   
   -   5        
 ��Name$
 lblTipodePlan��5*      $��Tipo de Plan��6'   $
��Left=�6>   $��366,173,0,0q�6Y   $	��Top=�6n   �� 5+   
   -   5        $
 lblValorFinal��5+      $��Valor de Plan��6'   $
��Left=�6?   $��366,264,0,0q�6Z   $	��Top=�6o   �� 5,   
   -   5        $
 lblCantAsesoria��5,      $��Cantidad Asesorías��6)   $
��Left=�6F   $��366,352,0,0q�6a   $	��Top=�6v   �� 5-   
   -   5        $
 lblCantCapacitaciones��5-      $��Cantidad Capacitaciones��6/   $
��Left=�6Q   $��366,438,0,0q�6l   $	��Top=�6�   �� 5.   
   -   5        $
 lblCantVisitas��5.      $��Cantidad Visitas��6(   $
��Left=�6C   $��366,518,0,0q�6^   $	��Top=�6s   �� 5/   
   $��Tipo de Plan��6   $
��Left=�6'   $��
380,52,0,0q�6B   $	��Top=�6V   ���	#FF5B5B5B$��36(�6�   $��Bahnschrift Light)�6�   $
��Bold"�6�   �� 50   
   $��589,35,453,587q�6   $��	users.png��6(   $��Uniform=�6;   �� 51   
   -   5         ��Name$ txtTipoPlan��51      $
��Left=�6'   $��22��6B   $��540,175,0,0q�6N    �� TextWrapping$
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��144��6�    �� 	MaxLength$	 100��6�   6�   �� 52   
   -	   5        $ txtValorPlan��52      $
��Left=�6(   $��22��6C   $��540,266,0,0q�6O   $
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��144��6�   $ 20��6�   �� 53   
   -
   5        $ txtCantAsesorias��53      $
��Left=�6,   $��22��6G   $��540,354,0,0q�6S   $
 Wrap=�6h   $�� ��6|   $	��Top=�6�   $	��144��6�   $ 2��6�   �� 54   
   -   5        $ txtCantCapacitaciones��54      $
��Left=�61   $��22��6L   $��540,440,0,0q�6X   $
 Wrap=�6m   $�� ��6�   $	��Top=�6�   $	��144��6�   $ 2��6�   �� 55   
   -   5        $ txtCantVisitas��55      $
��Left=�6*   $��22��6E   $��540,520,0,0q�6Q   $
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��144��6�   $ 2��6�   56      57      