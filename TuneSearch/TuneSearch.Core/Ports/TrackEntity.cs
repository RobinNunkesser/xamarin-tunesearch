using System;
using System.Collections.Generic;

namespace TuneSearch.Core.Ports
{
    public class TrackEntity : IComparable<TrackEntity>
    {
        public string ArtistName { get; set; }
        public string CollectionName { get; set; }
        public string TrackName { get; set; }
        public int TrackNumber { get; set; }
        public int DiscNumber { get; set; }
        public Uri ArtworkUrl { get; set; }

        public int CompareTo(TrackEntity other)
        {
            if (!CollectionName.Equals(other.CollectionName)) return CollectionName.CompareTo(other.CollectionName);
            if (DiscNumber != other.DiscNumber) return DiscNumber.CompareTo(other.DiscNumber);
            return TrackNumber.CompareTo(other.TrackNumber);
        }

        public override string ToString()
        {
            return $"{TrackNumber}  - {TrackName} ";
        }
    }
}
