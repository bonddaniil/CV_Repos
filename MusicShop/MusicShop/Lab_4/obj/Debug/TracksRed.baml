   M S B A M L   `   `   `  ����@  <Lab_4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab_4Lab_4  5   	       Lab_4.TracksRed   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Lab_4     5   	     � Title$  Tracks��5   	   $	��450��6   $	��800��6%   .��5	      � ��5
   
   �� 5       �� ImageSource$ /фонТреки.jpg��6   .+�5   
   �� -   5         ��Name$ 
IdTrackAdd��5      $
��Left=�6&   $��
649,10,0,0q�6A    �� TextWrapping$
 Wrap=�6U   $"��Введіть Id треку��6i   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ TrackNameAdd��5      $
��Left=�6(   $��
649,87,0,0q�6C   $
 Wrap=�6W   $*��$Введіть назву треку��6k   $	��Top=�6�   $	��120��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ TracksDg��5      $��0,0,359,252q�6P   �� 5   
   -   5         ��Name$ 
TrackAddBt��5      $��Додати трек��6%   $
��Left=�6;   $��	664,0,0,0q�6V   $��Center=�6i   $��44��6�   $	��105��6�    J� RenderTransformOrigin$ 1.413,1.027&�6�   ���	#FF2DF4086�   �� 5   
   -   5        $ DeleteTrackName��5      $
��Left=�6+   $��
19,221,0,0q�6F   $
 Wrap=�6Z   $*��$Введіть назву треку��6n   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ DeleteTrackBt��5      $��Видалити трек��6(   $
��Left=�6@   $��
32,261,0,0q�6[   $	��Top=�6o   $	��107��6�   $��38��6�   ���	#FFF997116�   �� 5   
   -   5        $ ExitBt��5      $��У меню��6!   $
��Left=�62   $��664,361,0,0q�6M   $	��Top=�6b   $��46��6z   $	��105��6�   ���	#FFFA0808$
��Bold"�6�   �� 5   
   -   5         ��Name$ ChooseGroup��5      $
��Left=�6(   $��648,125,0,0q�6C   $	��Top=�6X   $	��120��6p   �� 5   
   -	   5        $ CircumsChoose��5      $
��Left=�6*   $��649,160,0,0q�6E   $	��Top=�6Z   $	��120��6r   �� 5   
   -
   5        $ RecordsChoose��5      $
��Left=�6*   $��
649,43,0,0q�6E   $	��Top=�6Y   $	��120��6q   5      5      