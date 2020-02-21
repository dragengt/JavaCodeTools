using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JavaWebTools
{
    public partial class GetSetToolPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_generateCode_Click(object sender, EventArgs e)
        {
            string srcCode = tb_srcCode.Text;
            if(String.IsNullOrEmpty(srcCode))
            {
                return;
            }
            tb_tarCode.Text = JavaToolsBiz.Util.JavaGetSetterGenerator.ConvertCodeWithGetSetter(srcCode);
        }
    }
}