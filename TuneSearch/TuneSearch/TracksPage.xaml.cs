using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TuneSearch
{
    public partial class TracksPage : ContentPage
    {
        public TracksPage(object bindingContext)
        {
            InitializeComponent();
            BindingContext = bindingContext;
        }
    }
}
