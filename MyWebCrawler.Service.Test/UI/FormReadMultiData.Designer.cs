namespace MyWebCrawler.Service.Test.UI
{
    partial class FormReadMultiData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReadMultiData));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnProcess = new System.Windows.Forms.Button();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtReg = new System.Windows.Forms.TextBox();
            this.txtPropertyName = new System.Windows.Forms.TextBox();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.btnProcess, 0, 3);
            this.tlpMain.Controls.Add(this.txtSource, 0, 0);
            this.tlpMain.Controls.Add(this.txtResult, 0, 4);
            this.tlpMain.Controls.Add(this.txtReg, 0, 1);
            this.tlpMain.Controls.Add(this.txtPropertyName, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 5;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Size = new System.Drawing.Size(736, 497);
            this.tlpMain.TabIndex = 0;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(3, 276);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtSource
            // 
            this.txtSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSource.Location = new System.Drawing.Point(3, 3);
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSource.Size = new System.Drawing.Size(730, 167);
            this.txtSource.TabIndex = 1;
            this.txtSource.Text = resources.GetString("txtSource.Text");
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Location = new System.Drawing.Point(3, 326);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(730, 168);
            this.txtResult.TabIndex = 2;
            // 
            // txtReg
            // 
            this.txtReg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReg.Location = new System.Drawing.Point(3, 176);
            this.txtReg.Name = "txtReg";
            this.txtReg.Size = new System.Drawing.Size(730, 21);
            this.txtReg.TabIndex = 3;
            this.txtReg.Text = "<li class=\"body_zb_li\" id=\"([^ ]+)\">[\\w\\W]+?<div class=\"zb_time\"><a>([^/]+)</a></" +
    "div>[\\w\\W]+?<span>([\\w\\W]+?)</span>";
            // 
            // txtPropertyName
            // 
            this.txtPropertyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPropertyName.Location = new System.Drawing.Point(3, 226);
            this.txtPropertyName.Name = "txtPropertyName";
            this.txtPropertyName.Size = new System.Drawing.Size(730, 21);
            this.txtPropertyName.TabIndex = 4;
            this.txtPropertyName.Text = "NewsID,NewsTime,Title";
            // 
            // FormReadMultiData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 497);
            this.Controls.Add(this.tlpMain);
            this.Name = "FormReadMultiData";
            this.Text = "FormReadMultiData";
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        protected System.Windows.Forms.Button btnProcess;
        protected System.Windows.Forms.TextBox txtSource;
        protected System.Windows.Forms.TextBox txtResult;
        protected System.Windows.Forms.TextBox txtReg;
        protected System.Windows.Forms.TextBox txtPropertyName;
    }
}