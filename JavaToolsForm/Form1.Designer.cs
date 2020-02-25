﻿namespace JavaToolsForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.tb_author = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rtb_srcCodeSnippet = new System.Windows.Forms.RichTextBox();
            this.rtb_tarCodeSnippet = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_convertSnippet = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cb_skipAutowired = new System.Windows.Forms.CheckBox();
            this.btn_batchGenCtor = new System.Windows.Forms.Button();
            this.btn_selectCtorFolder = new System.Windows.Forms.Button();
            this.tb_ctorFolder = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_genGetAndSet = new System.Windows.Forms.Button();
            this.btn_selectGetSetProjPath = new System.Windows.Forms.Button();
            this.tb_getsetProjPath = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btn_processForceFix = new System.Windows.Forms.Button();
            this.btn_selectForceFixProj = new System.Windows.Forms.Button();
            this.tb_forceFixProj = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPageGetSetProcess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
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
            this.tabPageGetSetProcess.Controls.Add(this.label2);
            this.tabPageGetSetProcess.Controls.Add(this.tb_author);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "@author字段名";
            // 
            // tb_author
            // 
            this.tb_author.Location = new System.Drawing.Point(483, 18);
            this.tb_author.Name = "tb_author";
            this.tb_author.Size = new System.Drawing.Size(100, 21);
            this.tb_author.TabIndex = 10;
            this.tb_author.Text = "曾昭亮/80231356";
            this.tb_author.TextChanged += new System.EventHandler(this.tb_author_TextChanged);
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
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBox2);
            this.tabPage1.Controls.Add(this.cb_skipAutowired);
            this.tabPage1.Controls.Add(this.btn_batchGenCtor);
            this.tabPage1.Controls.Add(this.btn_selectCtorFolder);
            this.tabPage1.Controls.Add(this.tb_ctorFolder);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(591, 545);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "构造方法处理";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cb_skipAutowired
            // 
            this.cb_skipAutowired.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_skipAutowired.AutoSize = true;
            this.cb_skipAutowired.Location = new System.Drawing.Point(475, 208);
            this.cb_skipAutowired.Name = "cb_skipAutowired";
            this.cb_skipAutowired.Size = new System.Drawing.Size(108, 16);
            this.cb_skipAutowired.TabIndex = 12;
            this.cb_skipAutowired.Text = "skip@Autowired";
            this.cb_skipAutowired.UseVisualStyleBackColor = true;
            // 
            // btn_batchGenCtor
            // 
            this.btn_batchGenCtor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_batchGenCtor.Location = new System.Drawing.Point(6, 139);
            this.btn_batchGenCtor.Name = "btn_batchGenCtor";
            this.btn_batchGenCtor.Size = new System.Drawing.Size(577, 54);
            this.btn_batchGenCtor.TabIndex = 11;
            this.btn_batchGenCtor.Text = "批量生成构造方法";
            this.btn_batchGenCtor.UseVisualStyleBackColor = true;
            this.btn_batchGenCtor.Click += new System.EventHandler(this.btn_batchGenCtor_Click);
            // 
            // btn_selectCtorFolder
            // 
            this.btn_selectCtorFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_selectCtorFolder.Location = new System.Drawing.Point(502, 111);
            this.btn_selectCtorFolder.Name = "btn_selectCtorFolder";
            this.btn_selectCtorFolder.Size = new System.Drawing.Size(81, 23);
            this.btn_selectCtorFolder.TabIndex = 10;
            this.btn_selectCtorFolder.Text = "选择文件夹";
            this.btn_selectCtorFolder.UseVisualStyleBackColor = true;
            this.btn_selectCtorFolder.Click += new System.EventHandler(this.btn_selectCtorFolder_Click);
            // 
            // tb_ctorFolder
            // 
            this.tb_ctorFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_ctorFolder.Location = new System.Drawing.Point(8, 111);
            this.tb_ctorFolder.Multiline = true;
            this.tb_ctorFolder.Name = "tb_ctorFolder";
            this.tb_ctorFolder.Size = new System.Drawing.Size(488, 23);
            this.tb_ctorFolder.TabIndex = 9;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_genGetAndSet);
            this.tabPage2.Controls.Add(this.btn_selectGetSetProjPath);
            this.tabPage2.Controls.Add(this.tb_getsetProjPath);
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
            // btn_selectGetSetProjPath
            // 
            this.btn_selectGetSetProjPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_selectGetSetProjPath.Location = new System.Drawing.Point(502, 10);
            this.btn_selectGetSetProjPath.Name = "btn_selectGetSetProjPath";
            this.btn_selectGetSetProjPath.Size = new System.Drawing.Size(81, 23);
            this.btn_selectGetSetProjPath.TabIndex = 7;
            this.btn_selectGetSetProjPath.Text = "选择文件夹";
            this.btn_selectGetSetProjPath.UseVisualStyleBackColor = true;
            this.btn_selectGetSetProjPath.Click += new System.EventHandler(this.btn_selectProjPath_Click);
            // 
            // tb_getsetProjPath
            // 
            this.tb_getsetProjPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_getsetProjPath.Location = new System.Drawing.Point(8, 10);
            this.tb_getsetProjPath.Multiline = true;
            this.tb_getsetProjPath.Name = "tb_getsetProjPath";
            this.tb_getsetProjPath.Size = new System.Drawing.Size(488, 23);
            this.tb_getsetProjPath.TabIndex = 6;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.richTextBox1);
            this.tabPage3.Controls.Add(this.btn_processForceFix);
            this.tabPage3.Controls.Add(this.btn_selectForceFixProj);
            this.tabPage3.Controls.Add(this.tb_forceFixProj);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(591, 545);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "规范强制转换";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btn_processForceFix
            // 
            this.btn_processForceFix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_processForceFix.Location = new System.Drawing.Point(6, 185);
            this.btn_processForceFix.Name = "btn_processForceFix";
            this.btn_processForceFix.Size = new System.Drawing.Size(577, 54);
            this.btn_processForceFix.TabIndex = 11;
            this.btn_processForceFix.Text = "强制规范转换";
            this.btn_processForceFix.UseVisualStyleBackColor = true;
            // 
            // btn_selectForceFixProj
            // 
            this.btn_selectForceFixProj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_selectForceFixProj.Location = new System.Drawing.Point(502, 157);
            this.btn_selectForceFixProj.Name = "btn_selectForceFixProj";
            this.btn_selectForceFixProj.Size = new System.Drawing.Size(81, 23);
            this.btn_selectForceFixProj.TabIndex = 10;
            this.btn_selectForceFixProj.Text = "选择文件夹";
            this.btn_selectForceFixProj.UseVisualStyleBackColor = true;
            this.btn_selectForceFixProj.Click += new System.EventHandler(this.btn_selectForceFixProj_Click);
            // 
            // tb_forceFixProj
            // 
            this.tb_forceFixProj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_forceFixProj.Location = new System.Drawing.Point(8, 157);
            this.tb_forceFixProj.Multiline = true;
            this.tb_forceFixProj.Name = "tb_forceFixProj";
            this.tb_forceFixProj.Size = new System.Drawing.Size(488, 23);
            this.tb_forceFixProj.TabIndex = 9;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(7, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(576, 138);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "1、注释处理：对//xx，以英文符号和;结尾的，视为注释，该行将整行删除\n2、对于@Autowired但是没有private修饰符的，予以提示，并需要记得构造方法" +
    "处理；\n";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox2.Enabled = false;
            this.richTextBox2.Location = new System.Drawing.Point(7, 3);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(576, 102);
            this.richTextBox2.TabIndex = 13;
            this.richTextBox2.Text = "1、目前只对拥有private字段的，且无构造方法的类进行处理";
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
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
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
        private System.Windows.Forms.Button btn_selectGetSetProjPath;
        private System.Windows.Forms.TextBox tb_getsetProjPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_author;
        private System.Windows.Forms.Button btn_batchGenCtor;
        private System.Windows.Forms.Button btn_selectCtorFolder;
        private System.Windows.Forms.TextBox tb_ctorFolder;
        private System.Windows.Forms.CheckBox cb_skipAutowired;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btn_processForceFix;
        private System.Windows.Forms.Button btn_selectForceFixProj;
        private System.Windows.Forms.TextBox tb_forceFixProj;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}

