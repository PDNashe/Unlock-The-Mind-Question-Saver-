using Realms;
using Realms.Sync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using UnlockTheMinde.Models;
using UnlockTheMinde.Views;
using Xamarin.Forms;

namespace UnlockTheMinde.ViewModels
{ 
     [QueryProperty(nameof(QsnTitle), nameof(QsnTitle))]
    public class EditQuestionViewModel : BindableObject
    {
        public Command UPDATE { get; }
        public Command DELETE { get; }

        public bool isbusy;
        public string qsntitle;
        public string qsn;
        public string temptitle;

        public bool IsBusy
        {
            get => isbusy;
            set
            {
                isbusy = value;
                OnPropertyChanged();
            }
        }
        public string TempTitle
        {
            get => temptitle;
            set
            {
                temptitle = value;
                OnPropertyChanged();
            }
        }
        public string QsnTitle
        {
            get => qsntitle;
            set
            {
                 qsntitle = value;
              qsntitle = Uri.UnescapeDataString(value);
                //  BindingContext = new QuestionsModel { Title = Uri.UnescapeDataString(value) };
                OnPropertyChanged();
            }
        }

        public string Question
        {
            get => qsn;
            set
            {
                qsn = value;
                OnPropertyChanged();
            }
        }
        public EditQuestionViewModel()
        {
            LoadQuestion();
            UPDATE = new Command(UpdateQsn);
            DELETE = new Command(DeleteQsn);
        }

        public async void LoadQuestion()
        {

            var realm = Realm.GetInstance();
            
            var findQuestion = realm.All<QuestionsModel>().Where(QuestionsModel => QuestionsModel.Title == QsnTitle);


           
            QuestionsModel qsn = new QuestionsModel();
        await App.Current.MainPage.DisplayAlert("Question Loading...", "View Question", "OK");

            qsn = findQuestion.FirstOrDefault();
            if (qsn == null)
            { 
                await App.Current.MainPage.DisplayAlert("Question Validation", "Question Not Found", "OK");
            }
            else
            {
                TempTitle = qsn.Title;
                Question = qsn.Question;
            }
        }
        
        public async void UpdateQsn()
        {
            var realm = Realm.GetInstance();

            var updtqsn = realm.All<QuestionsModel>().FirstOrDefault(
                 QuestionsModel => QuestionsModel.Title == QsnTitle);

           
            realm.Write(() =>
            {
                updtqsn.Title = TempTitle;
                updtqsn.Question = Question;
            });

            await App.Current.MainPage.DisplayAlert("Question Update", "Question SUcessfully Updated", "OK");
            await Application.Current.MainPage.Navigation.PushAsync(new QuestionsListPage());
        }

        public async void DeleteQsn()
        {
            var realm = Realm.GetInstance();

            var deltqsn = realm.All<QuestionsModel>().FirstOrDefault(
                QuestionsModel => QuestionsModel.Title == QsnTitle);

            realm.Write(() =>
                {
                realm.Remove(deltqsn);
            });
            await App.Current.MainPage.DisplayAlert("Question Deletation", "Question Successfully Deleted", "OK");
            await Application.Current.MainPage.Navigation.PushAsync(new QuestionsListPage());
            ;
        }
    }
}
