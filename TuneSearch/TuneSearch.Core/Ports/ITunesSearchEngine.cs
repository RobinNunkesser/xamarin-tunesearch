using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExplicitArchitecture;

namespace TuneSearch.Core.Ports
{
    public interface ITunesSearchEngine
    {
        public Task<Result<List<TrackEntity>>> GetSongs(string term);
    }       
}
