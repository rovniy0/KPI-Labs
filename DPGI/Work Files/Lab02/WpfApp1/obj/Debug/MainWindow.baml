   M S B A M L   `   `   `  ����  WpfApp1    WpfApp1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ 
TextEditor��5   	   $	��250��6   $	��450��6,   $	��300��69   $	��600��6H    � 	Resources 5
         LinearPanelBrush � Color � Offset �� 
TargetType �� Property �� Value��%Y  &	        '�� �     �� 5   
   .��5      � $ Yellow��6   $ 0Q�6*   67   � 5      $
 Aqua��6   $	 0.5Q�6(   67   � 5      $ Yellow��6   $	 0.8Q�6*   69   5      �� 5   
   " ��6   .�5      ��  � ��
 ���� 6+   �� 5       � ��
 �����6,   �� 5       � ��$ 5q�6'   5      5      .��5      �  � ShowGridLines .  	 � RowDefinitions	 5   
   �� 5      $
��Auto �6   6,   �� 5      6   .+�5!   
   �� $��0��6   ���	#FFCBBEBE$��2q�66   
 �� CornerRadius$
 10��6J   ._�5"      �� $��0��6    �� Orientation$ 
Horizontal=�6&   #��[  6?   .+�5#      �� $��50��6   $��50��6$   $��ApplicationCommands.Open��60   .��5$      ��  � ToolTip$
 Open��6   $��./Images/Open.png��6+   5%      �� 5&      $��50��6   $��50��6$   $��ApplicationCommands.Close��60   .��5'      �� $ Clear��6   $��./Images/Clear.png��6,   5(      �� 5)      $��50��6   $��50��6$   $��ApplicationCommands.Copy��60   ��6S   ��  �� ElementName$ MainTextBox��.��5*      �� $
 Copy��6   $��./Images/Copy.png��6+   5+      �� 5,      $��50��6   $��50��6$   $��ApplicationCommands.Paste��60   ��6T   �� $ MainTextBox��.��5-      �� $ Paste��6   $��./Images/Paste.png��6,   5.      5/      50      �� 53   
   $��1��6   ���	#FFCBBEBE$��2q�66   $
 10��6J   ._�54      � #��[  6   	 55      �� 56      �� 57      $
��Auto �6$   .+�5:      �� -   5         ��Name$ MainTextBox��5:      $��0��5;      $��10q�5<       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�5>      " �� VerticalScrollBarVisibility$ Visible=�5?      ��5@      �� $ 
FontSlider�� �� Path$ Value� �� UpdateSourceTrigger$ PropertyChanged=�6w   ]� 5C      $��1��6   $��
10 5 10 10q�6)   .+�5D      �� .��6   Розмір шрифту:6,   �� 5E      -   5        $��
FontSlider��5E   7   $��4q�6   $	��100��6(    � Maximum$	 100Q�6I    � Minimum$ 12Q�6W   �� 5F      $��30��6   $��Bottom=�6(   $��OK��6Q   $
 Save��6^   $��ApplicationCommands.Save��6m   ��6@   Z� 6m   5G      5H      5I      5J      5L      