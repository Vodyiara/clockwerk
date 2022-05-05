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
using System.Windows.Threading;



namespace Clock
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _hourAngle;
        public MainWindow()
        {
            InitializeComponent();
            CompositionTarget.Rendering += CompositionTarget_Rendering;

        }

        private void CompositionTarget_Rendering(object sender, object args)
        {
            DateTime dt = DateTime.Now;
            rotateSecond.Angle = 6 * (dt.Second + dt.Millisecond / 1000.0);
            rotateMinute.Angle = 6 * dt.Minute + rotateSecond.Angle / 60;
            rotateHour.Angle = 30 * (dt.Hour % 12) + rotateMinute.Angle / 12;

            rotateSecond1.Angle = 6 * (dt.Second + dt.Millisecond / 1000.0);
            rotateMinute1.Angle = 6 * dt.Minute + rotateSecond.Angle / 60;
            rotateHour1.Angle = 30 * ((dt.Hour +2) % 12) + rotateMinute.Angle / 12;


            rotateSecond2.Angle = 6 * (dt.Second + dt.Millisecond / 1000.0);
            rotateMinute2.Angle = 6 * dt.Minute + rotateSecond.Angle / 60;
            rotateHour2.Angle = 30 * ((dt.Hour - 2) % 12) + rotateMinute.Angle / 12;

            rotateSecond3.Angle = 6 * (dt.Second + dt.Millisecond / 1000.0);
            rotateMinute3.Angle = 6 * dt.Minute + rotateSecond.Angle / 60;
            rotateHour3.Angle = 30 * ((dt.Hour - 1) % 12) + rotateMinute.Angle / 12;

            rotateSecond4.Angle = 6 * (dt.Second + dt.Millisecond / 1000.0);
            rotateMinute4.Angle = 6 * dt.Minute + rotateSecond.Angle / 60;
            rotateHour4.Angle = 30 * ((dt.Hour - 7) % 12) + rotateMinute.Angle / 12;
        }




        const double ScaleRate = 2.0;
        private void canvas1_MouseWheel_1(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                scaleTransform1.CenterX = e.GetPosition(cnv).X;
                scaleTransform1.CenterY = e.GetPosition(cnv).Y;
                scaleTransform1.ScaleX *= ScaleRate;
                scaleTransform1.ScaleY *= ScaleRate;



            }
            else
            {
                scaleTransform1.CenterX = e.GetPosition(cnv).X;
                scaleTransform1.CenterY = e.GetPosition(cnv).Y;
                scaleTransform1.ScaleX /= ScaleRate;
                scaleTransform1.ScaleY /= ScaleRate;


          
            }
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            for (int i = 0; i < 60; ++i)
            {
                Rectangle marker = new Rectangle();
                if ((i % 5) == 0)
                {
                    marker.Width = 3;
                    marker.Height = 8;
                    marker.Fill = new SolidColorBrush(Color.FromArgb(0xe0, 0xff,
                    0xff, 0xff));
                    marker.Stroke = new SolidColorBrush(Color.FromArgb(0x80, 0x33,
                    0x33, 0x33));
                    marker.StrokeThickness = 0.5;
                }
                else
                {
                    marker.Width = 0.5;
                    marker.Height = 3;
                    marker.Fill = new SolidColorBrush(Color.FromArgb(0x80, 0xff,
                    0xff, 0xff));
                    marker.Stroke = null;
                    marker.StrokeThickness = 0;
                }
                TransformGroup transforms = new TransformGroup();

                transforms.Children.Add(new TranslateTransform(-(marker.Width / 2),
                marker.Width / 2 - 40 - marker.Height));
                transforms.Children.Add(new RotateTransform(i * 6));
                transforms.Children.Add(new TranslateTransform(50, 50));

                marker.RenderTransform = transforms;

                _markersCanvas.Children.Add(marker);
               
            }
            for (int i = 1; i <= 12; ++i)
            {
                TextBlock tb = new TextBlock();

                tb.Text = i.ToString();
                tb.TextAlignment = TextAlignment.Center;
                tb.RenderTransformOrigin = new Point(1, 1);
                tb.Foreground = Brushes.White;
                tb.FontSize = 4;

                tb.RenderTransform = new ScaleTransform(2, 2);

                double r = 34;
                double angle = Math.PI * i * 30.0 / 180.0;
                double x = Math.Sin(angle) * r + 50, y =
                -Math.Cos(angle) * r + 50;

                Canvas.SetLeft(tb, x);
                Canvas.SetTop(tb, y);

                _markersCanvas.Children.Add(tb);
                
            }




            for (int i = 0; i < 60; ++i)
            {
                Rectangle marker = new Rectangle();
                if ((i % 5) == 0)
                {
                    marker.Width = 3;
                    marker.Height = 8;
                    marker.Fill = new SolidColorBrush(Color.FromArgb(0xe0, 0xff,
                    0xff, 0xff));
                    marker.Stroke = new SolidColorBrush(Color.FromArgb(0x80, 0x33,
                    0x33, 0x33));
                    marker.StrokeThickness = 0.5;
                }
                else
                {
                    marker.Width = 0.5;
                    marker.Height = 3;
                    marker.Fill = new SolidColorBrush(Color.FromArgb(0x80, 0xff,
                    0xff, 0xff));
                    marker.Stroke = null;
                    marker.StrokeThickness = 0;
                }
                TransformGroup transforms = new TransformGroup();

                transforms.Children.Add(new TranslateTransform(-(marker.Width / 2),
                marker.Width / 2 - 40 - marker.Height));
                transforms.Children.Add(new RotateTransform(i * 6));
                transforms.Children.Add(new TranslateTransform(50, 50));

                marker.RenderTransform = transforms;

                _markersCanvas1.Children.Add(marker);

            }
            for (int i = 1; i <= 12; ++i)
            {
                TextBlock tb = new TextBlock();

                tb.Text = i.ToString();
                tb.TextAlignment = TextAlignment.Center;
                tb.RenderTransformOrigin = new Point(1, 1);
                tb.Foreground = Brushes.White;
                tb.FontSize = 4;

                tb.RenderTransform = new ScaleTransform(2, 2);

                double r = 34;
                double angle = Math.PI * i * 30.0 / 180.0;
                double x = Math.Sin(angle) * r + 50, y =
                -Math.Cos(angle) * r + 50;

                Canvas.SetLeft(tb, x);
                Canvas.SetTop(tb, y);

                _markersCanvas1.Children.Add(tb);

            }

            for (int i = 0; i < 60; ++i)
            {
                Rectangle marker = new Rectangle();
                if ((i % 5) == 0)
                {
                    marker.Width = 3;
                    marker.Height = 8;
                    marker.Fill = new SolidColorBrush(Color.FromArgb(0xe0, 0xff,
                    0xff, 0xff));
                    marker.Stroke = new SolidColorBrush(Color.FromArgb(0x80, 0x33,
                    0x33, 0x33));
                    marker.StrokeThickness = 0.5;
                }
                else
                {
                    marker.Width = 0.5;
                    marker.Height = 3;
                    marker.Fill = new SolidColorBrush(Color.FromArgb(0x80, 0xff,
                    0xff, 0xff));
                    marker.Stroke = null;
                    marker.StrokeThickness = 0;
                }
                TransformGroup transforms = new TransformGroup();

                transforms.Children.Add(new TranslateTransform(-(marker.Width / 2),
                marker.Width / 2 - 40 - marker.Height));
                transforms.Children.Add(new RotateTransform(i * 6));
                transforms.Children.Add(new TranslateTransform(50, 50));

                marker.RenderTransform = transforms;

                _markersCanvas2.Children.Add(marker);

            }
            for (int i = 1; i <= 12; ++i)
            {
                TextBlock tb = new TextBlock();

                tb.Text = i.ToString();
                tb.TextAlignment = TextAlignment.Center;
                tb.RenderTransformOrigin = new Point(1, 1);
                tb.Foreground = Brushes.White;
                tb.FontSize = 4;

                tb.RenderTransform = new ScaleTransform(2, 2);

                double r = 34;
                double angle = Math.PI * i * 30.0 / 180.0;
                double x = Math.Sin(angle) * r + 50, y =
                -Math.Cos(angle) * r + 50;

                Canvas.SetLeft(tb, x);
                Canvas.SetTop(tb, y);

                _markersCanvas2.Children.Add(tb);

            }

            for (int i = 0; i < 60; ++i)
            {
                Rectangle marker = new Rectangle();
                if ((i % 5) == 0)
                {
                    marker.Width = 3;
                    marker.Height = 8;
                    marker.Fill = new SolidColorBrush(Color.FromArgb(0xe0, 0xff,
                    0xff, 0xff));
                    marker.Stroke = new SolidColorBrush(Color.FromArgb(0x80, 0x33,
                    0x33, 0x33));
                    marker.StrokeThickness = 0.5;
                }
                else
                {
                    marker.Width = 0.5;
                    marker.Height = 3;
                    marker.Fill = new SolidColorBrush(Color.FromArgb(0x80, 0xff,
                    0xff, 0xff));
                    marker.Stroke = null;
                    marker.StrokeThickness = 0;
                }
                TransformGroup transforms = new TransformGroup();

                transforms.Children.Add(new TranslateTransform(-(marker.Width / 2),
                marker.Width / 2 - 40 - marker.Height));
                transforms.Children.Add(new RotateTransform(i * 6));
                transforms.Children.Add(new TranslateTransform(50, 50));

                marker.RenderTransform = transforms;

                _markersCanvas3.Children.Add(marker);

            }
            for (int i = 1; i <= 12; ++i)
            {
                TextBlock tb = new TextBlock();

                tb.Text = i.ToString();
                tb.TextAlignment = TextAlignment.Center;
                tb.RenderTransformOrigin = new Point(1, 1);
                tb.Foreground = Brushes.White;
                tb.FontSize = 4;

                tb.RenderTransform = new ScaleTransform(2, 2);

                double r = 34;
                double angle = Math.PI * i * 30.0 / 180.0;
                double x = Math.Sin(angle) * r + 50, y =
                -Math.Cos(angle) * r + 50;

                Canvas.SetLeft(tb, x);
                Canvas.SetTop(tb, y);

                _markersCanvas3.Children.Add(tb);

            }

            for (int i = 0; i < 60; ++i)
            {
                Rectangle marker = new Rectangle();
                if ((i % 5) == 0)
                {
                    marker.Width = 3;
                    marker.Height = 8;
                    marker.Fill = new SolidColorBrush(Color.FromArgb(0xe0, 0xff,
                    0xff, 0xff));
                    marker.Stroke = new SolidColorBrush(Color.FromArgb(0x80, 0x33,
                    0x33, 0x33));
                    marker.StrokeThickness = 0.5;
                }
                else
                {
                    marker.Width = 0.5;
                    marker.Height = 3;
                    marker.Fill = new SolidColorBrush(Color.FromArgb(0x80, 0xff,
                    0xff, 0xff));
                    marker.Stroke = null;
                    marker.StrokeThickness = 0;
                }
                TransformGroup transforms = new TransformGroup();

                transforms.Children.Add(new TranslateTransform(-(marker.Width / 2),
                marker.Width / 2 - 40 - marker.Height));
                transforms.Children.Add(new RotateTransform(i * 6));
                transforms.Children.Add(new TranslateTransform(50, 50));

                marker.RenderTransform = transforms;

                _markersCanvas4.Children.Add(marker);

            }
            for (int i = 1; i <= 12; ++i)
            {
                TextBlock tb = new TextBlock();

                tb.Text = i.ToString();
                tb.TextAlignment = TextAlignment.Center;
                tb.RenderTransformOrigin = new Point(1, 1);
                tb.Foreground = Brushes.White;
                tb.FontSize = 4;

                tb.RenderTransform = new ScaleTransform(2, 2);

                double r = 34;
                double angle = Math.PI * i * 30.0 / 180.0;
                double x = Math.Sin(angle) * r + 50, y =
                -Math.Cos(angle) * r + 50;

                Canvas.SetLeft(tb, x);
                Canvas.SetTop(tb, y);

                _markersCanvas4.Children.Add(tb);

            }


        }

        private void cnv1_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                scaleTransform2.CenterX = e.GetPosition(cnv1).X;
                scaleTransform2.CenterY = e.GetPosition(cnv1).Y;
                scaleTransform2.ScaleX *= ScaleRate;
                scaleTransform2.ScaleY *= ScaleRate;



            }
            else
            {
                scaleTransform2.CenterX = e.GetPosition(cnv1).X;
                scaleTransform2.CenterY = e.GetPosition(cnv1).Y;
                scaleTransform2.ScaleX /= ScaleRate;
                scaleTransform2.ScaleY /= ScaleRate;



            }
        }

        private void cnv2_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                scaleTransform3.CenterX = e.GetPosition(cnv2).X;
                scaleTransform3.CenterY = e.GetPosition(cnv2).Y;
                scaleTransform3.ScaleX *= ScaleRate;
                scaleTransform3.ScaleY *= ScaleRate;



            }
            else
            {
                scaleTransform3.CenterX = e.GetPosition(cnv2).X;
                scaleTransform3.CenterY = e.GetPosition(cnv2).Y;
                scaleTransform3.ScaleX /= ScaleRate;
                scaleTransform3.ScaleY /= ScaleRate;



            }
        }

        private void cnv3_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                scaleTransform4.CenterX = e.GetPosition(cnv3).X;
                scaleTransform4.CenterY = e.GetPosition(cnv3).Y;
                scaleTransform4.ScaleX *= ScaleRate;
                scaleTransform4.ScaleY *= ScaleRate;



            }
            else
            {
                scaleTransform4.CenterX = e.GetPosition(cnv3).X;
                scaleTransform4.CenterY = e.GetPosition(cnv3).Y;
                scaleTransform4.ScaleX /= ScaleRate;
                scaleTransform4.ScaleY /= ScaleRate;



            }
        }

        private void cnv4_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                scaleTransform5.CenterX = e.GetPosition(cnv4).X;
                scaleTransform5.CenterY = e.GetPosition(cnv4).Y;
                scaleTransform5.ScaleX *= ScaleRate;
                scaleTransform5.ScaleY *= ScaleRate;



            }
            else
            {
                scaleTransform5.CenterX = e.GetPosition(cnv4).X;
                scaleTransform5.CenterY = e.GetPosition(cnv4).Y;
                scaleTransform5.ScaleX /= ScaleRate;
                scaleTransform5.ScaleY /= ScaleRate;



            }
        }
    }
}
