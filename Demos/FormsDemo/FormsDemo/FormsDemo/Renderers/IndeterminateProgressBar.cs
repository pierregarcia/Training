using System;
using Xamarin.Forms;

namespace FormsDemo
{
	public class IndeterminateProgressBar : ProgressBar
	{
		public static readonly BindableProperty IndeterminateProperty = BindableProperty.Create(
		  "Indeterminate", typeof(bool), typeof(IndeterminateProgressBar), false, BindingMode.OneWay);

		public static readonly BindableProperty ProgressColorProperty = BindableProperty.Create(
			"ProgressColor", typeof(Color), typeof(IndeterminateProgressBar), Color.Red);

		public IndeterminateProgressBar()
		{
		}

		public bool Indeterminate
		{
			get
			{
				return (bool)GetValue(IndeterminateProperty);
			}
			set
			{
				SetValue(IndeterminateProperty, value);
			}
		}

		public Color ProgressColor
		{
			get
			{
				return (Color)GetValue(ProgressColorProperty);
			}
			set
			{
				SetValue(ProgressColorProperty, value);
			}
		}
	}
}