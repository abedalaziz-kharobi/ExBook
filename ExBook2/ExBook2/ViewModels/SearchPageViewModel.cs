using App1Search.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App1Search.ViewModel
{
    public class SearchPageViewModel
    {
        public ObservableCollection<SerachPageModel> MyListCollector { get; set; }
        public SearchPageViewModel()
        {
            MyListCollector = new ObservableCollection<SerachPageModel>()
            {
                new SerachPageModel(){MyNameBook = "Calculas" , MyDetailBook =" Cap" },
                new SerachPageModel(){MyNameBook = "AI" , MyDetailBook =" Cap" , },
                new SerachPageModel(){MyNameBook = "Qa" , MyDetailBook =" Cap" , },
               new SerachPageModel(){MyNameBook = "AI" , MyDetailBook =" Cap" , }


            };

        }
    }
}