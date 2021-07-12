using System;
using MusicPorts;

namespace TuneSearch.Infrastructure
{
    public partial class SearchApiResult : ITrackEntity
       {
           public Uri ArtworkUrl { get => ArtworkUrl100; set => ArtworkUrl100 = value; }
           int ITrackEntity.TrackNumber { get => (int)TrackNumber; set => TrackNumber = value; }
           int ITrackEntity.DiscNumber { get => (int)DiscNumber; set => DiscNumber = value; }

        public int CompareTo(ITrackEntity other)
        {
            if (!ArtistName.Equals(other.ArtistName)) return ArtistName.CompareTo(other.ArtistName);
            if (!CollectionName.Equals(other.CollectionName)) return CollectionName.CompareTo(other.CollectionName);            
            if (DiscNumber != other.DiscNumber) return ((int)DiscNumber).CompareTo(other.DiscNumber);
            return ((int)TrackNumber).CompareTo(other.TrackNumber);
        }
    }

}
