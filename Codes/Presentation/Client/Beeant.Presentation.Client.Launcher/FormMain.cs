using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Beeant.Presentation.Client.Launcher.Utility;

namespace Beeant.Presentation.Client.Launcher
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// 更新的产品名称
        /// </summary>
        public new string ProductName { get; set; }
        /// <summary>
        /// 产品执行文件
        /// </summary>
        public string ExecutablePath { get; set; }
        /// <summary>
        /// 产品版本号
        /// </summary>
        public new string ProductVersion { get; set; }
        /// <summary>
        /// 需要更新的版本
        /// </summary>
        public List<ProductVersion> NeedToUpdate { get; set; }

        delegate void StepProgressCallback(int percentage);
        delegate void ResetProgressCallback(int maximum);
        delegate void AppendTextCallback(string appended);
        public FormMain()
        {
            InitializeComponent();
        }
        #region 前期准备,处理工作,更新成功后工作,更新失败后回滚工作
        /// <summary>
        /// work
        /// </summary>
        /// <param name="operation">操作类型</param>
        /// <param name="sourceFolder">服务器文件夹（Download有效）</param>
        /// <param name="work"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        protected bool HandleWork(string operation, string sourceFolder, Work work, ref string message)
        {
            if (work == null) return true;
            foreach (var doc in work.MakeDir)
            {
                backgroundWorker1.ReportProgress(1);
                AppendText($"【{operation}】正在创建文件夹。。。");
                if (!UpdateTool.MakeDir(doc.TargetFolder, ref message))
                {
                    return false;
                }
            }
            foreach (var doc in work.NewFile)
            {
                backgroundWorker1.ReportProgress(1);
                AppendText($"【{operation}】正在新建文件。。。");
                if (!UpdateTool.NewFile(doc.TargetFolder, doc.Name, ref message))
                {
                    return false;
                }
            }
            foreach (var doc in work.Copy)
            {
                backgroundWorker1.ReportProgress(1);
                AppendText($"【{operation}】正在复制文件。。。");
                if (!UpdateTool.Copy(doc.SourceFolder, doc.TargetFolder, doc.Name,ref message))
                {
                    return false;
                }
            }
            foreach (var doc in work.Download)
            {
                backgroundWorker1.ReportProgress(1);
                AppendText($"【{operation}】正在下载文件。。。");
                if (!UpdateTool.Download(ProductName, sourceFolder, doc.TargetFolder, doc.Name, ref message))
                {
                    return false;
                }
            }
            foreach (var doc in work.UnRegister)
            {
                backgroundWorker1.ReportProgress(1);
                AppendText($"【{operation}】正在反注册文件。。。");
                if (!UpdateTool.UnRegister(doc.TargetFolder, doc.Name, ref message))
                {
                    return false;
                }
            }
            foreach (var doc in work.Register)
            {
                backgroundWorker1.ReportProgress(1);
                AppendText($"【{operation}】正在注册文件。。。");
                if (!UpdateTool.Register(doc.TargetFolder, doc.Name, ref message))
                {
                    return false;
                }
            }
            foreach (var doc in work.Execute)
            {
                backgroundWorker1.ReportProgress(1);
                AppendText($"【{operation}】正在执行文件。。。");
                if (!UpdateTool.Execute(doc.TargetFolder, doc.Name, ref message))
                {
                    return false;
                }
            }
            foreach (var doc in work.Delete)
            {
                backgroundWorker1.ReportProgress(1);
                AppendText($"【{operation}】正在删除文件。。。");
                if (!UpdateTool.DeleteFile(doc.TargetFolder, doc.Name, ref message))
                {
                    return false;
                }
            }
            foreach (var doc in work.RemoveDir)
            {
                backgroundWorker1.ReportProgress(1);
                AppendText($"【{operation}】正在删除文件夹。。。");
                if (!UpdateTool.RemoveDir(doc.TargetFolder, ref message))
                {
                    return false;
                }
            }
            AppendText($"【{operation}】完成！");

            return true;
        }
        #endregion
        #region RichTextBox
        /// <summary>
        /// 追加指定内容到RichTextBox控件中文本的末尾
        /// </summary>
        /// <param name="appended">追加的内容</param>
        protected void AppendText(string appended)
        {
            try
            {
                // InvokeRequired需要比较调用线程ID和创建线程ID
                // 如果它们不相同则返回true
                if (rtbList.InvokeRequired)
                {
                    var d = new AppendTextCallback(AppendText);
                    this.Invoke(d, appended);
                }
                else
                {
                    rtbList.AppendText(($"{DateTime.Now}: {appended} {Environment.NewLine}"));
                    if (!rtbList.Focused)
                    {
                        rtbList.ScrollToCaret();
                    }
                }
            }
            catch
            {
                //
            }
        }
        #endregion
        #region 进度条
        /// <summary>
        /// 设置进度条
        /// </summary>
        /// <param name="percentage">百分比</param>
        protected void StepProgress(int percentage)
        {
            try
            {
                // InvokeRequired需要比较调用线程ID和创建线程ID
                // 如果它们不相同则返回true
                if (progress.InvokeRequired)
                {
                    var d = new StepProgressCallback(StepProgress);
                    Invoke(d);
                }
                else
                {
                    //progress.Value += percentage;
                    progress.Value = percentage;
                }
            }
            catch
            {
                // ignored
            }
        }
        /// <summary>
        /// 重置进度条
        /// </summary>
        /// <param name="maximum"></param>
        protected void RetsetProgress(int maximum)
        {
            try
            {
                // InvokeRequired需要比较调用线程ID和创建线程ID
                // 如果它们不相同则返回true
                if (progress.InvokeRequired)
                {
                    var d = new ResetProgressCallback(RetsetProgress);
                    Invoke(d, maximum);
                }
                else
                {
                    progress.Value = 0;
                    progress.Maximum = maximum;
                }
            }
            catch
            {
                // ignored
            }
        }
        #endregion
        #region 更新
        /// <summary>
        /// 处理版本更新事件
        /// </summary>
        /// <param name="version"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool HandleUpdate(ProductVersion version,ref string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                message = $"正在更新【{ProductName}】的版本【V{version.Value}】。。。";
            }
            Update versionDetail = null;
            
            if (!UpdateTool.GetProductVersionDetail(ProductName, version.Folder, ref versionDetail))
            {
                message = "获取更新明细失败";
                return false;
            }
            RetsetProgress(versionDetail.WorkCount);
            //前期准备
            if (!HandleWork("更新前准备工作", version.Folder, versionDetail.Preparation, ref message))
            {
                return false;
            }
            //实际处理
            return HandleWork("处理工作", version.Folder, versionDetail.Handle, ref message)
                ? HandleWork("更新成功后工作", version.Folder, versionDetail.Success, ref message)
                : HandleWork("更新失败后回滚工作", version.Folder, versionDetail.Rollback, ref message);
        }
        /// <summary>
        /// 产品更新
        /// </summary>
        /// <param name="state"></param>
        private void AutoUpdate(object state)
        {
            //if (NeedToUpdate == null)
            //{
            //    AppendText($"！！严重警告！！版本更新服务器发生异常，请与管理员联系！");
            //    return;
            //}
            foreach (var detail in NeedToUpdate)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    break;
                }

                string message = string.Empty;
                AppendText("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                AppendText($"正在更新【{ProductName}】的版本【V{detail.Value}】。。。");
                if (!HandleUpdate(detail,ref message))
                {
                    AppendText($"{message}");
                    break;
                }
                AppendText($"【{ProductName}】的版本【V{detail.Value}】更新完成！");
                AppendText(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Thread.Sleep(1000);
            }
            /*
            for (var i = 1; i <= 10; i++)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    break;
                }
                foreach (var detail in UpdateVersion)
                {
                    if (backgroundWorker1.CancellationPending)
                    {
                        break;
                    }
                    AppendText($"{detail.Folder}:{detail.Value}");
                    Thread.Sleep(100);
                }
                backgroundWorker1.ReportProgress(i);
                AppendText($"本次更新的产品 {ProductName}");
                AppendText($"当前产品的版本号 {ProductVersion}");
                AppendText($"本次更新的产品文件 {ExecutablePath}");
                ////Thread.Sleep(1000);
                //AppendText($"检查需要更新的文件。。。");
                ////Thread.Sleep(1000);
                //AppendText($"下载需要更新的文件。。。");

                //AppendText($"替换需要更新的文件。。。");
                Thread.Sleep(100);
            }
            */
        }
        #endregion
        private void btnLaucher_Click(object sender, EventArgs e)
        {
            UpdateTool.StartProcess(ExecutablePath);
            Application.Exit();
            //this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //执行更新
            Thread.Sleep(Convert.ToInt32(e.Argument));
            AutoUpdate(null);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnLaucher.Enabled = true;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //AppendText(UpdateVersion.Count.ToString());
            Text = $"{Text} - V{Application.ProductVersion}";
            backgroundWorker1.RunWorkerAsync(2000);
            Application.DoEvents();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            StepProgress(e.ProgressPercentage);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
        }
    }
}
