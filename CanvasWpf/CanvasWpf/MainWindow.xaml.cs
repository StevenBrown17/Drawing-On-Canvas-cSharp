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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CanvasWpf {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        List<Point> pointsList = new List<Point>();
        Ellipse e = new Ellipse() { Height = 10, Width = 10, Fill = System.Windows.Media.Brushes.DarkBlue };
        
        public MainWindow() {
            InitializeComponent();
        }

        public Double convertDouble(Double d) {
            return d * 5;
        }//end convertDouble

        private void btnAdd_Click(object sender, RoutedEventArgs e) {

            System.Console.WriteLine("Button Pressed");

            Double x;
            Double y;

            try {

                x = Convert.ToDouble(txtX.Text);
                y = Convert.ToDouble(txtY.Text);

                if(x > 100 || y > 100) {
                    throw new Exception();
                }

                Point p = new Point(convertDouble(x), convertDouble(y));
                
                Ellipse el =new Ellipse() { Height = 10, Width = 10, Fill = System.Windows.Media.Brushes.DarkBlue };
                canvas.Children.Add(el);
                Canvas.SetLeft(el, p.getX()-1);
                Canvas.SetTop(el, p.getY()+1);
                pointsList.Add(p);

                TextBlock tb = new TextBlock();
                tb.Text = "("+x+","+y+")";
                canvas.Children.Add(tb);
                Canvas.SetLeft(tb, p.getX());
                Canvas.SetTop(tb, p.getY()+10);


                if(pointsList.Count != 1) {
                    double x1 = pointsList[0].getX();
                    double y1 = pointsList[0].getY();
                    double x2 = p.getX();
                    double y2 = p.getY();
                    double distance = p.distance(pointsList[0]);

                    Line line = new Line() { X1 = x1+1, Y1 = y1+5, X2 = x2+1, Y2 = y2+5, StrokeThickness = 2, Stroke = System.Windows.Media.Brushes.DarkBlue};
                    canvas.Children.Add(line);

                    Label label = new Label();
                    label.Content = Math.Round(distance,2);
                    canvas.Children.Add(label);
                    Canvas.SetLeft(label, (x1 + x2) / 2);
                    Canvas.SetTop(label, (y1 + y2) / 2);

                }	


            } catch(Exception) {
                System.Console.WriteLine("Exception Thrown, invalid input");

            }

        }


    }//end class
}//end namespace
