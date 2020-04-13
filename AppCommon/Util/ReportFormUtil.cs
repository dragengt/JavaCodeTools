using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppCommon.Util
{
    public class ReportFormUtil
    {
        private static ReportForm processReportForm;
        public static void ShowReport(string reportText)
        {
            if (processReportForm == null || processReportForm.Disposing || processReportForm.IsDisposed)
            {
                processReportForm = new ReportForm();
                processReportForm.Show();
            }

            processReportForm.SetReportText(reportText);
            processReportForm.Activate();
        }
    }
}
