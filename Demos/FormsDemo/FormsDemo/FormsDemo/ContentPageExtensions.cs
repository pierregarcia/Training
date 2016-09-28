using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace FormsDemo
{
	public static class ContentPageExtensions
	{
		public static void CreateToolBarItem(this ContentPage page)
		{
			page.ToolbarItems.Add(new ToolbarItem
			{
				Command = new Command(() => { BrowseSource(page);}),
				Text = "Browse Source",
				Priority = 0
			});
		}
        async static void BrowseSource(ContentPage page)
		{
			string xamlPage = "FormsDemo.Pages." + page.GetType().Name + ".xaml";
			Assembly assembly = page.GetType().GetTypeInfo().Assembly;

			using (Stream stream = assembly.GetManifestResourceStream(xamlPage))
			{
				using (StreamReader reader = new StreamReader(stream))
				{
					string xaml = reader.ReadToEnd();
					await page.Navigation.PushModalAsync(new XamlBrowserPage(xaml));
				}
			}
		}
	}
}
