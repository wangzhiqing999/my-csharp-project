namespace MyWebApiClientBuilder
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSwaggerDocUrl = new System.Windows.Forms.TextBox();
            this.pnlPath = new System.Windows.Forms.Panel();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.txtSourcePath = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCreateMyJavaScriptService = new System.Windows.Forms.Button();
            this.btnReadDoc = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tlpMain.SuspendLayout();
            this.pnlPath.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpMain.Controls.Add(this.label2, 0, 1);
            this.tlpMain.Controls.Add(this.label1, 0, 0);
            this.tlpMain.Controls.Add(this.txtSwaggerDocUrl, 1, 0);
            this.tlpMain.Controls.Add(this.pnlPath, 1, 1);
            this.tlpMain.Controls.Add(this.panel1, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(627, 167);
            this.tlpMain.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 50);
            this.label2.TabIndex = 3;
            this.label2.Text = "代码生成目录";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "swagger 文档地址";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSwaggerDocUrl
            // 
            this.txtSwaggerDocUrl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSwaggerDocUrl.Location = new System.Drawing.Point(191, 14);
            this.txtSwaggerDocUrl.Name = "txtSwaggerDocUrl";
            this.txtSwaggerDocUrl.Size = new System.Drawing.Size(394, 21);
            this.txtSwaggerDocUrl.TabIndex = 1;
            this.txtSwaggerDocUrl.Text = "http://localhost:64426/swagger/docs/v1";
            // 
            // pnlPath
            // 
            this.pnlPath.Controls.Add(this.btnSelectPath);
            this.pnlPath.Controls.Add(this.txtSourcePath);
            this.pnlPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPath.Location = new System.Drawing.Point(191, 53);
            this.pnlPath.Name = "pnlPath";
            this.pnlPath.Size = new System.Drawing.Size(433, 44);
            this.pnlPath.TabIndex = 5;
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(360, 13);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(42, 23);
            this.btnSelectPath.TabIndex = 5;
            this.btnSelectPath.Text = "...";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // txtSourcePath
            // 
            this.txtSourcePath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSourcePath.Location = new System.Drawing.Point(3, 13);
            this.txtSourcePath.Name = "txtSourcePath";
            this.txtSourcePath.Size = new System.Drawing.Size(350, 21);
            this.txtSourcePath.TabIndex = 4;
            // 
            // panel1
            // 
            this.tlpMain.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.btnCreateMyJavaScriptService);
            this.panel1.Controls.Add(this.btnReadDoc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(621, 61);
            this.panel1.TabIndex = 6;
            // 
            // btnCreateMyJavaScriptService
            // 
            this.btnCreateMyJavaScriptService.Enabled = false;
            this.btnCreateMyJavaScriptService.Location = new System.Drawing.Point(205, 18);
            this.btnCreateMyJavaScriptService.Name = "btnCreateMyJavaScriptService";
            this.btnCreateMyJavaScriptService.Size = new System.Drawing.Size(184, 23);
            this.btnCreateMyJavaScriptService.TabIndex = 3;
            this.btnCreateMyJavaScriptService.Text = "生成 MyJavaScriptService";
            this.btnCreateMyJavaScriptService.UseVisualStyleBackColor = true;
            this.btnCreateMyJavaScriptService.Click += new System.EventHandler(this.btnCreateMyJavaScriptService_Click);
            // 
            // btnReadDoc
            // 
            this.btnReadDoc.Location = new System.Drawing.Point(81, 18);
            this.btnReadDoc.Name = "btnReadDoc";
            this.btnReadDoc.Size = new System.Drawing.Size(75, 23);
            this.btnReadDoc.TabIndex = 2;
            this.btnReadDoc.Text = "读取";
            this.btnReadDoc.UseVisualStyleBackColor = true;
            this.btnReadDoc.Click += new System.EventHandler(this.btnReadDoc_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 167);
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WebApi客户端代码生成器";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.pnlPath.ResumeLayout(false);
            this.pnlPath.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSwaggerDocUrl;
        private System.Windows.Forms.Button btnReadDoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSourcePath;
        private System.Windows.Forms.Panel pnlPath;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCreateMyJavaScriptService;
    }
}

