   M S B A M L   `   `   `  ����J  FArmySIManagment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ArmySIManagment.GUI.ViewsArmySIManagment.GUI.Views  5      1    +ArmySIManagment.GUI.Views.SoldierRosterView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:ArmySIManagment.GUI.Views     5         NormalBrush#���   5	        � 	Resources  5       �� Source�� 5   
   $( "/GUI/Resources/ExpressionDark.xaml?�6   %    .��5      �  � ColumnDefinitions 5   
   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $��5 �6   �� 5      $
��auto �6   �� 5      $��10 �6    � RowDefinitions 5   
   �� 5      $��10 �6   �� 5      $	��300 �6   �� 5      $��5 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��10 �6   .+�5   
   �� -   5         ��Name$ BindSoldiers��5      $��1��6*   $��1��6:    �� SelectedItem 6H   �� *SelectedSoldier+ �� View 5      �� 5       -   5        SoldierGridView�� �� AllowsColumnReorder . P�5"      �� 5#      $��	Last Name��6)    �� Width$	 100��6g   	 �� DisplayMemberBinding	 6<   �� *
LastName+6g   �� 5$      $��
First Name��6)   $	 100��6h   	 6=   �� *	FirstName+6h   �� 5%      $
��Rank��6)   $	 100��6d   	 67   �� *
RankString+6d   �� 5&      $��Status��6)   $	 100��6h   	 69   �� *StatusString+6h   5(      5*      �� 5+   
   $��2��6   $��1��6'   $��5��66   $��Stretch=�6@   �� 5,   
   $��2��6   $��1��6$   $��5��64   $��Stretch=�6?   �� 5-   
   -   5        
 ��Name$
 
ActiveItem��5-      $��3��6-   $��1��6=   �� 5.   
   -   5         ��Name$ AddSoldierBtn��5.      $��Add Soldier��6(   $��1��6>   $��3��6N   �� 5/   
   -   5        $ RemoveSoldierBtn��5/      $��Remove Soldier��6+   $��1��6D   $��4��6T   50      51      