
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
	[Activity(Label = "CustomAdapterActivity"/**/, MainLauncher = true)]
	/*15 Create New Activity and New View for using ListView Control With Custom Row*/
	public class CustomAdapterActivity : Activity
	{
		List<string> _vegetables;
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			/*16  SetContentView*/
			SetContentView(Resource.Layout.CustomLayout);
			/*17  Get ListView*/
			var listView = FindViewById<ListView>(Resource.Id.listView);

			/*18  Create long Data*/
			_vegetables = new List<string> { "Beet greens",
				"Bitterleaf", "Bok choy",
				"Broccoli Rabe","Brussels sprout",
				"Cabbage", "Catsear",
				"Celery", "Celtuce",
				"Ceylon spinach", "Chard",
				"Chaya", "Chickweed",
				"Chicory", "Chinese cabbage",
				"Dandelion", "Endive",
				"Epazote", "Kale",
				"Kuka", "Mustard",
				"Orache", "Paracress",
				"Poke", "Radicchio",
				"Samphire", "Soko",
				"Sorrel", "Spinach"
			};
			var copy = _vegetables.Select(v => v + " 1").ToArray();
			_vegetables.AddRange(copy);

			_vegetables.Sort((x, y) => { return x.CompareTo(y); });

			/*22 Create and Set the Adapter to the listview*/
			listView.Adapter = new MySectionAdapter(this, _vegetables.ToArray());
			listView.ChoiceMode = Android.Widget.ChoiceMode.Single; //very important for selection to work

			/*24 Enable Fast Scrolling then run*/
			listView.FastScrollEnabled = true;

			/*23 Deal with Item ClickThen Run the app*/
			listView.ItemClick += (sender, e) =>
			{
				var vegetable = _vegetables[e.Position];
				Toast.MakeText(this, vegetable, ToastLength.Short).Show();
			};
		}
	}
	/*19 Create Custom Adapter (no section for now, Same as MyAdapter)*/
	public class MySectionAdapter : BaseAdapter<string>, ISectionIndexer
	{
		string[] _data;
		Activity _context;

		/*26 If time show custom Fast Scrolling (ISectionIndexer + Sections + ctor)*/
		string[] _sections;
		Java.Lang.Object[] _sectionsObjects;
		Dictionary<string, int> _alphaIndex;

		public MySectionAdapter(Activity context, string[] data) : base()
		{
			_context = context;
			_data = data;

			//Create a Dictionary Where Key=FirstLetter and Value=LetterFirstPosition
			_alphaIndex = new Dictionary<string, int>();
			for (int i = 0; i < data.Length; i++)
			{
				var key = data[i][0].ToString();
				if (!_alphaIndex.ContainsKey(key))
					_alphaIndex.Add(key, i);
			}
			//Create a array of string with the Letters
			_sections = _alphaIndex.Select(ai => ai.Key).ToArray();

			//Create a array of Java Objects with the First Letters Group
			_sectionsObjects = new Java.Lang.Object[_sections.Length];
			for (int i = 0; i < _sections.Length; i++)
			{
				_sectionsObjects[i] = new Java.Lang.String(_sections[i]);
			}
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override string this[int position]
		{
			get { return _data[position]; }
		}
		public override int Count
		{
			get { return _data.Length; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView;
			if (view == null)
			{
				/*20 Use Cutom Row Layout)*/
				view = _context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);

				/*25 Implemet View Holder for Performance (Create Class also)*/
				//var viewHolder = new MyViewHolder();
				//viewHolder.TextView = view.FindViewById<TextView>(Android.Resource.Id.Text1);
				//view.Tag = viewHolder;
			}
			//var holder = (MyViewHolder)view.Tag;
			//holder.TextView.Text = _data[position];

			/*21 Get View inside Layout*/
			view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = _data[position];
			return view;
		}

		// -- ISectionIndexer --
		public int GetPositionForSection(int section)
		{
			return _alphaIndex[_sections[section]];
		}

		public int GetSectionForPosition(int position)
		{      // this method isn't called in this example, but code is provided for completeness
			int prevSection = 0;

			for (int i = 0; i < _sections.Length; i++)
			{
				if (GetPositionForSection(i) > position)
				{
					break;
				}

				prevSection = i;
			}

			return prevSection;
		}

		public Java.Lang.Object[] GetSections()
		{
			return _sectionsObjects;
		}
	}
}
