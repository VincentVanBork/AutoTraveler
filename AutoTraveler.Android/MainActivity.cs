using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.OS;

using OpenNETCF.IoC;
using UniversalBeacon.Library.Core.Interfaces;
using Android;
using Android.Support.V4.App;
using Android.Support.Design.Widget;
using System.Collections.Generic;
using Android.Support.V4.Content;
using Xamarin.Forms;

namespace AutoTraveler.Droid
{
    [Activity(Label = "AutoTraveler", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public string[] PermissionsArray = { Manifest.Permission.BluetoothPrivileged, Manifest.Permission.Bluetooth, Manifest.Permission.AccessCoarseLocation };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new App());

            updateNonGrantedPermissions();

            try
            {
                if (PermissionsArray != null && PermissionsArray.Length > 0)
                {
                    if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
                    {
                        ActivityCompat.RequestPermissions(this, PermissionsArray, 0);
                    }
                }
            }
            catch (Exception oExp)
            {

            }

            var provider = RootWorkItem.Services.Get<IBluetoothPacketProvider>();
            if (provider == null)
            {
                provider = new UniversalBeacon.Library.AndroidBluetoothPacketProvider(this);
                RootWorkItem.Services.Add<IBluetoothPacketProvider>(provider);
            }

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


        private void updateNonGrantedPermissions()
        {
            try
            {
                List<string> PermissionList = new List<string>();
                PermissionList.Add(Manifest.Permission.MediaContentControl);
                if (ContextCompat.CheckSelfPermission(Forms.Context, Manifest.Permission.BluetoothPrivileged) != (int)Android.Content.PM.Permission.Granted)
                {
                    PermissionList.Add(Manifest.Permission.BluetoothPrivileged);
                }
                if (ContextCompat.CheckSelfPermission(Forms.Context, Manifest.Permission.AccessCoarseLocation) != (int)Android.Content.PM.Permission.Granted)
                {
                    PermissionList.Add(Manifest.Permission.AccessCoarseLocation);
                }
                if (ContextCompat.CheckSelfPermission(Forms.Context, Manifest.Permission.Bluetooth) != (int)Android.Content.PM.Permission.Granted)
                {
                    PermissionList.Add(Manifest.Permission.Bluetooth);
                }
                PermissionsArray = new string[PermissionList.Count];
                for (int index = 0; index < PermissionList.Count; index++)
                {
                    PermissionsArray.SetValue(PermissionList[index], index);
                }
            }
            catch (Exception oExp)
            {

            }
        }
    }
}