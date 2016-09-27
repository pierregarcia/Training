
using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Core;
using Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Views;

namespace Lab2Mvvmcross.Droid
{
	/*1 Add Nuget Package Mvvmcross starter pack*/
	/*2 Show FirtView, Setup, SplashScreen, DebugTrace, Linker*/
	/*3 Create Core Project (PCL Library)*/
	/*4 Add Nuget Package Mvvmcross starter pack in Core*/
	/*5 Show FirstViewModel and App*/
	/*6 Reference Core in Android*/
	/*7 Remove MainLauncher and Start App with FirstVM*/
	/*8 Change LoginActivity to MvxActivity*/
	/*9 Add Login View Model*/
	/*10 Change App.cs to Run LoginActivity*/
	/*11 Remove First View and VM*/
	[Activity(Label = "@string/app_name")]
	public class LoginActivity : MvxActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.View_Login);

			var txtPassword = FindViewById<EditText>(Resource.Id.userPassword);

			var set = this.CreateBindingSet<LoginActivity, LoginViewModel>();

			set.Bind(txtPassword)
			   .For(v => v.Text)
			   .To(vm => vm.Password);
			
			set.Apply();

			//var loginBt = FindViewById<Button>(Resource.Id.loginBt);
			//loginBt.Click += Login;
		}

		void Login(object sender, EventArgs e)
		{
			var txtUsername = FindViewById<EditText>(Resource.Id.userName);
			var txtPassword = FindViewById<EditText>(Resource.Id.userPassword);

			//if ("user".Equals(txtUsername.Text)
			//	&& "password".Equals(txtPassword.Text))
			//{
			//	var intent = new Intent(this, typeof(HomeActivity));
			//	intent.PutExtra(Intent.ExtraText, txtUsername.Text);
			//	StartActivity(intent);
			//}
			//else
			//{
			//	var alert = Toast.MakeText(this, Resource.String.AuthError_Message, ToastLength.Long);
			//	alert.Show();
			//}
		}
	}
}

