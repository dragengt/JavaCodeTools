using AppCommon.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JavaToolsBiz.Util;

namespace JavaToolsForm
{
    public partial class Form1 : Form
    {
        private static ProcessReportForm processReportForm;
        public Form1()
        {
            InitializeComponent();
        }
        private TabPage tbInvisible;
        private void Form1_Load(object sender, EventArgs e)
        {
            //暂时不显示批量处理，暂时有问题
            tbInvisible = tabControl1.TabPages[2];
            tabControl1.TabPages.RemoveAt(2);
            tb_author. KeyDown += Form1_KeyDown;
            
            //Config 监听：
            ConfigUtil.ListenControl(tb_getsetProjPath);
            ConfigUtil.ListenControl(tb_author);
            ConfigUtil.ListenControl(tb_ctorFolder);
            ConfigUtil.ListenControl(tb_forceFixProj);

            this.FormClosing += (se,eArg) =>  AppCommon.Util.ConfigUtil.SaveConfig(); 
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Alt && e.KeyCode== Keys.C&&tb_author.Text=="曾昭亮/80231356")
            {
                tabControl1.TabPages.Add(tbInvisible);
            }
        }


        private void btn_genGetAndSet_Click(object sender, EventArgs e)
        {
            var scanPath = tb_getsetProjPath.Text;
            if (string.IsNullOrEmpty(scanPath))
            {
                MessageBox.Show("本地路径为空");
                return;
            }
            List<string> processedList, unableList;
            JavaGetSetterGenerator.ProcessFolder(tb_getsetProjPath.Text,out processedList,out unableList);

            StringBuilder sb = new StringBuilder();
            processedList.ForEach((file) => sb.AppendLine(file));
            sb.AppendLine("----------------------------------------");
            sb.AppendLine("\n\nunable processed:");
            unableList.ForEach((file) => sb.AppendLine(file));

            ShowReport(sb);
        }
         

        //显示处理结果
        private void ShowReport(StringBuilder reportText)
        {
            if (processReportForm == null || processReportForm.Disposing || processReportForm.IsDisposed)
            {
                processReportForm = new ProcessReportForm();
                processReportForm.Show();
            }

            processReportForm.SetReportText(reportText);
            processReportForm.Activate();
        }

        private void btn_convertSnippet_Click(object sender, EventArgs e)
        {
            if( string.IsNullOrEmpty(rtb_srcCodeSnippet.Text))
            {
                MessageBox.Show("没啥代码可转换的。");
                return;
            }

            rtb_tarCodeSnippet.Text = JavaGetSetterGenerator.ConvertCodeWithGetSetter(rtb_srcCodeSnippet.Text);
        }

        private void tb_author_TextChanged(object sender, EventArgs e)
        {
            JavaGetSetterGenerator.g_author = tb_author.Text;
        }

        private void btn_batchGenCtor_Click(object sender, EventArgs e)
        {
            var scanPath = tb_ctorFolder.Text;
            if (string.IsNullOrEmpty(scanPath))
            {
                MessageBox.Show("本地路径为空");
                return;
            }
            List<string> processedList, unableList;
            JavaConstructorFixer.SetSkipAutowired(cb_skipAutowired.Checked);
            JavaConstructorFixer.ProcessFolder(tb_ctorFolder.Text, out processedList, out unableList);

            StringBuilder sb = new StringBuilder();
            processedList.ForEach((file) => sb.AppendLine(file));
            sb.AppendLine("----------------------------------------");
            sb.AppendLine("\n\nunable processed:");
            unableList.ForEach((file) => sb.AppendLine(file));

            ShowReport(sb);
        }

        private void btn_selectCtorFolder_Click(object sender, EventArgs e)
        {
            tb_ctorFolder.Text = SelectFolder();
        }

        private void btn_selectForceFixProj_Click(object sender, EventArgs e)
        {
            tb_forceFixProj.Text = SelectFolder();
        }
         
        private void btn_selectProjPath_Click(object sender, EventArgs e)
        {
            tb_getsetProjPath.Text = SelectFolder();
        }

        private string SelectFolder()
        {
            var dialog = new OpenFileDialog()
            {
                Filter = "any|*",
                CheckPathExists = false,
                ValidateNames = false,
            };
            var pickResult = dialog.ShowDialog();
            if (pickResult == DialogResult.OK)
            {
                //获得选择的文件信息
                var selectedFile = dialog.FileName;
                string selectedFileName = Path.GetFileNameWithoutExtension(selectedFile);
                string selectedPath = Path.GetDirectoryName(selectedFile);


                //--使用选择的项目路径
                return selectedPath;
            }
            return string.Empty;
        }
    }
}
