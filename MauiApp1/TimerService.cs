using System.Timers;

namespace MauiApp1
{
    internal class TimerService : ITimerService
    {
        private readonly System.Timers.Timer _timer;

        public TimerService(double interval)
        {
            _timer = new System.Timers.Timer(interval);
            _timer.Elapsed += (sender, e) => Elapsed?.Invoke(sender, e);
        }

        public event ElapsedEventHandler? Elapsed;

        public void Start() => _timer.Start();

        public void Stop() => _timer.Stop();
    }
}