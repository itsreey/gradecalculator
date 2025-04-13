using Microsoft.Maui.ApplicationModel;

namespace gradecalculator
{
    public static class GCTheme
    {
        public static void SetTheme()
        {
            if (Application.Current?.UserAppTheme is null)
            {
                return;
            }

            switch (Settings.Theme)
            {
                // default is using system theme
                case 0:
                    Application.Current.UserAppTheme = AppTheme.Unspecified;
                    break;
                // light mode
                case 1:
                    Application.Current.UserAppTheme = AppTheme.Light;
                    break;
                // dark mode
                case 2:
                    Application.Current.UserAppTheme = AppTheme.Dark;
                    break;
            }

        }
    }
}
