namespace ProcessManipulation
{
    partial class MainWindow
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
            groupBox1 = new GroupBox();
            lbRunning = new ListBox();
            groupBox2 = new GroupBox();
            lbAvailable = new ListBox();
            btnStart = new Button();
            btnStop = new Button();
            btnClose = new Button();
            btnRefresh = new Button();
            btnNotepad = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lbRunning);
            groupBox1.Location = new Point(35, 71);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(286, 314);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Запущенные процессы";
            // 
            // lbRunning
            // 
            lbRunning.FormattingEnabled = true;
            lbRunning.ItemHeight = 15;
            lbRunning.Location = new Point(6, 22);
            lbRunning.Name = "lbRunning";
            lbRunning.Size = new Size(274, 289);
            lbRunning.TabIndex = 3;
            lbRunning.SelectedIndexChanged += lbRunning_SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lbAvailable);
            groupBox2.Location = new Point(482, 71);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(276, 314);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Доступные сборки";
            // 
            // lbAvailable
            // 
            lbAvailable.FormattingEnabled = true;
            lbAvailable.ItemHeight = 15;
            lbAvailable.Location = new Point(6, 22);
            lbAvailable.Name = "lbAvailable";
            lbAvailable.Size = new Size(264, 289);
            lbAvailable.TabIndex = 0;
            lbAvailable.SelectedIndexChanged += lbAvailable_SelectedIndexChanged;
            // 
            // btnStart
            // 
            btnStart.Enabled = false;
            btnStart.Location = new Point(351, 81);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(100, 33);
            btnStart.TabIndex = 2;
            btnStart.Text = "Старт";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Enabled = false;
            btnStop.Location = new Point(351, 120);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(100, 35);
            btnStop.TabIndex = 3;
            btnStop.Text = "Стоп";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnClose
            // 
            btnClose.Enabled = false;
            btnClose.Location = new Point(351, 161);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 35);
            btnClose.TabIndex = 4;
            btnClose.Text = "Закрыть окно";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Enabled = false;
            btnRefresh.Location = new Point(351, 202);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 35);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnNotepad
            // 
            btnNotepad.Location = new Point(351, 243);
            btnNotepad.Name = "btnNotepad";
            btnNotepad.Size = new Size(100, 35);
            btnNotepad.TabIndex = 6;
            btnNotepad.Text = "Блокнот";
            btnNotepad.UseVisualStyleBackColor = true;
            btnNotepad.Click += btnNotepad_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnNotepad);
            Controls.Add(btnRefresh);
            Controls.Add(btnClose);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "MainWindow";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnStart;
        private ListBox lbRunning;
        private ListBox lbAvailable;
        private Button btnStop;
        private Button btnClose;
        private Button btnRefresh;
        private Button btnNotepad;
    }
}
