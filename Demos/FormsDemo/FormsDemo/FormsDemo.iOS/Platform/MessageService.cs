using FormsDemo.iOS.Platform;
using FormsDemo.Services;

[assembly: Xamarin.Forms.Dependency(typeof(MessageService))]
namespace FormsDemo.iOS.Platform
{
    public class MessageService : IMessageService
    {
        public void DisplayMessage(string title, string message)
        {
            var alert = new UIKit.UIAlertView(title, message, null, "OK", new string[] { "Cancel" });
            alert.Show();
        }
    }
}
