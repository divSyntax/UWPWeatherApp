using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using System.Net.Http;
using static WeatherApp.WeatherConditions;
using Windows.UI.Xaml.Media.Imaging;

namespace WeatherApp
{
 
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            getMilwaukeeWeather();
        }

        private async void getMilwaukeeWeather()
        {
            string input = temp.Text;

            RootObject rootObject = await WeatherConditions.getWeather(input);

            temp.Text = "City: " +rootObject.name + " Temp: " + Math.Round(rootObject.main.temp);

            foreach (var item in rootObject.weather)
            {
              string icon = String.Format("http://openweathermap.org/img/w/{0}.png", item.icon);//get icon
              desc.Text = " Description: " + item.description;
              cloud.Source = new BitmapImage(new Uri(icon,UriKind.Absolute));//show icon
            }
        }
    }
}
