   M S B A M L   `   `   `  ����?  ;View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ViewView  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      U QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5	          View.MenuEmpresaPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:View     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5	      LmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     5
        N� Title$  MenuEmpresaPage��5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��35* �6   �� 5      $	��40* �6   �� 5      $
��240* �6   �� 5      $	��80* �6   �� 5      $	��80* �6   �� 5      $	��11* �6    � RowDefinitions 5   
   �� 5      $	��85* �6   �� 5      $	��56* �6   �� 5      $	��50* �6   �� 5      $
��509* �6   .+�5   
   �� $��10,10,153,10q�6   $��2��6+   $��2��6;   .+�5      �� $��Administrador de Empresas��6   $��36(�68   $
��Bold"�6F   5       �� 5!   
   $��10q�6   $��img/bussinec-ic.png��6   $��1��69   �� 5"   
   -   5         ��Name$ btnAgregarEmpresa��5"      $�� ��5#      $��1��6    $��15,0,0,0q�60      MetroCircleButtonStyle#���   5$       J� RenderTransformOrigin$ 0.545,0.455&�6F   $��1��6j   $
��Left=�6�   $��52��6�   $��44��6�   $	��Top=�6�   ��5%      �� 5&       �� ImageSource$ img/add-ic.png��6   5(      �� 5)   
   -   5        $��txtBuscarEmpresa��5,      *  $MahApps.Metro.Controls.TextBoxHelper   ClearTextButton .    	Watermark$ Nombre Empresa��5+      $��2��5.      $
��Left=�6!   $��30��6<   $��10,6,0,0q�6H    �� TextWrapping$
 Wrap=�6Z   $�� ��6n   $	��Top=�6v   $	��160��6�   $��2��6�   .��6�   50      �� 51   
   	 �� TextAlignment$	 Center=�6   $��10q�6+   $
��Wrap=�67   $��Buscar��6K   $��18(�6Y   $��1��6g   $��2��6w   �� 52   
   -   5        $��40��52      $	 Center=�6N   $
��Wrap=�6e   $��Ingresar nueva empresa��6y   ���	#FFCFCFCF$��22(�6�   $��2��6�   $��
10,4,223,0q�6�   $��1��6�   $ 0.494,0.225&�6�   �� 53   
   $��2��6   $��355,10,10,0q�6$   $��2��69   $
��Wrap=�6F   $��Ordenar por��6Z   $��18(�6m   $y�	Collapsed=�6{   �� 54   
   $��3��6   $��	10,6,10,3q�6#   $��2��66   $��30��6C   $y�	Collapsed=�6O   �� 55   
   $��4��6   $��	10,6,10,3q�6#   $��2��66   $��30��6C   $y�	Collapsed=�6O   &   System.Windows.Controls.DataGrid  56   
   -   5        
  Name$
 	dtEmpresa��56      $��4��6&   $��1��6:   $��10,10,10,25q�6J   $��3��6_      AutoGenerateColumns .     CanUserDeleteRows .     CanUserAddRows .     Columns 5:      0  *System.Windows.Controls.DataGridTextColumn  5;      -   5        campoId��,  &System.Windows.Controls.DataGridColumn   Header$ Id��5;   6      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6`   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *	IdEmpresa+6`     5=      -   5        campoRut��$	 rut��5=   7   $	 100 6c    6D   �� *
RutEmpresa+6c     5?      -   5        campoNombre��$ Nombre��5?   :   $	 260 6l    6J   �� *NombreEmpresa+6l     5A      -   5        
campoFecha��$ Fecha de Incorporacion��5A   9   $	 180 6�    6Y   �� *FechaIncorporacion+6�     5C      -	   5        
compoLocal��$ Locales��5C   9   $	 120 6n    6J   �� *CantidadLocales+6n   4  .System.Windows.Controls.DataGridTemplateColumn  5E       5F      �� 5G      $��Editar��6%      CellTemplate 5I      �� 5J      .R�5K      �� $ btnGoEditar��6%   -
   5        $��40��5K   T   $��40��6_   .��5L   "   �� $4��.img/if_circle-edit-pen-pencil-glyph_763463.png��6(   $
��Fill=�6`   5M      5N      5P        5R       5S      �� 5T      $��Eliminar��6%    5V      �� 5W      .R�5X      �� $ btnEliminar��6%   -   5        $��Center=�5X   T   $��Center=�6q   $��Center=�6�   $��40��6�   $��40��6�   .��5Y   "   �� $��img/if_delete_678153.png��6(   $
��Fill=�6J   5Z      5[      5]      5_      5`      5a      