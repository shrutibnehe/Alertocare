   M S B A M L   `   `   `  ����H  DAlertToCareUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:AlertToCareUI.ViewsAlertToCareUI.Views  5      /    )AlertToCareUI.Views.AdmissionAndDischarge   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:AlertToCareUI.Views     5      .��5	      � .+�5
   
   �� 
�������  �� Orientation$  Vertical=�6/   $	��500��6F   $	��320��6R   .+�5      �� $��ADMISSION And DISCHARGE��6   $��15(�68   $
��Bold"�5   
   $��0��6   $��0��60   � 5      $��0,20,0,0q�6    � RowDefinitions 5      �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��* �6$    � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $��* �6'   .+�5      �� $��0��6   $��1��6/   $  
Horizontal=�6>   .+�5      �� $��ID��6   $
��Bold"�6+   $��Center=�6>   $��70��6[   �� 5       -   5        $��id��5       $��Center=�6+   $��50��5!      .��6   5"      5#      �� 5%      $��0��6   $��2��6/   $  
Horizontal=�6>   .+�5&      �� $	��Age��6   $
��Bold"�6,   $��Center=�6>   $��70��6[   �� 5'      -   5        $	��age��5'      $��Center=�6+   $��50��5(      .��6   5)      5*      �� 5,      $��0��6   $��3��6/   $  
Horizontal=�6>   .+�5-      �� $��Bed No��6   $
��Bold"�6/   $��Center=�6A   $��70��6^   �� 5.      -   5        $��bedno��5.      $��Center=�6-   $��50��5/      6   50      �� 52      $��1��6   $��1��6/   $  
Horizontal=�6>   .+�53      �� $
��Name��6   $
��Bold"�6-   $��Center=�6?   $��70��6\   �� 54      -   5        $
��name��54      $��Center=�6,   $	��100��55      6   56      �� 57      $��1��6   $��2��6/   $  
Horizontal=�6>   .+�58      �� $��	ContactNo��6   $
��Bold"�62   $��Center=�6D   $��70��6a   �� 59      -   5        $��contact��59      $��Center=�6/   $	��100��5:      6   5B      5C      �� 5D      -   5        $��Patient Admission��5D      $	��200��61   $��40��6=   6I   �� 5E      $  
Horizontal=�6   $��0,20,0,0q�65   .+�5F      �� $!��Patient ID To be Discharged��6   $
��Bold"�6@   $��Center=�6R   �� 5G      -   5        $��	patientid��5G      $��Center=�6-   $	��100��5H      6   5I      �� 5J      -   5        $��Patient Discharge��5J      $	��200��61   $��40��6=   $��0,20,0,0q�6I   6[   5K      5L      5M      