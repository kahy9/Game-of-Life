   M S B A M L   `   `   `  ����G  CGame-Of-Life, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Game_Of_LifeGame_Of_Life  5   	       Game_Of_Life.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Game_Of_Life     5   	   J FWpfAnimatedGif, Version=1.4.18.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5   	   -   5          � WindowState$  	Maximized=�5   	    � WindowStyle$
 None=�5	   	    � Title$ GameOfLife-DELTA��5   	   $	��400��6"   $	��800��6/   .��5      � -   5         �Name$ gridik��5      
���   � � ColumnDefinitions 5   
   �� 5      $
��200* �6   �� 5      $
��200* �6   .+�5   
   � -   5        $ 
gameCanvas��5      $��1��6#   5      � 5   
   -   5        $ Control��5      $��0��6     � RowDefinitions 5      �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    .+�5      �� -   5         ��Name$ start��5      $��0��6$   $��Start��62   ���	#FF40A351$��48(�6m   $��Microsoft Yi Baiti)�6{   �� 5      -   5        $ generace��5      $��1��6'   $��
Generation��65   ���	#FF40A351$��Microsoft Yi Baiti)�6x   $��48(�6�   �� 5       -   5        $
 load��5       $��2��6#   $
��Load��60   ���	#FF40A351$��Microsoft Yi Baiti)�6i   $��48(�6�   �� 5!      -   5        $
 save��5!      $��3��6#   $
��Save��60   ���	#FF40A351$��Microsoft Yi Baiti)�6i   $��48(�6�   �� 5"      $��Speed��6   $��4��6$   ���	#00000000
�������$��Microsoft Yi Baiti)�6[   $��50(�6{   $��Bottom=�6�   �� 5#      -	   5        $��5��5#       � Minimum$ 10Q�6"    � SmallChange$ 10Q�6/   	 J� RenderTransformOrigin$	 0.5,0.5&�6c   
 � Maximum$

 1000Q�6�   ���	#FF40A351���	#FF40A351 J� OpacityMask �	#FF40A351$	��Top=�6�   z�5$      V� 5%      .~�5&      �� �� 5'      �� 5(       �� Angle$	 180Q�6*   T� 5)      5*      5,      5-      5.      5/      