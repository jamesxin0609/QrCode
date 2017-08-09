using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace QrParse
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //this.ToolbarItems.Add(new ToolbarItem {Command= } (,"设置", "", () => { Navigation.PushAsync(new SetupPage()); }));
        }
        public Command CreateCommand { get; private set; }

        private void RespCallback(IAsyncResult asss)
        {

        }
        public bool CheckUrlVisit(string url)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                if(req != null)
                {
                    return true;
                }
            }
            catch(WebException webex)
            {
                return false;
            }
            catch(Exception e)
            {
                return false;
            }

            return false;
        }

        private void OnClickSetup(object sender, EventArgs e)
        {

        }
        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
#if __ANDROID__
	// Initialize the scanner first so it can track the current context
	MobileBarcodeScanner.Initialize (Application);
#endif
           
            //var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            var scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) => {
                // Stop scanning
                scanPage.IsScanning = false;

                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    await DisplayAlert("结果", result.Text, "确定");
                    bool bIsUrl = CheckUrlVisit(result.Text);
                    if(bIsUrl)
                    {
                        bool bOpenURL = await DisplayAlert("", "检测到网页连接件，是否跳转到该链接？", "是", "否");
                        if (bOpenURL)
                            Device.OpenUri(new Uri(result.Text));
                    }
                });
            };
            await Navigation.PushAsync(scanPage);
        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SetupPage());
        }
    }
}
