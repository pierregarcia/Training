using System;
using FormsDemo.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("MyCompany")]
[assembly: ExportEffect(typeof(FocusEffect), "FocusEffect")]
namespace FormsDemo.Droid
{
	public class FocusEffect : PlatformEffect
	{
		Android.Graphics.Color _backgroundColor;

		protected override void OnAttached()
		{
			try
			{
				_backgroundColor = Android.Graphics.Color.Blue;
				if (Control is Android.Widget.ProgressBar)
				{
					var progress = (Android.Widget.ProgressBar)Control;
					progress.Indeterminate = true;
				}
				else if (Element is Entry)
				{
					Control.SetBackgroundColor(_backgroundColor);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
			}
		}

		protected override void OnDetached()
		{
		}

		protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
		{
			base.OnElementPropertyChanged(args);
			try
			{
				if (Element is Entry)
				{
					if (args.PropertyName == "IsFocused")
					{
						if (((Android.Graphics.Drawables.ColorDrawable)Control.Background).Color == _backgroundColor)
						{
                            Control.SetBackgroundColor(Android.Graphics.Color.Black);
                            if (Control is Android.Widget.EditText)
                            {
                                ((Android.Widget.EditText)Control).SetTextColor(Android.Graphics.Color.White);
                            }
						}
						else 
                        {
							Control.SetBackgroundColor(_backgroundColor);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
			}
		}
	}
}
