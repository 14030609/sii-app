
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SIIXPATM.NewFolder;
using SIIXPATM.Vistas;
using SIIXPATM.Modelos;
using SIIXPATM.WebServices;
using SIIXPATM.Vistas;
namespace SIIXPATM
{
    public partial class ActualizaDatosAlumno : ContentPage
    {
        private Entry txtTelefono, txtNss,txtDireccion, txtPassword;
        private ActivityIndicator aiIndicator;
        private Button btnActualizar;
        private Image imgLogo;
        private StackLayout stkLogin;
        private RelativeLayout rlLogin;
        Login login = new Login();
        public ActualizaDatosAlumno()
        {
            Settings.Settings.host = "http://192.168.1.74:3000";

            //InitializeComponent();
           // NavigationPage.SetHasNavigationBar(this, false);  //eliminar barra de navegación

            Padding = new Thickness(5);
            BackgroundColor = Color.FromHex("#BBFFFF");
            imgLogo = new Image
            {
                Source = "Icon.png",
            };
            txtTelefono = new Entry
            {
                Placeholder = "Telefono",
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
            txtDireccion = new Entry
            {
                Placeholder = "Direccion",
                PlaceholderColor = Color.SlateBlue,
                HorizontalTextAlignment = TextAlignment.Center,
                // HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.Black,

            };
            txtNss = new Entry
            {
                IsPassword = true,
                Placeholder = "Nss",
                PlaceholderColor = Color.SlateBlue,
                HorizontalTextAlignment = TextAlignment.Center,
                //HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.Black,

            };

            btnActualizar = new Button
            {
                Text = "Actualizar Datos",
                BackgroundColor = Color.FromHex("#80ffe5"),
                BorderColor = Color.FromHex("#b3f0ff"),
                BorderWidth = 3,
                CornerRadius = 30,
                TextColor = Color.Black,
            };

            btnActualizar.Clicked += BtnLogin_CLicked;
            aiIndicator = new ActivityIndicator
            {
                HorizontalOptions = LayoutOptions.Center,
            };
            stkLogin = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HeightRequest = 500,
                WidthRequest = 400,
                HorizontalOptions = LayoutOptions.Center,
                Children =
            {
//            imgLogo,
            txtTelefono,
            txtNss,
            txtDireccion,
            txtPassword,
            aiIndicator,
            btnActualizar
            }
            };
            rlLogin = new RelativeLayout();
            rlLogin.Children.Add(
                stkLogin,
                Constraint.RelativeToParent((parent) => { return 0; }), //valor para posicion de x apartir del layout
                Constraint.RelativeToParent((parent) => { return parent.Height * .10; }), //valor para posicion de Con un cuarto del tamaño total del padre
                Constraint.RelativeToParent((parent) => { return parent.Width; }), //valor para posicion de x apartir del layout
                Constraint.RelativeToParent((parent) => { return parent.Width; }) //valor para posicion de x apartir del layout
                );
            Content = rlLogin;
        }
        private async void BtnLogin_CLicked(Object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                await DisplayAlert("Error", "Debes introducir un telefono", "Aceptar");
                txtTelefono.Focus();
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                await DisplayAlert("Error", "Debes introducir un password", "Aceptar");
                txtPassword.Focus();
            }
            if (string.IsNullOrEmpty(txtNss.Text))
            {
                await DisplayAlert("Error", "Debes introducir un numero de seguro social", "Aceptar");
                txtNss.Focus();
            }
            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                await DisplayAlert("Error", "Debes introducir una direccion", "Aceptar");
                txtDireccion.Focus();
            }

            aiIndicator.IsRunning = true;
            try
            {/*
                WsLogin objWSL = new WsLogin();
                String result = await objWSL.conexion(txtemail.Text, txtPassword.Text);
                //DisplayAlert("Error", result, "Aceptar");
                if (result.Equals("Acceso denegado"))
                {
                    await DisplayAlert("Error", "Acceso denegado", "Aceptar");
                    aiIndicator.IsRunning = false;
                }
                else
                {*/
                    await DisplayAlert("Correcto", "Acceso correcto", "Aceptar " + Settings.Settings.rol);
                    aiIndicator.IsRunning = false;

//                    if (Settings.Settings.rol.Equals("Alumno"))
  //                  {
                        WsLogin objWSA = new WsLogin();
                        Usuarios result2 = await objWSA.conexion(Settings.Settings.email,txtPassword.Text);
                        Console.Write("este es el emmail del alumno " + result2.email);
                        WSActualizarAlumno objWSAc = new WSActualizarAlumno();
                        Boolean result3 = await objWSAc.getKardex(txtPassword.Text,txtTelefono.Text,txtTelefono.Text,txtDireccion.Text,Settings.Settings.email);
                        Console.Write("este es el emmail del result3 " + result3);
                    await DisplayAlert("Correcto", "Acceso correcto", "Aceptar result 3 " + result3);


                    await Navigation.PushModalAsync(new DashBoardAlumno());
                   // }


                //}

            }
            catch (Exception) { }

        }   

    }
}




