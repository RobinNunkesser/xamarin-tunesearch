using System;
using System.Collections.Generic;
using System.Linq;
using TuneSearch.Common;

namespace TuneSearch
{
    public class SearchInteractor : IInputBoundary<SearchRequest, TracksViewModel>
    {
        public async void Send(SearchRequest request,IOutputBoundary <TracksViewModel> outputBoundary)
        {
            var gatewayResponse = await new ITunesSearchGateway().GetSongs(request.term);
            gatewayResponse.Match(success =>
            {
                var collections = success.OrderBy(t => t).GroupBy(t => t.collectionName);
                var viewModel = new TracksViewModel();
                foreach (var result in collections)
                {
                    var collectionViewModel = new CollectionViewModel { LongName = result.Key };
                    foreach (var track in result)
                    {
                        collectionViewModel.Add(new TrackPresenter().present(track));
                    }
                    viewModel.items.Add(collectionViewModel);
                }
                outputBoundary.Receive(new Response<TracksViewModel>(viewModel));
            }, failure =>
            {
                outputBoundary.Receive(new Response<TracksViewModel>(failure));
            });
        }
    }
}