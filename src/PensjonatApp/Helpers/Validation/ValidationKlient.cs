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
	/*
	 * 
	 * 
		<ControlTemplate x:Key="TextBoxErrorTemplateK" TargetType="{x:Type TextBox}">
			<Grid ClipToBounds="False" >
				<Image HorizontalAlignment="Right" VerticalAlignment="Top" 
					   Width="16" Height="16" Margin="0,-8,-8,0" 
					   ToolTip="{Binding ElementName=adornedElement, 
							RelativeSource={RelativeSource Self},
							Path=(Validation.Errors)[0].ErrorContent}"
					   Source="/PensjonatApp;component/Images/Check-icon.png" />
				<Border BorderBrush="Red" BorderThickness="1" Margin="-1">
					<AdornedElementPlaceholder Name="adornedElement" />
				</Border>
	 		</Grid>
		</ControlTemplate>
	 * 
	 * 
	 * 
	 * 
	 * 
	 * 
		<!--
		<Style TargetType="{x:Type TextBox}">
			<Setter Property="Validation.ErrorTemplate">
				<Setter.Value>
					<ControlTemplate>
						<DockPanel LastChildFill="True">

							<TextBlock DockPanel.Dock="Right"
								Foreground="Orange"
								Margin="5" 
								FontSize="12pt"
								Focusable="False"
								Text="{Binding ElementName=MyAdorner, 
                               Path=AdornedElement.(Validation.Errors)[0].ErrorContent}">
							</TextBlock>

							<Border BorderBrush="Red" BorderThickness="1">
								<AdornedElementPlaceholder Name="MyAdorner" />
							</Border>

						</DockPanel>
					</ControlTemplate>
				</Setter.Value>
			</Setter>
			<Style.Triggers>
				<Trigger Property="Validation.HasError" Value="true">
					<Setter Property="ToolTip"
						Value="{Binding RelativeSource={RelativeSource Self}, 
                       Path=(Validation.Errors)[0].ErrorContent}"/>
				</Trigger>
			</Style.Triggers>
		</Style> -->
	 * 
	 */

	public class ValidationKlient
	{
		private string _imie;
		private string _nazwisko;
		private string _pesel;
		private string _adres;
		private string _telefon;
		private string _mail;
		private string _kodPoczotwy;
		private string _nip;
		private string _firma;

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
		public string Pesel
		{
			get { return _pesel; }
			set { _pesel = value; }
		}
		public string Adres
		{
			get { return _adres; }
			set { _adres = value; }
		}
		public string Telefon
		{
			get { return _telefon; }
			set { _telefon = value; }
		}
		public string Mail
		{
			get { return _mail; }
			set { _mail = value; }
		}
		public string KodPocztowy
		{
			get { return _kodPoczotwy; }
			set { _kodPoczotwy = value; }
		}
		public string Nip
		{
			get { return _nip; }
			set { _nip = value; }
		}
		public string Firma
		{
			get { return _firma; }
			set { _firma = value; }
		}
		#endregion
		/// <summary>
		/// Sprawdza czy wszystkie wymagane pola sa wypelnione
		/// </summary>
		public static bool isValid(DependencyObject parent, params AutoCompleteTextBox [] autoTextBoxes)
		{
			ValidationHelper.forceUpdate(parent);
			foreach (var atb in autoTextBoxes)
			{
				if (string.IsNullOrWhiteSpace(atb.Text))
					return false;
			}
			return ValidationHelper.isValid(parent);
		}
	}
}
