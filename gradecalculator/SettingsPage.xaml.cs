namespace gradecalculator;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (!e.Value)
        {
            return;
        }

        var val = (sender as RadioButton)?.Value as string;

        if (string.IsNullOrEmpty(val))
        {
            return;
        }
        switch (val)
        {
            case "System":
                Settings.Theme = 0;
                break;
            case "Light":
                Settings.Theme = 1;
                break;
            case "Dark":
                Settings.Theme = 2;
                break;
        }

        GCTheme.SetTheme();

    }
}