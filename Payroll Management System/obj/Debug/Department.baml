   M S B A M L   `   `   `  ����T  PPayroll Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Payroll_Management_SystemPayroll_Management_System  5   	   *    $Payroll_Management_System.Department   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Payroll_Management_System     5   	   -   5          � Icon$5  / D:\Nyein Chan Aung\C# Problems\Photos\dept.png��5   	    � Title$ 
Department��5	   	   $	��400��6   $	��510��6)    � 
ResizeMode$ CanMinimize=�65    � WindowStartupLocation$ CenterScreen=�6N   .��5
      � .+�5   
   �� $
��Left=�6   $	��490��61   $��	0,0,0,279q�6=   .+�5      �� $��2,2,-0.333,2q�6   $	��Top=�6/   $��30��6G   .+�5      �� 
����  �$��Center=�62   $��	200,5,0,5q�6N   $
��Left=�6a   $	��150��6|   $��
Department��6�   $��14.667(�6�   $
��Bold"�6�   6�   5      �� 5      $��40��6    �� Orientation$ 
Horizontal=�6%   $��0q�6>   .+�5      �� $��10,8,5,7q�6   
����  �$��25��6E   $��65��6Q   $��	Dept Name��6\   6o   �� 5      -   5         ��Name$ txtName��5      $��10q�6,   
����  �$	��150��6O   6]   �� 5      
����  �$��25��62   $��60��6>   $��	Dept Code��6I   $��10,8,5,8q�6Z   6n   �� 5      -   5        $ txtCode��5      $��10q�6+   
����  �$	��150��6N   6]   5      5      �� 5   
   $��40��6   $ 
Horizontal=�6!   $��	0,290,5,5q�6:   .+�5      �� -   5         ��Name$ update��5      $��Update��6%   $��30��66   $��50��6B   
����  �
�������$��	280,5,5,5q�6v   6�   �� 5      -   5        $
 save��5      $
��Save��6#   $��30��62   $��50��6>   
����  �
�������$��10,5,5,5q�6r   6�   �� 5      -   5        $ delete��5      $��Delete��6%   $��30��66   $��50��6B   
����  �
�������$��10,5,5,5q�6v   6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $
��Left=�6%   $	��218��6@   $��0,85,0,0q�6M   $	��Top=�6_   $	��504��6w      AutoGenerateColumns . 	   AlternatingRowBackground
	 ��·�
   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	
 245 6�   ��6�   �� 6�   5      5      