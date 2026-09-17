using System.Drawing;

namespace StyleLibrary;

public static class ColorHelper
{
    public static Color Parse(string hex)
    {
        try { return ColorTranslator.FromHtml(hex); }
        catch { return Color.Gray; }
    }

    public static string ToHex(Color c) => $"#{c.R:X2}{c.G:X2}{c.B:X2}";
}
