using System;
using Android.Content;
using Android.Widget;
using FormsDemo.Droid.Platform;
using FormsDemo.Services;

[assembly: Xamarin.Forms.Dependency(typeof(MessageService))]
namespace FormsDemo.Droid.Platform
{
    public class MessageService : IMessageService
    {
        public void DisplayMessage(string title, string message)
        {
            var alert = Toast.MakeText(Android.App.Application.Context, $"{title}{Environment.NewLine}{message}", ToastLength.Long);
            alert.Show();
        }
    }
}
