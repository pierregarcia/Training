using System;
using System.Reactive.Linq;
using System.Threading;
using FormsDemo;
using FormsDemo.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(IndeterminateProgressBar), typeof(IndeterminateProgressBarRenderer))]
namespace FormsDemo.iOS.Renderers
{
    public class IndeterminateProgressBarRenderer: ProgressBarRenderer
    {

        private IDisposable _subscription;

        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            base.OnElementChanged(e);
            var customProgressBar = (IndeterminateProgressBar)Element;
            if (Control != null && customProgressBar != null)
            {
                Control.ProgressTintColor = customProgressBar.ProgressColor.ToUIColor();
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals("Renderer", StringComparison.OrdinalIgnoreCase))
            {
                if (_subscription != null)
                {
                    _subscription.Dispose();
                    _subscription = null;
                }
                else
                {
                    _subscription = Observable
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
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (_subscription != null)
            {
                _subscription.Dispose();
            }
        }
    }
}