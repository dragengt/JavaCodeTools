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
using System.Text.RegularExpressions;

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
            ConfigUtil.ListenControl(tb_unitTestAuthor);

            this.FormClosing += (se,eArg) =>  AppCommon.Util.ConfigUtil.SaveConfig(); 
            

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Alt && e.KeyCode== Keys.C&&tb_author.Text=="曾昭亮/80231356")
            {
                tabControl1.TabPages.Add(tbInvisible);
            }
        }

        //生成get/set方法
        private void btn_genGetAndSet_Click(object sender, EventArgs e)
        {
            var scanPath = tb_getsetProjPath.Text;
            if (string.IsNullOrEmpty(scanPath))
            {
                MessageBox.Show("本地路径为空");
                return;
            }
            
            List<string> processedList, unableList;
            JavaGetSetterGenerator.ProcessFolder(scanPath, out processedList,out unableList);

            ShowReport(processedList, unableList);
        }


        //生成构造方法
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
            JavaConstructorFixer.ProcessFolder(scanPath, out processedList, out unableList);

            ShowReport(processedList, unableList);
        }

        //强制转换规范
        private void btn_processForceFix_Click(object sender, EventArgs e)
        { 
            var scanPath = tb_forceFixProj.Text;
            if (string.IsNullOrEmpty(scanPath))
            {
                MessageBox.Show("本地路径为空");
                return;
            }
            
            List<string> processedList, unableList;
            JavaCodeForceFixer.ProcessFolder(scanPath, out processedList,out unableList);

            ShowReport(processedList, unableList);
        }
       
        //转换get/set 代码段
        private void btn_convertSnippet_Click(object sender, EventArgs e)
        {
            if( string.IsNullOrEmpty(rtb_srcCodeSnippet.Text))
            {
                MessageBox.Show("没啥代码可转换的。");
                return;
            }

            rtb_tarCodeSnippet.Text = JavaGetSetterGenerator.ConvertCodeWithGetSetter(rtb_srcCodeSnippet.Text);
        }

        //Java代码转C#处理
        private void btn_j2cConvert_Click(object sender, EventArgs e)
        {
            string src = rtb_j2cSrc.Text;
            if (string.IsNullOrEmpty(src.Trim()))
            {
                MessageBox.Show("没啥代码可转换的。");
                return;
            }

            rtb_j2cTar.Text = JavaCode2CSharpGenerator.ConvertJava2CSharp(src);
        }

        //Java单元测试代码生成
        private void rtb_unitTestGen_Click(object sender, EventArgs e)
        {

            string src = rtb_unitTestSrcCode.Text;
            if (string.IsNullOrEmpty(src.Trim()))
            {
                MessageBox.Show("没啥代码可转换的。");
                return;
            }
            JavaUnitTestGenerator.g_authorInfo = tb_unitTestAuthor.Text;
            rtb_unitTestTarCode.Text = JavaUnitTestGenerator.ProcessCode(src).ToString();
        }

        //临时：
        private void btn_j2cGenCodeFile_Click(object sender, EventArgs e)
        {
            var wantedFiles = rtb_j2cSrc.Text.Split('\n');
            AppCommon.Util.CommonUtil.ScanFiles("D:/安全桌面专用目录/Document文档/客户评级（201806）/201912人行征信对接预研/entity", (filename) =>
            {
             
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
                    if (wantedFiles.Contains(fileNameWithoutExtension))
                    {
                        File.Copy(filename, "D:/安全桌面专用目录/Document文档/客户评级（201806）/201912人行征信对接预研/entity/picked/" + fileNameWithoutExtension + ".java");
                        return true;
                    }
                    return false;

             
            });

        }

        private void tb_author_TextChanged(object sender, EventArgs e)
        {
            JavaGetSetterGenerator.g_author = tb_author.Text;
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

        private void GenFileTemp()
        {

            string src = rtb_j2cSrc.Text;
            if (string.IsNullOrEmpty(src.Trim()))
            {
                MessageBox.Show("没啥代码可转换的。");
                return;
            }

            string afterFile = JavaCode2CSharpGenerator.ConvertJava2CSharp(src);
            string className = Regex.Match(afterFile, @"class (\w+)").Groups[1].Value;
            afterFile = Regex.Replace(afterFile, @"^", "	", RegexOptions.Multiline);//对类加个缩进
            //afterFile = Regex.Replace(afterFile, @"	", "    ", RegexOptions.Multiline);//缩进换空格
            string fileContent = string.Format(@"
using Newtonsoft.Json; 

namespace CMBChina.CustomerRating.RatingCommonService.Model.RHZXV2
{{
{0}
}}", afterFile);
            File.WriteAllText("F:/RTC/RatingPure/LU18_Rating/LU18_批发客户评级系统/Rating/DotNetSln/RatingCommonService/RatingCommonService/Model/RHZXV2/" + className + ".cs", fileContent);
            rtb_j2cTar.Text = fileContent;
        }

        //显示处理结果
        private void ShowReport(List<string> processedList, List<string> unableList)
        {
            StringBuilder sb = new StringBuilder();
            processedList.ForEach((file) => sb.AppendLine(file));
            sb.AppendLine("----------------------------------------");
            sb.AppendLine("\n\nunable processed:");
            unableList.ForEach((file) => sb.AppendLine(file));

            ShowReport(sb);
        }

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

    }
}
