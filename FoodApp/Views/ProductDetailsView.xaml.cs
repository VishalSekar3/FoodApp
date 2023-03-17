using FoodApp.Model;
using FoodApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductDetailsView : ContentPage
	{
		ProductDetailsViewModel pvm;
		public ProductDetailsView(FoodItem foodItem)
		{
			InitializeComponent();
			pvm = new ProductDetailsViewModel(foodItem);
			this.BindingContext = pvm;
		}

		 async void Button_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync();
		}
	}
}