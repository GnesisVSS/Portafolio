   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   E APortafolio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Portafolio
Portafolio 5	   	      Portafolio.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   ;Controls,http://metro.mahapps.com/winfx/xaml/controls   5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $localclr-namespace:Portafolio  5	   	   -   5          � Title$  No más accidentes��5   	    � 
ResizeMode$ NoResize=�6#    � WindowStartupLocation$ CenterScreen=�6:    � WindowStyle$
 None=�6_    � AllowsTransparency . 
������ $
��1116��6�   $	��690��6�   
���   � � Icon$ Imagenes\Isotipo.png��6�   .��5      � .+�5   
   ��  �� CornerRadius$ 10��6   $��2��6#   ��5      �� 5      .��5      �  � Color$ 	#FFA692FF��6#    � Offset$ 1Q�65   � 5      $ 	#FFBEFFFF��6#   $ 0Q�65   5      ._�5      �� -   5        	 ��Name$	 	rctangulo��5      
�������$��306,73,328,85q�68   
 �� RadiusX$
 10��6O    �� RadiusY$ 10��6\   ��5      �� 5       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      � $ 	#FF00A2FF��6'   $ 0Q�69   � 5      $ 	#FF1700FF��6'   $ 1Q�69   5      5      5      �� 5   
   -   5         ��Name$ 
txtUsuario��5      $��29��6&   $��494,259,422,0q�62    �� TextWrapping$
 Wrap=�6I   *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Usuario��6]      ClearTextButton . $	��Top=�6�   $��14(�6�   $	��200��6�   6�   G� 5   
   -   5         G�Name$ txtPassword��5      $��494,330,422,0q�6+   $	��Top=�6B   $ Contraseña��6Z    . $��14(�6�    G� 	MaxLength$	 100��6�   �� 5!   
   -   5         ��Name$ btnIngresar��5!      $��Iniciar Sesión��6&   $	��Top=�6@   $��49��6s   
�������$
��Bold"�6�   $��18(�6�   $��Microsoft JhengHei)�6�   $��394,476,422,0q�6�   ��5#      �� 5$      .��5%      � $ 	#FF2862FB��6#   $ 0Q�65   � 5&      $ 	#FF9A7DFF��6#   $ 1Q�65   5'      ��5)      �� 5*      $ 0.5,1&�6&   $ 0.5,0&�67   .��5+      � $ 	#FF00A2FF��6#   $ 0Q�65   � 5,      $ 	#FF1700FF��6#   $ 1Q�65   5-      51      �� 53   
   $��Usuario��6   $��394,269,658,0q�6"   $	��Top=�69   $��14(�6Q   �� 54   
   $��Contraseña��6   $��394,339,636,0q�6%   $	��Top=�6<   $��14(�6T   �� 55   
   $��Inicio Sesión��6   $��437,147,458,0q�6(   $	��Top=�6?   $��36(�6W   $��Bahnschrift Light)�6e   ���	#DD0000006�   �� 56   
   -   5        $��	0,82,43,0q�56      $	��Top=�6$       MahApps.Styles.Button.Circle#���   6<   $��74��6s   
�������
�������$��3q�6�   $��Right=�6�   $��76��6�   .��57      %   MahApps.Metro.Controls.FontIcon  $��Segoe MDL2 Assets)�6      Glyph$	 ��6:    J� RenderTransformOrigin$ 0.503,0.503&�6K   $��48(�6o   $��56��6}   $��84��6�   58      �� 59   
   $
��Left=�6   $��64��6+   $��
330,92,0,0q�67   $	��Top=�6K   $��77��6c   $��Imagenes/Isotipo.png��6n   �� 5:   
   -   5        $ 	btnCerrar��5:      $��x��6$   $��	0,10,10,0q�60   $��18(�6p   $��0q�6~   $��Right=�6�   $��33��6�   $	��Top=�6�   ��6C   Z� ��6Y   Z� 6�   �� 5;   
   -   5        $ btnMaximizar��5;      $��o��6'   $��	0,10,43,0q�63   $��18(�6s   $��0q�6�   $��Right=�6�   $��33��6�   $	��Top=�6�   {�.  ��6F   Z� ��6\   Z� 6�   �� 5<   
   -	   5        $ btnMinimizar��5<      $��-��6'   $��	0,10,81,0q�63   $��18(�6s   $��0q�6�   $	��Top=�6�   $��Right=�6�   $��33��6�   ��6F   Z� ��6\   Z� 6�   �� 5=   
   -
   5        $ btnContrasena��5=      $��Olvidé mi contraseña��6(   $
��Auto��6G   $��453,530,484,130q�6U   ���	#DD0017FF��6n   Z� ��6�   Z� 6�   5>      5?      