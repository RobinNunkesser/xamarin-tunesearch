using System;
using System.Collections.Generic;

namespace TuneSearch.Core.Ports
{
    public class CollectionEntity
    {
        public String Name { get; set; }
        public List<TrackEntity> Tracks { get; set; } = new List<TrackEntity>();

    }
}
