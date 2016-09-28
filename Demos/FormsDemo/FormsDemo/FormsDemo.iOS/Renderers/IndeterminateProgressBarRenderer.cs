using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Reactive.Linq;
using UIKit;
using System.Reactive.Concurrency;
using System.Threading;
using FormsDemo;
using FormsDemo.iOS;

[assembly: ExportRenderer(typeof(IndeterminateProgressBar), typeof(IndeterminateProgressBarRenderer))]
namespace Vingo.iOS.Renderers
{
    public class IndeterminateProgressBarRenderer : ProgressBarRenderer
    {

        private IDisposable subscription;

        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            base.OnElementChanged(e);
            var customProgressBar = (IndeterminateProgressBar)Element;
            if (Control != null && IndeterminateProgressBar != null)
            {
                Control.ProgressTintColor = customProgressBar.ProgressColor.ToUIColor();
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "IsVisible")
            {
                if (Element.IsVisible)
                {
                    subscription = Observable
                        .Interval(TimeSpan.FromMilliseconds(25))
                        .ObserveOn(SynchronizationContext.Current)
                        .Subscribe(
                            x =>
                            {
                                if (Control.Progress >= 1.0f)
                                {
                                    Control.Progress = 0.0f;
                                }
                                else
                                {
                                    Control.Progress = Control.Progress + 0.0125f;
                                }
                            }
                        );
                }
                else
                {
                    if (subscription != null)
                    {
                        subscription.Dispose();
                        subscription = null;
                    }
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (subscription != null)
            {
                subscription.Dispose();
            }
        }
    }
}