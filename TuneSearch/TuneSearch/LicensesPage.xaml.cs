using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace TuneSearch
{
    public partial class LicensesPage : ContentPage
    {
        public LicensesPage()
        {
            InitializeComponent();
            var assembly = typeof(LicensesPage).GetTypeInfo().Assembly;
            Stream stream = assembly
                .GetManifestResourceStream("TuneSearch.licenses.html");
            string html = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = html;
            browser.Source = htmlSource;
        }
    }
}
