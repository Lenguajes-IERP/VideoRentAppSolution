   M S B A M L   `   `   `  ����G  CVideoRentApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:VideoRentAppVideoRentApp  5   	       VideoRentApp.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5	   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5
   	   ,localclr-namespace:VideoRentApp     5   	     � Title$  
MainWindow��5   	   $	��700��6   $
��1200��6)    � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ Templates.xaml?�6%   %    5      .��5      � .+�5!   
   �� ���#2E333A$	��230��5"       �� Orientation$ Vertical=�5#      $
��Left=�5$      .+�5(      � $��50��6   $	��Top=�5)      $��0,30,0,0q�5*      .+�5,      �� ���#D61734$��25��5-       �� CornerRadius$ 3,0,0,3��5.      $��6��5/      $��Center=�50      $��Right=�51      �� 53      $��
VIDEO RENT��6   ���#FFFFFF$��Fonts/#Orbitron Medium)�55      $��15(�56      $��Center=�57      $��Center=�58      59      o� 5:      $	��450��6   
������ $��0,40,0,0q�69   ��5;      �� 5<      .R�5=      $� 	 $� Orientation$	 Vertical=�61   5>      .@�5A      m� $
��Home��6      Menu_Template#��[  5B      
 m� Icon
 5C      �� 5D      $��Assets/img_home.png��6    $
��None=�5E       5G      m� 5I      $��Mantenimiento��6     SubMenu_Template#��[ 5J      
 5K      �� 5L      $��Assets/img_edit.png��6    $
��None=�5M      .@�5O      m� -   5        $��Actores��5O      #��[  60   
 5Q      �� 5R      $��Assets/img_actor.png��6$   $
��None=�5S      5U      5V      m� 5W      -   5        $��Salir��5W      #��[  5X   !   
 5Y      �� 5Z      $��Assets/img_exit.png��6    $
��None=�5[      5]      5^      5_      �� 5`   
   -   5         ��Name$ MaxBtn��5`        MaxBtnStyle#��[ 5a      5b      �� 5f   
   -   5        $ CloseBtn��5f        CloseBtnStyle#��[ 5g      5h      �� 5k   
   -   5         ��Name$ MainContentArea��5k      5m      5p      