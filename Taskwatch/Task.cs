using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Taskwatch
{
    public class Task : INotifyPropertyChanged
    {
        private string timeSpent = "00:00:00";
        private Stopwatch stopwatch = new Stopwatch();
        private DispatcherTimer dispatcher = new DispatcherTimer()
        {
            Interval = TimeSpan.FromMilliseconds(100)
        };

        public string Name { get; }
        public string TimeSpent
        {
            get => timeSpent;
            private set { timeSpent = value; RaisePropertyChanged("TimeSpent"); }
        }

        public Task(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));

            Name = name;
            dispatcher.Tick += Timer_Tick;
        }

        public void Start()
        {
            dispatcher.Start();
            stopwatch.Start();
        }

        public void Stop()
        {
            dispatcher.Stop();
            stopwatch.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var elapsed = stopwatch.Elapsed;
            TimeSpent = elapsed.ToShortTimeString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
