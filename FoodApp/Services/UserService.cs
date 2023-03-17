using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Firebase.Database;
using System.Threading.Tasks;
using System.Linq;
using FoodApp.Model;
using Firebase.Database.Query;
using System.Reactive.Subjects;

namespace FoodApp.Services
{
	public class UserService
	{
		FirebaseClient client;
		//SqlConnection _connection = new SqlConnection(@"");

		public UserService()
		{
			client = new FirebaseClient("https://foodapp-b655f-default-rtdb.firebaseio.com/");	
		}

		public async Task<bool> IsUserExist(string uname)
		{
			var user = (await client.Child("Users")
				.OnceAsync<User>()).Where(u => u.Object.Username == uname).FirstOrDefault();
			return (user != null);
		}

		public async Task<bool> RegisterUser(string uname, string passwd)
		{
			if (await IsUserExist(uname) == false)
			{
				await client.Child("Users")
					.PostAsync(new User() 
					{
						Username = uname,
						Password = passwd
					});
				return true;
			}
			else 
			{ 
				return false; 
			}
		}

		public async Task<bool> LoginUser(string uname, string passwd)
		{
			var user = (await client.Child("Users")
				.OnceAsync<User>()).Where(u => u.Object.Username == uname)
				.Where(u => u.Object.Password == passwd).FirstOrDefault();

			return (user != null);
		}
	}
}
