   M S B A M L   `   `   `  ����E  APortafolio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Portafolio
Portafolio  5   	   !    Portafolio.CambioContrasena   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Portafolio     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   -   5          � Title$  No más accidentes��5
       � 
ResizeMode$ NoResize=�6!    � WindowStartupLocation$ CenterScreen=�68    � WindowStyle$
 None=�6]    � AllowsTransparency . 
������ $
��1116��6�   $	��690��6�   
���   � � Icon$ Imagenes\Isotipo.png��6�   .��5      � .+�5   
   ��  �� CornerRadius$ 10��6   $��2��6#   ��5      �� 5      .��5      �  � Color$ 	#FFA692FF��6#    � Offset$ 1Q�65   � 5      $ 	#FFBEFFFF��6#   $ 0Q�65   5      ._�5      �� -   5        	 ��Name$	 	rctangulo��5      
�������$��130,88,138,67q�68   
 �� RadiusX$
 10��6O    �� RadiusY$ 10��6\   ��5      �� 5       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      � $ 	#FF00A2FF��6'   $ 0Q�69   � 5      $ 	#FF1700FF��6'   $ 1Q�69   5      5      5      )  #MaterialDesignThemes.Wpf.DialogHost  5   
      MaterialDesignDevider#���   6$      DialogContent 5      � 5       $	��300��6   $	��150��6#   $��Center=�60   .+�5!      ��  �� Orientation$ 
Horizontal=�6!   $��15q�6:   .+�5"      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ QuestionMark=�62     PrimaryHueMidBrush#��[ 6F   $��50��6w   $��50��6�   �� 5#      
�������$	��200��66   $
��15 5q�6B   $
��Wrap=�6P   " Desea actualizar la contraseña?5%      5&      �� 5'      $ 
Horizontal=�6!   $��Right=�6:   $��Bottom=�6V   $��15q�6q   .+�5(      ��    CloseDialogCommand#��Z 6!     MaterialDesignFlatButton#���  6c   $��4q�6�   $��Center=�6�   .��6�   
Cancelar5*      5+      �� 5,      $ 
Horizontal=�6!   $
��Left=�6:   $��Bottom=�6U   $��15q�6p   .+�5-      �� -   5         ��Name$ boton_confirmacion��5-   !   #��Z 6=   #���  6   $��4q�6�   $��Center=�6�   .��6�   	Registrar5/      50      51      .��54      �� -   5        $ btnConfirmar��54      $��Cambiar Contraseña��6+   $	��Top=�6I   $��69��6|   
�������$
��Bold"�6�   $��18(�6�   $��Microsoft JhengHei)�6�   $��374,526,431,0q�6�      OpenDialogCommand#��Z 6�   ��56      �� 57      .��58      � $ 	#FF2862FB��6'   $ 0Q�69   � 59      $ 	#FF9A7DFF��6'   $ 1Q�69   5:      ��5<      �� 5=      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5>      � $ 	#FF00A2FF��6'   $ 0Q�69   � 5?      $ 	#FF1700FF��6'   $ 1Q�69   5@      5D      5E      �� 5F   
   $��Cambio de Contraseña��6   $��364,169,350,0q�6/   $	��Top=�6F   $��36(�6^   $��Bahnschrift Light)�6l   ���	#DD0000006�   �� 5G   
   $
��Left=�6   $��64��6+   $��183,156,0,0q�67   $	��Top=�6L   $��64��6d   $��Imagenes/Isotipo.png��6o   �� 5H   
   $!��Rut(Con digito verificador)��6   $��339,288,580,0q�66   $	��Top=�6M   $��14(�6e   �� 5I   
   $��Contraseña Nueva��6   $��389,348,580,0q�6+   $	��Top=�6B   $��14(�6Z   �� 5J   
   -   5         ��Name$ txtRun��5J      $��29��6"   $��541,286,375,0q�6.    �� TextWrapping$
 Wrap=�6E   $	��Top=�6Z   $��14(�6r   $	��200��6�    �� 	MaxLength$ 9��6�   G� 5K   
   -   5         G�Name$ txtPassword��5K      $��541,339,375,0q�6+   $	��Top=�6B   $��14(�6[    G� 	MaxLength$	 100��6i   �� 5N   
   $��Confirmar Contraseña��6   $��373,398,580,0q�6/   $	��Top=�6F   $��14(�6^   G� 5O   
   -   5        $ txtPasswordConfirma��5O      $��541,397,375,0q�63   $	��Top=�6J   $��14(�6c   $	 100��6q   �� 5P   
   -   5        $ 	btnCerrar��5P      $��x��6$   $��	0,10,10,0q�60   $��18(�6p   $��0q�6~   $��Right=�6�   $��33��6�   $	��Top=�6�   ��6C   Z� ��6Y   Z� 6�   �� 5Q   
   -	   5        $ btnMaximizar��5Q      $��o��6'   $��	0,10,43,0q�63   $��18(�6s   $��0q�6�   $��Right=�6�   $��33��6�   $	��Top=�6�   {�.  ��6F   Z� ��6\   Z� 6�   �� 5R   
   -
   5        $ btnMinimizar��5R      $��-��6'   $��	0,10,81,0q�63   $��18(�6s   $��0q�6�   $	��Top=�6�   $��Right=�6�   $��33��6�   ��6F   Z� ��6\   Z� 6�   �� 5S   
   -   5        $ 	btnVolver��5S      $��volver��6$   $	��Top=�66   $��51��6g   
�������$
��Bold"�6�   $��18(�6�   $��Microsoft JhengHei)�6�   $��10,629,997,0q�6�   ���	#DDA6A6A6���	#FF9595956�   5T      5U      