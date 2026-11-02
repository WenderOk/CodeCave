namespace _5UDPServer;

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
        button1 = new Button();
        button2 = new Button();
        button3 = new Button();
        textBox1 = new TextBox();
        textBox2 = new TextBox();
        button4 = new Button();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new Point(30, 23);
        button1.Name = "button1";
        button1.Size = new Size(75, 23);
        button1.TabIndex = 0;
        button1.Text = "Старт";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // button2
        // 
        button2.Location = new Point(144, 23);
        button2.Name = "button2";
        button2.Size = new Size(75, 23);
        button2.TabIndex = 1;
        button2.Text = "Стоп";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // button3
        // 
        button3.Location = new Point(256, 23);
        button3.Name = "button3";
        button3.Size = new Size(75, 23);
        button3.TabIndex = 2;
        button3.Text = "Очистить";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(30, 53);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.ScrollBars = ScrollBars.Both;
        textBox1.Size = new Size(429, 168);
        textBox1.TabIndex = 3;
        // 
        // textBox2
        // 
        textBox2.Location = new Point(30, 250);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(348, 23);
        textBox2.TabIndex = 4;
        // 
        // button4
        // 
        button4.Location = new Point(384, 250);
        button4.Name = "button4";
        button4.Size = new Size(75, 23);
        button4.TabIndex = 5;
        button4.Text = "Отправить";
        button4.UseVisualStyleBackColor = true;
        button4.Click += button4_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(511, 311);
        Controls.Add(button4);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(button1);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button button1;
    private Button button2;
    private Button button3;
    private TextBox textBox1;
    private TextBox textBox2;
    private Button button4;
}
