using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FormsDemo
{
	public partial class ProgressBarPage : ContentPage
	{
		public ProgressBarPage()
		{
			InitializeComponent();
			this.CreateToolBarItem();
		}
		protected async override void OnAppearing()
		{
			base.OnAppearing();
			// animate the progression to 80%, in 250ms
			await progressBar.ProgressTo(.8, 2000, Easing.Linear);
		}
		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			progressBar.Progress = 0.1;
		}
	}
}
