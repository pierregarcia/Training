using System;
using System.Diagnostics;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace Core.ViewModels
{
	/*12 Add Properties in VM for login*/
	/*15 Bind Properties to view (show two way)
		 Add Local in View, Bind in View
		 Bind In Activity
		 Run and Pu breakpoint inside properties*/
	public class LoginViewModel : MvxViewModel
	{
		private readonly IMessageService _messageService;

		/*32  Give the Service to the View Model*/
		public LoginViewModel(IMessageService messageService)
		{
			_messageService = messageService;
		}

		private string _username;
		public string Username
		{
			get
			{
				return _username;
			}
			set
			{
				/*13 Set Property*/
				SetProperty(ref _username, value);
			}
		}

		private string _password;
		public string Password
		{
			get
			{
				return _password;
			}
			set
			{
				/*14 RaisePropertyChanged*/
				_password = value;
				RaisePropertyChanged();
			}
		}

		/*16 Create the HomeVm and change the Home Activity*/
		/*17 Create a Command for the Login, Then Bind it and remove it from Activity*/
		public ICommand DoLogin
		{
			get 
			{
				return new MvxCommand(() =>
				{
					if ("user".Equals(Username) && "password".Equals(Password))
					{
						/*18 Navigate With MvvmCross to Home*/
						//ShowViewModel<HomeViewModel>();

						/*19 Send Data when Navigating and remove Intent*/
						ShowViewModel<HomeViewModel>(new { name = Username});
					}
					else
					{
						/*33 Use the Service*/
						_messageService.DisplayMessage("Authentication Error", "Invalid Username or Password");
						Debug.WriteLine($"Error password [{Password}] user [{Username}]");
					}
				});
			}
		}

	}
}
