using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FormsDemo
{
	public partial class MasterPage : ContentPage
	{
		public ListView ListView { get { return listView; } }

		public MasterPage()
		{
			InitializeComponent();
			this.CreateToolBarItem();
			
			listView.ItemsSource = PageItem.All;
		}
	}
}
