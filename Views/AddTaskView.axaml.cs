using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.VisualTree;

namespace ToDoApplication.Views
{
    public partial class AddTaskView : UserControl
    {
        public AddTaskView()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object? sender, RoutedEventArgs e)
        {
            if (this.GetVisualRoot() is MainWindow mainWindow)
                mainWindow.GoBack();
        }
    }
}