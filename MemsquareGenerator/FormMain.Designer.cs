namespace MemsquareGenerator {
	partial class FormMain {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.uiInputFileLabel = new System.Windows.Forms.Label();
			this.uiInputFileLocation = new System.Windows.Forms.TextBox();
			this.uiInputFileBrowse = new System.Windows.Forms.Button();
			this.uiColoringModeGroupBox = new System.Windows.Forms.GroupBox();
			this.uiColoringModeBlue = new System.Windows.Forms.ComboBox();
			this.uiColoringModeBlueLabel = new System.Windows.Forms.Label();
			this.uiColoringModeGreen = new System.Windows.Forms.ComboBox();
			this.uiColoringModeGreenLabel = new System.Windows.Forms.Label();
			this.uiColoringModeRed = new System.Windows.Forms.ComboBox();
			this.uiColoringModeRedLabel = new System.Windows.Forms.Label();
			this.uiBlockSizeLabel = new System.Windows.Forms.Label();
			this.uiBlockSize = new System.Windows.Forms.NumericUpDown();
			this.uiGenerate = new System.Windows.Forms.Button();
			this.uiProgressBar = new System.Windows.Forms.ProgressBar();
			this.uiCancel = new System.Windows.Forms.Button();
			this.uiVisibleChannelsGroupBox = new System.Windows.Forms.GroupBox();
			this.uiBlueChannelVisible = new System.Windows.Forms.CheckBox();
			this.uiGreenChannelVisible = new System.Windows.Forms.CheckBox();
			this.uiRedChannelVisible = new System.Windows.Forms.CheckBox();
			this.uiInputFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.uiSave = new System.Windows.Forms.Button();
			this.uiWorker = new System.ComponentModel.BackgroundWorker();
			this.uiSaveDialog = new System.Windows.Forms.SaveFileDialog();
			this.uiStatus = new System.Windows.Forms.Label();
			this.uiMemsquareView = new MemsquareGenerator.InterpolatedPictureBox();
			this.uiColoringModeGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.uiBlockSize)).BeginInit();
			this.uiVisibleChannelsGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.uiMemsquareView)).BeginInit();
			this.SuspendLayout();
			// 
			// uiInputFileLabel
			// 
			this.uiInputFileLabel.AutoSize = true;
			this.uiInputFileLabel.Location = new System.Drawing.Point(12, 9);
			this.uiInputFileLabel.Name = "uiInputFileLabel";
			this.uiInputFileLabel.Size = new System.Drawing.Size(50, 13);
			this.uiInputFileLabel.TabIndex = 0;
			this.uiInputFileLabel.Text = "Input File";
			// 
			// uiInputFileLocation
			// 
			this.uiInputFileLocation.Location = new System.Drawing.Point(12, 25);
			this.uiInputFileLocation.Name = "uiInputFileLocation";
			this.uiInputFileLocation.Size = new System.Drawing.Size(176, 20);
			this.uiInputFileLocation.TabIndex = 1;
			// 
			// uiInputFileBrowse
			// 
			this.uiInputFileBrowse.Location = new System.Drawing.Point(194, 23);
			this.uiInputFileBrowse.Name = "uiInputFileBrowse";
			this.uiInputFileBrowse.Size = new System.Drawing.Size(24, 23);
			this.uiInputFileBrowse.TabIndex = 2;
			this.uiInputFileBrowse.Text = "...";
			this.uiInputFileBrowse.UseVisualStyleBackColor = true;
			this.uiInputFileBrowse.Click += new System.EventHandler(this.uiInputFileBrowse_Click);
			// 
			// uiColoringModeGroupBox
			// 
			this.uiColoringModeGroupBox.Controls.Add(this.uiColoringModeBlue);
			this.uiColoringModeGroupBox.Controls.Add(this.uiColoringModeBlueLabel);
			this.uiColoringModeGroupBox.Controls.Add(this.uiColoringModeGreen);
			this.uiColoringModeGroupBox.Controls.Add(this.uiColoringModeGreenLabel);
			this.uiColoringModeGroupBox.Controls.Add(this.uiColoringModeRed);
			this.uiColoringModeGroupBox.Controls.Add(this.uiColoringModeRedLabel);
			this.uiColoringModeGroupBox.Location = new System.Drawing.Point(12, 90);
			this.uiColoringModeGroupBox.Name = "uiColoringModeGroupBox";
			this.uiColoringModeGroupBox.Size = new System.Drawing.Size(206, 141);
			this.uiColoringModeGroupBox.TabIndex = 3;
			this.uiColoringModeGroupBox.TabStop = false;
			this.uiColoringModeGroupBox.Text = "Coloring Mode";
			// 
			// uiColoringModeBlue
			// 
			this.uiColoringModeBlue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.uiColoringModeBlue.FormattingEnabled = true;
			this.uiColoringModeBlue.Location = new System.Drawing.Point(6, 112);
			this.uiColoringModeBlue.Name = "uiColoringModeBlue";
			this.uiColoringModeBlue.Size = new System.Drawing.Size(194, 21);
			this.uiColoringModeBlue.TabIndex = 6;
			// 
			// uiColoringModeBlueLabel
			// 
			this.uiColoringModeBlueLabel.AutoSize = true;
			this.uiColoringModeBlueLabel.Location = new System.Drawing.Point(6, 96);
			this.uiColoringModeBlueLabel.Name = "uiColoringModeBlueLabel";
			this.uiColoringModeBlueLabel.Size = new System.Drawing.Size(28, 13);
			this.uiColoringModeBlueLabel.TabIndex = 4;
			this.uiColoringModeBlueLabel.Text = "Blue";
			// 
			// uiColoringModeGreen
			// 
			this.uiColoringModeGreen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.uiColoringModeGreen.FormattingEnabled = true;
			this.uiColoringModeGreen.Location = new System.Drawing.Point(6, 72);
			this.uiColoringModeGreen.Name = "uiColoringModeGreen";
			this.uiColoringModeGreen.Size = new System.Drawing.Size(194, 21);
			this.uiColoringModeGreen.TabIndex = 5;
			// 
			// uiColoringModeGreenLabel
			// 
			this.uiColoringModeGreenLabel.AutoSize = true;
			this.uiColoringModeGreenLabel.Location = new System.Drawing.Point(6, 56);
			this.uiColoringModeGreenLabel.Name = "uiColoringModeGreenLabel";
			this.uiColoringModeGreenLabel.Size = new System.Drawing.Size(36, 13);
			this.uiColoringModeGreenLabel.TabIndex = 2;
			this.uiColoringModeGreenLabel.Text = "Green";
			// 
			// uiColoringModeRed
			// 
			this.uiColoringModeRed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.uiColoringModeRed.FormattingEnabled = true;
			this.uiColoringModeRed.Location = new System.Drawing.Point(6, 32);
			this.uiColoringModeRed.Name = "uiColoringModeRed";
			this.uiColoringModeRed.Size = new System.Drawing.Size(194, 21);
			this.uiColoringModeRed.TabIndex = 4;
			// 
			// uiColoringModeRedLabel
			// 
			this.uiColoringModeRedLabel.AutoSize = true;
			this.uiColoringModeRedLabel.Location = new System.Drawing.Point(6, 16);
			this.uiColoringModeRedLabel.Name = "uiColoringModeRedLabel";
			this.uiColoringModeRedLabel.Size = new System.Drawing.Size(27, 13);
			this.uiColoringModeRedLabel.TabIndex = 0;
			this.uiColoringModeRedLabel.Text = "Red";
			// 
			// uiBlockSizeLabel
			// 
			this.uiBlockSizeLabel.AutoSize = true;
			this.uiBlockSizeLabel.Location = new System.Drawing.Point(12, 48);
			this.uiBlockSizeLabel.Name = "uiBlockSizeLabel";
			this.uiBlockSizeLabel.Size = new System.Drawing.Size(57, 13);
			this.uiBlockSizeLabel.TabIndex = 4;
			this.uiBlockSizeLabel.Text = "Block Size";
			// 
			// uiBlockSize
			// 
			this.uiBlockSize.Location = new System.Drawing.Point(12, 64);
			this.uiBlockSize.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
			this.uiBlockSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.uiBlockSize.Name = "uiBlockSize";
			this.uiBlockSize.Size = new System.Drawing.Size(206, 20);
			this.uiBlockSize.TabIndex = 3;
			this.uiBlockSize.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
			// 
			// uiGenerate
			// 
			this.uiGenerate.Location = new System.Drawing.Point(12, 266);
			this.uiGenerate.Name = "uiGenerate";
			this.uiGenerate.Size = new System.Drawing.Size(206, 23);
			this.uiGenerate.TabIndex = 7;
			this.uiGenerate.Text = "Generate";
			this.uiGenerate.UseVisualStyleBackColor = true;
			this.uiGenerate.Click += new System.EventHandler(this.uiGenerate_Click);
			// 
			// uiProgressBar
			// 
			this.uiProgressBar.Location = new System.Drawing.Point(12, 237);
			this.uiProgressBar.Name = "uiProgressBar";
			this.uiProgressBar.Size = new System.Drawing.Size(206, 23);
			this.uiProgressBar.TabIndex = 7;
			// 
			// uiCancel
			// 
			this.uiCancel.Location = new System.Drawing.Point(12, 295);
			this.uiCancel.Name = "uiCancel";
			this.uiCancel.Size = new System.Drawing.Size(206, 23);
			this.uiCancel.TabIndex = 8;
			this.uiCancel.Text = "Cancel";
			this.uiCancel.UseVisualStyleBackColor = true;
			this.uiCancel.Click += new System.EventHandler(this.uiCancel_Click);
			// 
			// uiVisibleChannelsGroupBox
			// 
			this.uiVisibleChannelsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.uiVisibleChannelsGroupBox.Controls.Add(this.uiBlueChannelVisible);
			this.uiVisibleChannelsGroupBox.Controls.Add(this.uiGreenChannelVisible);
			this.uiVisibleChannelsGroupBox.Controls.Add(this.uiRedChannelVisible);
			this.uiVisibleChannelsGroupBox.Location = new System.Drawing.Point(12, 435);
			this.uiVisibleChannelsGroupBox.Name = "uiVisibleChannelsGroupBox";
			this.uiVisibleChannelsGroupBox.Size = new System.Drawing.Size(206, 89);
			this.uiVisibleChannelsGroupBox.TabIndex = 9;
			this.uiVisibleChannelsGroupBox.TabStop = false;
			this.uiVisibleChannelsGroupBox.Text = "Visible Channels";
			// 
			// uiBlueChannelVisible
			// 
			this.uiBlueChannelVisible.AutoCheck = false;
			this.uiBlueChannelVisible.AutoSize = true;
			this.uiBlueChannelVisible.Checked = true;
			this.uiBlueChannelVisible.CheckState = System.Windows.Forms.CheckState.Checked;
			this.uiBlueChannelVisible.Location = new System.Drawing.Point(6, 65);
			this.uiBlueChannelVisible.Name = "uiBlueChannelVisible";
			this.uiBlueChannelVisible.Size = new System.Drawing.Size(47, 17);
			this.uiBlueChannelVisible.TabIndex = 11;
			this.uiBlueChannelVisible.Text = "Blue";
			this.uiBlueChannelVisible.UseVisualStyleBackColor = true;
			this.uiBlueChannelVisible.CheckStateChanged += new System.EventHandler(this.visibleChannels_CheckStateChanged);
			this.uiBlueChannelVisible.Click += new System.EventHandler(this.visibleChannels_Click);
			// 
			// uiGreenChannelVisible
			// 
			this.uiGreenChannelVisible.AutoCheck = false;
			this.uiGreenChannelVisible.AutoSize = true;
			this.uiGreenChannelVisible.Checked = true;
			this.uiGreenChannelVisible.CheckState = System.Windows.Forms.CheckState.Checked;
			this.uiGreenChannelVisible.Location = new System.Drawing.Point(6, 42);
			this.uiGreenChannelVisible.Name = "uiGreenChannelVisible";
			this.uiGreenChannelVisible.Size = new System.Drawing.Size(55, 17);
			this.uiGreenChannelVisible.TabIndex = 10;
			this.uiGreenChannelVisible.Text = "Green";
			this.uiGreenChannelVisible.UseVisualStyleBackColor = true;
			this.uiGreenChannelVisible.CheckStateChanged += new System.EventHandler(this.visibleChannels_CheckStateChanged);
			this.uiGreenChannelVisible.Click += new System.EventHandler(this.visibleChannels_Click);
			// 
			// uiRedChannelVisible
			// 
			this.uiRedChannelVisible.AutoCheck = false;
			this.uiRedChannelVisible.AutoSize = true;
			this.uiRedChannelVisible.Checked = true;
			this.uiRedChannelVisible.CheckState = System.Windows.Forms.CheckState.Checked;
			this.uiRedChannelVisible.Location = new System.Drawing.Point(6, 19);
			this.uiRedChannelVisible.Name = "uiRedChannelVisible";
			this.uiRedChannelVisible.Size = new System.Drawing.Size(46, 17);
			this.uiRedChannelVisible.TabIndex = 9;
			this.uiRedChannelVisible.Text = "Red";
			this.uiRedChannelVisible.UseVisualStyleBackColor = true;
			this.uiRedChannelVisible.CheckStateChanged += new System.EventHandler(this.visibleChannels_CheckStateChanged);
			this.uiRedChannelVisible.Click += new System.EventHandler(this.visibleChannels_Click);
			// 
			// uiInputFileDialog
			// 
			this.uiInputFileDialog.Filter = "All Files (*.*)|*.*";
			// 
			// uiSave
			// 
			this.uiSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.uiSave.Location = new System.Drawing.Point(661, 530);
			this.uiSave.Name = "uiSave";
			this.uiSave.Size = new System.Drawing.Size(75, 23);
			this.uiSave.TabIndex = 12;
			this.uiSave.Text = "Save";
			this.uiSave.UseVisualStyleBackColor = true;
			this.uiSave.Click += new System.EventHandler(this.uiSave_Click);
			// 
			// uiWorker
			// 
			this.uiWorker.WorkerReportsProgress = true;
			this.uiWorker.WorkerSupportsCancellation = true;
			this.uiWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.uiWorker_DoWork);
			this.uiWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.uiWorker_ProgressChanged);
			this.uiWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.uiWorker_RunWorkerCompleted);
			// 
			// uiSaveDialog
			// 
			this.uiSaveDialog.Filter = "PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";
			// 
			// uiStatus
			// 
			this.uiStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.uiStatus.AutoSize = true;
			this.uiStatus.Location = new System.Drawing.Point(221, 530);
			this.uiStatus.Name = "uiStatus";
			this.uiStatus.Size = new System.Drawing.Size(65, 13);
			this.uiStatus.TabIndex = 13;
			this.uiStatus.Text = "{RUNTIME}";
			// 
			// uiMemsquareView
			// 
			this.uiMemsquareView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.uiMemsquareView.BackColor = System.Drawing.SystemColors.ControlDark;
			this.uiMemsquareView.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			this.uiMemsquareView.Location = new System.Drawing.Point(224, 12);
			this.uiMemsquareView.Name = "uiMemsquareView";
			this.uiMemsquareView.Size = new System.Drawing.Size(512, 512);
			this.uiMemsquareView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.uiMemsquareView.TabIndex = 10;
			this.uiMemsquareView.TabStop = false;
			this.uiMemsquareView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.uiMemsquareView_MouseMove);
			// 
			// FormMain
			// 
			this.AcceptButton = this.uiGenerate;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(748, 565);
			this.Controls.Add(this.uiStatus);
			this.Controls.Add(this.uiSave);
			this.Controls.Add(this.uiMemsquareView);
			this.Controls.Add(this.uiVisibleChannelsGroupBox);
			this.Controls.Add(this.uiCancel);
			this.Controls.Add(this.uiProgressBar);
			this.Controls.Add(this.uiGenerate);
			this.Controls.Add(this.uiBlockSize);
			this.Controls.Add(this.uiBlockSizeLabel);
			this.Controls.Add(this.uiColoringModeGroupBox);
			this.Controls.Add(this.uiInputFileBrowse);
			this.Controls.Add(this.uiInputFileLocation);
			this.Controls.Add(this.uiInputFileLabel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(764, 604);
			this.Name = "FormMain";
			this.Text = "Memsquare Generator";
			this.uiColoringModeGroupBox.ResumeLayout(false);
			this.uiColoringModeGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.uiBlockSize)).EndInit();
			this.uiVisibleChannelsGroupBox.ResumeLayout(false);
			this.uiVisibleChannelsGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.uiMemsquareView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label uiInputFileLabel;
		private System.Windows.Forms.TextBox uiInputFileLocation;
		private System.Windows.Forms.Button uiInputFileBrowse;
		private System.Windows.Forms.GroupBox uiColoringModeGroupBox;
		private System.Windows.Forms.ComboBox uiColoringModeBlue;
		private System.Windows.Forms.Label uiColoringModeBlueLabel;
		private System.Windows.Forms.ComboBox uiColoringModeGreen;
		private System.Windows.Forms.Label uiColoringModeGreenLabel;
		private System.Windows.Forms.ComboBox uiColoringModeRed;
		private System.Windows.Forms.Label uiColoringModeRedLabel;
		private System.Windows.Forms.Label uiBlockSizeLabel;
		private System.Windows.Forms.NumericUpDown uiBlockSize;
		private System.Windows.Forms.Button uiGenerate;
		private System.Windows.Forms.ProgressBar uiProgressBar;
		private System.Windows.Forms.Button uiCancel;
		private System.Windows.Forms.GroupBox uiVisibleChannelsGroupBox;
		private System.Windows.Forms.CheckBox uiBlueChannelVisible;
		private System.Windows.Forms.CheckBox uiGreenChannelVisible;
		private System.Windows.Forms.CheckBox uiRedChannelVisible;
		private InterpolatedPictureBox uiMemsquareView;
		private System.Windows.Forms.OpenFileDialog uiInputFileDialog;
		private System.Windows.Forms.Button uiSave;
		private System.ComponentModel.BackgroundWorker uiWorker;
		private System.Windows.Forms.SaveFileDialog uiSaveDialog;
		private System.Windows.Forms.Label uiStatus;
	}
}

