using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace ListViewDemo
{
	[Activity(Label = "ListView"/*, MainLauncher = true*/, Icon = "@mipmap/icon")]
	/*1 */
	public class MainActivity : ListActivity/*1 Implement ListActivity */
	{
		List<string> _names;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			/*2 Remove the View for This Activity */
			// Set our view from the "main" layout resource
			//SetContentView(Resource.Layout.Main);


			/*3 Create Data*/
			_names = new List<string> { "matthieu",
				"michel",
				"vincent",
				"christopher",
				"joric",
				"léon",
				"dominique",
				"brian"
			};
			_names.Sort((x, y) => x.CompareTo(y));

			/*4 Set the Adapter. Choose the Template and give the data*/
			ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, _names);
		}

		/*5 override OnListItemClick and deal with clic*/
		protected override void OnListItemClick(Android.Widget.ListView l, Android.Views.View v, int position, long id)
		{
			var name = _names[position];
			Toast.MakeText(this, name, ToastLength.Short).Show();
		}
	}
}