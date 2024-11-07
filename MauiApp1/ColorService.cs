namespace MauiApp1
{
    internal class ColorService : IColorService
    {
        private readonly Random _random = new();

        public Color GetRandomWarmColor()
        {
            var r = _random.NextDouble();
            var g = _random.NextDouble();
            var b = _random.NextDouble() * r;
            return new Color((float)r, (float)g, (float)b);
        }

        public Color GetRandomCoolColor()
        {
            var b = _random.NextDouble();
            var g = _random.NextDouble();
            var r = _random.NextDouble() * b;
            return new Color((float)r, (float)g, (float)b);
        }
    }
}