using System;
using System.Collections.ObjectModel;

namespace TuneSearch
{
    public class CollectionViewModel : ObservableCollection<TrackViewModel>
    {
        public string LongName { get; set; }
        public string ShortName { get; set; }
    }
}
