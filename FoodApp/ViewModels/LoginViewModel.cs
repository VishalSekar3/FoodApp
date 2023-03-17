using FoodApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using FoodApp.Views;
using FoodApp.Model;
using SQLite;

namespace FoodApp.ViewModels
{
	
	public class LoginViewModel : BaseViewModel
	{
		private readonly SQLiteConnection _connection;
		private string _UserName;
		public string Username
		{
			set 
			{
				this._UserName= value;
				OnPropertyChanged();
			}
			get
			{
				return this._UserName;
			}
		}

		private string _Password;
		public string Password
		{
			set
			{
				this._Password = value;
				OnPropertyChanged();
			}
			get
			{
				return this._Password;
			}
		}

		private bool _IsBusy;
		public bool IsBusy
		{
			set
			{
				this._IsBusy = value;
				OnPropertyChanged();
			}
			get
			{
				return this._IsBusy;
			}
		}

		private bool _Result;
		public bool Result
		{
			set
			{
				this._Result = value;
				OnPropertyChanged();
			}
			get
			{
				return this._Result;
			}
		}

		public Command LoginCommand { get; set; }
		public Command RegisterCommand{ get; set; }

		public LoginViewModel()
		{
			LoginCommand = new Command(async () => await LoginCommandAsync());
			RegisterCommand = new Command(async () => await RegisterCommandAsync());
			_connection = DependencyService.Get<ISQLite>().GetConnection();

		}

		private async Task RegisterCommandAsync()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;
				var userService = new UserService();
				Result = await userService.RegisterUser(Username, Password);
				if (Result)
				 await Application.Current.MainPage.DisplayAlert("Success", "User Registered", "Ok");
				
				else
					await Application.Current.MainPage.DisplayAlert("Error", "User already exist with this Credentials", "Ok");
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
			}
			finally
			{
				IsBusy = false;
			}
		}

		private bool CreateCartTable()
		{
			try
				{
					_connection.CreateTable<CartItem>();
					_connection.Close();
					return true;
				}
			catch (Exception ex) {return false;}
		}

		private async Task LoginCommandAsync()
		{

			if (IsBusy)
				return;
			try
			{
				
				IsBusy = true;
				var userService = new UserService();
				Result = await userService.LoginUser(Username, Password);
				if ( Result)
				{
					CreateCartTable();
					Preferences.Set("Username", Username);
					await Application.Current.MainPage.Navigation.PushModalAsync(new ProductsView());
					
				}
				else
				{
					await Application.Current.MainPage.DisplayAlert("Error", "Invalid Username or Password", "ok");
				}

			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}
