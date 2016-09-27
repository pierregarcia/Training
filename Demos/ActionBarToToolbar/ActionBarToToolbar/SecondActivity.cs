using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace ActionBarToToolbar
{
	[Activity(Label = "Second Activity")]
	/*8 Change Minimum version to less than 21, then run on Device < 21. See Errors*/
	/*9 Add Nuget Package Xamarin Android support v7 AppCompat*/
	/*10 Change Toolbar Layout and Styles*/
	/*11 Use AppCompatActivity and import using (ToolBar)*/
	public class SecondActivity : AppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Second);

			/*3 Create New Activity, Include Toolbar in Layout Then Use it*/
			var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
			//SetActionBar(toolbar);


			//ActionBar.Title = this.Title;

			///*4 Back to Main Activity*/
			//ActionBar.SetDisplayHomeAsUpEnabled(true);
			//ActionBar.SetHomeButtonEnabled(true);

			/*12 Setup New Toolbar then Deploy on 19*/
			SetSupportActionBar(toolbar);
			SupportActionBar.Title = this.Title;
			SupportActionBar.SetDisplayHomeAsUpEnabled(true);
			SupportActionBar.SetHomeButtonEnabled(true);

			/*13 Change showAction in menu to show them*/
		}

		public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
		{
			/*5 Action for Home Button Pressed*/
			if (item.ItemId == Android.Resource.Id.Home)
			{
				this.Finish();
			}

			/*7 add menu layout (folder, layout, then deal with clicks)*/
			Toast.MakeText(this, "Action selected: " + item.TitleFormatted, ToastLength.Short).Show();

			return base.OnOptionsItemSelected(item);
		}

		public override bool OnCreateOptionsMenu(Android.Views.IMenu menu)
		{
			/*6 Use created View*/
			MenuInflater.Inflate(Resource.Menu.toolbar_menu, menu);
			return base.OnCreateOptionsMenu(menu);
		}
	}
}
