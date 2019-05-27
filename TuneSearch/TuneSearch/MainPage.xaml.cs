using TuneSearch.Resx;
using Xamarin.Forms;
using BasicCleanArch;

namespace TuneSearch
{
    public partial class MainPage : ContentPage, IDisplayer<TracksViewModel>
    {
        private IUseCase<SearchRequest, TracksViewModel> _interactor = new SearchInteractor();

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        public void Display(Result<TracksViewModel> response)
        {
            response.Match(
            async success => await Navigation.PushAsync(new TracksPage(success)),
            async failure => await DisplayAlert(AppResources.Error, failure.Message, AppResources.OK));
        }

        void Handle_Search_Clicked(object sender, System.EventArgs e)
        {
            var term = searchTermEntry.Text;
            _interactor.Execute(new SearchRequest { term = term }, this);
        }

        async void Handle_Info_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new LicensesPage());
        }

    }
}
