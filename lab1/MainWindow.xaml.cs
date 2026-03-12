using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace lab1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DrawFigures("Red");
        }

        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ColorComboBox.SelectedItem is ComboBoxItem item && item.Content != null)
            {
                string selectedColor = item.Content.ToString() ?? "Red";
                DrawFigures(selectedColor);
            }
        }

        private void DrawFigures(string colorName)
        {
            if (FigureCanvas == null)
                return;

            FigureCanvas.Children.Clear();

            IFigureFactory factory;

            switch (colorName)
            {
                case "Blue":
                    factory = new BlueFactory();
                    break;

                case "Green":
                    factory = new GreenFactory();
                    break;

                default:
                    factory = new RedFactory();
                    break;
            }

            Shape circle = factory.CreateCircle();
            Shape square = factory.CreateSquare();
            Shape triangle = factory.CreateTriangle();

            Canvas.SetLeft(circle, 70);
            Canvas.SetTop(circle, 100);

            Canvas.SetLeft(square, 300);
            Canvas.SetTop(square, 100);

            Canvas.SetLeft(triangle, 530);
            Canvas.SetTop(triangle, 100);

            FigureCanvas.Children.Add(circle);
            FigureCanvas.Children.Add(square);
            FigureCanvas.Children.Add(triangle);
        }
    }

    public interface IFigureFactory
    {
        Shape CreateCircle();
        Shape CreateSquare();
        Shape CreateTriangle();
    }

    public class RedFactory : IFigureFactory
    {
        public Shape CreateCircle()
        {
            return new Ellipse
            {
                Width = 120,
                Height = 120,
                Fill = Brushes.Red,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
        }

        public Shape CreateSquare()
        {
            return new Rectangle
            {
                Width = 120,
                Height = 120,
                Fill = Brushes.Red,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
        }

        public Shape CreateTriangle()
        {
            return new Polygon
            {
                Fill = Brushes.Red,
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                Points = new PointCollection
                {
                    new Point(60, 0),
                    new Point(0, 120),
                    new Point(120, 120)
                }
            };
        }
    }

    public class BlueFactory : IFigureFactory
    {
        public Shape CreateCircle()
        {
            return new Ellipse
            {
                Width = 120,
                Height = 120,
                Fill = Brushes.Blue,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
        }

        public Shape CreateSquare()
        {
            return new Rectangle
            {
                Width = 120,
                Height = 120,
                Fill = Brushes.Blue,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
        }

        public Shape CreateTriangle()
        {
            return new Polygon
            {
                Fill = Brushes.Blue,
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                Points = new PointCollection
                {
                    new Point(60, 0),
                    new Point(0, 120),
                    new Point(120, 120)
                }
            };
        }
    }

    public class GreenFactory : IFigureFactory
    {
        public Shape CreateCircle()
        {
            return new Ellipse
            {
                Width = 120,
                Height = 120,
                Fill = Brushes.Green,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
        }

        public Shape CreateSquare()
        {
            return new Rectangle
            {
                Width = 120,
                Height = 120,
                Fill = Brushes.Green,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
        }

        public Shape CreateTriangle()
        {
            return new Polygon
            {
                Fill = Brushes.Green,
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                Points = new PointCollection
                {
                    new Point(60, 0),
                    new Point(0, 120),
                    new Point(120, 120)
                }
            };
        }
    }
}
