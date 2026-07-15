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

        private void QuitApp(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddTaskWindow(object? sender, RoutedEventArgs e)
        {
            var window = new AddTaskWindow();
            window.Show();
        }

        private void FinishedTasksWindow(object? sender, RoutedEventArgs e)
        {
            var window = new FinishedTasksWindow();
            window.Show();
        }
    }
}
