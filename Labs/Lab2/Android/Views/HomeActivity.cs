using Android.Content;
using Android.App;
using Android.OS;
using Android.Widget;
using Android.Views;

namespace Lab2
{
	[Activity(Label = "Home")]
	public class HomeActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Create your application here
			SetContentView(Resource.Layout.View_Home);

			if (this.Intent != null
				&& this.Intent.Extras.ContainsKey(Intent.ExtraText))
			{
				var user = this.Intent.Extras.GetString(Intent.ExtraText);
				var alert = Toast.MakeText(this, string.Format("Hello {0}!", user), ToastLength.Long);
				alert.Show();
			}
			var places = new Place[]
			{
				new Place{ Name = "Hotel Contoso", Description="Charming hotel for newly married couples.", Icon="Icon.png" },
				new Place{ Name = "Restaurant Contoso", Description="First gluten free restaurant", Icon="Icon.png" },
				new Place{ Name = "Supermarket Contoso", Description="Save Money. Live Better.", Icon="Icon.png" }
			};

			var placeList = FindViewById<ListView>(Resource.Id.placesList);
			placeList.Adapter = new PlaceAdapter(this, places);
			placeList.ItemClick += (sender, e) =>
			{
				var alert = Toast.MakeText(this, places[e.Position].Name, ToastLength.Long);
				alert.Show();
			};
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