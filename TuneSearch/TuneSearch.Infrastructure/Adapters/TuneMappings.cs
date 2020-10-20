using TuneSearch.Core.Ports;

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
                        ArtworkUrl = self.ArtworkUrl100
                    };

    }
}

