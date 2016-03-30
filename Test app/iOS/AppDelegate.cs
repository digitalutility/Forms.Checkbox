﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Messier16.Forms.iOS.Controls;
using UIKit;
using Xamarin.Forms;

namespace CheckboxTestApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            CheckboxRenderer.Init();
#if ENABLE_TEST_CLOUD
            Forms.ViewInitialized += (object sender, ViewInitializedEventArgs e) => {
                // http://developer.xamarin.com/recipes/testcloud/set-accessibilityidentifier-ios/
                if (null != e.View.StyleId)
                {
                    e.NativeView.AccessibilityIdentifier = e.View.StyleId;
                }
            };

            // requires Xamarin Test Cloud Agent
            Xamarin.Calabash.Start();
#endif

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}

