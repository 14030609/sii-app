using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SIIXPATM.Vistas;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace SIIXPATM
{
	public partial class App : Application
	{
		public App ()
		{
		//s	InitializeComponent();

            //			MainPage = new MainPage();
            MainPage = new MasterDetail();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
