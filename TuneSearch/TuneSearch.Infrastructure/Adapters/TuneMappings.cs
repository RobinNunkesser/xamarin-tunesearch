using TuneSearch.Core;

namespace TuneSearch.Infrastructure.Adapters
{
    public static class TuneMappings
    {
        public static TrackEntity ToTrackEntity(this SearchApiResult self) =>
                    new TrackEntity()
                    {
                        ArtistName = self.ArtistName,
                        CollectionName = self.CollectionName,
                        TrackName = self.TrackName,
                        TrackNumber = (int)self.TrackNumber,
                        DiscNumber = (int)self.DiscNumber,
                        ArtworkUrl60 = self.ArtworkUrl60,
                        ArtworkUrl100 = self.ArtworkUrl100
                    };

    }
}

