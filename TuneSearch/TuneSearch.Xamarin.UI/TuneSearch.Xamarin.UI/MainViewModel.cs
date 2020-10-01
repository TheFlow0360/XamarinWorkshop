using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using TuneSearch.Core.Ports;
using Xamarin.Forms;

namespace TuneSearch.Xamarin.UI
{
    class MainViewModel : INotifyPropertyChanged
    {
        private ISearchRequest _searchRequest;

        private Func<string, ISearchResult, Task> _showResultView;

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
            }
        }

        private Boolean _isWorking;
        public Boolean IsWorking 
        { 
            get => _isWorking; 
            private set 
            {
                _isWorking = value;
                OnPropertyChanged();
            } 
        }

        public ICommand SearchCommand { get; }

        public MainViewModel(ISearchRequest searchRequest, Func<string, ISearchResult, Task> showResultView)
        {
            _searchRequest = searchRequest ?? throw new ArgumentNullException(nameof(searchRequest));
            _showResultView = showResultView ?? throw new ArgumentNullException(nameof(showResultView));
            SearchCommand = new Command(async () => await ProcessSearch());
        }

        private async Task ProcessSearch()
        {
            IsWorking = true;
            try
            {
                var result = await _searchRequest.ProcessRequest(SearchText);
                await _showResultView(SearchText, result);
            }
            finally
            {
                IsWorking = false;
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion
    }
}
