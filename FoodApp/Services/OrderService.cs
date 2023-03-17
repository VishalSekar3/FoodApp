using Firebase.Database;
using Firebase.Database.Query;
using FoodApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FoodApp.Services
{
	public class OrderService
	{
		FirebaseClient client;
		public OrderService() 
		{
			client = new FirebaseClient("https://foodapp-b655f-default-rtdb.firebaseio.com/");
		}
		public async Task<string> PlaceOrderAsync()
		{
			var cn = DependencyService.Get<ISQLite>().GetConnection();
			var data = cn.Table<CartItem>().ToList();

			var orderID = Guid.NewGuid().ToString();
			var uname = Preferences.Get("Username", "Guest");

			decimal totalCost = 0;

			foreach (var item in data)
			{
				OrderDetails od =new OrderDetails()
				{
					OrderId= orderID,
					OrderDetailId= Guid.NewGuid().ToString(),
					ProductID = item.ProductId,
					ProductName= item.ProductName,
					Price= item.Price,
					Quantity= item.Quantity
				};
				totalCost += item.Price * item.Quantity;
				await client.Child("OrderDetails").PostAsync(od);
			}

			await client.Child("Orders").PostAsync(
				new Order()
				{
					OrderId = orderID,
					Username = uname,
					TotalCost = totalCost
				});
			return orderID;
		}

	}
}
