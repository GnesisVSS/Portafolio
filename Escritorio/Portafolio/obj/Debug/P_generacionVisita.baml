   M S B A M L   `   `   `  ����E  APortafolio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Portafolio
Portafolio  5      #    Portafolio.P_generacionVisita   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $localclr-namespace:Portafolio  5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5      $
��1116��5      $	��690��6,   .��5	      � 
�������.+�5
   
   )  #MaterialDesignThemes.Wpf.DialogHost     MaterialDesignDevider#���   6$       DialogContent  5      � 5      $	��300��6   $	��150��6#   $��Center=�60   .+�5      ��  �� Orientation$ 
Horizontal=�6!   $��15q�6:   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ QuestionMark=�62     PrimaryHueMidBrush#��[ 6F   $��50��6w   $��50��6�   �� 5      
�������$	��200��66   $
��15 5q�6B   $
��Wrap=�6P   75Desea registrar en el sistema a la empresa ingresada?5      5      �� 5      $ 
Horizontal=�6!   $��Right=�6:   $��Bottom=�6V   $��15q�6q   .+�5      ��    CloseDialogCommand#��Z 6!     MaterialDesignFlatButton#���  6c   $��4q�6�   $��Center=�6�   .��6�   
Cancelar5      5      �� 5      $ 
Horizontal=�6!   $
��Left=�6:   $��Bottom=�6U   $��15q�6p   .+�5      �� -   5         ��Name$ boton_confirmacion��5   !   #��Z 6=   #���  6   $��4q�6�   $��Center=�6�   .��6�   	Registrar5      5      5      .��5       �� -   5        $ btnDocumento��5       $��Generar Documento��6+   $��Bottom=�6G   $��52��6b   $��Right=�6n   $	��200��6�   $��	0,0,30,45q�6�   
�������
���   �$
��Bold"�6�      OpenDialogCommand#��Z 6�   ��5!      �� 5"       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5#      �  � Color$ 	#FF00A2FF��6'   	 � Offset$	 0Q�69   � 5$      $ 	#FF1700FF��6'   $	 1Q�69   5%      5'      5)      �� 5+   
   -   5        $ 	btnVolver��5+      $��volver��6$   $
��Left=�65   $	��114��6P   $��36��6\   $��Bottom=�6h   $��	56,0,0,45q�6�   
�������
�������
���   �6�   �� 5,   
   -   5        
 ��Name$
 
lblEmpresa��5,      $��Empresa��6$   $
��Left=�66   $��144,387,0,0q�6Q   $	��Top=�6f   �� 5-   
   -   5         ��Name$ 
txtEmpresa��5-      $
��Left=�6&   $��23��6A   $��227,388,0,0q�6M    �� TextWrapping$
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��151��6�   *  $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ingrese la Empresa��6�   �� 5.   
   -   5        $
 lblFechaVisita��5.      $��Fecha Visita��6(   $
��Left=�6?   $��144,204,0,0q�6Z   $	��Top=�6o   (  "System.Windows.Controls.DatePicker  5/   
   -   5          Name$ dpFechaVisita��5/      $
��Left=�6,   $��227,204,0,0q�6G   $	��Top=�6\   $	��151��6t   �� 50   
   -   5        $
 lblItems��50      $��Items a Evaluar��6"   $
��Left=�6<   $��590,192,0,0q�6W   $	��Top=�6l   $��16(�6�   �� 51   
   $
��Left=�6   $��46��6/   $��339,297,0,0q�6;   $	��Top=�6P   $	��316��6h    J� RenderTransformOrigin$ 0.5,0.5&�6t   z�52      V� 53      .~�54      �� �� 55      �� 56       �� Angle$ -90.152Q�6&   T� 57      58      5:      �� 5;   
   -	   5        $
 lblTituloProfesional��5;      $��Visitas a Terreno��6.   $
��Left=�6J   $��
426,44,0,0q�6e   $	��Top=�6y   ���	#FF5B5B5B$��36(�6�   $��Bahnschrift Light)�6�   $
��Bold"�6�   $��49��6�   �� 5<   
   $��710,27,352,597q�6   $��mapa-de-pines.png��6(   $��Uniform=�6C   �� 5=   
   -
   5         ��Name$ item1��5=      $
��Left=�6"   $��590,291,0,0q�6=   $	��Top=�6R   {�.  6j   �� 5>   
   -   5        $ item2��5>      $
��Left=�6"   $��590,334,0,0q�6=   $	��Top=�6R   {�.  6j   �� 5?   
   -   5        $ item3��5?      $
��Left=�6"   $��590,393,0,0q�6=   $	��Top=�6R   {�.  6j   �� 5@   
   -   5        $ 
itemextra1��5@      $�� ��6'   $
��Left=�62   $��826,291,0,0q�6M   $	��Top=�6b   {�.  6z   �� 5A   
   -   5        $ 
itemextra2��5A      $�� ��6'   $
��Left=�62   $��826,335,0,0q�6M   $	��Top=�6b   {�.  6z   �� 5B   
   -   5        $ 
itemextra3��5B      $�� ��6'   $
��Left=�62   $��826,393,0,0q�6M   $	��Top=�6b   {�.  6z   �� 5C   
   -   5        $
 lblItemsObligatorios��5C      $��Items Obligatorios��6.   $
��Left=�6K   $��590,249,0,0q�6f   $	��Top=�6{   $��Italic$�6�   �� 5D   
   -   5        $
 lblItemsOpcionales��5D      $��Items Opcionales��6,   $
��Left=�6G   $��826,249,0,0q�6b   $	��Top=�6w   $��Italic$�6�   �� 5E   
   -   5        $ 	DescItem1��5E      $
��Left=�6%   $��23��6@   $��613,286,0,0q�6L   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��120��6�    �� 	MaxLength$	 100��6�   �� 5F   
   -   5        $ 	DescItem2��5F      $
��Left=�6%   $��23��6@   $��613,329,0,0q�6L   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��120��6�   $	 100��6�   �� 5G   
   -   5        $ 	DescItem3��5G      $
��Left=�6%   $��23��6@   $��613,388,0,0q�6L   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��120��6�   $	 100��6�   �� 5H   
   -   5        $ DescExtraItem1��5H      $
��Left=�6*   $��23��6E   $��870,286,0,0q�6Q   $
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��120��6�   $	 100��6�   �� 5I   
   -   5        $ DescExtraItem2��5I      $
��Left=�6*   $��23��6E   $��870,330,0,0q�6Q   $
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��120��6�   $	 100��6�   �� 5J   
   -   5        $ DescExtraItem3��5J      $
��Left=�6*   $��23��6E   $��870,388,0,0q�6Q   $
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��120��6�   $	 100��6�   �� 5K   
   -   5        $
 lblTipo��5K      $��Tipo Visita��6!   $
��Left=�67   $��144,291,0,0q�6R   $	��Top=�6g   $��70��6   �� 5L   
   -   5        $ txtTipo��5L      $
��Left=�6#   $��23��6>   $��227,286,0,0q�6J   $
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��151��6�   �� 5M   
   -   5        $ btnBuscarNombre��5M      $
��Left=�6*   $��406,375,0,0q�6E   $	��Top=�6Z   $��39��6r   $��36��6~   
���   �$
��Bold"�6�   $��0q�6�   ��6�   Z� ��6�   Z� .��5N      �� $��29��6   $��buscar(2).png��6    $��Uniform=�67   $��38��6I   5O      �� 5P   
   -   5        $ btnCancelar��5P      $
��Left=�6&   $	��Top=�6B   $��18��6Z   $��17��6f   
������ 
������ 
���   �$
��Bold"�6�   $��383,393,0,0q�6�   $��0q�6�   $ 0.5,0.5&�6  .��5Q      �� $��boton-x.png��6   $��Uniform=�6)   $��13��6;   $��14��6G   5S      &   System.Windows.Controls.DataGrid  5T   
   -   5          Name$ 	dgEmpresa��5T      $
��Left=�6&   $	��137��6A   $��227,411,0,0q�6N   $	��Top=�6c   $	��151��6{      
IsReadOnly . $y�Hidden=�6�   $   HorizontalScrollBarVisibility$ Disabled=�6�   5U      5V      