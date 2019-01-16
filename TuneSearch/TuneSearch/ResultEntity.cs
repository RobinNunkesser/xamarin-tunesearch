using System;
using System.Collections.Generic;

namespace TuneSearch
{
    public class ResultEntity
    {
        public int resultCount { get; set; }
        public IEnumerable<TrackEntity> results { get; set; }
    }
}
