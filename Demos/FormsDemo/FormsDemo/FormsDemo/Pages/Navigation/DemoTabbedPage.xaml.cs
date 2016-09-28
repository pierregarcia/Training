using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FormsDemo
{
	public partial class DemoTabbedPage : TabbedPage
	{
		public DemoTabbedPage()
		{
			InitializeComponent();

			ItemsSource = PageItem.All;
		}
	}
}
