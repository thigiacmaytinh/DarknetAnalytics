using System;
using System.ComponentModel;

namespace DarknetAnalytics
{
    partial class Form1
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
            this.btnCopyPath = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_probability = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bgLoadFile = new System.ComponentModel.BackgroundWorker();
            this.grLeft = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblIndex = new System.Windows.Forms.Label();
            this.txtMoveFile2 = new System.Windows.Forms.TextBox();
            this.txtMoveFile1 = new System.Windows.Forms.TextBox();
            this.chkMoveFileNotDetect = new System.Windows.Forms.CheckBox();
            this.chkMoveFileDetected = new System.Windows.Forms.CheckBox();
            this.chkDefault = new System.Windows.Forms.CheckBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnAnalytics = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_load = new System.Windows.Forms.Button();
            this.cb_weight = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_loadWeight = new System.Windows.Forms.Button();
            this.cb_config = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_loadConfig = new System.Windows.Forms.Button();
            this.cb_classes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoadClasses = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowseDir = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.bgAnalytics = new System.ComponentModel.BackgroundWorker();
            this.contextListview = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnOpenImage = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.timerClear = new System.Windows.Forms.Timer(this.components);
            this.grLeft.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contextListview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCopyPath
            // 
            this.btnCopyPath.Name = "btnCopyPath";
            this.btnCopyPath.Size = new System.Drawing.Size(139, 22);
            this.btnCopyPath.Text = "Copy path";
            this.btnCopyPath.Click += new System.EventHandler(this.btnCopyPath_Click);
            // 
            // txt_probability
            // 
            this.txt_probability.Enabled = false;
            this.txt_probability.Location = new System.Drawing.Point(142, 47);
            this.txt_probability.Name = "txt_probability";
            this.txt_probability.Size = new System.Drawing.Size(61, 20);
            this.txt_probability.TabIndex = 8;
            this.txt_probability.Text = "0";
            this.txt_probability.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtScale_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Probability";
            // 
            // bgLoadFile
            // 
            this.bgLoadFile.WorkerSupportsCancellation = true;
            this.bgLoadFile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgLoadFile_DoWork);
            this.bgLoadFile.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgLoadFile_RunWorkerCompleted);
            // 
            // grLeft
            // 
            this.grLeft.Controls.Add(this.listView1);
            this.grLeft.Controls.Add(this.groupBox2);
            this.grLeft.Controls.Add(this.groupBox3);
            this.grLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.grLeft.Location = new System.Drawing.Point(0, 0);
            this.grLeft.Name = "grLeft";
            this.grLeft.Size = new System.Drawing.Size(588, 536);
            this.grLeft.TabIndex = 11;
            this.grLeft.TabStop = false;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.clStatus,
            this.clCount,
            this.clTime});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 380);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(582, 153);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File name";
            this.columnHeader1.Width = 334;
            // 
            // clStatus
            // 
            this.clStatus.Text = "Status";
            this.clStatus.Width = 92;
            // 
            // clCount
            // 
            this.clCount.Text = "Count";
            // 
            // clTime
            // 
            this.clTime.Text = "Elapsed (ms)";
            this.clTime.Width = 74;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTotal);
            this.groupBox2.Controls.Add(this.lblIndex);
            this.groupBox2.Controls.Add(this.txtMoveFile2);
            this.groupBox2.Controls.Add(this.txtMoveFile1);
            this.groupBox2.Controls.Add(this.chkMoveFileNotDetect);
            this.groupBox2.Controls.Add(this.chkMoveFileDetected);
            this.groupBox2.Controls.Add(this.txt_probability);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.chkDefault);
            this.groupBox2.Controls.Add(this.btnExport);
            this.groupBox2.Controls.Add(this.btnAnalytics);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 180);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(582, 200);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parameter";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(12, 173);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotal.Size = new System.Drawing.Size(34, 13);
            this.lblTotal.TabIndex = 20;
            this.lblTotal.Text = "Total:";
            // 
            // lblIndex
            // 
            this.lblIndex.AutoSize = true;
            this.lblIndex.Location = new System.Drawing.Point(470, 173);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblIndex.Size = new System.Drawing.Size(0, 13);
            this.lblIndex.TabIndex = 19;
            // 
            // txtMoveFile2
            // 
            this.txtMoveFile2.Enabled = false;
            this.txtMoveFile2.Location = new System.Drawing.Point(166, 107);
            this.txtMoveFile2.Name = "txtMoveFile2";
            this.txtMoveFile2.Size = new System.Drawing.Size(308, 20);
            this.txtMoveFile2.TabIndex = 18;
            // 
            // txtMoveFile1
            // 
            this.txtMoveFile1.Enabled = false;
            this.txtMoveFile1.Location = new System.Drawing.Point(166, 82);
            this.txtMoveFile1.Name = "txtMoveFile1";
            this.txtMoveFile1.Size = new System.Drawing.Size(308, 20);
            this.txtMoveFile1.TabIndex = 17;
            // 
            // chkMoveFileNotDetect
            // 
            this.chkMoveFileNotDetect.AutoSize = true;
            this.chkMoveFileNotDetect.Location = new System.Drawing.Point(12, 110);
            this.chkMoveFileNotDetect.Name = "chkMoveFileNotDetect";
            this.chkMoveFileNotDetect.Size = new System.Drawing.Size(153, 17);
            this.chkMoveFileNotDetect.TabIndex = 16;
            this.chkMoveFileNotDetect.Text = "Move file can not detect to";
            this.chkMoveFileNotDetect.UseVisualStyleBackColor = true;
            this.chkMoveFileNotDetect.CheckedChanged += new System.EventHandler(this.chkMoveFileNotDetect_CheckedChanged);
            // 
            // chkMoveFileDetected
            // 
            this.chkMoveFileDetected.AutoSize = true;
            this.chkMoveFileDetected.Location = new System.Drawing.Point(12, 83);
            this.chkMoveFileDetected.Name = "chkMoveFileDetected";
            this.chkMoveFileDetected.Size = new System.Drawing.Size(126, 17);
            this.chkMoveFileDetected.TabIndex = 15;
            this.chkMoveFileDetected.Text = "Move file detected to";
            this.chkMoveFileDetected.UseVisualStyleBackColor = true;
            this.chkMoveFileDetected.CheckedChanged += new System.EventHandler(this.chkMoveFileDetected_CheckedChanged);
            // 
            // chkDefault
            // 
            this.chkDefault.AutoSize = true;
            this.chkDefault.Checked = true;
            this.chkDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDefault.Location = new System.Drawing.Point(12, 41);
            this.chkDefault.Name = "chkDefault";
            this.chkDefault.Size = new System.Drawing.Size(109, 17);
            this.chkDefault.TabIndex = 6;
            this.chkDefault.Text = "Use default value";
            this.chkDefault.UseVisualStyleBackColor = true;
            this.chkDefault.CheckedChanged += new System.EventHandler(this.chkDefault_CheckedChanged);
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(270, 147);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnAnalytics
            // 
            this.btnAnalytics.Enabled = false;
            this.btnAnalytics.Location = new System.Drawing.Point(189, 147);
            this.btnAnalytics.Name = "btnAnalytics";
            this.btnAnalytics.Size = new System.Drawing.Size(75, 23);
            this.btnAnalytics.TabIndex = 3;
            this.btnAnalytics.Text = "Analytics";
            this.btnAnalytics.UseVisualStyleBackColor = true;
            this.btnAnalytics.Click += new System.EventHandler(this.btnAnalytics_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_load);
            this.groupBox3.Controls.Add(this.cb_weight);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.btn_loadWeight);
            this.groupBox3.Controls.Add(this.cb_config);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.btn_loadConfig);
            this.groupBox3.Controls.Add(this.cb_classes);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btnLoadClasses);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnBrowseDir);
            this.groupBox3.Controls.Add(this.txtFolder);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(582, 164);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Input";
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(243, 133);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(75, 23);
            this.btn_load.TabIndex = 21;
            this.btn_load.Text = "Load model";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // cb_weight
            // 
            this.cb_weight.FormattingEnabled = true;
            this.cb_weight.Location = new System.Drawing.Point(131, 106);
            this.cb_weight.Name = "cb_weight";
            this.cb_weight.Size = new System.Drawing.Size(403, 21);
            this.cb_weight.TabIndex = 11;
            this.cb_weight.TextChanged += new System.EventHandler(this.cb_weight_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Weight file";
            // 
            // btn_loadWeight
            // 
            this.btn_loadWeight.Location = new System.Drawing.Point(540, 105);
            this.btn_loadWeight.Name = "btn_loadWeight";
            this.btn_loadWeight.Size = new System.Drawing.Size(27, 23);
            this.btn_loadWeight.TabIndex = 10;
            this.btn_loadWeight.Text = "...";
            this.btn_loadWeight.UseVisualStyleBackColor = true;
            this.btn_loadWeight.Click += new System.EventHandler(this.btn_loadWeight_Click);
            // 
            // cb_config
            // 
            this.cb_config.FormattingEnabled = true;
            this.cb_config.Location = new System.Drawing.Point(131, 79);
            this.cb_config.Name = "cb_config";
            this.cb_config.Size = new System.Drawing.Size(403, 21);
            this.cb_config.TabIndex = 8;
            this.cb_config.TextChanged += new System.EventHandler(this.cb_config_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Config file (*.cfg)";
            // 
            // btn_loadConfig
            // 
            this.btn_loadConfig.Location = new System.Drawing.Point(540, 78);
            this.btn_loadConfig.Name = "btn_loadConfig";
            this.btn_loadConfig.Size = new System.Drawing.Size(27, 23);
            this.btn_loadConfig.TabIndex = 7;
            this.btn_loadConfig.Text = "...";
            this.btn_loadConfig.UseVisualStyleBackColor = true;
            this.btn_loadConfig.Click += new System.EventHandler(this.btn_loadConfig_Click);
            // 
            // cb_classes
            // 
            this.cb_classes.FormattingEnabled = true;
            this.cb_classes.Location = new System.Drawing.Point(131, 52);
            this.cb_classes.Name = "cb_classes";
            this.cb_classes.Size = new System.Drawing.Size(403, 21);
            this.cb_classes.TabIndex = 5;
            this.cb_classes.TextChanged += new System.EventHandler(this.cb_classes_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Names file (classes)";
            // 
            // btnLoadClasses
            // 
            this.btnLoadClasses.Location = new System.Drawing.Point(540, 51);
            this.btnLoadClasses.Name = "btnLoadClasses";
            this.btnLoadClasses.Size = new System.Drawing.Size(27, 23);
            this.btnLoadClasses.TabIndex = 4;
            this.btnLoadClasses.Text = "...";
            this.btnLoadClasses.UseVisualStyleBackColor = true;
            this.btnLoadClasses.Click += new System.EventHandler(this.btnLoadClasses_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Folder contain images";
            // 
            // btnBrowseDir
            // 
            this.btnBrowseDir.Location = new System.Drawing.Point(540, 21);
            this.btnBrowseDir.Name = "btnBrowseDir";
            this.btnBrowseDir.Size = new System.Drawing.Size(27, 23);
            this.btnBrowseDir.TabIndex = 1;
            this.btnBrowseDir.Text = "...";
            this.btnBrowseDir.UseVisualStyleBackColor = true;
            this.btnBrowseDir.Click += new System.EventHandler(this.btnBrowseDir_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(131, 23);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(403, 20);
            this.txtFolder.TabIndex = 0;
            this.txtFolder.TextChanged += new System.EventHandler(this.txtFolder_TextChanged);
            // 
            // bgAnalytics
            // 
            this.bgAnalytics.WorkerReportsProgress = true;
            this.bgAnalytics.WorkerSupportsCancellation = true;
            this.bgAnalytics.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgAnalytics_DoWork);
            this.bgAnalytics.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgAnalytics_ProgressChanged);
            this.bgAnalytics.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgAnalytics_RunWorkerCompleted);
            // 
            // contextListview
            // 
            this.contextListview.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCopyPath,
            this.btnOpenImage});
            this.contextListview.Name = "contextListview";
            this.contextListview.Size = new System.Drawing.Size(140, 48);
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(139, 22);
            this.btnOpenImage.Text = "Open image";
            this.btnOpenImage.Click += new System.EventHandler(this.btnOpenImage_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(588, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1, 536);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // progressBar1
            // 
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar1,
            this.lblMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 536);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(589, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // timerClear
            // 
            this.timerClear.Interval = 1000;
            this.timerClear.Tick += new System.EventHandler(this.timerClear_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 558);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.grLeft);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "Darknet Analytics";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.grLeft.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.contextListview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem btnCopyPath;
        private System.Windows.Forms.TextBox txt_probability;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker bgLoadFile;
        private System.Windows.Forms.GroupBox grLeft;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader clStatus;
        private System.Windows.Forms.ColumnHeader clCount;
        private System.Windows.Forms.ColumnHeader clTime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblIndex;
        private System.Windows.Forms.TextBox txtMoveFile2;
        private System.Windows.Forms.TextBox txtMoveFile1;
        private System.Windows.Forms.CheckBox chkMoveFileNotDetect;
        private System.Windows.Forms.CheckBox chkMoveFileDetected;
        private System.Windows.Forms.CheckBox chkDefault;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnAnalytics;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.ComboBox cb_weight;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_loadWeight;
        private System.Windows.Forms.ComboBox cb_config;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_loadConfig;
        private System.Windows.Forms.ComboBox cb_classes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoadClasses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowseDir;
        private System.Windows.Forms.TextBox txtFolder;
        private System.ComponentModel.BackgroundWorker bgAnalytics;
        private System.Windows.Forms.ContextMenuStrip contextListview;
        private System.Windows.Forms.ToolStripMenuItem btnOpenImage;
        private System.Windows.Forms.ToolStripStatusLabel lblMessage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripProgressBar progressBar1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Timer timerClear;
    }
}

