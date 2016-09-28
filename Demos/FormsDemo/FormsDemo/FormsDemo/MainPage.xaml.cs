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
				new Item("Image", new ImagePage(){Title = "Image"}),
				new Item("Label", new LabelPage(){Title = "Label"}),
				new Item("List View", new ListViewPage(){Title = "List View"}),
				new Item("Picker", new PickerPage(){Title = "Picker"}),
				new Item("Progress Bar", new ProgressBarPage(){Title = "Progress Bar"}),
				new Item("Search Bar", new SearchBarPage(){Title = "Search Bar"}),
				new Item("Stepper", new StepperPage(){Title = "Stepper"}),
				new Item("Activity Indicator", new ActivityIndicatorPage(){Title = "Activity Indicator"}),
				new Item("Box View", new BoxViewPage(){Title = "Box View"}),
				new Item("Button", new ButtonPage(){Title = "Button"}),
				new Item("Editor", new EditorPage(){Title = "Editor"}),
				new Item("Time Picker", new TimePickerPage(){Title = "Time Picker"}),
				new Item("Web View", new WebViewPage(){Title = "Web View"}),
				new Item("Switch", new SwitchPage(){Title = "Switch"}),
			};
			var layoutSection = new Section("Xamarin Forms Layouts", "Layouts")
			{
				new Item("Stack Layout", new LayoutStackLayoutPage(){Title = "Stack Layout"}),
				new Item("Absolute Layout", new LayoutAbsoluteLayoutPage(){Title = "Absolute Layout"}),
				new Item("Relative Layout", new LayoutRelativeLayoutPage(){Title = "Relative Layout"}),
				new Item("Grid", new LayoutGridPage(){Title = "Grid"}),
				new Item("Scroll View", new LayoutScrollViewPage(){Title = "Scroll View"}),
			};

			var navigationSection = new Section("Xamarin Forms Navigation", "Navigation")
			{
				new Item("Master Detail", new HamburgerPage(){Title="Master Detail"}),
				new Item("Tabbed Page", new DemoTabbedPage(){Title="Tabbed Page"}),
				new Item("Pop Page", new PopNavigationPage(){Title="Navigation Pop"}),
			};

			var bindingSection = new Section("Xamarin Forms Bindings", "Bindings")
			{
				new Item("InterElement Binding", new InterElementBinding(){Title="InterElement Binding"}),
			};

			var othersSection = new Section("Xamarin Forms Customize", "Customize")
			{
				new Item("Effects", new EffectPage(){Title="Effect"}),
				new Item("Renderer", new RendererPage(){Title="Renderer"}),
			};


			var grouppedItems = new ObservableCollection<Section>()
			{
				controlsSection,
				layoutSection,
				navigationSection,
				bindingSection,
				othersSection
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
		public Page Page { get; private set; }

		public Item(string name, Page page)
		{
			Title = name;
			Page = page;
		}
	}
}
