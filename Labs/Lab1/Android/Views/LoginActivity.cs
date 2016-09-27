
using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace Lab1
{
	[Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@mipmap/icon")]
	public class LoginActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.View_Login);

			var loginBt = FindViewById<Button>(Resource.Id.loginBt);
			loginBt.Click += Login;
		}

		void Login(object sender, EventArgs e)
		{
			var txtUsername = FindViewById<EditText>(Resource.Id.userName);
			var txtPassword = FindViewById<EditText>(Resource.Id.userPassword);

			if ("user".Equals(txtUsername.Text)
				&& "password".Equals(txtPassword.Text))
			{
				var intent = new Intent(this, typeof(HomeActivity));
				intent.PutExtra(Intent.ExtraText, txtUsername.Text);
				StartActivity(intent);
			}
			else
			{
				var alert = Toast.MakeText(this, Resource.String.AuthError_Message, ToastLength.Long);
				alert.Show();
			}
		}
	}
}

