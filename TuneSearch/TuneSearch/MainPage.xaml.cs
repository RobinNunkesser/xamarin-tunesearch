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
    public partial class MainPage : ContentPage, IOutputBoundary<TracksViewModel>
    {
        private IInputBoundary<SearchRequest, TracksViewModel> inputBoundary = new SearchInteractor();

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        public void Receive(Response<TracksViewModel> response)
        {
            response.Match(async success =>
            {
                await Navigation.PushAsync(new TracksPage(success));
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
