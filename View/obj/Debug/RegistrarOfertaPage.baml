   M S B A M L   `   `   `  ����?  ;View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ViewView  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      U QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5      >/clr-namespace:ControlzEx;assembly=MahApps.Metro
ControlzEx 5
          View.RegistrarOfertaPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:View     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      LmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     5	      F
ControlzEx/clr-namespace:ControlzEx;assembly=MahApps.Metro     5
        N� Title$  RegistrarOfertaPage��5      .��5      �� .��5   
   � $
��1000��6   $
��2000��6    � ColumnDefinitions 5      �� 5      $��2* �6#   �� 5      $	��23* �6#    � RowDefinitions 5      �� 5      $	��80* �6    �� 5      $	��42* �6    �� 5      $	��19* �6    �� 5      $
��281* �6    �� 5      $	��16* �6    �� 5      $	��41* �6    �� 5      $
��161* �6    �� 5      $	��41* �6    �� 5      $
��179* �6    �� 5      $	��39* �6    �� 5       $
��181* �6    �� 5!      $	��19* �6    �� 5"      $
��302* �6    �� 5#      $	��19* �6    �� 5$      $	��60* �6    �� 5%      $
��360* �6    �� 5&      $	��20* �6    �� 5'      $	��70* �6    �� 5(      $	��70* �6    �� 5)      $��0* �6    .+�5+      �� $��5q�6   $��img/oferta-ic.png��6   �� 5,      $��1��6   $��10,10,361,10q�6(   $
��Wrap=�6>   $��Administrador de Oferta��6R   $��48(�6q   �� 5-      $��1��6   $��10,77,361,16q�6(   $
��Wrap=�6>   $��Agregar Oferta��6R   $��24(�6h   $��3��6v   �� 5.      $��1��6   $
��10,0q�6(   $��2��66      View.CamposOfertaControl  5/      -   5          Name$ camposOfertas��5/   (   $��1��6?   $��10,10,361,10q�6O   $��3��6e   �� 50      $��1��6   $��10,254,280,2q�6(   $��3��6>   $��2��6K   �� 51      $��Titulo:��6   $��1��6&   $
��Left=�66   $��10,5,0,5q�6Q   $��5��6c    J� RenderTransformOrigin$ 0.474,0.288&�6p   $	��549��6�   $��18(�6�   �� 52      $��Descripcion:��6   $��1��6+   $
��Left=�6;   $��10,5,0,5q�6V   $��7��6h   $ 0.474,0.288&�6u   $	��549��6�   $��18(�6�   �� 53      -   5         ��Name$ 	tbxTitulo��53      $��1��6)   $
��Left=�69   $��
10,10,0,21q�6T   $��6��6h    �� TextWrapping$
 Wrap=�6u   $	��630��6�   �� 54      -   5        $ tbxDescripcion��54      $��1��6.   $��10,10,280,10q�6>   $��8��6T   .��6a   55      �� 56      -   5        $ tbxCondiciones��56      $��1��6.   $��10,10,280,10q�6>   $��10��6T   .��6b   58      �� 59      $��Condiciones��6   $��1��6*   $
��Left=�6:   $��10,0,0,0q�6U   $��9��6g   $	��503��6t   $��18(�6�   �� 5:      $��1��6   $��
10,0,280,0q�6(   $��11��6<   � 5;      $��1��6   $
��Left=�6#   $��12��6>   $	��640��6L    5<      �� 5=      $	��40* �6$   �� 5>      $	��40* �6$   �� 5?      $	��40* �6$   �� 5@      $
��181* �6$    5B      �� 5C      $	��30* �6'   �� 5D      $	��33* �6'   �� 5E      $	��17* �6'   .+�5G      �� $��
Productos:��6   $��10,5,5,5q�6-   �� 5H      $��Cantidad Minima:��6   $
��10,5q�63   $��1��6A   �� 5I      $��Cantidad Maxima:��6   $
��10,5q�63   $��2��6A   �� 5J      -   5         ��Name$ cbxProductos��5J      $��1��61   $��	10,5,20,5q�6A   �� 5K      -   5         ��Name$ btnAgregarDetalle��5K      $��Agregar��64   $��2��6F   $
��20,5q�6V   6d   �� 5L      -   5        $ txtCantidadMinima��5L      *  $MahApps.Metro.Controls.TextBoxHelper	   ClearTextButton	 . $��1��5M      $��	10,7,20,7q�6%   $��1��68   $
 Wrap=�6E   $�� ��6Y   6a   �� 5N      -   5        $ txtCantidadMaxima��5N      	 . $��1��5P      $��	10,7,20,7q�6%   $��2��68   $
 Wrap=�6E   $�� ��6Y   6a   &   System.Windows.Controls.DataGrid  5Q      -	   5        
  Name$
 	dtDetalle��5Q      $��10q�6.   $��3��6:   $��3��6G      CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     AutoGenerateColumns .  $��Center=�5V         Columns 5X      0  *System.Windows.Controls.DataGridTextColumn  5Y      ,  &System.Windows.Controls.DataGridColumn   Header$ Codigo��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 6i   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *Producto.CodigoProducto+6i     5Z      $ Nombre��6-   $	 120 6f    6=   �� *Producto.Descripcion+6f     5[      $ Precio Normal��6-   $	 115 6n    6D   �� *Producto.PrecioNormal+6n     5\      $ Cantidad Minima��6-   $	 120 6i    6F   �� *CantidadMinima+6i     5]      $ Cantidad Maxima��6-   $	 120 6i    6F   �� *CantidadMaxima+6i   4  .System.Windows.Controls.DataGridTemplateColumn  5^       5_      �� 5`   "   $��ELIMINAR��6-      CellTemplate 5b      �� 5c   "   .R�5d   &   �� $ btnEliminar��6-   -
   5        $��Center=�5d   \   $��Center=�6y   $��Center=�6�   $��40��6�   $��40��6�   .��5e   *   �� $��img/if_delete_678153.png��60   $
