using OpenNETCF.IoC;
using Plugin.Permissions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using UniversalBeacon.Library.Core.Entities;
using UniversalBeacon.Sample.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AutoTraveler.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        string infoString = string.Empty;

        private BeaconService _service;
        public ObservableCollection<Beacon> Beacons => _service?.Beacons;
        private Beacon _selectedBeacon;

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
            StartBeaconService();
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

        private void StartBeaconService()
        {
            _service = RootWorkItem.Services.Get<BeaconService>();
            if (_service == null)
            {
                _service = RootWorkItem.Services.AddNew<BeaconService>();
                if (_service.Beacons != null) _service.Beacons.CollectionChanged += Beacons_CollectionChanged;
            }
        }

        private void Beacons_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine($"Beacons_CollectionChanged {sender} e {e}");
        }


        public Beacon SelectedBeacon
        {
            get => _selectedBeacon;
            set
            {
                SetProperty(ref _selectedBeacon, value);
            }
        }



        
    }


    
}