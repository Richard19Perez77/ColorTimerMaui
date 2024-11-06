using System;
using System.Timers;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        private System.Timers.Timer _timer;
        private Random _random;
        private bool _isWarm;

        public MainPage()
        {
            InitializeComponent();
            _timer = new System.Timers.Timer(16);
            _timer.Elapsed += OnTimerElapsed;
            _timer.Start();
            _random = new Random();
            _isWarm = false;
        }

        private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
        {
            Dispatcher.Dispatch(() =>
            {
                TimerLabel.Text = DateTime.Now.ToString("HH:mm:ss.fff");

                if (_isWarm)
                {
                    var randomColor = GetRandomWarmColor();
                    BackgroundColor = randomColor;
                    randomColor = GetRandomWarmColor();
                    TimerLabel.TextColor = randomColor;
                    ColorToneLabel.TextColor = randomColor;
                    ColorToneLabel.Text = "Warm Colors";
                }
                else
                {
                    var randomColor = GetRandomCoolColor();
                    BackgroundColor = randomColor;
                    randomColor = GetRandomCoolColor();
                    TimerLabel.TextColor = randomColor;
                    ColorToneLabel.TextColor = randomColor;
                    ColorToneLabel.Text = "Cool Colors";
                }
            });
        }

        private Color GetRandomWarmColor()
        {
            var r = _random.NextDouble();
            var g = _random.NextDouble();
            var b = _random.NextDouble() * r;
            return new Color((float)r, (float)g, (float)b); // Random color with RGB values between 0 and 1
        }

        private Color GetRandomCoolColor()
        {
            var b = _random.NextDouble();
            var g = _random.NextDouble();
            var r = _random.NextDouble() * b;
            return new Color((float)r, (float)g, (float)b); // Random color with RGB values between 0 and 1
        }

        private void OnScreenTapped(object? sender, EventArgs e)
        {
            _isWarm = !_isWarm;  // Toggle the value of the local variable
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _timer?.Stop();
        }
    }
}
