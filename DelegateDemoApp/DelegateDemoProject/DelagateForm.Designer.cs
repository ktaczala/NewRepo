namespace DelegateDemoProject
{
    partial class DelagateForm
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
            this.ManualButton = new System.Windows.Forms.Button();
            this.TestProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.CountLabel = new System.Windows.Forms.Label();
            this.CountLabel2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BGWProgressBar = new System.Windows.Forms.ProgressBar();
            this.BGWTest = new System.ComponentModel.BackgroundWorker();
            this.BackGroundWorkerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ManualButton
            // 
            this.ManualButton.Location = new System.Drawing.Point(309, 108);
            this.ManualButton.Name = "ManualButton";
            this.ManualButton.Size = new System.Drawing.Size(89, 23);
            this.ManualButton.TabIndex = 0;
            this.ManualButton.Text = "Start Manual";
            this.ManualButton.UseVisualStyleBackColor = true;
            this.ManualButton.Click += new System.EventHandler(this.ManualButton_Click);
            // 
            // TestProgressBar
            // 
            this.TestProgressBar.Location = new System.Drawing.Point(101, 169);
            this.TestProgressBar.Name = "TestProgressBar";
            this.TestProgressBar.Size = new System.Drawing.Size(553, 23);
            this.TestProgressBar.Step = 1;
            this.TestProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.TestProgressBar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(311, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Count: ";
            // 
            // CountLabel
            // 
            this.CountLabel.AutoSize = true;
            this.CountLabel.Location = new System.Drawing.Point(363, 134);
            this.CountLabel.Name = "CountLabel";
            this.CountLabel.Size = new System.Drawing.Size(13, 15);
            this.CountLabel.TabIndex = 3;
            this.CountLabel.Text = "0";
            // 
            // CountLabel2
            // 
            this.CountLabel2.AutoSize = true;
            this.CountLabel2.Location = new System.Drawing.Point(363, 308);
            this.CountLabel2.Name = "CountLabel2";
            this.CountLabel2.Size = new System.Drawing.Size(13, 15);
            this.CountLabel2.TabIndex = 7;
            this.CountLabel2.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(311, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Count: ";
            // 
            // BGWProgressBar
            // 
            this.BGWProgressBar.Location = new System.Drawing.Point(101, 343);
            this.BGWProgressBar.Name = "BGWProgressBar";
            this.BGWProgressBar.Size = new System.Drawing.Size(553, 23);
            this.BGWProgressBar.Step = 1;
            this.BGWProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.BGWProgressBar.TabIndex = 5;
            // 
            // BGWTest
            // 
            this.BGWTest.WorkerReportsProgress = true;
            this.BGWTest.WorkerSupportsCancellation = true;
            this.BGWTest.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWTest_DoWork);
            this.BGWTest.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BGWTest_ProgressChanged);
            // 
            // BackGroundWorkerButton
            // 
            this.BackGroundWorkerButton.Location = new System.Drawing.Point(276, 272);
            this.BackGroundWorkerButton.Name = "BackGroundWorkerButton";
            this.BackGroundWorkerButton.Size = new System.Drawing.Size(162, 23);
            this.BackGroundWorkerButton.TabIndex = 8;
            this.BackGroundWorkerButton.Text = "Start BackGroundWorker";
            this.BackGroundWorkerButton.UseVisualStyleBackColor = true;
            this.BackGroundWorkerButton.Click += new System.EventHandler(this.BGWButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BackGroundWorkerButton);
            this.Controls.Add(this.CountLabel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BGWProgressBar);
            this.Controls.Add(this.CountLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TestProgressBar);
            this.Controls.Add(this.ManualButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button ManualButton;
        private ProgressBar TestProgressBar;
        private Label label1;
        private Label CountLabel;
        private Label CountLabel2;
        private Label label3;
        private ProgressBar BGWProgressBar;
        private System.ComponentModel.BackgroundWorker BGWTest;
        private Button BackGroundWorkerButton;
    }
}