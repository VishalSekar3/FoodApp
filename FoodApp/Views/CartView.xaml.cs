using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CartView : ContentPage
	{
		public CartView ()
		{
			InitializeComponent ();
			LableName.Text = "Welcome " + Preferences.Get("Username", "Guest") + ",";
		}

		async void Button_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync();

        }
    }
}