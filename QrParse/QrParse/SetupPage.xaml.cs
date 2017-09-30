using System.Net.Http;
using System.Diagnostics;
using XLabs.Forms.Controls;
using Xamarin.Forms.PlatformConfiguration;
using XLabs.Platform.Device;
using ZXing.QrCode.Internal;
using ZXing;
using ZXing.Net.Mobile.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Ioc;
using System.Net;
using System.IO;

namespace QrParse
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetupPage : ContentPage
    {
        InviteByQr m_inviteByQrPage;
        public SetupPage()
        {
            InitializeComponent();

            logo.Source = ImageSource.FromResource("QrParse.Image.icon.png");
            m_inviteByQrPage = new InviteByQr();
            ///var device = Resolver.Resolve<IDevice>();
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //var mainTab = new ExtendedTabbedPage() { Title = "Xamarin forms", SwipeEnabled=true };
            //mainTab.Children.Add(new ContentPage { Title = "test1" , Content=new BoxView { Color=Color.Blue, HeightRequest=100f, VerticalOptions=LayoutOptions.Center} });
            //mainTab.Children.Add(new ContentPage { Title = "test2" , Content=new BoxView { Color=Color.Blue, HeightRequest=100f, VerticalOptions=LayoutOptions.Center} });
            //mainTab.Children.Add(new ContentPage { Title = "test3" , Content=new BoxView { Color=Color.Blue, HeightRequest=100f, VerticalOptions=LayoutOptions.Center} });
            // mainPage = new NavigationPage(mainTab);
           // mainTab.CurrentPageChanged += () => DisplayAlert("tips", mainTab.Title, "OK");
            //Navigation.PushAsync(mainPage);
            Navigation.PushAsync(m_inviteByQrPage);
        }

        private async Task Button_Clicked_1Async(object sender, EventArgs e)
        {
            string strUrl = "http://10.184.129.30:8888";
            //string strUrl = "https://www.baidu.com";
            var httpClinet = new HttpClient();
            //var response = await httpClinet.GetAsync(strUrl);
            //response.EnsureSuccessStatusCode();
            string content = await httpClinet.GetStringAsync(strUrl);


            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(strUrl);
            request.Method = "GET";

            //request.ContentType = "application/x-www-form-urlencoded";
            //request.BeginGetRequestStream(new AsyncCallback(RequestProceed), request);
        }

        private void callbackAsync(IAsyncResult asyncResult)
        {
            var request = asyncResult.AsyncState as HttpWebRequest;
            var response = request.EndGetResponse(asyncResult);
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
            string json = reader.ReadToEnd();
        }

        private void RequestProceed(IAsyncResult asyncResult)
        {
            HttpWebRequest request = (HttpWebRequest)asyncResult.AsyncState;
            request.BeginGetResponse(new AsyncCallback(callbackAsync), request);
        }

      

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SendEmailPage());
        }
    }
}