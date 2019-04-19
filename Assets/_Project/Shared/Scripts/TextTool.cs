using MetaphoricalSheep.UnityTools.RichText;

namespace Assets.Scripts
{
    public static class TextTool
    {
        public static string Highlight(this string str) => str.AddColor(RichTextColors.Orange);
    }
}
