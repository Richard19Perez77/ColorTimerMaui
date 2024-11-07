using System.Timers;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {

        private readonly ITimerService _timerService;
        private readonly IColorService _colorService;
        private bool _isWarm;
        private bool _doRunColorTimer;

        public MainPage()
        {
            InitializeComponent();
            _isWarm = false;
            _timerService = new TimerService(16);
            _timerService.Elapsed += OnTimerElapsed;
            _timerService.Start();
            _colorService = new ColorService();
            _isWarm = false;
            _doRunColorTimer = false;
        }

        private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
        {
            Dispatcher.Dispatch(() =>
            {
                TimerLabel.Text = DateTime.Now.ToString("HH:mm:ss.fff");

                if (_isWarm)
                {
                    var randomColor = _colorService.GetRandomWarmColor();
                    BackgroundColor = randomColor;
                    randomColor = _colorService.GetRandomWarmColor();
                    TimerLabel.TextColor = randomColor;
                    ColorToneLabel.TextColor = randomColor;
                    ColorToneLabel.Text = "Warm Colors";
                }
                else
                {
                    var randomColor = _colorService.GetRandomCoolColor();
                    BackgroundColor = randomColor;
                    randomColor = _colorService.GetRandomCoolColor();
                    TimerLabel.TextColor = randomColor;
                    ColorToneLabel.TextColor = randomColor;
                    ColorToneLabel.Text = "Cool Colors";
                }
            });
        }

        private void OnDoubleTapped(object? sender, EventArgs e)
        {
            _doRunColorTimer = !_doRunColorTimer;
            if (_doRunColorTimer)
            {
                _timerService.Start();
            } else
            {
                _timerService.Stop();
                Dispatcher.Dispatch(() =>
                {
                    BackgroundColor = Colors.Black;
                    TimerLabel.TextColor = Colors.White;
                    ColorToneLabel.TextColor = Colors.White;
                });
            }
        }

        private void OnScreenTapped(object? sender, EventArgs e)
        {
            _isWarm = !_isWarm;
            if (_isWarm)
            {
                ColorToneLabel.Text = "Warm Colors";
            }
            else
            {
                ColorToneLabel.Text = "Cool Colors";
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (_doRunColorTimer)
            {
                _timerService.Stop();
                _doRunColorTimer = false;
            }
        }
    }
}