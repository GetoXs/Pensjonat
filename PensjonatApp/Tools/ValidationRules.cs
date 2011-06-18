using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Globalization;

namespace PensjonatApp
{
	/// <summary>
	/// Zasada sprawdzająca Nulle
	/// </summary>
	public class NotNullValidationRule : ValidationRule
	{
		public override ValidationResult Validate(object value,CultureInfo cultureInfo)
		{
			ValidationResult result = new ValidationResult(true, null);
			string inputString = (value ?? string.Empty).ToString();
			if (string.IsNullOrEmpty(inputString))
			{
				result = new ValidationResult(false, "Pole nie może być puste");
			}
			return result;
		}
	}
	/// <summary>
	/// Zasada sprawdzająca liczby
	/// </summary>
	public class OnlyDigitsValidationRule : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			ValidationResult result = new ValidationResult(true, null);
			string inputString = (value ?? string.Empty).ToString();
			int intTmp;
			if (int.TryParse(inputString, out intTmp)==false)
			{
				result = new ValidationResult(false, "Pole musi zawierać tylko liczbę");
			}
			return result;
		}
	}
}
