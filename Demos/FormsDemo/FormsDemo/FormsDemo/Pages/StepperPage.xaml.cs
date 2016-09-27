using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FormsDemo
{
	public partial class StepperPage : ContentPage
	{
		public StepperPage()
		{
			InitializeComponent();
			stepper.ValueChanged += OnStepperValueChanged;
		}

		void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
		{
			label.Text = e.NewValue.ToString();
		}
	}
}
