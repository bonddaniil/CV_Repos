   M S B A M L   `   `   `  ����@  <Lab_4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab_4Lab_4  5   	       Lab_4.RedactMusicians   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Lab_4     5   	     � Title$  	Musicians��5   	   $	��450��6   $	��800��6(   .��5	      � ��5
   
   �� 5       �� ImageSource$ /фонМуз.png��6    J� OpacityMask 5   
   �� 5      $ /фонМуз.png��6   .+�5   
   �� -   5         ��Name$
 Exit��5      $��У меню��6   $
��Left=�60   $��668,351,0,0q�6K   $	��Top=�6`   $��42��6x   $��98��6�    �	#FFF10606���	#FFF60202$
��Bold"�6�   �� 5   
   -   5         ��Name$ IdAdd��5      $
��Left=�6!   $��
646,38,0,0q�6<    �� TextWrapping$
 Wrap=�6P   $��Введіть Id��6d   $	��Top=�6v   $	��120��6�   �� 5   
   -   5        $ 
SurnameAdd��5      $
��Left=�6&   $��
646,87,0,0q�6A   $
 Wrap=�6U   $%��Введіть прізвище��6i   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ NameAdd��5      $
��Left=�6#   $��646,136,0,0q�6>   $
 Wrap=�6S   $��Введіть ім'я��6g   $	��Top=�6{   $	��120��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ MusiciansDg��5      $��0,2,347,244q�6S   �� 5   
   -   5        $ AddMButt��5      $%��Додати музиканта��6#   $
��Left=�6>   $��646,260,0,0q�6Y   $	��Top=�6n   $��34��6�   $	��120��6�    �	#FFCC1313���	#FF08F7286�   �� 5   
   -   5        $ SurnameDelete��5      $
��Left=�6)   $��
66,231,0,0q�6D   $
 Wrap=�6X   $%��Введіть прізвище��6l   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ DeleteMusicianButton��5      $)��#Видалити музиканта��6/   $
��Left=�6L   $��
47,270,0,0q�6g   $	��Top=�6{   ���	#FFF6B306$��38��6�   $	��139��6�   �� 5   
   -	   5         ��Name$ ChooseGroup��5      $
��Left=�6(   $��646,177,0,0q�6C   $	��Top=�6X   $	��120��6p    J� RenderTransformOrigin$ 
0.299,0.72&�6|   �� 5   
   -
   5        $ ProffecionChoose��5      $
��Left=�6-   $��646,215,0,0q�6H   $	��Top=�6]   $	��120��6u   5      5      