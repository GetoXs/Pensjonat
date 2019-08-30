using System;
using System.Text;
using System.Data.Odbc;
using System.Data.Common;
using System.IO;

/*NIEUZYWAC!!!!*/
namespace PensjonatApp.Tools
{
	/// <summary>
	/// Singleton bazy danych
	/// Przykładowe użycie:
	///		Db.setUpAccesFile("baza.mdb", "Administrator", "");
	///		Db.Con.Open();
	///		DbCommand cmd = Db.Con.CreateCommand();
	///		cmd.CommandText = "SELECT * FROM Pracownicy_slownik";
	///		DbDataReader reader = cmd.ExecuteReader();
	///		Db.Con.Close();
	/// </summary>
	class Db
	{
		/// <summary>
		/// Połączenie z bazą danych
		/// </summary>
		private static readonly DbConnection con = new OdbcConnection();

		private Db() 
		{}
		static Db() 
		{}
		/// <summary>
		/// Pobieranie polaczenia z baza danych
		/// </summary>
		public static DbConnection Con
		{
			get
			{
				return con;
			}
		}

		/*
		/// <summary>
		/// Ustawia połączenie z bazą danych przez SQL Server
		/// </summary>
		/// <param name="serverName"></param>
		/// <param name="dbName"></param>
		/// <param name="user"></param>
		/// <param name="pass"></param>
		public static void setUpServer(String serverName, String dbName, String user, String pass)
		{
			//http://www.dofactory.com/Connect/Connect.aspx#sqlserver
			//http://www.codemaker.co.uk/it/tips/ado_conn.htm
			if (con.State != System.Data.ConnectionState.Closed)
				con.Close();
				
				con.ConnectionString =
					"Driver={SQL Server};" +
					"Server=" + serverName + ";" +
					"DataBase=" + dbName + ";" +
					"Uid=" + user + ";" +
					"Pwd=" + pass + ";";

		}
		/// <summary>
		/// Ustawia połączenie z bazą danych przez plik MS Access umieszczony w katalogu roboczym z aplikacją /bin/Debug/
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="user"></param>
		/// <param name="pass"></param>
		public static void setUpAccesFile(String fileName, String user, String pass)
		{
			if (con.State != System.Data.ConnectionState.Closed)
				con.Close();
			con.ConnectionString =
				@"Driver={Microsoft Access Driver (*.mdb)};" +
				@"Dbq=" + Directory.GetCurrentDirectory() + @"\" + fileName + ";" +
				@"Uid=" + user + ";" +
				@"Pwd=" + pass + ";";
		}
		 * */

	}
}
