using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuneSearch.Common;
using Xamarin.Forms;

namespace TuneSearch
{
    public partial class MainPage : ContentPage, IOutputBoundary<IEnumerable<TrackEntity>>
    {
        private IInputBoundary<SearchRequest, IEnumerable<TrackEntity>> inputBoundary = new SearchInteractor();

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        public void Receive(Response<IEnumerable<TrackEntity>> response)
        {
            response.Match(async success =>
            {
                var collections = success.OrderBy(t => t).GroupBy(t => t.collectionName);
                var viewModel = new TracksViewModel();
                foreach (var result in collections)
                {
                    var collectionViewModel = new CollectionViewModel { LongName = result.Key };
                    foreach (var track in result)
                    {
                        collectionViewModel.Add(new TrackViewModel
                        {
                            image = track.artworkUrl100,
                            text = $"{track.trackNumber}  - {track.trackName}",
                            detail = track.artistName
                        });
                    }
                    viewModel.items.Add(collectionViewModel);
                }
                await Navigation.PushAsync(new TracksPage(viewModel));
            }, failure =>
            {
                // Handle Errpr
                Debug.WriteLine(failure);
            });
        }

        void Handle_Search_Clicked(object sender, System.EventArgs e)
        {
            var term = searchTermEntry.Text;
            inputBoundary.Send(new SearchRequest { term = term }, this);
        }
    }
}
