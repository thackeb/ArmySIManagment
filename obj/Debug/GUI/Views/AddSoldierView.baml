   M S B A M L   `   `   `  ����J  FArmySIManagment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ArmySIManagment.GUI.ViewsArmySIManagment.GUI.Views  5   	   .    (ArmySIManagment.GUI.Views.AddSoldierView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:ArmySIManagment.GUI.Views     5   	     � Title$  AddSoldierView��5   	   $	��450��6    $	��800��6-      NormalBrush#���   5	   	    � 	Resources 5       �� Source�� 5   
   $( "/GUI/Resources/ExpressionDark.xaml?�6   %    .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5       $��1* �6   �� 5!      $��1* �6   �� 5"      $��1* �6   �� 5#      $��1* �6   �� 5$      $��1* �6   �� 5%      $��1* �6   �� 5&      $��* �6   .+�5(   
   �� $��Add Soldier��6   $��0��6&   $��1��63   $��0��6D   $��14��6T   $��Center=�6i   $��20(�6�   $��Center=�6�   $
��Bold"�6�   �� 5*   
   $��	Last Name��6   $��1��6$   $��1��61   $��1��6B   $��2��6R   $��Center=�6f   $��Center=�6�   $��15(�6�   $��DemiBold"�6�   �� 5+   
   -   5         ��Name$ LastName��5+      $��2��6$   $��1��61   $��2��6A   �� 5,   
   $��
First Name��6   $��1��6%   $��1��62   $��4��6C   $��2��6S   $��Center=�6g   $��Center=�6�   $��15(�6�   $��DemiBold"�6�   �� 5-   
   -   5        $ 	FirstName��5-      $��2��6%   $��4��62   $��2��6B   �� 5.   
   $
��Rank��6   $��1��6   $��1��6,   $��7��6=   $��2��6M   $��Center=�6a   $��Center=�6~   $��15(�6�   $��DemiBold"�6�   �� 5/   
   -   5         ��Name$ Ranks��5/      $��2��6@   $��7��6M   $��2��6]    �� SelectedItem 6"   �� *Rank+6]   �� 50   
   $��Assigned Role��6   $��4��6(   $��1��65   $��1��6F   $��2��6V   $��Center=�6j   $��Center=�6�   $��15(�6�   $��DemiBold"�6�   �� 51   
   -   5        $ AssignedRole��51      $��5��6(   $��1��65   $��2��6E   �� 52   
   -   5         ��Name$ AssignRoleBtn��52      $��Assign Role��6(   $��3��6>   $��2��6N   $��5��6c   �� 53   
   -   5        $ CreateSoldierBtn��53      $��Add Soldier��6+   $��6��6A   $��3��6Q   $��6��6e   55      56      