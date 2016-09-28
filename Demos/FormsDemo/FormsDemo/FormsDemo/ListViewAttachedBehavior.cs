using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace FormsDemo
{
	public static class ListViewAttachedBehavior
	{
		#region Command
		public static readonly BindableProperty CommandProperty =
			BindableProperty.CreateAttached(
				"Command",
				typeof(ICommand),
				typeof(ListViewAttachedBehavior),
				null,
				propertyChanged: OnCommandChanged);

		static void OnCommandChanged(BindableObject view, object oldValue, object newValue)
		{
			var listView = view as ListView;
			if (listView == null)
				return;

			listView.ItemTapped += (sender, e) =>
				{
					var command = (newValue as ICommand);
					if (command == null)
						return;

					if (command.CanExecute(e.Item))
					{
						command.Execute(e.Item);
					}

				};
		}
		#endregion
		#region DisableSelection
		public static readonly BindableProperty IsSelectionEnabledProperty =
			BindableProperty.CreateAttached(
				"IsSelectionEnabled",
				typeof(bool),
				typeof(ListViewAttachedBehavior),
				true,
				propertyChanged: OnIsSelectionEnabledChanged);

		static void OnIsSelectionEnabledChanged(BindableObject view, object oldValue, object newValue)
		{
			var listView = view as ListView;
			if (listView == null)
				return;

			var isEnabled = (newValue as bool?).GetValueOrDefault(true);


			if (isEnabled)
				return;

			listView.ItemSelected += (sender, e) =>
				{
				   //Disable selection -- https://developer.xamarin.com/guides/xamarin-forms/user-interface/listview/interactivity/
				   ((ListView)sender).SelectedItem = null;
				};
		}
		#endregion
	}
}