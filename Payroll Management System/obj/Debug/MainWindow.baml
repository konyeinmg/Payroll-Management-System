   M S B A M L   `   `   `  ����T  PPayroll Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Payroll_Management_SystemPayroll_Management_System  5   	   *    $Payroll_Management_System.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Payroll_Management_System     5   	   -   5          � Icon$7  1D:\Nyein Chan Aung\C# Problems\Photos\payroll.png��5   	    � Title$ Payroll��5	   	   $	��631��6   $	��900��6&    � 
ResizeMode$ CanMinimize=�62    � WindowStartupLocation$ CenterScreen=�6K   ���	#FFD8D8F1.��5      � $��0,0,0,1q�6   .+�5   
   �� $��	0,5,0,540q�6    �� Orientation$ 
Horizontal=�6(   $	��900��6A   $
��Left=�6M   ���	#FF232E5F.+�5      �� -   5         ��Name$ button3��5      $
��Home��6&   $
��Left=�65   $��44��6P   $��2,0,0,0q�6\   $	��Top=�6m   $��60��6�   $��13.333(�6�   
���2͚���6�   Z� ��6�   Z� 6�   �� 5      -   5        $ button1��5      $
��View��6&   $
��Left=�65   $��44��6P   $��25,0,0,0q�6\   $	��Top=�6n   $��64��6�   $��13.333(�6�   
���2͚���6�   Z� ��6�   Z� �� 5      -   5        $ button2��5      $��Daily Process��6&   $
��Left=�6>   $��44��6Y   $��30,0,0,0q�6e   $	��Top=�6w   $��92��6�   $��13.333(�6�   
���2͚���6�   Z� ��6�   Z� �� 5      -   5        $ button��5      $��
Pay Master��6%   $
��Left=�6:   $��44��6U   $��35,0,0,0q�6a   $	��Top=�6s   $��87��6�   $��13.333(�6�   
���2͚���6�   Z� ��6�   Z� �� 5      -   5        $ buttonAutho��5      $��	Authorise��6*   $
��Left=�6>   $��44��6Y   $	��Top=�6e   $��35,0,0,0q�6}   $��87��6�   $��13.333(�6�   
���2͚���6�   Z� ��6�   Z� �� 5      -   5        $ search��5      $��80��6%   $��270,10,10,12q�6]   ��60   Z� ��6F   Z� .��5      �� $��25��6   $��80��6)   $��Center=�64   $��Center=�6O   .+�5      �� $6��0D:\Nyein Chan Aung\C# Problems\Photos\search.png��6   $��20��6V   $��0,3,52,0q�6b   �� 5      -   5         ��Name$ search1��5      $��Search��6-   
�������$��
22,-25,0,0q�6Q   $��27��6e   $��47��6q   5      5      5       � 5   
   -	   5          �Name$ frame��5      $
��Left=�6   $	��100��6:   $��0,48,0,0q�6G   $	��Top=�6Y   $	��894��6q     � NavigationUIVisibility$ Hidden=�6}   ���	#FF9BAAB0$��1q�6�   ���	#FFB8ECAC	  � Source$	 	Home.xaml?�6�    � 5   
   -
   5        $ frame1��5      $
��Left=�6    $	��474��6;   $��0,150,0,-23q�6H   $	��Top=�6]   $	��254��6u   $��1q�6�   $ Hidden=�6�   ���	#FF15BB3B$	 Search.xaml?�6�   ���	#FFF3E9E9���	#FF232E5F6�   &   System.Windows.Controls.DataGrid  5!   
   -   5        
  Name$
 dataGrid��5!      $
��Left=�6%   $	��441��6@   $��259,150,0,0q�6M   $	��Top=�6b   $	��621��6z      AutoGenerateColumns .    AlternatingRowBackground
 ��·�   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 100 6�   ��6�   ��  � 	Resources 5"      ��%    5&      5'      5)      5*      