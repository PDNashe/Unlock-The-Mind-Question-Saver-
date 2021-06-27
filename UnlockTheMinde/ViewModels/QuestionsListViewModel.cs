using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Realms;
using Realms.Sync;
using Xamarin.Forms;
using AsyncTask = System.Threading.Tasks.Task;

using UnlockTheMinde.Models;
using UnlockTheMinde.Views;

namespace UnlockTheMinde.ViewModels
{
      [QueryProperty(nameof(QsnTitle), nameof(QsnTitle))]
    public class QuestionsListViewModel : BindableObject
    {

        public string qsntitle;
        public string qsn;
        public string tempTitle;
        public string tempQsn;

        public Command<QuestionsModel> ItemTapped { get; }
        public Command DELETE { get; }
        public Command UPDATE { get; }

         
        public ObservableCollection<QuestionsModel> finalList = new ObservableCollection<QuestionsModel>();
        public List<QuestionsModel> qsnlist = new List<QuestionsModel>();
        public string QsnTitle
        {
            get => qsntitle;
            set
            {
                qsntitle = value;
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

        public string  TempTitle
        {
            get => tempTitle;
            set
            {
                tempTitle = value;
                OnPropertyChanged();
            }
        }

        public string TempQsn
        {
            get => tempQsn;
            set
            {
                tempQsn = value;
                OnPropertyChanged();
            }
        }
        public List<QuestionsModel> QuesnList
        {
            get => qsnlist;
            set
            {
                qsnlist = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<QuestionsModel> FinalList
        {
            get => finalList;
            set
            {
                finalList = value;
                OnPropertyChanged();
            }
        }


        public QuestionsListViewModel()
        {
            LoadQuestions();
            ItemTapped = new Command<QuestionsModel>(Choice);

        }

        public void DeleteALL()
        {
            var realm = Realm.GetInstance();

            var clearAll = realm.All<QuestionsModel>().ToList();

            realm.Write(() =>
            {
                realm.RemoveAll();
            });
        }

        public void LoadQuestions()
        {
           
            var realm = Realm.GetInstance();

           
            var loadQuestions = realm.All<QuestionsModel>().ToList();


            QuesnList = loadQuestions;
            var qsnslist = new ObservableCollection<QuestionsModel>();
            foreach(var qdata in loadQuestions)
            {
                qsnslist.Add(qdata);
            }
            FinalList = qsnslist;

          
        }

        public async void Choice(QuestionsModel qsnsmodel)
        {
            await Shell.Current.GoToAsync($"{nameof(EditQuestionPage)}?{nameof(EditQuestionViewModel.QsnTitle)}={qsnsmodel.Title}");
           
        }


        public void OnAppearing()
        {
            LoadQuestions();
        }

    }
    }

