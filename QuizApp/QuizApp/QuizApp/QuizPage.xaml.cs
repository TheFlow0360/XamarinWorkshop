using Xamarin.Forms;

namespace QuizApp
{
    public partial class QuizPage : ContentPage
    {
        private IAppearingHandler AppearingHandler { get; }

        public QuizPage(IAppearingHandler appearingHandler)
        {
            AppearingHandler = appearingHandler;
            InitializeComponent();
        }

        private void ContentPage_Appearing(object sender, System.EventArgs e)
        {
            AppearingHandler.Appeared();
        }

        private void ContentPage_Disappearing(object sender, System.EventArgs e)
        {
            AppearingHandler.Disappeared();
        }
    }
}
