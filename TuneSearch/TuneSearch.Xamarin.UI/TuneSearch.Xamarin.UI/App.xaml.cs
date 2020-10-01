using System.Threading.Tasks;
using TuneSearch.Core.Ports;
using TuneSearch.Xamarin.UI.Mocks;
using Xamarin.Forms;

namespace TuneSearch.Xamarin.UI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage()
            {
                BindingContext = new MainViewModel(new SearchRequestMock(), ShowResults) 
            });
        }

        private async Task ShowResults(string searchText, ISearchResult result)
        {
            await MainPage.Navigation.PushAsync(new ResultsPage()
            {
                BindingContext = new ResultsViewModel(searchText, result)
            });
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
