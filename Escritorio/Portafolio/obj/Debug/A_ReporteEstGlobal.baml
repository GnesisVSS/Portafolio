   M S B A M L   `   `   `  ����E  APortafolio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Portafolio
Portafolio  5      ` \De.TorstenMandelkow.MetroChart, Version=0.9.5818.20693, Culture=neutral, PublicKeyToken=nullwTclr-namespace:De.TorstenMandelkow.MetroChart;assembly=De.TorstenMandelkow.MetroChartDe.TorstenMandelkow.MetroChart 5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5	      #    Portafolio.A_ReporteEstGlobal   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Portafolio     5      _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      e
MetroChartTclr-namespace:De.TorstenMandelkow.MetroChart;assembly=De.TorstenMandelkow.MetroChart  5      >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5	      $
��1116��5
      $	��690��6,   .��5      � -   5          �Name$  print��5      
�������.+�5   
   � $��107,253,671,100q�6    J� OpacityMask 5      !� 5       !� Visual 6   ��  �� ElementName$ BorderG2��.+�5      �� -   5         ��Name$ BorderG2��5       �� CornerRadius$ 15��6'   ��5      �� 5       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      �  � Color$ 	#FFBEFFFF��6'   	 � Offset$	 0Q�69   � 5      $ 	#FFA692FF��6'   $	 1Q�69   5      5        LiveCharts.Wpf.PieChart  5      -   5        
  Name$
 prueba��5      &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Bottom=�6+      	Hoverable .    InnerRadius$ 0Q�6�   $��50,82,50,26q�6�      Series 6C   �� *SeriesCollection+   ChartLegend 5      "  LiveCharts.Wpf.DefaultLegend  5         
