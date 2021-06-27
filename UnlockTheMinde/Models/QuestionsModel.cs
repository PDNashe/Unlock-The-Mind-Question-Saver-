using UnlockTheMinde.Views;
using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace UnlockTheMinde.Models
{
    public class QuestionsModel : RealmObject 
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId? Id { get; set; } = ObjectId.GenerateNewId();

        [MapTo("question")]
        [Required]
        public string Question { get; set; }

        [MapTo("realm_id")]
        public string RealmId { get; set; }

        [MapTo("title")]
        [Required]
        public string Title { get; set; }
    }
}
