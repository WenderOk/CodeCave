namespace WinFormsApp2
{
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
            label1 = new Label();
            TextBox_login = new TextBox();
            TextBox_pasword = new TextBox();
            label2 = new Label();
            label3 = new Label();
            TextBox_projectName = new TextBox();
            label4 = new Label();
            Button_accept = new Button();
            ComboBox_type = new ComboBox();
            label5 = new Label();
            groupBox1 = new GroupBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            linkLabel1 = new LinkLabel();
            checkBox1 = new CheckBox();
            label6 = new Label();
            textBox4 = new TextBox();
            Button_save = new Button();
            listBox1 = new ListBox();
            MaskedTextBox_projectDate = new MaskedTextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 18);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "LOGIN";
            // 
            // TextBox_login
            // 
            TextBox_login.Location = new Point(66, 10);
            TextBox_login.Name = "TextBox_login";
            TextBox_login.Size = new Size(100, 23);
            TextBox_login.TabIndex = 1;
            TextBox_login.UseSystemPasswordChar = true;
            // 
            // TextBox_pasword
            // 
            TextBox_pasword.Location = new Point(246, 10);
            TextBox_pasword.Name = "TextBox_pasword";
            TextBox_pasword.Size = new Size(100, 23);
            TextBox_pasword.TabIndex = 3;
            TextBox_pasword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(172, 18);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 2;
            label2.Text = "PASSWORD";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 59);
            label3.Name = "label3";
            label3.Size = new Size(77, 15);
            label3.TabIndex = 4;
            label3.Text = "Projcet name";
            // 
            // TextBox_projectName
            // 
            TextBox_projectName.Location = new Point(98, 56);
            TextBox_projectName.Name = "TextBox_projectName";
            TextBox_projectName.Size = new Size(100, 23);
            TextBox_projectName.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 95);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 7;
            label4.Text = "Project date";
            // 
            // Button_accept
            // 
            Button_accept.BackColor = SystemColors.ActiveCaption;
            Button_accept.Location = new Point(405, 9);
            Button_accept.Name = "Button_accept";
            Button_accept.Size = new Size(75, 23);
            Button_accept.TabIndex = 8;
            Button_accept.Text = "accept";
            Button_accept.UseVisualStyleBackColor = false;
            Button_accept.Click += Button_accept_Click;
            // 
            // ComboBox_type
            // 
            ComboBox_type.FormattingEnabled = true;
            ComboBox_type.Location = new Point(66, 136);
            ComboBox_type.Name = "ComboBox_type";
            ComboBox_type.Size = new Size(121, 23);
            ComboBox_type.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 139);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 10;
            label5.Text = "Type";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(22, 165);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(294, 50);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Format";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(194, 22);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(59, 19);
            radioButton2.TabIndex = 13;
            radioButton2.TabStop = true;
            radioButton2.Text = "offline";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(6, 22);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(58, 19);
            radioButton1.TabIndex = 12;
            radioButton1.TabStop = true;
            radioButton1.Text = "online";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(22, 246);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(158, 15);
            linkLabel1.TabIndex = 12;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Условия для ознакомления";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(22, 278);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(49, 19);
            checkBox1.TabIndex = 13;
            checkBox1.Text = "i see";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 359);
            label6.Name = "label6";
            label6.Size = new Size(53, 15);
            label6.TabIndex = 14;
            label6.Text = "message";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(87, 351);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 15;
            // 
            // Button_save
            // 
            Button_save.BackColor = SystemColors.ActiveCaption;
            Button_save.Location = new Point(22, 388);
            Button_save.Name = "Button_save";
            Button_save.Size = new Size(75, 23);
            Button_save.TabIndex = 16;
            Button_save.Text = "save";
            Button_save.UseVisualStyleBackColor = false;
            Button_save.Click += Button_save_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(335, 44);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(453, 394);
            listBox1.TabIndex = 17;
            // 
            // MaskedTextBox_projectDate
            // 
            MaskedTextBox_projectDate.Location = new Point(98, 87);
            MaskedTextBox_projectDate.Mask = "00/00/0000";
            MaskedTextBox_projectDate.Name = "MaskedTextBox_projectDate";
            MaskedTextBox_projectDate.Size = new Size(100, 23);
            MaskedTextBox_projectDate.TabIndex = 6;
            MaskedTextBox_projectDate.ValidatingType = typeof(DateTime);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBox1);
            Controls.Add(Button_save);
            Controls.Add(textBox4);
            Controls.Add(label6);
            Controls.Add(checkBox1);
            Controls.Add(linkLabel1);
            Controls.Add(groupBox1);
            Controls.Add(label5);
            Controls.Add(ComboBox_type);
            Controls.Add(Button_accept);
            Controls.Add(label4);
            Controls.Add(MaskedTextBox_projectDate);
            Controls.Add(TextBox_projectName);
            Controls.Add(label3);
            Controls.Add(TextBox_pasword);
            Controls.Add(label2);
            Controls.Add(TextBox_login);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TextBox_login;
        private TextBox TextBox_pasword;
        private Label label2;
        private Label label3;
        private TextBox TextBox_projectName;
        private Label label4;
        private Button Button_accept;
        private ComboBox ComboBox_type;
        private Label label5;
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private LinkLabel linkLabel1;
        private CheckBox checkBox1;
        private Label label6;
        private TextBox textBox4;
        private Button Button_save;
        private ListBox listBox1;
        private MaskedTextBox MaskedTextBox_projectDate;

    }
}
