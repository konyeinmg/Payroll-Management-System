   M S B A M L   `   `   `  ����T  PPayroll Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Payroll_Management_SystemPayroll_Management_System  5      *    $Payroll_Management_System.Pay_Change   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:Payroll_Management_System     5        N� Title$  
Pay_Change��5	       � 	Resources 5       �� 
TargetType �� 	Resources �� Property �� Value��%�   '��       �� 5   
   " ��6    5      ���� 5      '��       " ��6   .�5      ��  �@��CornerRadius$ 8��65   5      5      5      5      .��5      � .+�5   
   �� -   5         ��Name$ 	textBlock��5      $
��Left=�6'   $��42��6B   $��	10,20,0,0q�6N   $
��Wrap=�6a   $��
Pay Change��6u   $	��Top=�6�   $	��230��6�   $��21(�6�   $
��Bold"�6�    �� TextAlignment$ Center=�6�   
�������6�   �� 5   
   -   5        $ 
textBlock1��5      $
��Left=�6(   $��27��6C   $��	10,80,0,0q�6O   $
��Wrap=�6b   $
��Name��6v   $	��Top=�6�   $��43��6�   $��12(�6�   
�������6�   �� 5   
   -   5         ��Name$ txtName��5      $
��Left=�6#   $��27��6>   $��	72,80,0,0q�6J   	 �� TextWrapping$
	 Wrap=�6]   $	��Top=�6q   $	��156��6�   $��12(�6�   6�   �� 5   
   -   5        $ 
textBlock2��5      $
��Left=�6(   $��27��6C   $��
10,125,0,0q�6O   $
��Wrap=�6c   $��ID��6w   $	��Top=�6�   $��43��6�   $��12(�6�   
�������6�   �� 5   
   -   5        $ txtID��5      $
��Left=�6!   $��27��6<   $��
72,124,0,0q�6H   $
	 Wrap=�6\   $	��Top=�6p   $	��156��6�   $��12(�6�   
 �� 
IsReadOnly
 . 6�   �� 5   
   -   5        $ txtType��5      $
��Left=�6%   $��27��6@   $��
10,172,0,0q�6L   $
��Wrap=�6`   $
��Type��6t   $	��Top=�6�   
�������$��43��6�   $��12(�6�   �� 5   
   -   5         ��Name$ comboBox��5      $
��Left=�6%   $��
74,170,0,0q�6@   $	��Top=�6T   $	��150��6l   $��25��6x   .@�5      �� $��Increase��6   �� 5      $��Decrease��6   5      �� 5    
   -   5        $ month��5       $
��Left=�6#   $��
10,215,0,0q�6>   $
��Wrap=�6R   $��Month��6f   $	��Top=�6s   $��27��6�   $��43��6�   
�������6�   �� 5!   
   -	   5         ��Name$ groupBox��5!      $��Salary��6%   $
��Left=�65   $	��123��6P   $��
10,247,0,0q�6]   $	��Top=�6q   $	��218��6�   $��12(�6�   
����ح�
�������$	��0.5q�6�   �� 5"   
   -
   5        $ 
textBlock3��5"      $
��Left=�6(   $��27��6C   $��
18,282,0,0q�6O   $
��Wrap=�6c   $��Previous��6w   $	��Top=�6�   $��51��6�   $��12(�6�   
�������6�   �� 5#   
   -   5        $ txtPrevious��5#      
 . $
��Left=�69   $��27��6T   $��
75,281,0,0q�6`   $
	 Wrap=�6t   $	��Top=�6�   $	��141��6�   $��12(�6�   �� 5$   
   -   5        $ 
textBlock4��5$      $
��Left=�6(   $��27��6C   $��
18,327,0,0q�6O   $
��Wrap=�6c   $	��Now��6w   $	��Top=�6�   $��42��6�   $��12(�6�   
�������6�   �� 5%   
   -   5        $ txtNow��5%      $
��Left=�6"   $��27��6=   $��
75,326,0,0q�6I   $
	 Wrap=�6]   $	��Top=�6q   $	��141��6�   $��12(�6�   �� 5&   
   -   5         ��Name$ button��5&      $��Submit��6!   $
��Left=�62   $��35��6M   $��
93,386,0,0q�6Y   $	��Top=�6m   $��71��6�   $��16(�6�   $
��Bold"�6�   ���	#FF71CD626�   �� 5'   
   -   5        $ comboBoxMonth��5'      $
��Left=�6*   $��27��6E   $��
75,215,0,0q�6Q   $	��Top=�6e   $	��149��6}   .@�5(      �� $	��Jan��6   �� 5)      $	��Feb��6   �� 5*      $��March��6   �� 5+      $��April��6   �� 5,      $	��May��6   �� 5-      $	��Jun��6   �� 5.      $
��July��6   �� 5/      $	��Aug��6   �� 50      $
��Sept��6   �� 51      $	��Oct��6   �� 52      $	��Nov��6   �� 53      $	��Dec��6   54      �� 56   
   -   5        $ newpaychange��56       ^� InitialShowDelay$	 300��6T    ^� ShowDuration$
 1000��6z    ^� BetweenShowDelay$
 1000��6�    � ToolTip$	 New��6�   $
��Left=�6�   $��36��6�   $��185,385,0,0q�6�   $	��Top=�6  $��35��6'  ��6'   Z� ��6>   Z� .��57      �� $4��.D:\Nyein Chan Aung\C# Problems\Photos/new1.png��6   59      5:      5<      5=      