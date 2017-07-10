using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Beeant.Distributed.Service.Host
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            this.Closing += Form1_Closing;
            if (comboBox1.Items.Count == 1)
            {
                comboBox1.SelectedIndex = 0;
                StartService();
            }

        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CloseService();
        }

        /// <summary>
        /// 得到表格
        /// </summary>
        /// <returns></returns>
        protected virtual void LoadData()
        {
            foreach (var key in ConfigurationManager.AppSettings.AllKeys)
            {
                comboBox1.Items.Add(string.Format("{0}-{1}", key, ConfigurationManager.AppSettings[key]));

            }
        }
        /// <summary>
        /// 关闭服务
        /// </summary>
        protected virtual void CloseService()
        {
            if (comboBox1.SelectedItem == null || button1.Enabled)
            {
                return;
            }
            var value = comboBox1.SelectedItem.ToString().Split('-');
            Winner.Creator.Get<Winner.Wcf.IWcfHost>().Stop(Type.GetType(value[1]));
        
        }
        /// <summary>
        /// 开启服务
        /// </summary>
        protected virtual void StartService()
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("请选择服务");
                return;
            }
            var value = comboBox1.SelectedItem.ToString().Split('-');
            Configuration.ConfigurationManager.Initialize(Type.GetType(value[1]).FullName);
            if (value[1] == "Beeant.Distributed.Host.Service.SearchService")
            {
                Winner.Creator.Get<Winner.Search.IIndexer>().InitlizeDocumentIndex();
            }
            Winner.Creator.Get<Winner.Wcf.IWcfHost>().Start(Type.GetType(value[1]));
            Text = comboBox1.SelectedItem.ToString();
            button1.Enabled = false;
            timer1.Enabled = true;
            Icon= GetIcon(value[1]);
            notifyIcon.Icon = Icon;
            notifyIcon.Text = value[0];
        }
    

        /// <summary>
        /// 得到图标
        /// </summary>
        /// <returns></returns>
        protected virtual Icon GetIcon(string type)
        {
            var vals = type.Split(',')[0].Split('.');
            var fileName = vals[vals.Length-1];
            if (string.IsNullOrWhiteSpace(fileName))
                return null;
            if (!File.Exists($"{System.Windows.Forms.Application.StartupPath}\\Icon\\{fileName}.ico"))
                return null;
            using (FileStream fsRead = new FileStream($"{System.Windows.Forms.Application.StartupPath}\\Icon\\{fileName}.ico", FileMode.Open))
            {
                return new Icon(fsRead, 32, 32);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartService();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || button1.Enabled)
            {
                return;
            }
            var value = comboBox1.SelectedItem.ToString().Split('-');
            Winner.Creator.Get<Winner.Wcf.IWcfHost>().Stop(Type.GetType(value[1]));
            Close();
        }

   

  


        private void timer1_Tick(object sender, EventArgs e)
        {

            ShowInTaskbar = false;
            Hide();
            timer1.Enabled = false;
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseService();
            Close();
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowInTaskbar = true;
        
            Show();
        
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                Hide();
                return;
            }
            WindowState = FormWindowState.Normal;
            BringToFront();
        }
    }
}
