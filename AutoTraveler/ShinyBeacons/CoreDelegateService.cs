using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Shiny;
using Shiny.Notifications;


namespace AutoTraveler.ShinyBeacons
{

    public class CoreDelegateServices
    {
        public CoreDelegateServices(SampleSqliteConnection conn,
                                    AppNotifications notifications)
        {
            this.Connection = conn;
            this.Notifications = notifications;
        }


        public SampleSqliteConnection Connection { get; }
        public AppNotifications Notifications { get; }

    }
    
}
