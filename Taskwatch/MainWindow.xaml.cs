using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Taskwatch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static ObservableCollection<Task> tasks = new ObservableCollection<Task>();
        private static string currentTaskName;

        public MainWindow()
        {
            InitializeComponent();
            ic.ItemsSource = tasks;
        }

        private void AddTask(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(taskName.Text) && tasks.FirstOrDefault(x => x.Name == taskName.Text) == null)
            {
                tasks.Add(new Task(taskName.Text));
                taskName.Clear();
            }
        }

        private void StartTask(object sender, RoutedEventArgs e)
        {
            var taskName = ((Button)sender).Tag.ToString();

            if (!string.IsNullOrEmpty(currentTaskName)) tasks.First(x => x.Name == currentTaskName).Stop();
            tasks.First(x => x.Name == taskName).Start();
            currentTaskName = taskName;
        }
    }
}
