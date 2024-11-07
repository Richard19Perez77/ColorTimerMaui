namespace MauiApp1
{
    internal interface IColorService
    {
        Color GetRandomWarmColor();
        Color GetRandomCoolColor();
        public bool GetIsWarm();
        void ToggleIsWarm();
    }
}