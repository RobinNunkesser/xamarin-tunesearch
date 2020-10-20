using TuneSearch.Core;
using TuneSearch.Core.Ports;

namespace TuneSearch.Infrastructure.Adapters
{
    public static class CollectionMappings
    {
        public static SectionViewModel<TrackViewModel> ToSectionViewModel(this CollectionEntity self)
        {
            var collectionViewModel = new SectionViewModel<TrackViewModel> { LongName = self.Name };
            foreach (var track in self.Tracks)
            {
                collectionViewModel.Add(new TrackViewModel()
                {
                    image = track.ArtworkUrl,
                    text = $"{track.TrackNumber}  - {track.TrackName}",
                    detail = track.ArtistName
                });
            }
            return collectionViewModel;
        }

    }
}