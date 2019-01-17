using System;
using System.Collections.ObjectModel;

namespace TuneSearch
{
    public class TracksViewModel
    {
        public ObservableCollection<CollectionViewModel> items { get; set; }

        public TracksViewModel()
        {
            items = new ObservableCollection<CollectionViewModel>();
        }
    }
}
