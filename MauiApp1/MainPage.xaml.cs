using System.Timers;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {

        private readonly IColorService _colorService;
        private bool _isWarm;

        public MainPage()
        {
            InitializeComponent();
            _isWarm = false;
            TimerService.Instance.Elapsed += OnTimerElapsed;
            _colorService = new ColorService();
            _isWarm = false;
            Dispatcher.Dispatch(() =>
            {
                ColorToneLabel.Text = "Cool Colors";
                TimerLabel.Text = DateTime.Now.ToString("HH:mm:ss.fff");
            });
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
            TimerService.Instance.ToggleDoRunColorTimer();
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

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}