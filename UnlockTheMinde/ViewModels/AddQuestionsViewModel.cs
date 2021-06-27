using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

using Realms;
using UnlockTheMinde.Models;
using Realms.Sync;
using System.Linq;

namespace UnlockTheMinde.ViewModels
{
    public class AddQuestionsViewModel : BindableObject
    {
        public Command SAVE { get; }
        public Command CLEAR { get; }

        private string titletxt;
        private string questiontxt;

        public string TitleText
        {
            get => titletxt;
            set
            {
                titletxt = value;
                OnPropertyChanged();
            }
        }

        public string QuestionText
        {
            get => questiontxt;
            set
            {
                questiontxt = value;
                OnPropertyChanged();
            }
        }

        public AddQuestionsViewModel()
        {
            SAVE = new Command(SaveQuestion);
            CLEAR = new Command(ClearFields);
        }

        public async void SaveQuestion()
        {


            if (TitleText == null || TitleText == string.Empty 
                || QuestionText == null || QuestionText == string.Empty)
                await Application.Current.MainPage.DisplayAlert("Error", "Fill in all fields", "OK");
            else
            {

                var realm =  Realm.GetInstance();

                var checkExist = realm.All<QuestionsModel>().FirstOrDefault(
                 QuestionsModel => QuestionsModel.Title == TitleText);

                if (checkExist != null)
                {
                    await App.Current.MainPage.DisplayAlert
                        ("Question Existence", "Question Title Already Exists! Change Title", "OK");

                }
                else
                {
                    realm.Write(() =>
                    {
                        realm.Add(new QuestionsModel()
                        {
                            Title = TitleText,
                            Question = QuestionText
                        });
                    });

                    await Application.Current.MainPage.DisplayAlert("Process", "Question Successfully Saved", "OK");
                }

            }


        }
      
        public void ClearFields()
        {
            TitleText = string.Empty;
            QuestionText = string.Empty;
        }
    }
}
