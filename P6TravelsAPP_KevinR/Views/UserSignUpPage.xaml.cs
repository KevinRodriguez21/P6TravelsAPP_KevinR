using P6TravelsAPP_KevinR.ViewModels;
using P6TravelsAPP_KevinR.Models;

namespace P6TravelsAPP_KevinR.Views;


public partial class UserSignUpPage : ContentPage
{
    //definicion del objeto viewmodel que gestiona la pagina

    UserViewModel? vm;

	public UserSignUpPage()
	{
        InitializeComponent();

        BindingContext = vm = new UserViewModel();

        LoadUserRolesList();
    }

    private async void LoadUserRolesList()
    {
        LstUserRoles.ItemsSource = await vm.VmGetUserRolesAsync();
    }

    private async void BtnCancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void BtnAdd_Clicked(object sender, EventArgs e)
    {
        //debemos hacer una validacion para los campos que son requisito

        var answer = await DisplayAlert("Confirmation Required", "Adding new user. Are you sure?", "Yes", "No");

        if (answer)
        {
            //extraer el objeto de tipo user role en el picker (Lista)
            UserRole SelectedUserRole = LstUserRoles.SelectedItem as UserRole;

            bool R = await vm.VmAddUser(TxtEmail.Text.Trim(),TxtName.Text.Trim(),TxtPhone.Text.Trim(), TxtPassword.Text.Trim(),SelectedUserRole.UserRoleId);

            if (R)
            {
                await DisplayAlert(":)", "User added!!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(":(", "Error: ", "OK");
            }

        }

    }
}