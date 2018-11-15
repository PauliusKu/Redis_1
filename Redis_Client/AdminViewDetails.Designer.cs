namespace Redis_Client
{
    partial class AdminViewDetails
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
            this.DetailedData = new System.Windows.Forms.ListView();
            this.labelclient = new System.Windows.Forms.Label();
            this.labelflight = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DetailedData
            // 
            this.DetailedData.Location = new System.Drawing.Point(91, 106);
            this.DetailedData.Name = "DetailedData";
            this.DetailedData.Size = new System.Drawing.Size(604, 314);
            this.DetailedData.TabIndex = 0;
            this.DetailedData.UseCompatibleStateImageBehavior = false;
            // 
            // labelclient
            // 
            this.labelclient.AutoSize = true;
            this.labelclient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.labelclient.Location = new System.Drawing.Point(177, 33);
            this.labelclient.Name = "labelclient";
            this.labelclient.Size = new System.Drawing.Size(54, 24);
            this.labelclient.TabIndex = 1;
            this.labelclient.Text = "client";
            // 
            // labelflight
            // 
            this.labelflight.AutoSize = true;
            this.labelflight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.labelflight.Location = new System.Drawing.Point(367, 33);
            this.labelflight.Name = "labelflight";
            this.labelflight.Size = new System.Drawing.Size(48, 24);
            this.labelflight.TabIndex = 2;
            this.labelflight.Text = "flight";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.Location = new System.Drawing.Point(278, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Flight ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label2.Location = new System.Drawing.Point(87, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Client ID:";
            // 
            // AdminViewDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelflight);
            this.Controls.Add(this.labelclient);
            this.Controls.Add(this.DetailedData);
            this.Name = "AdminViewDetails";
            this.Text = "AdminViewDetails";
            this.Load += new System.EventHandler(this.AdminViewDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView DetailedData;
        private System.Windows.Forms.Label labelclient;
        private System.Windows.Forms.Label labelflight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}