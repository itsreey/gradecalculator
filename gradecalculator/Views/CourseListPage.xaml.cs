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
        Calculator calc = new Calculator(courseList);

        DisplayAlert("Result", "Your GPA is " + calc.GetResult() + ".", "Done");

        //TODO: add rounding to results
        //TODO: add special exception phrase when theres no courses yet. currently it says "Your GPA is NaN"

    }

}
