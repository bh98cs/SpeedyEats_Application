
namespace Assignment2
{
    partial class ViewDates
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
            this.lstDates = new System.Windows.Forms.ListBox();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lblSpeedyEats = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstDates
            // 
            this.lstDates.FormattingEnabled = true;
            this.lstDates.ItemHeight = 16;
            this.lstDates.Location = new System.Drawing.Point(90, 89);
            this.lstDates.Name = "lstDates";
            this.lstDates.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstDates.Size = new System.Drawing.Size(299, 260);
            this.lstDates.TabIndex = 0;
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(189, 376);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(92, 57);
            this.btnReturn.TabIndex = 1;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lblSpeedyEats
            // 
            this.lblSpeedyEats.AutoSize = true;
            this.lblSpeedyEats.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeedyEats.ForeColor = System.Drawing.Color.Red;
            this.lblSpeedyEats.Location = new System.Drawing.Point(147, 31);
            this.lblSpeedyEats.Name = "lblSpeedyEats";
            this.lblSpeedyEats.Size = new System.Drawing.Size(179, 32);
            this.lblSpeedyEats.TabIndex = 2;
            this.lblSpeedyEats.Text = "SpeedyEats";
            // 
            // ViewDates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 450);
            this.Controls.Add(this.lblSpeedyEats);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.lstDates);
            this.Name = "ViewDates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daily Distances";
            this.Load += new System.EventHandler(this.ViewDates_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstDates;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label lblSpeedyEats;
    }
}