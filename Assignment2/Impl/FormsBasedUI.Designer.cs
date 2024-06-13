
namespace Assignment2
{
    partial class FormsBasedUI
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
            this.lblSpeedyEats = new System.Windows.Forms.Label();
            this.btnDates = new System.Windows.Forms.Button();
            this.btnDrivers = new System.Windows.Forms.Button();
            this.btnProducerConsumer = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.lstJourneys = new System.Windows.Forms.ListBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.lstDrivers = new System.Windows.Forms.ListBox();
            this.lblLongestJourney = new System.Windows.Forms.Label();
            this.txtLongestJourney = new System.Windows.Forms.TextBox();
            this.lblProgress = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lstTotalDistance = new System.Windows.Forms.ListBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblTotalDistance = new System.Windows.Forms.Label();
            this.lblJourneys = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSpeedyEats
            // 
            this.lblSpeedyEats.AutoSize = true;
            this.lblSpeedyEats.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeedyEats.ForeColor = System.Drawing.Color.Red;
            this.lblSpeedyEats.Location = new System.Drawing.Point(55, 21);
            this.lblSpeedyEats.Name = "lblSpeedyEats";
            this.lblSpeedyEats.Size = new System.Drawing.Size(179, 32);
            this.lblSpeedyEats.TabIndex = 1;
            this.lblSpeedyEats.Text = "SpeedyEats";
            // 
            // btnDates
            // 
            this.btnDates.Enabled = false;
            this.btnDates.Location = new System.Drawing.Point(152, 124);
            this.btnDates.Name = "btnDates";
            this.btnDates.Size = new System.Drawing.Size(106, 49);
            this.btnDates.TabIndex = 2;
            this.btnDates.Text = "View Dates";
            this.btnDates.UseVisualStyleBackColor = true;
            this.btnDates.Click += new System.EventHandler(this.btnDates_Click);
            // 
            // btnDrivers
            // 
            this.btnDrivers.Enabled = false;
            this.btnDrivers.Location = new System.Drawing.Point(152, 194);
            this.btnDrivers.Name = "btnDrivers";
            this.btnDrivers.Size = new System.Drawing.Size(106, 49);
            this.btnDrivers.TabIndex = 3;
            this.btnDrivers.Text = "View Drivers";
            this.btnDrivers.UseVisualStyleBackColor = true;
            this.btnDrivers.Click += new System.EventHandler(this.btnDrivers_Click);
            // 
            // btnProducerConsumer
            // 
            this.btnProducerConsumer.Enabled = false;
            this.btnProducerConsumer.Location = new System.Drawing.Point(26, 194);
            this.btnProducerConsumer.Name = "btnProducerConsumer";
            this.btnProducerConsumer.Size = new System.Drawing.Size(106, 49);
            this.btnProducerConsumer.TabIndex = 5;
            this.btnProducerConsumer.Text = "Load Journey Data";
            this.btnProducerConsumer.UseVisualStyleBackColor = true;
            this.btnProducerConsumer.Click += new System.EventHandler(this.btnProducerConsumer_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(26, 124);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(106, 49);
            this.btnConfig.TabIndex = 6;
            this.btnConfig.Text = "Create Config Data";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // lstJourneys
            // 
            this.lstJourneys.Enabled = false;
            this.lstJourneys.FormattingEnabled = true;
            this.lstJourneys.ItemHeight = 16;
            this.lstJourneys.Items.AddRange(new object[] {
            "Awaiting Data ... "});
            this.lstJourneys.Location = new System.Drawing.Point(618, 128);
            this.lstJourneys.Name = "lstJourneys";
            this.lstJourneys.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstJourneys.Size = new System.Drawing.Size(659, 244);
            this.lstJourneys.TabIndex = 8;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 390);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(106, 49);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lstDrivers
            // 
            this.lstDrivers.Enabled = false;
            this.lstDrivers.FormattingEnabled = true;
            this.lstDrivers.ItemHeight = 16;
            this.lstDrivers.Items.AddRange(new object[] {
            "Awaiting Data ... "});
            this.lstDrivers.Location = new System.Drawing.Point(276, 128);
            this.lstDrivers.Name = "lstDrivers";
            this.lstDrivers.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstDrivers.Size = new System.Drawing.Size(165, 244);
            this.lstDrivers.TabIndex = 10;
            this.toolTip1.SetToolTip(this.lstDrivers, "Select driver to view their journeys");
            this.lstDrivers.SelectedIndexChanged += new System.EventHandler(this.lstDrivers_SelectedIndexChanged);
            // 
            // lblLongestJourney
            // 
            this.lblLongestJourney.AutoSize = true;
            this.lblLongestJourney.Location = new System.Drawing.Point(298, 401);
            this.lblLongestJourney.Name = "lblLongestJourney";
            this.lblLongestJourney.Size = new System.Drawing.Size(168, 17);
            this.lblLongestJourney.TabIndex = 11;
            this.lblLongestJourney.Text = "Longest Journey to Date:";
            // 
            // txtLongestJourney
            // 
            this.txtLongestJourney.Location = new System.Drawing.Point(472, 401);
            this.txtLongestJourney.Name = "txtLongestJourney";
            this.txtLongestJourney.ReadOnly = true;
            this.txtLongestJourney.Size = new System.Drawing.Size(658, 22);
            this.txtLongestJourney.TabIndex = 12;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(380, 28);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(169, 17);
            this.lblProgress.TabIndex = 13;
            this.lblProgress.Text = "Please create config data";
            // 
            // lstTotalDistance
            // 
            this.lstTotalDistance.Enabled = false;
            this.lstTotalDistance.FormattingEnabled = true;
            this.lstTotalDistance.ItemHeight = 16;
            this.lstTotalDistance.Items.AddRange(new object[] {
            "Awaiting Data ... "});
            this.lstTotalDistance.Location = new System.Drawing.Point(447, 128);
            this.lstTotalDistance.Name = "lstTotalDistance";
            this.lstTotalDistance.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstTotalDistance.Size = new System.Drawing.Size(165, 244);
            this.lstTotalDistance.TabIndex = 14;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(273, 108);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(91, 17);
            this.lblName.TabIndex = 15;
            this.lblName.Text = "Driver Name:";
            // 
            // lblTotalDistance
            // 
            this.lblTotalDistance.AutoSize = true;
            this.lblTotalDistance.Location = new System.Drawing.Point(444, 108);
            this.lblTotalDistance.Name = "lblTotalDistance";
            this.lblTotalDistance.Size = new System.Drawing.Size(103, 17);
            this.lblTotalDistance.TabIndex = 16;
            this.lblTotalDistance.Text = "Total Distance:";
            // 
            // lblJourneys
            // 
            this.lblJourneys.AutoSize = true;
            this.lblJourneys.Location = new System.Drawing.Point(615, 108);
            this.lblJourneys.Name = "lblJourneys";
            this.lblJourneys.Size = new System.Drawing.Size(70, 17);
            this.lblJourneys.TabIndex = 17;
            this.lblJourneys.Text = "Journeys:";
            // 
            // FormsBasedUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 451);
            this.Controls.Add(this.lblJourneys);
            this.Controls.Add(this.lblTotalDistance);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lstTotalDistance);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.txtLongestJourney);
            this.Controls.Add(this.lblLongestJourney);
            this.Controls.Add(this.lstDrivers);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lstJourneys);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnProducerConsumer);
            this.Controls.Add(this.btnDrivers);
            this.Controls.Add(this.btnDates);
            this.Controls.Add(this.lblSpeedyEats);
            this.Name = "FormsBasedUI";
            this.Text = "SpeedyEats";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSpeedyEats;
        private System.Windows.Forms.Button btnDates;
        private System.Windows.Forms.Button btnDrivers;
        private System.Windows.Forms.Button btnProducerConsumer;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.ListBox lstJourneys;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListBox lstDrivers;
        private System.Windows.Forms.Label lblLongestJourney;
        private System.Windows.Forms.TextBox txtLongestJourney;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ListBox lstTotalDistance;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTotalDistance;
        private System.Windows.Forms.Label lblJourneys;
    }
}

