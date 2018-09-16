namespace MyLoggerReader
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtLoggerPath = new System.Windows.Forms.TextBox();
            this.btnBrowsePath = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.txtResultFile = new System.Windows.Forms.TextBox();
            this.btnBrowseResultFile = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.btnGetFileCount = new System.Windows.Forms.Button();
            this.lblFileCount = new System.Windows.Forms.Label();
            this.btnReadFile = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "日志文件目录";
            // 
            // txtLoggerPath
            // 
            this.txtLoggerPath.Location = new System.Drawing.Point(117, 10);
            this.txtLoggerPath.Name = "txtLoggerPath";
            this.txtLoggerPath.Size = new System.Drawing.Size(427, 21);
            this.txtLoggerPath.TabIndex = 1;
            // 
            // btnBrowsePath
            // 
            this.btnBrowsePath.Location = new System.Drawing.Point(550, 8);
            this.btnBrowsePath.Name = "btnBrowsePath";
            this.btnBrowsePath.Size = new System.Drawing.Size(45, 23);
            this.btnBrowsePath.TabIndex = 2;
            this.btnBrowsePath.Text = "...";
            this.btnBrowsePath.UseVisualStyleBackColor = true;
            this.btnBrowsePath.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "结果文件";
            // 
            // txtResultFile
            // 
            this.txtResultFile.Location = new System.Drawing.Point(117, 72);
            this.txtResultFile.Name = "txtResultFile";
            this.txtResultFile.Size = new System.Drawing.Size(427, 21);
            this.txtResultFile.TabIndex = 4;
            // 
            // btnBrowseResultFile
            // 
            this.btnBrowseResultFile.Location = new System.Drawing.Point(550, 72);
            this.btnBrowseResultFile.Name = "btnBrowseResultFile";
            this.btnBrowseResultFile.Size = new System.Drawing.Size(45, 23);
            this.btnBrowseResultFile.TabIndex = 5;
            this.btnBrowseResultFile.Text = "...";
            this.btnBrowseResultFile.UseVisualStyleBackColor = true;
            this.btnBrowseResultFile.Click += new System.EventHandler(this.btnBrowseResultFile_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 283);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(607, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // btnGetFileCount
            // 
            this.btnGetFileCount.Location = new System.Drawing.Point(29, 119);
            this.btnGetFileCount.Name = "btnGetFileCount";
            this.btnGetFileCount.Size = new System.Drawing.Size(75, 23);
            this.btnGetFileCount.TabIndex = 7;
            this.btnGetFileCount.Text = "文件数获取";
            this.btnGetFileCount.UseVisualStyleBackColor = true;
            this.btnGetFileCount.Click += new System.EventHandler(this.btnGetFileCount_Click);
            // 
            // lblFileCount
            // 
            this.lblFileCount.AutoSize = true;
            this.lblFileCount.Location = new System.Drawing.Point(136, 124);
            this.lblFileCount.Name = "lblFileCount";
            this.lblFileCount.Size = new System.Drawing.Size(11, 12);
            this.lblFileCount.TabIndex = 8;
            this.lblFileCount.Text = "0";
            // 
            // btnReadFile
            // 
            this.btnReadFile.Location = new System.Drawing.Point(271, 119);
            this.btnReadFile.Name = "btnReadFile";
            this.btnReadFile.Size = new System.Drawing.Size(109, 23);
            this.btnReadFile.TabIndex = 9;
            this.btnReadFile.Text = "文件分析处理";
            this.btnReadFile.UseVisualStyleBackColor = true;
            this.btnReadFile.Click += new System.EventHandler(this.btnReadFile_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 305);
            this.Controls.Add(this.btnReadFile);
            this.Controls.Add(this.lblFileCount);
            this.Controls.Add(this.btnGetFileCount);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnBrowseResultFile);
            this.Controls.Add(this.txtResultFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowsePath);
            this.Controls.Add(this.txtLoggerPath);
            this.Controls.Add(this.label1);
            this.Name = "FormMain";
            this.Text = "日志读取处理";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLoggerPath;
        private System.Windows.Forms.Button btnBrowsePath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtResultFile;
        private System.Windows.Forms.Button btnBrowseResultFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Button btnGetFileCount;
        private System.Windows.Forms.Label lblFileCount;
        private System.Windows.Forms.Button btnReadFile;
    }
}

