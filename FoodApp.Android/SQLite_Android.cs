using System;
using System.IO;
using FoodApp.Model;
using SQLite;
using Xamarin.Forms;

[assembly:Dependency(typeof(FoodApp.Droid.SQLite_Android))]
namespace FoodApp.Droid
{
	public class SQLite_Android : ISQLite
	{
		public SQLiteConnection GetConnection()
		{
			var sqliteFileName = "MyDatabase.db3";
			string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var path = Path.Combine(documentsPath, sqliteFileName);
			var cn = new SQLiteConnection(path);
			return cn;
		}
	}
}