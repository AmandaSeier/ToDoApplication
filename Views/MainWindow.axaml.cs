using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using System;
using System.Globalization;
using System.Threading.Tasks;

// Animation made with help from Claude AI 

namespace ToDoApplication.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            GreetingText.Text = GetGreeting();
            WeekdayText.Text = GetWeekday();
            DateText.Text = GetFormattedDate();
        }

        private string GetGreeting()
        {
            var hour = DateTime.Now.Hour;

            if (hour >= 5 && hour < 12)
                return "Good morning!";
            if (hour >= 12 && hour < 17)
                return "Good afternoon!";
            if (hour >= 17 && hour < 22)
                return "Good evening!";

            return "Good night!";
        }

        private string GetFormattedDate()
        {
            return DateTime.Now.ToString("MMMM d'th' yyyy", new CultureInfo("en-US"));
        }

        private string GetWeekday()
        {
            return DateTime.Now.ToString("dddd", new CultureInfo("en-US")) + ",";
        }

        public void AddTaskWindow(object? sender, RoutedEventArgs e)
        {
            var window = new AddTaskWindow();
            window.Show();
        }

        public void FinishedTasksWindow(object? sender, RoutedEventArgs e)
        {
            var window = new FinishedTasksWindow();
            window.Show();
        }

        private bool _menuAnimating = false;

        private const int AnimationSteps = 30;   
        private const int AnimationDelayMs = 8;  

        private static double EaseOutHalfway(double t)
        {
            const double splitPoint = 0.5;     
            const double distAtSplit = 0.85;   

            if (t <= splitPoint)
            {
                double localT = t / splitPoint;
                return distAtSplit * (1 - Math.Pow(1 - localT, 2));
            }
            else
            {
                double localT = (t - splitPoint) / (1 - splitPoint);
                double eased = 1 - Math.Pow(1 - localT, 3);
                return distAtSplit + (1 - distAtSplit) * eased;
            }
        }

        private static double EaseInCubic(double t) => t * t * t;

        private async void MenuButtonOpen(object sender, RoutedEventArgs e)
        {
            if (_menuAnimating)
                return;

            _menuAnimating = true;

            double width = PopupRoot.Width;
            double height = PopupRoot.Height;

            if (!PopupRoot.IsVisible)
            {
                PopupRoot.IsVisible = true;

                for (int i = 0; i <= AnimationSteps; i++)
                {
                    double t = (double)i / AnimationSteps;
                    double eased = EaseOutHalfway(t);
                    double reveal = height * eased;

                    PopupRoot.Clip = new RectangleGeometry(
                        new Rect(0, height - reveal, width, reveal));

                    await Task.Delay(AnimationDelayMs);
                }

                PopupRoot.Clip = new RectangleGeometry(new Rect(0, 0, width, height));
            }
            else
            {
                for (int i = 0; i <= AnimationSteps; i++)
                {
                    double t = (double)i / AnimationSteps;
                    double eased = EaseInCubic(t);
                    double reveal = height * (1 - eased);

                    PopupRoot.Clip = new RectangleGeometry(
                        new Rect(0, height - reveal, width, reveal));

                    await Task.Delay(AnimationDelayMs);
                }

                PopupRoot.IsVisible = false;
                PopupRoot.Clip = null;
            }

            _menuAnimating = false;
        }
    }
}