using System;
using System.IO;
using AutoTraveler.Models;
using SQLite;
using Shiny;

namespace AutoTraveler.ShinyBeacons
{
        public class SampleSqliteConnection : SQLiteAsyncConnection
        {
            public SampleSqliteConnection(IPlatform platform) : base(Path.Combine(platform.AppData.FullName, "sample.db"))
            {
                var conn = this.GetConnection();
                conn.CreateTable<BeaconEvent>();
                //conn.CreateTable<JobLog>();

            }

            public AsyncTableQuery<BeaconEvent> BeaconEvents => this.Table<BeaconEvent>();
            //public AsyncTableQuery<JobLog> JobLogs => this.Table<JobLog>();
    
        }
    }
