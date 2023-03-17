using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FoodApp.Helpers;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage ()
		{
			InitializeComponent ();
		}

		private async void ButtonCategories_Clicked(object sender, EventArgs e)
		{
			var acd = new AddCategoryData();
			await acd.AddCategoryAsync();
        }

		private async void ButtonProducts_Clicked(object sender, EventArgs e)
		{
			var afd = new AddFoodItemData();
			await afd.AddFoodItemsAsync();
        }

		private void ButtonCart_Clicked(object sender, EventArgs e)
		{
			var cct = new CreateCartTable();
			if (cct.CreateTable())
				DisplayAlert("Success", "Cart Table Created", "Ok");
			else
				DisplayAlert("Error","Error while creating the Table","ok");
        }
    }
}