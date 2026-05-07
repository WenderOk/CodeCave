namespace _06_05
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelName = new System.Windows.Forms.Label();
            this.labelPosition = new System.Windows.Forms.Label();
            this.labelSalary = new System.Windows.Forms.Label();
            this.NameInput = new System.Windows.Forms.TextBox();
            this.PositionInput = new System.Windows.Forms.TextBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SalaryInput = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SalaryInput)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(29, 29);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(253, 394);
            this.listBox1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelName);
            this.flowLayoutPanel1.Controls.Add(this.labelPosition);
            this.flowLayoutPanel1.Controls.Add(this.labelSalary);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(316, 29);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(119, 307);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.Location = new System.Drawing.Point(3, 0);
            this.labelName.Name = "labelName";
            this.labelName.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.labelName.Size = new System.Drawing.Size(46, 35);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "FIO";
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPosition.Location = new System.Drawing.Point(3, 35);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.labelPosition.Size = new System.Drawing.Size(89, 35);
            this.labelPosition.TabIndex = 1;
            this.labelPosition.Text = "Position";
            // 
            // labelSalary
            // 
            this.labelSalary.AutoSize = true;
            this.labelSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSalary.Location = new System.Drawing.Point(3, 70);
            this.labelSalary.Name = "labelSalary";
            this.labelSalary.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.labelSalary.Size = new System.Drawing.Size(73, 35);
            this.labelSalary.TabIndex = 2;
            this.labelSalary.Text = "Salary";
            // 
            // NameInput
            // 
            this.NameInput.Location = new System.Drawing.Point(462, 35);
            this.NameInput.Name = "NameInput";
            this.NameInput.Size = new System.Drawing.Size(236, 20);
            this.NameInput.TabIndex = 2;
            // 
            // PositionInput
            // 
            this.PositionInput.Location = new System.Drawing.Point(462, 70);
            this.PositionInput.Name = "PositionInput";
            this.PositionInput.Size = new System.Drawing.Size(236, 20);
            this.PositionInput.TabIndex = 3;
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.Location = new System.Drawing.Point(322, 376);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(113, 47);
            this.buttonExit.TabIndex = 4;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonExit_MouseClick);
            // 
            // SalaryInput
            // 
            this.SalaryInput.Location = new System.Drawing.Point(462, 106);
            this.SalaryInput.Name = "SalaryInput";
            this.SalaryInput.Size = new System.Drawing.Size(120, 20);
            this.SalaryInput.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SalaryInput);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.PositionInput);
            this.Controls.Add(this.NameInput);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SalaryInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.Label labelSalary;
        private System.Windows.Forms.TextBox NameInput;
        private System.Windows.Forms.TextBox PositionInput;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.NumericUpDown SalaryInput;
    }
}

