using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizApp
{
    public partial class App : Application
    {
        QuizPage QuizPage { get; }

        StatisticsPage StatisticsPage { get; }

        MainViewModel ViewModel { get; }

        public App()
        {
            InitializeComponent();

            ViewModel = new MainViewModel(() => MainPage.Navigation.PushAsync(StatisticsPage));
            QuizPage = new QuizPage(ViewModel)
            {
                BindingContext = ViewModel
            };

            StatisticsPage = new StatisticsPage()
            {
                BindingContext = ViewModel
            };

            MainPage = new NavigationPage(QuizPage);
        }

        protected override void OnStart()
        {
            ViewModel.LoadStatistics();
        }

        protected override void OnSleep()
        {
            ViewModel.SaveStatistics();
        }

        protected override void OnResume()
        {
        }
    }
}
