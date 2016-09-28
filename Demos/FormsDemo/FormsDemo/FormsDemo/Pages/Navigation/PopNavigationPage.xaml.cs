using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FormsDemo
{
	public partial class PopNavigationPage : ContentPage
	{
		public PopNavigationPage()
		{
			InitializeComponent();
			this.CreateToolBarItem();

			button.Clicked += (sender, e) => { Navigation.PopAsync();};
		}
	}
}
