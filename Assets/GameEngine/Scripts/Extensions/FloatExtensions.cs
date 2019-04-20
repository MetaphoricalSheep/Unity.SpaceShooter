namespace TwoBirds.GameEngine.Extensions
{
    public static class FloatExtensions
    {
        public static float ToInterval(this float percentage) => percentage / 100;
        public static float ToPercentage(this float interval) => interval * 100;
        public static string ToPercentageString(this float percentage) => $"{percentage}%";
    }
}