   M S B A M L   `   `   `  ����E  APortafolio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Portafolio
Portafolio  5   	   $    Portafolio.A_menuAdministrador   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Portafolio     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  menuAdministrador��5	   	    � WindowStartupLocation$ CenterScreen=�6#    � Icon$ Imagenes\Isotipo.png��6H   $	��735��6e   $
��1365��6u   $	��735��6�   $
��1365��6�    � AllowsTransparency . 
������  � SizeToContent$ WidthAndHeight=�6�    � WindowStyle$
 None=�6�   .��5      � 
�������.+�5   
   �  � RowDefinitions 5      �� 5      $��65 �6    �� 5       � ColumnDefinitions 5      �� 5      $	��250 �6#   �� 5      $��* �6#   .+�5      (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ 
PrimaryMid=�6'   $��2��69   $��Stretch=�6M   $��72��6k   $��2��6w   $��0,-5,0,0q�6�   ��5      �� 5      .��5      � 	 � Color$	 	#FF0045FB��6'   
 � Offset$
 0Q�69   � 5      $	 	#FF9A7DFF��6'   $
 1Q�69   5      .��5      � .+�5      '  !MaterialDesignThemes.Wpf.PopupBox     PlacementMode$ BottomAndAlignRightEdges=�6.   $��Right=�6W   $��	0,37,12,0q�6s      PopupContent. 5      �� $	��150��6%   .+�5       �� -   5         ��Name$ 	btnPerfil��5    %   $��	Mi Perfil��68   6L   �� 5!      -   5        $ 
btn_cerrar��5!   %   $��Cerrar Sesión��69   6l   5"      5#      �� 5$      -   5        $ 	btnCerrar��5$      $��x��60   $��0,0,12,0q�6<   $��18(�6{   $��0q�6�   $��Right=�6�   $��33��6�   $	��Top=�6�   ��6N   Z� ��6d   Z� 6�   �� 5%      -   5        $ btnMaximizar��5%      $��o��63   $��0,0,45,0q�6?   $��18(�6~   $��0q�6�   $��Right=�6�   $��33��6�   $	��Top=�6�   {�.  ��6Q   Z� ��6g   Z� 6�   �� 5&      -   5        $ btnMinimizar��5&      $��-��63   $��0,0,83,0q�6?   $��18(�6~   $��0q�6�   $	��Top=�6�   $��Right=�6�   $��33��6�   ��6Q   Z� ��6g   Z� 6�   5'      5)      � 5+      $��Stretch=�6   $��1��61   $��0,22,0,0q�6>   ��5,      �� 5-      .��5.      � $	 	#FF0023FF��6'   $
 0Q�69   � 5/      $	 	#FF9A7DFF��6'   $
 1Q�69   50       52      �� 53      $��70 �6$   �� 54      $��* �6$   .+�56      � $��0��6   
�������$��	0,-20,0,6q�67   .+�57      �� $��Imagenes\Logotipo.png��6   $��Uniform=�6;   $��	52,0,55,0q�6M   58      �� 59      $��Stretch=�6   $��Disabled=�6=   $
��Auto=�6f   $��0,64,0,0q�6�   $��2��6�   .��5:      �� -   5         ��Name$
 Menu��5:   !   $��10q�6/   5;      5=      � 5?      -   5         �Name$ GridMain��5?   0   $��1��6   $��1��6#   $��0,2,0,0q�6B   5B      �� 5C   
   -	   5        
������ 
������ $��80��5C   Z   $��50��6e   $
��Left=�6q   $��258,81,0,609q�6�   .��5D      �� $��40��6   $��pagina-de-inicio(2).png��6    $��Uniform=�6A   $��40��6S   5E      5H      5J      