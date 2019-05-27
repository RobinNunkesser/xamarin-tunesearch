using System;
using System.Collections.ObjectModel;
using BasicCleanArch;

namespace TuneSearch
{
    public class TracksViewModel
    {
        public ObservableCollection<SectionViewModel<TrackViewModel>> items { get; set; }

        public TracksViewModel()
        {
            items = new ObservableCollection<SectionViewModel<TrackViewModel>>();
        }
    }
}
