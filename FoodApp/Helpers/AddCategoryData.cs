using Firebase.Database;
using Firebase.Database.Query;
using FoodApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodApp.Helpers
{
	public class AddCategoryData
	{
		public List<Category> Categories { get; set; }

		FirebaseClient client;

		public AddCategoryData() 
		{
			client = new FirebaseClient("https://foodapp-b655f-default-rtdb.firebaseio.com/");

			Categories = new List<Category>()
			{
				new Category()
				{
					CategoryID = 1,
					CategoryName = "Biryani House",
					CategoryDescription = "Hot Dum Biryanis and Fast food",
					ImageUrl = "Biryani.png"},

				new Category()
				{
					CategoryID = 2,
					CategoryName = "Burger Bro's",
					CategoryDescription = "Super Burgers",
					ImageUrl = "Burger.png"},

				new Category()
				{
					CategoryID = 3,
					CategoryName = "Cake Shop",
					CategoryDescription = "Yummy Cakes",
					ImageUrl = "Dessert.png"
				}
			};
		}

		public async Task AddCategoryAsync()
		{
			try 
			{
				foreach (var category in Categories) 
				{
					await client.Child("Categories").PostAsync(new Category()
					{
						CategoryID = category.CategoryID,
						CategoryName = category.CategoryName,
						CategoryDescription = category.CategoryDescription,
						ImageUrl = category.ImageUrl
					});
				}
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "ok");
			}
		}
	}
}
