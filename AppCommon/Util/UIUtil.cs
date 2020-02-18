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
        public static void AddRow(this ListView.ListViewItemCollection srcControl,params string[] colums)
        {
            ListViewItem fileItem = new ListViewItem(colums, 0);
            srcControl.Add(fileItem);
        }
    }
}
