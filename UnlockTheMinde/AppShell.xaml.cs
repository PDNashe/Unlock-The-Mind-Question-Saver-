using System;
using System.Collections.Generic;
using UnlockTheMinde.ViewModels;
using UnlockTheMinde.Views;
using Xamarin.Forms;

namespace UnlockTheMinde
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            BindingContext = this;
            
            Routing.RegisterRoute(nameof(EditQuestionPage), typeof(EditQuestionPage));
        }

    }
}
