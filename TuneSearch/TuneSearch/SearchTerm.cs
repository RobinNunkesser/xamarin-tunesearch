using System;
using ExplicitArchitecture.TuneSearchExample.Core.Ports;

namespace TuneSearch
{
    public class SearchTerm : ISearchTerm
    {
        public string Term { get; set; }
    }
}
