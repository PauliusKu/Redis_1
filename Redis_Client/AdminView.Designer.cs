namespace Redis_Client
{
    partial class AdminView
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
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.AdminTable = new System.Windows.Forms.ListView();
            this.FindFlight = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SearchBox
            // 
            this.SearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SearchBox.Location = new System.Drawing.Point(41, 37);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(170, 26);
            this.SearchBox.TabIndex = 0;
            // 
            // AdminTable
            // 
            this.AdminTable.Location = new System.Drawing.Point(41, 107);
            this.AdminTable.Name = "AdminTable";
            this.AdminTable.Size = new System.Drawing.Size(947, 397);
            this.AdminTable.TabIndex = 1;
            this.AdminTable.UseCompatibleStateImageBehavior = false;
            // 
            // FindFlight
            // 
            this.FindFlight.Location = new System.Drawing.Point(239, 37);
            this.FindFlight.Name = "FindFlight";
            this.FindFlight.Size = new System.Drawing.Size(100, 26);
            this.FindFlight.TabIndex = 2;
            this.FindFlight.Text = "Find Flight";
            this.FindFlight.UseVisualStyleBackColor = true;
            this.FindFlight.Click += new System.EventHandler(this.FindFlight_Click);
            // 
            // AdminView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 556);
            this.Controls.Add(this.FindFlight);
            this.Controls.Add(this.AdminTable);
            this.Controls.Add(this.SearchBox);
            this.Name = "AdminView";
            this.Text = "AdminView";
            this.Load += new System.EventHandler(this.AdminView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.ListView AdminTable;
        private System.Windows.Forms.Button FindFlight;
    }
}