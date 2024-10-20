﻿using DJI.WindowsSDK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace DJIWindowsSDKSample.DJISDKInitializing
{
    public sealed partial class ActivatingPage : Page
    {
        public ActivatingPage()
        {
            this.InitializeComponent();
            DJISDKManager.Instance.SDKRegistrationStateChanged += Instance_SDKRegistrationEvent;
            string registrationKey = "1ebd2d74d0fef595e6f8a5ba";

            DJISDKManager.Instance.RegisterApp(registrationKey);
        }

        private async void Instance_SDKRegistrationEvent(SDKRegistrationState state, SDKError resultCode)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
               activateStateTextBlock.Text = state == SDKRegistrationState.Succeeded ? "Activated." : "Not Activated.";
               activationInformation.Text = resultCode == SDKError.NO_ERROR ? "Register success" : resultCode.ToString();
            });
        }
    }
}
