using Avalonia.Controls;
using System.Collections.Generic;

namespace ToDoApplication.Views
{
    public partial class MainWindow : Window
    {
        private readonly Stack<UserControl> _history = new();

        public MainWindow()
        {
            InitializeComponent();
            Navigate(new HomeView(), addToHistory: false);
        }

        public void Navigate(UserControl view, bool addToHistory = true)
        {
            if (addToHistory && MainContent.Content is UserControl current)
                _history.Push(current);

            MainContent.Content = view;
        }

        public void GoBack()
        {
            if (_history.Count > 0)
            {
                var previous = _history.Pop();
                MainContent.Content = previous;
            }
        }
    }
}