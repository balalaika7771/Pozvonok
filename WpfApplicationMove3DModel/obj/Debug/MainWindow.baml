   M S B A M L   `   `   `  ????  WpfApplicationMove3DModel*    $WpfApplicationMove3DModel.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   \ XHelixToolkit.Wpf, Version=2015.1.715.0, Culture=neutral, PublicKeyToken=52aa3500039caf0d$hhttp://helix-toolkit.org/wpf  5   	     ? Title$#  3D визуалицазция??5   	   $	??920??6"   $
??1080??6/    ? WindowStyle$ ThreeDBorderWindow=?6<   $y?Visible=?6]    J? Effect 5      '  !HelixToolkit.Wpf.InterlacedEffect  5   
      Offset$ 10??6   .??5
      ?  ? ColumnDefinitions 5   
   ?? 5      $
??375* ?6   ?? 5      $
??142* ?6   .+?5   
   ? $??0q?6   ???	#FF1A1A1A$??1??61    5      ?? 5      $	??62* ?6#   ?? 5      $	??64* ?6#   ?? 5      $	??61* ?6#    ? RowDefinitions 5      ?? 5      $	??10* ?6    ?? 5      $	??28* ?6    ?? 5      $	??22* ?6    ?? 5      $	??26* ?6    ?? 5      $	??26* ?6    ?? 5      $	??27* ?6    ?? 5      $
??180* ?6    .+?5      ?? -   5         ??Name$ rotationSlider??5       ? Maximum$	 180Q?6-    ? Minimum$
 -180Q?6;   $??	0,22,0,21q?6J   $??1??6]   $??1??6j   $??Center=?6z   $??18??6?   ?? 5      $??55,14,55,15q?6   $??1??6-   $
??Wrap=?6:   $??R??6N   ???	#FFEEEEEE$??24(?6n   	 ?? TextAlignment$	 Center=?6|   $??Center=?6?   $??Center=?6?   $??32??6?   $??14??6?   ? 5       $??2??6   $??13,17,10,17q?6    $??Center=?65   $??14??6P   $??1??6\    5!      ?? 5"      $	??44* ?6'   ?? 5#      $	??49* ?6'   ?? 5$      $	??49* ?6'   .+?5&      	? -   5        
 	?Name$
 RX??5&       	? 	GroupName$ rotaionAxis??6*   $??X??6B   $	??5,0q?6N    K? ZIndex$ 4??6[   ???	#FFEEEEEE???	#FFEEEEEE d? 	IsChecked$
 TrueY?6?   	? 5'      -   5        $
 RY??5'      $ rotaionAxis??6*   $??Y??6B   $	??5,0q?6N   $ 4??6[   ???	#FFEEEEEE???	#FFEEEEEE$??1q?6?   $??1??6?   	? 5(      -   5        $
 RZ??5(      $ rotaionAxis??6*   $??Z??6B   $	??5,0q?6N   $ 4??6[   ???	#FFEEEEEE???	#FFEEEEEE$??2??6?   5)      ?? 5*      -   5        $??btnOpenFile??5*      .??6B   	Open file6M   ?? 5+      $??55,13,55,11.5q?6   $??3??6/   $
??Wrap=?6<   $??X??6P   $??Center=?6Y   $??Center=?6t   ???	#FFEEEEEE$??24(?6?   $??32??6?   $??14??6?   ?? 5.      -   5        $
 Xpos??5.      $ 10Q?6#   $	 -10Q?60   $??0,17,0,23.5q?6>   $??Center=?6S   $??1??6n   $??3??6~    ? LargeChange$
 0.01Q?6?   $??16??6?   ?? 5/      -   5        $
 Ypos??5/      $ 10Q?6#   $	 -10Q?60   $??0,20.5,0,20q?6>   $??Center=?6S   $??1??6n   $??4??6~   $
 0.01Q?6?   $??16??6?   6?   ?? 50      $??55,12.5,55,12q?6   $??4??6/   $
??Wrap=?6<   $??Y??6P   ???	#FFEEEEEE$??24(?6p   $??Center=?6~   $??Center=?6?   $??32??6?   $??14??6?   ?? 51      -   5        $
 Zpos??51      $ 10Q?6#   $	 -10Q?60   $??	0,22,0,23q?6>   $??Center=?6Q   $??1??6l   $??5??6|   $
 0.01Q?6?   $??14??6?   ?? 52      -	   5         ??Name$ z??52      $??55,14,55,15q?6#   $??5??68   $
??Wrap=?6E   $??Z??6Y   ???	#FFEEEEEE$??Center=?6y   $??24(?6?   $??30??6?   $??Center=?6?   $??14??6?   53      ? 54   
   $??0q?6    55      ?? 56      $??4* ?6#   ?? 57      $	??43* ?6#   .+?59      &   HelixToolkit.Wpf.HelixViewport3D  -
   5          Name$ hVp3D??59       $??	0,0,0,0.5q?60      ShowFrameRate .    RotationSensitivity$	 0.3Q?5:         ZoomSensitivity$	 0.1Q?5;         ShowCoordinateSystem . $??2??5=   /      Children. 5@      $  HelixToolkit.Wpf.DefaultLights  g? 5A      -   5        foo??5A       5B      5C      ?? 5D   
   $!??Новосибирск 2022??6   $??1??6+   $??Center=?6;   $??56.5,0,57,0.5q?6X   $??36??6o   $	??182??6{   $??22(?6?   ???	#FFE8E324$??Times New Roman)?6?   $??Bottom=?6?    J? RenderTransformOrigin$ 0.519,0.493&?6?   5H      5I      