
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
using SIIXPATM.Servicios;

namespace SIIXPATM
{
    public partial class Correo : ContentPage
    {
        private Entry txtemail, txtPassword,txtMensaje;
        private ActivityIndicator aiIndicator;
        private Button btnLogin;
        private Image imgLogo;
        private Label lblLogin;
        private StackLayout stkLogin;
        private RelativeLayout rlLogin;
        Login login = new Login();
        public Correo()
        {

            //InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);  //eliminar barra de navegación

            Padding = new Thickness(15);
            BackgroundColor = Color.FromHex("#BBFFFF");
/*            txtemail = new Entry
            {
                Placeholder = "direccion",
                PlaceholderColor = Color.SlateBlue,
                HorizontalTextAlignment = TextAlignment.Center,
                // HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.Black,

            };
  */          txtPassword = new Entry
            {
                IsPassword = true,
                Placeholder = "asunto",
                PlaceholderColor = Color.SlateBlue,
                HorizontalTextAlignment = TextAlignment.Center,
                //HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.Black,

            };
            txtMensaje = new Entry
            {
                Placeholder = "mensaje",
                PlaceholderColor = Color.SlateBlue,
                HorizontalTextAlignment = TextAlignment.Center,
                //HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.Black,

            };

            btnLogin = new Button
            {
                Text = "Enviar correo",
                BackgroundColor = Color.FromHex("#80ffe5"),
                BorderColor = Color.FromHex("#b3f0ff"),
                BorderWidth = 3,
                CornerRadius = 30,
                TextColor = Color.Black,
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
                WidthRequest = 400,
                HorizontalOptions = LayoutOptions.Center,
                Children =
            {
  //          imgLogo,
//            txtemail,
            txtPassword,
            txtMensaje,
            aiIndicator,
            btnLogin
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

//            var contacto = (Contacto)lstProfesores.SelectedItem;
            ServiciosCorreo.EnviarCorreo("14030609@itcelaya.edu.mx", txtPassword.Text, txtMensaje.Text);
 

            /*            if (string.IsNullOrEmpty(txtemail.Text))
                        {
                            await DisplayAlert("Error", "Debes introducir un us", "Aceptar");
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

                            Servicios.ServiciosCorreo.EnviarCorreo("14030609@itcelaya.edu.mx",
                                       "hola",
                                       "soy yo ");

                        }
                        catch (Exception) { }
                        */
        }

    }
}




