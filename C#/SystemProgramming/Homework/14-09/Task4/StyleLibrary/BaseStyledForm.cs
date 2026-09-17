using System.Drawing;
using System.Windows.Forms;

namespace StyleLibrary;

public class BaseStyledForm : Form
{
    protected Label TitleLabel = null!;
    protected TextBox NameTextBox = null!;
    protected TextBox EmailTextBox = null!;
    protected CheckBox SubscribeCheckBox = null!;
    protected ComboBox ThemeComboBox = null!;
    protected ListBox ItemsListBox = null!;
    protected Button SubmitButton = null!;
    protected Button ClearButton = null!;

    public BaseStyledForm()
    {
        InitializeComponents();
        ApplyStyle(new StyleSettings());
    }

    private void InitializeComponents()
    {
        Text = ThemeBroadcaster.TargetWindowTitle;
        ClientSize = new Size(500, 400);
        StartPosition = FormStartPosition.CenterScreen;

        TitleLabel = new Label
        {
            Text = "Registration",
            Location = new Point(20, 20),
            Size = new Size(460, 30)
        };

        NameTextBox = new TextBox
        {
            Location = new Point(20, 60),
            Size = new Size(460, 25),
            PlaceholderText = "Name"
        };

        EmailTextBox = new TextBox
        {
            Location = new Point(20, 95),
            Size = new Size(460, 25),
            PlaceholderText = "Email"
        };

        SubscribeCheckBox = new CheckBox
        {
            Text = "Subscribe to newsletter",
            Location = new Point(20, 130),
            Size = new Size(250, 25)
        };

        ThemeComboBox = new ComboBox
        {
            Location = new Point(20, 165),
            Size = new Size(220, 25),
            DropDownStyle = ComboBoxStyle.DropDownList
        };
        ThemeComboBox.Items.AddRange(new object[] { "Light", "Dark", "Blue" });
        ThemeComboBox.SelectedIndex = 0;

        ItemsListBox = new ListBox
        {
            Location = new Point(20, 200),
            Size = new Size(220, 150)
        };
        ItemsListBox.Items.AddRange(new object[] { "Item 1", "Item 2", "Item 3" });

        SubmitButton = new Button
        {
            Text = "Submit",
            Location = new Point(260, 200),
            Size = new Size(100, 35)
        };

        ClearButton = new Button
        {
            Text = "Clear",
            Location = new Point(380, 200),
            Size = new Size(100, 35)
        };

        Controls.AddRange(new Control[]
        {
            TitleLabel, NameTextBox, EmailTextBox, SubscribeCheckBox,
            ThemeComboBox, ItemsListBox, SubmitButton, ClearButton
        });
    }

    /// <summary>
    /// Применяет стиль. Вызывается локально и по WM_COPYDATA из App2.
    /// </summary>
    public virtual void ApplyStyle(StyleSettings s)
    {
        SuspendLayout();
        try
        {
            BackColor = ColorHelper.Parse(s.FormBackColor);
            ForeColor = ColorHelper.Parse(s.FormForeColor);
            Font = new Font(s.FontFamily, s.FontSize);

            TitleLabel.ForeColor = ColorHelper.Parse(s.TitleForeColor);
            TitleLabel.Font = new Font(s.FontFamily, s.TitleFontSize, FontStyle.Bold);

            foreach (var tb in new[] { NameTextBox, EmailTextBox })
            {
                tb.BackColor = ColorHelper.Parse(s.TextBoxBackColor);
                tb.ForeColor = ColorHelper.Parse(s.TextBoxForeColor);
                tb.BorderStyle = BorderStyle.FixedSingle;
            }

            foreach (var btn in new[] { SubmitButton, ClearButton })
            {
                btn.BackColor = ColorHelper.Parse(s.ButtonBackColor);
                btn.ForeColor = ColorHelper.Parse(s.ButtonForeColor);
                btn.FlatStyle = s.ButtonFlat ? FlatStyle.Flat : FlatStyle.Standard;
                if (s.ButtonFlat)
                    btn.FlatAppearance.BorderColor = ColorHelper.Parse(s.ButtonBorderColor);
            }

            ThemeComboBox.BackColor = ColorHelper.Parse(s.TextBoxBackColor);
            ThemeComboBox.ForeColor = ColorHelper.Parse(s.TextBoxForeColor);

            SubscribeCheckBox.ForeColor = ColorHelper.Parse(s.FormForeColor);

            ItemsListBox.BackColor = ColorHelper.Parse(s.ListBackColor);
            ItemsListBox.ForeColor = ColorHelper.Parse(s.ListForeColor);
        }
        finally
        {
            ResumeLayout(true);
        }
    }

    // ------------------ WinAPI-приём сообщения ------------------

    protected override void WndProc(ref Message m)
    {
        if (ThemeReceiver.TryHandle(ref m, this))
            return;

        base.WndProc(ref m);
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        // На случай, если наследник сменил Text — восстановим контракт с FindWindow.
        Text = ThemeBroadcaster.TargetWindowTitle;
    }
}
