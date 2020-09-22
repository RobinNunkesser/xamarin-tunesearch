﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuneSearch.Common;
using TuneSearch.Core;
using TuneSearch.Core.Ports;

namespace TuneSearch.Infrastructure.Adapters
{
    public class TunesSearchEngineAdapter : ITunesSearchEngine
    {
        private readonly ITunesSearchAPI _api;

        public TunesSearchEngineAdapter(ITunesSearchAPI api) => _api = api;

        public TunesSearchEngineAdapter() => _api = new ITunesSearchAPI();

        public async Task<Result<List<TrackEntity>>> GetSongs(string term)
        {
            var result = await _api.GetSongs(term);

            return result.Map(tunes =>
                tunes.Select(tune => tune.ToTrackEntity()).ToList());
        }
    }
}