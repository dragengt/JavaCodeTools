namespace JavaTools
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageGetSetProcess = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rtb_srcCodeSnippet = new System.Windows.Forms.RichTextBox();
            this.rtb_tarCodeSnippet = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_convertSnippet = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_genGetAndSet = new System.Windows.Forms.Button();
            this.btn_selectProjPath = new System.Windows.Forms.Button();
            this.tb_localProjPath = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPageGetSetProcess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageGetSetProcess);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(599, 571);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageGetSetProcess
            // 
            this.tabPageGetSetProcess.Controls.Add(this.splitContainer1);
            this.tabPageGetSetProcess.Controls.Add(this.label1);
            this.tabPageGetSetProcess.Controls.Add(this.btn_convertSnippet);
            this.tabPageGetSetProcess.Location = new System.Drawing.Point(4, 22);
            this.tabPageGetSetProcess.Name = "tabPageGetSetProcess";
            this.tabPageGetSetProcess.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGetSetProcess.Size = new System.Drawing.Size(591, 545);
            this.tabPageGetSetProcess.TabIndex = 0;
            this.tabPageGetSetProcess.Text = "Getter/Setter处理";
            this.tabPageGetSetProcess.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(8, 45);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rtb_srcCodeSnippet);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtb_tarCodeSnippet);
            this.splitContainer1.Size = new System.Drawing.Size(575, 456);
            this.splitContainer1.SplitterDistance = 287;
            this.splitContainer1.TabIndex = 9;
            // 
            // rtb_srcCodeSnippet
            // 
            this.rtb_srcCodeSnippet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_srcCodeSnippet.Location = new System.Drawing.Point(0, 0);
            this.rtb_srcCodeSnippet.Name = "rtb_srcCodeSnippet";
            this.rtb_srcCodeSnippet.Size = new System.Drawing.Size(287, 456);
            this.rtb_srcCodeSnippet.TabIndex = 6;
            this.rtb_srcCodeSnippet.Text = "";
            // 
            // rtb_tarCodeSnippet
            // 
            this.rtb_tarCodeSnippet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_tarCodeSnippet.Location = new System.Drawing.Point(0, 0);
            this.rtb_tarCodeSnippet.Name = "rtb_tarCodeSnippet";
            this.rtb_tarCodeSnippet.Size = new System.Drawing.Size(284, 456);
            this.rtb_tarCodeSnippet.TabIndex = 6;
            this.rtb_tarCodeSnippet.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "代码片段处理";
            // 
            // btn_convertSnippet
            // 
            this.btn_convertSnippet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_convertSnippet.Location = new System.Drawing.Point(8, 507);
            this.btn_convertSnippet.Name = "btn_convertSnippet";
            this.btn_convertSnippet.Size = new System.Drawing.Size(575, 35);
            this.btn_convertSnippet.TabIndex = 7;
            this.btn_convertSnippet.Text = "转换代码片段=>";
            this.btn_convertSnippet.UseVisualStyleBackColor = true;
            this.btn_convertSnippet.Click += new System.EventHandler(this.btn_convertSnippet_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_genGetAndSet);
            this.tabPage2.Controls.Add(this.btn_selectProjPath);
            this.tabPage2.Controls.Add(this.tb_localProjPath);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(591, 545);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "预留";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_genGetAndSet
            // 
            this.btn_genGetAndSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_genGetAndSet.Location = new System.Drawing.Point(6, 38);
            this.btn_genGetAndSet.Name = "btn_genGetAndSet";
            this.btn_genGetAndSet.Size = new System.Drawing.Size(577, 54);
            this.btn_genGetAndSet.TabIndex = 8;
            this.btn_genGetAndSet.Text = "批量扫描文件生成getter/setter";
            this.btn_genGetAndSet.UseVisualStyleBackColor = true;
            this.btn_genGetAndSet.Click += new System.EventHandler(this.btn_genGetAndSet_Click);
            // 
            // btn_selectProjPath
            // 
            this.btn_selectProjPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_selectProjPath.Location = new System.Drawing.Point(502, 10);
            this.btn_selectProjPath.Name = "btn_selectProjPath";
            this.btn_selectProjPath.Size = new System.Drawing.Size(81, 23);
            this.btn_selectProjPath.TabIndex = 7;
            this.btn_selectProjPath.Text = "选择文件夹";
            this.btn_selectProjPath.UseVisualStyleBackColor = true;
            this.btn_selectProjPath.Click += new System.EventHandler(this.btn_selectProjPath_Click);
            // 
            // tb_localProjPath
            // 
            this.tb_localProjPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_localProjPath.Location = new System.Drawing.Point(8, 10);
            this.tb_localProjPath.Multiline = true;
            this.tb_localProjPath.Name = "tb_localProjPath";
            this.tb_localProjPath.Size = new System.Drawing.Size(488, 23);
            this.tb_localProjPath.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(591, 545);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "预留";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(591, 545);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "预留";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 571);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageGetSetProcess.ResumeLayout(false);
            this.tabPageGetSetProcess.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageGetSetProcess;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btn_convertSnippet;
        private System.Windows.Forms.RichTextBox rtb_tarCodeSnippet;
        private System.Windows.Forms.RichTextBox rtb_srcCodeSnippet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_genGetAndSet;
        private System.Windows.Forms.Button btn_selectProjPath;
        private System.Windows.Forms.TextBox tb_localProjPath;
    }
}

