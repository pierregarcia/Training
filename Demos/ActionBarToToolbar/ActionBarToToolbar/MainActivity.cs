using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;

namespace ActionBarToToolbar
{
	/*0 Remove Support v7, Change Minimum and Target version to  >= 21*/
	[Activity(Label = "Main Activity", MainLauncher = true, Icon = "@mipmap/icon", 
	          /*1 Add Theme to remove ActionBar.Here or in the Manifest for all activities*/Theme="@style/MyThemeAppCompat")]
	public class MainActivity : AppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.myButton);

			button.Click += (sender, e) =>
			{
				StartActivity(typeof(SecondActivity));
			};

			/*2 Create ToolBar Layout, Include it and Use it*/

			var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
			SetSupportActionBar(toolbar);

			SupportActionBar.Title = this.Title;
		}
	}
}

