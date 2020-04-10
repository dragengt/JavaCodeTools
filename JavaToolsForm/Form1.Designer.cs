namespace JavaToolsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tab_springFileCreate = new System.Windows.Forms.TabControl();
            this.tp_GetSetProcess = new System.Windows.Forms.TabPage();
            this.cb_genSwaggerComment = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_author = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rtb_srcCodeSnippet = new System.Windows.Forms.RichTextBox();
            this.rtb_tarCodeSnippet = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_convertSnippet = new System.Windows.Forms.Button();
            this.tp_getsetBatch = new System.Windows.Forms.TabPage();
            this.btn_genGetAndSet = new System.Windows.Forms.Button();
            this.btn_selectGetSetProjPath = new System.Windows.Forms.Button();
            this.tb_getsetProjPath = new System.Windows.Forms.TextBox();
            this.tp_ctorBatch = new System.Windows.Forms.TabPage();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.cb_skipAutowired = new System.Windows.Forms.CheckBox();
            this.btn_batchGenCtor = new System.Windows.Forms.Button();
            this.btn_selectCtorFolder = new System.Windows.Forms.Button();
            this.tb_ctorFolder = new System.Windows.Forms.TextBox();
            this.tp_codeFixBatch = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btn_processForceFix = new System.Windows.Forms.Button();
            this.btn_selectForceFixProj = new System.Windows.Forms.Button();
            this.tb_forceFixProj = new System.Windows.Forms.TextBox();
            this.tp_java2Cs = new System.Windows.Forms.TabPage();
            this.btn_j2cGenCodeFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_j2cConvert = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.rtb_j2cSrc = new System.Windows.Forms.RichTextBox();
            this.rtb_j2cTar = new System.Windows.Forms.RichTextBox();
            this.tp_unitTestGenerator = new System.Windows.Forms.TabPage();
            this.rtb_unitTestGen = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.rtb_unitTestSrcCode = new System.Windows.Forms.RichTextBox();
            this.rtb_unitTestTarCode = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_unitTestAuthor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tb_springFileToProc = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cb_alwaysTopWindow = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_createSpringBootFile = new System.Windows.Forms.Button();
            this.tab_springFileCreate.SuspendLayout();
            this.tp_GetSetProcess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tp_getsetBatch.SuspendLayout();
            this.tp_ctorBatch.SuspendLayout();
            this.tp_codeFixBatch.SuspendLayout();
            this.tp_java2Cs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tp_unitTestGenerator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_springFileCreate
            // 
            this.tab_springFileCreate.Controls.Add(this.tp_GetSetProcess);
            this.tab_springFileCreate.Controls.Add(this.tp_getsetBatch);
            this.tab_springFileCreate.Controls.Add(this.tp_ctorBatch);
            this.tab_springFileCreate.Controls.Add(this.tp_codeFixBatch);
            this.tab_springFileCreate.Controls.Add(this.tp_java2Cs);
            this.tab_springFileCreate.Controls.Add(this.tp_unitTestGenerator);
            this.tab_springFileCreate.Controls.Add(this.tabPage1);
            this.tab_springFileCreate.Controls.Add(this.tabPage2);
            this.tab_springFileCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_springFileCreate.Location = new System.Drawing.Point(0, 0);
            this.tab_springFileCreate.Name = "tab_springFileCreate";
            this.tab_springFileCreate.SelectedIndex = 0;
            this.tab_springFileCreate.Size = new System.Drawing.Size(599, 571);
            this.tab_springFileCreate.TabIndex = 0;
            // 
            // tp_GetSetProcess
            // 
            this.tp_GetSetProcess.Controls.Add(this.label7);
            this.tp_GetSetProcess.Controls.Add(this.cb_genSwaggerComment);
            this.tp_GetSetProcess.Controls.Add(this.label2);
            this.tp_GetSetProcess.Controls.Add(this.tb_author);
            this.tp_GetSetProcess.Controls.Add(this.splitContainer1);
            this.tp_GetSetProcess.Controls.Add(this.label1);
            this.tp_GetSetProcess.Controls.Add(this.btn_convertSnippet);
            this.tp_GetSetProcess.Location = new System.Drawing.Point(4, 22);
            this.tp_GetSetProcess.Name = "tp_GetSetProcess";
            this.tp_GetSetProcess.Padding = new System.Windows.Forms.Padding(3);
            this.tp_GetSetProcess.Size = new System.Drawing.Size(591, 545);
            this.tp_GetSetProcess.TabIndex = 0;
            this.tp_GetSetProcess.Text = "Getter/Setter处理";
            this.tp_GetSetProcess.UseVisualStyleBackColor = true;
            // 
            // cb_genSwaggerComment
            // 
            this.cb_genSwaggerComment.AutoSize = true;
            this.cb_genSwaggerComment.Location = new System.Drawing.Point(101, 19);
            this.cb_genSwaggerComment.Name = "cb_genSwaggerComment";
            this.cb_genSwaggerComment.Size = new System.Drawing.Size(168, 16);
            this.cb_genSwaggerComment.TabIndex = 12;
            this.cb_genSwaggerComment.Text = "同时生成swagger的API注释";
            this.cb_genSwaggerComment.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "@author字段名";
            // 
            // tb_author
            // 
            this.tb_author.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.splitContainer1.Size = new System.Drawing.Size(575, 390);
            this.splitContainer1.SplitterDistance = 287;
            this.splitContainer1.TabIndex = 9;
            // 
            // rtb_srcCodeSnippet
            // 
            this.rtb_srcCodeSnippet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_srcCodeSnippet.Location = new System.Drawing.Point(0, 0);
            this.rtb_srcCodeSnippet.Name = "rtb_srcCodeSnippet";
            this.rtb_srcCodeSnippet.Size = new System.Drawing.Size(287, 390);
            this.rtb_srcCodeSnippet.TabIndex = 6;
            this.rtb_srcCodeSnippet.Text = "";
            // 
            // rtb_tarCodeSnippet
            // 
            this.rtb_tarCodeSnippet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_tarCodeSnippet.Location = new System.Drawing.Point(0, 0);
            this.rtb_tarCodeSnippet.Name = "rtb_tarCodeSnippet";
            this.rtb_tarCodeSnippet.Size = new System.Drawing.Size(284, 390);
            this.rtb_tarCodeSnippet.TabIndex = 6;
            this.rtb_tarCodeSnippet.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 21);
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
            // tp_getsetBatch
            // 
            this.tp_getsetBatch.Controls.Add(this.btn_genGetAndSet);
            this.tp_getsetBatch.Controls.Add(this.btn_selectGetSetProjPath);
            this.tp_getsetBatch.Controls.Add(this.tb_getsetProjPath);
            this.tp_getsetBatch.Location = new System.Drawing.Point(4, 22);
            this.tp_getsetBatch.Name = "tp_getsetBatch";
            this.tp_getsetBatch.Padding = new System.Windows.Forms.Padding(3);
            this.tp_getsetBatch.Size = new System.Drawing.Size(591, 545);
            this.tp_getsetBatch.TabIndex = 1;
            this.tp_getsetBatch.Text = "getset批量处理";
            this.tp_getsetBatch.UseVisualStyleBackColor = true;
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
            // tp_ctorBatch
            // 
            this.tp_ctorBatch.Controls.Add(this.richTextBox2);
            this.tp_ctorBatch.Controls.Add(this.cb_skipAutowired);
            this.tp_ctorBatch.Controls.Add(this.btn_batchGenCtor);
            this.tp_ctorBatch.Controls.Add(this.btn_selectCtorFolder);
            this.tp_ctorBatch.Controls.Add(this.tb_ctorFolder);
            this.tp_ctorBatch.Location = new System.Drawing.Point(4, 22);
            this.tp_ctorBatch.Name = "tp_ctorBatch";
            this.tp_ctorBatch.Size = new System.Drawing.Size(591, 545);
            this.tp_ctorBatch.TabIndex = 2;
            this.tp_ctorBatch.Text = "构造方法处理";
            this.tp_ctorBatch.UseVisualStyleBackColor = true;
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
            // tp_codeFixBatch
            // 
            this.tp_codeFixBatch.Controls.Add(this.richTextBox1);
            this.tp_codeFixBatch.Controls.Add(this.btn_processForceFix);
            this.tp_codeFixBatch.Controls.Add(this.btn_selectForceFixProj);
            this.tp_codeFixBatch.Controls.Add(this.tb_forceFixProj);
            this.tp_codeFixBatch.Location = new System.Drawing.Point(4, 22);
            this.tp_codeFixBatch.Name = "tp_codeFixBatch";
            this.tp_codeFixBatch.Size = new System.Drawing.Size(591, 545);
            this.tp_codeFixBatch.TabIndex = 3;
            this.tp_codeFixBatch.Text = "规范强制转换";
            this.tp_codeFixBatch.UseVisualStyleBackColor = true;
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
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
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
            this.btn_processForceFix.Click += new System.EventHandler(this.btn_processForceFix_Click);
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
            // tp_java2Cs
            // 
            this.tp_java2Cs.Controls.Add(this.btn_j2cGenCodeFile);
            this.tp_java2Cs.Controls.Add(this.label3);
            this.tp_java2Cs.Controls.Add(this.btn_j2cConvert);
            this.tp_java2Cs.Controls.Add(this.splitContainer2);
            this.tp_java2Cs.Location = new System.Drawing.Point(4, 22);
            this.tp_java2Cs.Name = "tp_java2Cs";
            this.tp_java2Cs.Size = new System.Drawing.Size(591, 545);
            this.tp_java2Cs.TabIndex = 4;
            this.tp_java2Cs.Text = "java2C#";
            this.tp_java2Cs.UseVisualStyleBackColor = true;
            // 
            // btn_j2cGenCodeFile
            // 
            this.btn_j2cGenCodeFile.Location = new System.Drawing.Point(415, 8);
            this.btn_j2cGenCodeFile.Name = "btn_j2cGenCodeFile";
            this.btn_j2cGenCodeFile.Size = new System.Drawing.Size(167, 23);
            this.btn_j2cGenCodeFile.TabIndex = 13;
            this.btn_j2cGenCodeFile.Text = "临时：直接挑选";
            this.btn_j2cGenCodeFile.UseVisualStyleBackColor = true;
            this.btn_j2cGenCodeFile.Click += new System.EventHandler(this.btn_j2cGenCodeFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "仅支持java实体类到C#";
            // 
            // btn_j2cConvert
            // 
            this.btn_j2cConvert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_j2cConvert.Location = new System.Drawing.Point(260, 506);
            this.btn_j2cConvert.Name = "btn_j2cConvert";
            this.btn_j2cConvert.Size = new System.Drawing.Size(72, 35);
            this.btn_j2cConvert.TabIndex = 11;
            this.btn_j2cConvert.Text = "转换代码片段=>";
            this.btn_j2cConvert.UseVisualStyleBackColor = true;
            this.btn_j2cConvert.Click += new System.EventHandler(this.btn_j2cConvert_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(8, 44);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.rtb_j2cSrc);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.rtb_j2cTar);
            this.splitContainer2.Size = new System.Drawing.Size(575, 456);
            this.splitContainer2.SplitterDistance = 287;
            this.splitContainer2.TabIndex = 10;
            // 
            // rtb_j2cSrc
            // 
            this.rtb_j2cSrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_j2cSrc.Location = new System.Drawing.Point(0, 0);
            this.rtb_j2cSrc.Name = "rtb_j2cSrc";
            this.rtb_j2cSrc.Size = new System.Drawing.Size(287, 456);
            this.rtb_j2cSrc.TabIndex = 6;
            this.rtb_j2cSrc.Text = "";
            // 
            // rtb_j2cTar
            // 
            this.rtb_j2cTar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_j2cTar.Location = new System.Drawing.Point(0, 0);
            this.rtb_j2cTar.Name = "rtb_j2cTar";
            this.rtb_j2cTar.Size = new System.Drawing.Size(284, 456);
            this.rtb_j2cTar.TabIndex = 6;
            this.rtb_j2cTar.Text = "";
            // 
            // tp_unitTestGenerator
            // 
            this.tp_unitTestGenerator.Controls.Add(this.rtb_unitTestGen);
            this.tp_unitTestGenerator.Controls.Add(this.splitContainer3);
            this.tp_unitTestGenerator.Controls.Add(this.label4);
            this.tp_unitTestGenerator.Controls.Add(this.tb_unitTestAuthor);
            this.tp_unitTestGenerator.Controls.Add(this.label6);
            this.tp_unitTestGenerator.Controls.Add(this.label5);
            this.tp_unitTestGenerator.Location = new System.Drawing.Point(4, 22);
            this.tp_unitTestGenerator.Name = "tp_unitTestGenerator";
            this.tp_unitTestGenerator.Size = new System.Drawing.Size(591, 545);
            this.tp_unitTestGenerator.TabIndex = 5;
            this.tp_unitTestGenerator.Text = "单元测试方法生成";
            this.tp_unitTestGenerator.UseVisualStyleBackColor = true;
            // 
            // rtb_unitTestGen
            // 
            this.rtb_unitTestGen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_unitTestGen.Location = new System.Drawing.Point(8, 502);
            this.rtb_unitTestGen.Name = "rtb_unitTestGen";
            this.rtb_unitTestGen.Size = new System.Drawing.Size(575, 35);
            this.rtb_unitTestGen.TabIndex = 16;
            this.rtb_unitTestGen.Text = "转换代码片段=>";
            this.rtb_unitTestGen.UseVisualStyleBackColor = true;
            this.rtb_unitTestGen.Click += new System.EventHandler(this.rtb_unitTestGen_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.Location = new System.Drawing.Point(8, 65);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.rtb_unitTestSrcCode);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.rtb_unitTestTarCode);
            this.splitContainer3.Size = new System.Drawing.Size(575, 435);
            this.splitContainer3.SplitterDistance = 287;
            this.splitContainer3.TabIndex = 15;
            // 
            // rtb_unitTestSrcCode
            // 
            this.rtb_unitTestSrcCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_unitTestSrcCode.Location = new System.Drawing.Point(0, 0);
            this.rtb_unitTestSrcCode.Name = "rtb_unitTestSrcCode";
            this.rtb_unitTestSrcCode.Size = new System.Drawing.Size(287, 435);
            this.rtb_unitTestSrcCode.TabIndex = 6;
            this.rtb_unitTestSrcCode.Text = "";
            // 
            // rtb_unitTestTarCode
            // 
            this.rtb_unitTestTarCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_unitTestTarCode.Location = new System.Drawing.Point(0, 0);
            this.rtb_unitTestTarCode.Name = "rtb_unitTestTarCode";
            this.rtb_unitTestTarCode.Size = new System.Drawing.Size(284, 435);
            this.rtb_unitTestTarCode.TabIndex = 6;
            this.rtb_unitTestTarCode.Text = "";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(391, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "@author字段名";
            // 
            // tb_unitTestAuthor
            // 
            this.tb_unitTestAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_unitTestAuthor.Location = new System.Drawing.Point(483, 14);
            this.tb_unitTestAuthor.Name = "tb_unitTestAuthor";
            this.tb_unitTestAuthor.Size = new System.Drawing.Size(100, 21);
            this.tb_unitTestAuthor.TabIndex = 13;
            this.tb_unitTestAuthor.Text = "曾昭亮/80231356";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(413, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "处理完成后，需要手动修复JsonHelpr的import，和测试类所在package信息：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "处理设置：";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tb_createSpringBootFile);
            this.tabPage1.Controls.Add(this.tb_springFileToProc);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(591, 545);
            this.tabPage1.TabIndex = 6;
            this.tabPage1.Text = "文件自动生成";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tb_springFileToProc
            // 
            this.tb_springFileToProc.AllowDrop = true;
            this.tb_springFileToProc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_springFileToProc.Location = new System.Drawing.Point(8, 6);
            this.tb_springFileToProc.Multiline = true;
            this.tb_springFileToProc.Name = "tb_springFileToProc";
            this.tb_springFileToProc.Size = new System.Drawing.Size(575, 292);
            this.tb_springFileToProc.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cb_alwaysTopWindow);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(591, 545);
            this.tabPage2.TabIndex = 7;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cb_alwaysTopWindow
            // 
            this.cb_alwaysTopWindow.AutoSize = true;
            this.cb_alwaysTopWindow.Location = new System.Drawing.Point(29, 21);
            this.cb_alwaysTopWindow.Name = "cb_alwaysTopWindow";
            this.cb_alwaysTopWindow.Size = new System.Drawing.Size(96, 16);
            this.cb_alwaysTopWindow.TabIndex = 0;
            this.cb_alwaysTopWindow.Text = "窗口总在最前";
            this.cb_alwaysTopWindow.UseVisualStyleBackColor = true;
            this.cb_alwaysTopWindow.CheckedChanged += new System.EventHandler(this.cb_alwaysTopWindow_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 449);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(245, 48);
            this.label7.TabIndex = 13;
            this.label7.Text = "用于entity的代码片段处理：左边填写标准的\r\n/**注释*/\r\nprivate XX xxx;\r\n即可转换生成对应的get/set方法+对应注释";
            // 
            // tb_createSpringBootFile
            // 
            this.tb_createSpringBootFile.Location = new System.Drawing.Point(8, 341);
            this.tb_createSpringBootFile.Name = "tb_createSpringBootFile";
            this.tb_createSpringBootFile.Size = new System.Drawing.Size(575, 82);
            this.tb_createSpringBootFile.TabIndex = 1;
            this.tb_createSpringBootFile.Text = "Create";
            this.tb_createSpringBootFile.UseVisualStyleBackColor = true;
            this.tb_createSpringBootFile.Click += new System.EventHandler(this.tb_createSpringBootFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 571);
            this.Controls.Add(this.tab_springFileCreate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tab_springFileCreate.ResumeLayout(false);
            this.tp_GetSetProcess.ResumeLayout(false);
            this.tp_GetSetProcess.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tp_getsetBatch.ResumeLayout(false);
            this.tp_getsetBatch.PerformLayout();
            this.tp_ctorBatch.ResumeLayout(false);
            this.tp_ctorBatch.PerformLayout();
            this.tp_codeFixBatch.ResumeLayout(false);
            this.tp_codeFixBatch.PerformLayout();
            this.tp_java2Cs.ResumeLayout(false);
            this.tp_java2Cs.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tp_unitTestGenerator.ResumeLayout(false);
            this.tp_unitTestGenerator.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_springFileCreate;
        private System.Windows.Forms.TabPage tp_GetSetProcess;
        private System.Windows.Forms.TabPage tp_getsetBatch;
        private System.Windows.Forms.TabPage tp_ctorBatch;
        private System.Windows.Forms.TabPage tp_codeFixBatch;
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
        private System.Windows.Forms.TabPage tp_java2Cs;
        private System.Windows.Forms.Button btn_j2cConvert;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RichTextBox rtb_j2cSrc;
        private System.Windows.Forms.RichTextBox rtb_j2cTar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_j2cGenCodeFile;
        private System.Windows.Forms.TabPage tp_unitTestGenerator;
        private System.Windows.Forms.Button rtb_unitTestGen;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.RichTextBox rtb_unitTestSrcCode;
        private System.Windows.Forms.RichTextBox rtb_unitTestTarCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_unitTestAuthor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cb_genSwaggerComment;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox tb_springFileToProc;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox cb_alwaysTopWindow;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button tb_createSpringBootFile;
    }
}

