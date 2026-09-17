using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using StyleLibrary;

namespace App2;

public class SettingsForm : Form
{
    private readonly StyleSettings _style = new();
    private readonly Dictionary<string, Button> _colorButtons = new();

    private ComboBox _fontCombo = null!;
    private NumericUpDown _fontSizeSpin = null!;
    private NumericUpDown _titleFontSizeSpin = null!;
    private CheckBox _flatCheck = null!;
    private Label _status = null!;

    public SettingsForm()
    {
        Text = "Настройки стиля App1";
        ClientSize = new Size(440, 620);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;

        var grid = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            Padding = new Padding(12),
            AutoScroll = true,
        };
        grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55));
        grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45));

        AddColorRow(grid, "Фон формы", nameof(StyleSettings.FormBackColor));
        AddColorRow(grid, "Текст формы", nameof(StyleSettings.FormForeColor));
        AddColorRow(grid, "Цвет заголовка", nameof(StyleSettings.TitleForeColor));
        AddColorRow(grid, "Фон TextBox", nameof(StyleSettings.TextBoxBackColor));
        AddColorRow(grid, "Текст TextBox", nameof(StyleSettings.TextBoxForeColor));
        AddColorRow(grid, "Фон кнопок", nameof(StyleSettings.ButtonBackColor));
        AddColorRow(grid, "Текст кнопок", nameof(StyleSettings.ButtonForeColor));
        AddColorRow(grid, "Рамка кнопок", nameof(StyleSettings.ButtonBorderColor));
        AddColorRow(grid, "Фон списка", nameof(StyleSettings.ListBackColor));
        AddColorRow(grid, "Текст списка", nameof(StyleSettings.ListForeColor));

        grid.Controls.Add(new Label { Text = "Шрифт", AutoSize = true, Anchor = AnchorStyles.Left });
        _fontCombo = new ComboBox
        {
            DropDownStyle = ComboBoxStyle.DropDownList,
            Width = 180,
            Anchor = AnchorStyles.Left
        };
        _fontCombo.Items.AddRange(new object[]
        {
            "Segoe UI", "Arial", "Consolas", "Times New Roman", "Verdana", "Tahoma"
        });
        _fontCombo.SelectedItem = _style.FontFamily;
        grid.Controls.Add(_fontCombo);

        grid.Controls.Add(new Label { Text = "Размер шрифта", AutoSize = true, Anchor = AnchorStyles.Left });
        _fontSizeSpin = new NumericUpDown
        {
            Minimum = 6,
            Maximum = 24,
            Value = (decimal)_style.FontSize,
            Width = 80,
            Anchor = AnchorStyles.Left
        };
        grid.Controls.Add(_fontSizeSpin);

        grid.Controls.Add(new Label { Text = "Размер заголовка", AutoSize = true, Anchor = AnchorStyles.Left });
        _titleFontSizeSpin = new NumericUpDown
        {
            Minimum = 8,
            Maximum = 32,
            Value = (decimal)_style.TitleFontSize,
            Width = 80,
            Anchor = AnchorStyles.Left
        };
        grid.Controls.Add(_titleFontSizeSpin);

        grid.Controls.Add(new Label { Text = "Плоские кнопки", AutoSize = true, Anchor = AnchorStyles.Left });
        _flatCheck = new CheckBox { Checked = _style.ButtonFlat, Anchor = AnchorStyles.Left };
        grid.Controls.Add(_flatCheck);

        var toolbar = new FlowLayoutPanel
        {
            Dock = DockStyle.Bottom,
            Height = 52,
            Padding = new Padding(12, 8, 12, 8)
        };

        var applyBtn = new Button { Text = "Применить в App1", Width = 150, Height = 32 };
        var darkBtn = new Button { Text = "Тёмный пресет", Width = 120, Height = 32 };
        var lightBtn = new Button { Text = "Светлый пресет", Width = 120, Height = 32 };

        applyBtn.Click += (_, _) => Apply();
        darkBtn.Click += (_, _) => LoadPreset(StyleSettings.Dark);
        lightBtn.Click += (_, _) => LoadPreset(new StyleSettings());

        toolbar.Controls.AddRange(new Control[] { applyBtn, darkBtn, lightBtn });

        _status = new Label
        {
            Dock = DockStyle.Bottom,
            Height = 26,
            TextAlign = ContentAlignment.MiddleLeft,
            Padding = new Padding(12, 0, 0, 0),
            Text = "Готово. Запустите App1 и нажмите «Применить»."
        };

        Controls.Add(grid);
        Controls.Add(toolbar);
        Controls.Add(_status);
    }

    // ---------------------- helpers ----------------------

    private void AddColorRow(TableLayoutPanel grid, string caption, string propertyName)
    {
        grid.Controls.Add(new Label { Text = caption, AutoSize = true, Anchor = AnchorStyles.Left });

        var initial = GetProp(propertyName);
        var btn = new Button
        {
            Width = 160,
            Height = 26,
            BackColor = ColorHelper.Parse(initial),
            FlatStyle = FlatStyle.Flat,
            Anchor = AnchorStyles.Left
        };
        btn.Click += (_, _) =>
        {
            using var dlg = new ColorDialog { Color = btn.BackColor, FullOpen = true };
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                btn.BackColor = dlg.Color;
                SetProp(propertyName, ColorHelper.ToHex(dlg.Color));
            }
        };
        _colorButtons[propertyName] = btn;
        grid.Controls.Add(btn);
    }

    private string GetProp(string name) =>
        (string)typeof(StyleSettings).GetProperty(name)!.GetValue(_style)!;

    private void SetProp(string name, object value) =>
        typeof(StyleSettings).GetProperty(name)!.SetValue(_style, value);

    private void LoadPreset(StyleSettings preset)
    {
        foreach (var p in typeof(StyleSettings).GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if (!p.CanRead || !p.CanWrite) continue;
            p.SetValue(_style, p.GetValue(preset));
        }
        RefreshUiFromStyle();
    }

    private void RefreshUiFromStyle()
    {
        foreach (var (prop, btn) in _colorButtons)
            btn.BackColor = ColorHelper.Parse(GetProp(prop));

        _fontCombo.SelectedItem = _style.FontFamily;
        _fontSizeSpin.Value = (decimal)_style.FontSize;
        _titleFontSizeSpin.Value = (decimal)_style.TitleFontSize;
        _flatCheck.Checked = _style.ButtonFlat;
    }

    private void Apply()
    {
        // синхронизируем модель с UI
        _style.FontFamily = _fontCombo.SelectedItem?.ToString() ?? "Segoe UI";
        _style.FontSize = (float)_fontSizeSpin.Value;
        _style.TitleFontSize = (float)_titleFontSizeSpin.Value;
        _style.ButtonFlat = _flatCheck.Checked;

        try
        {
            ThemeBroadcaster.Send(_style);
            _status.Text = $"Стиль отправлен в App1 в {DateTime.Now:HH:mm:ss}";
            _status.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            _status.Text = "Ошибка: " + ex.Message;
            _status.ForeColor = Color.Red;
        }
    }
}
