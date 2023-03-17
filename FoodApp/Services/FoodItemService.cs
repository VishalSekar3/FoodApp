using Firebase.Database;
using FoodApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Services
{
    class FoodItemService
    {
        FirebaseClient client;

        public FoodItemService() 
        {
            client = new FirebaseClient("https://foodapp-b655f-default-rtdb.firebaseio.com/");        
        }

        public async Task<List<FoodItem>> GetFoodItemsAsync()
        {
            var products = (await client.Child("FoodItems")
                .OnceAsync<FoodItem>())
                .Select(f => new FoodItem
                { 
                    CategoryID = f.Object.CategoryID,
                    Description = f.Object.Description,
                    Name= f.Object.Name,
                    Price= f.Object.Price,
                    ProductID= f.Object.ProductID,
                    ImageUrl= f.Object.ImageUrl,
                    Rating= f.Object.Rating,
                }).ToList();
            return products;
        }
        public async Task<ObservableCollection<FoodItem>> GetFoodItemsByCategoryAsync(int categoryID)
        {
            var foodItemsByCategory = new ObservableCollection<FoodItem>();
            var items = (await GetFoodItemsAsync()).Where(p => p.CategoryID == categoryID).ToList();
            foreach (var item in items)
            {
                foodItemsByCategory.Add(item);
            }
            return foodItemsByCategory;
        }

        public async Task<ObservableCollection<FoodItem>> GetLatestFoodItemsAsync()
        {
            var latestFoodItems = new ObservableCollection<FoodItem>();
            var items = (await GetFoodItemsAsync()).OrderByDescending(f => f.ProductID).Take(3);
            foreach (var item in items)
            {
                latestFoodItems.Add(item);
            }
            return latestFoodItems;
        }

        public async Task<ObservableCollection<FoodItem>> GetFoodItemByQueryAsync(string searchText)
        {
            var foodItemsByQuery = new ObservableCollection<FoodItem>();
            var items = (await GetFoodItemsAsync()).Where(p => p.Name.Contains(searchText)).ToList();

            foreach (var item in items)
            {
                foodItemsByQuery.Add(item);
            }
            return foodItemsByQuery;
        }
    }
}
