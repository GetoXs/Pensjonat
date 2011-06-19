using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using PensjonatApp.ValidationEx;

namespace PensjonatApp
{
	public class ValidationPracownik
	{
		private string _imie;
		private string _nazwisko;
		private string _login;
		private string _pesel;
		private string _telefon;
		private string _stanowisko;

		#region Getters&Setters
		public string Imie
		{
			get { return _imie; }
			set { _imie = value; }
		}
		public string Nazwisko
		{
			get { return _nazwisko; }
			set { _nazwisko = value; }
		}
		public string Login
		{
			get { return _login; }
			set { _login = value; }
		}
		public string Pesel
		{
			get { return _pesel; }
			set { _pesel = value; }
		}
		public string Telefon
		{
			get { return _telefon; }
			set { _telefon = value; }
		}
		public string Stanowisko
		{
			get { return _stanowisko; }
			set { _stanowisko = value; }
		}
		#endregion
		/// <summary>
		/// Sprawdza czy wszystkie wymagane pola sa wypelnione
		/// </summary>
		public static bool isValid(DependencyObject parent)
		{
			ValidationHelper.forceUpdate(parent);
			return ValidationHelper.isValid(parent);
		}
	}
}
