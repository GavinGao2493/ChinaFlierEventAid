using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;

namespace EventAidForm
{
    public partial class EventPublishForm : Form
    {
        private ChromiumWebBrowser chromeBrowser;
        public EventPublishForm()
        {
            InitializeComponent();
            InitializeChromium();
        }

        private void InitializeChromium()
        {
            // 初始化CefSharp设置
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);

            // 创建ChromiumWebBrowser控件
            chromeBrowser = new ChromiumWebBrowser("https://pilot.chinaflier.com/login.php");
            chromeBrowser.Dock = DockStyle.Fill;

            // 注册FrameLoadEnd事件，用于在框架加载完成后执行操作
            chromeBrowser.FrameLoadEnd += ChromeBrowser_FrameLoadEnd;

            // 将ChromiumWebBrowser控件添加到窗体中
            Controls.Add(chromeBrowser);
        }

        private void ChromeBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            // 在框架加载完成后执行自动点击登录按钮的操作
            if (e.Frame.IsMain)
            {
                chromeBrowser.ExecuteScriptAsync("document.getElementsByClassName('form-control')[0].value = 'CFR_admin'");
                chromeBrowser.ExecuteScriptAsync("document.getElementsByClassName('form-control')[1].value = '123456789'");
                chromeBrowser.ExecuteScriptAsync("document.getElementsByClassName('btn btn-info btn-lg btn-block text-uppercase waves-effect waves-light')[0].click()");
                chromeBrowser.ExecuteScriptAsync("document.getElementsByClassName('ti-file fa-fw')[0].click()");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // 关闭时释放Cef资源
            Cef.Shutdown();
            base.OnFormClosing(e);
        }
    }
}
