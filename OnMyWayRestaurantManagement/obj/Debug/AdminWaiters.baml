   M S B A M L   `   `   `  ����  OnMyWayRestaurantManagement.    (OnMyWayRestaurantManagement.AdminWaiters   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  5      $	��844��5      $	��505��6   .��5      �    ContentRoot#��[  6   .+�5	   
   &   System.Windows.Controls.DataGrid  -   5           Name$  WaitersDataGrid��5	         AutoGenerateColumns .     CanUserAddRows .  $��0,0,0,35q�6_      Columns 5
      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ WaiterId��6%      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *
WaiterId+6T     5      $ 
WaiterName��6%    69   �� *
WaiterName+  5      $ WaiterFirstname��6%    6>   �� *WaiterFirstname+  5      $ Gender��6%    65   �� *Gender+   RowDetailsTemplate 5      �� 5      .R�5      �� $��10q�67   ��6    �� *Stats+67   5      5      �� 5   
   -   5        $��
New Waiter��5   (   $��Right=�6=   $��	0,0,125,4q�6Y   $	��113��6l   $��26��6x   $��Bottom=�6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6&   	 �� 
StartPoint$	 0.5,0&�67   .��5      � 
 � Color$
 White��6#    � Offset$ 1Q�61   � 5      $
 White��6#   $ 1Q�61   � 5      $
 White��6#   $ 1Q�61   � 5      $
 	#66800000��6#   5      5      �� 5    
   -   5        $��Save Waiters��5    ,   $��0,0,10,4q�6C   $��26��6U   $��Bottom=�6a   $��Right=�6|   $	��110��6�   ��5!      �� 5"      $ 0.5,1&�6&   $	 0.5,0&�67   .��5#      � $
 White��6#   $ 1Q�61   � 5$      $
 White��6#   $ 1Q�61   � 5%      $
 White��6#   $ 1Q�61   � 5&      $
 	#66800000��6#   5'      5)      �� 5*   
   -   5        $��Delete Selection��5*   ,   $��	0,0,243,4q�6G   $��26��6Z   $��Bottom=�6f   $��Right=�6�   $	��130��6�   ��5+      �� 5,      $ 0.5,1&�6&   $	 0.5,0&�67   .��5-      � $
 White��6#   $ 1Q�61   � 5.      $
 White��6#   $ 1Q�61   � 5/      $
 White��6#   $ 1Q�61   � 50      $
 	#66800000��6#   51      53      �� 54   
   -   5        $��Refresh��54   %   $��Right=�67   $��	0,0,378,4q�6S   $��98��6f   $��26��6q   $��Bottom=�6}   ��55      �� 56      $ 0.5,1&�6&   $	 0.5,0&�67   .��57      � $
 White��6#   $ 1Q�61   � 58      $
 White��6#   $ 1Q�61   � 59      $
 White��6#   $ 1Q�61   � 5:      $
 	#66800000��6#   5;      5=      5>      5?      