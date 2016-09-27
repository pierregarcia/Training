using System;
using Android.Content;
using Android.Widget;
using Core;

namespace Plateform
{
	/*27 Create Message Service implementation for Android*/
	public class MessageService : IMessageService
	{
		/*28 Give the context needed for Toast inside the CTOR*/
		Context _context;
		public MessageService(Context context)
		{
			_context = context;
		}

		public void DisplayMessage(string title, string message)
		{
			/*29 Create the Toast*/
			var alert = Toast.MakeText(_context, $"{title}{Environment.NewLine}{message}", ToastLength.Long);
			alert.Show(); ;
		}
	}
}
