using System;
using System.ComponentModel;
using System.Globalization;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamarinEssentials
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Flashlight.TurnOffAsync();
            }
            catch (PermissionException pEx)
            {
                lblInfo.Text = pEx.Message;
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                await Flashlight.TurnOnAsync();
            }
            catch (PermissionException pEx)
            {
                lblInfo.Text = pEx.Message;
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            var level = Battery.ChargeLevel;
            var state = Battery.State;
            var source = Battery.PowerSource;

            string texto = string.Concat("Nível Bateria: ", level.ToString("P", CultureInfo.InvariantCulture)," - Status Bateria: ", state.ToString()
                ," - Fonte de energia: ", source.ToString());

            lblBatteryInformation.Text = texto;

        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            var appName = AppInfo.Name;
            var packageName = AppInfo.PackageName;
            var version = AppInfo.VersionString;
            var build = AppInfo.BuildString;

            lblAppInformation.Text = $"Infos: App Name: {appName} \r\n Package Name: {packageName} \r\n Versão: {version} \r\n Build: {build}";
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            var device = DeviceInfo.Model;
            var manufacturer = DeviceInfo.Manufacturer;
            var deviceName = DeviceInfo.Name;
            var version = DeviceInfo.VersionString;
            var platform = DeviceInfo.Platform;
            var idiom = DeviceInfo.Idiom;
            var deviceType = DeviceInfo.DeviceType;

            lblDeviceInformation.Text = $"Infos: Device: {device} \r\n Manufacturer: {manufacturer} \r\n Device Name: {deviceName} " +
                $"\r\n Version: {version} \r\n Platform: {platform} \r\n Idiom: {idiom} \r\n Device Type: {deviceType}";
        }
    }
}
