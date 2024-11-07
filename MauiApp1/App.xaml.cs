namespace MauiApp1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
            TimerService.Instance.OnSleep();
        }
    }
}
