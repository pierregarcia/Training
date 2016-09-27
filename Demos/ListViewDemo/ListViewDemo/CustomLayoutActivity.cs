
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ListViewDemo
{
	[Activity(Label = "CustomLayoutActivity"/*, MainLauncher = true*/)]
	/*6 Create New Activity and New View for using ListView Control With Android Adapter*/
	public class CustomLayoutActivity : Activity
	{
		List<string> _names;
		
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			/*7 don't forget SetContentView*/
			SetContentView(Resource.Layout.CustomLayout);

			/*8 Get your ListView */
			var listView = FindViewById<Android.Widget.ListView>(Resource.Id.listView);

			/*9 Create Data*/
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

			/*10 Create the Row Layout*/
			//CustomRowLayout with a TextView

			/*12 Create and Set the Adapter to the listview*/
			listView.Adapter = new MyAdapter(this, _names.ToArray());
			listView.ChoiceMode = Android.Widget.ChoiceMode.Single; //very important for selection to work

			/*13 Deal with Item Click*/
			listView.ItemClick += (sender, e) =>
			{
				var name = _names[e.Position];
				Android.Widget.Toast.MakeText(this, name, Android.Widget.ToastLength.Short).Show();
			};
		}

		protected override void OnResume()
		{
			base.OnResume();
			FindViewById<ListView>(Resource.Id.listView).SetItemChecked(1, true);
		}

		/*11 Create a custom Adapter implementing the Row Layout*/
		private class MyAdapter : BaseAdapter
		{
			string[] _data;
			Activity _context;

			public MyAdapter(Activity context, string[] data)
			{
				_context = context;
				_data = data;
			}

			public override Java.Lang.Object GetItem(int position)
			{
				return _data[position];
			}

			public override long GetItemId(int position)
			{
				return position;
			}

			public override View GetView(int position, View convertView, ViewGroup parent)
			{
				var view = convertView;

				if (view == null)
				{
					view = _context.LayoutInflater.Inflate(Resource.Layout.CustomRowLayout, null);
				}
				view.FindViewById<TextView>(Resource.Id.myTextView).Text = _data[position];

				return view;
			}

			public override int Count
			{
				get
				{
					return _data.Length;
				}
			}
		}
	}
}
