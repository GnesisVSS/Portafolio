   M S B A M L   `   `   `  ����E  APortafolio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Portafolio
Portafolio  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5	      $    Portafolio.A_ReporteEstCliente   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Portafolio     5      _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5	      $
��1116��5
      $	��690��6,   .��5      � -   5          �Name$  print��5      
�������.+�5   
   �� -   5         ��Name$ lblRunAsociado��5      $��Run del Representante��6(   $
��Left=�6H   $��
75,138,0,0q�6c   $	��Top=�6w   $	��134��6�   �� 5   
   -   5         ��Name$ txtRunAsociado��5      $
��Left=�6*   $��24��6E   $��209,138,0,0q�6Q    �� TextWrapping$
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��110��6�    �� 	MaxLength$ 9��6�   �� 5   
   $��Reporte de Clientes��6   $
��Left=�6.   $��
386,41,0,0q�6I   $	��Top=�6]   ���	#FF5B5B5B$��36(�6�   $��Bahnschrift Light)�6�   $
��Bold"�6�   $	��323��6�   �� 5   
   -   5         ��Name$ 	btnBuscar��5      $
��Left=�6$   $	��Top=�6@   $��38��6X   $��28��6d   
������ 
������ 
���   �$
��Bold"�6�   $��342,134,0,0q�6�   $��0q�6�   .��5      �� $��buscar(2).png��6   $��Uniform=�6+   $��29��6=   $��28��6I   5      � 5   
   $��160,229,586,75q�6   .+�5      �� -   5         ��Name$ BorderG2��5       �� CornerRadius$ 15��6'   ��5      �� 5       �� EndPoint$ 0.5,1&�6*   	 �� 
StartPoint$	 0.5,0&�6;   .��5      � 
 � Color$
 	#FFBEFFFF��6'    � Offset$ 0Q�69   � 5      $
 	#FFA692FF��6'   $ 1Q�69   5      5        LiveCharts.Wpf.PieChart  5      -   5          Name$ Chart��5      &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Bottom=�5         InnerRadius$ 60Q�6/   $��16,67,17,39q�6@   $y�Visible=�6V      Series 5   *   �� *SeriesCollection2+   ChartLegend 5      "  LiveCharts.Wpf.DefaultLegend  5         
BulletSize$ 20Q�6(      DataTooltip 5       #  LiveCharts.Wpf.DefaultTooltip  5!         
BulletSize$ 20Q�6)   5#        5$      -   5        $ ChartActCli��5$      $ Bottom=�5%      $ 60Q�6/   $��16,67,17,39q�6@   $y�Hidden=�6U    5$   0   �� *SeriesCollection4+ 5&        5'      $ 20Q�6(    5)        5*      $ 20Q�6)   5,      5-      � 5.   
   $��580,229,171,75q�6   ��5/      �� 50      $ 0.5,1&�6&   $	 0.5,0&�67   .��51      � $
 	#FFFCBEFF��6#   $ 0Q�65   � 52      $
 	#FF9F8CF7��6#   $ 1Q�65   53       J� OpacityMask 56      !� 57       !� Visual 6   ��  �� ElementName$ BorderG2��.+�59        -   5        $ prueba2��59      $ Bottom=�6,   $ 0Q�6h   $��50,82,50,26q�6x    6D   �� *SeriesCollection+ 5:        5;      $ 15Q�6(   $��8(�68   $
��Bold"�6O   6c    5=        5>      $ 20Q�6)   6;   5@      5A      �� 5B   
   $��Actividades por Estado��6   $
��Left=�61   $��258,261,0,0q�6L   $	��Top=�6a   $	��154��6y   ���	#DD000000$��Corbel)�6�   $��14(�6�   $
��Bold"�6�   �� 5C   
   $��Cantidad de Actividades��6   $
��Left=�62   $��688,261,0,0q�6M   $	��Top=�6b   $	��154��6z   ���	#DD000000$��Corbel)�6�   $��14(�6�   $
��Bold"�6�   �� 5D   
   $��Rut de la empresa��6   $
��Left=�6,   $��412,138,0,0q�6G   $	��Top=�6\   �� 5F   
   -	   5        $ lblRunEmpresa��5F      $�� ��6'   $
��Left=�62   $��412,168,0,0q�6M   $	��Top=�6b   �� 5G   
   $��Nombre de la empresa��6   $
��Left=�6/   $��552,138,0,0q�6J   $	��Top=�6_   �� 5H   
   -
   5        $ lblNombreEmpresa��5H      $�� ��6*   $
��Left=�65   $��552,168,0,0q�6P   $	��Top=�6e   �� 5I   
   $��Nombre Rep.��6   $
��Left=�6&   $��724,138,0,0q�6A   $	��Top=�6V   �� 5J   
   -   5        $ lblRepNombre��5J      $�� ��6&   $
��Left=�61   $��724,168,0,0q�6L   $	��Top=�6a   �� 5K   
   $��Rut del rep-��6   $
��Left=�6'   $��874,138,0,0q�6B   $	��Top=�6W   �� 5L   
   -   5        $ 	lblRepRut��5L      $�� ��6#   $
��Left=�6.   $��874,168,0,0q�6I   $	��Top=�6^   �� 5M   
   -   5        $ btnPDF��5M      $��Generar PDF��6!   $
��Left=�67   $��970,612,0,0q�6R   $	��Top=�6g   $	��118��6   
�������
���   �$
��Bold"�6�   $��40��6�   ��5N      �� 5O      $ 0.5,1&�6&   $	 0.5,0&�67   .��5P      � $
 	#FF00A2FF��6#   $ 0Q�65   � 5Q      $
 	#FF1700FF��6#   $ 1Q�65   5R      5T      �� 5U   
   $��733,28,298,606q�6   $��grafico-de-barras.png��6(   $��Uniform=�6G   �� 5V   
   -   5        $ btnActualizar��5V      $
��Left=�6(   $��	28,80,0,0q�6C   $	��Top=�6V   $��46��6n   
���   �$
��Bold"�6�   $��47��6�   $��0q�6�   {�.  ��6y   Z� ��6�   Z� .��5W      �� $��refresh(1).png��6   $��Uniform=�6,   $��37��6>   $��35��6J   5X      &   System.Windows.Controls.DataGrid  5Y   
   -   5          Name$ 
dgAsociado��5Y      $
��Left=�6'   $	��124��6B   $��209,162,0,0q�6O   $	��Top=�6d   $	��110��6|   $y�Hidden=�6�      
IsReadOnly . $   HorizontalScrollBarVisibility$ Hidden=�6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 110 6  �� 5Z   
   -   5        $ btnCancelar��5Z      $
��Left=�6&   $	��Top=�6B   $��18��6Z   $��17��6f   
������ 
������ 
���   �$
��Bold"�6�   $��319,140,0,0q�6�   $��0q�6�    J� RenderTransformOrigin$ 0.5,0.5&�6  .��5[      �� $��boton-x.png��6   $��Uniform=�6)   $��13��6;   $��14��6G   5]      �� 5^   
   -   5         ��Name$ cboCapacitaciones��5^      $
��Left=�6.   $��410,192,0,0q�6I   $	��Top=�6^   $	��120��6v    �� SelectedIndex$ 0��6�   {�.  .@�5_      �� $��Capacitaciones��6   $
��Left=�64   $	��118��6O   �� 5`      $��Visitas��6   $
��Left=�6-   $	��118��6H   5a      �� 5b   
   -   5        $ lblError��5b      $&�� No hay información para mostrar��6"   $
��Left=�6L   $��232,398,0,0q�6g   $	��Top=�6|   $��16(�6�   ���	#DD000000$y�Hidden=�6�   �� 5c   
   -   5        $ 	lblError2��5c      $&�� No hay información para mostrar��6#   $
��Left=�6M   $��646,406,0,0q�6h   $	��Top=�6}   $��16(�6�   ���	#DD000000$y�Hidden=�6�   5f      5g      