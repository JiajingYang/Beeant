using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Beeant.Presentation.Client.Launcher.Utility;
using System.Diagnostics;
using System.IO;

namespace Beeant.Presentation.Client.Launcher
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main(params string[] args)
        {
            //检测输入参数
            var result = UpdateTool.CheckParam(args);
            if (!result.Success)
            {
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain
            {
                ProductName = result.ProductName,
                ExecutablePath = result.ExecutablePath,
                ProductVersion = result.ProductVersion,
                NeedToUpdate = result.NeedForUpdate
            });

        }
    }
}
