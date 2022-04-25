
namespace TDesk
{
    partial class Login
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
            this.userName = new System.Windows.Forms.TextBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.pswText = new System.Windows.Forms.TextBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.pswLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(60, 38);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(124, 23);
            this.userName.TabIndex = 0;
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(23, 38);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(30, 15);
            this.userLabel.TabIndex = 1;
            this.userLabel.Text = "User";
            // 
            // pswText
            // 
            this.pswText.Location = new System.Drawing.Point(60, 84);
            this.pswText.Name = "pswText";
            this.pswText.Size = new System.Drawing.Size(124, 23);
            this.pswText.TabIndex = 2;
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(60, 129);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(75, 23);
            this.loginBtn.TabIndex = 3;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // pswLabel
            // 
            this.pswLabel.AutoSize = true;
            this.pswLabel.Location = new System.Drawing.Point(13, 84);
            this.pswLabel.Name = "pswLabel";
            this.pswLabel.Size = new System.Drawing.Size(40, 15);
            this.pswLabel.TabIndex = 4;
            this.pswLabel.Text = "Parolă";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 170);
            this.Controls.Add(this.pswLabel);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.pswText);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.userName);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.TextBox pswText;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Label pswLabel;
    }
}