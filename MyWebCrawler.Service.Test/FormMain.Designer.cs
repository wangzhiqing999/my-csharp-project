namespace MyWebCrawler.Service.Test
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readHtmlTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readMultiDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readDetailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cffexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readCffexListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readCffexDetailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readShfeListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readShfeDetailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem,
            this.pToolStripMenuItem,
            this.cffexToolStripMenuItem,
            this.shfeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readHtmlTextToolStripMenuItem,
            this.readMultiDataToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.testToolStripMenuItem.Text = "Test";
            // 
            // readHtmlTextToolStripMenuItem
            // 
            this.readHtmlTextToolStripMenuItem.Name = "readHtmlTextToolStripMenuItem";
            this.readHtmlTextToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.readHtmlTextToolStripMenuItem.Text = "ReadHtmlText";
            this.readHtmlTextToolStripMenuItem.Click += new System.EventHandler(this.readHtmlTextToolStripMenuItem_Click);
            // 
            // readMultiDataToolStripMenuItem
            // 
            this.readMultiDataToolStripMenuItem.Name = "readMultiDataToolStripMenuItem";
            this.readMultiDataToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.readMultiDataToolStripMenuItem.Text = "ReadMultiData";
            this.readMultiDataToolStripMenuItem.Click += new System.EventHandler(this.readMultiDataToolStripMenuItem_Click);
            // 
            // pToolStripMenuItem
            // 
            this.pToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readListToolStripMenuItem,
            this.readDetailToolStripMenuItem});
            this.pToolStripMenuItem.Name = "pToolStripMenuItem";
            this.pToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.pToolStripMenuItem.Text = "平安期货";
            // 
            // readListToolStripMenuItem
            // 
            this.readListToolStripMenuItem.Name = "readListToolStripMenuItem";
            this.readListToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.readListToolStripMenuItem.Text = "公告列表";
            this.readListToolStripMenuItem.Click += new System.EventHandler(this.readListToolStripMenuItem_Click);
            // 
            // readDetailToolStripMenuItem
            // 
            this.readDetailToolStripMenuItem.Name = "readDetailToolStripMenuItem";
            this.readDetailToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.readDetailToolStripMenuItem.Text = "公告明细";
            this.readDetailToolStripMenuItem.Click += new System.EventHandler(this.readDetailToolStripMenuItem_Click);
            // 
            // cffexToolStripMenuItem
            // 
            this.cffexToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readCffexListToolStripMenuItem,
            this.readCffexDetailToolStripMenuItem});
            this.cffexToolStripMenuItem.Name = "cffexToolStripMenuItem";
            this.cffexToolStripMenuItem.Size = new System.Drawing.Size(128, 21);
            this.cffexToolStripMenuItem.Text = "中国金融期货交易所";
            // 
            // readCffexListToolStripMenuItem
            // 
            this.readCffexListToolStripMenuItem.Name = "readCffexListToolStripMenuItem";
            this.readCffexListToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.readCffexListToolStripMenuItem.Text = "公告列表";
            this.readCffexListToolStripMenuItem.Click += new System.EventHandler(this.readCffexListToolStripMenuItem_Click);
            // 
            // readCffexDetailToolStripMenuItem
            // 
            this.readCffexDetailToolStripMenuItem.Name = "readCffexDetailToolStripMenuItem";
            this.readCffexDetailToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.readCffexDetailToolStripMenuItem.Text = "公告明细";
            this.readCffexDetailToolStripMenuItem.Click += new System.EventHandler(this.readCffexDetailToolStripMenuItem_Click);
            // 
            // shfeToolStripMenuItem
            // 
            this.shfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readShfeListToolStripMenuItem,
            this.readShfeDetailToolStripMenuItem});
            this.shfeToolStripMenuItem.Name = "shfeToolStripMenuItem";
            this.shfeToolStripMenuItem.Size = new System.Drawing.Size(104, 21);
            this.shfeToolStripMenuItem.Text = "上海期货交易所";
            // 
            // readShfeListToolStripMenuItem
            // 
            this.readShfeListToolStripMenuItem.Name = "readShfeListToolStripMenuItem";
            this.readShfeListToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.readShfeListToolStripMenuItem.Text = "公告列表";
            this.readShfeListToolStripMenuItem.Click += new System.EventHandler(this.readShfeListToolStripMenuItem_Click);
            // 
            // readShfeDetailToolStripMenuItem
            // 
            this.readShfeDetailToolStripMenuItem.Name = "readShfeDetailToolStripMenuItem";
            this.readShfeDetailToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.readShfeDetailToolStripMenuItem.Text = "公告明细";
            this.readShfeDetailToolStripMenuItem.Click += new System.EventHandler(this.readShfeDetailToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "数据抓取测试";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readHtmlTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readMultiDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readDetailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cffexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readCffexListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readCffexDetailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shfeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readShfeListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readShfeDetailToolStripMenuItem;
    }
}

