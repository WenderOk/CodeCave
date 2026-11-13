namespace Client;

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
        label1 = new Label();
        textBox1 = new TextBox();
        label2 = new Label();
        textBox2 = new TextBox();
        label3 = new Label();
        textBox3 = new TextBox();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new Point(23, 24);
        button1.Name = "button1";
        button1.Size = new Size(107, 23);
        button1.TabIndex = 0;
        button1.Text = "Отправить";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(153, 28);
        label1.Name = "label1";
        label1.Size = new Size(56, 15);
        label1.TabIndex = 1;
        label1.Text = "IP-адрес:";
        // 
        // textBox1
        // 
        textBox1.Location = new Point(215, 24);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(100, 23);
        textBox1.TabIndex = 2;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(345, 29);
        label2.Name = "label2";
        label2.Size = new Size(38, 15);
        label2.TabIndex = 3;
        label2.Text = "Порт:";
        // 
        // textBox2
        // 
        textBox2.Location = new Point(389, 25);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(100, 23);
        textBox2.TabIndex = 4;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(23, 69);
        label3.Name = "label3";
        label3.Size = new Size(76, 15);
        label3.TabIndex = 5;
        label3.Text = "Сообщение:";
        // 
        // textBox3
        // 
        textBox3.Location = new Point(153, 66);
        textBox3.Name = "textBox3";
        textBox3.Size = new Size(336, 23);
        textBox3.TabIndex = 6;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(520, 123);
        Controls.Add(textBox3);
        Controls.Add(label3);
        Controls.Add(textBox2);
        Controls.Add(label2);
        Controls.Add(textBox1);
        Controls.Add(label1);
        Controls.Add(button1);
        Name = "Form1";
        Text = "Клиент";
        FormClosed += Form1_FormClosed;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button button1;
    private Label label1;
    private TextBox textBox1;
    private Label label2;
    private TextBox textBox2;
    private Label label3;
    private TextBox textBox3;
}
