   M S B A M L   `   `   `  ����E  APortafolio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Portafolio
Portafolio  5      #    Portafolio.P_BusquedaAsesoria   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $localclr-namespace:Portafolio  5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5      $
��1116��5	      $	��690��6,   .��5
      � 
�������.+�5   
   )  #MaterialDesignThemes.Wpf.DialogHost     MaterialDesignDevider#���   6$       DialogContent  5      � 5      $	��300��6   $	��150��6#   $��Center=�60   .+�5      ��  �� Orientation$ 
Horizontal=�6!   $��15q�6:   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ QuestionMark=�62     PrimaryHueMidBrush#��[ 6F   $��50��6w   $��50��6�   �� 5      
�������$	��200��66   $
��15 5q�6B   $
��Wrap=�6P   $"Desea generar una nueva asesoría?5      5      �� 5      $ 
Horizontal=�6!   $��Right=�6:   $��Bottom=�6V   $��15q�6q   .+�5      ��    CloseDialogCommand#��Z 6!     MaterialDesignFlatButton#���  6c   $��4q�6�   $��Center=�6�   .��6�   
Cancelar5      5      �� 5      $ 
Horizontal=�6!   $
��Left=�6:   $��Bottom=�6U   $��15q�6p   .+�5      �� -   5         ��Name$ boton_confirmacion��5   !   #��Z 6=   #���  6   $��4q�6�   $��Center=�6�   .��6�   	Confirmar5      5      5      5!      &   System.Windows.Controls.DataGrid  5"   
   -   5          Name$ dtgAsesorias��5"      $��191,236,176,178q�6)   6B   �� 5#   
   -   5         ��Name$ lblTituloProfesional��5#      $��Busqueda Asesoría��6.   $
��Left=�6J   $��
372,56,0,0q�6e   $	��Top=�6y   ���	#FF5B5B5B$��36(�6�   $��Bahnschrift Light)�6�   $
��Bold"�6�   $��49��6�   �� 5$   
   $��697,56,370,582q�6   $��burbujas-de-chat.png��6(   $��Uniform=�6F   �� 5%   
   -   5        $ 
lblEmpresa��5%      $��Empresa��6$   $
��Left=�66   $��191,176,0,0q�6Q   $	��Top=�6f   �� 5&   
   -   5         ��Name$ 
txtEmpresa��5&      $
��Left=�6&   $��22��6A   $��249,176,0,0q�6M    �� TextWrapping$
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��159��6�   	 �� 	MaxLength$	 15��6�   �� 5'   
   -   5        $ btnBuscarNombre��5'      $
��Left=�6*   $��441,164,0,0q�6E   $	��Top=�6Z   $��40��6r   $��36��6~   
���   �$
��Bold"�6�   $��0q�6�   ��6�   Z� ��6�   Z� .��5(      �� $��29��6   $��buscar(2).png��6    $��Uniform=�67   $��38��6I   5)      �� 5*   
   -   5        $ btnCancelarEmpresa��5*      $
��Left=�6-   $	��Top=�6I   $��18��6a   $��16��6m   
������ 
������ 
���   �$
��Bold"�6�   $��419,182,0,0q�6�   $��0q�6  
 J� RenderTransformOrigin$
 0.5,0.5&�6  .��5+      �� $��boton-x.png��6   $��Uniform=�6)   $��13��6;   $��14��6G   5-        5.   
   -   5        $ 	dgEmpresa��5.      $
��Left=�6&   $	��100��6A   $��249,198,0,0q�6N   $	��Top=�6c   $	��159��6{      
IsReadOnly . $   HorizontalScrollBarVisibility$ Disabled=�6�   $y�Hidden=�6
  5/      50      