using TuneSearch.Resx;
using Xamarin.Forms;
using TuneSearch.Common;
using System.Collections.Generic;
using TuneSearch.Core;
using TuneSearch.Infrastructure.Adapters;
using System.Linq;

namespace TuneSearch
{
    public partial class MainPage : ContentPage
    {
        private ICommandHandler<SearchTracksDTO, List<CollectionEntity>> _command = new SearchTracksCommand(new TunesSearchEngineAdapter());

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        void Handle_Search_Clicked(object sender, System.EventArgs e)
        {
            _command.Execute(new SearchTracksDTO { Term = searchTermEntry.Text },successHandler,errorHandler);
        }

        private async void errorHandler(System.Exception failure)
        {
            await DisplayAlert(AppResources.Error, failure.Message, AppResources.OK);
        }

        private async void successHandler(List<CollectionEntity> collections)
        {
            var viewModel = new TracksViewModel
            {
                items = collections.Select(collection => collection.ToSectionViewModel()).ToList()
            };
            await Navigation.PushAsync(new TracksPage(viewModel));
        }

        async void Handle_Info_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new LicensesPage());
        }

    }
}
