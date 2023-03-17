using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodApp.Model
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}
