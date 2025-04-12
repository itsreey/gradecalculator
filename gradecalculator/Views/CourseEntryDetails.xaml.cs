using gradecalculator.Models;
using gradecalculator.ViewModels;

namespace gradecalculator.Views;

[QueryProperty("Item", "Item")]
public partial class CourseEntryDetails : ContentPage
{
	CourseEntry model;

	// bind our course entry model class
	public CourseEntryDetails(CourseEntry m)
	{
		model = m;
		BindingContext = model;
		InitializeComponent();
	}

	// strings work easiest for this because we can use IsNullOrEmpty to check, but then we must convert from string to double for the calculations
	// that bit is handled in the CourseEntry model with a bunch of if-else statements. Maybe I should look into making it a switch for optimization but it works for now so I'm leaving it as is
	async void SaveBtnClicked(object sender, EventArgs e)
	{
		if (string.IsNullOrWhiteSpace(model.courseName))
		{
			await DisplayAlert("Name Required", "Please enter the name of the course.", "OK");
			return;
		} else if (string.IsNullOrEmpty(model.grade) || string.IsNullOrEmpty(model.creditUnits))
		{
			await DisplayAlert("Field Required", "Please ensure you've selected an option.", "OK");
			return;
		} else
		{
			HapticFeedback.Default.Perform(HapticFeedbackType.Click); // add vibration for emphasis
			CourseEntryViewModel.Current.SaveCourse(model);
		}
		await Navigation.PopAsync();
	}

	// do nothing and just return to the prev page
	async void CancelBtnClicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}

	// delete the course from our viewmodel/list - just like how the labs did it too
	async void DeleteBtnClicked(object sender, EventArgs e)
	{
		if (await DisplayAlert("Confirm Delete", "Are you sure you want to delete this course entry?", "Yes", "No") != true)
			return;
		var model = (CourseEntry)BindingContext;
		CourseEntryViewModel.Current.DeleteCourse(model);

		await Navigation.PopAsync();
	}

}