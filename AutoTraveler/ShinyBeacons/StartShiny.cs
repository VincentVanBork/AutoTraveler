using System;
using Shiny;
using Shiny.Beacons;
using Shiny.Logging;
using Shiny.Notifications;
using Shiny.Net.Http;
using Microsoft.Extensions.DependencyInjection;


namespace AutoTraveler.ShinyBeacons
{
    public class StartShiny : ShinyStartup
    {
        public override void ConfigureServices(IServiceCollection builder)
        {
            // custom logging
            Log.UseConsole();
            Log.UseDebug();

            //// create your infrastructure
            builder.AddSingleton<SampleSqliteConnection>();

            // register all of the acr stuff you want to use
            builder.UseBeaconMonitoring<BeaconDelegate>();
            builder.UseBeaconRanging();
            //builder.UseNotifications();
           

    
        }
    }
}