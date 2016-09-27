using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace FormsDemo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			var controlsSection = new Section("Xamarin Forms Controls", "Controls")
			{
				new Item("Image", (ContentPage)new ImagePage()),
				new Item("Label", (ContentPage)new LabelPage()),
				new Item("List View", (ContentPage)new ListViewPage()),
				new Item("Picker", (ContentPage)new PickerPage()),
				new Item("Progress Bar", (ContentPage)new ProgressBarPage()),
				new Item("Search Bar", (ContentPage)new SearchBarPage()),
				new Item("Stepper", (ContentPage)new StepperPage()),
				new Item("Activity Indicator", (ContentPage)new ActivityIndicatorPage()),
				new Item("Box View", (ContentPage)new BoxViewPage()),
				new Item("Button", (ContentPage)new ButtonPage()),
				new Item("Editor", (ContentPage)new EditorPage()),
				new Item("Time Picker", (ContentPage)new TimePickerPage()),
				new Item("Web View", (ContentPage)new WebViewPage()),
				new Item("Switch", (ContentPage)new SwitchPage()),
			};
			var layoutSection = new Section("Xamarin Forms Layouts", "Layouts")
			{
				new Item("Stack Layout", (ContentPage)new LayoutStackLayoutPage()),
				new Item("Absolute Layout", (ContentPage)new LayoutAbsoluteLayoutPage()),
				new Item("Relative Layout", (ContentPage)new LayoutRelativeLayoutPage()),
				new Item("Grid", (ContentPage)new LayoutGridPage()),
			};


			var grouppedItems = new ObservableCollection<Section>()
			{
				controlsSection,
				layoutSection,
			};
			BindingContext = grouppedItems;
		}

		void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e == null) return; // has been set to null, do not 'process' tapped event
			Debug.WriteLine("Selected: " + e.SelectedItem);
			((ListView)sender).SelectedItem = null; // de-select the row

			var item = e.SelectedItem as Item;
			if (item != null)
			{
				Navigation.PushAsync(item.Page);
			}
		}
	}

	public class Section : ObservableCollection<Item>
	{
		public string Name { get; private set; }
		public string ShortName { get; private set; }

		public Section(string name, string shortName)
		{
			Name = name;
			ShortName = shortName;
		}
	}

	public class Item
	{
		public string Title { get; private set; }
		public ContentPage Page { get; private set; }

		public Item(string name, ContentPage page)
		{
			Title = name;
			Page = page;
		}
	}
}
