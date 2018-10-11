namespace MyJob.Service.Test
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
            this.jobProcessServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsCmdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sqlQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sqlUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jobProcessServiceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // jobProcessServiceToolStripMenuItem
            // 
            this.jobProcessServiceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowsCmdToolStripMenuItem,
            this.sqlQueryToolStripMenuItem,
            this.sqlUpdateToolStripMenuItem});
            this.jobProcessServiceToolStripMenuItem.Name = "jobProcessServiceToolStripMenuItem";
            this.jobProcessServiceToolStripMenuItem.Size = new System.Drawing.Size(127, 21);
            this.jobProcessServiceToolStripMenuItem.Text = "JobProcessService";
            // 
            // windowsCmdToolStripMenuItem
            // 
            this.windowsCmdToolStripMenuItem.Name = "windowsCmdToolStripMenuItem";
            this.windowsCmdToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.windowsCmdToolStripMenuItem.Text = "WindowsCmd";
            this.windowsCmdToolStripMenuItem.Click += new System.EventHandler(this.windowsCmdToolStripMenuItem_Click);
            // 
            // sqlQueryToolStripMenuItem
            // 
            this.sqlQueryToolStripMenuItem.Name = "sqlQueryToolStripMenuItem";
            this.sqlQueryToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.sqlQueryToolStripMenuItem.Text = "SqlQuery";
            this.sqlQueryToolStripMenuItem.Click += new System.EventHandler(this.sqlQueryToolStripMenuItem_Click);
            // 
            // sqlUpdateToolStripMenuItem
            // 
            this.sqlUpdateToolStripMenuItem.Name = "sqlUpdateToolStripMenuItem";
            this.sqlUpdateToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.sqlUpdateToolStripMenuItem.Text = "SqlUpdate";
            this.sqlUpdateToolStripMenuItem.Click += new System.EventHandler(this.sqlUpdateToolStripMenuItem_Click);
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
            this.Text = "MyJob.Service.Test";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem jobProcessServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsCmdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sqlQueryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sqlUpdateToolStripMenuItem;
    }
}

