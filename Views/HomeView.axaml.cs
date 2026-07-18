using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.VisualTree;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace ToDoApplication.Views

// ANIMATION MADE WITH CLAUDE AI

{
    public partial class HomeView : UserControl
    {
        public HomeView()
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
            if (this.GetVisualRoot() is MainWindow mainWindow)
                mainWindow.Navigate(new AddTaskView());
        }

        public void FinishedTasksWindow(object? sender, RoutedEventArgs e)
        {
            if (this.GetVisualRoot() is MainWindow mainWindow)
                mainWindow.Navigate(new FinishedTasksView());
        }

        private bool _menuAnimating = false;

        private const int PanelSteps = 24;
        private const int PanelDelayMs = 4;
        private const int FadeSteps = 36;
        private const int FadeDelayMs = 12;

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

        private static double FadeIn(double t, double startAt, double duration)
        {
            if (t <= startAt) return 0;
            if (t >= startAt + duration) return 1;
            return (t - startAt) / duration;
        }

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
                IconAccount.Opacity = 0;
                IconSettings.Opacity = 0;
                IconEdit.Opacity = 0;

                for (int i = 0; i <= PanelSteps; i++)
                {
                    double t = (double)i / PanelSteps;
                    double eased = EaseOutHalfway(t);
                    double reveal = height * eased;

                    PopupRoot.Clip = new RectangleGeometry(
                        new Rect(0, height - reveal, width, reveal));

                    await Task.Delay(PanelDelayMs);
                }

                PopupRoot.Clip = new RectangleGeometry(new Rect(0, 0, width, height));

                for (int i = 0; i <= FadeSteps; i++)
                {
                    double t = (double)i / FadeSteps;

                    IconEdit.Opacity = FadeIn(t, 0.00, 0.33);
                    IconSettings.Opacity = FadeIn(t, 0.33, 0.33);
                    IconAccount.Opacity = FadeIn(t, 0.66, 0.34);

                    await Task.Delay(FadeDelayMs);
                }

                IconAccount.Opacity = 1;
                IconSettings.Opacity = 1;
                IconEdit.Opacity = 1;
            }
            else
            {
                for (int i = 0; i <= FadeSteps; i++)
                {
                    double t = (double)i / FadeSteps;

                    IconAccount.Opacity = 1 - FadeIn(t, 0.00, 0.33);
                    IconSettings.Opacity = 1 - FadeIn(t, 0.33, 0.33);
                    IconEdit.Opacity = 1 - FadeIn(t, 0.66, 0.34);

                    await Task.Delay(FadeDelayMs);
                }

                IconAccount.Opacity = 0;
                IconSettings.Opacity = 0;
                IconEdit.Opacity = 0;

                for (int i = 0; i <= PanelSteps; i++)
                {
                    double t = (double)i / PanelSteps;
                    double eased = EaseInCubic(t);
                    double reveal = height * (1 - eased);

                    PopupRoot.Clip = new RectangleGeometry(
                        new Rect(0, height - reveal, width, reveal));

                    await Task.Delay(PanelDelayMs);
                }

                PopupRoot.IsVisible = false;
                PopupRoot.Clip = null;
            }

            _menuAnimating = false;
        }
    }
}