﻿namespace MyWebCrawler.Service.Test.UI
{
    partial class FormReadPinganList
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtPropertyName = new System.Windows.Forms.TextBox();
            this.txtReg = new System.Windows.Forms.TextBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtHtml = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.txtResult, 0, 4);
            this.tlpMain.Controls.Add(this.txtPropertyName, 0, 3);
            this.tlpMain.Controls.Add(this.txtReg, 0, 2);
            this.tlpMain.Controls.Add(this.txtUrl, 0, 0);
            this.tlpMain.Controls.Add(this.btnGo, 1, 0);
            this.tlpMain.Controls.Add(this.txtHtml, 0, 1);
            this.tlpMain.Controls.Add(this.btnProcess, 1, 3);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 5;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Size = new System.Drawing.Size(935, 480);
            this.tlpMain.TabIndex = 1;
            // 
            // txtResult
            // 
            this.tlpMain.SetColumnSpan(this.txtResult, 2);
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Location = new System.Drawing.Point(3, 288);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(929, 189);
            this.txtResult.TabIndex = 7;
            // 
            // txtPropertyName
            // 
            this.txtPropertyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPropertyName.Location = new System.Drawing.Point(3, 258);
            this.txtPropertyName.Name = "txtPropertyName";
            this.txtPropertyName.Size = new System.Drawing.Size(461, 21);
            this.txtPropertyName.TabIndex = 5;
            this.txtPropertyName.Text = "Date,Title,Url";
            // 
            // txtReg
            // 
            this.tlpMain.SetColumnSpan(this.txtReg, 2);
            this.txtReg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReg.Location = new System.Drawing.Point(3, 228);
            this.txtReg.Name = "txtReg";
            this.txtReg.Size = new System.Drawing.Size(929, 21);
            this.txtReg.TabIndex = 4;
            this.txtReg.Text = "<li>[\\w\\W]+?<span>([\\w\\W]+?)</span>[\\w\\W]+?<a title=\"([\\w\\W]+?)\" href=\"([\\w\\W]+?)" +
    "\" [\\w\\W]+?</li>";
            // 
            // txtUrl
            // 
            this.txtUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUrl.Location = new System.Drawing.Point(3, 3);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(461, 21);
            this.txtUrl.TabIndex = 0;
            this.txtUrl.Text = "http://futures.pingan.com/pinganqihuogonggao/pinganqihuogonggaoTab.shtml";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(470, 3);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtHtml
            // 
            this.tlpMain.SetColumnSpan(this.txtHtml, 2);
            this.txtHtml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHtml.Location = new System.Drawing.Point(3, 33);
            this.txtHtml.Multiline = true;
            this.txtHtml.Name = "txtHtml";
            this.txtHtml.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtHtml.Size = new System.Drawing.Size(929, 189);
            this.txtHtml.TabIndex = 2;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(470, 258);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 6;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // FormReadPinganList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 480);
            this.Controls.Add(this.tlpMain);
            this.Name = "FormReadPinganList";
            this.Text = "FormReadPinanList";
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtHtml;
        protected System.Windows.Forms.TextBox txtReg;
        protected System.Windows.Forms.TextBox txtPropertyName;
        protected System.Windows.Forms.Button btnProcess;
        protected System.Windows.Forms.TextBox txtResult;
    }
}