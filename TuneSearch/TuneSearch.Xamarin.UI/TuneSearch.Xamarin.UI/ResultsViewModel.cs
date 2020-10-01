using System;
using System.Collections.Generic;
using System.Text;
using TuneSearch.Core.Ports;

namespace TuneSearch.Xamarin.UI
{
    class ResultsViewModel
    {
        private ISearchResult _result;

        public String Title { get; }

        public ResultsViewModel(string title, ISearchResult result)
        {
            Title = title;
            _result = result;
        }
    }
}
