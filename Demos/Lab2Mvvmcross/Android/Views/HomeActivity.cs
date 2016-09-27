using Android.Content;
using Android.App;
using Android.OS;
using Android.Widget;
using Android.Views;
using MvvmCross.Droid.Views;
using Core;

namespace Lab2Mvvmcross.Droid
{
	[Activity(Label = "Home")]
	public class HomeActivity : MvxActivity
	{
		/*20 Change ListView to MvxListView*/
		/*21 Add Local in View_Home*/
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Create your application here
			SetContentView(Resource.Layout.View_Home);

			//var places = new Place[]
			//{
			//	new Place{ Name = "Hotel Contoso", Description="Charming hotel for newly married couples.", Icon="Icon.png" },
			//	new Place{ Name = "Restaurant Contoso", Description="First gluten free restaurant", Icon="Icon.png" },
			//	new Place{ Name = "Supermarket Contoso", Description="Save Money. Live Better.", Icon="Icon.png" }
			//};

			/*22 Use MvxItemTemplate in MvxListView ans Remove Adapter and ItemClick from here*/
			//var placeList = FindViewById<ListView>(Resource.Id.placesList);
			//placeList.Adapter = new PlaceAdapter(this, places);
			//placeList.ItemClick += (sender, e) =>
			//{
			//	var alert = Toast.MakeText(this, places[e.Position].Name, ToastLength.Long);
			//	alert.Show();
			//};
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.home_menu, menu);
			return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnMenuItemSelected(int featureId, IMenuItem item)
		{
			switch (item.ItemId)
			{
				case Resource.Id.refreshHome:
					var alert = Toast.MakeText(this, "Refreshing...", ToastLength.Long);
					alert.Show();
					break;
			}
			return base.OnMenuItemSelected(featureId, item);
		}
	}
}