namespace New_Pathfinder
{
    partial class Form
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
            this.panel = new System.Windows.Forms.Panel();
            this.autoResizeCheckBox = new System.Windows.Forms.CheckBox();
            this.pathIntervalLabel = new System.Windows.Forms.Label();
            this.pathIntervalTrackBar = new System.Windows.Forms.TrackBar();
            this.revealPathCheckBox = new System.Windows.Forms.CheckBox();
            this.pathLengthLabel = new System.Windows.Forms.Label();
            this.gridSizeLabel = new System.Windows.Forms.Label();
            this.showNodeInfoCheckBox = new System.Windows.Forms.CheckBox();
            this.autoPathfindCheckBox = new System.Windows.Forms.CheckBox();
            this.boxSizeLabel = new System.Windows.Forms.Label();
            this.gridSizeTrackBar = new System.Windows.Forms.TrackBar();
            this.findPathButton = new System.Windows.Forms.Button();
            this.loadGridButton = new System.Windows.Forms.Button();
            this.saveGridButton = new System.Windows.Forms.Button();
            this.clearGridButton = new System.Windows.Forms.Button();
            this.createGridButton = new System.Windows.Forms.Button();
            this.gridSizeTextBox = new System.Windows.Forms.TextBox();
            this.gridPictureBox = new System.Windows.Forms.PictureBox();
            this.revealPathTimer = new System.Windows.Forms.Timer(this.components);
            this.rgbTimer = new System.Windows.Forms.Timer(this.components);
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pathIntervalTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSizeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel.Controls.Add(this.autoResizeCheckBox);
            this.panel.Controls.Add(this.pathIntervalLabel);
            this.panel.Controls.Add(this.pathIntervalTrackBar);
            this.panel.Controls.Add(this.revealPathCheckBox);
            this.panel.Controls.Add(this.pathLengthLabel);
            this.panel.Controls.Add(this.gridSizeLabel);
            this.panel.Controls.Add(this.showNodeInfoCheckBox);
            this.panel.Controls.Add(this.autoPathfindCheckBox);
            this.panel.Controls.Add(this.boxSizeLabel);
            this.panel.Controls.Add(this.gridSizeTrackBar);
            this.panel.Controls.Add(this.findPathButton);
            this.panel.Controls.Add(this.loadGridButton);
            this.panel.Controls.Add(this.saveGridButton);
            this.panel.Controls.Add(this.clearGridButton);
            this.panel.Controls.Add(this.createGridButton);
            this.panel.Controls.Add(this.gridSizeTextBox);
            this.panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(200, 450);
            this.panel.TabIndex = 0;
            // 
            // autoResizeCheckBox
            // 
            this.autoResizeCheckBox.AutoSize = true;
            this.autoResizeCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.autoResizeCheckBox.Location = new System.Drawing.Point(0, 359);
            this.autoResizeCheckBox.Name = "autoResizeCheckBox";
            this.autoResizeCheckBox.Size = new System.Drawing.Size(200, 17);
            this.autoResizeCheckBox.TabIndex = 19;
            this.autoResizeCheckBox.Text = "Auto Resize";
            this.autoResizeCheckBox.UseVisualStyleBackColor = true;
            // 
            // pathIntervalLabel
            // 
            this.pathIntervalLabel.AutoSize = true;
            this.pathIntervalLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pathIntervalLabel.Location = new System.Drawing.Point(0, 346);
            this.pathIntervalLabel.Name = "pathIntervalLabel";
            this.pathIntervalLabel.Size = new System.Drawing.Size(131, 13);
            this.pathIntervalLabel.TabIndex = 14;
            this.pathIntervalLabel.Text = "Path Reveal Interval:  100";
            this.pathIntervalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pathIntervalTrackBar
            // 
            this.pathIntervalTrackBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pathIntervalTrackBar.Location = new System.Drawing.Point(0, 301);
            this.pathIntervalTrackBar.Maximum = 1000;
            this.pathIntervalTrackBar.Minimum = 1;
            this.pathIntervalTrackBar.Name = "pathIntervalTrackBar";
            this.pathIntervalTrackBar.Size = new System.Drawing.Size(200, 45);
            this.pathIntervalTrackBar.TabIndex = 13;
            this.pathIntervalTrackBar.Value = 100;
            this.pathIntervalTrackBar.ValueChanged += new System.EventHandler(this.pathIntervalTrackBar_ValueChanged);
            // 
            // revealPathCheckBox
            // 
            this.revealPathCheckBox.AutoSize = true;
            this.revealPathCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.revealPathCheckBox.Location = new System.Drawing.Point(0, 284);
            this.revealPathCheckBox.Name = "revealPathCheckBox";
            this.revealPathCheckBox.Size = new System.Drawing.Size(200, 17);
            this.revealPathCheckBox.TabIndex = 12;
            this.revealPathCheckBox.Text = "Show Path Animation";
            this.revealPathCheckBox.UseVisualStyleBackColor = true;
            // 
            // pathLengthLabel
            // 
            this.pathLengthLabel.AutoSize = true;
            this.pathLengthLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pathLengthLabel.Location = new System.Drawing.Point(0, 271);
            this.pathLengthLabel.Name = "pathLengthLabel";
            this.pathLengthLabel.Size = new System.Drawing.Size(77, 13);
            this.pathLengthLabel.TabIndex = 11;
            this.pathLengthLabel.Text = "Path Length: ∞";
            this.pathLengthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridSizeLabel
            // 
            this.gridSizeLabel.AutoSize = true;
            this.gridSizeLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridSizeLabel.Location = new System.Drawing.Point(0, 258);
            this.gridSizeLabel.Name = "gridSizeLabel";
            this.gridSizeLabel.Size = new System.Drawing.Size(61, 13);
            this.gridSizeLabel.TabIndex = 10;
            this.gridSizeLabel.Text = "Grid Size: 0";
            this.gridSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // showNodeInfoCheckBox
            // 
            this.showNodeInfoCheckBox.AutoSize = true;
            this.showNodeInfoCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.showNodeInfoCheckBox.Location = new System.Drawing.Point(0, 241);
            this.showNodeInfoCheckBox.Name = "showNodeInfoCheckBox";
            this.showNodeInfoCheckBox.Size = new System.Drawing.Size(200, 17);
            this.showNodeInfoCheckBox.TabIndex = 9;
            this.showNodeInfoCheckBox.Text = "Show Node Info";
            this.showNodeInfoCheckBox.UseVisualStyleBackColor = true;
            this.showNodeInfoCheckBox.CheckedChanged += new System.EventHandler(this.showNodeInfoCheckBox_CheckedChanged);
            // 
            // autoPathfindCheckBox
            // 
            this.autoPathfindCheckBox.AutoSize = true;
            this.autoPathfindCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.autoPathfindCheckBox.Location = new System.Drawing.Point(0, 224);
            this.autoPathfindCheckBox.Name = "autoPathfindCheckBox";
            this.autoPathfindCheckBox.Size = new System.Drawing.Size(200, 17);
            this.autoPathfindCheckBox.TabIndex = 8;
            this.autoPathfindCheckBox.Text = "Auto Find Path";
            this.autoPathfindCheckBox.UseVisualStyleBackColor = true;
            // 
            // boxSizeLabel
            // 
            this.boxSizeLabel.AutoSize = true;
            this.boxSizeLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.boxSizeLabel.Location = new System.Drawing.Point(0, 211);
            this.boxSizeLabel.Name = "boxSizeLabel";
            this.boxSizeLabel.Size = new System.Drawing.Size(74, 13);
            this.boxSizeLabel.TabIndex = 7;
            this.boxSizeLabel.Text = "Node Size: 75";
            this.boxSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridSizeTrackBar
            // 
            this.gridSizeTrackBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridSizeTrackBar.Location = new System.Drawing.Point(0, 166);
            this.gridSizeTrackBar.Maximum = 125;
            this.gridSizeTrackBar.Minimum = 5;
            this.gridSizeTrackBar.Name = "gridSizeTrackBar";
            this.gridSizeTrackBar.Size = new System.Drawing.Size(200, 45);
            this.gridSizeTrackBar.TabIndex = 6;
            this.gridSizeTrackBar.Value = 75;
            this.gridSizeTrackBar.ValueChanged += new System.EventHandler(this.gridSizeTrackBar_ValueChanged);
            // 
            // findPathButton
            // 
            this.findPathButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.findPathButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.findPathButton.Location = new System.Drawing.Point(0, 415);
            this.findPathButton.Name = "findPathButton";
            this.findPathButton.Size = new System.Drawing.Size(200, 35);
            this.findPathButton.TabIndex = 5;
            this.findPathButton.Text = "Find Path";
            this.findPathButton.UseVisualStyleBackColor = false;
            this.findPathButton.Click += new System.EventHandler(this.findPathButton_Click);
            // 
            // loadGridButton
            // 
            this.loadGridButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.loadGridButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.loadGridButton.Location = new System.Drawing.Point(0, 131);
            this.loadGridButton.Name = "loadGridButton";
            this.loadGridButton.Size = new System.Drawing.Size(200, 35);
            this.loadGridButton.TabIndex = 4;
            this.loadGridButton.Text = "Load Grid";
            this.loadGridButton.UseVisualStyleBackColor = false;
            this.loadGridButton.Click += new System.EventHandler(this.loadGridButton_Click);
            // 
            // saveGridButton
            // 
            this.saveGridButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.saveGridButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.saveGridButton.Location = new System.Drawing.Point(0, 96);
            this.saveGridButton.Name = "saveGridButton";
            this.saveGridButton.Size = new System.Drawing.Size(200, 35);
            this.saveGridButton.TabIndex = 3;
            this.saveGridButton.Text = "Save Grid";
            this.saveGridButton.UseVisualStyleBackColor = false;
            this.saveGridButton.Click += new System.EventHandler(this.saveGridButton_Click);
            // 
            // clearGridButton
            // 
            this.clearGridButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.clearGridButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.clearGridButton.Location = new System.Drawing.Point(0, 61);
            this.clearGridButton.Name = "clearGridButton";
            this.clearGridButton.Size = new System.Drawing.Size(200, 35);
            this.clearGridButton.TabIndex = 2;
            this.clearGridButton.Text = "Clear Grid";
            this.clearGridButton.UseVisualStyleBackColor = false;
            this.clearGridButton.Click += new System.EventHandler(this.clearGridButton_Click);
            // 
            // createGridButton
            // 
            this.createGridButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.createGridButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.createGridButton.Location = new System.Drawing.Point(0, 26);
            this.createGridButton.Name = "createGridButton";
            this.createGridButton.Size = new System.Drawing.Size(200, 35);
            this.createGridButton.TabIndex = 1;
            this.createGridButton.Text = "Create Grid";
            this.createGridButton.UseVisualStyleBackColor = false;
            this.createGridButton.Click += new System.EventHandler(this.createGridButton_Click);
            // 
            // gridSizeTextBox
            // 
            this.gridSizeTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridSizeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridSizeTextBox.Location = new System.Drawing.Point(0, 0);
            this.gridSizeTextBox.MaxLength = 3;
            this.gridSizeTextBox.Name = "gridSizeTextBox";
            this.gridSizeTextBox.Size = new System.Drawing.Size(200, 26);
            this.gridSizeTextBox.TabIndex = 0;
            // 
            // gridPictureBox
            // 
            this.gridPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPictureBox.Location = new System.Drawing.Point(200, 0);
            this.gridPictureBox.Name = "gridPictureBox";
            this.gridPictureBox.Size = new System.Drawing.Size(350, 450);
            this.gridPictureBox.TabIndex = 1;
            this.gridPictureBox.TabStop = false;
            this.gridPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.gridPictureBox_Paint);
            this.gridPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridPictureBox_MouseDown);
            this.gridPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridPictureBox_MouseMove);
            this.gridPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridPictureBox_MouseUp);
            // 
            // revealPathTimer
            // 
            this.revealPathTimer.Tick += new System.EventHandler(this.revealPathTimer_Tick);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 450);
            this.Controls.Add(this.gridPictureBox);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pathfinder";
            this.Load += new System.EventHandler(this.Form_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_KeyUp);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pathIntervalTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSizeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.TextBox gridSizeTextBox;
        private System.Windows.Forms.Button createGridButton;
        private System.Windows.Forms.Button loadGridButton;
        private System.Windows.Forms.Button saveGridButton;
        private System.Windows.Forms.Button clearGridButton;
        private System.Windows.Forms.PictureBox gridPictureBox;
        private System.Windows.Forms.Button findPathButton;
        private System.Windows.Forms.TrackBar gridSizeTrackBar;
        private System.Windows.Forms.CheckBox autoPathfindCheckBox;
        private System.Windows.Forms.CheckBox showNodeInfoCheckBox;
        private System.Windows.Forms.Label gridSizeLabel;
        private System.Windows.Forms.Label pathLengthLabel;
        private System.Windows.Forms.Timer revealPathTimer;
        private System.Windows.Forms.CheckBox revealPathCheckBox;
        private System.Windows.Forms.Label pathIntervalLabel;
        private System.Windows.Forms.TrackBar pathIntervalTrackBar;
        private System.Windows.Forms.Label boxSizeLabel;
        private System.Windows.Forms.Timer rgbTimer;
        private System.Windows.Forms.CheckBox autoResizeCheckBox;
    }
}

