using CommunityToolkit.Mvvm.ComponentModel;
using gradecalculator.Models;
using gradecalculator.Views;
using SQLite;
using SQLiteNetExtensions.Extensions;

namespace gradecalculator.ViewModels
{
    public class CourseEntryViewModel : ObservableObject
    {
        public static CourseEntryViewModel Current { get; set; }

        SQLiteConnection connection;

        // class constructor. sets connection to our database and instantiates a 'current' view model to use
        public CourseEntryViewModel()
        {
            Current = this;
            connection = GCDatabase.Connection;

            LoadCourses();
        }

        private List<CourseEntry> _courses;

        public List<CourseEntry> CourseEntries
        {
            get
            {
                return _courses;
            }
        }

        // this one is why we need the sqlnet extension package, and also the mvvm toolkit
        public void LoadCourses()
        {
            _courses = connection.GetAllWithChildren<CourseEntry>();
            MainThread.BeginInvokeOnMainThread(() =>
            {
                OnPropertyChanged(nameof(CourseEntries));
            });
            
        }

        // just like from our labs, bc if it aint broke dont fix it

        public void SaveCourse(CourseEntry entry)
        {
            if (entry.entryId > 0)
            {
                connection.Update(entry);
            }
            else
            {
                connection.Insert(entry);
            }
        }

        public void DeleteCourse(CourseEntry entry)
        {
            if (entry.entryId > 0)
            {
                connection.Delete(entry);
            }
        }
    }
}
