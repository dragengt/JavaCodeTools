using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppCommon.Util
{
    /// <summary>
    /// text相关控件/checkBox的Config设置和保存类
    /// </summary>
    public  class UIConfigUtil 
    {
        [JsonIgnore]
        private static UIConfigUtil _instance;

        [JsonIgnore]
        private static UIConfigUtil instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = InitConfig();
                }
                return _instance;
            }
        }

        private static List<Control> controlList;

        private Dictionary<string, string> configDict;

        const String Config_Yes = "1";
        const String Config_No = "0";

        /// <summary>
        /// 绑定控件，以此监听控件的值
        /// </summary>
        /// <param name="control"></param>
        public static void ListenControl(Control control)
        {
            var configDict = instance.configDict;

            controlList.Add(control);

            //设置控件的值为保存的内容：
            if (configDict.ContainsKey(control.Name))
            {
                //额外判断：是否checkbox
                if (control is CheckBox)
                {
                    ((CheckBox)control).Checked = configDict[control.Name] == Config_Yes;
                }
                else
                {
                    //Get this control's value:
                    control.Text = configDict[control.Name];
                }
            }
        }

        /// <summary>
        /// 读取配置内容
        /// </summary>
        /// <returns></returns>
        private static UIConfigUtil InitConfig()
        {
            UIConfigUtil.controlList = new List<Control>();

            var config = new UIConfigUtil();

            String filePath = GetConfigPath();
            if (File.Exists(filePath))
            {
                string txt = File.ReadAllText(filePath);
                if (!String.IsNullOrEmpty(txt))
                {
                    config.configDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(txt);
                }
            }

            if(config.configDict==null)
            {
                config.configDict = new Dictionary<string, string>();
            }

            return config;
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        public static void SaveConfig()
        {
            //重新读取控件的值：
            var configDict = instance.configDict;
            foreach (var control in controlList)
            {
                //额外判断：是否checkbox
                if (control is CheckBox)
                {
                    configDict[control.Name] = ((CheckBox)control).Checked ?Config_Yes:Config_No;
                }
                else
                {
                    configDict[control.Name] = control.Text;
                }
            }

            string filePath = GetConfigPath();
            string saveContent = JsonConvert.SerializeObject(instance.configDict);
            Console.WriteLine("save config " + saveContent + " to " + filePath);
            File.WriteAllText(filePath, saveContent);
        }

        private static string GetConfigPath()
        {
            return Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "uiConfig.json");
        }

    }
}

