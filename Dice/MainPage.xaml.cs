using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using ShakeGestures;
using Microsoft.Devices;

namespace Dice
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        //    BugSenseHandler.Instance.InitAndStartSession(this, "c5f08765"");
                
            ShakeGesturesHelper.Instance.ShakeGesture += new EventHandler<ShakeGestureEventArgs>(Instance_ShakeGesture);
            ShakeGesturesHelper.Instance.MinimumRequiredMovesForShake = 5;
            ShakeGesturesHelper.Instance.Active = true;
        }
        private void Instance_ShakeGesture(object sender, ShakeGestureEventArgs e)
        {
            
            _lastUpdateTime.Dispatcher.BeginInvoke(
                () =>
                {
                    status_line.Value += 20;
                    if (status_line.Value == 100)
                    {
                        doMagic();
                        
                    }
                        
                                     
                });
        }

        private void ContentPanel_Tap(object sender, GestureEventArgs e)
        {
            doMagic();
        }
        public void doMagic()
        {
            VibrateController testVibrateController = VibrateController.Default;
            testVibrateController.Start(TimeSpan.FromSeconds(1));
            vienas.Opacity = 0;
            du.Opacity = 0;
            trys.Opacity = 0;
            keturi.Opacity = 0;
            penki.Opacity = 0;
            sesi.Opacity = 0;
            septyni.Opacity = 0;
            astuoni.Opacity = 0;
            devyni.Opacity = 0;

            Random rnd = new Random();
            int dice = rnd.Next(1, 7);
            _lastUpdateTime.Text = "It is " + dice.ToString() + "!";

            switch (dice)
            {
                case 1:
                    penki.Opacity = 100;
                    break;
                case 2:
                    du.Opacity = 100;
                    astuoni.Opacity = 100;
                    break;
                case 3:
                    vienas.Opacity = 100;
                    penki.Opacity = 100;
                    devyni.Opacity = 100;
                    break;
                case 4:
                    vienas.Opacity = 100;
                    trys.Opacity = 100;
                    septyni.Opacity = 100;
                    devyni.Opacity = 100;
                    break;
                case 5:
                    vienas.Opacity = 100;
                    trys.Opacity = 100;
                    penki.Opacity = 100;
                    septyni.Opacity = 100;
                    devyni.Opacity = 100;
                    break;
                case 6:
                    vienas.Opacity = 100;
                    trys.Opacity = 100;
                    keturi.Opacity = 100;
                    sesi.Opacity = 100;
                    septyni.Opacity = 100;
                    devyni.Opacity = 100;
                    break;
                default:
                    break;
            }
            status_line.Value = 0;
        }
    }
}