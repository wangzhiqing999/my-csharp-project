namespace MyImageReplace
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.btnSetPath = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtOldFileName = new System.Windows.Forms.TextBox();
            this.txtNewFileName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSelectOld = new System.Windows.Forms.Button();
            this.btnSelectNew = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnStartReplace = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "图片路径";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "旧图片";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "新图片";
            // 
            // txtImagePath
            // 
            this.txtImagePath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtImagePath.Location = new System.Drawing.Point(371, 11);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(547, 28);
            this.txtImagePath.TabIndex = 3;
            // 
            // btnSetPath
            // 
            this.btnSetPath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSetPath.Location = new System.Drawing.Point(924, 13);
            this.btnSetPath.Name = "btnSetPath";
            this.btnSetPath.Size = new System.Drawing.Size(75, 23);
            this.btnSetPath.TabIndex = 4;
            this.btnSetPath.Text = "……";
            this.btnSetPath.UseVisualStyleBackColor = true;
            this.btnSetPath.Click += new System.EventHandler(this.btnSetPath_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtOldFileName
            // 
            this.txtOldFileName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtOldFileName.Location = new System.Drawing.Point(371, 61);
            this.txtOldFileName.Name = "txtOldFileName";
            this.txtOldFileName.Size = new System.Drawing.Size(547, 28);
            this.txtOldFileName.TabIndex = 5;
            // 
            // txtNewFileName
            // 
            this.txtNewFileName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNewFileName.Location = new System.Drawing.Point(371, 111);
            this.txtNewFileName.Name = "txtNewFileName";
            this.txtNewFileName.Size = new System.Drawing.Size(547, 28);
            this.txtNewFileName.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Controls.Add(this.btnSearch, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnSelectNew, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSelectOld, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSetPath, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtNewFileName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtOldFileName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtImagePath, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtResult, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnStartReplace, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1002, 712);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // btnSelectOld
            // 
            this.btnSelectOld.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSelectOld.Location = new System.Drawing.Point(924, 63);
            this.btnSelectOld.Name = "btnSelectOld";
            this.btnSelectOld.Size = new System.Drawing.Size(74, 23);
            this.btnSelectOld.TabIndex = 7;
            this.btnSelectOld.Text = "……";
            this.btnSelectOld.UseVisualStyleBackColor = true;
            this.btnSelectOld.Click += new System.EventHandler(this.btnSelectOld_Click);
            // 
            // btnSelectNew
            // 
            this.btnSelectNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSelectNew.Location = new System.Drawing.Point(924, 113);
            this.btnSelectNew.Name = "btnSelectNew";
            this.btnSelectNew.Size = new System.Drawing.Size(74, 23);
            this.btnSelectNew.TabIndex = 8;
            this.btnSelectNew.Text = "……";
            this.btnSelectNew.UseVisualStyleBackColor = true;
            this.btnSelectNew.Click += new System.EventHandler(this.btnSelectNew_Click);
            // 
            // txtResult
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtResult, 3);
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Location = new System.Drawing.Point(3, 203);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(996, 506);
            this.txtResult.TabIndex = 9;
            // 
            // btnStartReplace
            // 
            this.btnStartReplace.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnStartReplace.Location = new System.Drawing.Point(371, 158);
            this.btnStartReplace.Name = "btnStartReplace";
            this.btnStartReplace.Size = new System.Drawing.Size(127, 34);
            this.btnStartReplace.TabIndex = 10;
            this.btnStartReplace.Text = "开始替换";
            this.btnStartReplace.UseVisualStyleBackColor = true;
            this.btnStartReplace.Click += new System.EventHandler(this.btnStartReplace_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSearch.Location = new System.Drawing.Point(3, 158);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(127, 34);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "预处理";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 712);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormMain";
            this.Text = "图片替换";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.Button btnSetPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtOldFileName;
        private System.Windows.Forms.TextBox txtNewFileName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSelectNew;
        private System.Windows.Forms.Button btnSelectOld;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnStartReplace;
        private System.Windows.Forms.Button btnSearch;
    }
}

