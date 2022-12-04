namespace DelegateDemoProject
{
    partial class DelegateForm
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
            this.ManualCountLabel = new System.Windows.Forms.Label();
            this.BGWCountLabel = new System.Windows.Forms.Label();
            this.BGWProgressBar = new System.Windows.Forms.ProgressBar();
            this.BGWTest = new System.ComponentModel.BackgroundWorker();
            this.BackGroundWorkerButton = new System.Windows.Forms.Button();
            this.Asyncbutton = new System.Windows.Forms.Button();
            this.AsyncCountlabel = new System.Windows.Forms.Label();
            this.AsyncProgressBar = new System.Windows.Forms.ProgressBar();
            this.AsyncWithIProgressBar = new System.Windows.Forms.ProgressBar();
            this.AsyncWIProgressCountLabel = new System.Windows.Forms.Label();
            this.AsyncIProgressButton = new System.Windows.Forms.Button();
            this.RunAllButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ManualButton
            // 
            this.ManualButton.Location = new System.Drawing.Point(327, 12);
            this.ManualButton.Name = "ManualButton";
            this.ManualButton.Size = new System.Drawing.Size(89, 23);
            this.ManualButton.TabIndex = 0;
            this.ManualButton.Text = "Start Manual";
            this.ManualButton.UseVisualStyleBackColor = true;
            this.ManualButton.Click += new System.EventHandler(this.ManualButton_Click);
            // 
            // TestProgressBar
            // 
            this.TestProgressBar.Location = new System.Drawing.Point(118, 41);
            this.TestProgressBar.Name = "TestProgressBar";
            this.TestProgressBar.Size = new System.Drawing.Size(553, 23);
            this.TestProgressBar.Step = 1;
            this.TestProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.TestProgressBar.TabIndex = 1;
            // 
            // ManualCountLabel
            // 
            this.ManualCountLabel.AutoSize = true;
            this.ManualCountLabel.Location = new System.Drawing.Point(695, 45);
            this.ManualCountLabel.Name = "ManualCountLabel";
            this.ManualCountLabel.Size = new System.Drawing.Size(23, 15);
            this.ManualCountLabel.TabIndex = 3;
            this.ManualCountLabel.Text = "0%";
            // 
            // BGWCountLabel
            // 
            this.BGWCountLabel.AutoSize = true;
            this.BGWCountLabel.Location = new System.Drawing.Point(696, 103);
            this.BGWCountLabel.Name = "BGWCountLabel";
            this.BGWCountLabel.Size = new System.Drawing.Size(23, 15);
            this.BGWCountLabel.TabIndex = 7;
            this.BGWCountLabel.Text = "0%";
            // 
            // BGWProgressBar
            // 
            this.BGWProgressBar.Location = new System.Drawing.Point(118, 99);
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
            this.BGWTest.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGWTest_RunWorkerCompleted);
            // 
            // BackGroundWorkerButton
            // 
            this.BackGroundWorkerButton.Location = new System.Drawing.Point(293, 70);
            this.BackGroundWorkerButton.Name = "BackGroundWorkerButton";
            this.BackGroundWorkerButton.Size = new System.Drawing.Size(162, 23);
            this.BackGroundWorkerButton.TabIndex = 8;
            this.BackGroundWorkerButton.Text = "Start BackGroundWorker";
            this.BackGroundWorkerButton.UseVisualStyleBackColor = true;
            this.BackGroundWorkerButton.Click += new System.EventHandler(this.BGWButton_Click);
            // 
            // Asyncbutton
            // 
            this.Asyncbutton.Location = new System.Drawing.Point(293, 128);
            this.Asyncbutton.Name = "Asyncbutton";
            this.Asyncbutton.Size = new System.Drawing.Size(162, 23);
            this.Asyncbutton.TabIndex = 12;
            this.Asyncbutton.Text = "Start Async";
            this.Asyncbutton.UseVisualStyleBackColor = true;
            this.Asyncbutton.Click += new System.EventHandler(this.Asyncbutton_Click);
            // 
            // AsyncCountlabel
            // 
            this.AsyncCountlabel.AutoSize = true;
            this.AsyncCountlabel.Location = new System.Drawing.Point(696, 161);
            this.AsyncCountlabel.Name = "AsyncCountlabel";
            this.AsyncCountlabel.Size = new System.Drawing.Size(23, 15);
            this.AsyncCountlabel.TabIndex = 11;
            this.AsyncCountlabel.Text = "0%";
            // 
            // AsyncProgressBar
            // 
            this.AsyncProgressBar.Location = new System.Drawing.Point(118, 157);
            this.AsyncProgressBar.Name = "AsyncProgressBar";
            this.AsyncProgressBar.Size = new System.Drawing.Size(553, 23);
            this.AsyncProgressBar.Step = 1;
            this.AsyncProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.AsyncProgressBar.TabIndex = 9;
            // 
            // AsyncWithIProgressBar
            // 
            this.AsyncWithIProgressBar.Location = new System.Drawing.Point(118, 215);
            this.AsyncWithIProgressBar.Name = "AsyncWithIProgressBar";
            this.AsyncWithIProgressBar.Size = new System.Drawing.Size(553, 23);
            this.AsyncWithIProgressBar.Step = 1;
            this.AsyncWithIProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.AsyncWithIProgressBar.TabIndex = 9;
            // 
            // AsyncWIProgressCountLabel
            // 
            this.AsyncWIProgressCountLabel.AutoSize = true;
            this.AsyncWIProgressCountLabel.Location = new System.Drawing.Point(696, 219);
            this.AsyncWIProgressCountLabel.Name = "AsyncWIProgressCountLabel";
            this.AsyncWIProgressCountLabel.Size = new System.Drawing.Size(23, 15);
            this.AsyncWIProgressCountLabel.TabIndex = 11;
            this.AsyncWIProgressCountLabel.Text = "0%";
            // 
            // AsyncIProgressButton
            // 
            this.AsyncIProgressButton.Location = new System.Drawing.Point(293, 186);
            this.AsyncIProgressButton.Name = "AsyncIProgressButton";
            this.AsyncIProgressButton.Size = new System.Drawing.Size(162, 23);
            this.AsyncIProgressButton.TabIndex = 12;
            this.AsyncIProgressButton.Text = "Start Async w/IProgress";
            this.AsyncIProgressButton.UseVisualStyleBackColor = true;
            this.AsyncIProgressButton.Click += new System.EventHandler(this.AsyncWithIProgressbutton_Click);
            // 
            // RunAllButton
            // 
            this.RunAllButton.Location = new System.Drawing.Point(341, 273);
            this.RunAllButton.Name = "RunAllButton";
            this.RunAllButton.Size = new System.Drawing.Size(75, 23);
            this.RunAllButton.TabIndex = 13;
            this.RunAllButton.Text = "Start All";
            this.RunAllButton.UseVisualStyleBackColor = true;
            this.RunAllButton.Click += new System.EventHandler(this.RunAllButton_Click);
            // 
            // DelegateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RunAllButton);
            this.Controls.Add(this.AsyncIProgressButton);
            this.Controls.Add(this.AsyncWIProgressCountLabel);
            this.Controls.Add(this.Asyncbutton);
            this.Controls.Add(this.AsyncWithIProgressBar);
            this.Controls.Add(this.AsyncCountlabel);
            this.Controls.Add(this.AsyncProgressBar);
            this.Controls.Add(this.BackGroundWorkerButton);
            this.Controls.Add(this.BGWCountLabel);
            this.Controls.Add(this.BGWProgressBar);
            this.Controls.Add(this.ManualCountLabel);
            this.Controls.Add(this.TestProgressBar);
            this.Controls.Add(this.ManualButton);
            this.Name = "DelegateForm";
            this.Text = "Using Delegates";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button ManualButton;
        private ProgressBar TestProgressBar;
        private Label ManualCountLabel;
        private Label BGWCountLabel;
        private ProgressBar BGWProgressBar;
        private System.ComponentModel.BackgroundWorker BGWTest;
        private Button BackGroundWorkerButton;
        private Button Asyncbutton;
        private Label AsyncCountlabel;
        private ProgressBar AsyncProgressBar;
        private ProgressBar AsyncWithIProgressBar;
        private Label AsyncWIProgressCountLabel;
        private Button AsyncIProgressButton;
        private Button RunAllButton;
    }
}