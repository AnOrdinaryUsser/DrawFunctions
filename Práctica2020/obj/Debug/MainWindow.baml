   M S B A M L   `   `   `  ����l  hSystem.Windows.Controls.DataVisualization.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null�{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting  5   	   H DPráctica2020, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Práctica2020Práctica2020 5   	      Práctica2020.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   �ChartToolKit{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     5   	   -localclr-namespace:Práctica2020     5   	     � Title$  GoExcel��5	   	   $	��500��5
   	   $
��1000��5   	    � Icon$ GoExcel.ico��5   	    � 	Resources 5      �{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting  5      C   =System.Windows.Controls.DataVisualization.Charting.LegendItem �� 
TargetType �� Property �� Value   MyColumnDataPointStyleH   BSystem.Windows.Controls.DataVisualization.Charting.ColumnDataPoint �� 
TargetType �� Color ��Name	 J� Opacity�� 5   
   D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6   :x,http://schemas.microsoft.com/winfx/2006/xaml     5      �chartingToolkit{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit  5      %�  '        &	  J     �� 5      "  6   .�5      ��  � ��
 ���� 6/   5      �� 5      "  63   .�5      ��  � ��
 � � �6/   �� 5       � ��
 ���� 60   �� 5       � ��$	 0.5q�64   �� 5       � �� .  6.   �� 5       � �� 5      �� 5      "  6*   .R�5      � #��z��6#   .+�5    "   �� ��5!   &   �� 5"   *   $ #229954��6:   5$   #   �� 5%   "   ���#229954$��1q�6?   �� 5&   "   $ SelectionHighlight��6,   
��� � �$	 0Q�6U   �� 5'   "   $ MouseOverHighlight��6,   
�������$	 0Q�6U   5(      5)      5+      5,      5-      .��50      � 
������ 
 � RowDefinitions
 51   
   �� 52      $��20 �6   �� 53      $��* �6   �� 54      $
��Auto �6    � ColumnDefinitions 56   
   �� 57      $��* �6   �� 58      $��* �6   .+�5;   
   o� 
�������$��Center=�6&   $��0��6A   $��2��6N   .@�5<      m� -   5        $��Archivos��5<   )   $��_Archivo��6   .@�5=      m� -   5        $��introduccionManual��5=   9   $��_Introducción manual��6    � ToolTip$3 -Añade los puntos para construir una función��5>      5?      m� 5@      -   5        $��introduccionAutomatica��5@   =   $ ��_Introducción automática��6   $3 -Añade los puntos para construir una función��5A      5B      m� 5C      -   5        $��Save_Canvas��5C   -   $��_Guardar��6   $) #Guarda el canvas en un fichero .png��5D      5E      5F      m� 5H      $	��Ver��6   .@�5I      m� -   5        $��GraphicChart��5I   I   $,��&_Representación en gráfica de barras��6   $= 7Representación de los puntos en una gráfica de barras��5J       m� IsCheckable . 5K      m� 5L      -   5        $��GraphicLine��5L   A   $$��_Representación en polilínea��6   $5 /Representación de los puntos en una polilínea��5M       . 5N      m� 5O      -   5        $��	purgeMode��5O   C   $%��_Mostrar rectángulo modo purga��6   $( "Habilita el rectangulo para purgar��5P       . 5R      5S      5T      �� 5U   
   $��1��6   $��0��6   
���   �$��2q�6C   
������� �� CornerRadius$ 2��6o   $��20,20,20,20q�6�   �� 5V   
   -   5         ��Name$ GraphicPanel��5V      $��1��5W      $��0��6   $��20,20,20,20q�6.   
������ }�. .+�5^      �� -	   5        $ 	rectPurge��5_      
������$	 50Q�5a      $y�	Collapsed=�5b      5c      >   8System.Windows.Controls.DataVisualization.Charting.Chart  5e   
   -
   5          Name$ BarChar��5e      $��1��5f      $��1��6!   
�������   Title$ Gráfica de barras��6I   $��20,20,20,20q�6c      Series 5h      E   ?System.Windows.Controls.DataVisualization.Charting.ColumnSeries  ?   9System.Windows.Controls.DataVisualization.Charting.Series   Title$ Coord.��6,   H   BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries   DataPointStyle# [  5i   #      ItemsSource 5j   #   �� *ListaCordenadasPuntos+   IndependentValueBinding 5k   !   �� *CoordinateX+   DependentValueBinding 5l   !   �� *CoordinateY+5m      5o      �� 5q   
   -   5        $��
deleteLine��5q   $   $��Eliminar��6   $��2��66   $��0��6C   $��5q�6n   $��175,0,175,10q�6z   �� 5r   
   -   5        $��deleteChart��5r   $   $��Eliminar��6   $��2��67   $��1��6D   $��5q�6q   $��175,0,175,10q�6}   5t      5u      