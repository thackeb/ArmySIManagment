   M S B A M L   `   `   `  ����J  FArmySIManagment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ArmySIManagment.GUI.ViewsArmySIManagment.GUI.Views  5      =    7ArmySIManagment.GUI.Views.SelectedSoldierAssignRoleView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:ArmySIManagment.GUI.Views     5         NormalBrush#���   5   7     � 	Resources  5	       �� Source�� 5
   
   $( "/GUI/Resources/ExpressionDark.xaml?�6   %    .��5      �  � ColumnDefinitions 5   
   �� 5      $��10 �6   �� 5      $	��275 �6   �� 5      $��5 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��10 �6    � RowDefinitions 5   
   �� 5      $��10 �6   �� 5      $	��300 �6   �� 5      $��5 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��10 �6   .+�5   
   �� -   5         ��Name$ 	BindRoles��5      $��1��6'   $��1��67    �� SelectedItem 6E   �� *SelectedRole+ �� View 5      �� 5      -   5        SoldierGridView�� �� AllowsColumnReorder . P�5       �� 5!      $��Position��6)    �� DisplayMemberBinding 6;   �� *
RoleName+�� 5"      $��Squad��6)    68   �� *SquadString+�� 5#      $��	Fire Team��6)    6<   �� *FireTeamString+5%      5'      �� 5(   
   $��2��6   $��1��6'   $��5��66   $��Stretch=�6@   �� 5)   
   $��2��6   $��1��6$   $��5��64   $��Stretch=�6?   �� 5+   
   -   5        	 ��Name$	 AssignRoleBtn��5+      $��Assign Role��6(   $��1��6>   $��3��6N   �� 5.   
   -   5        
 ��Name$
 
ActiveItem��5.      $��4��6-   $��1��6=   5/      50      