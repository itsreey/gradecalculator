using gradecalculator.Views;

namespace gradecalculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void StartBtnClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("CourseListPage");
        }
    }

}