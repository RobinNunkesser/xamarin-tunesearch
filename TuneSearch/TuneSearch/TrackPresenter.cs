using System;
using TuneSearch.Common;

namespace TuneSearch
{
    public class TrackPresenter : IPresenter<TrackEntity, TrackViewModel>
    {
        public TrackViewModel present(TrackEntity entity)
        {
            return
                new TrackViewModel
                {
                    image = entity.artworkUrl100,
                    text = $"{entity.trackNumber}  - {entity.trackName}",
                    detail = entity.artistName
                };
        }
    }
}
