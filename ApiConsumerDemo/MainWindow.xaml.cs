using ApiConsumerDemo.Business;
using ApiConsumerDemo.Models;
using System;
using System.Net.Cache;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;


namespace ApiConsumerDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int maxNumber;
        private int currentNumber;
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
           
        }
        public async Task LoadImage(int imageNumber = 0)
        {
            var comic = await ComicProcessor.LoadComic(imageNumber);
            if (imageNumber==0)
            {
                maxNumber = comic.Num;
            }
            currentNumber = comic.Num;
            var uriSource = new Uri(comic.Img, UriKind.Absolute);
            comicImage.Source = new BitmapImage(uriSource, new RequestCachePolicy(RequestCacheLevel.CacheIfAvailable));
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadImage();
        }

        private async void Click_precedent(object sender, RoutedEventArgs e)
        {
            if (currentNumber > 1)
            {
                currentNumber -= 1;
                nextImageButton.IsEnabled = true;
                await LoadImage(currentNumber);
            }
            if(currentNumber == 1)
            {
                previousImageButton.IsEnabled = false;
            }
        }

        private async void Click_suivant(object sender, RoutedEventArgs e)
        {
            if (currentNumber < maxNumber)
            {
                currentNumber += 1;
                previousImageButton.IsEnabled = true;
                await LoadImage(currentNumber);
            }
            if (currentNumber == maxNumber)
            {
                nextImageButton.IsEnabled = false;
            }
        }

        private void SunInfo_Click(object sender, RoutedEventArgs e)
        {
            SunInfo sunInfo = new SunInfo();
            sunInfo.Show();
        }
    }
}
