   M S B A M L   `   `   `  ����Q  MOrderTracker.WPFClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:OrderTracker.WPFClientOrderTracker.WPFClient  5   	   *    $OrderTracker.WPFClient.NameSelection   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:OrderTracker.WPFClient     5   	   -   5          � AllowsTransparency  .  � WindowStyle$
 None=�5
   	   
������  � Title$ NameSelection��5   	   $	��450��6   $	��320��6,   .��5      �� $��5q�6    �� CornerRadius$ 10��5      
�������._�5   
   �  � RowDefinitions 5      �� 5      $��40 �6    �� 5      $��* �6    .+�5      ��    
PrimaryRed#��[  6   $ 	10 10 0 0��5      ._�5      �� 
�������$��18(�5      $
��Bold"�5      .��6*   Select Restaurant6>   5      �� 5      $��1��6   $��5q�6#   ��5      �� 5      .R�5       �  � ColumnDefinitions 5!      �� 5"   "   $��* �63   �� 5#   "   $	��100 �63   .+�5%      �� 
���   ���6(   �� *Name+5&   (   �� 5'      $��1��6%   ��5(   %   �� *SelectCommand+��5)      �� 5*   "    �� 
TargetType" �6(   .�5+   &   ��  �� Property � {� �� Value . 5,   -   	 �� Triggers	 5-   &   �� 5.   *   
 �� Binding
 66   �� *IsAvailable+ �� Value	 False5/   6   .a�50   .   ��  � {� .  51   5   52   +   55   #   57      58      5:      5;      5<      5=      