using ApiConsumerDemo.Business;
using System.Windows;

namespace ApiConsumerDemo
{
    /// <summary>
    /// Interaction logic for SunInfo.xaml
    /// </summary>
    public partial class SunInfo : Window
    {
        public SunInfo()
        {
            InitializeComponent();
        }

        private async void loadSunInfo_Click(object sender, RoutedEventArgs e)
        {
            var sunInformation = await SunProcessor.LoadSunInfo(36, -4);
            sunRiseText.Text = $"Le levé du soleil sera à {sunInformation.SunRise.ToLocalTime().ToShortTimeString()}";
            sunSetText.Text = $"Le couché du soleil sera à {sunInformation.SunSet.ToLocalTime().ToShortTimeString()}";
        }
    }
}
