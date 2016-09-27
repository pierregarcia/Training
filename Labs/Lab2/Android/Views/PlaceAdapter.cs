using System;
using Android.App;
using Android.Views;
using Android.Widget;

namespace Lab2
{
	public class PlaceAdapter : BaseAdapter
	{
		Place[] _places;
		Activity _context;

		public PlaceAdapter(Activity context, Place[] places)
		{
			_context = context;
			_places = places;
		}

		#region implemented abstract members of BaseAdapter
		public override Java.Lang.Object GetItem(int position)
		{
			return (Java.Lang.Object)(object)_places[position];
		}
		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView;
			var place = _places[position];

			if (view == null)
			{
				view = _context.LayoutInflater.Inflate(Resource.Layout.PlaceItemView, null);
			}

			view.FindViewById<TextView>(Resource.Id.txtName).Text = place.Name;
			view.FindViewById<TextView>(Resource.Id.txtDescription).Text = place.Description;
			view.FindViewById<ImageView>(Resource.Id.iconView).SetImageResource(Resource.Drawable.Icon);

			return view;
		}

		public override int Count
		{
			get
			{
				return _places.Length;
			}
		}
		#endregion
	}

}