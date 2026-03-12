using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
//1
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

            CircleCreator circleCreator;
            SquareCreator squareCreator;
            TriangleCreator triangleCreator;

            switch (colorName)
            {
                case "Blue":
                    circleCreator = new BlueCircleCreator();
                    squareCreator = new BlueSquareCreator();
                    triangleCreator = new BlueTriangleCreator();
                    break;

                case "Green":
                    circleCreator = new GreenCircleCreator();
                    squareCreator = new GreenSquareCreator();
                    triangleCreator = new GreenTriangleCreator();
                    break;

                default:
                    circleCreator = new RedCircleCreator();
                    squareCreator = new RedSquareCreator();
                    triangleCreator = new RedTriangleCreator();
                    break;
            }

            Shape circle = circleCreator.CreateFigure();
            Shape square = squareCreator.CreateFigure();
            Shape triangle = triangleCreator.CreateFigure();

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

    public abstract class CircleCreator
    {
        public abstract Shape CreateFigure();
    }

    public abstract class SquareCreator
    {
        public abstract Shape CreateFigure();
    }

    public abstract class TriangleCreator
    {
        public abstract Shape CreateFigure();
    }

    public class RedCircleCreator : CircleCreator
    {
        public override Shape CreateFigure()
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
    }

    public class BlueCircleCreator : CircleCreator
    {
        public override Shape CreateFigure()
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
    }

    public class GreenCircleCreator : CircleCreator
    {
        public override Shape CreateFigure()
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
    }

    public class RedSquareCreator : SquareCreator
    {
        public override Shape CreateFigure()
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
    }

    public class BlueSquareCreator : SquareCreator
    {
        public override Shape CreateFigure()
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
    }

    public class GreenSquareCreator : SquareCreator
    {
        public override Shape CreateFigure()
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
    }

    public class RedTriangleCreator : TriangleCreator
    {
        public override Shape CreateFigure()
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

    public class BlueTriangleCreator : TriangleCreator
    {
        public override Shape CreateFigure()
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

    public class GreenTriangleCreator : TriangleCreator
    {
        public override Shape CreateFigure()
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
