using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AutoTraveler.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        string infoString = string.Empty;


        public AboutViewModel()
        {

            Title = "Current Travel";
            StartScan = new Command(async () => await StartScanning());
            StopScan = new Command(async () => await StopScanning());
            InfoString = "helllo";

        }

        async public Task StartScanning() {
            await Task.Delay(1000);
            InfoString = "depepe";
        }
        async public Task StopScanning()
        {
            await Task.Delay(1000);
            InfoString = "dheh";
        }

        public ICommand StartScan { get; }
        public ICommand StopScan { get; }

        public string InfoString {
            get { return infoString; }

            set { 
                SetProperty(ref infoString, value);
            }
        }
 
    }


    
}