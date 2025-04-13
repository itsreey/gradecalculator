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

        private void HelpBtn_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("How to Use", "In the course list page, you can add your courses taken so far, and calculate your overall GPA. Each course requires a name (enter anything you find memorable and easy to understand, it can be the subject code or even a shorthand), its credit amount and letter grade. Tap on a course to edit or delete it.", "Done");

        }
    }

}