��Fill=�6R   5f   '   5g   #   5i      5k      5m      �� 5n      $��1��6   $
��Left=�6(   $��19��6C   $��10,0,0,0q�6O   $��13��6a   $	��Top=�6o   $	��630��6�   �� 5o      -   5        $ btnAbrirFolfer��5o      $��Subir Imagen��6-   $��1��6D   $��Center=�6T   $��160,5,520,5q�6q   $��14��6�   $	��240��6�   ���	#FF4D79D86�   � 5p      $��1��6   $
��Left=�6#   $	��360��6>   $��10,0,0,0q�6K   $��15��6]   $	��Top=�6k   $	��630��6�   .+�5r        -   5        $
 dtImagenesOferta��5r      $��4��65   $��1��6I   $��10,10,10,25q�6Y   $��3��6n    .   .   .   .     	RowHeight$	 140Q�5v   1    5x        5y      $ Imagen��61   $	 230 6A    5z      �� 5{   "   .R�5|   &   �� ��6,   �� *Imagen+5}   #   5        5�      $
 Ruta��6-   $	 220 6T    6;   �� *Ruta+6b     5�      $	 150 61    5�      �� 5�   "   $��ELIMINAR��6-    5�      �� 5�   "   .R�5�   &   �� $ btnEliminarImagenOferta��6-   -   5        $��Center=�5�   t   $��Center=�6�   $��Center=�6�   $��40��6�   $��40��6�   .��5�   *   �� $��img/if_delete_678153.png��60   $
��Fill=�6R   5�   '   5�   #   5�      5�      5�      �� 5�      $��1��6   $
��Left=�6(   $��20��6C   $��10,0,0,0q�6O   $��16��6a   $	��Top=�6o   $	��630��6�   � 5�      $��1��6   $
��Left=�6#   $��80��6>   $��10,0,0,0q�6J   $��17��6\   $	��Top=�6j   $	��503��6�   $��2��6�    5�      �� 5�      $
��230* �6'   �� 5�      $
��273* �6'   .+�5�      �� $��10q�6   $
��Wrap=�6(   $��Publicar Automaticamente��6<   $��18(�6\   	� 5�      -   5         	�Name$
 rbSi��5�      $��Si��6,   $��1��69   $
��Left=�6I   $��	10,15,0,0q�6d   $	��Top=�6w    	� 	GroupName$ 
automatico��6�   	� 5�      -   5        $
 rbNo��5�      $��No��6,   $��1��69   $
��Left=�6I   $��	10,38,0,0q�6d   $	��Top=�6w   $ 0.038,0.417&�6�   $ 
automatico��6�   5�      �� 5�      -   5        $��Agregar Oferta��5�      $��1��6.   $��245,10,361,10q�6>   $��18��6U   ���	#FF0AD4004	  .System.Windows.Automation.AutomationProperties 	  Name$ btnGenerarOferta��6�   5�      5�      5�      