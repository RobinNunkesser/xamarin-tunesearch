using System;
using System.Collections.Generic;

namespace TuneSearch.Infrastructure
{
    public class ResultEntity
    {
        public int resultCount { get; set; }
        public List<TrackEntity> results { get; set; }
    }
}
