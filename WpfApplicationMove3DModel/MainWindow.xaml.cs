using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.Win32;
using System.Windows.Threading;
namespace WpfApplicationMove3DModel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
	/// 
	
    public partial class MainWindow : Window
    {
        Matrix3D matrix = new Matrix3D();
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        public DispatcherTimer CameraMove;
       
        public MainWindow()
        {
            InitializeComponent();
            
            var lights = new DefaultLights();
            
            hVp3D.Children.Add(lights);



        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|Object files (*.obj*)|*.obj*";
            if (openFileDialog.ShowDialog() == true)
            {
                if (openFileDialog.FilterIndex == 1)
                {
                    ObjReader r = new HelixToolkit.Wpf.ObjReader();
                    pozvonok pz = new pozvonok();
                    Model3DGroup MyModel = r.Read(pz.generateObjFile(openFileDialog.FileName));
                    foo.Content = MyModel;
                }
                if (openFileDialog.FilterIndex == 2)
                {

                    ObjReader r = new HelixToolkit.Wpf.ObjReader();
                    Model3DGroup MyModel = r.Read(openFileDialog.FileName);
                    
                    foo.Content = MyModel.Children[0];
                    
                }
                Matrix3D matrixtemp = new Matrix3D();
                matrixtemp = foo.Transform.Value;
                matrixtemp.Rotate(new Quaternion(new Vector3D(1, 0, 0), 90));
                foo.Content.Transform = new MatrixTransform3D(matrixtemp);
                matrix = foo.Transform.Value;


            }
             
        }
        private void Slider_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
        	// TODO: Add event handler implementation here.
            var axis = new Vector3D(0, 0, 1);
             if(RX.IsChecked==true)
             {
                 axis = new Vector3D(1, 0, 0);
             }
             if (RY.IsChecked == true)
             {
                 axis = new Vector3D(0, 1, 0);
             }
             if (RZ.IsChecked == true)
             {
                 axis = new Vector3D(0, 0, 1);

             }
            var angle = rotationSlider.Value;

            Matrix3D matrixtemp = new Matrix3D();
            matrixtemp = matrix;
            matrixtemp.Rotate(new Quaternion(axis, angle));

            foo.Transform = new MatrixTransform3D(matrixtemp);
			Console.WriteLine(rotationSlider.Value) ;
        }

        private void NumberTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
        	
        }

        private void Xpos_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            hVp3D.Camera.Position =  new Point3D(Xpos.Value + hVp3D.Camera.Position.X,  hVp3D.Camera.Position.Y,  hVp3D.Camera.Position.Z);
       
        }

        private void Ypos_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            hVp3D.Camera.Position = new Point3D( hVp3D.Camera.Position.X, Ypos.Value + hVp3D.Camera.Position.Y, hVp3D.Camera.Position.Z);

        }

        private void Zpos_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            hVp3D.Camera.Position = new Point3D( hVp3D.Camera.Position.X,  hVp3D.Camera.Position.Y, Zpos.Value + hVp3D.Camera.Position.Z);

        }


    }
}
