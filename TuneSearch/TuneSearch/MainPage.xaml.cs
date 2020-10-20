using TuneSearch.Resx;
using Xamarin.Forms;
using System.Collections.Generic;
using TuneSearch.Core;
using TuneSearch.Infrastructure.Adapters;
using System.Linq;
using ExplicitArchitecture;
using TuneSearch.Core.Ports;

namespace TuneSearch
{
    public partial class MainPage : ContentPage
    {
        private IService<SearchTracksDTO, List<CollectionEntity>> _command = new SearchTracksService(new TunesSearchEngineAdapter());

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
            _command.Execute(new SearchTracksDTO { Term = searchTermEntry.Text },SuccessHandler,ErrorHandler);
        }

        private async void ErrorHandler(System.Exception failure)
        {
            await DisplayAlert(AppResources.Error, failure.Message, AppResources.OK);
        }

        private async void SuccessHandler(List<CollectionEntity> collections)
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
