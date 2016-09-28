using System;
using System.Collections.Generic;
using FormsDemo.Services;
using Xamarin.Forms;

namespace FormsDemo
{
	public partial class ButtonPage : ContentPage
	{
		public ButtonPage()
		{
			InitializeComponent();
			this.CreateToolBarItem();
            var messageService = DependencyService.Get<IMessageService>();
            
			button.Clicked += (sender, e) => 
			{
                messageService.DisplayMessage("Alert", "Button Clicked!!");
			};
		}
	}
}
