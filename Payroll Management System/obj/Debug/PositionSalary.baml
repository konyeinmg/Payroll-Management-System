   M S B A M L   `   `   `  ����T  PPayroll Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Payroll_Management_SystemPayroll_Management_System  5   	   .    (Payroll_Management_System.PositionSalary   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Payroll_Management_System     5   	   -   5          � Icon$7  1 D:\Nyein Chan Aung\C# Problems\Photos\salary.png��5   	    � Title$ PositionSalary��5	   	   $	��400��6    $	��500��6-    � 
ResizeMode$ CanMinimize=�69    � WindowStartupLocation$ CenterScreen=�6R   .��5
      � .+�5   
   �� $
��Left=�6   $	��490��61   $��0,0,0,68q�6=   .+�5      �� $��2,2,-0.333,2q�6   $	��Top=�6/   $��30��6G   .+�5      �� 
����  �$��Center=�62   $��	150,5,0,5q�6N   $
��Left=�6a   $	��150��6|   $��Position and Salary��6�   $��14.667(�6�   $
��Bold"�6�   6�   5      �� 5      $��40��6    �� Orientation$ 
Horizontal=�6%   $��0q�6>   .+�5      �� $��10,10q�6   
����  �$��25��6B   $��45��6N   $��Position��6Y   6k   �� 5      -   5         ��Name$ txtPosition��5      $��10q�60   
����  �$	��150��6S   6a   �� 5      
����  �$��45��62   $��Salary��6=   $��	25,10,5,6q�6K   �� 5      -   5        $ 	txtSalary��5      $��10q�6-   
����  �$	��150��6P   6_   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ dataGrid��5      $
��Left=�6)   $	��214��6D   $	��490��6Q      AutoGenerateColumns .    AlternatingRowBackground
 ��·�	   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$		 155 6�   ��6x   �� 6�   5      �� 5   
   $��40��6   $ 
Horizontal=�6!   $��	0,290,5,5q�6:   .+�5      �� -   5        
 ��Name$
 update��5      $��Update��6%   $��30��66   $��50��6B   
����  �
�������$��	280,5,5,5q�6v   6�   �� 5      -   5        $

 save��5      $
��Save��6#   $��30��62   $��50��6>   
����  �
�������$��10,5,5,5q�6r   6�   �� 5      -   5        $
 delete��5      $��Delete��6%   $��30��66   $��50��6B   
����  �
�������$��10,5,5,5q�6v   6�   5      5"      5#      