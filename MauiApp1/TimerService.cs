using System.Timers;

namespace MauiApp1
{
    internal class TimerService : ITimerService
    {
        private static TimerService? _instance;
        private readonly System.Timers.Timer _timer;
        private bool _doRun;

        private TimerService(double interval)
        {
            _timer = new System.Timers.Timer(interval);
            _timer.Elapsed += (sender, e) => Elapsed?.Invoke(sender, e);
            _doRun = false;
        }

        public static TimerService Instance
        {
            get
            {
                _instance ??= new TimerService(16);
                return _instance;
            }
        }

        public event ElapsedEventHandler? Elapsed;

        public void Start() => _timer.Start();

        public void Stop() => _timer.Stop();

        internal bool GetDoRunColorTimer()
        {
            return _doRun;
        }

        internal void OnSleep()
        {
            _timer.Stop();
            _doRun = false;
        }

        internal void SetDoRunColorTimer(bool v)
        {
            _doRun = v;
        }

        internal void ToggleDoRunColorTimer()
        {
            _doRun = !_doRun;
            if (_doRun)
            {
                _timer.Start();
            }
            else
            {
                _timer.Stop();
            }
        }
    }
}