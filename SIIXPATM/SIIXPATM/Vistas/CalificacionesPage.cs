using SIIXPATM.Vistas;
using SIIXPATM.WebServices;
using System;
using SIIXPATM.Modelos;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SIIXPATM.Vistas
{
    class CalificacionesPage : ContentPage
    {
        private ListView lv_inst;
        private StackLayout st_inst;
        private List<Modelos.listas> list_inst;
        private WSCalificaciones objWsKardex;
        private DashBoard menuPage;
        //   private Label lblMateria, lblNogpo, lblMaestro, lblSalon;

        public CalificacionesPage()
        {
            list_inst = new List<Modelos.listas>();
            objWsKardex = new WSCalificaciones();
            //   NavigationPage.SetHasNavigationBar(this, false);  //eliminar barra de navegación
            DashBoard dashBoard = new DashBoard();

            CrearGUIAsync();
        }
        public void CrearGUIAsync()
        {

            menuPage = new DashBoard();
            menuPage.lvMenu.ItemSelected += (sender, e) => NavigationToPage(e.SelectedItem as Item);

            var lblMateria = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                Text = "Materia",
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
            var lblParcial_1 = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                Text = "Parcial 1",
                TextColor = Color.Gray,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold
            };

            var lblParcial_2 = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                Text = "Parcial 2",
                TextColor = Color.Gray,
                FontFamily = "Roboto",

            };
            var lblParcial_3 = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                Text = "Parcial 3",
                TextColor = Color.Gray,
                FontFamily = "Roboto",

            };

            var lblParcial_4 = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                Text = "Parcial 4",
                TextColor = Color.Gray,
                FontFamily = "Roboto",

            };


            lv_inst = new ListView()
            {
                HasUnevenRows = true, //Estandarizar items
                ItemTemplate = new DataTemplate(typeof(ResultCellAddMaterias))
            };


            st_inst = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(20),
                Children =
                {
                    new StackLayout(){
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.Center,
                        Padding = new Thickness (20),
                        Children ={lblMateria,lblParcial_1,lblParcial_2,lblParcial_3,lblParcial_4 }
                    },
                    lv_inst
                }
            };
            Content = st_inst;
        }

        public void NavigationToPage(Item item)
        {
            Page pagina = (Page)Activator.CreateInstance(item.page);
            NavigationPage Detail = new NavigationPage(pagina);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                NavigationPage.SetHasNavigationBar(this, true);  //eliminar barra de navegación

                lv_inst.IsVisible = false;
                list_inst = await objWsKardex.getKardex();
//                await DisplayAlert("Correcto", "Acceso correcto", "Aceptar materia " + list_inst[0].materia);

                lv_inst.ItemsSource = list_inst;
                lv_inst.IsVisible = true;
            }
            catch (Exception e) { await DisplayAlert("", e.StackTrace, ""); }

        }

    }
    class ResultCellAddMaterias : ViewCell
    {
        public ResultCellAddMaterias()
        {
            int width = 100, heigh = 35;

            var lblmateria = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                HeightRequest = heigh,
                WidthRequest = 30,
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
            lblmateria.SetBinding(Label.TextProperty, "cvemat");
            var lblQualification = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 10,
                HeightRequest = heigh,
                WidthRequest = 30,
                TextColor = Color.Gray,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold
            };
            lblQualification.SetBinding(Label.TextProperty, "parcial_1");

            var lblSemester = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 10,
                HeightRequest = heigh,
                WidthRequest = 30,
                TextColor = Color.Gray,
                FontFamily = "Roboto",

            };
            lblSemester.SetBinding(Label.TextProperty, "parcial_2");

            var lblParcial_3 = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 10,
                HeightRequest = heigh,
                WidthRequest = 30,
                TextColor = Color.Gray,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold
            };
            lblParcial_3.SetBinding(Label.TextProperty, "parcial_3");

            var lblParcial_4 = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 10,
                HeightRequest = heigh,
                WidthRequest = 30,
                TextColor = Color.Gray,
                FontFamily = "Roboto",

            };
            lblParcial_4.SetBinding(Label.TextProperty, "parcial_4");


            var stackList = new StackLayout
            {
                Padding = new Thickness(10),
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    lblmateria,
                    lblQualification,
                    lblSemester,
                    lblParcial_3,
                    lblParcial_4
                }
            };
            View = stackList;
        }

    }
}
