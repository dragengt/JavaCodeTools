using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCommon.Util
{
    public static class UIUtil
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void AddRow(this ListView.ListViewItemCollection srcControl,params string[] colums)
        {
            ListViewItem fileItem = new ListViewItem(colums, 0);
            srcControl.Add(fileItem);
        }

        /// <summary>
        /// 安全地调用，出错则提示为messageBox
        /// </summary>
        /// <param name="action"></param>
        /// <param name="errorMsgPrefix">错误消息的前缀</param>
        public static void TryAction(System.Action action, string errorMsgPrefix = "抱歉，出错啦：")
        {
            try
            {
                action();
            }
            catch(Exception ex)
            {
                MessageBox.Show( errorMsgPrefix + ex.Message+" \n具体错误已经记录到日志。", "出错啦~", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _log.Error(ex.ToString());

                Console.WriteLine(ex.ToString());
            }
        }
    }
}
