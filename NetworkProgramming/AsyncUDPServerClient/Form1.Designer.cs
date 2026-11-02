namespace _6AsyncUDPServerClient;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        button4 = new Button();
        textBox2 = new TextBox();
        textBox1 = new TextBox();
        button3 = new Button();
        button2 = new Button();
        button1 = new Button();
        SuspendLayout();
        // 
        // button4
        // 
        button4.Location = new Point(376, 246);
        button4.Name = "button4";
        button4.Size = new Size(75, 23);
        button4.TabIndex = 11;
        button4.Text = "Отправить";
        button4.UseVisualStyleBackColor = true;
        button4.Click += button4_Click;
        // 
        // textBox2
        // 
        textBox2.Location = new Point(22, 246);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(348, 23);
        textBox2.TabIndex = 10;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(22, 49);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.ScrollBars = ScrollBars.Both;
        textBox1.Size = new Size(429, 168);
        textBox1.TabIndex = 9;
        // 
        // button3
        // 
        button3.Location = new Point(248, 19);
        button3.Name = "button3";
        button3.Size = new Size(75, 23);
        button3.TabIndex = 8;
        button3.Text = "Очистить";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // button2
        // 
        button2.Location = new Point(136, 19);
        button2.Name = "button2";
        button2.Size = new Size(75, 23);
        button2.TabIndex = 7;
        button2.Text = "Стоп";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // button1
        // 
        button1.Location = new Point(22, 19);
        button1.Name = "button1";
        button1.Size = new Size(75, 23);
        button1.TabIndex = 6;
        button1.Text = "Старт";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(500, 310);
        Controls.Add(button4);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(button1);
        Name = "Form1";
        Text = "Асинхронный UDP сервер и клиент";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button button4;
    private TextBox textBox2;
    private TextBox textBox1;
    private Button button3;
    private Button button2;
    private Button button1;
}
