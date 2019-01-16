using System;
namespace TuneSearch
{
    public class TrackEntity
    {
        public string artistName { get; set; }
        public string collectionName { get; set; }
        public string trackName { get; set; }
        public int trackNumber { get; set; }
        public override string ToString()
        {
            return $"{trackNumber}  - {trackName} ";
        }
    }
}
