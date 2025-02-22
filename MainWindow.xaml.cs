using System;
using System.Windows;
using System.Windows.Threading;

namespace ClockWidget
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += Timer_Tick;
            timer.Start();

            Timer_Tick(this, EventArgs.Empty);
            CenterWindow();
        }

        private void Timer_Tick(object? sender, EventArgs? e) // Fix: Use nullable types
        {
            ClockText.Text = DateTime.Now.ToString("HH:mm");
            DayText.Text=DateTime.Now.ToString("dddd , MMMM  dd");
        }

        private void CenterWindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.Manual;

            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;

            double windowWidth = this.Width;
            double windowHeight = this.Height;

            this.Left=(screenWidth - windowWidth)/2;
            this.Top =(screenHeight - windowHeight)/3.6;
        }
    }
}
