using System.Linq;
using BasicCleanArch;

namespace TuneSearch
{
    public class SearchInteractor : IUseCase<SearchRequest, TracksViewModel>
    {
        public async void Execute(SearchRequest request,IDisplayer <TracksViewModel> outputBoundary)
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
                outputBoundary.Display(new Result<TracksViewModel>(viewModel));
            }, failure =>
            {
                outputBoundary.Display(new Result<TracksViewModel>(failure));
            });
        }
    }
}