using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace FormsDemo
{
	public partial class ListViewPage : ContentPage
	{
		public ListViewPage()
		{
			InitializeComponent();
			this.CreateToolBarItem();

			BindingContext = new[] { "a", "b", "c" };
		}

		void OnItemTapped(object sender, ItemTappedEventArgs e)
		{
			if (e == null) return; // has been set to null, do not 'process' tapped event
			Debug.WriteLine("Tapped: " + e.Item);
			((ListView)sender).SelectedItem = null; // de-select the row
		}
	}
}
