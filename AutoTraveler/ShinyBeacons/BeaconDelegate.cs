using System;
using System.Threading.Tasks;
using AutoTraveler.Models;
using Shiny;
using Shiny.Beacons;


namespace AutoTraveler.ShinyBeacons
{
    public class BeaconDelegate : IBeaconMonitorDelegate, IShinyStartupTask
    {
        readonly CoreDelegateServices services;
        public BeaconDelegate(CoreDelegateServices services) => this.services = services;


        public async Task OnStatusChanged(BeaconRegionState newStatus, BeaconRegion region)
        {
            await this.services.Connection.InsertAsync(new BeaconEvent
            {
                Identifier = region.Identifier,
                Uuid = region.Uuid.ToString(),
                Major = region.Major,
                Minor = region.Minor,
                Entered = newStatus == BeaconRegionState.Entered,
                Date = DateTime.Now
            });
            await this.services.Notifications.Send(
                this.GetType(),
                newStatus == BeaconRegionState.Entered,
                $"Beacon Region {newStatus}",
                $"{region.Identifier} - {region.Uuid}/{region.Major}/{region.Minor}"
            );
        }


        public void Start()
            => this.services.Notifications.Register(this.GetType(), true, "Beacon Regions");
    }
}