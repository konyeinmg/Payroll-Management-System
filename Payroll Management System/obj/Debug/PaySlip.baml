   M S B A M L   `   `   `  ����T  PPayroll Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Payroll_Management_SystemPayroll_Management_System  5   	   '    !Payroll_Management_System.PaySlip   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Payroll_Management_System     5   	   -   5          � Icon$2  , D:\Nyein Chan Aung\C# Problems\Photos\1.png��5   	    � Title$ PaySlip��5	   	   $	��500��6   $	��490��6&    � WindowStartupLocation$ CenterScreen=�62    � 
ResizeMode$ CanMinimize=�6W   .��5
      � ���	#FFF7F0F0.+�5   
   ��  �� Orientation$ Vertical=�6   $	��210��6,   $
��Left=�68   $	��300��6S   .+�5      �� $ 
Horizontal=�6   $��40��62   $��5,5,5,5q�6>   .+�5      �� $
��Name��6   $��25��6(   $��15,5,5,5q�64   $��40��6F   
����  �6Q   �� 5      -   5         ��Name$ txtname��5      $	��120��6+   $��25��67   $��15,5,5,5q�6C   
����  �6l   5      �� 5      $ 
Horizontal=�6   $��40��62   $��5,10,5,5q�6>   .+�5      �� $��ID��6   $��25��6&   $��15,5,5,5q�62   $��40��6D   
����  �6O   �� 5      -   5        $ txtid��5      $	��120��6)   $��25��65   $��15,5,5,5q�6A   
����  �6S   5      �� 5      $ 
Horizontal=�6   $��40��62   $��5,10,5,5q�6>   .+�5      �� $��Month��6   $��25��6)   $��15,5,5,5q�65   
����  �6G   �� 5      -   5         ��Name$ txtmonth��5      $	��110��6-   $��25��69   $��23,5,5,5q�6E   
����  �.@�5      �� $	��Jan��6#   �� 5      $	��Feb��6#   �� 5      $��March��6#   �� 5      $��April��6#   �� 5      $	��May��6#   �� 5      $	��Jun��6#   �� 5      $
��July��6#   �� 5       $	��Aug��6#   �� 5!      $
��Sept��6#   �� 5"      $	��Oct��6#   �� 5#      $	��Nov��6#   �� 5$      $	��Dec��6#   5%      5&      �� 5(      $ 
Horizontal=�6   $��40��62   $��5,25,5,5q�6>   .+�5)      �� -   5         ��Name$	 pay��5)      $��PaySlip��6&   $��60��68   $��30��6C   $��60,5,5,5q�6O   
�������
����  �6�   5*      5,       � 5-   
   -   5          �Name$ frame2��5-      $
��Left=�6    $	��460��6;   $��	232,5,0,0q�6H   $	��Top=�6[   $	��235��6s   	  � NavigationUIVisibility$	 Hidden=�6   51      52      