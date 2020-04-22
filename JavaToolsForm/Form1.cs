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
            tbInvisible = tab_springFileCreate.TabPages[2];
            tab_springFileCreate.TabPages.RemoveAt(2);
            tb_author.KeyDown += Form1_KeyDown;

            //Config 监听以下控件变动
            ConfigUtil.ListenControl(tb_getsetProjPath);            //批量生成get/set的目录
            ConfigUtil.ListenControl(tb_author);                            //作者字段
            ConfigUtil.ListenControl(tb_ctorFolder);                    //用于批量处理构造方法目录
            ConfigUtil.ListenControl(tb_forceFixProj);               // 
            ConfigUtil.ListenControl(tb_unitTestAuthor);         //单元测试的注释作者字段
            ConfigUtil.ListenControl(cb_alwaysTopWindow);  //是否总在最前
            ConfigUtil.ListenControl(tb_springFileAuthor);

            this.FormClosing += (se, eArg) => AppCommon.Util.ConfigUtil.SaveConfig();

            //支持文件拖拽到文本框：
            tb_springFileToProc.DragEnter += Tb_springFileToProc_DragEnter;
            tb_springFileToProc.DragDrop += Tb_springFileToProc_DragDrop;
             
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.C && tb_author.Text == "曾昭亮/80231356")
            {
                tab_springFileCreate.TabPages.Add(tbInvisible);
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
            UIUtil.TryAction(() =>
            {
                List<string> processedList, unableList;
                JavaGetSetterGenerator.ProcessFolder(scanPath, out processedList, out unableList);

                ShowReport(processedList, unableList);
            });
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

            UIUtil.TryAction(() =>
            {
                JavaConstructorFixer.SetSkipAutowired(cb_skipAutowired.Checked);
                JavaConstructorFixer.ProcessFolder(scanPath, out processedList, out unableList);

                ShowReport(processedList, unableList);
            });
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
            UIUtil.TryAction(() =>
            {
                List<string> processedList, unableList;
                JavaCodeForceFixer.ProcessFolder(scanPath, out processedList, out unableList);

                ShowReport(processedList, unableList);
            });
        }

        //转换get/set 代码段
        private void btn_convertSnippet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtb_srcCodeSnippet.Text))
            {
                MessageBox.Show("没啥代码可转换的。");
                return;
            }
            UIUtil.TryAction(() =>
            {
                rtb_tarCodeSnippet.Text = JavaGetSetterGenerator.ConvertCodeWithGetSetter(rtb_srcCodeSnippet.Text, cb_genSwaggerComment.Checked);
            });
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
            UIUtil.TryAction(() =>
            {
                rtb_j2cTar.Text = JavaCode2CSharpGenerator.ConvertJava2CSharp(src);
            });
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
            UIUtil.TryAction(() =>
            {
                rtb_unitTestTarCode.Text = JavaUnitTestGenerator.ProcessCode(src).ToString();
            });
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

        /// <summary>
        /// 文件拖拽-结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_springFileToProc_DragDrop(object sender, DragEventArgs e)
        {
            var datas = (System.Array)e.Data.GetData(DataFormats.FileDrop);
            foreach (var data in datas)
            {
                tb_springFileToProc.AppendText(data.ToString());
                tb_springFileToProc.AppendText("\n");
            }

            //重新分析当前选中的文件类型，并推断需要生成的文件：
            List<string> fileList;
            string errorMsg;
            var type = AnalyzeType(out fileList, out errorMsg);
            if (type == JavaSpringBootFileCreator.SBFileType.NULL || errorMsg.Length > 0)
            {
                MessageBox.Show(errorMsg);
                return;
            }

            switch (type)
            {
                case JavaSpringBootFileCreator.SBFileType.Controller:
                    ShowCheckBox(false, cb_createSpringController, cb_createSpringMapperResource);
                    CheckCheckBox(false, cb_createSpringController, cb_createSpringMapperResource);

                    ShowCheckBox(true, cb_createSpringService, cb_createSpringMapper);
                    CheckCheckBox(true, cb_createSpringService, cb_createSpringMapper);
                    break;

                case JavaSpringBootFileCreator.SBFileType.Service:
                    ShowCheckBox(false, cb_createSpringService, cb_createSpringMapperResource);
                    CheckCheckBox(false, cb_createSpringService, cb_createSpringMapperResource);

                    ShowCheckBox(true, cb_createSpringController, cb_createSpringMapper);
                    CheckCheckBox(true, cb_createSpringController, cb_createSpringMapper);
                    break;

                case JavaSpringBootFileCreator.SBFileType.Mapper:
                    ShowCheckBox(false, cb_createSpringMapper, cb_createSpringMapperResource);
                    CheckCheckBox(false, cb_createSpringMapper, cb_createSpringMapperResource);

                    ShowCheckBox(true, cb_createSpringController, cb_createSpringService);
                    CheckCheckBox(true, cb_createSpringController, cb_createSpringService);
                    break;
            }
        }

        private void ShowCheckBox(bool isOn, params CheckBox[] cbs)
        {
            foreach (var cb in cbs)
            {
                cb.Visible = isOn;
            }
        }
        private void CheckCheckBox(bool isOn, params CheckBox[] cbs)
        {
            foreach (var cb in cbs)
            {
                cb.Checked = isOn;
            }
        }

        /// <summary>
        /// 文件拖拽-进入TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_springFileToProc_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Cb_ToggleCombox()
        {
            //注释预设

            //范例：
            //F:\java\workspace\LU14_RiskView_Svc\LU14_RiskView_Svc\src\main\java\com\cmb\cvm\biznotify\mapper\health\HealthMapper.java
            UIUtil.TryAction(() =>
            {

            });
        }


        private void tb_createSpringBootFile_Click(object sender, EventArgs e)
        {

            //Mapper->生成Resource对应Mapper
            //Controller->生成Service层、Mapper层、
            //Service->生成Mapper层
            //有mapper层或Controller勾选mapper生成->生成ResourceMapper文件
            UIUtil.TryAction(() =>
            {
                //设定作者名称
                JavaSpringBootFileCreator.g_javaAuthorName = tb_springFileAuthor.Text;

                List<string> fileNamesTrimed;
                StringBuilder sbSucMsg = new StringBuilder();
                string errorMsg;

                var type = AnalyzeType(out fileNamesTrimed, out errorMsg);
                if (type == JavaSpringBootFileCreator.SBFileType.NULL || errorMsg.Length > 0)
                {
                    MessageBox.Show(errorMsg.ToString());
                    return;
                }
                else
                {
                    var subFileTypes = GetCreateSpringSubTypes(); //获得勾选了哪些需要生成的内容
                    foreach (var file in fileNamesTrimed)
                    {
                        foreach (var tarFileType in subFileTypes)
                        {
                            if (JavaSpringBootFileCreator.CreateFileFor(file, type, tarFileType))
                            {
                                sbSucMsg.AppendLine(file + "处理完成：" + tarFileType);
                            }
                        }

                    }

                    ReportFormUtil.ShowReport(sbSucMsg.ToString());
                }
            });
        }

        private JavaSpringBootFileCreator.SBFileType AnalyzeType(out List<string> fileNamesTrimed, out string errorMsg)
        {
            var fileNames = tb_springFileToProc.Text.Split('\n');
            //去掉空行内容：
            fileNamesTrimed = CommonUtil.TrimEmptyLines(fileNames);

            var type = JavaSpringBootFileCreator.AnalyzeFiles(fileNamesTrimed, out errorMsg);
            return type;
        }

        /// <summary>
        /// 获得勾选的生成文件类型内容
        /// </summary>
        /// <returns></returns>
        private List<JavaSpringBootFileCreator.SBFileType> GetCreateSpringSubTypes()
        {
            List<JavaSpringBootFileCreator.SBFileType> subTypes = new List<JavaSpringBootFileCreator.SBFileType>();
            if (cb_createSpringController.Checked)
            {
                subTypes.Add(JavaSpringBootFileCreator.SBFileType.Controller);
            }
            if (cb_createSpringService.Checked)
            {
                subTypes.Add(JavaSpringBootFileCreator.SBFileType.Service);
            }
            if (cb_createSpringMapper.Checked)
            {
                subTypes.Add(JavaSpringBootFileCreator.SBFileType.Mapper);
            }
            if (cb_createSpringMapperResource.Checked)
            {
                subTypes.Add(JavaSpringBootFileCreator.SBFileType.ResourceMapper);
            }

            return subTypes; 
        } 

        private void cb_alwaysTopWindow_CheckedChanged(object sender, EventArgs e)
        {
            //是否窗体最前设置：
            RefreshWindowTopLevel();
        }

        private void RefreshWindowTopLevel()
        {
            this.TopMost = cb_alwaysTopWindow.Checked;
        }
    }
}
