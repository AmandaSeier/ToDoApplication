using Avalonia.Controls;
using Avalonia.Interactivity;

namespace ToDoApplication.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
    }
}
