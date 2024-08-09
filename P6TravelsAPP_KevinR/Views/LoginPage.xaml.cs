namespace P6TravelsAPP_KevinR.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private void SwshowPassword_Toggled(object sender, ToggledEventArgs e)
    {
		TxtPassword.IsPassword = true;

		if (SwshowPassword.IsToggled)
		{
			TxtPassword.IsPassword = false;
		}
    }

    private async void BtnSignUp_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new UserSignUpPage());
    }
}