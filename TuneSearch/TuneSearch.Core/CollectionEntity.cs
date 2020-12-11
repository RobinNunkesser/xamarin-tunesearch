using System;
using System.Collections.Generic;
using ExplicitArchitecture.TuneSearchExample.Core.Ports;

namespace TuneSearch.Core
{
    public class CollectionEntity : ICollectionEntity
    {
        public CollectionEntity()
        {
            Tracks = new List<ITrackEntity>();
        }

        public string Name { get; set; }
        public List<ITrackEntity> Tracks { get; set; }
    }
}
