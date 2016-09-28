using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FormsDemo
{
	public partial class XamlBrowserPage
	{
		public XamlBrowserPage(string xaml)
		{
			InitializeComponent();
			this.CreateToolBarItem();

			label.Text = xaml;

			browserButton.Clicked += (sender, e) => { Navigation.PopModalAsync();};
		}
	}
}
