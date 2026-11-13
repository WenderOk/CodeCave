namespace Server;

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
        textBox1 = new TextBox();
        textBox2 = new TextBox();
        label1 = new Label();
        label2 = new Label();
        messageList = new ListBox();
        label3 = new Label();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new Point(23, 24);
        button1.Name = "button1";
        button1.Size = new Size(107, 23);
        button1.TabIndex = 0;
        button1.Text = "Старт";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(215, 24);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(100, 23);
        textBox1.TabIndex = 1;
        // 
        // textBox2
        // 
        textBox2.Location = new Point(389, 25);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(100, 23);
        textBox2.TabIndex = 2;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(153, 28);
        label1.Name = "label1";
        label1.Size = new Size(56, 15);
        label1.TabIndex = 3;
        label1.Text = "IP-адрес:";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(345, 29);
        label2.Name = "label2";
        label2.Size = new Size(38, 15);
        label2.TabIndex = 4;
        label2.Text = "Порт:";
        // 
        // messageList
        // 
        messageList.FormattingEnabled = true;
        messageList.Location = new Point(23, 98);
        messageList.Name = "messageList";
        messageList.Size = new Size(466, 184);
        messageList.TabIndex = 5;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(23, 69);
        label3.Name = "label3";
        label3.Size = new Size(148, 15);
        label3.TabIndex = 6;
        label3.Text = "Полученные сообщения:";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(520, 306);
        Controls.Add(label3);
        Controls.Add(messageList);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Controls.Add(button1);
        Name = "Form1";
        Text = "Сервер";
        FormClosed += Form1_FormClosed;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button button1;
    private TextBox textBox1;
    private TextBox textBox2;
    private Label label1;
    private Label label2;
    private ListBox messageList;
    private Label label3;
}
