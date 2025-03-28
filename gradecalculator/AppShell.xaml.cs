using gradecalculator.Views;

namespace gradecalculator
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CourseListPage), typeof(CourseListPage));
        }
    }
}
