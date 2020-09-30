using System;

namespace HelloWorld
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ProcessButton_Clicked(object sender, EventArgs e)
        {
            var text = InputEntry.Text;
            OutputEntry.Text = $"You input was \"{text.ToUpper()}\"";
        }
    }
}
