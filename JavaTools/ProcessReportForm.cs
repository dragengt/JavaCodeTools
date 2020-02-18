using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JavaTools
{
    public partial class ProcessReportForm : Form
    {
        public ProcessReportForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置界面展示的结果内容
        /// </summary>
        /// <param name="sb"></param>
        public void SetReportText(StringBuilder sb)
        {
            rtb_reportView.Text = sb.ToString();
        }
    }
}
