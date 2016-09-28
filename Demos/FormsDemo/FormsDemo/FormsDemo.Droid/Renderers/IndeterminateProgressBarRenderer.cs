using System;
using FormsDemo;
using FormsDemo.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(IndeterminateProgressBar), typeof(IndeterminateProgressBarRenderer))]
namespace FormsDemo.Droid
{
	public class IndeterminateProgressBarRenderer: ProgressBarRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ProgressBar> e)
		{
			base.OnElementChanged(e);

			var customProgressBar = (IndeterminateProgressBar)Element;

			Control.Indeterminate = customProgressBar.Indeterminate;
			Control.IndeterminateDrawable.SetColorFilter(Resources.GetColor(Android.Resource.Color.HoloRedDark), Android.Graphics.PorterDuff.Mode.SrcIn);
		}
	}
}