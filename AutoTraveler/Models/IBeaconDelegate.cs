using System;
using System.Threading.Tasks;
using Shiny.Beacons;

namespace AutoTraveler.Models
{
        public interface IBeaconDelegate : IShinyDelegate
        {
            Task OnStatusChanged(BeaconRegionState newStatus, BeaconRegion region);
        }
    
}
