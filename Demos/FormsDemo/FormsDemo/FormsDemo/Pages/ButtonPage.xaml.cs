using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FormsDemo
{
	public partial class ButtonPage : ContentPage
	{
		public ButtonPage()
		{
			InitializeComponent();
			button.Clicked += (sender, e) => 
			{
				DisplayAlert("Alert", "Button Clicked!!", "OK");
			};
		}
	}
}
