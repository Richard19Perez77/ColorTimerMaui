using System.Timers;

namespace MauiApp1
{
    internal interface ITimerService
    {
        event ElapsedEventHandler Elapsed;
        void Start();
        void Stop();
    }
}