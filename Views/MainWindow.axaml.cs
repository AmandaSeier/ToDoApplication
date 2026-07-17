using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Globalization;

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

        private void MenuButtonOpen(object sender, RoutedEventArgs e)
        {
            PopupMenu.IsOpen = !PopupMenu.IsOpen;
        }
    }
}
