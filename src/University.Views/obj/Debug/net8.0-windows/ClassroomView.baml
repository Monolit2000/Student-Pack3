   M S B A M L   `   `   `  ����  University.Views$    University.Views.ClassroomView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5       �� MergedDictionaries �� Source�� 5   
    5	      �� 5
      $6 0/University.Views;component/SharedResources.xaml?�6%   %    5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ]� $��0��6   $��False��6!   .+�5      �� $��Add Classroom��6   $��Right=�6E   $��5q�6\      PrimaryButton#��[  6g   
 � Tag$	 ��6�   ��6-   �� *Add+6�   5      �� 5   
   $��1��6   $��0q�6C     ListViewPrimaryItem#��[ 6W   ��6    �� *
Classrooms+ �� View 5      �� 5      .P�5      �� $��Location��6%    �� DisplayMemberBinding 67   �� *
Location+ �� CellTemplate 5      �� 5      .R�5   "   �� ��6,   �� *
Location+5      5      �� 5       $��Capacity��6%    67   �� *
Capacity+ 5!      �� 5"      .R�5#   "   �� ��6,   �� *
Capacity+5$      5&      �� 5'      $��Available Seats��6%    6>   �� *AvailableSeats+ 5(      �� 5)      .R�5*   "   �� ��6,   �� *AvailableSeats+5+      5-      �� 5.      $��	Projector��6%    68   �� *	Projector+ 5/      �� 50      .R�51   "   �� ${�False��6K    d� 	IsChecked 6+   �� *	Projector+6K   52      54      �� 55      $��
Whiteboard��6%    69   �� *
Whiteboard+ 56      �� 57      .R�58   "   �� ${�False��6L    6+   �� *
Whiteboard+6L   59      5;      �� 5<      $��
Microphone��6%    69   �� *
Microphone+ 5=      �� 5>      .R�5?   "   �� ${�False��6L    6+   �� *
Microphone+6L   5@      5B      �� 5C      $��Description��6%    6:   �� *Description+ 5D      �� 5E      .R�5F   "   �� ��6,   �� *Description+5G      5I      �� 5J      $
��Edit��6%    5K      �� 5L      .R�5M   "   ��   SecondaryButton#��[ 6�   $	 ��6�   ��6)   �� *DataContext.Edit+	 �� RelativeSource	 �� *FindAncestor+
 �� AncestorType
 UserControl��6�   �� *ClassroomId+6�   5N      5P      �� 5Q      $��Remove��6%    5R      �� 5S      .R�5T   "   �� #��[ 6�   $	 ��6�   ��6)   �� *DataContext.Remove+	 �� *FindAncestor+
 UserControl��6�   �� *ClassroomId+6�   5U      5W      5X      5Z      5[      5\      