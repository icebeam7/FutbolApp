using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace FutbolApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            string rutaBD = Helpers.FileHelper.ObtenerRutaLocal("futbol.db3");
            LoadApplication(new App(rutaBD, new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS()));

            return base.FinishedLaunching(app, options);
        }
    }
}
