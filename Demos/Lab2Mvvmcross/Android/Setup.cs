using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using Plateform;
using Core;
using MvvmCross.Platform;

namespace Lab2Mvvmcross.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

		/*30  override InitializeIoC*/
		protected override void InitializeIoC()
		{
			base.InitializeIoC();

			/*31  Register your service*/
			var service = new MessageService(this.ApplicationContext);
			Mvx.RegisterSingleton<IMessageService>(service);
		}
    }
}
