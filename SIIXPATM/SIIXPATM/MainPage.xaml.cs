
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SIIXPATM.WebServices;
using SIIXPATM.NewFolder;
using SIIXPATM.Vistas;
using SIIXPATM.NewFolder;

using SIIXPATM.Modelos;
using SIIXPATM.Vistas;
namespace SIIXPATM
{
	public partial class MainPage : ContentPage
	{
        private Entry txtemail, txtPassword;
        private ActivityIndicator aiIndicator;
        private Button btnLogin;
        private Image imgLogo;
        private Label lblLogin;
        private StackLayout stkLogin;
        private RelativeLayout rlLogin;
        Login login = new Login();
        public MainPage()
		{
            Settings.Settings.host = "http://192.168.56.1:3000";

            //InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);  //eliminar barra de navegación

            Padding = new Thickness(15);
            BackgroundColor = Color.FromHex("#BBFFFF");
            imgLogo = new Image
            {
                Source = "Icon.png",
            };
            txtemail = new Entry
            {
                Placeholder = "email",
                PlaceholderColor = Color.SlateBlue,
                HorizontalTextAlignment = TextAlignment.Center,
               // HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.Black,

             };
            txtPassword = new Entry
            {
                IsPassword = true,
                Placeholder = "Contraseña",
                PlaceholderColor = Color.SlateBlue,
                HorizontalTextAlignment = TextAlignment.Center,
                //HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.Black,
        
            };
            btnLogin = new Button
            {
                Text = "Login",
                BackgroundColor = Color.FromHex("#80ffe5"),
                BorderColor = Color.FromHex("#b3f0ff"),
                BorderWidth =3,
                CornerRadius = 30,
                TextColor=Color.Black,
            };
            lblLogin = new Label
            {
                Text = "Powered by Mike",
                FontSize = 15,
                TextColor = Color.FromHex("#003399"),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            btnLogin.Clicked += BtnLogin_CLicked;
            aiIndicator = new ActivityIndicator
            {
                HorizontalOptions = LayoutOptions.Center,
            };
            stkLogin = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HeightRequest = 500,
                WidthRequest=400,
                HorizontalOptions = LayoutOptions.Center,
                Children =
            {
            imgLogo,
            txtemail,
            txtPassword,
            aiIndicator,
            btnLogin
            }
            };
            rlLogin = new RelativeLayout();
            rlLogin.Children.Add(
                stkLogin,
                Constraint.RelativeToParent((parent)=> { return 0; }), //valor para posicion de x apartir del layout
                Constraint.RelativeToParent((parent) => { return parent.Height *.10; }), //valor para posicion de Con un cuarto del tamaño total del padre
                Constraint.RelativeToParent((parent) => { return parent.Width; }), //valor para posicion de x apartir del layout
                Constraint.RelativeToParent((parent) => { return parent.Width; }) //valor para posicion de x apartir del layout
                );
            rlLogin.Children.Add(
                lblLogin,
                Constraint.RelativeToParent((parent) => { return 0; }), //valor para posicion de x apartir del layout
                Constraint.RelativeToView(stkLogin,(parent,view) => { return view.Y+view.Height + 80 ; }), //valor para posicion de Con un cuarto del tamaño total del padre
                Constraint.RelativeToParent((parent) => { return parent.Width; }), //valor para posicion de x apartir del layout
                Constraint.RelativeToParent((parent) => { return parent.Width; }) //valor para posicion de x apartir del layout
                );
            Content = rlLogin;
        }
        private async void BtnLogin_CLicked(Object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtemail.Text))
            {
                await DisplayAlert("Error", "Debes introducir un usuario", "Aceptar");
                txtemail.Focus();
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
               await DisplayAlert("Error", "Debes introducir un password", "Aceptar");
                txtemail.Focus();
            }
            aiIndicator.IsRunning = true;
            try
            {
                WsLogin objWSL = new WsLogin();
                Usuarios result = await objWSL.conexion(txtemail.Text,txtPassword.Text);
                //DisplayAlert("Error", result, "Aceptar");
                if(result.Equals("Acceso denegado"))
                {
                    await DisplayAlert("Error", "Acceso denegado", "Aceptar");
                    aiIndicator.IsRunning = false ;
                }
                else
                {
                    await DisplayAlert("Correcto", "Acceso correcto", "Aceptar "+ Settings.Settings.rol);
                    aiIndicator.IsRunning = false;
                    
                    if(Settings.Settings.rol.Equals("Alumno"))
                     {
                        WSAlumno objWSA = new WSAlumno();
                        Alumno result2 = await objWSA.getAlumno(txtemail.Text);
                        Console.Write("este es el emmail del alumno "+ result2.nocont);

                        Settings.Settings.nocont = result2.nocont;

                        await Navigation.PushModalAsync(new DashBoardAlumno());
                    }else
                    {
                        WSMaestro objWSM = new WSMaestro();
                        Maestro result3 = await objWSM.getMaestro(txtemail.Text);
                        Console.Write("este es el emmail del maestro " + result3.cvemae);
                        await DisplayAlert("Correcto", "Acceso correcto", "cvemae" + result3.cvemae);

                        Settings.Settings.cvemae = result3.cvemae;
                        await Navigation.PushModalAsync(new DashBoardMaestro());

                    }


                }

            }
            catch (Exception) { }
            
        }

    }
}




