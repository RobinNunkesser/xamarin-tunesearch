using System;
using ExplicitArchitecture.TuneSearchExample.Core.Ports;
using Newtonsoft.Json;

namespace TuneSearch.Infrastructure
{
    public partial class SearchApiResult : ITrackEntity
       {
           public Uri ArtworkUrl { get => ArtworkUrl100; set => ArtworkUrl100 = value; }
           int ITrackEntity.TrackNumber { get => (int)TrackNumber; set => TrackNumber = value; }
           int ITrackEntity.DiscNumber { get => (int)DiscNumber; set => DiscNumber = value; }

        public int CompareTo(ITrackEntity other)
        {
            if (!CollectionName.Equals(other.CollectionName)) return CollectionName.CompareTo(other.CollectionName);
            if (DiscNumber != other.DiscNumber) return ((int)DiscNumber).CompareTo(other.DiscNumber);
            return ((int)TrackNumber).CompareTo(other.TrackNumber);
        }
    }

}
