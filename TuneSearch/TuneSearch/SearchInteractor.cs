using System;
using System.Collections.Generic;
using TuneSearch.Common;

namespace TuneSearch
{
    public class SearchInteractor : IInputBoundary<SearchRequest,IEnumerable<TrackEntity>>
    {
        public SearchInteractor()
        {
        }

        public async void Send(SearchRequest request,IOutputBoundary < IEnumerable<TrackEntity>> outputBoundary)
        {
            var gatewayResponse = await new ITunesSearchGateway().GetSongs(request.term);
            outputBoundary.Receive(gatewayResponse);
        }
    }
}