using System;
using System.Diagnostics;
using MvvmCross.Core.ViewModels;

namespace Core
{
	public class HomeViewModel : MvxViewModel
	{
		private string _username;
		readonly IMessageService _messageService;

		public HomeViewModel(IMessageService messageService)
		{
			_messageService = messageService;
		}

		/*19bis Receive Navigation Data*/
		public void Init(string name)
		{
			_username = name;
			Debug.WriteLine($"Received user [{_username}]");
			_messageService.DisplayMessage("User Logged", _username);
			
			Places = new Place[]
			{
				new Place{ Name = "Hotel Contoso", Description="Charming hotel for newly married couples.", Icon="icon" },
				new Place{ Name = "Restaurant Contos", Description="First gluten free restaurant", Icon="icon" },
				new Place{ Name = "Supermarket Contoso", Description="Save Money. Live Better.", Icon="icon" }
			};
		}

		/*23 Move Model folder inside Core Project*/
		/*24 Create Places Property and use it in View_Home (REmove Adapter in View)*/
		/*25 Change ItemView with bindings*/
		public Place[] Places{ get; set; }

		/*34 Implement ItemClick Command ans Use It in View*/
		public IMvxCommand SeePlace
		{
			get
			{
				/*35 Command to get the Item Selected (<Place>)*/
				return new MvxCommand<Place>(place =>
				   {
						_messageService.DisplayMessage("Selection", place.Name);
				   });
			}
		}
	}
}
