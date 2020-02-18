﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JavaTools
{
    public partial class Form1 : Form
    {
        private static ProcessReportForm processReportForm;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            AppCommon.Util.ConfigUtil.ListenControl(tb_localProjPath);

            this.FormClosing += (se,eArg) =>  AppCommon.Util.ConfigUtil.SaveConfig(); 
        }

        private void btn_selectProjPath_Click(object sender, EventArgs e)
        {
            //new FolderBrowserDialog().ShowDialog();
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
                tb_localProjPath.Text = selectedPath;
            }
        }

        private void btn_genGetAndSet_Click(object sender, EventArgs e)
        {
            var scanPath = tb_localProjPath.Text;
            if (string.IsNullOrEmpty(scanPath))
            {
                MessageBox.Show("本地路径为空");
                return;
            }
            List<string> processedList, unableList;
            Util.JavaGetSetterGenerator.ProcessFolder(tb_localProjPath.Text,out processedList,out unableList);

            StringBuilder sb = new StringBuilder();
            processedList.ForEach((file) => sb.AppendLine(file));
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

    }
}
