using System;
using UnlockTheMinde.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UnlockTheMinde
{
    public partial class App : Application
    {
        public const string AppID = "unlockthemind-ymuds";
        public static Realms.Sync.App RealmApp;

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            RealmApp = Realms.Sync.App.Create(AppID);
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
