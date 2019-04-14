namespace MetaphoricalSheep.UnityTools.RichText
{
    public static class RichTextExtensions
    {
        private const string bold = "b";
        private const string italics = "i";
        private const string size = "size";
        private const string color = "color";
        private const string material = "material";
        private const string quad = "quad";
        private const string x = "x";
        private const string y = "y";
        private const string width = "width";
        private const string height = "height";

        public static string AddBold(this string str) => AddType(str, bold);
        public static string AddItalics(this string str) => AddType(str, italics);
        public static string AddSize(this string str, string value) => AddType(str, size, value);
        public static string AddColor(this string str, string value) => AddType(str, color, value);
        public static string AddMaterial(this string str, string value) => AddType(str, material, value);

        public static string AddQuad(this string str, string materialValue, string sizeValue, string xValue, string yValue, string widthValue, string heightValue)
        {
            return $"{quad} {material}={materialValue} {size}={sizeValue} {x}={xValue} {y}={yValue} {width}={widthValue} {height}={heightValue} />{str}";
        }

        private static string AddType(string str, string identifier) => $"<{identifier}>{str}</{identifier}>";

        private static string AddType(string str, string identifier, string value) => $"<{identifier}={value}>{str}</{identifier}>";

    }
}
