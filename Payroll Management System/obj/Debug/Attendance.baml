   M S B A M L   `   `   `  ����T  PPayroll Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Payroll_Management_SystemPayroll_Management_System  5   	   *    $Payroll_Management_System.Attendance   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Payroll_Management_System     5   	   -   5          � Icon$7  1 D:\Nyein Chan Aung\C# Problems\Photos\attend.png��5   	    � Title$ 
Attendance��5	   	   $	��450��6   $	��500��6)    � WindowStartupLocation$ CenterScreen=�65    � 
ResizeMode$ CanMinimize=�6q   .��5
      � .+�5   
   �� -   5         ��Name$ textdate��5      $
��Left=�6&   $��20��6A   $��	10,25,0,0q�6M   $
��Wrap=�6`   $��	TextBlock��6t   $	��Top=�6�   $��90��6�   
����  �$��13.333(�6�   �� 5   
   -   5        $ 
textBlock1��5      $
��Left=�6(   $��20��6C   $��
120,25,0,0q�6O   $
��Wrap=�6c   $��
Attendance��6w   $	��Top=�6�   $��85��6�   
����  �$��13.333(�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $
��Left=�6%   $	��285��6@   $��0,65,0,0q�6M   $	��Top=�6_   $	��492��6w      AutoGenerateColumns .    AlternatingRowBackground
 ��·�   SelectionMode$ Extended=�6�   	   SelectionUnit$	 FullRow=�6�   ��6�   �� 6�   �� 5   
   -   5        
 ��Name$
 confirm��5      $��Confirm��6"   $
��Left=�64   $��25��6O   $��410,370,0,0q�6[   $	��Top=�6p   $��65��6�   
�������
����  �6�   �� 5   
   -   5        $

 save��5      $
��Save��6   $
��Left=�6.   $��25��6I   $��325,370,0,0q�6U   $	��Top=�6j   $��65��6�   
�������
����  �6�   5      5      