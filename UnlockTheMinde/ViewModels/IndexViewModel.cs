using System;
using System.Collections.Generic;
using System.Text;
using UnlockTheMinde.Views;
using Xamarin.Forms;

namespace UnlockTheMinde.ViewModels
{
    public class IndexViewModel
    {
        public Command Unlock { get; }

        public IndexViewModel()
        {
            Unlock = new Command(UnlockTheMind);
        }

        public async void UnlockTheMind()
        {  

            await Shell.Current.GoToAsync($"//{nameof(AddQuestionsPage)}");
        }
    }
}
