using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using GrpcBaseCore.Services;
using NetGrpcCore.Common;
using Newtonsoft.Json;

namespace GrpcWpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnClickME_Click(object sender, RoutedEventArgs e)
        {
            var channelKey = "ModuleApiChannelKey";

            var reqParams = new GrpcBaseReq()
            {
                Opt = 1
            };

            var res = await GrpcClientHandle.GrpcGeneralCall("192.168.3.4", 52001, reqParams, channelKey);

            var bytes = new byte[res.Bts.Length];

            res.Bts.CopyTo(bytes, 0);

            var realData = Encoding.UTF8.GetString(bytes);

            txtRecordME.Text = $"{realData}\r\n\r\n{JsonConvert.SerializeObject(res)}";
        }
    }
}
