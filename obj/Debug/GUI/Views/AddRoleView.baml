   M S B A M L   `   `   `  ����J  FArmySIManagment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ArmySIManagment.GUI.ViewsArmySIManagment.GUI.Views  5   	   +    %ArmySIManagment.GUI.Views.AddRoleView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:ArmySIManagment.GUI.Views     5   	     � Title$  	Add Role ��5   	   $	��400��6   $	��600��6(    � 
ResizeMode$ NoResize=�64      NormalBrush#���   5	   
    � 	Resources 5
       �� Source�� 5   
   $( "/GUI/Resources/ExpressionDark.xaml?�6   %    .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5       $��1* �6   �� 5!      $��1* �6   �� 5"      $��1* �6   �� 5#      $��1* �6   �� 5$      $��* �6   .+�5'   
   �� $��	Role Name��6   $��1��6$   $��3��61   $��3��6A   $��1��6U   $��Center=�6f   $��Center=�6�   �� 5(   
   -   5         ��Name$ RoleName��5(      $��Enter Role Name Here��6$   $��2��6@   $��2��6N   $��5��6^   $��Center=�6r   $��Center=�6�   �� 5)   
   $��Platoons��6   $��3��6#   $��0��60   $��3��6@   $��1��6T   $��Center=�6e   $��Center=�6�   �� 5*   
   -   5         ��Name$ FirstPlatoonCheckBox��5*      $��1st Platoon��61   $��4��6G   $��1��6T   $��3��6d   �� 5+   
   -   5        $ SecondPlatoonCheckBox��5+      $��2nd Platoon��62   $��5��6H   $��1��6U   $��3��6e   �� 5,   
   -   5        $ ThirdPlatoonCheckBox��5,      $��
3rdPlatoon��61   $��6��6F   $��1��6S   $��3��6c   �� 5-   
   -   5        $ FourthPlatoonCheckBox��5-      $��
HQ Platoon��62   $��7��6G   $��1��6T   $��3��6d   �� 5.   
   $��Squads��6   $��3��6!   $��4��6.   $��3��6>   $��1��6R   $��Center=�6c   $��Center=�6�   �� 5/   
   -   5        $ FirstSquadCheckBox��5/      $��	1st Squad��6/   $��4��6C   $��5��6P   $��3��6`   �� 50   
   -   5        $ SecondSquadCheckBox��50      $��	2nd Squad��60   $��5��6D   $��5��6Q   $��3��6a   �� 51   
   -   5        $ ThirdSquadCheckBox��51      $��	3rd Squad��6/   $��6��6C   $��5��6P   $��3��6`   �� 52   
   -	   5        $ FourthSquadCheckBox��52      $��
Wpns Squad��60   $��7��6E   $��5��6R   $��3��6b   �� 53   
   $��FireTeam��6   $��3��6#   $��7��60   $��3��6@   $��1��6T   $��Center=�6e   $��Center=�6�   �� 54   
   -
   5        $ AlphaTeamCheckBox��54      $��
Alpha Team��6.   $��4��6C   $��8��6P   $��3��6`   �� 55   
   -   5        $ BravoTeamCheckBox��55      $��
Bravo Team��6.   $��5��6C   $��8��6P   $��3��6`   �� 56   
   -   5         ��Name$ 
AddRoleBtn��56      $��Add Role��6%   $��3��68   $��8��6H   $��3��6U   57      58      