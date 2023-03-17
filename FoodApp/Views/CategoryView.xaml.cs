using System;
using FoodApp.Model;
using FoodApp.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CategoryView : ContentPage
	{
		CategoryViewModel cvm;
		public CategoryView(Category category)
		{
			InitializeComponent ();
			cvm = new CategoryViewModel(category);
			this.BindingContext = cvm;
		}

		private async void Button_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync();
        }

		private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var selectedProduct = e.CurrentSelection.FirstOrDefault() as FoodItem;
			if (selectedProduct == null) 
				return;

				await Navigation.PushModalAsync(new ProductDetailsView(selectedProduct));
			((CollectionView)sender).SelectedItem = null;
        }
    }
}