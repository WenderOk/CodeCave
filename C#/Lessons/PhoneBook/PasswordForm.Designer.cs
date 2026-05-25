namespace PhoneBook
{
    partial class PasswordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxPwd = new System.Windows.Forms.TextBox();
            this.BtnConfirmPwd = new System.Windows.Forms.Button();
            this.labelPwd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxPwd
            // 
            this.textBoxPwd.Location = new System.Drawing.Point(143, 102);
            this.textBoxPwd.Name = "textBoxPwd";
            this.textBoxPwd.Size = new System.Drawing.Size(153, 20);
            this.textBoxPwd.TabIndex = 0;
            this.textBoxPwd.UseSystemPasswordChar = true;
            // 
            // BtnConfirmPwd
            // 
            this.BtnConfirmPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.BtnConfirmPwd.Location = new System.Drawing.Point(176, 138);
            this.BtnConfirmPwd.Name = "BtnConfirmPwd";
            this.BtnConfirmPwd.Size = new System.Drawing.Size(84, 26);
            this.BtnConfirmPwd.TabIndex = 1;
            this.BtnConfirmPwd.Text = "Подвердить";
            this.BtnConfirmPwd.UseVisualStyleBackColor = true;
            this.BtnConfirmPwd.Click += new System.EventHandler(this.Btn_confirmPwd_Click);
            // 
            // labelPwd
            // 
            this.labelPwd.AutoSize = true;
            this.labelPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPwd.Location = new System.Drawing.Point(139, 59);
            this.labelPwd.Name = "labelPwd";
            this.labelPwd.Size = new System.Drawing.Size(157, 24);
            this.labelPwd.TabIndex = 2;
            this.labelPwd.Text = "Введите пароль";
            // 
            // PasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 211);
            this.Controls.Add(this.labelPwd);
            this.Controls.Add(this.BtnConfirmPwd);
            this.Controls.Add(this.textBoxPwd);
            this.Name = "PasswordForm";
            this.Text = "PasswordForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPwd;
        private System.Windows.Forms.Button BtnConfirmPwd;
        private System.Windows.Forms.Label labelPwd;
    }
}