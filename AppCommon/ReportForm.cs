using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppCommon
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置界面展示的结果内容
        /// </summary>
        /// <param name="text"></param>
        public void SetReportText(String text)
        {
            rtb_reportView.Text = text;
        }
    }
}
