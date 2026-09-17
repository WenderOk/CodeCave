namespace StyleLibrary
{
    public class StyleSettings
    {
        public string FormBackColor { get; set; } = "#F0F0F0";
        public string FormForeColor { get; set; } = "#000000";
        public string FontFamily { get; set; } = "Segoe UI";
        public float FontSize { get; set; } = 9F;
        public string TitleForeColor { get; set; } = "#323232";
        public float TitleFontSize { get; set; } = 14F;
        public string TextBoxBackColor { get; set; } = "#FFFFFF";
        public string TextBoxForeColor { get; set; } = "#000000";
        public string ButtonBackColor { get; set; } = "#E1E1E1";
        public string ButtonForeColor { get; set; } = "#000000";
        public bool ButtonFlat { get; set; } = false;
        public string ButtonBorderColor { get; set; } = "#707070";
        public string ListBackColor { get; set; } = "#FFFFFF";
        public string ListForeColor { get; set; } = "#000000";

        public static StyleSettings Dark => new()
        {
            FormBackColor = "#1E1E1E",
            FormForeColor = "#FFFFFF",
            FontFamily = "Consolas",
            FontSize = 10F,
            TitleForeColor = "#00C8FF",
            TitleFontSize = 16F,
            TextBoxBackColor = "#2D2D30",
            TextBoxForeColor = "#FFFFFF",
            ButtonBackColor = "#0078D4",
            ButtonForeColor = "#FFFFFF",
            ButtonFlat = true,
            ButtonBorderColor = "#00C8FF",
            ListBackColor = "#2D2D30",
            ListForeColor = "#FFFFFF"
        };
    }
}
