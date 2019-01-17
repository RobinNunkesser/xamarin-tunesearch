using System;
namespace TuneSearch
{
    public class TrackEntity : IComparable<TrackEntity>
    {
        public string artistName { get; set; }
        public string collectionName { get; set; }
        public string trackName { get; set; }
        public int trackNumber { get; set; }
        public int discNumber { get; set; }
        public string artworkUrl60 { get; set; }
        public string artworkUrl100 { get; set; }

        public int CompareTo(TrackEntity other)
        {
            if (!collectionName.Equals(other.collectionName)) return collectionName.CompareTo(other.collectionName);
            if (discNumber != other.discNumber) return discNumber.CompareTo(other.discNumber);
            return trackNumber.CompareTo(other.trackNumber);
        }

        public override string ToString()
        {
            return $"{trackNumber}  - {trackName} ";
        }
    }
}