BulletSize$ 15Q�6(   $��8(�68   $
��Bold"�6O   6c      DataTooltip 5      #  LiveCharts.Wpf.DefaultTooltip  5          
BulletSize$ 20Q�6)   6;   5"      5#      � 5$   
   $��471,253,307,100q�6   ��5%      �� 5&      $ 0.5,1&�6&   $ 0.5,0&�67   .��5'      � $ 	#FFFCBEFF��6#   � 5(      $ 	#FF9F8CF7��6#   $	 1Q�65   5)       5,      !� 5-       6   �� $ BorderG2��.+�5/        -   5        $��Chart��5/      $ Right=�50      $ 60Q�6.   $��32,48,26,14q�6?   $y�Hidden=�6T    5/   (   �� *SeriesCollection2+ 51        52      $ 20Q�6(   6:    54        55      $ 20Q�6)   6;   57        58      -   5        $��Chart2��58      $ Right=�59      $ 60Q�6.   $��32,48,26,14q�6?    58   )   �� *SeriesCollection3+ 5:        5;      $ 20Q�6(   6:    5=        5>      $ 20Q�6)   6;   5@      5A      �� 5B   
   $!��Reporte Estadístico Global��6   $
��Left=�65   $��
287,40,0,0q�6P   $	��Top=�6d   ���	#FF5B5B5B$��36(�6�   $��Bahnschrift Light)�6�   $
��Bold"�6�   $	��446��6�   �� 5C   
   $��733,28,298,606q�6   $��grafico-de-barras.png��6(   $��Uniform=�6G   �� 5D   
   -   5        $
��Left=�5D      $��	28,80,0,0q�6,   $	��Top=�6?   $��46��6W   
���   �$
��Bold"�6�   $��47��6�   $��0q�6�   ��6b   Z� ��6�   Z� .��5E      �� $��refresh(1).png��6   $��Uniform=�6,   $��37��6>   $��35��6J   5F      �� 5G   
   -   5         ��Name$ btnPDF��5G      $��Generar PDF��6!   $
��Left=�67   $��970,612,0,0q�6R   $	��Top=�6g   $	��118��6   
�������
���   �$
��Bold"�6�   $��40��6�   ��5H      �� 5I      $ 0.5,1&�6&   $ 0.5,0&�67   .��5J      � $ 	#FF00A2FF��6#   $	 0Q�65   � 5K      $ 	#FF1700FF��6#   $	 1Q�65   5L      5N      #  MaterialDesignThemes.Wpf.Card  5O   
   -   5          Name$ cardCantClientes��5O      $
��Left=�69   $��
79,122,0,0q�6T   $	��Top=�6h   $��82��6�   $	��161��6�   ��5P      �� 5Q      .��5R      � $ 	#FF84B6FD��6#   $	 0Q�65   � 5S      $ 	#FFAA54FF��6#   $	 1Q�65   5T      .��5V      �� -	   5         ��Name$ lblCantClientes��5V      $�� ��6-   $��Center=�68   $��10,37,10,10q�6U   $��Center=�6j   ���	#DDFFFFFF$
��Bold"�6�   $	��141��6�   $��Center=�6�   $��Center=�6�   $��18(�6   $��35��6  5W        5X   
   -
   5        $ cardCantProfesionales��5X      $
��Left=�6>   $��268,122,0,0q�6Y   $	��Top=�6n   $��82��6�   $	��172��6�   ��5Y      �� 5Z      .��5[      � $ 	#FF00DCFF��6#   $	 0Q�65   � 5\      $ 	#FF3C4DFF��6#   $	 1Q�65   5]      .��5_      �� -   5        $ lblCantProfesionales��5_      $�� ��62   $��Center=�6=   $��10,37,10,10q�6Z   $��Center=�6o   ���	#DDFFFFFF$
��Bold"�6�   $	��152��6�   $��Center=�6�   $��Center=�6�   $��18(�6  $��35��6  5`        5a   
   -   5        $ cardCant��5a      $
��Left=�61   $��465,122,0,0q�6L   $	��Top=�6a   $��82��6y   $	��172��6�   ��5b      �� 5c      .��5d      � $ 	#FF84B6FD��6#   $	 0Q�65   � 5e      $ 	#FFAA54FF��6#   $	 1Q�65   5f      .��5h      �� -   5        $ 
lblCantCap��5h      $�� ��6(   $��Center=�63   $��10,37,10,10q�6P   $��Center=�6e   ���	#DDFFFFFF$
��Bold"�6�   $	��152��6�   $��Center=�6�   $��Center=�6�   $��18(�6�   $��35��6	  5i        5j   
   -   5        $ 	cardCant2��5j      $
��Left=�62   $��664,122,0,0q�6M   $	��Top=�6b   $��82��6z   $	��172��6�   ��5k      �� 5l      .��5m      � $ 	#FF00DCFF��6#   $	 0Q�65   � 5n      $ 	#FF3C4DFF��6#   $	 1Q�65   5o      .��5q      �� -   5        $ lblCantVisita��5q      $�� ��6+   $��Center=�66   $��10,37,10,10q�6S   $��Center=�6h   ���	#DDFFFFFF$
��Bold"�6�   $	��152��6�   $��Center=�6�   $��Center=�6�   $��18(�6�   $��35��6  5r        5s   
   -   5        $ 	cardCant3��5s      $
��Left=�62   $��866,122,0,0q�6M   $	��Top=�6b   $��82��6z   $	��172��6�   ��5t      �� 5u      .��5v      � $ 	#FF84B6FD��6#   $	 0Q�65   � 5w      $ 	#FFAA54FF��6#   $	 1Q�65   5x      .��5z      �� -   5        $ lblCantContrato��5z      $�� ��6-   $��Center=�68   $��10,37,10,10q�6U   $��Center=�6j   ���	#DDFFFFFF$
��Bold"�6�   $	��152��6�   $��Center=�6�   $��Center=�6�   $��18(�6   $��35��6  5{      � 5|   
   $��841,271,38,278q�6   .+�5}        LiveCharts.Wpf.Gauge  -   5          Name$ CantClientesActivos��5}      $��0��65      Uses360Mode .    From$ 0Q�5      	   To$	 100Q�6      HighFontSize$ 60X�5�      
�������   InnerRadius$ 0X�5�         GaugeBackground �	#BE9A6CFD   	FromColor$ 	#BE3700AC��6A   $��0,0,0,10q�6W   5�      5�      � 5�   
   $��841,453,38,100q�6   .+�5�        -   5        $ CantClientesInac��5�      $��0��62    . $ 0Q�5�      $	 100Q�6   $ 60X�5�      
�������$ 0X�5�       �	#BE0085FB$ 	#BE0000FF��6@   $��0,0,0,10q�6V   5�      �� 5�   
   $��Clientes Totales��6   $
��Left=�6+   $��105,142,0,0q�6F   $	��Top=�6[   $	��107��6s   ���	#DDFFFFFF$��Bahnschrift Light)�6�   $
��Bold"�6�   $��14(�6�   �� 5�   
   $��Profesionales Totales��6   $
��Left=�60   $��283,142,0,0q�6K   $	��Top=�6`   $	��148��6x   ���	#DDFFFFFF$��Bahnschrift Light)�6�   $
��Bold"�6�   $��14(�6�   �� 5�   
   $-��'Clientes totales asignados por empleado��6   $
��Left=�6B   $��137,266,0,0q�6]   $	��Top=�6r   $	��271��6�   ���	#DD000000$��Corbel)�6�   $��14(�6�   $
��Bold"�6�   �� 5�   
   $��Actividades por Estado��6   $
��Left=�61   $��503,266,0,0q�6L   $	��Top=�6a   $	��271��6y   ���	#DD000000$��Corbel)�6�   $��14(�6�   $
��Bold"�6�   �� 5�   
   -   5         ��Name$ cboCapacitaciones��5�      $
��Left=�6.   $��471,223,0,0q�6I   $	��Top=�6^   $	��120��6v    �� SelectedIndex$ 0��6�   .@�5�      �� $��Capacitaciones��6   $
��Left=�64   $	��118��6O   �� 5�      $��Visitas��6   $
��Left=�6-   $	��118��6H   5�      �� 5�   
   $��Clientes Activos��6   $
��Left=�6+   $��901,236,0,0q�6F   $	��Top=�6[   $	��119��6s   ���	#DD000000$��Corbel)�6�   $��14(�6�   $
��Bold"�6�   �� 5�   
   $��Clientes Inactivos��6   $
��Left=�6-   $��901,423,0,0q�6H   $	��Top=�6]   $	��119��6u   ���	#DD000000$��Corbel)�6�   $��14(�6�   $
��Bold"�6�   �� 5�   
   $��Capacitaciones Totales��6   $
��Left=�61   $��476,142,0,0q�6L   $	��Top=�6a   $	��154��6y   ���	#DDFFFFFF$��Bahnschrift Light)�6�   $
��Bold"�6�   $��14(�6�   �� 5�   
   $��Visitas Totales��6   $
��Left=�6*   $��700,142,0,0q�6E   $	��Top=�6Z   $	��104��6r   ���	#DDFFFFFF$��Bahnschrift Light)�6�   $
��Bold"�6�   $��14(�6�   �� 5�   
   $��Contratos Totales��6   $
��Left=�6,   $��895,142,0,0q�6G   $	��Top=�6\   $	��125��6t   ���	#DDFFFFFF$��Bahnschrift Light)�6�   $
��Bold"�6�   $��14(�6�   5�      5�      