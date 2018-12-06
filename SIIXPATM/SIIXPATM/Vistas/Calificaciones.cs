
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
    public partial class Calificaciones : ContentPage
    {
        private Entry txtCalif_1, txtCalif_2, txtCalif_3,txtCalif_4;
        private ActivityIndicator aiIndicator;
        private Button btnActualizar;
        private Image imgLogo;
        private StackLayout stkLogin;
        private RelativeLayout rlLogin;
        Login login = new Login();
        public Calificaciones()
        {
            //InitializeComponent();
            // NavigationPage.SetHasNavigationBar(this, false);  //eliminar barra de navegación

            Padding = new Thickness(5);
            BackgroundColor = Color.FromHex("#BBFFFF");
            imgLogo = new Image
            {
                Source = "Icon.png",
            };

            var lblMateria = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                Text = Settings.Settings.MateriaName,
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };

            txtCalif_1 = new Entry
            {
                IsPassword = true,
                Placeholder = "Calif 1",
                PlaceholderColor = Color.SlateBlue,
                HorizontalTextAlignment = TextAlignment.Center,
                //HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.Black,

            };
            txtCalif_2 = new Entry
            {
                Placeholder = "Calif 2",
                PlaceholderColor = Color.SlateBlue,
                HorizontalTextAlignment = TextAlignment.Center,
                // HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.Black,

            };
            txtCalif_3 = new Entry
            {
                IsPassword = true,
                Placeholder = "Calif 3",
                PlaceholderColor = Color.SlateBlue,
                HorizontalTextAlignment = TextAlignment.Center,
                //HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.Black,

            };
            txtCalif_4 = new Entry
            {
                IsPassword = true,
                Placeholder = "Calif 4",
                PlaceholderColor = Color.SlateBlue,
                HorizontalTextAlignment = TextAlignment.Center,
                //HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.Black,

            };

            btnActualizar = new Button
            {
                Text = "Subir Calificaciones",
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
            lblMateria,
            txtCalif_1,
            txtCalif_2,
            txtCalif_3,
            txtCalif_4,
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

            aiIndicator.IsRunning = true;
            try
            {
     
                WSActualizarCalificaciones objWSAc = new WSActualizarCalificaciones();
                Boolean result3 = await objWSAc.getKardex(txtCalif_1.Text, txtCalif_2.Text, txtCalif_3.Text, txtCalif_4.Text);
                Console.Write("este es el emmail del result3 " + result3);
                await DisplayAlert("Correcto", "Acceso correcto", "Aceptar result 3 " + result3);


                await Navigation.PushModalAsync(new DashBoardMaestro());
            }
            catch (Exception) { }

        }

    }
}




