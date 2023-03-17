using Firebase.Database;
using Firebase.Database.Query;
using FoodApp.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodApp.Helpers
{
    class AddFoodItemData
    {
		FirebaseClient client;
		public List<FoodItem> FoodItems { get; set; }

        public AddFoodItemData()
        {
			

			client = new FirebaseClient("https://foodapp-b655f-default-rtdb.firebaseio.com/");
			FoodItems = new List<FoodItem>()
			{
                    new FoodItem()
                  {
                     ProductID= 1,
                     CategoryID= 1,
                     ImageUrl = "MainBiryani.png",
                     Name = "Chicken Dum Biryani",
                     Description = "Tastiest Biryani with a healty twist",
                     Rating = "4.7",
                     Price= 299
                   },


					new FoodItem()
				  {
					 ProductID= 2,
					 CategoryID= 1,
					 ImageUrl = "MainFriedrice.png",
					 Name = "Veg Fried Rice",
					 Description = "A treat for the Veg",
					 Rating = "4.1",
					 Price= 190
				   },


					new FoodItem()
				  {
					 ProductID= 3,
					 CategoryID= 2,
					 ImageUrl = "MainVegBurger.png",
					 Name = "Veg Burger",
					 Description = "Super Bro's Special Veg Burger",
					 Rating = "3",
					 Price= 179
				   },

					new FoodItem()
				  {
					 ProductID= 4,
					 CategoryID= 2,
					 ImageUrl = "MainCBurger.png",
					 Name = "Double Chicken Burger",
					 Description = "Super Bro's Super Big Burger",
					 Rating = "4.1",
					 Price= 249
					},

					new FoodItem()
				  {
					 ProductID= 5,
					 CategoryID= 3,
					 ImageUrl = "MainACake.png",
					 Name = "Honey Almond Cake",
					 Description = "For your sweet tooth",
					 Rating = "3.1",
					 Price= 79
					},

					new FoodItem()
				  {
					 ProductID= 6,
					 CategoryID= 3,
					 ImageUrl = "MainBCake.png",
					 Name = "Blueberry Cheesecake",
					 Description = "Amazing Cheesecake",
					 Rating = "4.0",
					 Price= 89
					}
			};

        }
		public async Task AddFoodItemsAsync()
		{ try 
			{
				foreach (var item in FoodItems)
				{
					await client.Child("FoodItems").PostAsync(new FoodItem() 
					{ 
						ProductID= item.ProductID,
						CategoryID= item.CategoryID,
						ImageUrl= item.ImageUrl,
						Name = item.Name,
						Description = item.Description,
						Rating = item.Rating,
						Price= item.Price,
					});
				}	
			}

		catch(Exception ex) 
			{
				await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "ok");
			}
		}

	}
}
