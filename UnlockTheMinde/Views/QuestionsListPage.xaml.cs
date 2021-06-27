using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnlockTheMinde.Models;
using UnlockTheMinde.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UnlockTheMinde.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionsListPage : ContentPage
    {
        
        public QuestionsListPage()
        {
            InitializeComponent();
          
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var qsns = BindingContext as QuestionsListViewModel;
            qsns.OnAppearing();
           
        }


    }
}