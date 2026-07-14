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

        private void Button_Click(object? sender, RoutedEventArgs e)
        {
        }
    }
}