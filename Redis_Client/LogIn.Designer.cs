namespace Redis_Client
{
    partial class LogIn
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
            this.components = new System.ComponentModel.Container();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxPsw = new System.Windows.Forms.TextBox();
            this.butLogIn = new System.Windows.Forms.Button();
            this.butRegister = new System.Windows.Forms.Button();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.textBoxName.Location = new System.Drawing.Point(75, 92);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(250, 30);
            this.textBoxName.TabIndex = 0;
            this.textBoxName.Click += new System.EventHandler(this.TextBoxName_Click);
            // 
            // textBoxPsw
            // 
            this.textBoxPsw.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.textBoxPsw.Location = new System.Drawing.Point(75, 141);
            this.textBoxPsw.Name = "textBoxPsw";
            this.textBoxPsw.Size = new System.Drawing.Size(250, 30);
            this.textBoxPsw.TabIndex = 1;
            this.textBoxPsw.Click += new System.EventHandler(this.TextBoxPsw_Click);
            // 
            // butLogIn
            // 
            this.butLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.butLogIn.Location = new System.Drawing.Point(75, 245);
            this.butLogIn.Name = "butLogIn";
            this.butLogIn.Size = new System.Drawing.Size(250, 50);
            this.butLogIn.TabIndex = 2;
            this.butLogIn.Text = "LogIn";
            this.butLogIn.UseVisualStyleBackColor = true;
            this.butLogIn.Click += new System.EventHandler(this.ButLogIn_Click);
            // 
            // butRegister
            // 
            this.butRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.butRegister.Location = new System.Drawing.Point(75, 302);
            this.butRegister.Name = "butRegister";
            this.butRegister.Size = new System.Drawing.Size(250, 50);
            this.butRegister.TabIndex = 3;
            this.butRegister.Text = "Register";
            this.butRegister.UseVisualStyleBackColor = true;
            this.butRegister.Click += new System.EventHandler(this.ButRegister_Click);
            // 
            // textBoxMail
            // 
            this.textBoxMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.textBoxMail.Location = new System.Drawing.Point(75, 189);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(250, 30);
            this.textBoxMail.TabIndex = 4;
            this.textBoxMail.Visible = false;
            this.textBoxMail.Click += new System.EventHandler(this.TextBoxMail_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 479);
            this.Controls.Add(this.textBoxMail);
            this.Controls.Add(this.butRegister);
            this.Controls.Add(this.butLogIn);
            this.Controls.Add(this.textBoxPsw);
            this.Controls.Add(this.textBoxName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Location = new System.Drawing.Point(200, 200);
            this.Name = "LogIn";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogIn";
            this.Load += new System.EventHandler(this.LogIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPsw;
        private System.Windows.Forms.Button butLogIn;
        private System.Windows.Forms.Button butRegister;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}