namespace Redis_Client
{
    partial class Order
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Order));
            this.ButtonOrder = new System.Windows.Forms.Button();
            this.textBoxPassAmount = new System.Windows.Forms.TextBox();
            this.buttonLess = new System.Windows.Forms.Button();
            this.buttonMore = new System.Windows.Forms.Button();
            this.labelOrder = new System.Windows.Forms.Label();
            this.labelSum = new System.Windows.Forms.Label();
            this.FlightInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonOrder
            // 
            this.ButtonOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ButtonOrder.Location = new System.Drawing.Point(95, 422);
            this.ButtonOrder.Name = "ButtonOrder";
            this.ButtonOrder.Size = new System.Drawing.Size(223, 64);
            this.ButtonOrder.TabIndex = 0;
            this.ButtonOrder.Text = "Order";
            this.ButtonOrder.UseVisualStyleBackColor = true;
            this.ButtonOrder.Click += new System.EventHandler(this.ButtonOrder_Click);
            // 
            // textBoxPassAmount
            // 
            this.textBoxPassAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.textBoxPassAmount.Location = new System.Drawing.Point(166, 365);
            this.textBoxPassAmount.Name = "textBoxPassAmount";
            this.textBoxPassAmount.ReadOnly = true;
            this.textBoxPassAmount.Size = new System.Drawing.Size(81, 30);
            this.textBoxPassAmount.TabIndex = 1;
            this.textBoxPassAmount.Text = "1";
            this.textBoxPassAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonLess
            // 
            this.buttonLess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.buttonLess.Location = new System.Drawing.Point(95, 361);
            this.buttonLess.Name = "buttonLess";
            this.buttonLess.Size = new System.Drawing.Size(52, 39);
            this.buttonLess.TabIndex = 2;
            this.buttonLess.Text = "-";
            this.buttonLess.UseVisualStyleBackColor = true;
            this.buttonLess.Click += new System.EventHandler(this.buttonLess_Click);
            // 
            // buttonMore
            // 
            this.buttonMore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.buttonMore.Location = new System.Drawing.Point(266, 361);
            this.buttonMore.Name = "buttonMore";
            this.buttonMore.Size = new System.Drawing.Size(52, 39);
            this.buttonMore.TabIndex = 3;
            this.buttonMore.Text = "+";
            this.buttonMore.UseVisualStyleBackColor = true;
            this.buttonMore.Click += new System.EventHandler(this.buttonMore_Click);
            // 
            // labelOrder
            // 
            this.labelOrder.AutoSize = true;
            this.labelOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.labelOrder.Location = new System.Drawing.Point(99, 323);
            this.labelOrder.Name = "labelOrder";
            this.labelOrder.Size = new System.Drawing.Size(209, 25);
            this.labelOrder.TabIndex = 4;
            this.labelOrder.Text = "Number of passengers";
            // 
            // labelSum
            // 
            this.labelSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.labelSum.Location = new System.Drawing.Point(104, 514);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(204, 34);
            this.labelSum.TabIndex = 5;
            this.labelSum.Text = "0 EUR";
            this.labelSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FlightInfo
            // 
            this.FlightInfo.AllowDrop = true;
            this.FlightInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.FlightInfo.Location = new System.Drawing.Point(43, 31);
            this.FlightInfo.Name = "FlightInfo";
            this.FlightInfo.Size = new System.Drawing.Size(328, 264);
            this.FlightInfo.TabIndex = 6;
            this.FlightInfo.Text = resources.GetString("FlightInfo.Text");
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 590);
            this.Controls.Add(this.FlightInfo);
            this.Controls.Add(this.labelSum);
            this.Controls.Add(this.labelOrder);
            this.Controls.Add(this.buttonMore);
            this.Controls.Add(this.buttonLess);
            this.Controls.Add(this.textBoxPassAmount);
            this.Controls.Add(this.ButtonOrder);
            this.Name = "Order";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order";
            this.Load += new System.EventHandler(this.Order_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonOrder;
        private System.Windows.Forms.TextBox textBoxPassAmount;
        private System.Windows.Forms.Button buttonLess;
        private System.Windows.Forms.Button buttonMore;
        private System.Windows.Forms.Label labelOrder;
        private System.Windows.Forms.Label labelSum;
        private System.Windows.Forms.Label FlightInfo;
    }
}