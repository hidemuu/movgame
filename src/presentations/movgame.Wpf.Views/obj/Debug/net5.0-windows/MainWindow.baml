   M S B A M L   `   `   `  ����L  Hmovgame.Wpf.Views, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:movgame.Wpf.Viewsmovgame.Wpf.Views  5
   	   "    movgame.Wpf.Views.MainWindow   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a;	behaviors+http://schemas.microsoft.com/xaml/behaviors  5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962ac	 _MaterialDesignThemes.MahApps, Version=0.1.9.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  	 5   	   T
 PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f8metro,http://metro.mahapps.com/winfx/xaml/controls 
 5	   	   +localclr-namespace:movgame.Wpf.Views 
 5
   	   !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5   	    � Title$ 
MainWindow��5   	   $	��600��6   $	��800��6)      AccentColorBrush( 
 "MahApps.Metro.Controls.MetroWindow   	GlowBrush# �   5   	   $��11(�5   	   $��Medium"�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	    � 
ResizeMode$ CanResizeWithGrip=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   ��5   	   :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension   J� InputBindings 5      �� 5   
    �� Gesture$ Up��6   	 �� Command	 6"   �� *KeyGestureUpCommand+�� 5   
   $
 Down��6   	 6$   �� *KeyGestureDownCommand+�� 5   
   $
 Left��6   	 6$   �� *KeyGestureLeftCommand+�� 5   
   $ Right��6   	 6%   �� *KeyGestureRightCommand+*  $Microsoft.Xaml.Behaviors.Interaction
   Triggers
 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ Loaded��6!   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6,   �� *LoadedCommand+5        5    
   $ KeyUp��6!   . 5!         6,   �� *KeyUpCommand+5"      .��5$      ]� $��10q�6   .+�5%   
   �� -   5         ��Name$ 
mainRegion��5%      !	  Prism.Regions.RegionManager 	  
RegionName$ 
MainRegion��6-    	  RegionManager 6Y   �� *RegionManager+5&      5'      