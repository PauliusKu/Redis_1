namespace Redis_Client
{
    partial class ClientView
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
            this.listViewClient = new System.Windows.Forms.ListView();
            this.staticLabelUsername = new System.Windows.Forms.Label();
            this.staticLabelMail = new System.Windows.Forms.Label();
            this.staticLabelMoney = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelMail = new System.Windows.Forms.Label();
            this.labelMoney = new System.Windows.Forms.Label();
            this.buttonMyFlights = new System.Windows.Forms.Button();
            this.buttonSystemFlights = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewClient
            // 
            this.listViewClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.listViewClient.Location = new System.Drawing.Point(505, 102);
            this.listViewClient.Name = "listViewClient";
            this.listViewClient.Size = new System.Drawing.Size(465, 403);
            this.listViewClient.TabIndex = 6;
            this.listViewClient.UseCompatibleStateImageBehavior = false;
            this.listViewClient.DoubleClick += new System.EventHandler(this.ListViewClient_DoubleClick);
            // 
            // staticLabelUsername
            // 
            this.staticLabelUsername.AutoSize = true;
            this.staticLabelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.staticLabelUsername.Location = new System.Drawing.Point(31, 28);
            this.staticLabelUsername.Name = "staticLabelUsername";
            this.staticLabelUsername.Size = new System.Drawing.Size(150, 36);
            this.staticLabelUsername.TabIndex = 7;
            this.staticLabelUsername.Text = "Username";
            // 
            // staticLabelMail
            // 
            this.staticLabelMail.AutoSize = true;
            this.staticLabelMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.staticLabelMail.Location = new System.Drawing.Point(31, 102);
            this.staticLabelMail.Name = "staticLabelMail";
            this.staticLabelMail.Size = new System.Drawing.Size(88, 36);
            this.staticLabelMail.TabIndex = 8;
            this.staticLabelMail.Text = "Email";
            // 
            // staticLabelMoney
            // 
            this.staticLabelMoney.AutoSize = true;
            this.staticLabelMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.staticLabelMoney.Location = new System.Drawing.Point(31, 175);
            this.staticLabelMoney.Name = "staticLabelMoney";
            this.staticLabelMoney.Size = new System.Drawing.Size(105, 36);
            this.staticLabelMoney.TabIndex = 9;
            this.staticLabelMoney.Text = "Money";
            // 
            // labelUsername
            // 
            this.labelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.labelUsername.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelUsername.Location = new System.Drawing.Point(195, 31);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelUsername.Size = new System.Drawing.Size(273, 36);
            this.labelUsername.TabIndex = 10;
            this.labelUsername.Tag = "";
            this.labelUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMail
            // 
            this.labelMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.labelMail.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelMail.Location = new System.Drawing.Point(195, 102);
            this.labelMail.Name = "labelMail";
            this.labelMail.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelMail.Size = new System.Drawing.Size(274, 36);
            this.labelMail.TabIndex = 11;
            this.labelMail.Tag = "";
            this.labelMail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMoney
            // 
            this.labelMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.labelMoney.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelMoney.Location = new System.Drawing.Point(195, 175);
            this.labelMoney.Name = "labelMoney";
            this.labelMoney.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelMoney.Size = new System.Drawing.Size(278, 36);
            this.labelMoney.TabIndex = 12;
            this.labelMoney.Tag = "";
            this.labelMoney.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonMyFlights
            // 
            this.buttonMyFlights.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.buttonMyFlights.Location = new System.Drawing.Point(505, 28);
            this.buttonMyFlights.Name = "buttonMyFlights";
            this.buttonMyFlights.Size = new System.Drawing.Size(178, 52);
            this.buttonMyFlights.TabIndex = 13;
            this.buttonMyFlights.Text = "My Flights";
            this.buttonMyFlights.UseVisualStyleBackColor = true;
            this.buttonMyFlights.Click += new System.EventHandler(this.ButtonMyFlights_Click);
            // 
            // buttonSystemFlights
            // 
            this.buttonSystemFlights.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.buttonSystemFlights.Location = new System.Drawing.Point(792, 28);
            this.buttonSystemFlights.Name = "buttonSystemFlights";
            this.buttonSystemFlights.Size = new System.Drawing.Size(178, 52);
            this.buttonSystemFlights.TabIndex = 14;
            this.buttonSystemFlights.Text = "Choose a flight";
            this.buttonSystemFlights.UseVisualStyleBackColor = true;
            this.buttonSystemFlights.Click += new System.EventHandler(this.ButtonSystemFlights_Click);
            // 
            // ClientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.buttonSystemFlights);
            this.Controls.Add(this.buttonMyFlights);
            this.Controls.Add(this.labelMoney);
            this.Controls.Add(this.labelMail);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.staticLabelMoney);
            this.Controls.Add(this.staticLabelMail);
            this.Controls.Add(this.staticLabelUsername);
            this.Controls.Add(this.listViewClient);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ClientView";
            this.ShowIcon = false;
            this.Text = "ClientView";
            this.Load += new System.EventHandler(this.ClientView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listViewClient;
        private System.Windows.Forms.Label staticLabelUsername;
        private System.Windows.Forms.Label staticLabelMail;
        private System.Windows.Forms.Label staticLabelMoney;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelMail;
        private System.Windows.Forms.Label labelMoney;
        private System.Windows.Forms.Button buttonMyFlights;
        private System.Windows.Forms.Button buttonSystemFlights;
    }
}