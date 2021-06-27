using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnlockTheMinde.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UnlockTheMinde.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditQuestionPage : ContentPage
    {
        public EditQuestionPage()
        {
            InitializeComponent();
        }

     /*  protected override void OnAppearing()
        {
            base.OnAppearing();

            var vm = BindingContext as EditQuestionViewModel;
            vm.OnAppearing();
        }*/
    }
}