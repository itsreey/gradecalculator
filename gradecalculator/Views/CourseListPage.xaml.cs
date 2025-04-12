using gradecalculator.Models;
using gradecalculator.ViewModels;

namespace gradecalculator.Views;

public partial class CourseListPage : ContentPage
{
    CourseEntryViewModel _entryViewModel = new CourseEntryViewModel();
	public CourseListPage()
	{
		InitializeComponent();
        BindingContext = _entryViewModel;
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        _entryViewModel.LoadCourses();
    }

    private void CourseListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        CourseEntry tapped = (CourseEntry)e.Item;
        Navigation.PushAsync(new CourseEntryDetails(tapped));
    }

    private void AddBtnClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CourseEntryDetails(new CourseEntry()));
    }

    private void CalcBtnClicked(object sender, EventArgs e)
    {

        List<CourseEntry> courseList = _entryViewModel.CourseEntries;
        Calculator calc = new Calculator(courseList); // create a new calculator object to calculate

        HapticFeedback.Default.Perform(HapticFeedbackType.Click); // add haptic feedback for the results showing, for emphasis

        double result = calc.GetResult();

        // if nothing in course list, say so. Else, display as a pop-up.
        if (Double.IsNaN(result) == true)
        {
            DisplayAlert("Nothing to Calculate", "There are no courses entered yet.", "Okay");
        } else
        {
            DisplayAlert("Result", "Your GPA is " + result + ".", "Done");
        }

    }

}
